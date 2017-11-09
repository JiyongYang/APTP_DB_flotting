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
            this.button_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_pause = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_acc_log = new System.Windows.Forms.DataGridView();
            this.col_acc_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_bpm_log = new System.Windows.Forms.DataGridView();
            this.col_bpm_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bpm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_rri_log = new System.Windows.Forms.DataGridView();
            this.col_rri_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_excel_export = new System.Windows.Forms.Button();
            this.comboBox_id = new System.Windows.Forms.ComboBox();
            this.ncc_gsr = new Nevron.Chart.WinForm.NChartControl();
            this.ncc_stress = new Nevron.Chart.WinForm.NChartControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv_gsr_log = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_stress_log = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bpm_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rri_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gsr_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stress_log)).BeginInit();
            this.SuspendLayout();
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.Location = new System.Drawing.Point(15, 47);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(31, 16);
            this.label_id.TabIndex = 2;
            this.label_id.Text = "ID: ";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(15, 85);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(60, 16);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "Name: ";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_email.Location = new System.Drawing.Point(15, 127);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(64, 16);
            this.label_email.TabIndex = 4;
            this.label_email.Text = "E-mail: ";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_gender.Location = new System.Drawing.Point(342, 47);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(70, 16);
            this.label_gender.TabIndex = 5;
            this.label_gender.Text = "Gender: ";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_height.Location = new System.Drawing.Point(342, 85);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(63, 16);
            this.label_height.TabIndex = 6;
            this.label_height.Text = "Height: ";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_weight.Location = new System.Drawing.Point(342, 127);
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
            this.ncc_acc.Location = new System.Drawing.Point(19, 729);
            this.ncc_acc.Name = "ncc_acc";
            this.ncc_acc.Size = new System.Drawing.Size(550, 300);
            this.ncc_acc.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_acc.State")));
            this.ncc_acc.TabIndex = 9;
            this.ncc_acc.Text = "nChartControl1";
            // 
            // ncc_bpm
            // 
            this.ncc_bpm.AutoRefresh = false;
            this.ncc_bpm.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_bpm.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_bpm.Location = new System.Drawing.Point(617, 378);
            this.ncc_bpm.Name = "ncc_bpm";
            this.ncc_bpm.Size = new System.Drawing.Size(550, 300);
            this.ncc_bpm.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_bpm.State")));
            this.ncc_bpm.TabIndex = 10;
            this.ncc_bpm.Text = "nChartControl1";
            // 
            // ncc_rri
            // 
            this.ncc_rri.AutoRefresh = false;
            this.ncc_rri.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_rri.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_rri.Location = new System.Drawing.Point(19, 378);
            this.ncc_rri.Name = "ncc_rri";
            this.ncc_rri.Size = new System.Drawing.Size(550, 300);
            this.ncc_rri.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_rri.State")));
            this.ncc_rri.TabIndex = 11;
            this.ncc_rri.Text = "nChartControl4";
            // 
            // label_userinfo
            // 
            this.label_userinfo.AutoSize = true;
            this.label_userinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_userinfo.Location = new System.Drawing.Point(15, 9);
            this.label_userinfo.Name = "label_userinfo";
            this.label_userinfo.Size = new System.Drawing.Size(83, 16);
            this.label_userinfo.TabIndex = 12;
            this.label_userinfo.Text = "User Info";
            // 
            // label_timeinfo
            // 
            this.label_timeinfo.AutoSize = true;
            this.label_timeinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_timeinfo.Location = new System.Drawing.Point(15, 168);
            this.label_timeinfo.Name = "label_timeinfo";
            this.label_timeinfo.Size = new System.Drawing.Size(83, 16);
            this.label_timeinfo.TabIndex = 12;
            this.label_timeinfo.Text = "Time Info";
            this.label_timeinfo.Click += new System.EventHandler(this.label_timeinfo_Click);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_time.Location = new System.Drawing.Point(15, 204);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(45, 19);
            this.label_time.TabIndex = 4;
            this.label_time.Text = "----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 714);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "ACC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "RRI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "BPM";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Realtime_OnTimerTick);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(18, 283);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(96, 41);
            this.button_start.TabIndex = 14;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(16, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Controls";
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(136, 283);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(96, 41);
            this.button_pause.TabIndex = 14;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1207, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "ACC Log";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1207, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "BPM Log";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1205, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "RRI Log";
            // 
            // dgv_acc_log
            // 
            this.dgv_acc_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_acc_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_acc_time,
            this.col_acc_x,
            this.col_acc_y,
            this.col_acc_z});
            this.dgv_acc_log.Location = new System.Drawing.Point(1209, 24);
            this.dgv_acc_log.Name = "dgv_acc_log";
            this.dgv_acc_log.RowTemplate.Height = 23;
            this.dgv_acc_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_acc_log.TabIndex = 21;
            // 
            // col_acc_time
            // 
            this.col_acc_time.HeaderText = "Time";
            this.col_acc_time.Name = "col_acc_time";
            this.col_acc_time.ReadOnly = true;
            this.col_acc_time.Width = 120;
            // 
            // col_acc_x
            // 
            this.col_acc_x.HeaderText = "ACC_X";
            this.col_acc_x.Name = "col_acc_x";
            this.col_acc_x.ReadOnly = true;
            this.col_acc_x.Width = 165;
            // 
            // col_acc_y
            // 
            this.col_acc_y.HeaderText = "ACC_Y";
            this.col_acc_y.Name = "col_acc_y";
            this.col_acc_y.ReadOnly = true;
            this.col_acc_y.Width = 165;
            // 
            // col_acc_z
            // 
            this.col_acc_z.HeaderText = "ACC_Z";
            this.col_acc_z.Name = "col_acc_z";
            this.col_acc_z.ReadOnly = true;
            this.col_acc_z.Width = 165;
            // 
            // dgv_bpm_log
            // 
            this.dgv_bpm_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bpm_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_bpm_time,
            this.col_bpm});
            this.dgv_bpm_log.Location = new System.Drawing.Point(1207, 231);
            this.dgv_bpm_log.Name = "dgv_bpm_log";
            this.dgv_bpm_log.RowTemplate.Height = 23;
            this.dgv_bpm_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_bpm_log.TabIndex = 22;
            // 
            // col_bpm_time
            // 
            this.col_bpm_time.HeaderText = "Time";
            this.col_bpm_time.Name = "col_bpm_time";
            this.col_bpm_time.ReadOnly = true;
            this.col_bpm_time.Width = 120;
            // 
            // col_bpm
            // 
            this.col_bpm.HeaderText = "BPM";
            this.col_bpm.Name = "col_bpm";
            this.col_bpm.ReadOnly = true;
            this.col_bpm.Width = 495;
            // 
            // dgv_rri_log
            // 
            this.dgv_rri_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rri_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_rri_time,
            this.col_rri});
            this.dgv_rri_log.Location = new System.Drawing.Point(1207, 438);
            this.dgv_rri_log.Name = "dgv_rri_log";
            this.dgv_rri_log.RowTemplate.Height = 23;
            this.dgv_rri_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_rri_log.TabIndex = 23;
            // 
            // col_rri_time
            // 
            this.col_rri_time.HeaderText = "Time";
            this.col_rri_time.Name = "col_rri_time";
            this.col_rri_time.ReadOnly = true;
            this.col_rri_time.Width = 120;
            // 
            // col_rri
            // 
            this.col_rri.HeaderText = "RRI";
            this.col_rri.Name = "col_rri";
            this.col_rri.ReadOnly = true;
            this.col_rri.Width = 495;
            // 
            // button_excel_export
            // 
            this.button_excel_export.Location = new System.Drawing.Point(255, 283);
            this.button_excel_export.Name = "button_excel_export";
            this.button_excel_export.Size = new System.Drawing.Size(96, 41);
            this.button_excel_export.TabIndex = 24;
            this.button_excel_export.Text = "Export to Excel";
            this.button_excel_export.UseVisualStyleBackColor = true;
            this.button_excel_export.Click += new System.EventHandler(this.button_excel_export_Click);
            // 
            // comboBox_id
            // 
            this.comboBox_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_id.FormattingEnabled = true;
            this.comboBox_id.Location = new System.Drawing.Point(45, 43);
            this.comboBox_id.Name = "comboBox_id";
            this.comboBox_id.Size = new System.Drawing.Size(121, 20);
            this.comboBox_id.Sorted = true;
            this.comboBox_id.TabIndex = 25;
            this.comboBox_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_id_SelectedIndexChanged);
            // 
            // ncc_gsr
            // 
            this.ncc_gsr.AutoRefresh = false;
            this.ncc_gsr.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_gsr.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_gsr.Location = new System.Drawing.Point(617, 729);
            this.ncc_gsr.Name = "ncc_gsr";
            this.ncc_gsr.Size = new System.Drawing.Size(550, 300);
            this.ncc_gsr.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_gsr.State")));
            this.ncc_gsr.TabIndex = 26;
            this.ncc_gsr.Text = "nChartControl1";
            // 
            // ncc_stress
            // 
            this.ncc_stress.AutoRefresh = false;
            this.ncc_stress.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_stress.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_stress.Location = new System.Drawing.Point(617, 24);
            this.ncc_stress.Name = "ncc_stress";
            this.ncc_stress.Size = new System.Drawing.Size(550, 300);
            this.ncc_stress.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_stress.State")));
            this.ncc_stress.TabIndex = 27;
            this.ncc_stress.Text = "nChartControl2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 714);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "GSR";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(615, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "STRESS";
            // 
            // dgv_gsr_log
            // 
            this.dgv_gsr_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gsr_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_gsr_log.Location = new System.Drawing.Point(1209, 655);
            this.dgv_gsr_log.Name = "dgv_gsr_log";
            this.dgv_gsr_log.RowTemplate.Height = 23;
            this.dgv_gsr_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_gsr_log.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1207, 636);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "GSR Log";
            // 
            // dgv_stress_log
            // 
            this.dgv_stress_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stress_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgv_stress_log.Location = new System.Drawing.Point(1209, 869);
            this.dgv_stress_log.Name = "dgv_stress_log";
            this.dgv_stress_log.RowTemplate.Height = 23;
            this.dgv_stress_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_stress_log.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1207, 850);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "STRESS Log";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "GSR";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 495;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "STRESS";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 495;
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.dgv_stress_log);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgv_gsr_log);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ncc_stress);
            this.Controls.Add(this.ncc_gsr);
            this.Controls.Add(this.comboBox_id);
            this.Controls.Add(this.button_excel_export);
            this.Controls.Add(this.dgv_rri_log);
            this.Controls.Add(this.dgv_bpm_log);
            this.Controls.Add(this.dgv_acc_log);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.button_start);
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
            this.Load += new System.EventHandler(this.Visualizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bpm_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rri_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gsr_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stress_log)).EndInit();
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
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_acc_log;
        private System.Windows.Forms.DataGridView dgv_bpm_log;
        private System.Windows.Forms.DataGridView dgv_rri_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_z;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bpm_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bpm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rri_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rri;
        private System.Windows.Forms.Button button_excel_export;
        private System.Windows.Forms.ComboBox comboBox_id;
        private Nevron.Chart.WinForm.NChartControl ncc_gsr;
        private Nevron.Chart.WinForm.NChartControl ncc_stress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_gsr_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_stress_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label11;
    }
}

