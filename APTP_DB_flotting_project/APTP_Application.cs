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
using System.Runtime.InteropServices;
using System.Threading;


namespace APTP_DB_flotting_project
{
    public partial class APTP_Application : Form
    {
        [DllImport("omiPlayer.dll")]
        static extern void Play(string someStr);

        [DllImport("omiPlayer.dll")]
        static extern void Stop();
        
        private void shellListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void shellListView1_BeforeInvokeCommandOnSelected(object sender, Jam.Shell.InvokeCommandEventArgs e)
        {

        }

        private void shellListView1_BeforeShellCommand(object sender, Jam.Shell.BeforeShellCommandEventArgs e)
        {
            MessageBox.Show(e.Paths.ToString());
            Stop();
            Thread.Sleep(1000);
            try
            {
                Play(e.Paths.ToString());
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
            e.ExecuteShellCommand = false;
        }

        private void APTP_application_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        
        private mySqlLinkage msl;

        NLineSeries m_RRILine;
        NLineSeries m_BPMLine;
        NLineSeries m_GSRLine;
        NLineSeries m_STRESSLine;

        int m_BpmMaxCount = 60;
        int m_RriMaxCount = 60;
        int m_GsrMaxCount = 60;
        int m_StressMaxCount = 60;
        public Color[] m_ColorTable;
        public int day_flag;
        public Dictionary<string, string> day_stack;
        public Dictionary<ACC, bool> dic_log_acc;
        public Dictionary<BPM, bool> dic_log_bpm;
        public Dictionary<RRI, bool> dic_log_rri;
        public Dictionary<GSR, bool> dic_log_gsr;
        public Dictionary<STRESS, bool> dic_log_stress;
        public int sec_flag;
        public string date_format;

        public int selected_user_id;

        public APTP_Application()
        {
            InitializeComponent();
        }

        public APTP_Application(mySqlLinkage _msl)
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

        #region Realtime APIs
        public void RealtimeInitialize()
        {
            dic_log_acc = new Dictionary<ACC, bool>();
            dic_log_bpm = new Dictionary<BPM, bool>();
            dic_log_rri = new Dictionary<RRI, bool>();
            dic_log_gsr = new Dictionary<GSR, bool>();
            dic_log_stress = new Dictionary<STRESS, bool>();

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
            this.Realtime_InitializeBarACC();
            //this.Realtime_InitializeSurfaceRRI();
            this.Realtime_InitializeRRI();
            this.Realtime_InitializeBPMGraph();
            this.Realtime_InitializeGSR();
            this.Realtime_InitializeSTRESS();
        }

        public void Realtime_OnTimerTick(object sender, EventArgs e)
        {
            //real data
            this.msl.Realtime_SelectUsingReader(selected_user_id);

            //fake data
            //this.msl.Realtime_FakeDataGenerator(selected_user_id);

            Realtime_UpdateBarACC();
            Realtime_UpdateLineBPM();
            //Realtime_UpdateSurfaceRRI();
            Realtime_UpdateLineRRI();
            Realtime_UpdateLineGSR();
            Realtime_UpdateLineSTRESS();

            Realtime_SetTimerLabel();
            Realtime_SetLogTextBoxes();

            this.Refresh(ncc_acc);
            this.Refresh(ncc_rri);
            this.Refresh(ncc_bpm);
            this.Refresh(ncc_gsr);
            this.Refresh(ncc_stress);
        }

        public void Realtime_InitializeBarACC()
        {
            ncc_acc.Controller.Tools.Clear();
            ncc_acc.Controller.Tools.Add(new NPanelSelectorTool());
            ncc_acc.Controller.Tools.Add(new NTrackballTool());
            // set a chart title
            NLabel title = ncc_acc.Labels.AddHeader("ACC Bar chart");
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18);
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
            yAxis.View = new NRangeAxisView(new NRange1DD(-1, 1));

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
            
            // view point
            NProjection projection = ncc_acc.Charts[0].Projection;
            projection.Elevation = 22;
            projection.Rotation = -13;
            
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
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18, FontStyle.Italic);

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

        private void Realtime_InitializeRRI()
        {
            ncc_rri.Clear();
            ncc_rri.Legends.Clear();

            // Set a chart title
            NLabel title = ncc_rri.Labels.AddHeader("RRI Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            
            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_rri.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "RRI", 0, 1);

            chart.Series.Clear();

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.WhiteSmoke), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            m_RRILine = CreateLineSeries(m_RriMaxCount);
            chart.Series.Add(m_RRILine);

            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_rri, chart, title, null);

