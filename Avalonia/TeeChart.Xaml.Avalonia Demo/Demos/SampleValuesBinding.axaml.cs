using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  /// <summary>
  /// Interaction logic for SampleValuesBinding.xaml
  /// </summary>
  public partial class SampleValuesBinding : UserControl
  {
    public SampleValuesBinding()
    {
      InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
