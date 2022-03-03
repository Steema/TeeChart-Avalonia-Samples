using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  public partial class BindingDataProperties : UserControl
  {
    public BindingDataProperties()
    {
      InitializeComponent();

      //var internalChart = LogicalTreeHelper.GetChildren(tChart1).OfType<Steema.TeeChart.WPF.TChart>().First();

      //var internalColorGrid = (Steema.TeeChart.Styles.ColorGrid)internalChart[0];
      //internalColorGrid.Pen.Color = System.Drawing.Color.White;
      //internalColorGrid.Pen.Width = 2;
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
