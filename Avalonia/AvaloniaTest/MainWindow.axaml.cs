using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTest
{
    public partial class MainWindow : Window
    {
        private TeeChart.Xaml.Avalonia.Series.Candle Candle11;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            if (!((Avalonia.Controls.CheckBox)sender).IsChecked.Value)
            {
                //this.Refresh();

                Candle11 = this.FindNameScope()?.Find<global::TeeChart.Xaml.Avalonia.Series.Candle>("Candle1");
                tChartCandle = this.FindNameScope()?.Find<global::TeeChart.Xaml.Avalonia.TChart>("tChartCandle");
                
                if (Candle11 != null)
                {
                    SetLabelsNoWeekend((Steema.TeeChart.Styles.Candle)Candle11.InternalSeries);
                }

                Candle11.InternalSeries.Chart.Panel.MarginBottom = 20;
                Candle11.InternalSeries.Chart.Header.Text = "Candle Series - no weekends";
            }
            else
            {
                InitializeComponent();
                tabControl1 = this.FindNameScope()?.Find<global::Avalonia.Controls.TabControl>("tabControl1");
                tabControl1.SelectedIndex = 3;
            }
                

        }

        private void SetLabelsNoWeekend(Steema.TeeChart.Styles.Candle theCandle)
        {
            Steema.TeeChart.Styles.StringList labels = new Steema.TeeChart.Styles.StringList(10);
            labels.Add("25/04/2024");
            labels.Add("26/04/2024");
            labels.Add("29/04/2024");
            labels.Add("30/04/2024");
            labels.Add("1/05/2024");
            labels.Add("2/05/2024");
            labels.Add("3/05/2024");
            labels.Add("6/05/2024");
            labels.Add("7/05/2024");

            theCandle.XValues.DateTime = false;
            theCandle.GetHorizAxis.Labels.Angle = 270;

            Random r = new Random();
            theCandle.Clear();

            double tmpOpen;
            double tmpClose;
            int count = 0;
            DateTime dt = new DateTime(2024, 04, 25); //DateTime.Parse("23/03/2009");
            TimeSpan ts = TimeSpan.FromDays(1);
            for (int t = 0; t < 13; t++)
            {
                if (t == 0)
                    tmpOpen = r.Next(100);
                else
                    tmpOpen = theCandle.CloseValues.Last +5 -  r.Next(10);
                tmpClose = tmpOpen + 25 - r.Next(50);
                if (dt.DayOfWeek != DayOfWeek.Saturday & dt.DayOfWeek !=
                    DayOfWeek.Sunday)
                {
                    ++count;
                    var high = tmpOpen + r.Next(20);
                    var low = tmpOpen - r.Next(20);
                    theCandle.Add(count, tmpOpen, high ,
                        low, low + r.Next(10));
                }
                dt += ts;
            }
            theCandle.Labels = labels;

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
