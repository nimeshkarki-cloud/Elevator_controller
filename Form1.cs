using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Timer = System.Windows.Forms.Timer;

namespace ElevatorApp
{
    public partial class Form1 : Form, IElevatorObserver
    {
        static readonly Color Back = Color.FromArgb(24, 28, 40);
        static readonly Color Card = Color.FromArgb(38, 44, 62);
        static readonly Color Key = Color.FromArgb(52, 60, 84);
        static readonly Color Ink = Color.FromArgb(235, 238, 245);
        static readonly Color Dim = Color.FromArgb(139, 147, 168);
        static readonly Color Teal = Color.FromArgb(46, 196, 182);
        static readonly Color Amber = Color.FromArgb(255, 183, 3);

        readonly Dispatcher dispatcher = new Dispatcher();
        readonly Timer clock = new Timer { Interval = 50 };    // लिफ्ट ढिलो र स्मूथ हिँड्नका लागि इन्टरभल ५० बनाइएको छ
        readonly bool[] hallLit = new bool[2];                  // call button lights, one per floor
        readonly ElevatorContext liftA = new ElevatorContext("A", 0);
        readonly ElevatorContext liftB = new ElevatorContext("B", 1);
        Button[] hallBtn;
        Label[] floorStatus;
        LogService logs;

        public Form1()
        {
            InitializeComponent();

            dispatcher.Lifts.Add(liftA);
            dispatcher.Lifts.Add(liftB);

            hallBtn = new Button[] { btnReq0, btnReq1 };
            floorStatus = new Label[] { lblFloorStatus0, lblFloorStatus1 };
            btnReq0.Tag = 0; btnReq1.Tag = 1;

            btnCar0.Tag = 0; btnCar0.Text = Floors.Show(0).ToString();
            btnCar1.Tag = 1; btnCar1.Text = Floors.Show(1).ToString();
            btnCar0B.Tag = 0; btnCar0B.Text = Floors.Show(0).ToString();
            btnCar1B.Tag = 1; btnCar1B.Text = Floors.Show(1).ToString();

            toolTip1.SetToolTip(btnOpenA, "Open doors");
            toolTip1.SetToolTip(btnCloseA, "Close doors");
            toolTip1.SetToolTip(btnOpenB, "Open doors");
            toolTip1.SetToolTip(btnCloseB, "Close doors");
            toolTip1.SetToolTip(btnReq1, "Call a lift to this floor");
            toolTip1.SetToolTip(btnReq0, "Call a lift to this floor");

            StyleGrid();

            try
            {
                logs = new LogService(new ElevatorLog());
                logs.Loaded += table => grid.DataSource = table;
                logs.Failed += ShowError;
                logs.AutoRefresh = true;
            }
            catch (Exception ex) { ShowError(ex); }

            var logger = new LogObserver((lift, floor, action) => { if (logs != null) logs.Save(lift, floor, action); });
            foreach (ElevatorContext l in dispatcher.Lifts)
            {
                l.Attach(logger);      // observer 1: logging
                l.Attach(this);        // observer 2: this form (displays, doors, call lights)
            }

            clock.Tick += (s, e) => dispatcher.Tick();
            clock.Start();

            OnLiftChanged(liftA);
            OnLiftChanged(liftB);
        }

        // ---------- buttons (one handler per kind, shared by both lifts) ----------
        ElevatorContext LiftOf(object sender)
        {
            return ((Control)sender).Parent == grpB ? liftB : liftA;
        }

        void CallButton_Click(object sender, EventArgs e)
        {
            int floor = (int)((Button)sender).Tag;
            hallLit[floor] = true;
            ElevatorContext chosen = dispatcher.Assign(floor);
            lblInfo.Text = "Call at floor " + Floors.Show(floor) + " -> Lift " + chosen.Name;
            RefreshHall();
        }

        void PanelButton_Click(object sender, EventArgs e)
        {
            LiftOf(sender).RequestMove((int)((Button)sender).Tag);
        }

        void OpenButton_Click(object sender, EventArgs e) { LiftOf(sender).OpenDoors(); }
        void CloseButton_Click(object sender, EventArgs e) { LiftOf(sender).CloseDoors(); }

        void BtnLog_Click(object sender, EventArgs e)
        {
            if (logs == null) return;
            logs.AutoRefresh = true;
            logs.Load();
        }

        // ---------- Observer: called whenever a lift changes ----------
        public void OnLiftChanged(ElevatorContext lift)
        {
            if (lift == liftA) ShowLift(lift, shaftA, carA, lblDisplay, lblDoor, btnCar0, btnCar1, btnOpenA);
            else ShowLift(lift, shaftB, carB, lblDisplayB, lblDoorB, btnCar0B, btnCar1B, btnOpenB);
            RefreshHall();
        }

        void ShowLift(ElevatorContext lift, Panel shaft, CarPanel car, Label display, Label door,
                      Button floor0, Button floor1, Button open)
        {
            int span = shaft.ClientSize.Height - car.Height - 16;
            car.Top = 8 + (span * (ElevatorContext.TravelTicks - lift.PosTicks)) / ElevatorContext.TravelTicks;
            car.DoorsOpen = lift.DoorsAreOpen;

            string arrow = lift.IsMoving ? (lift.Target > lift.Floor ? " \u25B2" : " \u25BC") : "";
            display.Text = Floors.Show(lift.Floor) + arrow;

            door.Text = lift.DoorsAreOpen ? "Doors: OPEN" : "Doors: CLOSED";
            door.ForeColor = lift.DoorsAreOpen ? Teal : Dim;

            Light(floor0, lift.IsPending(0));
            Light(floor1, lift.IsPending(1));
            Light(open, lift.DoorsAreOpen, true);
        }

        void RefreshHall()
        {
            for (int f = 0; f < 2; f++)
            {
                var here = new List<string>();
                foreach (ElevatorContext l in dispatcher.Lifts)
                {
                    if (l.Floor == f && !l.IsMoving) here.Add(l.Name);
                    if (l.Floor == f && l.DoorsAreOpen) hallLit[f] = false;   // a lift arrived: light goes out
                }
                floorStatus[f].Text = "Floor " + Floors.Show(f) + "\n" + (here.Count == 0 ? "-" : "Lift " + string.Join(", ", here.ToArray()));
                Light(hallBtn[f], hallLit[f]);
            }
        }

        static void Light(Button b, bool on, bool teal = false)
        {
            b.BackColor = on ? (teal ? Teal : Amber) : Key;
            b.ForeColor = on ? Back : Ink;
        }

        // ---------- helpers ----------
        void StyleGrid()
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.BorderStyle = BorderStyle.None;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Back;
            grid.GridColor = Card;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Card;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Teal;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Card;
            grid.DefaultCellStyle.BackColor = Back;
            grid.DefaultCellStyle.ForeColor = Ink;
            grid.DefaultCellStyle.SelectionBackColor = Teal;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 35, 50);
        }

        void ShowError(Exception ex)
        {
            MessageBox.Show("Database problem: " + ex.Message, "Elevator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void grpB_Enter(object sender, EventArgs e)
        {

        }
    }
}