namespace APTP_DB_flotting_project
{
    partial class Visualizer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizer));
            this.label_id = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.label_weight = new System.Windows.Forms.Label();
            this.ncc_acc = new Nevron.Chart.WinForm.NChartControl();
            this.ncc_bpm = new Nevron.Chart.WinForm.NChartControl();
            this.ncc_rri = new Nevron.Chart.WinForm.NChartControl();
            this.label_userinfo = new System.Windows.Forms.Label();
            this.label_timeinfo = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.Location = new System.Drawing.Point(41, 80);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(31, 16);
            this.label_id.TabIndex = 2;
            this.label_id.Text = "ID: ";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(41, 118);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(60, 16);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "Name: ";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_email.Location = new System.Drawing.Point(41, 160);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(64, 16);
            this.label_email.TabIndex = 4;
            this.label_email.Text = "E-mail: ";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_gender.Location = new System.Drawing.Point(368, 80);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(70, 16);
            this.label_gender.TabIndex = 5;
            this.label_gender.Text = "Gender: ";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_height.Location = new System.Drawing.Point(368, 118);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(63, 16);
            this.label_height.TabIndex = 6;
            this.label_height.Text = "Height: ";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_weight.Location = new System.Drawing.Point(368, 160);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(67, 16);
            this.label_weight.TabIndex = 7;
            this.label_weight.Text = "Weight: ";
            // 
            // ncc_acc
            // 
            this.ncc_acc.AutoRefresh = false;
            this.ncc_acc.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_acc.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_acc.Location = new System.Drawing.Point(622, 20);
            this.ncc_acc.Name = "ncc_acc";
            this.ncc_acc.Size = new System.Drawing.Size(550, 400);
            this.ncc_acc.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_acc.State")));
            this.ncc_acc.TabIndex = 9;
            this.ncc_acc.Text = "nChartControl1";
            // 
            // ncc_bpm
            // 
            this.ncc_bpm.AutoRefresh = false;
            this.ncc_bpm.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_bpm.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_bpm.Location = new System.Drawing.Point(18, 448);
            this.ncc_bpm.Name = "ncc_bpm";
            this.ncc_bpm.Size = new System.Drawing.Size(550, 400);
            this.ncc_bpm.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_bpm.State")));
            this.ncc_bpm.TabIndex = 10;
            this.ncc_bpm.Text = "nChartControl1";
            // 
            // ncc_rri
            // 
            this.ncc_rri.AutoRefresh = false;
            this.ncc_rri.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_rri.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_rri.Location = new System.Drawing.Point(622, 448);
            this.ncc_rri.Name = "ncc_rri";
            this.ncc_rri.Size = new System.Drawing.Size(550, 400);
            this.ncc_rri.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_rri.State")));
            this.ncc_rri.TabIndex = 11;
            this.ncc_rri.Text = "nChartControl4";
            // 
            // label_userinfo
            // 
            this.label_userinfo.AutoSize = true;
            this.label_userinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_userinfo.Location = new System.Drawing.Point(41, 42);
            this.label_userinfo.Name = "label_userinfo";
            this.label_userinfo.Size = new System.Drawing.Size(83, 16);
            this.label_userinfo.TabIndex = 12;
            this.label_userinfo.Text = "User Info";
            // 
            // label_timeinfo
            // 
            this.label_timeinfo.AutoSize = true;
            this.label_timeinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_timeinfo.Location = new System.Drawing.Point(41, 225);
            this.label_timeinfo.Name = "label_timeinfo";
            this.label_timeinfo.Size = new System.Drawing.Size(83, 16);
            this.label_timeinfo.TabIndex = 12;
            this.label_timeinfo.Text = "Time Info";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_time.Location = new System.Drawing.Point(41, 261);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(40, 16);
            this.label_time.TabIndex = 4;
            this.label_time.Text = "----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "ACC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "RRI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "BPM";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_timeinfo);
            this.Controls.Add(this.label_userinfo);
            this.Controls.Add(this.ncc_rri);
            this.Controls.Add(this.ncc_bpm);
            this.Controls.Add(this.ncc_acc);
            this.Controls.Add(this.label_weight);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label_gender);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_id);
            this.Name = "Visualizer";
            this.Text = "Visualizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_id;
        protected internal System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_weight;
        public Nevron.Chart.WinForm.NChartControl ncc_acc;
        public Nevron.Chart.WinForm.NChartControl ncc_bpm;
        public Nevron.Chart.WinForm.NChartControl ncc_rri;
        private System.Windows.Forms.Label label_userinfo;
        private System.Windows.Forms.Label label_timeinfo;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}

