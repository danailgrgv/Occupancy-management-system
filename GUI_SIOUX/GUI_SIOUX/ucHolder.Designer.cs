
namespace GUI_SIOUX
{
    partial class ucHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHolder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbExit = new System.Windows.Forms.Label();
            this.lbQueue = new System.Windows.Forms.Label();
            this.lbGateNr = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.pbDelete);
            this.panel1.Controls.Add(this.lbExit);
            this.panel1.Controls.Add(this.lbQueue);
            this.panel1.Controls.Add(this.lbGateNr);
            this.panel1.Controls.Add(this.lbPass);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 160);
            this.panel1.TabIndex = 2;
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbExit.ForeColor = System.Drawing.SystemColors.Control;
            this.lbExit.Location = new System.Drawing.Point(71, 89);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(60, 20);
            this.lbExit.TabIndex = 2;
            this.lbExit.Text = "Exited:";
            // 
            // lbQueue
            // 
            this.lbQueue.AutoSize = true;
            this.lbQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbQueue.ForeColor = System.Drawing.Color.Yellow;
            this.lbQueue.Location = new System.Drawing.Point(3, 123);
            this.lbQueue.Name = "lbQueue";
            this.lbQueue.Size = new System.Drawing.Size(159, 25);
            this.lbQueue.TabIndex = 1;
            this.lbQueue.Text = "There is a queue";
            // 
            // lbGateNr
            // 
            this.lbGateNr.AutoSize = true;
            this.lbGateNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGateNr.ForeColor = System.Drawing.SystemColors.Control;
            this.lbGateNr.Location = new System.Drawing.Point(63, 9);
            this.lbGateNr.Name = "lbGateNr";
            this.lbGateNr.Size = new System.Drawing.Size(71, 25);
            this.lbGateNr.TabIndex = 1;
            this.lbGateNr.Text = "Gate - ";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPass.ForeColor = System.Drawing.SystemColors.Control;
            this.lbPass.Location = new System.Drawing.Point(71, 59);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(72, 20);
            this.lbPass.TabIndex = 1;
            this.lbPass.Text = "Entered:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI_SIOUX.Properties.Resources.access_3_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbDelete
            // 
            this.pbDelete.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(179, 123);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(38, 34);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDelete.TabIndex = 3;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // ucHolder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.panel1);
            this.Name = "ucHolder";
            this.Size = new System.Drawing.Size(220, 160);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbQueue;
        private System.Windows.Forms.Label lbGateNr;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.PictureBox pbDelete;
    }
}
