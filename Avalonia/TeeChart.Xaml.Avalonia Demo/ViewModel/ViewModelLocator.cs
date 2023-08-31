using System;
using Microsoft.Extensions.DependencyInjection;
using XamlAvaloniaDemo.Demos;


namespace XamlAvaloniaDemo.ViewModel
{
  public class ViewModelLocator
  {
    public MainViewModel Main => _serviceLocator.GetService<MainViewModel>();

    public BindingObservableCollectionViewModel BindingObservableCollectionViewModel
      => _serviceLocator.GetService<BindingObservableCollectionViewModel>();

    public BindingDataPropertiesViewModel BindingDataPropertiesViewModel
      => _serviceLocator.GetService<BindingDataPropertiesViewModel>();

    private IServiceProvider _serviceLocator;

    public ViewModelLocator()
    {
      _serviceLocator = RegisterViewModels();
    }

    private static IServiceProvider RegisterViewModels()
    {
      var services = new ServiceCollection();

      services.AddSingleton<MainViewModel>();
      services.AddSingleton<BindingObservableCollectionViewModel>();
      services.AddSingleton<BindingDataPropertiesViewModel>();
      return services.BuildServiceProvider();
    }

    //public static void Cleanup()
    //{
    //  CleanupViewModel(typeof(BindingObservableCollectionViewModel));
    //  CleanupViewModel(typeof(BindingDataPropertiesViewModel));
    //  //Ioc.Default.Reset();
    //  RegisterViewModels();
    //}

    private static void CleanupViewModel(Type type)
    {
      //foreach (var vm in Ioc.Default.GetAllCreatedInstances(type).Cast<ViewModelBase>())
      //{
      //  vm.Cleanup();
      //}
    }
  }
}
