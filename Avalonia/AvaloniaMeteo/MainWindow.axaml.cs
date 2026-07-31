using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Input;
using Avalonia.Threading;
using Avalonia.Interactivity;
using AvaloniaMeteo.MODELS;
using MsBox.Avalonia;
using Steema.TeeChart;
using Steema.TeeChart.Avalonia.Drawing;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using AvaloniaMeteo.Controllers;
using AvaloniaMeteo.Languages;
using Color = System.Drawing.Color;

namespace AvaloniaMeteo
{
  public partial class MainWindow : Window
  {
    #region PRIVATE FIELDS
    private WeatherController weatherController;
    private WeatherResponse currentTemperature;
    private Forecast allTemperatures;

    // Dictionaries
    private Dictionary<DateTime, string> daysWithDates = new Dictionary<DateTime, string>();
    private Dictionary<double, string> hoursWithDates = new Dictionary<double, string>();
    private Dictionary<string, List<string>> iconsForDay = new Dictionary<string, List<string>>();
    private Dictionary<string, Bitmap> imageCacheAvalonia = new();
    private Dictionary<string, Tuple<double, double>> rankDays = new Dictionary<string, Tuple<double, double>>();

    // Chart Tools
    NearestPoint toolNPTemp = null;
    NearestPoint toolNPHumidity = null;
    Annotation annotation;
    Axis vertAxis, horizAxis;

    // Lists
    List<string> lstIconUrls = new List<string>();
    private List<double> verticalLinePositions = new List<double>();
    private List<string> recentCities = new List<string>();
    private const int MAX_RECENT_CITIES = 10;

    // Variables
    bool eventAdded = false;
    public bool btnDayActivate = true;
    public string currentCity;
    private bool isUpdatingComboBox = false;

    //SuggestionCities
    private System.Timers.Timer searchTimer;
    private List<MODELS.Location> currentSuggestions = new List<MODELS.Location>();
    private bool isSelectingSuggestion = false;
    #endregion


    public MainWindow()
    {
      InitializeComponent();
      //txtBlockInformation.FontSize = 16; txtBlockInformation.Foreground = Avalonia.Media.Brushes.Black;
      InitializeSearchTimer();

      #region RECENT CITIES
      LoadRecentCities();
      UpdateRecentCitiesList();

      #endregion

      //recentCities.Clear();
      //lstCities.Items.Clear();
      //SaveRecentCities();


      weatherController = new WeatherController();
      currentTemperature = new WeatherResponse();
      //Language.ChangeLenguage(Properties.Settings.Default.lang);
      cmbDays.IsVisible = false;
      scrollBarChart.IsVisible = false;

      ChartTemp.Zoom.Allow = false;
      ChartTempAndHumidity.Zoom.Allow = false;

      ChartTemp.Panning.Allow = ScrollModes.None;
      ChartTempAndHumidity.Panning.Allow = ScrollModes.None;

      #region CONFIGURACION ESTILO DEL CHART
      ChartTemp.Panel.Gradient.Visible = true;
      ChartTemp.Panel.Gradient.StartColor = Color.FromArgb(255, 255, 255);
      ChartTemp.Panel.Gradient.EndColor = Color.FromArgb(250, 252, 255);
      ChartTemp.Panel.Gradient.Direction = LinearGradientMode.Vertical;

      ChartTemp.Axes.Bottom.Grid.Visible = false;
      ChartTemp.Axes.Bottom.Labels.Font.Size = 8;
      ChartTemp.Axes.Bottom.Labels.Font.Bold = true;
      ChartTemp.Axes.Bottom.Labels.Font.Color = Color.FromArgb(80, 102, 120);
      #endregion

      #region CONFIGURACION DEL TITULO DEL CHART
      ChartTemp.Header.Font.Size = 14;
      ChartTemp.Header.Font.Bold = true;
      ChartTemp.Header.Font.Color = Color.FromArgb(80, 102, 120);
      ChartTemp.Header.Font.Name = "Segoe UI";
      ChartTemp.Header.Alignment = (StringAlignment)TextAlignment.Right;
      ChartTemp.Header.Transparent = true;

      ChartTempAndHumidity.Header.Font.Size = 14;
      ChartTempAndHumidity.Header.Font.Bold = true;
      ChartTempAndHumidity.Header.Font.Color = Color.FromArgb(80, 102, 120);
      ChartTempAndHumidity.Header.Font.Name = "Segoe UI";
      ChartTempAndHumidity.Header.Alignment = (StringAlignment)TextAlignment.Right;
      ChartTempAndHumidity.Header.Transparent = true;

      #endregion

    }

    private void InitializeSearchTimer()
    {
      searchTimer = new System.Timers.Timer(500);
      searchTimer.Elapsed += async (s, e) => await SearchLocationsAsync();
      searchTimer.AutoReset = false;
    }

    private async Task SearchLocationsAsync()
    {
      await Dispatcher.UIThread.InvokeAsync(async () =>
      {
        try
        {
          string query = txtSearch.Text?.Trim();
          if (!string.IsNullOrEmpty(query) && query.Length >= 3)
          {
            var suggestions = await weatherController.GetLocationSuggestionsAsync(query);
            currentSuggestions = suggestions;

            var filtered = suggestions.Where(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();

            currentSuggestions = filtered;

            if (filtered.Any())
            {
              suggestionsList.ItemsSource = filtered;
              suggestionsList.SelectedIndex = 0;
              suggestionsPopup.IsOpen = true;
            }
            else
            {
              suggestionsPopup.IsOpen = false;
            }
          }
        }
        catch (Exception ex)
        {
          suggestionsPopup.IsOpen = false;
        }
      });
    }

    private void LoadRecentCities()
    {
      try
      {
        string savedCities = ""; // Properties.Settings.Default.RecentCities;
        if (!string.IsNullOrEmpty(savedCities))
        {
          recentCities = savedCities.Split('|').ToList();
          UpdateRecentCitiesList();
        }
      }
      catch (Exception ex)
      {
        recentCities = new List<string>();

      }
    }

    private void SaveRecentCities()
    {
      try
      {
        //Properties.Settings.Default.RecentCities = string.Join("|", recentCities);
        //Properties.Settings.Default.Save();
      }
      catch (Exception ex)
      {
      }
    }

    private void AddToRecentCities(string cityName)
    {
      if (string.IsNullOrWhiteSpace(cityName)) return;

      cityName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cityName.ToLower());

      recentCities.Remove(cityName);

      recentCities.Insert(0, cityName);

      if (recentCities.Count > MAX_RECENT_CITIES)
      {
        recentCities = recentCities.Take(MAX_RECENT_CITIES).ToList();
      }

      UpdateRecentCitiesList();
      SaveRecentCities();
    }

