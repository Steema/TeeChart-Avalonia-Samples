using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using TeeChart.Xaml.Avalonia.Series;

namespace XamlAvaloniaDemo.Demos
{
  public class BindingDataPropertiesViewModel : ObservableRecipient
  {
    private const int Height = 20;
    private const int Amount = 100;

    private double _offset;

    private readonly DispatcherTimer _timer;

    public Series3DData[] Data { get; }

    public BindingDataPropertiesViewModel()
    {
      Data = new Series3DData[Amount];

      int i = 0;
      for (int x = 0; x < 10; x++)
      {
        for (int z = 0; z < 10; z++)
        {
          Data[i] = new Series3DData { X = x, Y = Math.Sin(i / (double)Amount * Math.PI * 2) * Height, Z = z };
          i++;
        }
      }

      _timer = new DispatcherTimer(DispatcherPriority.Normal) { Interval = TimeSpan.FromSeconds(0.05) };
      _timer.Tick += OnTick;
      _timer.Start();
    }

    private void OnTick(object sender, EventArgs eventArgs)
    {
      _offset += 2;
      for (var i = 0; i < Amount; i++)
      {
        Data[i].Y = Math.Sin((i + _offset) / Amount * Math.PI * 2) * Height;
      }
    }

    protected override void OnDeactivated()
    {
      base.OnDeactivated();


      _timer.Stop();
      _timer.Tick -= OnTick;
    }
  }
}
