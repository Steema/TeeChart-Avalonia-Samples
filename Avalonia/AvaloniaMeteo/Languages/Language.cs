using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.IO;
using System.Collections.Generic;

namespace AvaloniaMeteo.Languages
{
    public static class Language
    {
        public static Dictionary<string, string> info = new Dictionary<string, string>();

        private static void Load(string file)
        {
            info.Clear();

            foreach (string line in File.ReadLines($"..\\..\\..\\Languages\\{file}"))
            {
                if (line.Contains("="))
                {
                    string[] camps = line.Split('=');
                    info[camps[0].Trim()] = camps[1].Trim();
                }
            }
        }

        public static void ChangeLenguage(string file)
        {
            //AvaloniaMeteo.Properties.Settings config = new AvaloniaTextText.Properties.Settings();
            //config.lang = file;
            //config.Save();
            Load(file);

            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = desktop.MainWindow as MainWindow;
                if (mainWindow == null)
                    return;

                if (mainWindow.lblSearch != null)
                    mainWindow.lblSearch.Text = Language.info.ContainsKey("lblSearch") ? Language.info["lblSearch"] : "The weather in... ";

                mainWindow.UpdateChartLanguage();

                if (mainWindow.btnDays != null)
                    mainWindow.btnDays.Content = Language.info.ContainsKey("btnDays") ? Language.info["btnDays"] : "Days";

                if (mainWindow.btnHours != null)
                    mainWindow.btnHours.Content = Language.info.ContainsKey("btnHours") ? Language.info["btnHours"] : "Hours";

                if (mainWindow.txtRecentCities != null)
                    mainWindow.txtRecentCities.Text = Language.info.ContainsKey("txtRecentCities") ? Language.info["txtRecentCities"] : "📍Recent Cities";

                if (mainWindow.txtInformation != null)
                    mainWindow.txtInformation.Text = Language.info.ContainsKey("txtInformation") ? Language.info["txtInformation"] : "ℹ️ Information";

                if (mainWindow.txtBlockInformation != null)
                    mainWindow.txtBlockInformation.Text = Language.info.ContainsKey("txtBlockInformation") ? Language.info["txtBlockInformation"] : "Type the name of a city to get its weather forecast.\r\nYou can change the language from the top menu.\r\nSee recent cities in the side list.";

                if (mainWindow.tabTemperatureAndHumidity != null)
                    mainWindow.tabTemperatureAndHumidity.Header = Language.info.ContainsKey("tabTemperatureAndHumidity") ? Language.info["tabTemperatureAndHumidity"] : "Temperature/Humidity";

                if (mainWindow.tabTemperature != null)
                    mainWindow.tabTemperature.Header = Language.info.ContainsKey("tabTemperature") ? Language.info["tabTemperature"] : "Temperature";

                mainWindow.UpdateAnnotations();

                mainWindow.ConfigureAxes();

                mainWindow.UpdateAndLoadForecastDays();

                if (mainWindow.btnDayActivate)
                {
                    if (mainWindow.ChartTemp == null) return;

                    mainWindow.GetAllTemperaturesByDays(mainWindow.currentCity);
                }


            }
        }
    }
}
