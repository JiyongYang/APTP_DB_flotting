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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_acc = new System.Windows.Forms.TabPage();
            this.ncc_acc = new Nevron.Chart.WinForm.NChartControl();
            this.label_acc = new System.Windows.Forms.Label();
            this.tab_bpm = new System.Windows.Forms.TabPage();
            this.ncc_bpm = new Nevron.Chart.WinForm.NChartControl();
            this.label_bmi = new System.Windows.Forms.Label();
            this.tab_rri = new System.Windows.Forms.TabPage();
            this.ncc_rri = new Nevron.Chart.WinForm.NChartControl();
            this.label_rri = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_birth = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.label_weight = new System.Windows.Forms.Label();
            this.label_temp = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nChartControl1 = new Nevron.Chart.WinForm.NChartControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nChartControl2 = new Nevron.Chart.WinForm.NChartControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nChartControl3 = new Nevron.Chart.WinForm.NChartControl();
            this.tabControl1.SuspendLayout();
            this.tab_acc.SuspendLayout();
            this.tab_bpm.SuspendLayout();
            this.tab_rri.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_acc);
            this.tabControl1.Controls.Add(this.tab_bpm);
            this.tabControl1.Controls.Add(this.tab_rri);
            this.tabControl1.Location = new System.Drawing.Point(10, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 700);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_acc
            // 
            this.tab_acc.Controls.Add(this.tabControl2);
            this.tab_acc.Controls.Add(this.ncc_acc);
            this.tab_acc.Controls.Add(this.label_acc);
            this.tab_acc.Location = new System.Drawing.Point(4, 22);
            this.tab_acc.Name = "tab_acc";
            this.tab_acc.Padding = new System.Windows.Forms.Padding(3);
            this.tab_acc.Size = new System.Drawing.Size(1152, 674);
            this.tab_acc.TabIndex = 0;
            this.tab_acc.Text = "ACC";
            this.tab_acc.UseVisualStyleBackColor = true;
            // 
            // ncc_acc
            // 
            this.ncc_acc.AutoRefresh = false;
            this.ncc_acc.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_acc.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_acc.Location = new System.Drawing.Point(126, 37);
            this.ncc_acc.Name = "ncc_acc";
            this.ncc_acc.Size = new System.Drawing.Size(900, 600);
            this.ncc_acc.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_acc.State")));
            this.ncc_acc.TabIndex = 10;
            this.ncc_acc.Text = "nChartControl1";
            // 
            // label_acc
            // 
            this.label_acc.AutoSize = true;
            this.label_acc.Location = new System.Drawing.Point(15, 15);
            this.label_acc.Name = "label_acc";
            this.label_acc.Size = new System.Drawing.Size(225, 12);
            this.label_acc.TabIndex = 9;
            this.label_acc.Text = "ACC: values of accelerometer sensors";
            // 
            // tab_bpm
            // 
            this.tab_bpm.Controls.Add(this.ncc_bpm);
            this.tab_bpm.Controls.Add(this.label_bmi);
            this.tab_bpm.Location = new System.Drawing.Point(4, 22);
            this.tab_bpm.Name = "tab_bpm";
            this.tab_bpm.Padding = new System.Windows.Forms.Padding(3);
            this.tab_bpm.Size = new System.Drawing.Size(1152, 674);
            this.tab_bpm.TabIndex = 1;
            this.tab_bpm.Text = "BPM";
            this.tab_bpm.UseVisualStyleBackColor = true;
            // 
            // ncc_bpm
            // 
            this.ncc_bpm.AutoRefresh = false;
            this.ncc_bpm.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_bpm.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_bpm.Location = new System.Drawing.Point(126, 37);
            this.ncc_bpm.Name = "ncc_bpm";
            this.ncc_bpm.Size = new System.Drawing.Size(900, 600);
            this.ncc_bpm.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_bpm.State")));
            this.ncc_bpm.TabIndex = 10;
            this.ncc_bpm.Text = "nChartControl2";
            // 
            // label_bmi
            // 
            this.label_bmi.AutoSize = true;
            this.label_bmi.Location = new System.Drawing.Point(15, 15);
            this.label_bmi.Name = "label_bmi";
            this.label_bmi.Size = new System.Drawing.Size(144, 12);
            this.label_bmi.TabIndex = 9;
            this.label_bmi.Text = "BPM: Beats Per Minutes";
            // 
            // tab_rri
            // 
            this.tab_rri.Controls.Add(this.ncc_rri);
            this.tab_rri.Controls.Add(this.label_rri);
            this.tab_rri.Location = new System.Drawing.Point(4, 22);
            this.tab_rri.Name = "tab_rri";
            this.tab_rri.Padding = new System.Windows.Forms.Padding(3);
            this.tab_rri.Size = new System.Drawing.Size(1152, 674);
            this.tab_rri.TabIndex = 2;
            this.tab_rri.Text = "RRI";
            this.tab_rri.UseVisualStyleBackColor = true;
            // 
            // ncc_rri
            // 
            this.ncc_rri.AutoRefresh = false;
            this.ncc_rri.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_rri.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_rri.Location = new System.Drawing.Point(126, 37);
            this.ncc_rri.Name = "ncc_rri";
            this.ncc_rri.Size = new System.Drawing.Size(900, 600);
            this.ncc_rri.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_rri.State")));
            this.ncc_rri.TabIndex = 10;
            this.ncc_rri.Text = "nChartControl3";
            // 
            // label_rri
            // 
            this.label_rri.AutoSize = true;
            this.label_rri.Location = new System.Drawing.Point(15, 15);
            this.label_rri.Name = "label_rri";
            this.label_rri.Size = new System.Drawing.Size(98, 12);
            this.label_rri.TabIndex = 9;
            this.label_rri.Text = "RRI: R-R interval";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(15, 20);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(16, 12);
            this.label_id.TabIndex = 2;
            this.label_id.Text = "ID";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(165, 20);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(39, 12);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "Name";
            // 
            // label_birth
            // 
            this.label_birth.AutoSize = true;
            this.label_birth.Location = new System.Drawing.Point(315, 20);
            this.label_birth.Name = "label_birth";
            this.label_birth.Size = new System.Drawing.Size(30, 12);
            this.label_birth.TabIndex = 4;
            this.label_birth.Text = "Birth";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Location = new System.Drawing.Point(465, 20);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(46, 12);
            this.label_gender.TabIndex = 5;
            this.label_gender.Text = "Gender";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(615, 20);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(40, 12);
            this.label_height.TabIndex = 6;
            this.label_height.Text = "Height";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Location = new System.Drawing.Point(765, 20);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(42, 12);
            this.label_weight.TabIndex = 7;
            this.label_weight.Text = "Weight";
            // 
            // label_temp
            // 
            this.label_temp.AutoSize = true;
            this.label_temp.Location = new System.Drawing.Point(921, 20);
            this.label_temp.Name = "label_temp";
            this.label_temp.Size = new System.Drawing.Size(25, 12);
            this.label_temp.TabIndex = 8;
            this.label_temp.Text = "text";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(17, 37);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1129, 622);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nChartControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1121, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Line";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nChartControl1
            // 
            this.nChartControl1.AutoRefresh = false;
            this.nChartControl1.BackColor = System.Drawing.SystemColors.Control;
            this.nChartControl1.InputKeys = new System.Windows.Forms.Keys[0];
            this.nChartControl1.Location = new System.Drawing.Point(126, 37);
            this.nChartControl1.Name = "nChartControl1";
            this.nChartControl1.Size = new System.Drawing.Size(888, 563);
            this.nChartControl1.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("nChartControl1.State")));
            this.nChartControl1.TabIndex = 10;
            this.nChartControl1.Text = "nChartControl1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nChartControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1121, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stick";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nChartControl2
            // 
            this.nChartControl2.AutoRefresh = false;
            this.nChartControl2.BackColor = System.Drawing.SystemColors.Control;
            this.nChartControl2.InputKeys = new System.Windows.Forms.Keys[0];
            this.nChartControl2.Location = new System.Drawing.Point(126, 37);
            this.nChartControl2.Name = "nChartControl2";
            this.nChartControl2.Size = new System.Drawing.Size(900, 600);
            this.nChartControl2.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("nChartControl2.State")));
            this.nChartControl2.TabIndex = 10;
            this.nChartControl2.Text = "nChartControl2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nChartControl3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1121, 596);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nChartControl3
            // 
            this.nChartControl3.AutoRefresh = false;
            this.nChartControl3.BackColor = System.Drawing.SystemColors.Control;
            this.nChartControl3.InputKeys = new System.Windows.Forms.Keys[0];
            this.nChartControl3.Location = new System.Drawing.Point(126, 37);
            this.nChartControl3.Name = "nChartControl3";
            this.nChartControl3.Size = new System.Drawing.Size(900, 541);
            this.nChartControl3.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("nChartControl3.State")));
            this.nChartControl3.TabIndex = 10;
            this.nChartControl3.Text = "nChartControl3";
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.label_temp);
            this.Controls.Add(this.label_weight);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label_gender);
            this.Controls.Add(this.label_birth);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.tabControl1);
            this.Name = "Visualizer";
            this.Text = "Visualizer";
            this.tabControl1.ResumeLayout(false);
            this.tab_acc.ResumeLayout(false);
            this.tab_acc.PerformLayout();
            this.tab_bpm.ResumeLayout(false);
            this.tab_bpm.PerformLayout();
            this.tab_rri.ResumeLayout(false);
            this.tab_rri.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_bpm;
        private System.Windows.Forms.TabPage tab_acc;
        private System.Windows.Forms.Label label_id;
        protected internal System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_birth;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_weight;
        protected internal System.Windows.Forms.Label label_bmi;
        protected internal System.Windows.Forms.Label label_acc;
        private System.Windows.Forms.TabPage tab_rri;
        protected internal System.Windows.Forms.Label label_rri;
        private Nevron.Chart.WinForm.NChartControl ncc_acc;
        private Nevron.Chart.WinForm.NChartControl ncc_bpm;
        private Nevron.Chart.WinForm.NChartControl ncc_rri;
        private System.Windows.Forms.Label label_temp;
        public System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private Nevron.Chart.WinForm.NChartControl nChartControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Nevron.Chart.WinForm.NChartControl nChartControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private Nevron.Chart.WinForm.NChartControl nChartControl3;
    }
}

