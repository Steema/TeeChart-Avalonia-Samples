using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  /// <summary>
  /// Interaction logic for ManualValues.xaml
  /// </summary>
  public partial class ManualValues : UserControl
  {
    public ManualValues()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
