using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ElevatorApp
{
    // Floors are stored as 0 and 1 inside the program; Show() decides how they look on screen.
    public static class Floors
    {
        public const int Offset = 1;     // 1 = screen shows floors 1 and 2, 0 = screen shows floors 0 and 1
        public static int Show(int floor) { return floor + Offset; }
    }

    // ---------- Observer pattern ----------
    public interface IElevatorObserver
    {
        void OnLiftChanged(ElevatorContext lift);
    }

    public delegate void LogWriter(string lift, int floor, string action);

    // Observer that writes every real change of a lift to the log (through a delegate)
    public class LogObserver : IElevatorObserver
    {
        readonly LogWriter write;
        readonly Dictionary<string, string> last = new Dictionary<string, string>();

        public LogObserver(LogWriter write) { this.write = write; }

        public void OnLiftChanged(ElevatorContext lift)
        {
            string action = lift.IsMoving ? "Moving to floor " + Floors.Show(lift.Target) : lift.State.Name;
            string before;
            if (last.TryGetValue(lift.Name, out before) && before == action) return;
            last[lift.Name] = action;
            write("Lift " + lift.Name, Floors.Show(lift.Floor), action);
        }
    }

    // ---------- State pattern ----------
    public interface IElevatorState
    {
        string Name { get; }
        void Tick(ElevatorContext lift);
        int RemainingTicks(ElevatorContext lift);   // time until this state is finished (used for estimates)
    }

    public class IdleState : IElevatorState
    {
        public string Name { get { return "Idle"; } }
        public int RemainingTicks(ElevatorContext lift) { return 0; }

        public void Tick(ElevatorContext lift)
        {
            if (lift.Stops.Count == 0) return;
            lift.Target = lift.Stops.Dequeue();
            if (lift.Target == lift.Floor) lift.SetState(new DoorsOpenState());
            else lift.SetState(new MovingState());
        }
    }

    public class MovingState : IElevatorState
    {
        public string Name { get { return "Moving"; } }

        public int RemainingTicks(ElevatorContext lift)
        {
            return Math.Abs(lift.Target * ElevatorContext.TravelTicks - lift.PosTicks) + ElevatorContext.DoorTicks;
        }

        public void Tick(ElevatorContext lift)
        {
            int goal = lift.Target * ElevatorContext.TravelTicks;
            lift.PosTicks += Math.Sign(goal - lift.PosTicks);
            if (lift.PosTicks == goal)
            {
                lift.Floor = lift.Target;
                lift.SetState(new DoorsOpenState());
            }
            else lift.Notify();
        }
    }

    public class DoorsOpenState : IElevatorState
    {
        int left = ElevatorContext.DoorTicks;
        public string Name { get { return "Doors open"; } }
        public int RemainingTicks(ElevatorContext lift) { return left; }

        public void Tick(ElevatorContext lift)
        {
            left--;
            if (left <= 0) lift.SetState(new IdleState());
        }
    }

    // ---------- One lift: the context of the State pattern and the subject of the Observer pattern ----------
    public class ElevatorContext
    {
        public const int TravelTicks = 40;   // timer ticks needed to travel between the two floors
        public const int DoorTicks = 80;     // timer ticks the doors stay open

        readonly List<IElevatorObserver> observers = new List<IElevatorObserver>();

        public string Name { get; private set; }
        public int Floor { get; set; }              // last floor reached
        public int Target { get; set; }             // floor it is travelling to
        public int PosTicks { get; set; }           // exact position (floor * TravelTicks)
        public Queue<int> Stops { get; private set; }
        public IElevatorState State { get; private set; }

        public bool IsMoving { get { return State is MovingState; } }
        public bool DoorsAreOpen { get { return State is DoorsOpenState; } }

        public ElevatorContext(string name, int startFloor)
        {
            Name = name;
            Floor = startFloor;
            Target = startFloor;
            PosTicks = startFloor * TravelTicks;
            Stops = new Queue<int>();
            State = new IdleState();
        }

        public void Attach(IElevatorObserver o) { observers.Add(o); }
        public void Notify() { foreach (IElevatorObserver o in observers) o.OnLiftChanged(this); }
        public void SetState(IElevatorState s) { State = s; Notify(); }
        public void Tick() { State.Tick(this); }

        public void RequestMove(int floor)
        {
            bool alreadyComing = IsMoving && Target == floor;
            bool alreadyHere = DoorsAreOpen && Floor == floor;
            if (alreadyComing || alreadyHere || Stops.Contains(floor)) return;
            Stops.Enqueue(floor);
            Notify();
        }

        public bool IsPending(int floor)
        {
            return Stops.Contains(floor) || (IsMoving && Target == floor);
        }

        public void OpenDoors()
        {
            if (State is IdleState || State is DoorsOpenState) SetState(new DoorsOpenState());
        }

        public void CloseDoors()
        {
            if (State is DoorsOpenState) SetState(new IdleState());
        }

        // Estimated ticks until this lift could be at 'floor', without disturbing what it is already doing
        public int EstimateTicks(int floor)
        {
            if (DoorsAreOpen && Floor == floor && Stops.Count == 0) return 0;
            if (IsMoving && Target == floor) return Math.Abs(floor * TravelTicks - PosTicks);

            int time = State.RemainingTicks(this);
            int pos = IsMoving ? Target : Floor;
            foreach (int stop in Stops)
            {
                time += Math.Abs(pos - stop) * TravelTicks + DoorTicks;
                pos = stop;
            }
            return time + Math.Abs(pos - floor) * TravelTicks;
        }
    }

    // ---------- Chooses the lift with the shortest estimated response time ----------
    public class Dispatcher
    {
        public List<ElevatorContext> Lifts = new List<ElevatorContext>();

        public ElevatorContext Assign(int floor)
        {
            foreach (ElevatorContext l in Lifts)                // a lift is already coming: do not send a second one
                if (l.IsPending(floor)) return l;

            ElevatorContext best = null;
            int bestTime = int.MaxValue;
            foreach (ElevatorContext l in Lifts)
            {
                int t = l.EstimateTicks(floor);
                if (t < bestTime) { best = l; bestTime = t; }
            }
            best.RequestMove(floor);
            return best;
        }

        public void Tick() { foreach (ElevatorContext l in Lifts) l.Tick(); }
    }

    // ---------- A panel that draws a lift car with steel doors that slide open and closed ----------
    public class CarPanel : Panel
    {
        bool open;
        Color accent = Color.FromArgb(46, 196, 182);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Accent { get { return accent; } set { accent = value; Invalidate(); } }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DoorsOpen { get { return open; } set { if (open != value) { open = value; Invalidate(); } } }

        public CarPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = ClientRectangle;

            using (var frame = new SolidBrush(Color.FromArgb(58, 64, 82))) g.FillRectangle(frame, r);
            using (var lamp = new SolidBrush(accent)) g.FillRectangle(lamp, r.Width / 2 - 10, 6, 20, 6);

            Rectangle door = new Rectangle(6, 18, r.Width - 12, r.Height - 24);
            using (var dark = new SolidBrush(Color.FromArgb(20, 23, 33))) g.FillRectangle(dark, door);
            if (open)
                using (var inside = new SolidBrush(Color.FromArgb(226, 214, 190))) g.FillRectangle(inside, door);

            int leaf = open ? door.Width * 18 / 100 : door.Width / 2;
            Rectangle left = new Rectangle(door.Left, door.Top, leaf, door.Height);
            Rectangle right = new Rectangle(door.Right - leaf, door.Top, leaf, door.Height);
            using (var steel = new SolidBrush(Color.FromArgb(169, 178, 196)))
            using (var edge = new Pen(Color.FromArgb(208, 214, 226), 2))
            {
                g.FillRectangle(steel, left);
                g.FillRectangle(steel, right);
                g.DrawLine(edge, left.Right, door.Top, left.Right, door.Bottom);
                g.DrawLine(edge, right.Left, door.Top, right.Left, door.Bottom);
            }
        }
    }
}