    private void UpdateRecentCitiesList()
    {
      lstCities.Items.Clear();

      foreach (string city in recentCities)
      {
        ListBoxItem item = new ListBoxItem
        {
          Content = city,
          Margin = new Thickness(5, 2, 5, 2),
          Padding = new Thickness(10, 5, 10, 5)
        };

        lstCities.Items.Add(item);
      }
    }


    #region UPDATE METHODS
    /// <summary>
    /// Updates the annotations on the chart, adding labels for each vertical line.
    /// </summary>
    public void UpdateAnnotations()
    {
      if (ChartTemp != null)
      {
        for (int i = ChartTemp.Tools.Count - 1; i >= 0; i--)
        {
          if (ChartTemp.Tools[i] is Annotation)
          {
            ChartTemp.Tools.RemoveAt(i);
          }
        }

        foreach (var verticalLineX in verticalLinePositions)
        {
          int pixelX = ChartTemp.Axes.Bottom.CalcXPosValue(verticalLineX);
          DateTime dateFrom = DateTime.FromOADate(verticalLineX);
          DateTime dateTo = dateFrom.AddDays(1);

          string day1 = daysWithDates.FirstOrDefault(d => d.Key.Date == dateFrom.Date).Value;
          string day2 = daysWithDates.FirstOrDefault(d => d.Key.Date == dateTo.Date).Value;

          day1 = day1?.Trim();
          day2 = day2?.Trim();

          if (day2 != null)
          {
            day1 = Language.info.ContainsKey(day1) ? Language.info[day1] : day1;
            day2 = Language.info.ContainsKey(day2) ? Language.info[day2] : day2;
          }

          Annotation annotationLeft = new Annotation(ChartTemp.Chart);
          annotationLeft.Text = day1;
          annotationLeft.Left = pixelX - 95 - 40;
          annotationLeft.Top = ChartTemp.Axes.Left.IStartPos + 10;
          annotationLeft.Shape.Transparent = true;
          ChartTemp.Tools.Add(annotationLeft);

          if (day2 != null)
          {
            Annotation annotationRight = new Annotation(ChartTemp.Chart);
            annotationRight.Text = day2;
            annotationRight.Left = pixelX + 24;
            annotationRight.Top = ChartTemp.Axes.Left.IStartPos + 10;
            annotationRight.Shape.Transparent = true;
            ChartTemp.Tools.Add(annotationRight);
          }
        }
      }
    }

    /// <summary>
    /// Adds the days of the week in a cmbBox and updates depending on the chosen language.
    /// </summary>
    public async void UpdateAndLoadForecastDays()
    {
      if (allTemperatures == null || allTemperatures.forecastday.Count < 3)
      {
        return;
      }

      isUpdatingComboBox = true;

      try
      {
        int selectedIndex = cmbDays.SelectedIndex;
        string selectedDay = (cmbDays.SelectedItem != null) ? cmbDays.SelectedItem.ToString() : "";

        cmbDays.Items.Clear();

        for (int i = 0; i < 3; i++)
        {
          DateTime date = DateTime.Parse(allTemperatures.forecastday[i].date);
          string dayOfTheWeek = date.ToString("dddd");

          if (Language.info.ContainsKey(dayOfTheWeek))
          {
            dayOfTheWeek = Language.info[dayOfTheWeek];
          }

          string dayFormatted = $"{dayOfTheWeek} ({date:dd/MM})";
          string dateKey = date.ToString("yyyy-MM-dd");

          daysWithDates[date] = dayOfTheWeek;
          cmbDays.Items.Add(dayFormatted);
        }

        // Restore previous selection if it still exists
        if (!string.IsNullOrEmpty(selectedDay) && cmbDays.Items.Contains(selectedDay))
        {
          cmbDays.SelectedItem = selectedDay;
        }
        else if (cmbDays.Items.Count > 0)
        {
          cmbDays.SelectedIndex = selectedIndex >= 0 && selectedIndex < cmbDays.Items.Count ? selectedIndex : 0;
        }

        await Task.Delay(150);
      }
      finally
      {
        isUpdatingComboBox = false;
      }
    }

    /// <summary>
    /// Updates the language of the chart headers and series titles in the `tChart2` chart.
    /// It translates the evolution of the day, temperature, and humidity texts based on the selected language.
    /// If translations are not available, it uses default values.
    /// </summary>
    public void UpdateChartLanguage()
    {
      if (ChartTempAndHumidity == null || allTemperatures == null || allTemperatures.forecastday.Count == 0)
        return;

      string headerTxt = Language.info.ContainsKey("Forecast_by_hour") ? Language.info["Forecast_by_hour"] : "PREVICIÓ PER HORES";
      ChartTemp.Header.Text = headerTxt;

      string evolutionText = Language.info.ContainsKey("EVOLUTION_OF_DAY") ? Language.info["EVOLUTION_OF_DAY"] : "EVOLUCIÓ DEL DIA";
      string tempHumText = Language.info.ContainsKey("TEMP_HUMIDITY") ? Language.info["TEMP_HUMIDITY"] : "Temperatura / Humitat relativa";

      ChartTempAndHumidity.Header.Text = $"{evolutionText}: {allTemperatures.forecastday[0].date}";
      ChartTempAndHumidity.SubHeader.Text = tempHumText;

      if (ChartTempAndHumidity.Series.Count >= 2)
      {

        string tempText = Language.info.ContainsKey("TemperatureTchart2") ? Language.info["TemperatureTchart2"] : "Temperature (ºC)";

        string humText = Language.info.ContainsKey("HumidityTchart2") ? Language.info["HumidityTchart2"] : "Humidity (%)";

        ChartTempAndHumidity.Series[0].Title = tempText;
        ChartTempAndHumidity.Series[1].Title = humText;
      }

      ChartTemp.UpdateLayout();

    }
    #endregion


