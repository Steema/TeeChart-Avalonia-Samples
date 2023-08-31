using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AvaloniaEdit;
using AvaloniaEdit.Highlighting;
using CommunityToolkit.Mvvm.ComponentModel;
using XamlAvaloniaDemo.ViewModel;

namespace XamlAvaloniaDemo
{
  public partial class MainWindow : Window
  {
    private TextEditor _codeEditor;
    
    public MainWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif

      _codeEditor = this.FindControl<TextEditor>("CodeEditor");
      VisualStudioStyle(_codeEditor);

      UpdateCodeEditor((MainViewModel)DataContext);
      ((ObservableRecipient)DataContext).PropertyChanged += (sender, args) =>
      {
        if (args.PropertyName == "File")
        {
          UpdateCodeEditor((MainViewModel)sender);
        }
      };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void UpdateCodeEditor(MainViewModel vm)
    {
      if (vm.File == null) return;
      var extension = Path.GetExtension(vm.File);
      _codeEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(extension);
      _codeEditor.Load(Path.Combine("Demos", vm.File));
    }

    private void VisualStudioStyle(TextEditor editor)
    {
      // TODO: Style XAML to VisualStudio as well...
      var syntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");

      var keywords = new[]
      {
        "ValueTypeKeywords", "ReferenceTypeKeywords", "ThisOrBaseReference", "NullOrValueKeywords", "Keywords",
        "GotoKeywords", "ContextKeywords", "ExceptionKeywords", "CheckedKeyword", "UnsafeKeywords", "OperatorKeywords",
        "ParameterModifiers", "Modifiers", "Visibility", "NamespaceKeywords", "GetSetAddRemove", "TrueFalse",
        "TypeKeywords"
      };

      foreach (var keyword in keywords)
      {
        var color = syntaxHighlighting.GetNamedColor(keyword);
        color.Foreground = new SimpleHighlightingBrush(Colors.Blue);
        color.FontWeight = FontWeight.Normal;
      }

      syntaxHighlighting.GetNamedColor("String").Foreground = new SimpleHighlightingBrush(Colors.Brown);
      syntaxHighlighting.GetNamedColor("Char").Foreground = new SimpleHighlightingBrush(Colors.Brown);
      syntaxHighlighting.GetNamedColor("Preprocessor").Foreground = new SimpleHighlightingBrush(Colors.LightGray);
      syntaxHighlighting.GetNamedColor("NumberLiteral").Foreground = new SimpleHighlightingBrush(Colors.Black);
      var methodCallColor = syntaxHighlighting.GetNamedColor("MethodCall");
      methodCallColor.Foreground = new SimpleHighlightingBrush(Colors.Black);
      methodCallColor.FontWeight = FontWeight.Normal;

      editor.Options.HighlightCurrentLine = true;
      editor.Options.AllowScrollBelowDocument = true;
      editor.ShowLineNumbers = true;
      editor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(43, 145, 175));
      editor.TextArea.TextView.CurrentLineBackground = Brushes.Cornsilk;
      editor.TextArea.TextView.CurrentLineBorder = new Pen(new SolidColorBrush(Color.FromRgb(235, 235, 235)), 2);
      editor.TextArea.SelectionBorder = null;
    }
  }
}
