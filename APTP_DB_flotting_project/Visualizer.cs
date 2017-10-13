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

namespace APTP_DB_flotting_project
{
    public partial class Visualizer : Form
    {
        public Visualizer()
        {
            InitializeComponent();
            Initialize_Line_Chart_ACC();
        }

        public bool Initialize_Line_Chart_ACC()
        {
            this.acc = ncc_acc;

            acc.Labels.Clear();

            //set a chart title
            NLabel chartTitle = acc.Labels.AddHeader("ACC");
            chartTitle.TextStyle.FontStyle = new NFontStyle("Times New Roman", 15);

            //setup chart
            NCartesianChart nChart = new NCartesianChart();

            acc.Charts.Clear();
            acc.Charts.Add(nChart);

            nChart.Enable3D = false;
            nChart.Axis(StandardAxis.Depth).Visible = false;

            nChart.Series.Clear();

            acc_line = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            //line.Name = ncd.NSeriesName;
            acc_line.DataLabelStyle.Format = "<value>";
            acc_line.MarkerStyle.Visible = true;
            acc_line.MarkerStyle.PointShape = PointShape.Cylinder;
            acc_line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            acc_line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            acc_line.ShadowStyle.Type = ShadowType.GaussianBlur;
            acc_line.ShadowStyle.Offset = new NPointL(3, 3);
            acc_line.ShadowStyle.FadeLength = new NLength(5);
            acc_line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

            return true;
        }

        public bool Initialize_Line_Chart_BPM()
        {
            this.bpm = ncc_bpm;

            bpm.Labels.Clear();

            //set a chart title
            NLabel chartTitle = bpm.Labels.AddHeader("BPM");
            chartTitle.TextStyle.FontStyle = new NFontStyle("Times New Roman", 15);

            //setup chart
            NCartesianChart nChart = new NCartesianChart();

            bpm.Charts.Clear();
            bpm.Charts.Add(nChart);

            nChart.Enable3D = false;
            nChart.Axis(StandardAxis.Depth).Visible = false;

            nChart.Series.Clear();

            bpm_line = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            //line.Name = ncd.NSeriesName;
            bpm_line.DataLabelStyle.Format = "<value>";
            bpm_line.MarkerStyle.Visible = true;
            bpm_line.MarkerStyle.PointShape = PointShape.Cylinder;
            bpm_line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            bpm_line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            bpm_line.ShadowStyle.Type = ShadowType.GaussianBlur;
            bpm_line.ShadowStyle.Offset = new NPointL(3, 3);
            bpm_line.ShadowStyle.FadeLength = new NLength(5);
            bpm_line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

            return true;
        }

        public bool Initialize_Line_Chart_RRI()
        {
            this.rri = ncc_rri;

            rri.Labels.Clear();

            //set a chart title
            NLabel chartTitle = rri.Labels.AddHeader("RRI");
            chartTitle.TextStyle.FontStyle = new NFontStyle("Times New Roman", 15);

            //setup chart
            NCartesianChart nChart = new NCartesianChart();

            rri.Charts.Clear();
            rri.Charts.Add(nChart);

            nChart.Enable3D = false;
            nChart.Axis(StandardAxis.Depth).Visible = false;

            nChart.Series.Clear();

            rri_line = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            //line.Name = ncd.NSeriesName;
            rri_line.DataLabelStyle.Format = "<value>";
            rri_line.MarkerStyle.Visible = true;
            rri_line.MarkerStyle.PointShape = PointShape.Cylinder;
            rri_line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            rri_line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            rri_line.ShadowStyle.Type = ShadowType.GaussianBlur;
            rri_line.ShadowStyle.Offset = new NPointL(3, 3);
            rri_line.ShadowStyle.FadeLength = new NLength(5);
            rri_line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

            return true;
        }

        public bool Add_Line_Data(NLineSeries line, double data)
        {
            try
            {
                line.AddDataPoint(new NDataPoint(data));
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
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

        private NChartControl acc;
        private NChartControl bpm;
        private NChartControl rri;
        private NLineSeries acc_line;
        private NLineSeries bpm_line;
        private NLineSeries rri_line;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label_temp.Text = this.tabControl1.SelectedIndex.ToString();

            switch(this.tabControl1.SelectedIndex)
            {
                case 0:
                    Initialize_Line_Chart_ACC();
                    break;
                case 1:
                    Initialize_Line_Chart_BPM();
                    break;
                case 2:
                    Initialize_Line_Chart_RRI();
                    break;
                default:
                    Initialize_Line_Chart_ACC();
                    break;

            }
        }
        private mySqlLinkage msl;
    }
}