    #region TEMPERATURE METHODS
    /// <summary>
    ///  Gets the current temperature of the specified city and updates the UI elements.
    /// </summary>
    /// <param name="city">The city for which to get the temperature</param>
    private async Task<bool> GetCurrentTemperatureAsync(string city)
    {
      currentTemperature = await weatherController.GetCurrentTemperatura(city);

      if (currentTemperature != null)
      {
        txtTemperature.Text = Math.Truncate(currentTemperature.Current.temp_c).ToString() + "ºC";
        txtCity.Text = currentTemperature.Location.Name;
        txtRegion.Text = $"{currentTemperature.Location.Region}, {currentTemperature.Location.Country}";
        string iconUrl = $"https:{currentTemperature.Current.condition.Icon}";
        imgWeatherIcon.Source = LoadBitmapFromUrl(iconUrl);
        return true;
      }
      else
      {
        txtTemperature.Text = "--°C";
        txtCity.Text = "City not found";
        txtRegion.Text = "";
        imgWeatherIcon.Source = null;
        return false;
      }
    }

    /// <summary>
    /// Retrieves the 7-day weather forecast for the specified city and displays it in a bar chart.
    /// </summary>
    /// <param name="city">The name of the city to fetch the weather forecast for</param>
    public async void GetAllTemperaturesByDays(string city)
    {
      Bar barSeries;
      btnDayActivate = true;
      currentCity = city;
      cmbDays.IsVisible = false;

      if (ChartTemp.Series.Count == 0)
      {
        barSeries = new Bar();

        ChartTemp.Series.Add(barSeries);
        ChartTemp.Legend.Visible = false;
        ChartTemp[0].Marks.Visible = false;
        ChartTemp.Axes.Left.Labels.Visible = false;
      }
      else
      {
        barSeries = (Bar)ChartTemp.Series[0];
      }

      scrollBarChart.IsVisible = false;
      barSeries.Clear();
      iconsForDay.Clear();
      daysWithDates.Clear();
      verticalLinePositions.Clear();

      #region CONFIGURACION BAR SERIES
      barSeries.ColorEach = false;
      barSeries.Color = Color.FromArgb(52, 152, 219);
      barSeries.Gradient.Visible = true;
      barSeries.Gradient.StartColor = Color.LightBlue;
      barSeries.Gradient.EndColor = Color.FromArgb(136, 193, 231);
      barSeries.Gradient.Direction = LinearGradientMode.ForwardDiagonal;
      barSeries.Transparency = 20;
      barSeries.BarWidthPercent = 60;
      barSeries.BarStyle = BarStyles.RectGradient;
      #endregion

      // Removes previous annotations
      for (int i = ChartTemp.Tools.Count - 1; i >= 0; i--)
      {
        if (ChartTemp.Tools[i] is Annotation)
        {
          ChartTemp.Tools.RemoveAt(i);
        }
      }

      if (city == null)
        return;

      allTemperatures = await weatherController.GetPrevisionBy10Days(city);

      if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
      {
        string headerTxt = Language.info.ContainsKey("FORECAST_7_DAYS") ? Language.info["FORECAST_7_DAYS"] : "FORECAST(7 DAYS)";
        ChartTemp.Header.Text = headerTxt;

        foreach (Forecastday day in allTemperatures.forecastday)
        {
          DateTime date = DateTime.Parse(day.date);
          string dayOfTheWeek = date.ToString("dddd");

          if (Language.info.ContainsKey(dayOfTheWeek))
            dayOfTheWeek = Language.info[dayOfTheWeek];

          string dateKey = date.ToString("yyyy-MM-dd");
          daysWithDates[date] = dayOfTheWeek;
          barSeries.Add(day.day.avgtemp_c, dayOfTheWeek);

          string iconUrl = $"https:{day.day.condition.Icon}";
          iconsForDay[dateKey] = new List<string> { iconUrl };
        }

        ChartTemp.Axes.Bottom.SetMinMax(0, 0);
        ChartTemp.Axes.Bottom.Automatic = true;
        ChartTemp.Invalidate();
        ChartTemp.UpdateLayout();
      }

    }


    /// <summary>
    /// Retrieves the hourly weather evolution for the specified city and displays it in a bar chart.
    /// </summary>
    /// <param name="city">The name of the city to fetch the weather evolution for.</param>
    public async void GetAllTemperatures(string city)
    {
      Bar barSeries;
      scrollBarChart.IsVisible = true;
      cmbDays.IsVisible = true;
      scrollBarChart.IsVisible = true;


      ChartTemp.Axes.Bottom.Labels.Separation = 90;

      //ChartTemp.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneHour);

      btnDayActivate = false;

      verticalLinePositions.Clear();

      if (ChartTemp.Series.Count == 0)
      {
        barSeries = new Bar();
        ChartTemp.Series.Add(barSeries);
        ChartTemp.Legend.Visible = false;
        ChartTemp.Series[0].Marks.Visible = false;
      }
      else
      {
        while (ChartTemp.Series.Count > 1)
        {
          ChartTemp.Series.RemoveAt(1);
        }

        barSeries = (Bar)ChartTemp.Series[0];
        barSeries.Clear();
      }

      ChartTemp.Axes.Left.Labels.Visible = false;

      #region CONFIGURACION BAR SERIES
      barSeries.ColorEach = false;
      barSeries.OffsetPercent = 0;
      barSeries.Color = Color.FromArgb(52, 152, 219);
      barSeries.Gradient.Visible = true;
      barSeries.Gradient.StartColor = Color.LightBlue;
      barSeries.Gradient.EndColor = Color.FromArgb(136, 193, 231);
      barSeries.Gradient.Direction = LinearGradientMode.ForwardDiagonal;
      barSeries.Transparency = 20;
      barSeries.Pen.Visible = true;
      barSeries.Pen.Width = 1;
      barSeries.BarWidthPercent = 80;
      barSeries.BarStyle = BarStyles.RectGradient;
      #endregion

      if (ChartTemp.Series.Count > 0)
      {
        ChartTemp.Series[0].Clear();
        iconsForDay.Clear();
        daysWithDates.Clear();
      }

      string headerTxt = Language.info.ContainsKey("Forecast_by_hour") ? Language.info["Forecast_by_hour"] : "FORECAST BY HOUR";
      ChartTemp.Header.Text = headerTxt;


      if (city == null)
        return;

      allTemperatures = await weatherController.GetEvolutionOfWeatherByCity(city);

      if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
      {
        double? firstBarX = null;
        DateTime? lastBarTime = null;
        double? lastBarX = null;
        double? firstBarXNextDay = null;

        foreach (Forecastday dia in allTemperatures.forecastday)
        {
          DateTime date = DateTime.Parse(dia.date);
          string dateKey = date.ToString("yyyy-MM-dd");
          daysWithDates[date] = date.ToString("dddd");

          List<string> tempIcons = new List<string>();
          firstBarX = null;

          foreach (var hora in dia.hour)
          {
            DateTime dateHour = DateTime.Parse(hora.time.ToString());

            if (dateHour < DateTime.Now)
              continue;
            double hourValue = dateHour.ToOADate();
            barSeries.Add(hourValue, hora.temp_c, dateHour.ToString("HH:mm"));
            hoursWithDates[hourValue] = dateKey;
            tempIcons.Add($"https:{hora.condition.Icon}");

            if (firstBarX == null)
              firstBarX = hourValue;

            lastBarTime = dateHour;
            lastBarX = hourValue;

            rankDays[dateKey] = new Tuple<double, double>(firstBarX ?? 0, lastBarX ?? 0);
          }

          if (tempIcons.Count > 0)
            iconsForDay[dateKey] = tempIcons;

          if (firstBarX != null)
            firstBarXNextDay = firstBarX;

          if (lastBarTime != null && firstBarXNextDay != null)
          {
            DateTime date23 = date.AddHours(23);
            DateTime date00 = date.AddDays(1).AddHours(0);

            double x23 = date23.ToOADate();
            double x00 = date00.ToOADate();

            double verticalLineX = (x23 + x00) / 2;
            verticalLinePositions.Add(verticalLineX);
          }

          ChartTemp.Page.MaxPointsPerPage = 11;
          ChartTemp.Page.Current = 1;
        }
        await Task.Delay(100);

        if (barSeries.Count > 0)
        {
          double minX = barSeries.MinXValue();
          double maxX = barSeries.MaxXValue();

          if (maxX - minX < 10)
          {
            maxX = minX + 10;
          }

          double visibleRange = (maxX - minX) / 20;

          scrollBarChart.Minimum = 0;
          scrollBarChart.Maximum = 990;
          scrollBarChart.Value = 0;
          scrollBarChart.LargeChange = 10;

          double initialMax = minX + visibleRange;
          ChartTemp.Axes.Bottom.SetMinMax(minX, initialMax);
        }
        else
        {
          MessageBoxManager.GetMessageBoxStandard("Error", "No data were found to display in the graph.");
        }

        UpdateAndLoadForecastDays();
        UpdateAnnotations();
        ChartTemp.Invalidate();
      }
    }


