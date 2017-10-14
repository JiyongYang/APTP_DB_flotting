using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using Nevron;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.UI.WinForm.Controls;

namespace APTP_DB_flotting_project
{
    public partial class RealTimeLineChart : Form
    {
        // *********************************
        // chart data START
        // *********************************

        NLineSeries m_Line1;
        NLineSeries m_Line2;
        NLineSeries m_Line3;
        NLineSeries m_Line4;

        double[] m_ValueArray1;
        double[] m_ValueArray2;
        double[] m_ValueArray3;
        double[] m_ValueArray4;

        int m_MaxCount = 25000;
        int m_NewDataPointsPerTick = 4000;
        double m_Angle1;
        double m_Angle2;
        double m_Angle3;

        // *********************************
        // chart data END
        // *********************************

        List<BPM> lst;

        public RealTimeLineChart(List<BPM> _lst)
        {
            NLicense license = new NLicense("096ff936-7602-3c02-009c-5ea6176b006d");
            NLicenseManager.Instance.SetLicense(license);
            NLicenseManager.Instance.LockLicense = true;

            lst = _lst;

            InitializeComponent();
        }

        private void interpreteListData()
        {
            for (int i = 0; i < lst.Count; i++)
            {
                //lst[i].timestamp.Hour
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void DrawGraph()
        {
            nChartControl1.Clear();
            nChartControl1.Legends.Clear();

            // Set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("BPM Line chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // Setup Chart
            NCartesianChart chart = new NCartesianChart();
            nChartControl1.Panels.Add(chart);
            chart.BoundsMode = BoundsMode.Stretch;

            NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
            ConfigureAxis(axis1, 0, 25, "0 to 5");

            NAxis axis2 = chart.Axis(StandardAxis.SecondaryY);
            ConfigureAxis(axis2, 30, 55, "6 to 11");

            NAxis axis3 = ((NCartesianAxisCollection)chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontRight);
            ConfigureAxis(axis3, 60, 85, "12 to 17");

            NAxis axis4 = ((NCartesianAxisCollection)chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontRight);
            ConfigureAxis(axis4, 90, 115, "18 to 23");


            m_Line1 = CreateLineSeries();
            chart.Series.Add(m_Line1);

            m_Line2 = CreateLineSeries();
            chart.Series.Add(m_Line2);
            m_Line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
            m_Line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

            m_Line3 = CreateLineSeries();
            chart.Series.Add(m_Line3);
            m_Line3.DisplayOnAxis(StandardAxis.PrimaryY, false);
            m_Line3.DisplayOnAxis(axis3.AxisId, true);

            m_Line4 = CreateLineSeries();
            chart.Series.Add(m_Line4);
            m_Line4.DisplayOnAxis(StandardAxis.PrimaryY, false);
            m_Line4.DisplayOnAxis(axis4.AxisId, true);

            m_ValueArray1 = new double[m_NewDataPointsPerTick];
            m_ValueArray2 = new double[m_NewDataPointsPerTick];
            m_ValueArray3 = new double[m_NewDataPointsPerTick];
            m_ValueArray4 = new double[m_NewDataPointsPerTick];

            ConfigureStandardLayout(chart, title, null);

            nChartControl1.Settings.RenderSurface = RenderSurface.Window;

            UpdateValue();
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

        void ConfigureStandardLayout(NChart chart, NLabel title, NLegend legend)
        {
            nChartControl1.Panels.Clear();

            if (title != null)
            {
                nChartControl1.Panels.Add(title);

                title.DockMode = PanelDockMode.Top;
                title.Padding = new NMarginsL(5, 8, 5, 4);
            }

            if (legend != null)
            {
                nChartControl1.Panels.Add(legend);

                legend.DockMode = PanelDockMode.Right;
                legend.Padding = new NMarginsL(1, 1, 5, 5);
            }

            if (chart != null)
            {
                nChartControl1.Panels.Add(chart);

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

        private void TestUpdateValue()
        {
            // first accumulate the new data in arrays for faster processing
            int newDataPoints = m_NewDataPointsPerTick;

            double angleStep1 = (Math.PI * 2 / m_MaxCount) * 10;
            double angleStep2 = (Math.PI * 2 / m_MaxCount) * 20;
            double angleStep3 = (Math.PI * 2 / m_MaxCount) * 30;

            double amplitude1 = Math.Min(1, 10 * 0.01);
            double amplitude2 = Math.Min(1, 20 * 0.01);
            double amplitude3 = Math.Min(1, 30 * 0.01);

            double noise1 = 10 * 0.02;
            double noise2 = 20 * 0.02;
            double noise3 = 30 * 0.02;

            // generate new data
            Random random = new Random();
            double[] valueArray1 = m_ValueArray1;
            double[] valueArray2 = m_ValueArray2;
            double[] valueArray3 = m_ValueArray3;

            for (int i = 0; i < newDataPoints; i++)
            {
                valueArray1[i] = (Math.Sin(m_Angle1) + (random.NextDouble() - 0.5) * noise1) * amplitude1;
                valueArray2[i] = (Math.Sin(m_Angle2) + (random.NextDouble() - 0.5) * noise2) * amplitude2;
                valueArray3[i] = (Math.Sin(m_Angle3) + (random.NextDouble() - 0.5) * noise3) * amplitude3;

                m_Angle1 += angleStep1;
                m_Angle2 += angleStep2;
                m_Angle3 += angleStep3;
            }

            int valueIndex = 0;
            int itemsToAdd = newDataPoints;
            int originShift = newDataPoints;

            // then add the new data
            if (m_Line1.Values.Count < m_MaxCount)
            {
                // the line series can accumulate the new data
                int valueCount = Math.Min(m_MaxCount - m_Line1.Values.Count, newDataPoints);

                m_Line1.Values.AddRange(m_ValueArray1, valueIndex, valueCount);
                m_Line2.Values.AddRange(m_ValueArray2, valueIndex, valueCount);
                m_Line3.Values.AddRange(m_ValueArray3, valueIndex, valueCount);

                valueIndex += valueCount;
                itemsToAdd -= valueCount;
                originShift -= valueCount;
            }

            if (itemsToAdd > 0)
            {
                // capacity reached
                int count = m_Line1.Values.Count - m_Line1.DataPointOriginIndex;
                int valueCount = Math.Min(count, itemsToAdd);

                m_Line1.Values.SetRange(m_Line1.DataPointOriginIndex, m_ValueArray1, valueIndex, valueCount);
                m_Line2.Values.SetRange(m_Line2.DataPointOriginIndex, m_ValueArray2, valueIndex, valueCount);
                m_Line3.Values.SetRange(m_Line3.DataPointOriginIndex, m_ValueArray3, valueIndex, valueCount);

                itemsToAdd -= valueCount;

                if (itemsToAdd > 0)
                {
                    valueIndex += valueCount;

                    m_Line1.Values.SetRange(0, m_ValueArray1, valueIndex, itemsToAdd);
                    m_Line2.Values.SetRange(0, m_ValueArray2, valueIndex, itemsToAdd);
                    m_Line3.Values.SetRange(0, m_ValueArray3, valueIndex, itemsToAdd);
                }
            }

            m_Line1.DataPointOriginIndex += originShift;
            m_Line2.DataPointOriginIndex += originShift;
            m_Line3.DataPointOriginIndex += originShift;

            m_Line1.DataPointOriginIndex %= m_MaxCount;
            m_Line2.DataPointOriginIndex %= m_MaxCount;
            m_Line3.DataPointOriginIndex %= m_MaxCount;

            nChartControl1.Refresh();
        }

        public void UpdateValue()
        {
            double[] valueArray1 = m_ValueArray1;
            double[] valueArray2 = m_ValueArray2;
            double[] valueArray3 = m_ValueArray3;
            double[] valueArray4 = m_ValueArray4;

            for (int i = 0; i < m_NewDataPointsPerTick; i++)
            {
                valueArray1[i] = lst[i].bpm;
                //valueArray2[i] = ;
                //valueArray3[i] = ;
                //valueArray4[i] = ;
            }

            m_Line1.Values.AddRange(m_ValueArray1);
            m_Line2.Values.AddRange(m_ValueArray2);
            m_Line3.Values.AddRange(m_ValueArray3);
            m_Line4.Values.AddRange(m_ValueArray4);

            nChartControl1.Refresh();
        }
    }
}
