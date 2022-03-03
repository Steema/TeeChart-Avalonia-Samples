using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  /// <summary>
  /// Interaction logic for ManualValuesLabels.xaml
  /// </summary>
  public partial class ManualValuesLabels : UserControl
  {
    public ManualValuesLabels()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