    /// <summary>
    /// Obtains and displays the evolution of the temperature and relative humidity of a city on a graph.
    /// </summary>
    /// <param name="city">The city for which you wish to obtain temperature and humidity data</param>
    public async void GetTemperatureAndHumidity(string city)
    {
      if (ChartTempAndHumidity?.Chart == null)
        return;

      SetupChartAppearance();

      ChartTempAndHumidity.Series.Clear();

      for (int i = ChartTempAndHumidity.Tools.Count - 1; i >= 0; i--)
      {
        if (ChartTempAndHumidity.Tools[i] is NearestPoint)
          ChartTempAndHumidity.Tools.RemoveAt(i);
      }

      toolNPHumidity = null;
      toolNPTemp = null;


      Line lineTemperature = CreateTemperatureSeries();
      Line lineHumidity = CreateHumiditySeries();

      Color tempColor = lineTemperature.Color;

      lineTemperature.Color = lineHumidity.Color;
      lineHumidity.Color = tempColor;

      ChartTempAndHumidity.Series.Add(lineTemperature);
      ChartTempAndHumidity.Series.Add(lineHumidity);

      if (toolNPHumidity == null)
      {
        toolNPHumidity = new NearestPoint(ChartTempAndHumidity.Chart)
        {
          Series = lineHumidity,
          Style = NearestPointStyles.Rectangle,
          Size = 5,
          Brush = { Color = lineHumidity.Color }
        };

        toolNPHumidity.Pen.Visible = true;
        toolNPHumidity.Pen.Color = Color.Black;
        toolNPHumidity.Pen.Width = 2;
        toolNPHumidity.DrawLine = false;
        toolNPHumidity.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
        ChartTempAndHumidity.Tools.Add(toolNPHumidity);

        toolNPHumidity.Change += ToolNPHumidity_Change;
      }
      if (toolNPTemp == null)
      {
        toolNPTemp = new NearestPoint(ChartTempAndHumidity.Chart)
        {
          Series = lineTemperature,
          Style = NearestPointStyles.Circle,
          Size = 5,
          Brush = { Color = lineTemperature.Color }

        };

        toolNPTemp.Pen.Visible = true;
        toolNPTemp.Pen.Color = Color.Black;
        toolNPTemp.Pen.Width = 2;
        toolNPTemp.DrawLine = false;
        toolNPTemp.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
        ChartTempAndHumidity.Tools.Add(toolNPTemp);
      }

      allTemperatures = await weatherController.GetEvolutionOfHumidityAndTemperatureByCity(city);

      ConfigureAnottation();

      if (allTemperatures != null)
      {
        foreach (Forecastday day in allTemperatures.forecastday)
        {
          string evolutionText = Language.info.ContainsKey("EVOLUTION_OF_DAY") ? Language.info["EVOLUTION_OF_DAY"] : "EVOLUTION OF THE DAY";
          string tempHumText = Language.info.ContainsKey("TEMP_HUMIDITY") ? Language.info["TEMP_HUMIDITY"] : "Temperatura / Humitat relativa";

          ChartTempAndHumidity.Header.Text = $"{evolutionText}: {allTemperatures.forecastday[0].date}";
          ChartTempAndHumidity.SubHeader.Text = tempHumText;

          foreach (var hour in day.hour)
          {
            DateTime dateHour = DateTime.Parse(hour.time.ToString());
            if (dateHour.Hour >= 0 && dateHour.Hour <= 9 && (dateHour.Minute == 0 || dateHour.Minute == 30))
            {
              double hourValue = dateHour.ToOADate();

              lineTemperature.XValues.DateTime = true;
              lineHumidity.XValues.DateTime = true;

              lineTemperature.Add(hourValue, hour.temp_c);
              lineHumidity.Add(hourValue, hour.humidity);

              string iconUrl = $"https:{hour.condition.Icon}";
              lstIconUrls.Add(iconUrl);
            }
          }
        }
      }

      ConfigureAxes();

      ChartTempAndHumidity.Axes.Bottom.SetMinMax(0, 0);
      ChartTempAndHumidity.Axes.Bottom.Automatic = true;
      ChartTempAndHumidity.Invalidate();
      ChartTempAndHumidity.UpdateLayout();
      ChartTempAndHumidity.Invalidate();
    }

