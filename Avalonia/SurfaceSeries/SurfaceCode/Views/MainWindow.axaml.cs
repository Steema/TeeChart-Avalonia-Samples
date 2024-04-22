using Avalonia.Controls;
using Steema.TeeChart.Avalonia;

namespace SurfaceCode.Views;

public partial class MainWindow : Window
{

    private Steema.TeeChart.Styles.Surface Surface1;
    private Steema.TeeChart.Styles.Surface Surface2;

    public MainWindow()
    {
        InitializeComponent();
        modifychart();
    }

    public void modifychart()
    {
        chart1.Aspect.View3D = true;
        chart1.Aspect.Chart3DPercent = 40;
        chart1.Aspect.Orthogonal = false;
        chart1.Aspect.Zoom = 80;

        chart1.Panning.Active = false;
        chart1.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;

        //chart1.Header.Font.Size = 16;
        //chart1.Header.Text = "Surface Example";
        chart1.Header.Visible = false;

        chart1.Axes.Left.SetMinMax(-1.5, 1.5);
        chart1.Axes.Depth.Visible = true;

        chart1.Walls.Visible = false;
        chart1.Legend.Visible = false;

        Surface1 = new Steema.TeeChart.Styles.Surface(chart1.Chart)
        {
            Title = "Surface 1",
        };

        Surface2 = new Steema.TeeChart.Styles.Surface(chart1.Chart)
        {
            Title = "Surface 2",
            PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Rainbow,
            UseColorRange = false,
            UsePalette = true,
        };

        Surface1.Transparency = 50;
        Surface1.FillSampleValues();

        Surface2.Transparency = 55;
        Surface2.FillSampleValues();

        for (int i = 0; i < Surface2.YValues.Count; i++)
        {
            Surface2.YValues.Value[i] = Surface2.YValues.Value[i] - 0.6;
        }

        Steema.TeeChart.Tools.Rotate rotate = new Steema.TeeChart.Tools.Rotate(chart1.Chart);

    }
}
