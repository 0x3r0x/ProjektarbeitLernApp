using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Windows.Forms;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using SkiaSharp;


namespace ProjektarbeitLernAppGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.PrimaryValue, chartPoint.AsDataLabel);

            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "richtig beantwortet",
                    Values = new double[] {3},
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = PolarLabelsPosition.Middle
                },
                new PieSeries<double>
                {
                    Name = "falsch beantwortet",
                    Values = new double[] {4},
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = PolarLabelsPosition.Middle
                },
            };
            pieChart1.LegendPosition = LegendPosition.Left;


            cartesianChart1.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 4, 6, 5, 2, 7 },
                    Name = "gelernte Fragen"
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Tag",
                    Labels = new string[] { "05.12.", "06.12.", "07.12.", "08.12.", "09.12." }
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Gerlernt",
                    Labeler = value => value.ToString()
                }
            };

        }

    }
}