    public void ConfigureAxes()
    {

      ChartTempAndHumidity.Axes.Bottom.Labels.Style = AxisLabelStyle.Value;
      ChartTempAndHumidity.Axes.Bottom.Labels.ValueFormat = "HH:mm";
      ChartTempAndHumidity.Axes.Bottom.Labels.DateTimeFormat = "HH:mm";
      ChartTempAndHumidity.Axes.Bottom.Labels.Font.Size = 9;
      ChartTempAndHumidity.Axes.Bottom.Labels.Font.Bold = true;
      ChartTempAndHumidity.Axes.Bottom.Labels.Angle = 45;
      ChartTempAndHumidity.Axes.Bottom.Title.Font.Size = 10;
      ChartTempAndHumidity.Axes.Bottom.Title.Font.Bold = true;
      ChartTempAndHumidity.Axes.Bottom.Grid.Color = Color.FromArgb(230, 230, 230);

      ChartTempAndHumidity.Axes.Bottom.Increment = 1.0 / 24.0;  // Increment by 1 hour

      ChartTempAndHumidity.Axes.Left.SetMinMax(0, 30);
      ChartTempAndHumidity.Axes.Left.Increment = 5;
      ChartTempAndHumidity.Axes.Left.Automatic = false;
      string tempText = Language.info.ContainsKey("TemperatureTchart2") ? Language.info["TemperatureTchart2"] : "Temperature (ºC)";
      ChartTempAndHumidity.Axes.Left.Title.Text = tempText;
      ChartTempAndHumidity.Axes.Left.Title.Font.Size = 10;
      ChartTempAndHumidity.Axes.Left.Title.Font.Bold = true;

      ChartTempAndHumidity.Axes.Right.SetMinMax(0, 100);
      ChartTempAndHumidity.Axes.Right.Increment = 50;
      ChartTempAndHumidity.Axes.Right.Automatic = false;
      string humText = Language.info.ContainsKey("HumidityTchart2") ? Language.info["HumidityTchart2"] : "Humidity (%)";
      ChartTempAndHumidity.Axes.Right.Title.Text = humText;
      ChartTempAndHumidity.Axes.Right.Title.Font.Size = 10;
      ChartTempAndHumidity.Axes.Right.Title.Font.Bold = true;


      ChartTempAndHumidity.Axes.Bottom.Labels.ExactDateTime = true;

      ChartTempAndHumidity.Axes.Bottom.Maximum = 10;

      ChartTempAndHumidity.Invalidate();
      ChartTempAndHumidity.UpdateLayout();
    }

    private void ConfigureAnottation()
    {
      annotation = new Annotation(ChartTempAndHumidity.Chart);

      annotation.Shape.Font.Size = 9;
      annotation.Shape.Font.Bold = false;
      annotation.Shape.Font.Name = "Segoe UI";
      annotation.Shape.Transparent = true;
      annotation.Shape.Shadow.Visible = true;
      annotation.Shape.Shadow.Transparency = 70;

      vertAxis = ChartTempAndHumidity.Axes.Left;
      horizAxis = ChartTempAndHumidity.Axes.Bottom;

      ChartTempAndHumidity.PointerMoved += ChartTempAndHumidity_MouseMove;
    }

    private Line CreateTemperatureSeries()
    {
      string titleTemp = Language.info.ContainsKey("TemperatureTchart2") ? Language.info["TemperatureTchart2"] : "Temperature (ºC)";
      Line lineTemperature = new Line(ChartTempAndHumidity.Chart)
      {
        Title = titleTemp,
        Smoothed = false,
        Stairs = false,
        VertAxis = VerticalAxis.Left
      };

      lineTemperature.Pointer.Visible = true;
      lineTemperature.Pointer.Style = PointerStyles.Circle;
      lineTemperature.Pointer.HorizSize = 6;
      lineTemperature.Pointer.VertSize = 6;
      lineTemperature.Pointer.Gradient.Visible = true;
      lineTemperature.Pointer.Brush.Gradient.StartColor = Color.White;
      lineTemperature.Pointer.Brush.Gradient.EndColor = Color.FromArgb(220, 53, 69);
      lineTemperature.Pointer.Brush.Gradient.Direction = LinearGradientMode.Vertical;

      lineTemperature.LinePen.Width = 3;
     // lineTemperature.LinePen.EndCap = (LineCap)System.Drawing.Drawing2D.LineCap.Round;

      // Add marks at the points
      lineTemperature.Marks.Visible = false;
      lineTemperature.Marks.Arrow.Visible = false;
      lineTemperature.Marks.Transparent = true;
      return lineTemperature;
    }

    private Line CreateHumiditySeries()
    {
      string titleHum = Language.info.ContainsKey("HumidityTchart2") ? Language.info["HumidityTchart2"] : "Humidity (%)";
      Line lineHumidity = new Line(ChartTempAndHumidity.Chart)
      {
        Title = titleHum,
        Smoothed = false,
        Stairs = false,
        VertAxis = VerticalAxis.Right
      };

      lineHumidity.Pointer.Visible = true;
      lineHumidity.Pointer.Style = PointerStyles.Rectangle;
      lineHumidity.Pointer.HorizSize = 6;
      lineHumidity.Pointer.VertSize = 6;
      lineHumidity.Pointer.Brush.Gradient.Visible = true;
      lineHumidity.Pointer.Brush.Gradient.StartColor = Color.White;
      lineHumidity.Pointer.Brush.Gradient.EndColor = Color.FromArgb(0, 123, 255);
      lineHumidity.Pointer.Brush.Gradient.Direction = (LinearGradientMode)GradientDirection.Radial;

      // Configure line appearance
      lineHumidity.LinePen.Width = 3;
      lineHumidity.LinePen.Style = Steema.TeeChart.Drawing.DashStyle.Dash;
  //    lineHumidity.LinePen.EndCap = (LineCap)System.Drawing.Drawing2D.LineCap.Round;

      lineHumidity.Marks.Visible = false;
      lineHumidity.Marks.Arrow.Visible = false;
      lineHumidity.Marks.Transparent = true;

      return lineHumidity;
    }

    private void SetupChartAppearance()
    {
      ChartTempAndHumidity.Legend.Alignment = LegendAlignments.Bottom;
      ChartTempAndHumidity.Legend.Font.Size = 10;
      ChartTempAndHumidity.Legend.Font.Bold = true;

      ChartTempAndHumidity.Panel.Gradient.Visible = true;
      ChartTempAndHumidity.Panel.Gradient.StartColor = Color.White;
      ChartTempAndHumidity.Panel.Gradient.EndColor = Color.FromArgb(245, 245, 245);
      ChartTempAndHumidity.Panel.Gradient.Direction = LinearGradientMode.Vertical;
      ChartTempAndHumidity.Panel.Bevel.Inner = BevelStyles.None;
      ChartTempAndHumidity.Panel.Bevel.Outer = BevelStyles.None;
      ChartTempAndHumidity.Panel.BorderRound = 10;

      ChartTempAndHumidity.SubHeader.Font.Size = 10;
      ChartTempAndHumidity.SubHeader.Font.Color = Color.FromArgb(100, 100, 100);

    }
    #endregion


