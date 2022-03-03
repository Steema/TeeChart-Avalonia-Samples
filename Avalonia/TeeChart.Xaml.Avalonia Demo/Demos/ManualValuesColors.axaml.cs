using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  /// <summary>
  /// Interaction logic for ManualValuesColors.xaml
  /// </summary>
  public partial class ManualValuesColors : UserControl
  {
    public ManualValuesColors()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
