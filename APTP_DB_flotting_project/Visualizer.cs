using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nevron;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Editors;


namespace APTP_DB_flotting_project
{
    public partial class Visualizer : Form
    {
        private mySqlLinkage msl;
        public double[][] acc_m_matrix;
        public double[][] acc_w_matrix;
        public double[][] rri_m_matrix;
        public double[][] rri_w_matrix;
        int[] bpm_w_matrix;
        int[] bpm_m_matrix;

        NLineSeries m_BPMLine;
        int m_MaxCount = 60;
        int m_NewDataPointsPerTick = 60;
        public Color[] m_ColorTable;
        public int day_flag;
        public Dictionary<string, string> day_stack;
        public Dictionary<ACC, bool> dic_log_acc;
        public Dictionary<BPM, bool> dic_log_bpm;
        public Dictionary<RRI, bool> dic_log_rri;
        public int sec_flag;
        public string date_format;

        public int selected_user_id;

        public Visualizer()
        {
            InitializeComponent();
        }
        
        public Visualizer(mySqlLinkage _msl)
        {
            NLicense license = new NLicense("0619cf66-9900-d103-7d02-2d6f5900b739");
            NLicenseManager.Instance.SetLicense(license);
            NLicenseManager.Instance.LockLicense = true;
            msl = _msl;

            InitializeComponent();
            
            //non real time
            //NonRealtimeInitialize();

            //real time
            RealtimeInitialize();
        }

        #region NonRealtime APIs
        public void NonRealtimeInitialize()
        {
            //fake data
            //this.msl.FakeDataGenerator();
            //real data
            this.msl.SelectUsingReader();

            InitializeTime();
            m_ColorTable = new Color[256];
            for (int i = 0; i <= 255; i++)
            {
                m_ColorTable[i] = InterpolateColors(Color.Blue, Color.Red, i / 255.0f);
            }
            this.InitializeBarACC();
            this.InitializeBPMGraph();
            this.InitializeSurfaceRRI();
            this.SetUserInfoLabel();

        }

        public void OnTimerTick(object sender, EventArgs e)
        {

        }

        public void InitializeTime()
        {
            day_flag = 0;

            day_stack = new Dictionary<string, string>();

            //fill day_stack
            for (int j = 0; j < msl.list_ACC.Count; j++)
            {
                string today = msl.list_ACC[j].timestamp.Year.ToString() + "/" + msl.list_ACC[j].timestamp.Month.ToString() + "/" + msl.list_ACC[j].timestamp.Day.ToString();
                if (day_stack.ContainsKey(today) == false)
                {
                    day_stack.Add(today, day_flag.ToString());
                    day_flag++;
                }
            }
            //sort day_stack
            day_stack = day_stack.OrderBy(i => i.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);

            for (int i = 0; i < day_stack.Count; i++)
            {
                day_stack[day_stack.Keys.ElementAt(i)] = i.ToString();
            }
            day_flag = 0;
        }

        public void InitializeBarACC()
        {
            ncc_acc.Controller.Tools.Clear();
            ncc_acc.Controller.Tools.Add(new NPanelSelectorTool());
            ncc_acc.Controller.Tools.Add(new NTrackballTool());
            // set a chart title
            NLabel title = ncc_acc.Labels.AddHeader("ACC Bar chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // no legend
            ncc_acc.Legends.Clear();

            // do not update automatic legends
            ncc_acc.ServiceManager.LegendUpdateService.UpdateAutoLegends();
            ncc_acc.ServiceManager.LegendUpdateService.Stop();

            // configure the chart
            NCartesianChart chart = (NCartesianChart)ncc_acc.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.BoundsMode = BoundsMode.Fit;
            chart.Enable3D = true;
            chart.Fit3DAxisContent = false;

            // make the aspect 6:1:2
            chart.Width = 60;
            chart.Height = 20;
            chart.Depth = 20;

            // configure the y axis
            NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
            //y축 범위 지정
            yAxis.View = new NRangeAxisView(new NRange1DD(-2, 2));

            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
            linearScale.InnerMinorTickStyle.Visible = false;
            linearScale.InnerMajorTickStyle.Visible = false;
            linearScale.LabelFitModes = new LabelFitMode[0];

            // configure the x axis
            NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
            linearScale = new NLinearScaleConfigurator();
            linearScale.LabelFitModes = new LabelFitMode[0];
            xAxis.ScaleConfigurator = linearScale;
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;
            linearScale.InnerMinorTickStyle.Visible = false;
            linearScale.InnerMajorTickStyle.Visible = false;

            chart.Axis(StandardAxis.Depth).Visible = false;

            // apply layout
            ConfigureStandardLayout(ncc_acc, chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(ncc_acc.Document);

            //acc_w_matrix initialize, 3 section: x/y/z, 24*60*60: one day
            acc_w_matrix = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                acc_w_matrix[i] = new double[24 * 60 * 60];
            }

            LoadDayACCData();

            acc_m_matrix = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                acc_m_matrix[i] = new double[60];
            }

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

            //bar initialize
            for (int i = 0; i < 3; i++)
            {
                // add the first line
                NBarSeries bar = new NBarSeries();
                chart.Series.Add(bar);

                bar.WidthPercent = 100.0f;
                bar.DepthPercent = 100.0f;

                bar.EnableDepthSort = false;
                bar.DataLabelStyle.Visible = false;

                bar.Values.ValueFormatter = new NNumericValueFormatter("0.0");
                bar.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

                bar.Values.Clear();
                bar.FillStyles.StorageType = IndexedStorageType.Array;
                bar.DataPointOriginIndex = 0;

                // turn off bar border to improve performance
                bar.BorderStyle.Width = new NLength(0);
            }
        }
        