    #region EVENT HANDLERS

    // Search button (executed when the search button is clicked)
    private async void btnSearch_Click_1(object sender, RoutedEventArgs e)
    {
      await SearchWeather();
    }

    // Button for displaying hourly temperatures (loads the 3-day graph but displays each day's temperature by hour)
    private void btnHours_Click(object sender, RoutedEventArgs e)
    {
      string city = txtSearch.Text.Trim();

      if (!eventAdded)
      {
        ChartTemp.AfterDraw += ChartTemp_AfterDraw1;
        eventAdded = true;
      }

      if (!string.IsNullOrEmpty(city))
      {
        GetCurrentTemperatureAsync(city);
        GetAllTemperatures(city);
        GetTemperatureAndHumidity(city);

        if (ChartTemp.Series.Count > 0 && ChartTemp.Series[0] is Bar barSeries)
        {
          barSeries.BarWidthPercent = 60;
          barSeries.BarStyle = BarStyles.RectGradient;
          ChartTemp.Invalidate();
        }
      }
    }

    // Button to display temperatures per day (loads the temperature graph for each day of the week)
    private void btnDays_Click(object sender, RoutedEventArgs e)
    {
      btnDayActivate = true;
      string city = txtSearch.Text.Trim();

      if (!string.IsNullOrEmpty(city))
      {
        GetAllTemperaturesByDays(city);
      }

      if (ChartTemp.Series.Count > 0 && ChartTemp.Series[0] is Bar barSeries)
      {
        barSeries.BarWidthPercent = 60;
        barSeries.BarStyle = BarStyles.RectGradient;
        ChartTemp.Invalidate();
      }
    }
    private async void txtSearch_KeyDown(object sender, Avalonia.Input.KeyEventArgs e)
    {
      if (e.Key == Key.Enter && !suggestionsPopup.IsOpen)
      {
        await SearchWeather();
      }


    }
    #endregion


    #region TChart DRAWING HANDLERS
    /// <summary>
    /// Draws vertical lines on the chart at specified X-axis positions after the chart is rendered.
    /// </summary>
    private void ChartTemp_AfterDraw1(object sender, IGraphics3D g)
    {
      int offsetX = 34;
      foreach (var verticalLineX in verticalLinePositions)
      {
        int pixelX = ChartTemp.Axes.Bottom.CalcXPosValue(verticalLineX);
        g.Line(pixelX, ChartTemp.Axes.Left.IStartPos, pixelX, ChartTemp.Axes.Left.IEndPos);
      }
    }

    /// <summary>
    ///  Draw the images on the graph for the temperatures per day, and also for the temperatures per hour.
    /// </summary>
    private void ChartTemp_AfterDraw(object sender, IGraphics3D g)
    {
      // Removes any previous clipping regions that may have been configured
      ChartTemp.Graphics3D.ClearClipRegions();

      // Creates a rectangle that respects the horizontal boundaries of the chart (X and Width)
      // but extends from the top of the screen (Y=0) to the bottom of the chart
      Rect openTopRect = new Rect(
                              ChartTemp.Chart.ChartRect.X,
                              0, ChartTemp.Chart.ChartRect.Width,
                              ChartTemp.Chart.ChartRect.Height +
                              ChartTemp.Chart.ChartRect.Y
      );

      // Set this rectangle as the clipping region.
      // Anything drawn outside this region will be clipped (not visible).
      ChartTemp.Graphics3D.ClipRectangle(openTopRect);

      foreach (Series s in ChartTemp.Series)
      {
        if (!(s is Bar)) continue;

        Dictionary<string, List<int>> dataGroups = new Dictionary<string, List<int>>();

        for (int i = 0; i < s.Count; i++)
        {
          string dateKey;

          // Case 1: Data represents hours (GetAllTemperatures)
          if (hoursWithDates.ContainsKey(s.XValues[i]))
          {
            dateKey = hoursWithDates[s.XValues[i]];
          }
          // Case 2: Data represents days (GetAllTemperaturesByDays)
          else if (daysWithDates.ContainsValue(s.Labels[i]))
          {
            dateKey = daysWithDates.FirstOrDefault(x => x.Value == s.Labels[i]).Key.ToString("yyyy-MM-dd");
          }
          else
          {
            continue;
          }

          if (!dataGroups.ContainsKey(dateKey))
            dataGroups[dateKey] = new List<int>();

          dataGroups[dateKey].Add(i);
        }

        foreach (var group in dataGroups)
        {
          int p = 0;
          string dateKey = group.Key;

          if (!iconsForDay.ContainsKey(dateKey) || iconsForDay[dateKey].Count == 0)
            continue;

          foreach (int index in group.Value)
          {
            Bitmap bitmap;
            if (s.Labels[index].Contains(":"))
            {
              int iconIndex = p % iconsForDay[dateKey].Count;
              bitmap = LoadBitmapFromUrl(iconsForDay[dateKey][iconIndex]);
            }
            else
            {
              bitmap = LoadBitmapFromUrl(iconsForDay[dateKey][0]);
            }

            var tChartImage = new TImage(bitmap);

            double dpiScale = RenderScaling;

            int iconWidth = (int)(bitmap.Size.Width * dpiScale);
            int iconHeight = (int)(bitmap.Size.Height * dpiScale);

            int xPos = (int)ChartTemp.Axes.Bottom.CalcPosValue(s.XValues[index]) - (iconWidth / 2);
            int yPos = (int)ChartTemp.Axes.Left.CalcPosValue(s.YValues[index]) - (iconHeight / 2);

            g.Draw(xPos, yPos, tChartImage);

            string txt = $"{s.YValues[index]}ºC";
            int textWidth = (int)(g.TextWidth(txt) / 2);
            int textYPos = yPos + iconHeight + 5;
            int textXPos = xPos + (iconWidth / 2) - textWidth;

            g.TextOut(textXPos, textYPos, txt);

            p++;
          }
        }
      }
      ChartTemp.Graphics3D.ClearClipRegions();
    }

