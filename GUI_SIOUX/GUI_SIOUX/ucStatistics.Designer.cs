
namespace GUI_SIOUX
{
    partial class ucStatistics
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStatistics));
            this.cpbOccupancy = new CircularProgressBar.CircularProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLeftPlaces = new System.Windows.Forms.Label();
            this.lblOccupancy = new System.Windows.Forms.Label();
            this.lblInsideBuilding = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAssist = new System.Windows.Forms.Button();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.lblAssistance = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblToiletLeft = new System.Windows.Forms.Label();
            this.lblToilet = new System.Windows.Forms.Label();
            this.lblToiletIn = new System.Windows.Forms.Label();
            this.cpbToilet = new CircularProgressBar.CircularProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpbOccupancy
            // 
            this.cpbOccupancy.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("cpbOccupancy.AnimationFunction")));
            this.cpbOccupancy.AnimationSpeed = 50;
            this.cpbOccupancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.cpbOccupancy.Font = new System.Drawing.Font("Yu Gothic", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cpbOccupancy.ForeColor = System.Drawing.SystemColors.Control;
            this.cpbOccupancy.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.cpbOccupancy.InnerMargin = 2;
            this.cpbOccupancy.InnerWidth = -1;
            this.cpbOccupancy.Location = new System.Drawing.Point(8, 55);
            this.cpbOccupancy.MarqueeAnimationSpeed = 2000;
            this.cpbOccupancy.Name = "cpbOccupancy";
            this.cpbOccupancy.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            this.cpbOccupancy.OuterMargin = -25;
            this.cpbOccupancy.OuterWidth = 26;
            this.cpbOccupancy.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cpbOccupancy.ProgressWidth = 7;
            this.cpbOccupancy.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbOccupancy.Size = new System.Drawing.Size(175, 181);
            this.cpbOccupancy.StartAngle = 270;
            this.cpbOccupancy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.cpbOccupancy.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbOccupancy.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbOccupancy.SubscriptText = "";
            this.cpbOccupancy.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbOccupancy.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbOccupancy.SuperscriptText = "";
            this.cpbOccupancy.TabIndex = 0;
            this.cpbOccupancy.Text = "%";
            this.cpbOccupancy.TextMargin = new System.Windows.Forms.Padding(5, 8, 0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblLeftPlaces);
            this.panel1.Controls.Add(this.lblOccupancy);
            this.panel1.Controls.Add(this.lblInsideBuilding);
            this.panel1.Controls.Add(this.cpbOccupancy);
            this.panel1.Location = new System.Drawing.Point(12, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 246);
            this.panel1.TabIndex = 1;
            // 
            // lblLeftPlaces
            // 
            this.lblLeftPlaces.AutoSize = true;
            this.lblLeftPlaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeftPlaces.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLeftPlaces.Location = new System.Drawing.Point(170, 212);
            this.lblLeftPlaces.Name = "lblLeftPlaces";
            this.lblLeftPlaces.Size = new System.Drawing.Size(156, 24);
            this.lblLeftPlaces.TabIndex = 3;
            this.lblLeftPlaces.Text = "Remaining:  1000";
            // 
            // lblOccupancy
            // 
            this.lblOccupancy.AutoSize = true;
            this.lblOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOccupancy.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOccupancy.Location = new System.Drawing.Point(65, 11);
            this.lblOccupancy.Name = "lblOccupancy";
            this.lblOccupancy.Size = new System.Drawing.Size(226, 29);
            this.lblOccupancy.TabIndex = 1;
            this.lblOccupancy.Text = "Building Occupancy";
            // 
            // lblInsideBuilding
            // 
            this.lblInsideBuilding.AutoSize = true;
            this.lblInsideBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInsideBuilding.ForeColor = System.Drawing.SystemColors.Control;
            this.lblInsideBuilding.Location = new System.Drawing.Point(211, 71);
            this.lblInsideBuilding.Name = "lblInsideBuilding";
            this.lblInsideBuilding.Size = new System.Drawing.Size(80, 24);
            this.lblInsideBuilding.TabIndex = 2;
            this.lblInsideBuilding.Text = "Inside: 0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.btnAssist);
            this.panel2.Controls.Add(this.lblCO2);
            this.panel2.Controls.Add(this.lblAssistance);
            this.panel2.Controls.Add(this.lblStats);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 215);
            this.panel2.TabIndex = 1;
            // 
            // btnAssist
            // 
            this.btnAssist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAssist.BackColor = System.Drawing.Color.Lime;
            this.btnAssist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssist.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAssist.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAssist.Location = new System.Drawing.Point(545, 95);
            this.btnAssist.Name = "btnAssist";
            this.btnAssist.Size = new System.Drawing.Size(123, 117);
            this.btnAssist.TabIndex = 2;
            this.btnAssist.UseVisualStyleBackColor = false;
            this.btnAssist.Click += new System.EventHandler(this.btnAssist_Click);
            // 
            // lblCO2
            // 
            this.lblCO2.AutoSize = true;
            this.lblCO2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCO2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCO2.Location = new System.Drawing.Point(3, 95);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(148, 29);
            this.lblCO2.TabIndex = 1;
            this.lblCO2.Text = "CO2: 23ppm";
            this.lblCO2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssistance
            // 
            this.lblAssistance.AutoSize = true;
            this.lblAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAssistance.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAssistance.Location = new System.Drawing.Point(541, 68);
            this.lblAssistance.Name = "lblAssistance";
            this.lblAssistance.Size = new System.Drawing.Size(158, 24);
            this.lblAssistance.TabIndex = 1;
            this.lblAssistance.Text = "Assistance Button";
            this.lblAssistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStats.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStats.Location = new System.Drawing.Point(286, 9);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(108, 29);
            this.lblStats.TabIndex = 1;
            this.lblStats.Text = "Statistics";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.panel3.Controls.Add(this.lblToiletLeft);
            this.panel3.Controls.Add(this.lblToilet);
            this.panel3.Controls.Add(this.lblToiletIn);
            this.panel3.Controls.Add(this.cpbToilet);
            this.panel3.Location = new System.Drawing.Point(371, 242);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 246);
            this.panel3.TabIndex = 1;
            // 
            // lblToiletLeft
            // 
            this.lblToiletLeft.AutoSize = true;
            this.lblToiletLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToiletLeft.ForeColor = System.Drawing.SystemColors.Control;
            this.lblToiletLeft.Location = new System.Drawing.Point(173, 206);
            this.lblToiletLeft.Name = "lblToiletLeft";
            this.lblToiletLeft.Size = new System.Drawing.Size(136, 24);
            this.lblToiletLeft.TabIndex = 3;
            this.lblToiletLeft.Text = "Remaining:  50";
            // 
            // lblToilet
            // 
            this.lblToilet.AutoSize = true;
            this.lblToilet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToilet.ForeColor = System.Drawing.SystemColors.Control;
            this.lblToilet.Location = new System.Drawing.Point(65, 11);
            this.lblToilet.Name = "lblToilet";
            this.lblToilet.Size = new System.Drawing.Size(200, 29);
            this.lblToilet.TabIndex = 1;
            this.lblToilet.Text = "Toilet Occupancy";
            // 
            // lblToiletIn
            // 
            this.lblToiletIn.AutoSize = true;
            this.lblToiletIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToiletIn.ForeColor = System.Drawing.SystemColors.Control;
            this.lblToiletIn.Location = new System.Drawing.Point(214, 71);
            this.lblToiletIn.Name = "lblToiletIn";
            this.lblToiletIn.Size = new System.Drawing.Size(80, 24);
            this.lblToiletIn.TabIndex = 2;
            this.lblToiletIn.Text = "Inside: 0";
            // 
            // cpbToilet
            // 
            this.cpbToilet.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("cpbToilet.AnimationFunction")));
            this.cpbToilet.AnimationSpeed = 50;
            this.cpbToilet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.cpbToilet.Font = new System.Drawing.Font("Yu Gothic", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cpbToilet.ForeColor = System.Drawing.SystemColors.Control;
            this.cpbToilet.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.cpbToilet.InnerMargin = 2;
            this.cpbToilet.InnerWidth = -1;
            this.cpbToilet.Location = new System.Drawing.Point(12, 55);
            this.cpbToilet.MarqueeAnimationSpeed = 2000;
            this.cpbToilet.Name = "cpbToilet";
            this.cpbToilet.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            this.cpbToilet.OuterMargin = -25;
            this.cpbToilet.OuterWidth = 26;
            this.cpbToilet.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cpbToilet.ProgressWidth = 7;
            this.cpbToilet.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbToilet.Size = new System.Drawing.Size(175, 181);
            this.cpbToilet.StartAngle = 270;
            this.cpbToilet.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.cpbToilet.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbToilet.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbToilet.SubscriptText = "";
            this.cpbToilet.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbToilet.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbToilet.SuperscriptText = "";
            this.cpbToilet.TabIndex = 0;
            this.cpbToilet.Text = "%";
            this.cpbToilet.TextMargin = new System.Windows.Forms.Padding(5, 8, 0, 0);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // ucStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ucStatistics";
            this.Size = new System.Drawing.Size(695, 503);
            this.Leave += new System.EventHandler(this.ucStatistics_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar cpbOccupancy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblLeftPlaces;
        private System.Windows.Forms.Label lblInsideBuilding;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblToiletLeft;
        private System.Windows.Forms.Label lblToilet;
        private System.Windows.Forms.Label lblToiletIn;
        private CircularProgressBar.CircularProgressBar cpbToilet;
        private System.Windows.Forms.Button btnAssist;
        private System.Windows.Forms.Label lblAssistance;
        private System.Windows.Forms.Label lblCO2;
        public System.IO.Ports.SerialPort serialPort1;
    }
}
