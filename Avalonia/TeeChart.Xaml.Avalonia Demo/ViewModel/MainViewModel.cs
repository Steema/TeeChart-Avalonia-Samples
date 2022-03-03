using System;
using System.Linq;
using Avalonia.Controls;
using GalaSoft.MvvmLight;
using XamlAvaloniaDemo.Demos;

namespace XamlAvaloniaDemo.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    public Demo? SelectedDemo
    {
      get { return _selectedDemo; }
      set
      {
        if (Set(() => SelectedDemo, ref _selectedDemo, value))
        {
          UpdateDemo();
        }
      }
    }

    private Demo? _selectedDemo;

    public UserControl DemoControl
    {
      get { return _demoControl; }
      set { Set(() => DemoControl, ref _demoControl, value); }
    }

    private UserControl _demoControl;

    public Demo[] Demos { get; }

    public string File
    {
      get { return _file; }
      set { Set(() => File, ref _file, value); }
    }

    private string _file;

    public bool FileSelectVisible
    {
      get { return _fileSelectVisible; }
      set { Set(() => FileSelectVisible, ref _fileSelectVisible, value); }
    }

    private bool _fileSelectVisible;

    public MainViewModel()
    {
      Demos = new[]
      {
        new Demo
        {
          Name = "Manual Values",
          Files = new[] {"ManualValues.axaml"},
          Type = typeof(ManualValues)
        },
        new Demo
        {
          Name = "Manual Values: X and Y",
          Files = new[] {"ManualValuesXAndY.axaml"},
          Type = typeof(ManualValuesXAndY)
        },
        new Demo
        {
          Name = "Manual Values: Colors",
          Files = new[] {"ManualValuesColors.axaml"},
          Type = typeof(ManualValuesColors)
        },
        new Demo
        {
          Name = "Manual Values: Labels",
          Files = new[] {"ManualValuesLabels.axaml"},
          Type = typeof(ManualValuesLabels)
        },
        new Demo
        {
          Name = "Binding Observable Collection",
          Files = new[] {"BindingObservableCollection.axaml", "BindingObservableCollectionViewModel.cs"},
          Type = typeof(BindingObservableCollection)
        },
        new Demo
        {
          Name = "Binding Data Properties",
          Files = new[] {"BindingDataProperties.axaml", "BindingDataPropertiesViewModel.cs"},
          Type = typeof(BindingDataProperties)
        },
        new Demo
        {
          Name = "Sample Values",
          Files = new[] {"SampleValues.axaml"},
          Type = typeof(SampleValues)
        },
        new Demo
        {
          Name = "Sample Values Binding",
          Files = new[] {"SampleValuesBinding.axaml"},
          Type = typeof(SampleValuesBinding)
        }
      };

      SelectedDemo = Demos.FirstOrDefault();
    }

    private void UpdateDemo()
    {
      ViewModelLocator.Cleanup();
      if (!SelectedDemo.HasValue) return;

      File = SelectedDemo.Value.Files.FirstOrDefault();
      FileSelectVisible = SelectedDemo.Value.Files.Length > 1;
      DemoControl = (UserControl)Activator.CreateInstance(SelectedDemo.Value.Type);
    }

    public struct Demo
    {
      public string Name;
      public string[] Files { get; set; }
      public Type Type;

      public override string ToString()
      {
        return Name;
      }
    }
  }
}