        public void UpdateBarACC()
        {
            // clear the list
            for (int i = 0; i < acc_m_matrix.Length; i++)
            {
                double[] arr = acc_m_matrix[i];
                Array.Clear(arr, 0, arr.Length);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    acc_m_matrix[i][j] = 0;
                }
            }

            for (int j = 0; j < 60; j++)
            {
                if (sec_flag + j < 24 * 60 * 60)
                {
                    acc_m_matrix[0][j] = acc_w_matrix[0][sec_flag + j];
                    acc_m_matrix[1][j] = acc_w_matrix[1][sec_flag + j];
                    acc_m_matrix[2][j] = acc_w_matrix[2][sec_flag + j];
                }
            }

            // fill grid to bars
            NChart chart = ncc_acc.Charts[0];
            for (int i = 0; i < acc_m_matrix.Length; i++)
            {
                NBarSeries bar = chart.Series[i] as NBarSeries;
                double[] barValues = acc_m_matrix[i];
                int barValueCount = barValues.Length;

                if (bar.Values.Count == 0)
                {
                    bar.Values.AddRange(barValues);
                }
                else
                {
                    bar.Values.SetRange(0, barValues);
                }

                int fillStyleCount = bar.FillStyles.Count;

                for (int j = 0; j < barValueCount; j++)
                {
                    int color_var = 0;
                    if (!barValues[j].Equals(0))
                        color_var = (int)((barValues[j] + 2) * 60);

                    if (j >= fillStyleCount)
                    {
                        //bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[(int)barValues[j]]);
                        if (color_var == 0)
                            bar.FillStyles[j] = new NColorFillStyle(Color.FromArgb(0, 0, 0, 0));
                        else
                            bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[color_var]);
                    }
                    else
                    {
                        //((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[(int)barValues[j]];
                        if (color_var == 0)
                            ((NColorFillStyle)bar.FillStyles[j]).Color = Color.FromArgb(0, 0, 0, 0);
                        else
                            ((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[color_var];
                    }
                }
            }
        }

        public void LoadDayACCData()
        {
            //set to 0
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 24 * 60 * 60; j++)
                {
                    acc_w_matrix[i][j] = 0;
                }
            }

