using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  /// <summary>
  /// Interaction logic for ManualValuesXAndY.xaml
  /// </summary>
  public partial class ManualValuesXAndY : UserControl
  {
    public ManualValuesXAndY()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
