
namespace GUI_SIOUX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnSetings = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.pbLogoTime = new System.Windows.Forms.PictureBox();
            this.timerNowTime = new System.Windows.Forms.Timer(this.components);
            this.ucStettings1 = new GUI_SIOUX.ucSettings();
            this.ucStatistics1 = new GUI_SIOUX.ucStatistics();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(53)))));
            this.panelSide.Controls.Add(this.btnSetings);
            this.panelSide.Controls.Add(this.btnStatistics);
            this.panelSide.Controls.Add(this.pbLogo);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(239, 503);
            this.panelSide.TabIndex = 0;
            // 
            // btnSetings
            // 
            this.btnSetings.FlatAppearance.BorderSize = 0;
            this.btnSetings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSetings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(115)))), ((int)(((byte)(233)))));
            this.btnSetings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSetings.Image = ((System.Drawing.Image)(resources.GetObject("btnSetings.Image")));
            this.btnSetings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetings.Location = new System.Drawing.Point(0, 257);
            this.btnSetings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetings.Name = "btnSetings";
            this.btnSetings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSetings.Size = new System.Drawing.Size(239, 58);
            this.btnSetings.TabIndex = 3;
            this.btnSetings.Text = "       Gate Info";
            this.btnSetings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetings.UseVisualStyleBackColor = true;
            this.btnSetings.Click += new System.EventHandler(this.btnSetings_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnStatistics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(115)))), ((int)(((byte)(233)))));
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatistics.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistics.Image")));
            this.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.Location = new System.Drawing.Point(0, 194);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStatistics.Size = new System.Drawing.Size(239, 58);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "         Statistics";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(6, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(228, 82);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            this.pbLogo.MouseEnter += new System.EventHandler(this.pbLogo_MouseEnter);
            this.pbLogo.MouseLeave += new System.EventHandler(this.pbLogo_MouseLeave);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panelMain.Controls.Add(this.ucStettings1);
            this.panelMain.Controls.Add(this.ucStatistics1);
            this.panelMain.Controls.Add(this.lbTime);
            this.panelMain.Controls.Add(this.pbLogoTime);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(239, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(693, 503);
            this.panelMain.TabIndex = 1;
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTime.Location = new System.Drawing.Point(6, 302);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(684, 57);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "Time";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogoTime
            // 
            this.pbLogoTime.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoTime.Image")));
            this.pbLogoTime.Location = new System.Drawing.Point(258, 204);
            this.pbLogoTime.Name = "pbLogoTime";
            this.pbLogoTime.Size = new System.Drawing.Size(185, 90);
            this.pbLogoTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoTime.TabIndex = 2;
            this.pbLogoTime.TabStop = false;
            // 
            // timerNowTime
            // 
            this.timerNowTime.Enabled = true;
            this.timerNowTime.Interval = 1000;
            this.timerNowTime.Tick += new System.EventHandler(this.timerNowTime_Tick);
            // 
            // ucStettings1
            // 
            this.ucStettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.ucStettings1.Location = new System.Drawing.Point(0, 0);
            this.ucStettings1.Name = "ucStettings1";
            this.ucStettings1.Size = new System.Drawing.Size(695, 503);
            this.ucStettings1.TabIndex = 5;
            this.ucStettings1.ucStatistics1 = null;
            // 
            // ucStatistics1
            // 
            this.ucStatistics1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.ucStatistics1.Location = new System.Drawing.Point(0, 0);
            this.ucStatistics1.Name = "ucStatistics1";
            this.ucStatistics1.Size = new System.Drawing.Size(695, 503);
            this.ucStatistics1.TabIndex = 4;
            this.ucStatistics1.ucSettings1 = null;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(932, 503);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sioux";
            this.panelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbLogoTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timerNowTime;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnSetings;
        private ucStatistics ucStatistics1;
        private ucSettings ucStettings1;
    }
}

