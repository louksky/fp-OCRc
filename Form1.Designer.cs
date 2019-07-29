namespace EdgeDetector_WF
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb_CannyThreshold = new System.Windows.Forms.TextBox();
            this.tb_CannyThresholdLinking = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_HighlightSet = new System.Windows.Forms.Button();
            this.OriginalViewer = new Ozeki.Media.VideoViewerWF();
            this.ProcessedViewer = new Ozeki.Media.VideoViewerWF();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.tb_cameraUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button_Compose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_CannyThreshold
            // 
            this.tb_CannyThreshold.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_CannyThreshold.Location = new System.Drawing.Point(155, 13);
            this.tb_CannyThreshold.Name = "tb_CannyThreshold";
            this.tb_CannyThreshold.Size = new System.Drawing.Size(87, 20);
            this.tb_CannyThreshold.TabIndex = 4;
            // 
            // tb_CannyThresholdLinking
            // 
            this.tb_CannyThresholdLinking.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_CannyThresholdLinking.Location = new System.Drawing.Point(155, 41);
            this.tb_CannyThresholdLinking.Name = "tb_CannyThresholdLinking";
            this.tb_CannyThresholdLinking.Size = new System.Drawing.Size(87, 20);
            this.tb_CannyThresholdLinking.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "CannyThresholdLinking:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "CannyThreshold:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_CannyThresholdLinking);
            this.groupBox2.Controls.Add(this.btn_HighlightSet);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_CannyThreshold);
            this.groupBox2.Location = new System.Drawing.Point(351, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 89);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // btn_HighlightSet
            // 
            this.btn_HighlightSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HighlightSet.Location = new System.Drawing.Point(258, 60);
            this.btn_HighlightSet.Name = "btn_HighlightSet";
            this.btn_HighlightSet.Size = new System.Drawing.Size(58, 23);
            this.btn_HighlightSet.TabIndex = 19;
            this.btn_HighlightSet.Text = "Set";
            this.btn_HighlightSet.UseVisualStyleBackColor = true;
            this.btn_HighlightSet.Click += new System.EventHandler(this.btn_HighlightSet_Click);
            // 
            // OriginalViewer
            // 
            this.OriginalViewer.BackColor = System.Drawing.Color.Black;
            this.OriginalViewer.ContextMenuEnabled = true;
            this.OriginalViewer.FlipMode = Ozeki.Media.FlipMode.None;
            this.OriginalViewer.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.OriginalViewer.FullScreenEnabled = true;
            this.OriginalViewer.Location = new System.Drawing.Point(10, 110);
            this.OriginalViewer.Name = "OriginalViewer";
            this.OriginalViewer.RotateAngle = 0;
            this.OriginalViewer.Size = new System.Drawing.Size(330, 240);
            this.OriginalViewer.TabIndex = 17;
            this.OriginalViewer.Text = "videoViewerWF1";
            this.OriginalViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setpoints);
            // 
            // ProcessedViewer
            // 
            this.ProcessedViewer.BackColor = System.Drawing.Color.Black;
            this.ProcessedViewer.ContextMenuEnabled = true;
            this.ProcessedViewer.FlipMode = Ozeki.Media.FlipMode.None;
            this.ProcessedViewer.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.ProcessedViewer.FullScreenEnabled = true;
            this.ProcessedViewer.Location = new System.Drawing.Point(351, 110);
            this.ProcessedViewer.Name = "ProcessedViewer";
            this.ProcessedViewer.RotateAngle = 0;
            this.ProcessedViewer.Size = new System.Drawing.Size(320, 240);
            this.ProcessedViewer.TabIndex = 18;
            this.ProcessedViewer.Text = "videoViewerWF1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.stateLabel);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.button_Connect);
            this.groupBox5.Controls.Add(this.button_Disconnect);
            this.groupBox5.Controls.Add(this.tb_cameraUrl);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.button_Compose);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 89);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connect";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(80, 72);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 13);
            this.stateLabel.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "State:";
            // 
            // button_Connect
            // 
            this.button_Connect.Enabled = false;
            this.button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Connect.ForeColor = System.Drawing.Color.Black;
            this.button_Connect.Location = new System.Drawing.Point(83, 39);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(69, 23);
            this.button_Connect.TabIndex = 18;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Disconnect.Location = new System.Drawing.Point(180, 39);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(69, 23);
            this.button_Disconnect.TabIndex = 22;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // tb_cameraUrl
            // 
            this.tb_cameraUrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_cameraUrl.Location = new System.Drawing.Point(83, 13);
            this.tb_cameraUrl.Name = "tb_cameraUrl";
            this.tb_cameraUrl.ReadOnly = true;
            this.tb_cameraUrl.Size = new System.Drawing.Size(166, 20);
            this.tb_cameraUrl.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Camera URL:";
            // 
            // button_Compose
            // 
            this.button_Compose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Compose.Location = new System.Drawing.Point(253, 11);
            this.button_Compose.Name = "button_Compose";
            this.button_Compose.Size = new System.Drawing.Size(69, 23);
            this.button_Compose.TabIndex = 19;
            this.button_Compose.Text = "Compose";
            this.button_Compose.UseVisualStyleBackColor = true;
            this.button_Compose.Click += new System.EventHandler(this.button_Compose_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(251, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "shot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::camera.Properties.Resources.p__1____Copy;
            this.pictureBox1.Location = new System.Drawing.Point(12, 357);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 231);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::camera.Properties.Resources.p__1____Copy;
            this.pictureBox2.Location = new System.Drawing.Point(352, 357);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(322, 231);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "x y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(7, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "_______________________________________________________";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(686, 591);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.ProcessedViewer);
            this.Controls.Add(this.OriginalViewer);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Edge Detection";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_CannyThreshold;
        private System.Windows.Forms.TextBox tb_CannyThresholdLinking;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_HighlightSet;
        private Ozeki.Media.VideoViewerWF OriginalViewer;
        private Ozeki.Media.VideoViewerWF ProcessedViewer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.TextBox tb_cameraUrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_Compose;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}