            ncc_rri.Settings.RenderSurface = RenderSurface.Window;
        }

        private void Realtime_InitializeBPMGraph()
        {
            ncc_bpm.Clear();
            ncc_bpm.Legends.Clear();

            // Set a chart title
            NLabel title = ncc_bpm.Labels.AddHeader("BPM Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_bpm.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "BPM", 0, 200);

            chart.Series.Clear();

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.WhiteSmoke), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            m_BPMLine = CreateLineSeries(m_BpmMaxCount);
            chart.Series.Add(m_BPMLine);

            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_bpm, chart, title, null);

            ncc_bpm.Settings.RenderSurface = RenderSurface.Window;
        }

        private void Realtime_InitializeGSR()
        {
            ncc_gsr.Clear();
            ncc_gsr.Legends.Clear();

            // Set a chart title
            NLabel title = ncc_gsr.Labels.AddHeader("GSR Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_gsr.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "GSR", 0, 10000);

            chart.Series.Clear();

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.WhiteSmoke), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            m_GSRLine = CreateLineSeries(m_GsrMaxCount);
            chart.Series.Add(m_GSRLine);

            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_gsr, chart, title, null);

            ncc_gsr.Settings.RenderSurface = RenderSurface.Window;
        }

        private void Realtime_InitializeSTRESS()
        {
            ncc_stress.Clear();
            ncc_stress.Legends.Clear();

            // Set a chart title
            NLabel title = ncc_stress.Labels.AddHeader("STRESS Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Tahoma", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            ncc_stress.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 100, "STRESS", 0, 100);

            chart.Series.Clear();

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.WhiteSmoke), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            m_STRESSLine = CreateLineSeries(m_StressMaxCount);
            chart.Series.Add(m_STRESSLine);

            //bpm_w_matrix = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(ncc_stress, chart, title, null);

            ncc_stress.Settings.RenderSurface = RenderSurface.Window;
        }

        public void Realtime_UpdateBarACC()
        {   
            double[][] data = new double[3][];
            data[0] = new double[60];
            data[1] = new double[60];
            data[2] = new double[60];

            for (int i = 0; i < msl.list_ACC.Count; i++)
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
                    if (color_var > 255)
                        color_var = 255;
                    else if (color_var < 0)
                        color_var = 0;



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

        public void Realtime_UpdateLineRRI()
        {

            double[] data = new double[60];

            for (int i = 0; i < msl.list_RRI.Count; i++)
            {
                data[i] = msl.list_RRI[i].rri;
            }

            if (m_RRILine.Values.Count == 0)
            {
                m_RRILine.Values.AddRange(data);
            }
            else
            {
                m_RRILine.Values.SetRange(0, data);
            }

            m_RRILine.InflateMargins = true;
            m_RRILine.BorderStyle = new NStrokeStyle(Color.FromArgb(255, 108, 112, 115));
        }

        public void Realtime_UpdateLineBPM()
        {

            double[] data = new double[60];

            for (int i = 0; i < msl.list_BPM.Count; i++)
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

            m_BPMLine.InflateMargins = true;
            m_BPMLine.BorderStyle = new NStrokeStyle(Color.FromArgb(255, 207, 68, 61));

        }

        public void Realtime_UpdateLineGSR()
        {

            double[] data = new double[60];

            for (int i = 0; i < msl.list_GSR.Count; i++)
            {
                data[i] = msl.list_GSR[i].gsr;
            }

            if (m_GSRLine.Values.Count == 0)
            {
                m_GSRLine.Values.AddRange(data);
            }
            else
            {
                m_GSRLine.Values.SetRange(0, data);
            }

            m_GSRLine.InflateMargins = true;
            m_GSRLine.BorderStyle = new NStrokeStyle(Color.FromArgb(255, 121, 177, 166));
        }

        public void Realtime_UpdateLineSTRESS()
        {

            double[] data = new double[60];

            for (int i = 0; i < msl.list_STRESS.Count; i++)
            {
                data[i] = msl.list_STRESS[i].stress;
            }

            if (m_STRESSLine.Values.Count == 0)
            {
                m_STRESSLine.Values.AddRange(data);
            }
            else
            {
                m_STRESSLine.Values.SetRange(0, data);
            }
        }

        public void Realtime_SetTimerLabel()
        {
            if (msl.list_ACC.Count == 1)
                label_time.Text = msl.list_ACC[0].timestamp.ToString(date_format) + " ~ " + msl.list_ACC[0].timestamp.ToString(date_format);
            else if (msl.list_ACC.Count > 1)
                label_time.Text = msl.list_ACC[0].timestamp.ToString(date_format) + " ~ " + msl.list_ACC[msl.list_ACC.Count - 1].timestamp.ToString(date_format);
            else
                Console.WriteLine("Error: Acc's count is lower than 1");
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
            for (int i = 0; i < msl.list_GSR.Count; i++)
            {
                if (!dic_log_gsr.ContainsKey(msl.list_GSR[i]))
                    dic_log_gsr.Add(msl.list_GSR[i], false);
            }
            for (int i = 0; i < msl.list_STRESS.Count; i++)
            {
                if (!dic_log_stress.ContainsKey(msl.list_STRESS[i]))
                    dic_log_stress.Add(msl.list_STRESS[i], false);
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
            for (int i = 0; i < dic_log_gsr.Count; i++)
            {
                if (dic_log_gsr.Values.ElementAt(i) == false)
                {
                    //set flag to true
                    dic_log_gsr[dic_log_gsr.Keys.ElementAt(i)] = true;

                    DataGridViewRow row = (DataGridViewRow)dgv_gsr_log.Rows[0].Clone();
                    row.Cells[0].Value = dic_log_gsr.Keys.ElementAt(i).timestamp.ToString(date_format);
                    row.Cells[1].Value = dic_log_gsr.Keys.ElementAt(i).gsr;
                    dgv_gsr_log.Rows.Add(row);

                    dgv_gsr_log.FirstDisplayedScrollingRowIndex = dgv_gsr_log.Rows.Count - 1;
                }
            }
            for (int i = 0; i < dic_log_stress.Count; i++)
            {
                if (dic_log_stress.Values.ElementAt(i) == false)
                {
                    //set flag to true
                    dic_log_stress[dic_log_stress.Keys.ElementAt(i)] = true;

                    DataGridViewRow row = (DataGridViewRow)dgv_stress_log.Rows[0].Clone();
                    row.Cells[0].Value = dic_log_stress.Keys.ElementAt(i).timestamp.ToString(date_format);
                    row.Cells[1].Value = dic_log_stress.Keys.ElementAt(i).stress;
                    dgv_stress_log.Rows.Add(row);

                    dgv_stress_log.FirstDisplayedScrollingRowIndex = dgv_stress_log.Rows.Count - 1;
                }
            }
        }

        #endregion

        #region Common APIs
        private void ConfigureAxis(NAxis axis, float beginPercent, float endPercent, string title, int r1, int r2)
        {
            NLinearScaleConfigurator scale = new NLinearScaleConfigurator();
            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            axis.ScaleConfigurator = scale;
            axis.View = new NRangeAxisView(new NRange1DD(r1, r2), true, true);
            axis.ScaleConfigurator.Title.Text = title;
            axis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false);
            axis.Anchor.BeginPercent = beginPercent;
            axis.Anchor.EndPercent = endPercent;
            axis.Visible = true;
        }

        private NLineSeries CreateLineSeries(int capacity)
        {
            NLineSeries lineSeries = new NLineSeries();

            lineSeries.Values.Capacity = capacity;
            lineSeries.XValues.Capacity = capacity;
            lineSeries.DataLabelStyle.Visible = false;
            lineSeries.SamplingMode = SeriesSamplingMode.Enabled;
            lineSeries.SampleDistance = new NLength(1, NGraphicsUnit.Pixel);

            return lineSeries;
        }

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
            for (int i = 0; i < msl.list_USER.Count; i++)
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
                #region save STRESS data
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1];
                worksheet.Name = "STRESS_data";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgv_stress_log.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_stress_log.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_stress_log.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_stress_log.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.EntireColumn.AutoFit();
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets.Add();

                #endregion
                #region save GSR data
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1];
                worksheet.Name = "GSR_data";

                cellRowIndex = 1;
                cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgv_gsr_log.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_gsr_log.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_gsr_log.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv_gsr_log.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.EntireColumn.AutoFit();
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets.Add();

                #endregion
                #region save RRI data
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1];
                worksheet.Name = "RRI_data";

                cellRowIndex = 1;
                cellColumnIndex = 1;

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
            for (int i = 0; i < msl.list_USER.Count; i++)
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
                    dgv_gsr_log.Rows.Clear();
                    dgv_stress_log.Rows.Clear();
                    //init data list
                    msl.list_ACC.Clear();
                    msl.list_BPM.Clear();
                    msl.list_RRI.Clear();
                    msl.list_GSR.Clear();
                    msl.list_STRESS.Clear();
                    break;
                }
            }
        }
        #endregion
    }

}