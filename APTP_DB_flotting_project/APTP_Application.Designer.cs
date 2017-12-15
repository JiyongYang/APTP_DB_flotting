namespace APTP_DB_flotting_project
{
    partial class APTP_Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APTP_Application));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tp_visualizer = new System.Windows.Forms.TabPage();
            this.dgv_stress_log = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.dgv_gsr_log = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ncc_gsr = new Nevron.Chart.WinForm.NChartControl();
            this.button_excel_export = new System.Windows.Forms.Button();
            this.dgv_rri_log = new System.Windows.Forms.DataGridView();
            this.col_rri_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_bpm_log = new System.Windows.Forms.DataGridView();
            this.col_bpm_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bpm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncc_stress = new Nevron.Chart.WinForm.NChartControl();
            this.comboBox_id = new System.Windows.Forms.ComboBox();
            this.dgv_acc_log = new System.Windows.Forms.DataGridView();
            this.col_acc_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_acc_z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_timeinfo = new System.Windows.Forms.Label();
            this.label_userinfo = new System.Windows.Forms.Label();
            this.ncc_rri = new Nevron.Chart.WinForm.NChartControl();
            this.ncc_bpm = new Nevron.Chart.WinForm.NChartControl();
            this.ncc_acc = new Nevron.Chart.WinForm.NChartControl();
            this.label_weight = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.tp_vrms = new System.Windows.Forms.TabPage();
            this.shellFilePreview1 = new Jam.Shell.ShellFilePreview();
            this.shellControlConnector1 = new Jam.Shell.ShellControlConnector();
            this.shellListView1 = new Jam.Shell.ShellListView();
            this.shellTreeView1 = new Jam.Shell.ShellTreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tp_visualizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stress_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gsr_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rri_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bpm_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc_log)).BeginInit();
            this.tp_vrms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shellFilePreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shellListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shellTreeView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tp_visualizer);
            this.tabControl.Controls.Add(this.tp_vrms);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1892, 1017);
            this.tabControl.TabIndex = 34;
            // 
            // tp_visualizer
            // 
            this.tp_visualizer.Controls.Add(this.dgv_stress_log);
            this.tp_visualizer.Controls.Add(this.label11);
            this.tp_visualizer.Controls.Add(this.dgv_gsr_log);
            this.tp_visualizer.Controls.Add(this.label9);
            this.tp_visualizer.Controls.Add(this.label8);
            this.tp_visualizer.Controls.Add(this.ncc_gsr);
            this.tp_visualizer.Controls.Add(this.button_excel_export);
            this.tp_visualizer.Controls.Add(this.dgv_rri_log);
            this.tp_visualizer.Controls.Add(this.label10);
            this.tp_visualizer.Controls.Add(this.dgv_bpm_log);
            this.tp_visualizer.Controls.Add(this.ncc_stress);
            this.tp_visualizer.Controls.Add(this.comboBox_id);
            this.tp_visualizer.Controls.Add(this.dgv_acc_log);
            this.tp_visualizer.Controls.Add(this.label7);
            this.tp_visualizer.Controls.Add(this.label6);
            this.tp_visualizer.Controls.Add(this.label5);
            this.tp_visualizer.Controls.Add(this.label1);
            this.tp_visualizer.Controls.Add(this.button_pause);
            this.tp_visualizer.Controls.Add(this.button_start);
            this.tp_visualizer.Controls.Add(this.label4);
            this.tp_visualizer.Controls.Add(this.label3);
            this.tp_visualizer.Controls.Add(this.label2);
            this.tp_visualizer.Controls.Add(this.label_timeinfo);
            this.tp_visualizer.Controls.Add(this.label_userinfo);
            this.tp_visualizer.Controls.Add(this.ncc_rri);
            this.tp_visualizer.Controls.Add(this.ncc_bpm);
            this.tp_visualizer.Controls.Add(this.ncc_acc);
            this.tp_visualizer.Controls.Add(this.label_weight);
            this.tp_visualizer.Controls.Add(this.label_height);
            this.tp_visualizer.Controls.Add(this.label_gender);
            this.tp_visualizer.Controls.Add(this.label_time);
            this.tp_visualizer.Controls.Add(this.label_email);
            this.tp_visualizer.Controls.Add(this.label_name);
            this.tp_visualizer.Controls.Add(this.label_id);
            this.tp_visualizer.Location = new System.Drawing.Point(4, 22);
            this.tp_visualizer.Name = "tp_visualizer";
            this.tp_visualizer.Padding = new System.Windows.Forms.Padding(3);
            this.tp_visualizer.Size = new System.Drawing.Size(1884, 991);
            this.tp_visualizer.TabIndex = 0;
            this.tp_visualizer.Text = "Visualizer";
            this.tp_visualizer.UseVisualStyleBackColor = true;
            // 
            // dgv_stress_log
            // 
            this.dgv_stress_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stress_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgv_stress_log.Location = new System.Drawing.Point(1209, 825);
            this.dgv_stress_log.Name = "dgv_stress_log";
            this.dgv_stress_log.RowTemplate.Height = 23;
            this.dgv_stress_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_stress_log.TabIndex = 67;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1209, 810);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 12);
            this.label11.TabIndex = 66;
            this.label11.Text = "STRESS Log";
            // 
            // dgv_gsr_log
            // 
            this.dgv_gsr_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gsr_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_gsr_log.Location = new System.Drawing.Point(1209, 627);
            this.dgv_gsr_log.Name = "dgv_gsr_log";
            this.dgv_gsr_log.RowTemplate.Height = 23;
            this.dgv_gsr_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_gsr_log.TabIndex = 65;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(615, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 63;
            this.label9.Text = "STRESS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 670);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "GSR";
            // 
            // ncc_gsr
            // 
            this.ncc_gsr.AutoRefresh = false;
            this.ncc_gsr.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_gsr.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_gsr.Location = new System.Drawing.Point(617, 685);
            this.ncc_gsr.Name = "ncc_gsr";
            this.ncc_gsr.Size = new System.Drawing.Size(550, 300);
            this.ncc_gsr.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_gsr.State")));
            this.ncc_gsr.TabIndex = 60;
            this.ncc_gsr.Text = "nChartControl1";
            // 
            // button_excel_export
            // 
            this.button_excel_export.Location = new System.Drawing.Point(254, 259);
            this.button_excel_export.Name = "button_excel_export";
            this.button_excel_export.Size = new System.Drawing.Size(96, 41);
            this.button_excel_export.TabIndex = 58;
            this.button_excel_export.Text = "Export to Excel";
            this.button_excel_export.UseVisualStyleBackColor = true;
            this.button_excel_export.Click += new System.EventHandler(this.button_excel_export_Click);
            // 
            // dgv_rri_log
            // 
            this.dgv_rri_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rri_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_rri_time,
            this.col_rri});
            this.dgv_rri_log.Location = new System.Drawing.Point(1209, 429);
            this.dgv_rri_log.Name = "dgv_rri_log";
            this.dgv_rri_log.RowTemplate.Height = 23;
            this.dgv_rri_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_rri_log.TabIndex = 57;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1209, 612);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 12);
            this.label10.TabIndex = 64;
            this.label10.Text = "GSR Log";
            // 
            // dgv_bpm_log
            // 
            this.dgv_bpm_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bpm_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_bpm_time,
            this.col_bpm});
            this.dgv_bpm_log.Location = new System.Drawing.Point(1209, 231);
            this.dgv_bpm_log.Name = "dgv_bpm_log";
            this.dgv_bpm_log.RowTemplate.Height = 23;
            this.dgv_bpm_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_bpm_log.TabIndex = 56;
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
            // ncc_stress
            // 
            this.ncc_stress.AutoRefresh = false;
            this.ncc_stress.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_stress.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_stress.Location = new System.Drawing.Point(617, 25);
            this.ncc_stress.Name = "ncc_stress";
            this.ncc_stress.Size = new System.Drawing.Size(550, 300);
            this.ncc_stress.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_stress.State")));
            this.ncc_stress.TabIndex = 61;
            this.ncc_stress.Text = "nChartControl2";
            // 
            // comboBox_id
            // 
            this.comboBox_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_id.FormattingEnabled = true;
            this.comboBox_id.Location = new System.Drawing.Point(44, 47);
            this.comboBox_id.Name = "comboBox_id";
            this.comboBox_id.Size = new System.Drawing.Size(121, 20);
            this.comboBox_id.Sorted = true;
            this.comboBox_id.TabIndex = 59;
            this.comboBox_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_id_SelectedIndexChanged);
            // 
            // dgv_acc_log
            // 
            this.dgv_acc_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_acc_log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_acc_time,
            this.col_acc_x,
            this.col_acc_y,
            this.col_acc_z});
            this.dgv_acc_log.Location = new System.Drawing.Point(1209, 25);
            this.dgv_acc_log.Name = "dgv_acc_log";
            this.dgv_acc_log.RowTemplate.Height = 23;
            this.dgv_acc_log.Size = new System.Drawing.Size(660, 160);
            this.dgv_acc_log.TabIndex = 55;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1209, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 54;
            this.label7.Text = "RRI Log";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1209, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "BPM Log";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1209, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "ACC Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(15, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 51;
            this.label1.Text = "Controls";
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(135, 259);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(96, 41);
            this.button_pause.TabIndex = 49;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(17, 259);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(96, 41);
            this.button_start.TabIndex = 50;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "BPM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "RRI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 670);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "ACC";
            // 
            // label_timeinfo
            // 
            this.label_timeinfo.AutoSize = true;
            this.label_timeinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_timeinfo.Location = new System.Drawing.Point(14, 172);
            this.label_timeinfo.Name = "label_timeinfo";
            this.label_timeinfo.Size = new System.Drawing.Size(83, 16);
            this.label_timeinfo.TabIndex = 45;
            this.label_timeinfo.Text = "Time Info";
            // 
            // label_userinfo
            // 
            this.label_userinfo.AutoSize = true;
            this.label_userinfo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_userinfo.Location = new System.Drawing.Point(14, 13);
            this.label_userinfo.Name = "label_userinfo";
            this.label_userinfo.Size = new System.Drawing.Size(83, 16);
            this.label_userinfo.TabIndex = 44;
            this.label_userinfo.Text = "User Info";
            // 
            // ncc_rri
            // 
            this.ncc_rri.AutoRefresh = false;
            this.ncc_rri.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_rri.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_rri.Location = new System.Drawing.Point(19, 358);
            this.ncc_rri.Name = "ncc_rri";
            this.ncc_rri.Size = new System.Drawing.Size(550, 300);
            this.ncc_rri.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_rri.State")));
            this.ncc_rri.TabIndex = 43;
            this.ncc_rri.Text = "nChartControl4";
            // 
            // ncc_bpm
            // 
            this.ncc_bpm.AutoRefresh = false;
            this.ncc_bpm.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_bpm.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_bpm.Location = new System.Drawing.Point(617, 358);
            this.ncc_bpm.Name = "ncc_bpm";
            this.ncc_bpm.Size = new System.Drawing.Size(550, 300);
            this.ncc_bpm.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_bpm.State")));
            this.ncc_bpm.TabIndex = 42;
            this.ncc_bpm.Text = "nChartControl1";
            // 
            // ncc_acc
            // 
            this.ncc_acc.AutoRefresh = false;
            this.ncc_acc.BackColor = System.Drawing.SystemColors.Control;
            this.ncc_acc.InputKeys = new System.Windows.Forms.Keys[0];
            this.ncc_acc.Location = new System.Drawing.Point(19, 685);
            this.ncc_acc.Name = "ncc_acc";
            this.ncc_acc.Size = new System.Drawing.Size(550, 300);
            this.ncc_acc.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("ncc_acc.State")));
            this.ncc_acc.TabIndex = 41;
            this.ncc_acc.Text = "nChartControl1";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_weight.Location = new System.Drawing.Point(341, 131);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(67, 16);
            this.label_weight.TabIndex = 40;
            this.label_weight.Text = "Weight: ";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_height.Location = new System.Drawing.Point(341, 89);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(63, 16);
            this.label_height.TabIndex = 39;
            this.label_height.Text = "Height: ";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_gender.Location = new System.Drawing.Point(341, 51);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(70, 16);
            this.label_gender.TabIndex = 38;
            this.label_gender.Text = "Gender: ";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_time.Location = new System.Drawing.Point(15, 198);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(45, 19);
            this.label_time.TabIndex = 36;
            this.label_time.Text = "----";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_email.Location = new System.Drawing.Point(14, 131);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(64, 16);
            this.label_email.TabIndex = 37;
            this.label_email.Text = "E-mail: ";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(14, 89);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(60, 16);
            this.label_name.TabIndex = 35;
            this.label_name.Text = "Name: ";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.Location = new System.Drawing.Point(14, 51);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(31, 16);
            this.label_id.TabIndex = 34;
            this.label_id.Text = "ID: ";
            // 
            // tp_vrms
            // 
            this.tp_vrms.Controls.Add(this.shellFilePreview1);
            this.tp_vrms.Controls.Add(this.shellListView1);
            this.tp_vrms.Controls.Add(this.shellTreeView1);
            this.tp_vrms.Controls.Add(this.menuStrip1);
            this.tp_vrms.Location = new System.Drawing.Point(4, 22);
            this.tp_vrms.Name = "tp_vrms";
            this.tp_vrms.Padding = new System.Windows.Forms.Padding(3);
            this.tp_vrms.Size = new System.Drawing.Size(1884, 991);
            this.tp_vrms.TabIndex = 1;
            this.tp_vrms.Text = "VRMS";
            this.tp_vrms.UseVisualStyleBackColor = true;
            // 
            // shellFilePreview1
            // 
            this.shellFilePreview1.ItemIdList = null;
            this.shellFilePreview1.Location = new System.Drawing.Point(1258, 30);
            this.shellFilePreview1.Name = "shellFilePreview1";
            this.shellFilePreview1.Path = null;
            this.shellFilePreview1.ShellControlConnector = this.shellControlConnector1;
            this.shellFilePreview1.Size = new System.Drawing.Size(620, 955);
            this.shellFilePreview1.TabIndex = 6;
            this.shellFilePreview1.Text = "shellFilePreview1";
            // 
            // shellControlConnector1
            // 
            this.shellControlConnector1.Enabled = true;
            // 
            // shellListView1
            // 
            this.shellListView1.AutoSizeColumn = -1;
            this.shellListView1.Filter = "*.jpg;*.png;*.mp4;*.avi;*.MOV";
            this.shellListView1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.shellListView1.IsDropTarget = false;
            this.shellListView1.Location = new System.Drawing.Point(632, 30);
            this.shellListView1.Name = "shellListView1";
            this.shellListView1.Path = "";
            this.shellListView1.ShellControlConnector = this.shellControlConnector1;
            this.shellListView1.ShowColorCompressed = System.Drawing.Color.Empty;
            this.shellListView1.ShowColorEncrypted = System.Drawing.Color.Empty;
            this.shellListView1.Size = new System.Drawing.Size(620, 961);
            this.shellListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.shellListView1.TabIndex = 5;
            this.shellListView1.ThumbnailBorderColor = System.Drawing.Color.LightGray;
            this.shellListView1.ThumbnailSize = new System.Drawing.Size(96, 96);
            this.shellListView1.UseCompatibleStateImageBehavior = false;
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.shellTreeView1.ItemHeight = 24;
            this.shellTreeView1.Location = new System.Drawing.Point(6, 30);
            this.shellTreeView1.MultipleRoots = Jam.Shell.MultipleRoots.SingleRoot;
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.RootedAt = Jam.Shell.ShellFolder.Desktop;
            this.shellTreeView1.RootedAtFileSystemFolder = "";
            this.shellTreeView1.SelectedPath = "";
            this.shellTreeView1.ShellControlConnector = this.shellControlConnector1;
            this.shellTreeView1.ShowColorCompressed = System.Drawing.Color.Empty;
            this.shellTreeView1.ShowColorEncrypted = System.Drawing.Color.Empty;
            this.shellTreeView1.Size = new System.Drawing.Size(620, 955);
            this.shellTreeView1.SpecialFolder = Jam.Shell.ShellFolder.Drives;
            this.shellTreeView1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1878, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Realtime_OnTimerTick);
            // 
            // APTP_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tabControl);
            this.Name = "APTP_Application";
            this.Text = "APTP_Application";
            this.tabControl.ResumeLayout(false);
            this.tp_visualizer.ResumeLayout(false);
            this.tp_visualizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stress_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gsr_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rri_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bpm_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc_log)).EndInit();
            this.tp_vrms.ResumeLayout(false);
            this.tp_vrms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shellFilePreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shellListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shellTreeView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tp_visualizer;
        private System.Windows.Forms.TabPage tp_vrms;
        private System.Windows.Forms.DataGridView dgv_stress_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgv_gsr_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Nevron.Chart.WinForm.NChartControl ncc_gsr;
        private System.Windows.Forms.Button button_excel_export;
        private System.Windows.Forms.DataGridView dgv_rri_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rri_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rri;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_bpm_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bpm_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bpm;
        private Nevron.Chart.WinForm.NChartControl ncc_stress;
        private System.Windows.Forms.ComboBox comboBox_id;
        private System.Windows.Forms.DataGridView dgv_acc_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_acc_z;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_timeinfo;
        private System.Windows.Forms.Label label_userinfo;
        public Nevron.Chart.WinForm.NChartControl ncc_rri;
        public Nevron.Chart.WinForm.NChartControl ncc_bpm;
        public Nevron.Chart.WinForm.NChartControl ncc_acc;
        private System.Windows.Forms.Label label_weight;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_email;
        protected internal System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Timer timer1;
        private Jam.Shell.ShellControlConnector shellControlConnector1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private Jam.Shell.ShellTreeView shellTreeView1;
        private Jam.Shell.ShellFilePreview shellFilePreview1;
        private Jam.Shell.ShellListView shellListView1;
    }
}

