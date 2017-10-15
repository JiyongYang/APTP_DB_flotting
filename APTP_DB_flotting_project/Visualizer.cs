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
        public Color[] m_ColorTable;
        public int day_flag;
        public Dictionary<string, string> day_stack;
        public int sec_flag;

        public Visualizer()
        {
            InitializeComponent();
        }

        public Visualizer(mySqlLinkage _msl)
        {
            InitializeComponent();

            msl = _msl;
            InitializeTime();
            m_ColorTable = new Color[256];
            for (int i = 0; i <= 255; i++)
            {
                m_ColorTable[i] = InterpolateColors(Color.Blue, Color.Red, i / 255.0f);
            }
            this.InitializeBarACC();
            this.SetUserInfoLabel();
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

        public void OnTimerTick(object sender, EventArgs e)
        {
            UpdateBarACC();
            SetTimerLabel();
            
            //second value add
            sec_flag++;
            if (sec_flag == 24*60*60)
            {
                //day over
                sec_flag = 0;

                //day flag value setting
                day_flag++;
                if (day_flag == day_stack.Count)
                {
                    day_flag = 0;
                }

                LoadDayACCData();
            }

            this.Refresh(ncc_acc);
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
            // set a chart title
            NLabel title = ncc_acc.Labels.AddHeader("Real Time Bar - ACC");
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

            StartTimer();
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

        public void SetUserInfoLabel()
        {
            label_id.Text = "ID: " + msl.list_USER[0].idx.ToString();
            label_name.Text = "Name: " + msl.list_USER[0].name.ToString();
            label_email.Text = "E-mail: " + msl.list_USER[0].email.ToString();
            if(msl.list_USER[0].gender == 1)
                label_gender.Text = "Gender: Male";
            else
                label_gender.Text = "Gender: Female";
            label_height.Text = "Height: " + msl.list_USER[0].height.ToString();
            label_weight.Text = "Weight: " + msl.list_USER[0].weight.ToString();
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
    }
    
}