    /// <summary>
    /// Downloads an image from a given URL and returns it as a BitmapImage for use in WPF.
    /// Utilizes a cache to avoid repeated downloads of the same image.
    /// </summary>
    /// <param name="url">The URL of the image to download.</param>
    /// <returns>A BitmapImage loaded from the specified URL.</returns>
    private Bitmap LoadBitmapFromUrl(string url)
    {
      if (imageCacheAvalonia.ContainsKey(url))
        return imageCacheAvalonia[url];

      using var client = new WebClient();
      byte[] data = client.DownloadData(url);
      using var ms = new MemoryStream(data);
      var bitmap = new Bitmap(ms);          // Avalonia Bitmap
      imageCacheAvalonia[url] = bitmap;
      return bitmap;
    }
    #endregion


    #region Language Menu Events
    private void catalanMenuItem_Click(object sender, RoutedEventArgs e)
    {
      UncheckAllLanguageMenuItems();
      catalanMenuItem.IsChecked = true;
      Languages.Language.ChangeLenguage("ca.txt");
    }

    private void spanishMenuItem_Click(object sender, RoutedEventArgs e)
    {
      UncheckAllLanguageMenuItems();
      spanishMenuItem.IsChecked = true;
      Languages.Language.ChangeLenguage("es.txt");
    }

    private void englishMenuItem_Click(object sender, RoutedEventArgs e)
    {
      UncheckAllLanguageMenuItems();
      englishMenuItem.IsChecked = true;
      Languages.Language.ChangeLenguage("en.txt");

    }

    private void UncheckAllLanguageMenuItems()
    {
      spanishMenuItem.IsChecked = false;
      catalanMenuItem.IsChecked = false;
      englishMenuItem.IsChecked = false;
    }
    #endregion


    #region Chart Interaction and Visualization
    private void ChartTempAndHumidity_MouseMove(object? sender, PointerEventArgs e)
    {
      Point position = e.GetPosition(ChartTempAndHumidity);

      double mouseX = position.X;
      double mouseY = position.Y;

      toolNPHumidity.Active = mouseX >= horizAxis.IStartPos && mouseX <= horizAxis.IEndPos &&
      mouseY >= vertAxis.IStartPos && mouseY <= vertAxis.IEndPos;

      toolNPTemp.Active = mouseX >= horizAxis.IStartPos && mouseX <= horizAxis.IEndPos &&
      mouseY >= vertAxis.IStartPos && mouseY <= vertAxis.IEndPos;

      // Activate annotation if at least one of the tools is active
      annotation.Active = toolNPHumidity.Active || toolNPTemp.Active;
    }

    private void ToolNPHumidity_Change(object? sender, EventArgs e)
    {
      Line graphLineTemperature = (Line)ChartTempAndHumidity.Series[0];
      Line graphLineHumidity = (Line)ChartTempAndHumidity.Series[1];

      string tempText = Language.info.ContainsKey("Temperature") ? Language.info["Temperature"] : "Temperature";
      string humText = Language.info.ContainsKey("Humidity") ? Language.info["Humidity"] : "Humidity";


      int indexTemp = toolNPTemp.Point;
      int indexHum = toolNPHumidity.Point;

      // Check if the points are valid
      if (indexTemp >= 0 && indexTemp < graphLineTemperature.Count &&
          indexHum >= 0 && indexHum < graphLineHumidity.Count)
      {
        annotation.Text = $" {tempText}: {graphLineTemperature.YValues[toolNPTemp.Point]}ºC \n " +
                      $"{humText}: {graphLineHumidity.YValues[toolNPHumidity.Point]}%";
      }
      else
      {
        annotation.Text = string.Empty;
      }

    }

    private async void lstCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

      if (lstCities.SelectedItem is ListBoxItem selectedItem)
      {
        txtSearch.Text = selectedItem.Content.ToString();
        txtSearch.Focus();
        txtSearch.CaretIndex = txtSearch.Text.Length;
      }

      string city = txtSearch.Text.Trim();

      if (!eventAdded)
      {
        ChartTemp.AfterDraw += ChartTemp_AfterDraw1;
        eventAdded = true;
      }

      if (!string.IsNullOrEmpty(city))
      {
        bool cityFound = await GetCurrentTemperatureAsync(city);

        if (cityFound)
        {
          GetAllTemperaturesByDays(city);
          GetTemperatureAndHumidity(city);
        }

      }
    }

    private void ChartTemp_Scroll(object sender, EventArgs e)
    {
      if (ChartTemp.Page.Current >= scrollBarChart.Minimum && ChartTemp.Page.Current <= scrollBarChart.Maximum)
        scrollBarChart.Value = ChartTemp.Page.Current - 1;
    }

    private void scrollBarChart_Scroll(object sender, Avalonia.Controls.Primitives.ScrollEventArgs e)
    {
      ChartTemp.Axes.Bottom.Automatic = false;

      if (ChartTemp.Series.Count == 0 || ChartTemp.Series[0].Count == 0)
        return;

      Bar barSeries = (Bar)ChartTemp.Series[0];
      double minX = barSeries.MinXValue();
      double maxX = barSeries.MaxXValue();
      double visibleRange = (maxX - minX) / 7;

      double newMin = minX + e.NewValue * (maxX - minX - visibleRange) / scrollBarChart.Maximum;
      double newMax = newMin + visibleRange;

      if (newMax > maxX)
      {
        newMax = maxX;
        newMin = newMax - visibleRange;
      }

      if (newMin < minX)
      {
        newMin = minX;
        newMax = newMin + visibleRange;
      }

      ChartTemp.Axes.Bottom.SetMinMax(newMin, newMax);
      UpdateAnnotations();

      isUpdatingComboBox = true;

      try
      {
        foreach (var kvp in rankDays)
        {
          double minDay = kvp.Value.Item1;
          double maxDay = kvp.Value.Item2;

          if ((newMin >= minDay && newMin <= maxDay) ||
              (newMax >= minDay && newMax <= maxDay) ||
              (newMin <= minDay && newMax >= maxDay))
          {
            DateTime dateKey = DateTime.Parse(kvp.Key);
            string formattedDay = daysWithDates.ContainsKey(dateKey) ? daysWithDates[dateKey] : dateKey.ToString("dddd");

            string fullDayText = null;
            foreach (var item in cmbDays.Items)
            {
              if (item.ToString().StartsWith(formattedDay))
              {
                fullDayText = item.ToString();
                break;
              }
            }

            if (fullDayText != null)
            {
              int index = cmbDays.Items.IndexOf(fullDayText);
              if (index != -1 && index >= 0 && index < cmbDays.Items.Count && cmbDays.SelectedIndex != index)
              {
                cmbDays.SelectedIndex = index;
              }
            }
            break;
          }
        }
      }
      finally
      {
        isUpdatingComboBox = false;
      }
    }

