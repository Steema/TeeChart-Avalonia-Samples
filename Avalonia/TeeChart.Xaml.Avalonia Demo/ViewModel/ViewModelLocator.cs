using System;
using System.Linq;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using XamlAvaloniaDemo.Demos;

namespace XamlAvaloniaDemo.ViewModel
{
  public class ViewModelLocator
  {
    public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

    public BindingObservableCollectionViewModel BindingObservableCollectionViewModel
      => ServiceLocator.Current.GetInstance<BindingObservableCollectionViewModel>();

    public BindingDataPropertiesViewModel BindingDataPropertiesViewModel
      => ServiceLocator.Current.GetInstance<BindingDataPropertiesViewModel>();

    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      RegisterViewModels();
    }

    private static void RegisterViewModels()
    {
      SimpleIoc.Default.Register<MainViewModel>();
      SimpleIoc.Default.Register<BindingObservableCollectionViewModel>();
      SimpleIoc.Default.Register<BindingDataPropertiesViewModel>();
    }

    public static void Cleanup()
    {
      CleanupViewModel(typeof(BindingObservableCollectionViewModel));
      CleanupViewModel(typeof(BindingDataPropertiesViewModel));
      SimpleIoc.Default.Reset();
      RegisterViewModels();
    }

    private static void CleanupViewModel(Type type)
    {
      foreach (var vm in SimpleIoc.Default.GetAllCreatedInstances(type).Cast<ViewModelBase>())
      {
        vm.Cleanup();
      }
    }
  }
}
