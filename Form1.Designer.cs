namespace ElevatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            btnReq1 = new Button();
            lblFloorStatus1 = new Label();
            btnReq0 = new Button();
            lblFloorStatus0 = new Label();
            shaftA = new Panel();
            carA = new CarPanel();
            shaftB = new Panel();
            carB = new CarPanel();
            lblDisplay = new Label();
            btnCar1 = new Button();
            btnCar0 = new Button();
            btnOpenA = new Button();
            btnCloseA = new Button();
            lblDoor = new Label();
            grpA = new GroupBox();
            lblDisplayB = new Label();
            btnCar1B = new Button();
            btnCar0B = new Button();
            btnOpenB = new Button();
            btnCloseB = new Button();
            lblDoorB = new Label();
            grpB = new GroupBox();
            btnLog = new Button();
            lblLog = new Label();
            lblInfo = new Label();
            grid = new DataGridView();
            toolTip1 = new ToolTip(components);
            shaftA.SuspendLayout();
            shaftB.SuspendLayout();
            grpA.SuspendLayout();
            grpB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 196, 182);
            lblTitle.Location = new Point(21, 12);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(750, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Two-Elevator Controller";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnReq1
            // 
            btnReq1.BackColor = Color.FromArgb(52, 60, 84);
            btnReq1.Cursor = Cursors.Hand;
            btnReq1.FlatAppearance.BorderSize = 0;
            btnReq1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnReq1.FlatStyle = FlatStyle.Flat;
            btnReq1.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold);
            btnReq1.ForeColor = Color.FromArgb(235, 238, 245);
            btnReq1.Location = new Point(21, 72);
            btnReq1.Margin = new Padding(4, 4, 4, 4);
            btnReq1.Name = "btnReq1";
            btnReq1.Size = new Size(150, 78);
            btnReq1.TabIndex = 1;
            btnReq1.Text = "▼";
            btnReq1.UseVisualStyleBackColor = false;
            btnReq1.Click += CallButton_Click;
            // 
            // lblFloorStatus1
            // 
            lblFloorStatus1.BackColor = Color.Black;
            lblFloorStatus1.Font = new Font("Consolas", 10F, FontStyle.Bold);
            lblFloorStatus1.ForeColor = Color.FromArgb(255, 183, 3);
            lblFloorStatus1.Location = new Point(21, 156);
            lblFloorStatus1.Margin = new Padding(4, 0, 4, 0);
            lblFloorStatus1.Name = "lblFloorStatus1";
            lblFloorStatus1.Size = new Size(150, 69);
            lblFloorStatus1.TabIndex = 2;
            lblFloorStatus1.Text = "Floor 2\nLift B";
            lblFloorStatus1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReq0
            // 
            btnReq0.BackColor = Color.FromArgb(52, 60, 84);
            btnReq0.Cursor = Cursors.Hand;
            btnReq0.FlatAppearance.BorderSize = 0;
            btnReq0.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnReq0.FlatStyle = FlatStyle.Flat;
            btnReq0.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold);
            btnReq0.ForeColor = Color.FromArgb(235, 238, 245);
            btnReq0.Location = new Point(21, 354);
            btnReq0.Margin = new Padding(4, 4, 4, 4);
            btnReq0.Name = "btnReq0";
            btnReq0.Size = new Size(150, 78);
            btnReq0.TabIndex = 3;
            btnReq0.Text = "▲";
            btnReq0.UseVisualStyleBackColor = false;
            btnReq0.Click += CallButton_Click;
            // 
            // lblFloorStatus0
            // 
            lblFloorStatus0.BackColor = Color.Black;
            lblFloorStatus0.Font = new Font("Consolas", 10F, FontStyle.Bold);
            lblFloorStatus0.ForeColor = Color.FromArgb(255, 183, 3);
            lblFloorStatus0.Location = new Point(21, 438);
            lblFloorStatus0.Margin = new Padding(4, 0, 4, 0);
            lblFloorStatus0.Name = "lblFloorStatus0";
            lblFloorStatus0.Size = new Size(150, 69);
            lblFloorStatus0.TabIndex = 4;
            lblFloorStatus0.Text = "Floor 1\nLift A";
            lblFloorStatus0.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // shaftA
            // 
            shaftA.BackColor = Color.FromArgb(14, 17, 26);
            shaftA.Controls.Add(carA);
            shaftA.Location = new Point(195, 72);
            shaftA.Margin = new Padding(4, 4, 4, 4);
            shaftA.Name = "shaftA";
            shaftA.Size = new Size(126, 438);
            shaftA.TabIndex = 5;
            // 
            // carA
            // 
            carA.Accent = Color.FromArgb(46, 196, 182);
            carA.Location = new Point(15, 300);
            carA.Margin = new Padding(4, 4, 4, 4);
            carA.Name = "carA";
            carA.Size = new Size(96, 126);
            carA.TabIndex = 0;
            // 
            // shaftB
            // 
            shaftB.BackColor = Color.FromArgb(14, 17, 26);
            shaftB.Controls.Add(carB);
            shaftB.Location = new Point(339, 72);
            shaftB.Margin = new Padding(4, 4, 4, 4);
            shaftB.Name = "shaftB";
            shaftB.Size = new Size(126, 438);
            shaftB.TabIndex = 6;
            // 
            // carB
            // 
            carB.Accent = Color.FromArgb(127, 119, 221);
            carB.Location = new Point(15, 12);
            carB.Margin = new Padding(4, 4, 4, 4);
            carB.Name = "carB";
            carB.Size = new Size(96, 126);
            carB.TabIndex = 0;
            // 
            // lblDisplay
            // 
            lblDisplay.BackColor = Color.Black;
            lblDisplay.Font = new Font("Consolas", 20F, FontStyle.Bold);
            lblDisplay.ForeColor = Color.FromArgb(255, 183, 3);
            lblDisplay.Location = new Point(15, 36);
            lblDisplay.Margin = new Padding(4, 0, 4, 0);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(195, 66);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "1";
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCar1
            // 
            btnCar1.BackColor = Color.FromArgb(52, 60, 84);
            btnCar1.Cursor = Cursors.Hand;
            btnCar1.FlatAppearance.BorderSize = 0;
            btnCar1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCar1.FlatStyle = FlatStyle.Flat;
            btnCar1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCar1.ForeColor = Color.FromArgb(235, 238, 245);
            btnCar1.Location = new Point(68, 114);
            btnCar1.Margin = new Padding(4, 4, 4, 4);
            btnCar1.Name = "btnCar1";
            btnCar1.Size = new Size(90, 81);
            btnCar1.TabIndex = 1;
            btnCar1.Text = "2";
            btnCar1.UseVisualStyleBackColor = false;
            btnCar1.Click += PanelButton_Click;
            // 
            // btnCar0
            // 
            btnCar0.BackColor = Color.FromArgb(52, 60, 84);
            btnCar0.Cursor = Cursors.Hand;
            btnCar0.FlatAppearance.BorderSize = 0;
            btnCar0.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCar0.FlatStyle = FlatStyle.Flat;
            btnCar0.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCar0.ForeColor = Color.FromArgb(235, 238, 245);
            btnCar0.Location = new Point(68, 207);
            btnCar0.Margin = new Padding(4, 4, 4, 4);
            btnCar0.Name = "btnCar0";
            btnCar0.Size = new Size(90, 81);
            btnCar0.TabIndex = 2;
            btnCar0.Text = "1";
            btnCar0.UseVisualStyleBackColor = false;
            btnCar0.Click += PanelButton_Click;
            // 
            // btnOpenA
            // 
            btnOpenA.BackColor = Color.FromArgb(52, 60, 84);
            btnOpenA.Cursor = Cursors.Hand;
            btnOpenA.FlatAppearance.BorderSize = 0;
            btnOpenA.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnOpenA.FlatStyle = FlatStyle.Flat;
            btnOpenA.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold);
            btnOpenA.ForeColor = Color.FromArgb(235, 238, 245);
            btnOpenA.Location = new Point(15, 306);
            btnOpenA.Margin = new Padding(4, 4, 4, 4);
            btnOpenA.Name = "btnOpenA";
            btnOpenA.Size = new Size(93, 54);
            btnOpenA.TabIndex = 3;
            btnOpenA.Text = "◀|▶";
            btnOpenA.UseVisualStyleBackColor = false;
            btnOpenA.Click += OpenButton_Click;
            // 
            // btnCloseA
            // 
            btnCloseA.BackColor = Color.FromArgb(52, 60, 84);
            btnCloseA.Cursor = Cursors.Hand;
            btnCloseA.FlatAppearance.BorderSize = 0;
            btnCloseA.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCloseA.FlatStyle = FlatStyle.Flat;
            btnCloseA.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold);
            btnCloseA.ForeColor = Color.FromArgb(235, 238, 245);
            btnCloseA.Location = new Point(117, 306);
            btnCloseA.Margin = new Padding(4, 4, 4, 4);
            btnCloseA.Name = "btnCloseA";
            btnCloseA.Size = new Size(93, 54);
            btnCloseA.TabIndex = 4;
            btnCloseA.Text = "▶|◀";
            btnCloseA.UseVisualStyleBackColor = false;
            btnCloseA.Click += CloseButton_Click;
            // 
            // lblDoor
            // 
            lblDoor.Font = new Font("Segoe UI", 9.5F);
            lblDoor.ForeColor = Color.FromArgb(139, 147, 168);
            lblDoor.Location = new Point(15, 378);
            lblDoor.Margin = new Padding(4, 0, 4, 0);
            lblDoor.Name = "lblDoor";
            lblDoor.Size = new Size(195, 36);
            lblDoor.TabIndex = 5;
            lblDoor.Text = "Doors: CLOSED";
            lblDoor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpA
            // 
            grpA.BackColor = Color.FromArgb(38, 44, 62);
            grpA.Controls.Add(lblDisplay);
            grpA.Controls.Add(btnCar1);
            grpA.Controls.Add(btnCar0);
            grpA.Controls.Add(btnOpenA);
            grpA.Controls.Add(btnCloseA);
            grpA.Controls.Add(lblDoor);
            grpA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpA.ForeColor = Color.FromArgb(46, 196, 182);
            grpA.Location = new Point(495, 72);
            grpA.Margin = new Padding(4, 4, 4, 4);
            grpA.Name = "grpA";
            grpA.Padding = new Padding(4, 4, 4, 4);
            grpA.Size = new Size(225, 438);
            grpA.TabIndex = 7;
            grpA.TabStop = false;
            grpA.Text = "Lift A Panel";
            // 
            // lblDisplayB
            // 
            lblDisplayB.BackColor = Color.Black;
            lblDisplayB.Font = new Font("Consolas", 20F, FontStyle.Bold);
            lblDisplayB.ForeColor = Color.FromArgb(255, 183, 3);
            lblDisplayB.Location = new Point(15, 36);
            lblDisplayB.Margin = new Padding(4, 0, 4, 0);
            lblDisplayB.Name = "lblDisplayB";
            lblDisplayB.Size = new Size(195, 66);
            lblDisplayB.TabIndex = 0;
            lblDisplayB.Text = "2";
            lblDisplayB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCar1B
            // 
            btnCar1B.BackColor = Color.FromArgb(52, 60, 84);
            btnCar1B.Cursor = Cursors.Hand;
            btnCar1B.FlatAppearance.BorderSize = 0;
            btnCar1B.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCar1B.FlatStyle = FlatStyle.Flat;
            btnCar1B.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCar1B.ForeColor = Color.FromArgb(235, 238, 245);
            btnCar1B.Location = new Point(68, 114);
            btnCar1B.Margin = new Padding(4, 4, 4, 4);
            btnCar1B.Name = "btnCar1B";
            btnCar1B.Size = new Size(90, 81);
            btnCar1B.TabIndex = 1;
            btnCar1B.Text = "2";
            btnCar1B.UseVisualStyleBackColor = false;
            btnCar1B.Click += PanelButton_Click;
            // 
            // btnCar0B
            // 
            btnCar0B.BackColor = Color.FromArgb(52, 60, 84);
            btnCar0B.Cursor = Cursors.Hand;
            btnCar0B.FlatAppearance.BorderSize = 0;
            btnCar0B.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCar0B.FlatStyle = FlatStyle.Flat;
            btnCar0B.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCar0B.ForeColor = Color.FromArgb(235, 238, 245);
            btnCar0B.Location = new Point(68, 217);
            btnCar0B.Margin = new Padding(4, 4, 4, 4);
            btnCar0B.Name = "btnCar0B";
            btnCar0B.Size = new Size(90, 81);
            btnCar0B.TabIndex = 2;
            btnCar0B.Text = "1";
            btnCar0B.UseVisualStyleBackColor = false;
            btnCar0B.Click += PanelButton_Click;
            // 
            // btnOpenB
            // 
            btnOpenB.BackColor = Color.FromArgb(52, 60, 84);
            btnOpenB.Cursor = Cursors.Hand;
            btnOpenB.FlatAppearance.BorderSize = 0;
            btnOpenB.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnOpenB.FlatStyle = FlatStyle.Flat;
            btnOpenB.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold);
            btnOpenB.ForeColor = Color.FromArgb(235, 238, 245);
            btnOpenB.Location = new Point(15, 306);
            btnOpenB.Margin = new Padding(4, 4, 4, 4);
            btnOpenB.Name = "btnOpenB";
            btnOpenB.Size = new Size(93, 54);
            btnOpenB.TabIndex = 3;
            btnOpenB.Text = "◀|▶";
            btnOpenB.UseVisualStyleBackColor = false;
            btnOpenB.Click += OpenButton_Click;
            // 
            // btnCloseB
            // 
            btnCloseB.BackColor = Color.FromArgb(52, 60, 84);
            btnCloseB.Cursor = Cursors.Hand;
            btnCloseB.FlatAppearance.BorderSize = 0;
            btnCloseB.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnCloseB.FlatStyle = FlatStyle.Flat;
            btnCloseB.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold);
            btnCloseB.ForeColor = Color.FromArgb(235, 238, 245);
            btnCloseB.Location = new Point(117, 306);
            btnCloseB.Margin = new Padding(4, 4, 4, 4);
            btnCloseB.Name = "btnCloseB";
            btnCloseB.Size = new Size(93, 54);
            btnCloseB.TabIndex = 4;
            btnCloseB.Text = "▶|◀";
            btnCloseB.UseVisualStyleBackColor = false;
            btnCloseB.Click += CloseButton_Click;
            // 
            // lblDoorB
            // 
            lblDoorB.Font = new Font("Segoe UI", 9.5F);
            lblDoorB.ForeColor = Color.FromArgb(139, 147, 168);
            lblDoorB.Location = new Point(15, 378);
            lblDoorB.Margin = new Padding(4, 0, 4, 0);
            lblDoorB.Name = "lblDoorB";
            lblDoorB.Size = new Size(195, 36);
            lblDoorB.TabIndex = 5;
            lblDoorB.Text = "Doors: CLOSED";
            lblDoorB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpB
            // 
            grpB.BackColor = Color.FromArgb(38, 44, 62);
            grpB.Controls.Add(lblDisplayB);
            grpB.Controls.Add(btnCar1B);
            grpB.Controls.Add(btnCar0B);
            grpB.Controls.Add(btnOpenB);
            grpB.Controls.Add(btnCloseB);
            grpB.Controls.Add(lblDoorB);
            grpB.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpB.ForeColor = Color.FromArgb(46, 196, 182);
            grpB.Location = new Point(735, 72);
            grpB.Margin = new Padding(4, 4, 4, 4);
            grpB.Name = "grpB";
            grpB.Padding = new Padding(4, 4, 4, 4);
            grpB.Size = new Size(225, 438);
            grpB.TabIndex = 8;
            grpB.TabStop = false;
            grpB.Text = "Lift B Panel";
            grpB.Enter += grpB_Enter;
            // 
            // btnLog
            // 
            btnLog.BackColor = Color.FromArgb(46, 196, 182);
            btnLog.Cursor = Cursors.Hand;
            btnLog.FlatAppearance.BorderSize = 0;
            btnLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 82, 112);
            btnLog.FlatStyle = FlatStyle.Flat;
            btnLog.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLog.ForeColor = Color.FromArgb(4, 52, 44);
            btnLog.Location = new Point(996, 59);
            btnLog.Margin = new Padding(4, 4, 4, 4);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(180, 66);
            btnLog.TabIndex = 9;
            btnLog.Text = "Show log";
            btnLog.UseVisualStyleBackColor = false;
            btnLog.Click += BtnLog_Click;
            // 
            // lblLog
            // 
            lblLog.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLog.ForeColor = Color.FromArgb(46, 196, 182);
            lblLog.Location = new Point(21, 528);
            lblLog.Margin = new Padding(4, 0, 4, 0);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(225, 36);
            lblLog.TabIndex = 10;
            lblLog.Text = "Operation log";
            lblLog.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 9.5F);
            lblInfo.ForeColor = Color.FromArgb(139, 147, 168);
            lblInfo.Location = new Point(255, 528);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(720, 36);
            lblInfo.TabIndex = 11;
            lblInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grid
            // 
            grid.ColumnHeadersHeight = 34;
            grid.Location = new Point(21, 570);
            grid.Margin = new Padding(4, 4, 4, 4);
            grid.Name = "grid";
            grid.RowHeadersWidth = 62;
            grid.Size = new Size(1155, 324);
            grid.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(24, 28, 40);
            ClientSize = new Size(1200, 915);
            Controls.Add(lblTitle);
            Controls.Add(btnReq1);
            Controls.Add(lblFloorStatus1);
            Controls.Add(btnReq0);
            Controls.Add(lblFloorStatus0);
            Controls.Add(shaftA);
            Controls.Add(shaftB);
            Controls.Add(grpA);
            Controls.Add(grpB);
            Controls.Add(btnLog);
            Controls.Add(lblLog);
            Controls.Add(lblInfo);
            Controls.Add(grid);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Two-Elevator Controller";
            shaftA.ResumeLayout(false);
            shaftB.ResumeLayout(false);
            grpA.ResumeLayout(false);
            grpB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReq1;
        private System.Windows.Forms.Label lblFloorStatus1;
        private System.Windows.Forms.Button btnReq0;
        private System.Windows.Forms.Label lblFloorStatus0;
        private System.Windows.Forms.Panel shaftA;
        private ElevatorApp.CarPanel carA;
        private System.Windows.Forms.Panel shaftB;
        private ElevatorApp.CarPanel carB;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnCar1;
        private System.Windows.Forms.Button btnCar0;
        private System.Windows.Forms.Button btnOpenA;
        private System.Windows.Forms.Button btnCloseA;
        private System.Windows.Forms.Label lblDoor;
        private System.Windows.Forms.GroupBox grpA;
        private System.Windows.Forms.Label lblDisplayB;
        private System.Windows.Forms.Button btnCar1B;
        private System.Windows.Forms.Button btnCar0B;
        private System.Windows.Forms.Button btnOpenB;
        private System.Windows.Forms.Button btnCloseB;
        private System.Windows.Forms.Label lblDoorB;
        private System.Windows.Forms.GroupBox grpB;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}