    private void ChartTemp_BeforeDrawSeries(object sender, IGraphics3D g)
    {
      if (ChartTemp?.Series == null || ChartTemp.Series.Count == 0)
        return;

      var series0 = ChartTemp.Series[0];
      var barSeries = series0 as Bar;
      if (barSeries != null)
      {
        if ((barSeries.LastVisibleIndex - barSeries.FirstVisibleIndex) > 10)
          barSeries.CustomBarWidth = 45;
        else
          barSeries.CustomBarWidth = 0;
      }
    }


    private void BtnVisitWebsite_Click(object sender, RoutedEventArgs e)
    {
      ProcessStartInfo psi = new ProcessStartInfo
      {
        FileName = "https://www.weatherapi.com/",
        UseShellExecute = true
      };

      Process.Start(psi);
    }

    private void suggestionsList_PointerReleased(object sender, PointerReleasedEventArgs e)
    {
      if (suggestionsList.SelectedItem is MODELS.Location selected)
      {
        SelectSuggestion(selected);
      }
    }

    private void SelectSuggestion(MODELS.Location suggestion)
    {
      isSelectingSuggestion = true;
      txtSearch.Text = suggestion.DisplayName;
      txtSearch.Tag = suggestion;
      suggestionsPopup.IsOpen = false;
      isSelectingSuggestion = false;

      txtSearch.CaretIndex = txtSearch.Text.Length;
    }

    private void txtSearch_PreviewKeyDown(object sender, Avalonia.Input.KeyEventArgs e)
    {
      if (!suggestionsPopup.IsOpen || suggestionsList.ItemCount == 0)
        return;

      switch (e.Key)
      {
        case Key.Down:
          suggestionsList.SelectedIndex =
              (suggestionsList.SelectedIndex + 1) % suggestionsList.ItemCount;
          e.Handled = true;
          break;

        case Key.Up:
          suggestionsList.SelectedIndex =
              suggestionsList.SelectedIndex <= 0
              ? suggestionsList.ItemCount - 1
              : suggestionsList.SelectedIndex - 1;

          e.Handled = true;
          break;

        case Key.Enter:
          if (suggestionsList.SelectedItem is MODELS.Location selected)
            SelectSuggestion(selected);

          e.Handled = true;
          break;

        case Key.Escape:
          suggestionsPopup.IsOpen = false;
          e.Handled = true;
          break;
      }
    }

    private async Task SearchWeather()
    {
      MODELS.Location selectedLocation = txtSearch.Tag as MODELS.Location;
      string searchQuery;
      string displayName;

      if (selectedLocation != null)
      {
        searchQuery = selectedLocation.SearchQuery;
        displayName = selectedLocation.DisplayName;
      }
      else
      {
        searchQuery = txtSearch.Text?.Trim();
        displayName = searchQuery;
      }

      if (!string.IsNullOrEmpty(searchQuery))
      {
        try
        {
          bool cityFound = await GetCurrentTemperatureAsync(searchQuery);
          if (cityFound)
          {
            // Sanitize display name before saving recent cities
            if (!string.IsNullOrWhiteSpace(displayName) && displayName.Trim(',', ' ').Length > 0)
              AddToRecentCities(displayName);
            GetAllTemperaturesByDays(searchQuery);
            GetTemperatureAndHumidity(searchQuery);
          }
          else
          {
            MessageBoxManager.GetMessageBoxStandard("City not found", "The specified city was not found.").ShowWindowDialogAsync(this);
          }
        }
        catch (Exception ex)
        {
          MessageBoxManager.GetMessageBoxStandard("Error", $"Error when searching for the weather: {ex.Message}").ShowWindowDialogAsync(this);
        }
      }
    }

    private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
    {
      Task.Delay(150).ContinueWith(_ =>
      {
        Dispatcher.UIThread.Invoke(() => suggestionsPopup.IsOpen = false);
      });
    }

    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (isSelectingSuggestion)
        return;

      // Limpiar la ciudad seleccionada al editar manualmente
      txtSearch.Tag = null;

      string query = txtSearch.Text?.Trim();

      searchTimer?.Stop();

      if (string.IsNullOrWhiteSpace(query) || query.Length < 3)
      {
        currentSuggestions.Clear();

        suggestionsList.ItemsSource = null;
        suggestionsList.SelectedIndex = -1;

        suggestionsPopup.IsOpen = false;
        return;
      }

      searchTimer?.Start();
    }

    private void cmbDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      try
      {
        if (!isUpdatingComboBox &&
            cmbDays.SelectedItem != null &&
            cmbDays.SelectedIndex >= 0)
        {
          string selectedDay = cmbDays.SelectedItem.ToString();

          if (!string.IsNullOrWhiteSpace(selectedDay))
          {
            string fechaStr = selectedDay.Split('(')[1].Split(')')[0];

            if (DateTime.TryParseExact(fechaStr, "dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
              int currentYear = DateTime.Now.Year;
              DateTime fullDate = new DateTime(currentYear, parsedDate.Month, parsedDate.Day);
              string dateKey = fullDate.ToString("yyyy-MM-dd");

              if (rankDays.ContainsKey(dateKey))
              {
                double minX = rankDays[dateKey].Item1;
                double maxX = rankDays[dateKey].Item2;

                if (minX >= 0 && maxX > minX)
                {
                  ChartTemp.Axes.Bottom.SetMinMax(minX, maxX);

                  if (ChartTemp.Series.Count > 0 && ChartTemp.Series[0].Count > 0)
                  {
                    double globalMinX = ChartTemp.Series[0].MinXValue();
                    double globalMaxX = ChartTemp.Series[0].MaxXValue();
                    double totalRange = globalMaxX - globalMinX;

                    if (totalRange > 0)
                    {
                      double selectedRange = minX - globalMinX;
                      int sliderValue = (int)((selectedRange / totalRange) * scrollBarChart.Maximum);

                      if (sliderValue >= scrollBarChart.Minimum && sliderValue <= scrollBarChart.Maximum)
                      {
                        scrollBarChart.Value = sliderValue;
                      }
                    }
                  }

                  ChartTemp.UpdateLayout();
                  ChartTemp.Invalidate();
                  UpdateAnnotations();
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBoxManager.GetMessageBoxStandard("Error", "An error occurred while processing the selected day:\n" + ex.Message).ShowWindowDialogAsync(this);
      }
    }
    #endregion

  }
}