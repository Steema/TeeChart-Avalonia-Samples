using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace XamlAvaloniaDemo.Demos
{
  public partial class BindingObservableCollection : UserControl
  {
    public BindingObservableCollection()
    {
      InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
  }
}
