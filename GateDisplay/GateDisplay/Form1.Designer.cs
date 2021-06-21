namespace GateDisplay
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblID = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblOtherGate = new System.Windows.Forms.Label();
            this.spGate = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 33.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(83, 46);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(187, 65);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "GATE";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.Black;
            this.lblState.Location = new System.Drawing.Point(85, 134);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(151, 52);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "OPEN";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOtherGate
            // 
            this.lblOtherGate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherGate.ForeColor = System.Drawing.Color.Black;
            this.lblOtherGate.Location = new System.Drawing.Point(-3, 201);
            this.lblOtherGate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOtherGate.Name = "lblOtherGate";
            this.lblOtherGate.Size = new System.Drawing.Size(356, 44);
            this.lblOtherGate.TabIndex = 2;
            this.lblOtherGate.Text = "Go to gate";
            this.lblOtherGate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOtherGate.Visible = false;
            // 
            // spGate
            // 
            this.spGate.BaudRate = 115200;
            this.spGate.PortName = "COM5";
            this.spGate.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spGate_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(352, 298);
            this.Controls.Add(this.lblOtherGate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblID);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblOtherGate;
        private System.IO.Ports.SerialPort spGate;
    }
}