            //load acc whole data matrix according to changed day
            for (int j = 0; j < msl.list_ACC.Count; j++)
            {
                string today = msl.list_ACC[j].timestamp.Year.ToString() + "/" + msl.list_ACC[j].timestamp.Month.ToString() + "/" + msl.list_ACC[j].timestamp.Day.ToString();
                if (day_stack.ContainsKey(today) && day_stack[today] == day_flag.ToString())
                {
                    int k = msl.list_ACC[j].timestamp.Hour * 60 * 60 + msl.list_ACC[j].timestamp.Minute * 60 + msl.list_ACC[j].timestamp.Second;

                    acc_w_matrix[0][k] = msl.list_ACC[j].x;
                    acc_w_matrix[1][k] = msl.list_ACC[j].y;
                    acc_w_matrix[2][k] = msl.list_ACC[j].z;
                }
            }
        }

        public void InitializeSurfaceRRI()
        {
            ncc_rri.Settings.RenderSurface = RenderSurface.Window;
            ncc_rri.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
            ncc_rri.Controller.Tools.Clear();
            ncc_rri.Controller.Tools.Add(new NPanelSelectorTool());
            ncc_rri.Controller.Tools.Add(new NTrackballTool());

            // set a chart title
            NLabel title = ncc_rri.Labels.AddHeader("RRI Surface chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

            // setup chart
            NChart chart = ncc_rri.Charts[0];
            chart.Enable3D = true;
            chart.Width = 60.0f;
            chart.Depth = 60.0f;
            chart.Height = 60.0f;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // setup axes
            NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            // add the surface series
            NGridSurfaceSeries surface = new NGridSurfaceSeries();
            chart.Series.Add(surface);
            surface.ShadingMode = ShadingMode.Smooth;
            surface.FillMode = SurfaceFillMode.ZoneTexture;
            surface.FrameMode = SurfaceFrameMode.None;
            surface.SmoothPalette = true;
            surface.CellTriangulationMode = SurfaceCellTriangulationMode.MaxSum;
            surface.Data.SetGridSize(60, 10);
            
            // apply layout
            ConfigureStandardLayout(ncc_rri, chart, title, null);


            //rri_w_matrix initialize, 3 section: x/y/z, 24*60*60: one day
            rri_w_matrix = new double[10][];
            for (int i = 0; i < 10; i++)
            {
                rri_w_matrix[i] = new double[24 * 60 * 60];
            }

            LoadDayRRIData();

            rri_m_matrix = new double[10][];
            for (int i = 0; i < 10; i++)
            {
                rri_m_matrix[i] = new double[60];
            }
        }

        public void UpdateSurfaceRRI()
        {
            // clear the list
            for (int i = 0; i < rri_m_matrix.Length; i++)
            {
                double[] arr = rri_m_matrix[i];
                Array.Clear(arr, 0, arr.Length);
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    rri_m_matrix[i][j] = 0;
                }
            }
            for(int i=0;i<10;i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (sec_flag + j < 24 * 60 * 60)
                    {
                        rri_m_matrix[i][j] = rri_w_matrix[i][sec_flag + j];
                    }
                }
            }

            NGridSurfaceSeries surface = (NGridSurfaceSeries)ncc_rri.Charts[0].Series[0];
            

            for(int i=0;i<10;i++)
            {
                for(int j=0;j< 60;j++)
                {
                    surface.Data.SetValue(j, i, rri_m_matrix[i][j]);
                }
            }
        }

        public void LoadDayRRIData()
        {
            Random r = new Random();
            //set to 0
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24 * 60 * 60; j++)
                {
                    rri_w_matrix[i][j] = 0;
                }
            }

            //load acc whole data matrix according to changed day
            for (int j = 0; j < msl.list_RRI.Count; j++)
            {
                string today = msl.list_RRI[j].timestamp.Year.ToString() + "/" + msl.list_RRI[j].timestamp.Month.ToString() + "/" + msl.list_RRI[j].timestamp.Day.ToString();
                if (day_stack.ContainsKey(today) && day_stack[today] == day_flag.ToString())
                {
                    int k = msl.list_RRI[j].timestamp.Hour * 60 * 60 + msl.list_RRI[j].timestamp.Minute * 60 + msl.list_RRI[j].timestamp.Second;
                    rri_w_matrix[0][k] = msl.list_RRI[j].rri;
                    for (int i=1;i<10;i++)
                    {
                        rri_w_matrix[i][k] = msl.list_RRI[j].rri + r.NextDouble()/10.0;
                    }
                }
            }
        }
        
        private void ConfigureAxis(NAxis axis, float beginPercent, float endPercent, string title)
        {
            NLinearScaleConfigurator scale = new NLinearScaleConfigurator();
            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            axis.ScaleConfigurator = scale;
            axis.View = new NRangeAxisView(new NRange1DD(50, 110), true, true);
            axis.ScaleConfigurator.Title.Text = title;
            axis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false);
            axis.Anchor.BeginPercent = beginPercent;
            axis.Anchor.EndPercent = endPercent;
            axis.Visible = true;
        }

        private NLineSeries CreateLineSeries()
        {
            NLineSeries lineSeries = new NLineSeries();

            lineSeries.Values.Capacity = m_MaxCount;
            lineSeries.XValues.Capacity = m_MaxCount;
            lineSeries.DataLabelStyle.Visible = false;
            lineSeries.SamplingMode = SeriesSamplingMode.Enabled;
            lineSeries.SampleDistance = new NLength(1, NGraphicsUnit.Pixel);

            return lineSeries;
        }

        private void InitializeBPMGraph()
        {
            ncc_bpm.Clear();
            ncc_bpm.Legends.Clear();

            bpm_w_matrix = new int[24 * 60 * 60];
            LoadDayBPMData();
            bpm_m_matrix = new int[60];

            // Set a chart title
            NLabel title = ncc_bpm.Labels.AddHeader("BPM Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_bpm.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "Time");

            m_BPMLine = CreateLineSeries();
            chart.Series.Add(m_BPMLine);


            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_bpm, chart, title, null);

            ncc_bpm.Settings.RenderSurface = RenderSurface.Window;
        }

        public void UpdateLineBPM()
        {
            int newDataPoints = m_NewDataPointsPerTick;

            // clear the list
            for (int i = 0; i < bpm_m_matrix.Length; i++)
            {
                bpm_m_matrix[i] = 0;
            }

            for (int j = 0; j < 60; j++)
            {
                if (sec_flag + j < 24 * 60 * 60)
                {
                    bpm_m_matrix[j] = bpm_w_matrix[sec_flag + j];
                }
            }

            if (m_BPMLine.Values.Count == 0)
            {
                m_BPMLine.Values.AddRange(bpm_m_matrix);
            }
            else
            {
                m_BPMLine.Values.SetRange(0, bpm_m_matrix);
            }
        }

        public void LoadDayBPMData()
        {
            for (int j = 0; j < 24 * 60 * 60; j++)
            {
                bpm_w_matrix[j] = 0;
            }

            //load bpm whole data matrix according to changed day
            for (int j = 0; j < msl.list_BPM.Count; j++)
            {
                string today = msl.list_BPM[j].timestamp.Year.ToString() + "/" + msl.list_BPM[j].timestamp.Month.ToString() + "/" + msl.list_BPM[j].timestamp.Day.ToString();
                if (day_stack.ContainsKey(today) && day_stack[today] == day_flag.ToString())
                {
                    int k = msl.list_BPM[j].timestamp.Hour * 60 * 60 + msl.list_BPM[j].timestamp.Minute * 60 + msl.list_BPM[j].timestamp.Second;

                    bpm_w_matrix[k] = msl.list_BPM[j].bpm;
                }
            }
        }

        public void SetTimerLabel()
        {
            //time label setting
            if (day_stack.ContainsValue(day_flag.ToString()))
            {
                int s_hour = sec_flag / (60 * 60);
                int s_min = (sec_flag - s_hour * 60 * 60) / 60;
                int s_sec = sec_flag % 60;

                int e_hour = (sec_flag + 59) / (60 * 60);
                int e_min = ((sec_flag + 59) - e_hour * 60 * 60) / 60;
                int e_sec = (sec_flag + 59) % 60;

                string time_start = s_hour.ToString("D2") + ":" + s_min.ToString("D2") + ":" + s_sec.ToString("D2");
                string time_end = e_hour.ToString("D2") + ":" + e_min.ToString("D2") + ":" + e_sec.ToString("D2");

                if (sec_flag + 59 >= 24 * 60 * 60)
                    time_end = "24:00:00";

                label_time.Text = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key + "\n"
                    + time_start + " ~ " + time_end;
            }
        }

        public void SetLogTextBoxes()
        {
            ////add 60 text to box
            //if(sec_flag == 0)
            //{
            //    string date;
            //    int s_hour, s_min, s_sec;
            //    if (!day_stack.ContainsValue(day_flag.ToString()))
            //    {
            //        //error
            //    }
            //    date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key;
            //    s_hour = sec_flag / (60 * 60);
            //    s_min = (sec_flag - s_hour * 60 * 60) / 60;
            //    s_sec = sec_flag % 60;

            //    //acc log
            //    for (int i = day_flag * 24 * 60 * 60; i < (day_flag * 24 * 60 * 60) + 60; i++)
            //    {
            //        s_sec = i - (day_flag * 24 * 60 * 60);
            //        date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key + " " + s_hour.ToString("D2") + ":" + s_min.ToString("D2") + ":" + s_sec.ToString("D2");
            //        //textBox_aac_log.Text += date + "\r\nacc_x: " + acc_w_matrix[0][i] + "\r\nacc_y: " + acc_w_matrix[1][i] + "\r\nacc_z: " + acc_w_matrix[2][i] + "\r\n";
            //        listBox_acc_log.Items.Add(date + "  acc_x: " + acc_w_matrix[0][i] + "\tacc_y: " + acc_w_matrix[1][i] + "\tacc_z: " + acc_w_matrix[2][i]);
            //        this.listBox_acc_log.SelectedIndex = this.listBox_acc_log.Items.Count - 1;
            //    }

            //    //bpm log
            //    for (int i = day_flag * 24 * 60 * 60; i < (day_flag * 24 * 60 * 60) + 60; i++)
            //    {
            //        s_sec = i - (day_flag * 24 * 60 * 60);
            //        date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key + " " + s_hour.ToString("D2") + ":" + s_min.ToString("D2") + ":" + s_sec.ToString("D2");
            //        //textBox_bpm_log.Text += date + "\tbpm: " + bpm_w_matrix[i] + "\r\n";
            //        listBox_bpm_log.Items.Add(date + "  bpm: " + bpm_w_matrix[i]);
            //        this.listBox_bpm_log.SelectedIndex = this.listBox_bpm_log.Items.Count - 1;
            //    }

            //    //rri log
            //    for (int i = day_flag * 24 * 60 * 60; i < (day_flag * 24 * 60 * 60) + 60; i++)
            //    {
            //        s_sec = i - (day_flag * 24 * 60 * 60);
            //        date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key + " " + s_hour.ToString("D2") + ":" + s_min.ToString("D2") + ":" + s_sec.ToString("D2");
            //        //textBox_rri_log.Text += date + "\trri: " + rri_w_matrix[0][i] + "\r\n";
            //        listBox_rri_log.Items.Add(date + "  rri: " + rri_w_matrix[0][i]);
            //        this.listBox_rri_log.SelectedIndex = this.listBox_rri_log.Items.Count - 1;
            //    }
            //}
            //else
            //{
            //    string date;
            //    int s_hour, s_min, s_sec;
            //    if (!day_stack.ContainsValue(day_flag.ToString()))
            //    {
            //        //error
            //    }
                
            //    if (sec_flag + 59 <= 24 * 60 * 60)
            //    {
            //        date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key;
            //        s_hour = (sec_flag+59) / (60 * 60);
            //        s_min = ((sec_flag + 59) - s_hour * 60 * 60) / 60;
            //        s_sec = (sec_flag + 59) % 60;

            //        date = day_stack.FirstOrDefault(x => x.Value == day_flag.ToString()).Key + " " + s_hour.ToString("D2") + ":" + s_min.ToString("D2") + ":" + s_sec.ToString("D2");
            //        //acc log
            //        //textBox_aac_log.Text += date + "\r\nacc_x: " + acc_w_matrix[0][day_flag*24*60*60 + sec_flag + 59] + "\r\nacc_y: " + acc_w_matrix[1][day_flag * 24 * 60 * 60 + sec_flag + 59] 
            //        //    + "\r\nacc_z: " + acc_w_matrix[2][day_flag * 24 * 60 * 60 + sec_flag + 59] + "\r\n";
            //        listBox_acc_log.Items.Add(date + "  acc_x: " + acc_w_matrix[0][day_flag * 24 * 60 * 60 + sec_flag + 59] + "\tacc_y: " + acc_w_matrix[1][day_flag * 24 * 60 * 60 + sec_flag + 59] + "\tacc_z: " + acc_w_matrix[2][day_flag * 24 * 60 * 60 + sec_flag + 59]);
            //        this.listBox_acc_log.SelectedIndex = this.listBox_acc_log.Items.Count - 1;

            //        //bpm log
            //        //textBox_bpm_log.Text += date + "\tbpm: " + bpm_w_matrix[day_flag * 24 * 60 * 60 + sec_flag + 59] + "\r\n";
            //        listBox_bpm_log.Items.Add(date + "  bpm: " + bpm_w_matrix[day_flag * 24 * 60 * 60 + sec_flag + 59]);
            //        this.listBox_bpm_log.SelectedIndex = this.listBox_bpm_log.Items.Count - 1;

            //        //rri log
            //        //textBox_rri_log.Text += date + "\trri: " + rri_w_matrix[0][day_flag * 24 * 60 * 60 + sec_flag + 59] + "\r\n";
            //        listBox_rri_log.Items.Add(date + "  rri: " + rri_w_matrix[0][day_flag * 24 * 60 * 60 + sec_flag + 59]);
            //        this.listBox_rri_log.SelectedIndex = this.listBox_rri_log.Items.Count - 1;
            //    }
            //}
        }

        #endregion

        #region Realtime APIs
        public void RealtimeInitialize()
        {
            dic_log_acc = new Dictionary<ACC, bool>();
            dic_log_bpm = new Dictionary<BPM, bool>();
            dic_log_rri = new Dictionary<RRI, bool>();

            date_format = "yyyyMMdd HH:mm:ss";
            m_ColorTable = new Color[256];
            for (int i = 0; i <= 255; i++)
            {
                m_ColorTable[i] = InterpolateColors(Color.Blue, Color.Red, i / 255.0f);
            }
            //fake data
            //this.msl.Realtime_FakeUserInfoGenerator();
            //real data
            this.msl.Realtime_SelectUserInfoUsingReader();
            SetcomboBox_id_Items();
            selected_user_id = -1;
        }

        public void Realtime_OnTimerTick(object sender, EventArgs e)
        {
            //real data
            this.msl.Realtime_SelectUsingReader(selected_user_id);

            //fake data
            //this.msl.Realtime_FakeDataGenerator(selected_user_id);

            Realtime_UpdateBarACC();
            Realtime_UpdateLineBPM();
            Realtime_UpdateSurfaceRRI();

            Realtime_SetTimerLabel();
            Realtime_SetLogTextBoxes();

            this.Refresh(ncc_acc);
            this.Refresh(ncc_rri);
            this.Refresh(ncc_bpm);
        }

        public void Realtime_InitializeBarACC()
        {
            ncc_acc.Controller.Tools.Clear();
            ncc_acc.Controller.Tools.Add(new NPanelSelectorTool());
            ncc_acc.Controller.Tools.Add(new NTrackballTool());
            // set a chart title
            NLabel title = ncc_acc.Labels.AddHeader("ACC Bar chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // no legend
            ncc_acc.Legends.Clear();

            // do not update automatic legends
            ncc_acc.ServiceManager.LegendUpdateService.UpdateAutoLegends();
            ncc_acc.ServiceManager.LegendUpdateService.Stop();

            // configure the chart
            NCartesianChart chart = (NCartesianChart)ncc_acc.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.BoundsMode = BoundsMode.Fit;
            chart.Enable3D = true;
            chart.Fit3DAxisContent = false;

            // make the aspect 6:1:2
            chart.Width = 60;
            chart.Height = 20;
            chart.Depth = 20;

            // configure the y axis
            NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
            //y축 범위 지정
            yAxis.View = new NRangeAxisView(new NRange1DD(-2, 2));

            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
            linearScale.InnerMinorTickStyle.Visible = false;
            linearScale.InnerMajorTickStyle.Visible = false;
            linearScale.LabelFitModes = new LabelFitMode[0];

            // configure the x axis
            NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
            linearScale = new NLinearScaleConfigurator();
            linearScale.LabelFitModes = new LabelFitMode[0];
            xAxis.ScaleConfigurator = linearScale;
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;
            linearScale.InnerMinorTickStyle.Visible = false;
            linearScale.InnerMajorTickStyle.Visible = false;

            chart.Axis(StandardAxis.Depth).Visible = false;

            // apply layout
            ConfigureStandardLayout(ncc_acc, chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(ncc_acc.Document);

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

            chart.Series.Clear();

            //bar initialize
            for (int i = 0; i < 3; i++)
            {
                // add the first line
                NBarSeries bar = new NBarSeries();
                chart.Series.Add(bar);

                bar.WidthPercent = 100.0f;
                bar.DepthPercent = 100.0f;

                bar.EnableDepthSort = false;
                bar.DataLabelStyle.Visible = false;

                bar.Values.ValueFormatter = new NNumericValueFormatter("0.0");
                bar.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

                bar.Values.Clear();
                bar.FillStyles.StorageType = IndexedStorageType.Array;
                bar.DataPointOriginIndex = 0;

                // turn off bar border to improve performance
                bar.BorderStyle.Width = new NLength(0);
            }
        }

        public void Realtime_InitializeSurfaceRRI()
        {
            ncc_rri.Settings.RenderSurface = RenderSurface.Window;
            ncc_rri.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
            ncc_rri.Controller.Tools.Clear();
            ncc_rri.Controller.Tools.Add(new NPanelSelectorTool());
            ncc_rri.Controller.Tools.Add(new NTrackballTool());

            // set a chart title
            NLabel title = ncc_rri.Labels.AddHeader("RRI Surface chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

            // setup chart
            NChart chart = ncc_rri.Charts[0];
            chart.Enable3D = true;
            chart.Width = 60.0f;
            chart.Depth = 60.0f;
            chart.Height = 30.0f;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // setup axes
            NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            chart.Series.Clear();

            // add the surface series
            NGridSurfaceSeries surface = new NGridSurfaceSeries();
            chart.Series.Add(surface);
            surface.ShadingMode = ShadingMode.Smooth;
            surface.FillMode = SurfaceFillMode.ZoneTexture;
            surface.FrameMode = SurfaceFrameMode.None;
            surface.SmoothPalette = true;
            surface.CellTriangulationMode = SurfaceCellTriangulationMode.MaxSum;
            surface.Data.SetGridSize(60, 10);

            // apply layout
            ConfigureStandardLayout(ncc_rri, chart, title, null);            
        }

        private void Realtime_InitializeBPMGraph()
        {
            ncc_bpm.Clear();
            ncc_bpm.Legends.Clear();
            
            // Set a chart title
            NLabel title = ncc_bpm.Labels.AddHeader("BPM Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_bpm.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "Time");

            chart.Series.Clear();

            m_BPMLine = CreateLineSeries();
            chart.Series.Add(m_BPMLine);
            
            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_bpm, chart, title, null);

            ncc_bpm.Settings.RenderSurface = RenderSurface.Window;
        }

        public void Realtime_UpdateBarACC()
        {
            this.Realtime_InitializeBarACC();
            double[][] data = new double[3][];
            data[0] = new double[60];
            data[1] = new double[60];
            data[2] = new double[60];

            for (int i=0;i<msl.list_ACC.Count;i++)
            {
                data[0][i] = msl.list_ACC[i].x;
                data[1][i] = msl.list_ACC[i].y;
                data[2][i] = msl.list_ACC[i].z;
            }

            // fill grid to bars
            NChart chart = ncc_acc.Charts[0];
            for (int i = 0; i < data.Length; i++)
            {
                NBarSeries bar = chart.Series[i] as NBarSeries;
                double[] barValues = data[i];
                int barValueCount = barValues.Length;

                if (bar.Values.Count == 0)
                {
                    bar.Values.AddRange(barValues);
                }
                else
                {
                    bar.Values.SetRange(0, barValues);
                }

                int fillStyleCount = bar.FillStyles.Count;

                for (int j = 0; j < barValueCount; j++)
                {
                    int color_var = 0;
                    if (!barValues[j].Equals(0))
                        color_var = (int)((barValues[j] + 2) * 60);

                    if (j >= fillStyleCount)
                    {
                        //bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[(int)barValues[j]]);
                        if (color_var == 0)
                            bar.FillStyles[j] = new NColorFillStyle(Color.FromArgb(0, 0, 0, 0));
                        else
                            bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[color_var]);
                    }
                    else
                    {
                        //((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[(int)barValues[j]];
                        if (color_var == 0)
                            ((NColorFillStyle)bar.FillStyles[j]).Color = Color.FromArgb(0, 0, 0, 0);
                        else
                            ((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[color_var];
                    }
                }
            }
        }

        public void Realtime_UpdateSurfaceRRI()
        {
            Random r = new Random();
            this.Realtime_InitializeSurfaceRRI();

            double[][] data = new double[10][];
            for (int i = 0; i < 10; i++)
                data[i] = new double[60];

            for (int i = 0; i < msl.list_RRI.Count; i++)
            {
                data[0][i] = msl.list_RRI[i].rri;
                for (int j = 1; j < 10; j++)
                    data[j][i] = msl.list_RRI[i].rri + r.Next(-10, 10);
            }

            NGridSurfaceSeries surface = (NGridSurfaceSeries)ncc_rri.Charts[0].Series[0];
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    surface.Data.SetValue(j, i, data[i][j]);
                }
            }
        }

        public void Realtime_UpdateLineBPM()
        {
            this.Realtime_InitializeBPMGraph();

            double[] data = new double[60];

            for(int i=0;i<msl.list_BPM.Count;i++)
            {
                data[i] = msl.list_BPM[i].bpm;
            }

            if (m_BPMLine.Values.Count == 0)
            {
                m_BPMLine.Values.AddRange(data);
            }
            else
            {
                m_BPMLine.Values.SetRange(0, data);
            }
        }

        public void Realtime_SetTimerLabel()
        {
            label_time.Text = msl.list_ACC[0].timestamp.ToString(date_format) + " ~ " + msl.list_ACC[msl.list_ACC.Count-1].timestamp.ToString(date_format);
        }

        public void Realtime_SetLogTextBoxes()
        {
            for (int i = 0; i < msl.list_ACC.Count; i++)
            {
                if (!dic_log_acc.ContainsKey(msl.list_ACC[i]))
                    dic_log_acc.Add(msl.list_ACC[i], false);
            }
            for (int i = 0; i < msl.list_BPM.Count; i++)
            {
                if (!dic_log_bpm.ContainsKey(msl.list_BPM[i]))
                    dic_log_bpm.Add(msl.list_BPM[i], false);
            }
            for (int i = 0; i < msl.list_RRI.Count; i++)
            {
                if (!dic_log_rri.ContainsKey(msl.list_RRI[i]))
                    dic_log_rri.Add(msl.list_RRI[i], false);
            }

            for (int i = 0; i < dic_log_acc.Count; i++)
            {
                if (dic_log_acc.Values.ElementAt(i) == false)
                {
                    //set flag to true
                    dic_log_acc[dic_log_acc.Keys.ElementAt(i)] = true;

                    DataGridViewRow row = (DataGridViewRow)dgv_acc_log.Rows[0].Clone();
                    row.Cells[0].Value = dic_log_acc.Keys.ElementAt(i).timestamp.ToString(date_format);
                    row.Cells[1].Value = dic_log_acc.Keys.ElementAt(i).x;
                    row.Cells[2].Value = dic_log_acc.Keys.ElementAt(i).y;
                    row.Cells[3].Value = dic_log_acc.Keys.ElementAt(i).z;
                    dgv_acc_log.Rows.Add(row);

                    dgv_acc_log.FirstDisplayedScrollingRowIndex = dgv_acc_log.Rows.Count - 1;
                }
            }
            for (int i = 0; i < dic_log_bpm.Count; i++)
            {
                if (dic_log_bpm.Values.ElementAt(i) == false)
                {
                    //set flag to true
                    dic_log_bpm[dic_log_bpm.Keys.ElementAt(i)] = true;

                    DataGridViewRow row = (DataGridViewRow)dgv_bpm_log.Rows[0].Clone();
                    row.Cells[0].Value = dic_log_bpm.Keys.ElementAt(i).timestamp.ToString(date_format);
                    row.Cells[1].Value = dic_log_bpm.Keys.ElementAt(i).bpm;
                    dgv_bpm_log.Rows.Add(row);

                    dgv_bpm_log.FirstDisplayedScrollingRowIndex = dgv_bpm_log.Rows.Count - 1;
                }
            }
            for (int i = 0; i < dic_log_rri.Count; i++)
            {
                if (dic_log_rri.Values.ElementAt(i) == false)
                {
                    //set flag to true
                    dic_log_rri[dic_log_rri.Keys.ElementAt(i)] = true;

                    DataGridViewRow row = (DataGridViewRow)dgv_rri_log.Rows[0].Clone();
                    row.Cells[0].Value = dic_log_rri.Keys.ElementAt(i).timestamp.ToString(date_format);
                    row.Cells[1].Value = dic_log_rri.Keys.ElementAt(i).rri;
                    dgv_rri_log.Rows.Add(row);

                    dgv_rri_log.FirstDisplayedScrollingRowIndex = dgv_rri_log.Rows.Count - 1;
                }
            }      
        }

        #endregion

        #region Common APIs
        public static Color InterpolateColors(Color color1, Color color2, float factor)
        {
            int num1 = ((int)color1.R);
            int num2 = ((int)color1.G);
            int num3 = ((int)color1.B);

            int num4 = ((int)color2.R);
            int num5 = ((int)color2.G);
            int num6 = ((int)color2.B);

            byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
            byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
            byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

            return Color.FromArgb(num7, num8, num9);
        }

        void ConfigureStandardLayout(NChartControl ncc, NChart chart, NLabel title, NLegend legend)
        {
            ncc.Panels.Clear();

            if (title != null)
            {
                ncc.Panels.Add(title);

                title.DockMode = PanelDockMode.Top;
                title.Padding = new NMarginsL(5, 8, 5, 4);
            }

            if (legend != null)
            {
                ncc.Panels.Add(legend);

                legend.DockMode = PanelDockMode.Right;
                legend.Padding = new NMarginsL(1, 1, 5, 5);
            }

            if (chart != null)
            {
                ncc.Panels.Add(chart);

                float topPad = (title == null) ? 11 : 8;
                float rightPad = (legend == null) ? 11 : 4;

                if (chart.BoundsMode == BoundsMode.None)
                {
                    if (chart.Enable3D || !(chart is NCartesianChart))
                    {
                        chart.BoundsMode = BoundsMode.Fit;
                    }
                    else
                    {
                        chart.BoundsMode = BoundsMode.Stretch;
                    }
                }

                chart.DockMode = PanelDockMode.Fill;
                chart.Padding = new NMarginsL(
                    new NLength(11, NRelativeUnit.ParentPercentage),
                    new NLength(topPad, NRelativeUnit.ParentPercentage),
                    new NLength(rightPad, NRelativeUnit.ParentPercentage),
                    new NLength(11, NRelativeUnit.ParentPercentage));
            }
        }

        public void StartTimer()
        {
            this.timer1.Enabled = true;
        }

        public void PauseTimer()
        {
            this.timer1.Enabled = false;
        }

        public void SetUserInfoLabel()
        {
            int index = -1;
            for(int i=0;i<msl.list_USER.Count;i++)
            {
                if (selected_user_id == msl.list_USER[i].idx)
                    index = i;
            }
            label_name.Text = "Name: " + msl.list_USER[index].name.ToString();
            label_email.Text = "E-mail: " + msl.list_USER[index].email.ToString();
            if (msl.list_USER[index].gender == 1)
                label_gender.Text = "Gender: Male";
            else
                label_gender.Text = "Gender: Female";
            label_height.Text = "Height: " + msl.list_USER[index].height.ToString();
            label_weight.Text = "Weight: " + msl.list_USER[index].weight.ToString();
        }

        public Boolean Refresh(NChartControl ncc)
        {
            try
            {
                ncc.Refresh();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            PauseTimer();
        }

        public void ExportExcel()
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                #region save RRI data
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1];
                worksheet.Name = "RRI_data";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgv_rri_log.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_rri_log.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_rri_log.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_rri_log.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.EntireColumn.AutoFit();
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets.Add();

                #endregion
                #region save BPM data

                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1];
                worksheet.Name = "BPM_data";

                cellRowIndex = 1;
                cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgv_bpm_log.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_bpm_log.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_bpm_log.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_bpm_log.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.EntireColumn.AutoFit();
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets.Add();

                #endregion
                #region save ACC data

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ACC_data";

                cellRowIndex = 1;
                cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgv_acc_log.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_acc_log.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_acc_log.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_acc_log.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.EntireColumn.AutoFit();

                #endregion

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel file|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    Console.WriteLine("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        public void SetcomboBox_id_Items()
        {
            comboBox_id.Items.Clear();
            for(int i=0;i<msl.list_USER.Count;i++)
            {
                comboBox_id.Items.Add(msl.list_USER[i].idx.ToString());
            }
        }

        private void button_excel_export_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void comboBox_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_user_id = -1;
            for (int i = 0; i < msl.list_USER.Count; i++)
            {
                if (this.comboBox_id.SelectedItem.ToString() == msl.list_USER[i].idx.ToString())
                {
                    selected_user_id = msl.list_USER[i].idx;
                    SetUserInfoLabel();
                    //init log boxes
                    dgv_acc_log.Rows.Clear();
                    dgv_bpm_log.Rows.Clear();
                    dgv_rri_log.Rows.Clear();
                    //init data list
                    msl.list_ACC.Clear();
                    msl.list_BPM.Clear();
                    msl.list_RRI.Clear();
                    break;
                }
            }
        }
        #endregion

    }
}