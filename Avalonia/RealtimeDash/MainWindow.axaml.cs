using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using MsBox.Avalonia;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace RealtimeDash;

public partial class MainWindow : Window
{
    Annotation _annotation1;
    Line _lineSeries1;
    Line _lineSeries2;
    Stopwatch stopWatch;
    DispatcherTimer dispatcherTimer;
    string currentTime;

    public MainWindow()
    {
        InitializeComponent();

        stopWatch = Stopwatch.StartNew();
        stopWatch.Stop();

        StartStop.Click += StartStop_Click;

        Init();
        Config();
    }

    private DispatcherTimer getDispatcherTimer()
    {
        if (dispatcherTimer == null)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        return dispatcherTimer;
    }

    void dt_Tick(object sender, EventArgs e)
    {
        if (stopWatch.IsRunning)
        {
            TimeSpan ts = stopWatch.Elapsed;
            currentTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            DoTimerTick();
        }
    }

    public void SankeyTest()
    {
        tChart1.Panel.Color = System.Drawing.Color.Black;

        Sankey sankey = new Sankey();
        sankey.LinkCurvature = 0.7F;
        sankey.Highlighting = true;
        sankey.HighlightMode = HighlightMode.MouseEnter;
        sankey.HighlightBrush.Color = System.Drawing.Color.Olive;
        tChart1.Series.Add(sankey);
        sankey.FillSampleValues();
    }

    ActivityGauge aGauge;

    public void MakeActivityGauge()
    {
        tChart1.Chart.Panel.Color = System.Drawing.Color.AliceBlue;

        aGauge = new ActivityGauge(tChart1.Chart);
        aGauge.Pen.Width = 4;
        aGauge.Pen.Color = System.Drawing.Color.AliceBlue;

        aGauge.Marks.Visible = true;
        aGauge.MarksPie.InsideSlice = true;

        aGauge.Add(6);
        aGauge.Add(12);
        aGauge.Add(4);
    }

    public void MakeGraph()
    {
        _lineSeries1 = new Line();
        _lineSeries1.FillSampleValues(20);
        tChart1.Series.Add(_lineSeries1);

        _lineSeries2 = new Line();
        _lineSeries2.FillSampleValues(20);
        tChart1.Series.Add(_lineSeries2);

        Steema.TeeChart.Themes.AndrosTheme ath = new Steema.TeeChart.Themes.AndrosTheme(tChart1.Chart);
        ath.Apply();

        tChart1.Legend.ActiveStyle = LegendActiveStyles.CheckBox;


        _annotation1 = new Annotation
        {
            AutoSize = true,
            Position = AnnotationPositions.LeftBottom,
            Text = "Some text"
        };
        tChart1.Tools.Add(_annotation1);

        _annotation1.Click += Annotation1_Click;
    }

    void Annotation1_Click(object sender, MouseEventArgs e)
    {
        MessageBoxManager.GetMessageBoxStandard(_annotation1.Text, "Clicked").ShowWindowDialogAsync(this);
    }


    private CircularGauge circularGauge1;
    private Donut donut1;
    private Donut donut2;
    private Donut donut3;
    private Donut donut4;
    private Surface surface;
    private Rotate rotate1;
    private Area area1;
    private Line line1;
    private Line line2;
    private Axis axis1;
    private Axis axis2;
    private Bar3D bar3D1;
    private CursorTool cursorTool1;
    private HighLow highLow1;
    private Axis axis3;
    private Line line3;
    private Steema.TeeChart.Functions.StdDeviation stdDeviation1;
    private Axis axis4;
    private Line line4;
    private Steema.TeeChart.Functions.StdDeviation stdDeviation2;
    private ColorBand colorBand1;
    private ColorBand colorBand2;
    private Annotation annotation1;
    private Annotation annotation2;
    private Steema.TeeChart.Functions.RootMeanSquare rootMeanSquare1;

    public void Init()
    {
        axis3 = new Axis();
        axis4 = new Axis();
        highLow1 = new HighLow();
        line3 = new Line();
        stdDeviation2 = new Steema.TeeChart.Functions.StdDeviation();
        line4 = new Line();
        rootMeanSquare1 = new Steema.TeeChart.Functions.RootMeanSquare();
        colorBand1 = new ColorBand();
        colorBand2 = new ColorBand();
        annotation1 = new Annotation();
        annotation2 = new Annotation();
        axis1 = new Axis();
        axis2 = new Axis();
        area1 = new Area();
        line1 = new Line();
        line2 = new Line();
        bar3D1 = new Bar3D();
        cursorTool1 = new CursorTool();
        surface = new Surface();
        rotate1 = new Rotate();
        stdDeviation1 = new Steema.TeeChart.Functions.StdDeviation();
        circularGauge1 = new CircularGauge();
        donut4 = new Donut();
        donut3 = new Donut();
        donut2 = new Donut();
        donut1 = new Donut();

        // tChart6
        tChart6.Aspect.ColorPaletteIndex = -1;
        tChart6.Aspect.Elevation = 315;
        tChart6.Aspect.ElevationFloat = 315D;
        tChart6.Aspect.Orthogonal = false;
        tChart6.Aspect.Perspective = 0;
        tChart6.Aspect.Rotation = 360;
        tChart6.Aspect.RotationFloat = 360D;
        // 
        // 
        tChart6.Axes.Automatic = false;
        // 
        // 
        tChart6.Axes.Bottom.Automatic = false;
        tChart6.Axes.Bottom.AutomaticMaximum = false;
        tChart6.Axes.Bottom.AutomaticMinimum = false;
        // 
        // 
        tChart6.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.Bottom.Labels.Brush.Solid = true;
        tChart6.Axes.Bottom.Labels.Brush.Visible = true;
        tChart6.Axes.Bottom.Labels.DateTimeFormat = "hh:mm:ss";
        // 
        // 
        tChart6.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        tChart6.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart6.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Bottom.Labels.Font.Size = 8;
        tChart6.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.Bottom.Maximum = 0D;
        tChart6.Axes.Bottom.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.Bottom.Title.Brush.Solid = true;
        tChart6.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart6.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Bottom.Title.Font.Size = 8;
        tChart6.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart6.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        tChart6.Axes.Custom.Add(axis3);
        tChart6.Axes.Custom.Add(axis4);
        // 
        // 
        // 
        tChart6.Axes.Depth.Automatic = false;
        tChart6.Axes.Depth.AutomaticMaximum = false;
        tChart6.Axes.Depth.AutomaticMinimum = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.Depth.Labels.Brush.Solid = true;
        tChart6.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart6.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Depth.Labels.Font.Size = 8;
        tChart6.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.Depth.Maximum = 0D;
        tChart6.Axes.Depth.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.Depth.Title.Brush.Solid = true;
        tChart6.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart6.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Depth.Title.Font.Size = 8;
        tChart6.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart6.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Automatic = false;
        tChart6.Axes.DepthTop.AutomaticMaximum = false;
        tChart6.Axes.DepthTop.AutomaticMinimum = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart6.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart6.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.DepthTop.Labels.Font.Size = 8;
        tChart6.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.DepthTop.Maximum = 0D;
        tChart6.Axes.DepthTop.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.DepthTop.Title.Brush.Solid = true;
        tChart6.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart6.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.DepthTop.Title.Font.Size = 8;
        tChart6.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart6.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Left.Automatic = false;
        tChart6.Axes.Left.AutomaticMaximum = false;
        tChart6.Axes.Left.AutomaticMinimum = false;
        tChart6.Axes.Left.EndPosition = 38D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.Left.Labels.Brush.Solid = true;
        tChart6.Axes.Left.Labels.Brush.Visible = true;
        tChart6.Axes.Left.Labels.CustomSize = 44;
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart6.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Left.Labels.Font.Size = 8;
        tChart6.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.Left.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.Left.Maximum = 1010D;
        tChart6.Axes.Left.Minimum = 780D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.Left.Title.Brush.Solid = true;
        tChart6.Axes.Left.Title.Brush.Visible = true;
        tChart6.Axes.Left.Title.Caption = "Range";
        // 
        // 
        // 
        tChart6.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        tChart6.Axes.Left.Title.Font.Brush.Solid = true;
        tChart6.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Left.Title.Font.Size = 8;
        tChart6.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart6.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        tChart6.Axes.Left.Title.Lines = new string[]
    {
    "Range"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Right.Automatic = false;
        tChart6.Axes.Right.AutomaticMaximum = false;
        tChart6.Axes.Right.AutomaticMinimum = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.Right.Labels.Brush.Solid = true;
        tChart6.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart6.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Right.Labels.Font.Size = 8;
        tChart6.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.Right.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.Right.Maximum = 0D;
        tChart6.Axes.Right.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.Right.Title.Brush.Solid = true;
        tChart6.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Axes.Right.Title.Font.Brush.Solid = true;
        tChart6.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Right.Title.Font.Size = 8;
        tChart6.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart6.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Top.Automatic = false;
        tChart6.Axes.Top.AutomaticMaximum = false;
        tChart6.Axes.Top.AutomaticMinimum = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart6.Axes.Top.Labels.Brush.Solid = true;
        tChart6.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart6.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Top.Labels.Font.Size = 8;
        tChart6.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart6.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart6.Axes.Top.Labels.Shadow.Brush.Visible = true;
        tChart6.Axes.Top.Maximum = 0D;
        tChart6.Axes.Top.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Axes.Top.Title.Brush.Solid = true;
        tChart6.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Axes.Top.Title.Font.Brush.Solid = true;
        tChart6.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Axes.Top.Title.Font.Size = 8;
        tChart6.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart6.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart6.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart6.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart6.Footer.Brush.Solid = true;
        tChart6.Footer.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Footer.Font.Brush.Color = System.Drawing.Color.Red;
        tChart6.Footer.Font.Brush.Solid = true;
        tChart6.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Footer.Font.Shadow.Brush.Solid = true;
        tChart6.Footer.Font.Shadow.Brush.Visible = true;
        tChart6.Footer.Font.Size = 8;
        tChart6.Footer.Font.SizeFloat = 8F;
        tChart6.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Footer.ImageBevel.Brush.Solid = true;
        tChart6.Footer.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Footer.Shadow.Brush.Solid = true;
        tChart6.Footer.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart6.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Header.Brush.Gradient.SigmaScale = 0F;
        tChart6.Header.Brush.Solid = true;
        tChart6.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Header.Font.Brush.Solid = true;
        tChart6.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Header.Font.Shadow.Brush.Solid = true;
        tChart6.Header.Font.Shadow.Brush.Visible = true;
        tChart6.Header.Font.Size = 8;
        tChart6.Header.Font.SizeFloat = 8F;
        tChart6.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Header.ImageBevel.Brush.Solid = true;
        tChart6.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart6.Header.Shadow.Brush.Solid = true;
        tChart6.Header.Shadow.Brush.Visible = true;
        tChart6.Header.Shadow.Height = 0;
        tChart6.Header.Shadow.Width = 0;
        tChart6.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart6.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart6.Legend.Brush.Gradient.Visible = true;
        tChart6.Legend.Brush.Solid = true;
        tChart6.Legend.Brush.Visible = true;
        tChart6.Legend.CheckBoxes = false;
        tChart6.Legend.ClipText = false;
        // 
        // 
        // 
        tChart6.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart6.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart6.Legend.Font.Brush.Solid = true;
        tChart6.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Legend.Font.Shadow.Brush.Solid = true;
        tChart6.Legend.Font.Shadow.Brush.Visible = true;
        tChart6.Legend.Font.Size = 8;
        tChart6.Legend.Font.SizeFloat = 8F;
        tChart6.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Legend.ImageBevel.Brush.Solid = true;
        tChart6.Legend.ImageBevel.Brush.Visible = true;
        tChart6.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Values;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Legend.Shadow.Brush.Solid = true;
        tChart6.Legend.Shadow.Brush.Visible = true;
        tChart6.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart6.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart6.Legend.Title.Brush.Solid = true;
        tChart6.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart6.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart6.Legend.Title.Font.Brush.Solid = true;
        tChart6.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart6.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart6.Legend.Title.Font.Size = 8;
        tChart6.Legend.Title.Font.SizeFloat = 8F;
        tChart6.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart6.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Legend.Title.Shadow.Brush.Solid = true;
        tChart6.Legend.Title.Shadow.Brush.Visible = true;
        tChart6.Legend.Visible = false;
        //tChart6.Name = "tChart6";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart6.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart6.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart6.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart6.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart6.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart6.Panel.Brush.Gradient.UseMiddle = false;
        tChart6.Panel.Brush.Gradient.Visible = true;
        tChart6.Panel.Brush.Solid = true;
        tChart6.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Panel.ImageBevel.Brush.Solid = true;
        tChart6.Panel.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Panel.Shadow.Brush.Solid = true;
        tChart6.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.Series.Add(highLow1);
        tChart6.Series.Add(line3);
        tChart6.Series.Add(line4);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart6.SubFooter.Brush.Solid = true;
        tChart6.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart6.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart6.SubFooter.Font.Brush.Solid = true;
        tChart6.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart6.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart6.SubFooter.Font.Size = 8;
        tChart6.SubFooter.Font.SizeFloat = 8F;
        tChart6.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.SubFooter.ImageBevel.Brush.Solid = true;
        tChart6.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.SubFooter.Shadow.Brush.Solid = true;
        tChart6.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart6.SubHeader.Brush.Solid = true;
        tChart6.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart6.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart6.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart6.SubHeader.Font.Brush.Solid = true;
        tChart6.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart6.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart6.SubHeader.Font.Size = 12;
        tChart6.SubHeader.Font.SizeFloat = 12F;
        tChart6.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.SubHeader.ImageBevel.Brush.Solid = true;
        tChart6.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart6.SubHeader.Shadow.Brush.Solid = true;
        tChart6.SubHeader.Shadow.Brush.Visible = true;
        tChart6.TabIndex = 0;
        tChart6.Tools.Add(colorBand1);
        tChart6.Tools.Add(colorBand2);
        tChart6.Tools.Add(annotation1);
        tChart6.Tools.Add(annotation2);
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart6.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart6.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart6.Walls.Back.Brush.Solid = true;
        tChart6.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart6.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Walls.Back.Shadow.Brush.Solid = true;
        tChart6.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart6.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart6.Walls.Bottom.Brush.Solid = true;
        tChart6.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart6.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart6.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart6.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart6.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart6.Walls.Left.Brush.Solid = true;
        tChart6.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart6.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Walls.Left.Shadow.Brush.Solid = true;
        tChart6.Walls.Left.Shadow.Brush.Visible = true;
        tChart6.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart6.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart6.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart6.Walls.Right.Brush.Solid = true;
        tChart6.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart6.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart6.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart6.Walls.Right.Shadow.Brush.Solid = true;
        tChart6.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart6.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart6.Zoom.Brush.Solid = true;
        tChart6.Zoom.Brush.Visible = false;
        tChart6.BeforeDrawSeries += TChart6_BeforeDrawSeries;
        // axis3
        // 
        axis3.Automatic = false;
        axis3.AutomaticMaximum = false;
        axis3.AutomaticMinimum = false;
        axis3.EndPosition = 68D;
        axis3.Horizontal = false;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Labels.Brush.Color = System.Drawing.Color.White;
        axis3.Labels.Brush.Solid = true;
        axis3.Labels.Brush.Visible = true;
        axis3.Labels.CustomSize = 44;
        // 
        // 
        // 
        axis3.Labels.Font.Bold = false;
        // 
        // 
        // 
        axis3.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)168, (int)(byte)168, (int)(byte)0);
        axis3.Labels.Font.Brush.Solid = true;
        axis3.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis3.Labels.Font.Shadow.Brush.Solid = true;
        axis3.Labels.Font.Shadow.Brush.Visible = true;
        axis3.Labels.Font.Size = 9;
        axis3.Labels.Font.SizeFloat = 9F;
        axis3.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis3.Labels.ImageBevel.Brush.Solid = true;
        axis3.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis3.Labels.Shadow.Brush.Solid = true;
        axis3.Labels.Shadow.Brush.Visible = true;
        axis3.Maximum = 120D;
        axis3.Minimum = 0D;
        axis3.OtherSide = false;
        axis3.StartPosition = 42D;
        // 
        // 
        // 
        axis3.Title.Angle = 90;
        // 
        // 
        // 
        axis3.Title.Brush.Color = System.Drawing.Color.Silver;
        axis3.Title.Brush.Solid = true;
        axis3.Title.Brush.Visible = true;
        axis3.Title.Caption = "Std deviation";
        // 
        // 
        // 
        axis3.Title.Font.Bold = false;
        // 
        // 
        // 
        axis3.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        axis3.Title.Font.Brush.Solid = true;
        axis3.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis3.Title.Font.Shadow.Brush.Solid = true;
        axis3.Title.Font.Shadow.Brush.Visible = true;
        axis3.Title.Font.Size = 8;
        axis3.Title.Font.SizeFloat = 8F;
        axis3.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis3.Title.ImageBevel.Brush.Solid = true;
        axis3.Title.ImageBevel.Brush.Visible = true;
        axis3.Title.Lines = new string[]
    {
    "Std deviation"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        axis3.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis3.Title.Shadow.Brush.Solid = true;
        axis3.Title.Shadow.Brush.Visible = true;
        // 
        // axis4
        // 
        axis4.Automatic = false;
        axis4.AutomaticMaximum = false;
        axis4.AutomaticMinimum = false;
        // 
        // 
        // 
        axis4.Grid.DrawEvery = 1;
        axis4.Horizontal = false;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Labels.Brush.Color = System.Drawing.Color.White;
        axis4.Labels.Brush.Solid = true;
        axis4.Labels.Brush.Visible = true;
        axis4.Labels.CustomSize = 44;
        // 
        // 
        // 
        axis4.Labels.Font.Bold = false;
        // 
        // 
        // 
        axis4.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        axis4.Labels.Font.Brush.Solid = true;
        axis4.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis4.Labels.Font.Shadow.Brush.Solid = true;
        axis4.Labels.Font.Shadow.Brush.Visible = true;
        axis4.Labels.Font.Size = 9;
        axis4.Labels.Font.SizeFloat = 9F;
        axis4.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis4.Labels.ImageBevel.Brush.Solid = true;
        axis4.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis4.Labels.Shadow.Brush.Solid = true;
        axis4.Labels.Shadow.Brush.Visible = true;
        axis4.Maximum = 1050D;
        axis4.Minimum = 870D;
        axis4.OtherSide = false;
        axis4.StartPosition = 72D;
        // 
        // 
        // 
        axis4.Title.Angle = 90;
        // 
        // 
        // 
        axis4.Title.Brush.Color = System.Drawing.Color.Silver;
        axis4.Title.Brush.Solid = true;
        axis4.Title.Brush.Visible = true;
        axis4.Title.Caption = "RMS.";
        // 
        // 
        // 
        axis4.Title.Font.Bold = false;
        // 
        // 
        // 
        axis4.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        axis4.Title.Font.Brush.Solid = true;
        axis4.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis4.Title.Font.Shadow.Brush.Solid = true;
        axis4.Title.Font.Shadow.Brush.Visible = true;
        axis4.Title.Font.Size = 8;
        axis4.Title.Font.SizeFloat = 8F;
        axis4.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis4.Title.ImageBevel.Brush.Solid = true;
        axis4.Title.ImageBevel.Brush.Visible = true;
        axis4.Title.Lines = new string[]
    {
    "RMS."
    };
        // 
        // 
        // 
        // 
        // 
        // 
        axis4.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis4.Title.Shadow.Brush.Solid = true;
        axis4.Title.Shadow.Brush.Visible = true;
        // 
        // highLow1
        // 
        // 
        // 
        // 
        highLow1.Brush.Color = System.Drawing.Color.Empty;
        highLow1.Brush.Solid = true;
        highLow1.Brush.Visible = true;
        highLow1.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        highLow1.HighBrush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)192, (int)(byte)192, (int)(byte)255);
        // 
        // 
        // 
        highLow1.HighBrush.Gradient.Transparency = 50;
        highLow1.HighBrush.Gradient.UseMiddle = true;
        highLow1.HighBrush.Gradient.Visible = true;
        highLow1.HighBrush.Solid = true;
        highLow1.HighBrush.Visible = true;
        // 
        // 
        // 
        highLow1.HighPen.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        highLow1.HighValues.DataMember = "Y";
        // 
        // 
        // 
        // 
        // 
        highLow1.Legend.Brush.Color = System.Drawing.Color.White;
        highLow1.Legend.Brush.Solid = true;
        highLow1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        highLow1.Legend.Font.Bold = false;
        // 
        // 
        // 
        highLow1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        highLow1.Legend.Font.Brush.Solid = true;
        highLow1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        highLow1.Legend.Font.Shadow.Brush.Solid = true;
        highLow1.Legend.Font.Shadow.Brush.Visible = true;
        highLow1.Legend.Font.Size = 8;
        highLow1.Legend.Font.SizeFloat = 8F;
        highLow1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        highLow1.Legend.ImageBevel.Brush.Solid = true;
        highLow1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        highLow1.Legend.Shadow.Brush.Solid = true;
        highLow1.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        highLow1.LowBrush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)223, (int)(byte)223, (int)(byte)255);
        // 
        // 
        // 
        highLow1.LowBrush.Gradient.UseMiddle = true;
        highLow1.LowBrush.Gradient.Visible = true;
        highLow1.LowBrush.Solid = true;
        highLow1.LowBrush.Visible = true;
        // 
        // 
        // 
        highLow1.LowPen.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)255);
        // 
        // 
        // 
        highLow1.LowValues.DataMember = "Low";

        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        highLow1.Marks.Brush.Solid = true;
        highLow1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        highLow1.Marks.Font.Bold = false;
        // 
        // 
        // 
        highLow1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        highLow1.Marks.Font.Brush.Solid = true;
        highLow1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        highLow1.Marks.Font.Shadow.Brush.Solid = true;
        highLow1.Marks.Font.Shadow.Brush.Visible = true;
        highLow1.Marks.Font.Size = 8;
        highLow1.Marks.Font.SizeFloat = 8F;
        highLow1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        highLow1.Marks.ImageBevel.Brush.Solid = true;
        highLow1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        highLow1.Marks.Shadow.Brush.Solid = true;
        highLow1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        highLow1.Marks.Symbol.Brush.Solid = true;
        highLow1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        highLow1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        highLow1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        highLow1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        highLow1.Marks.Symbol.Shadow.Brush.Solid = true;
        highLow1.Marks.Symbol.Shadow.Brush.Visible = true;
        highLow1.Title = "high-Low1";
        // 
        // 
        // 
        highLow1.XValues.DataMember = "X";
        highLow1.XValues.DateTime = true;
        highLow1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // line3
        // 
        // 
        // 
        // 
        line3.AreaBrush.Color = System.Drawing.Color.White;
        line3.AreaBrush.Solid = true;
        line3.AreaBrush.Visible = false;
        // 
        // 
        // 
        line3.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)207, (int)(byte)104);
        line3.Brush.Solid = true;
        line3.Brush.Visible = true;
        line3.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)207, (int)(byte)104);
        line3.CustomVertAxis = axis3;
        line3.DataSource = highLow1;
        line3.Function = stdDeviation2;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Legend.Brush.Color = System.Drawing.Color.White;
        line3.Legend.Brush.Solid = true;
        line3.Legend.Brush.Visible = true;
        // 
        // 
        // 
        line3.Legend.Font.Bold = false;
        // 
        // 
        // 
        line3.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        line3.Legend.Font.Brush.Solid = true;
        line3.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line3.Legend.Font.Shadow.Brush.Solid = true;
        line3.Legend.Font.Shadow.Brush.Visible = true;
        line3.Legend.Font.Size = 8;
        line3.Legend.Font.SizeFloat = 8F;
        line3.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line3.Legend.ImageBevel.Brush.Solid = true;
        line3.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line3.Legend.Shadow.Brush.Solid = true;
        line3.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line3.Marks.Brush.Solid = true;
        line3.Marks.Brush.Visible = true;
        // 
        // 
        // 
        line3.Marks.Font.Bold = false;
        // 
        // 
        // 
        line3.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        line3.Marks.Font.Brush.Solid = true;
        line3.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line3.Marks.Font.Shadow.Brush.Solid = true;
        line3.Marks.Font.Shadow.Brush.Visible = true;
        line3.Marks.Font.Size = 8;
        line3.Marks.Font.SizeFloat = 8F;
        line3.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line3.Marks.ImageBevel.Brush.Solid = true;
        line3.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        line3.Marks.Shadow.Brush.Solid = true;
        line3.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        line3.Marks.Symbol.Brush.Solid = true;
        line3.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line3.Marks.Symbol.ImageBevel.Brush.Solid = true;
        line3.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line3.Marks.Symbol.Shadow.Brush.Solid = true;
        line3.Marks.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line3.Pointer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line3.Pointer.Brush.Solid = true;
        line3.Pointer.Brush.Visible = true;
        line3.Title = "line1";
        line3.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom;
        // 
        // 
        // 
        line3.XValues.DateTime = true;
        line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        // 
        // stdDeviation2
        // 
        stdDeviation2.Period = 10D;
        // 
        // line4
        // 
        // 
        // 
        // 
        line4.AreaBrush.Color = System.Drawing.Color.White;
        line4.AreaBrush.Solid = true;
        line4.AreaBrush.Visible = false;
        // 
        // 
        // 
        line4.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)127, (int)(byte)71);
        line4.Brush.Solid = true;
        line4.Brush.Visible = true;
        line4.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)127, (int)(byte)71);
        line4.CustomVertAxis = axis4;
        line4.DataSource = highLow1;
        line4.Function = rootMeanSquare1;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Legend.Brush.Color = System.Drawing.Color.White;
        line4.Legend.Brush.Solid = true;
        line4.Legend.Brush.Visible = true;
        // 
        // 
        // 
        line4.Legend.Font.Bold = false;
        // 
        // 
        // 
        line4.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        line4.Legend.Font.Brush.Solid = true;
        line4.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line4.Legend.Font.Shadow.Brush.Solid = true;
        line4.Legend.Font.Shadow.Brush.Visible = true;
        line4.Legend.Font.Size = 8;
        line4.Legend.Font.SizeFloat = 8F;
        line4.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line4.Legend.ImageBevel.Brush.Solid = true;
        line4.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line4.Legend.Shadow.Brush.Solid = true;
        line4.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line4.Marks.Brush.Solid = true;
        line4.Marks.Brush.Visible = true;
        // 
        // 
        // 
        line4.Marks.Font.Bold = false;
        // 
        // 
        // 
        line4.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        line4.Marks.Font.Brush.Solid = true;
        line4.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line4.Marks.Font.Shadow.Brush.Solid = true;
        line4.Marks.Font.Shadow.Brush.Visible = true;
        line4.Marks.Font.Size = 8;
        line4.Marks.Font.SizeFloat = 8F;
        line4.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line4.Marks.ImageBevel.Brush.Solid = true;
        line4.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        line4.Marks.Shadow.Brush.Solid = true;
        line4.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        line4.Marks.Symbol.Brush.Solid = true;
        line4.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line4.Marks.Symbol.ImageBevel.Brush.Solid = true;
        line4.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line4.Marks.Symbol.Shadow.Brush.Solid = true;
        line4.Marks.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line4.Pointer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line4.Pointer.Brush.Solid = true;
        line4.Pointer.Brush.Visible = true;
        line4.Title = "line2";
        line4.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom;
        // 
        // 
        // 
        line4.XValues.DateTime = true;
        line4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 

        // 
        // rootMeanSquare1
        // 
        rootMeanSquare1.Period = 10D;
        // 
        // colorBand1
        // 
        colorBand1.Axis = axis3;
        colorBand1.AxisIndex = -1;
        // 
        // 
        // 
        colorBand1.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)102, (int)(byte)190, (int)(byte)190, (int)(byte)0);
        colorBand1.Brush.Solid = true;
        colorBand1.Brush.Visible = true;
        colorBand1.End = 110D;
        // 
        // 
        // 
        colorBand1.Pen.Visible = false;
        colorBand1.ResizeEnd = false;
        colorBand1.ResizeStart = false;
        colorBand1.Start = 10D;
        // 
        // colorBand2
        // 
        colorBand2.Axis = axis4;
        colorBand2.AxisIndex = -1;
        // 
        // 
        // 
        colorBand2.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)97, (int)(byte)192, (int)(byte)192, (int)(byte)192);
        colorBand2.Brush.Solid = true;
        colorBand2.Brush.Visible = true;
        colorBand2.End = 940D;
        // 
        // 
        // 
        colorBand2.Pen.Visible = false;
        colorBand2.ResizeEnd = false;
        colorBand2.ResizeStart = false;
        colorBand2.Start = 1000D;
        // 
        // annotation1
        // 
        annotation1.AutoSize = true;
        // 
        // 
        // 
        annotation1.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        annotation1.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
        annotation1.Callout.ArrowHeadSize = 8;
        // 
        // 
        // 
        annotation1.Callout.Brush.Color = System.Drawing.Color.Black;
        annotation1.Callout.Brush.Solid = true;
        annotation1.Callout.Brush.Visible = true;
        annotation1.Callout.Distance = 0;
        annotation1.Callout.Draw3D = false;
        annotation1.Callout.XPosition = 0;
        annotation1.Callout.YPosition = 0;
        annotation1.Callout.ZPosition = 0;
        annotation1.Left = 6;
        annotation1.Position = Steema.TeeChart.Tools.AnnotationPositions.Custom;
        annotation1.PositionUnits = Steema.TeeChart.PositionUnits.Percent;
        // 
        // 
        // 
        annotation1.Shape.Bottom = 27;
        // 
        // 
        // 
        annotation1.Shape.Brush.Color = System.Drawing.Color.White;
        annotation1.Shape.Brush.Solid = true;
        annotation1.Shape.Brush.Visible = true;
        annotation1.Shape.CustomPosition = true;
        // 
        // 
        // 
        annotation1.Shape.Font.Bold = false;
        // 
        // 
        // 
        annotation1.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)190, (int)(byte)190, (int)(byte)0);
        annotation1.Shape.Font.Brush.Solid = true;
        annotation1.Shape.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation1.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        annotation1.Shape.Font.Shadow.Brush.Solid = true;
        annotation1.Shape.Font.Shadow.Brush.Visible = true;
        annotation1.Shape.Font.Size = 8;
        annotation1.Shape.Font.SizeFloat = 8F;
        annotation1.Shape.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation1.Shape.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        annotation1.Shape.ImageBevel.Brush.Solid = true;
        annotation1.Shape.ImageBevel.Brush.Visible = true;
        annotation1.Shape.Left = 6;
        annotation1.Shape.Lines = new string[]
    {
    "Safe Upper limit"
    };
        annotation1.Shape.Right = 79;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation1.Shape.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        annotation1.Shape.Shadow.Brush.Solid = true;
        annotation1.Shape.Shadow.Brush.Visible = true;
        annotation1.Shape.Top = 8;
        annotation1.Shape.Transparent = true;
        annotation1.Text = "Safe Upper limit";
        annotation1.Top = 8;
        // 
        // annotation2
        // 
        annotation2.AutoSize = true;
        // 
        // 
        // 
        annotation2.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        annotation2.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
        annotation2.Callout.ArrowHeadSize = 8;
        // 
        // 
        // 
        annotation2.Callout.Brush.Color = System.Drawing.Color.Black;
        annotation2.Callout.Brush.Solid = true;
        annotation2.Callout.Brush.Visible = true;
        annotation2.Callout.Distance = 0;
        annotation2.Callout.Draw3D = false;
        annotation2.Callout.XPosition = 0;
        annotation2.Callout.YPosition = 0;
        annotation2.Callout.ZPosition = 0;
        annotation2.Left = 6;
        annotation2.Position = Steema.TeeChart.Tools.AnnotationPositions.Custom;
        annotation2.PositionUnits = Steema.TeeChart.PositionUnits.Percent;
        // 
        // 
        // 
        annotation2.Shape.Bottom = 27;
        // 
        // 
        // 
        annotation2.Shape.Brush.Color = System.Drawing.Color.White;
        annotation2.Shape.Brush.Solid = true;
        annotation2.Shape.Brush.Visible = true;
        annotation2.Shape.CustomPosition = true;
        // 
        // 
        // 
        annotation2.Shape.Font.Bold = false;
        // 
        // 
        // 
        annotation2.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)190, (int)(byte)190, (int)(byte)0);
        annotation2.Shape.Font.Brush.Solid = true;
        annotation2.Shape.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation2.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        annotation2.Shape.Font.Shadow.Brush.Solid = true;
        annotation2.Shape.Font.Shadow.Brush.Visible = true;
        annotation2.Shape.Font.Size = 8;
        annotation2.Shape.Font.SizeFloat = 8F;
        annotation2.Shape.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation2.Shape.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        annotation2.Shape.ImageBevel.Brush.Solid = true;
        annotation2.Shape.ImageBevel.Brush.Visible = true;
        annotation2.Shape.Left = 6;
        annotation2.Shape.Lines = new string[]
    {
    "Safe Lower limit"
    };
        annotation2.Shape.Right = 79;
        // 
        // 
        // 
        // 
        // 
        // 
        annotation2.Shape.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        annotation2.Shape.Shadow.Brush.Solid = true;
        annotation2.Shape.Shadow.Brush.Visible = true;
        annotation2.Shape.Top = 8;
        annotation2.Shape.Transparent = true;
        annotation2.Text = "Safe Lower limit";
        annotation2.Top = 8;

        // tChart7
        tChart7.Aspect.ColorPaletteIndex = -1;
        // 
        // 
        tChart7.Axes.Bottom.Labels.Angle = 45;
        // 
        // 
        tChart7.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.Bottom.Labels.Brush.Solid = true;
        tChart7.Axes.Bottom.Labels.Brush.Visible = true;
        tChart7.Axes.Bottom.Labels.DateTimeFormat = "hh:mm:ss";
        // 
        // 
        tChart7.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        tChart7.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart7.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Bottom.Labels.Font.Size = 6;
        tChart7.Axes.Bottom.Labels.Font.SizeFloat = 6F;
        tChart7.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.Bottom.Title.Brush.Solid = true;
        tChart7.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart7.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Bottom.Title.Font.Size = 8;
        tChart7.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart7.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        tChart7.Axes.Custom.Add(axis1);
        tChart7.Axes.Custom.Add(axis2);
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.Depth.Labels.Brush.Solid = true;
        tChart7.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart7.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Depth.Labels.Font.Size = 8;
        tChart7.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart7.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.Depth.Title.Brush.Solid = true;
        tChart7.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart7.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Depth.Title.Font.Size = 8;
        tChart7.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart7.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart7.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart7.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.DepthTop.Labels.Font.Size = 8;
        tChart7.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart7.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.DepthTop.Title.Brush.Solid = true;
        tChart7.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart7.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.DepthTop.Title.Font.Size = 8;
        tChart7.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart7.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.AxisPen.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)255);
        tChart7.Axes.Left.AxisPen.Visible = true;
        tChart7.Axes.Left.EndPosition = 70D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.Left.Labels.Brush.Solid = true;
        tChart7.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart7.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Left.Labels.Font.Size = 8;
        tChart7.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart7.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.Left.Title.Brush.Solid = true;
        tChart7.Axes.Left.Title.Brush.Visible = true;
        tChart7.Axes.Left.Title.Caption = "Volume GBs";
        // 
        // 
        // 
        tChart7.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Left.Title.Font.Brush.Solid = true;
        tChart7.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Left.Title.Font.Size = 8;
        tChart7.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart7.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        tChart7.Axes.Left.Title.Lines = new string[]
    {
    "Volume GBs"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.AxisPen.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)192, (int)(byte)128);
        tChart7.Axes.Right.AxisPen.Visible = true;
        tChart7.Axes.Right.EndPosition = 70D;
        // 
        // 
        // 
        tChart7.Axes.Right.Grid.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.Right.Labels.Brush.Solid = true;
        tChart7.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart7.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Right.Labels.Font.Size = 8;
        tChart7.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart7.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.Right.Title.Brush.Solid = true;
        tChart7.Axes.Right.Title.Brush.Visible = true;
        tChart7.Axes.Right.Title.Caption = "Throughput GB/s";
        // 
        // 
        // 
        tChart7.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Right.Title.Font.Brush.Solid = true;
        tChart7.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Right.Title.Font.Size = 8;
        tChart7.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart7.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        tChart7.Axes.Right.Title.Lines = new string[]
    {
    "Throughput GB/s"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart7.Axes.Top.Labels.Brush.Solid = true;
        tChart7.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart7.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Top.Labels.Font.Size = 8;
        tChart7.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart7.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart7.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Axes.Top.Title.Brush.Solid = true;
        tChart7.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Axes.Top.Title.Font.Brush.Solid = true;
        tChart7.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Axes.Top.Title.Font.Size = 8;
        tChart7.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart7.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart7.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart7.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Footer.Alignment = Steema.TeeChart.Drawing.StringAlignment.Near;
        tChart7.Footer.Bottom = 349;
        // 
        // 
        // 
        tChart7.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart7.Footer.Brush.Solid = true;
        tChart7.Footer.Brush.Visible = true;
        tChart7.Footer.CustomPosition = true;
        // 
        // 
        // 
        tChart7.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart7.Footer.Font.Brush.Solid = true;
        tChart7.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Footer.Font.Shadow.Brush.Solid = true;
        tChart7.Footer.Font.Shadow.Brush.Visible = true;
        tChart7.Footer.Font.Size = 8;
        tChart7.Footer.Font.SizeFloat = 8F;
        tChart7.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Footer.ImageBevel.Brush.Solid = true;
        tChart7.Footer.ImageBevel.Brush.Visible = true;
        tChart7.Footer.Left = 640;
        tChart7.Footer.Lines = new string[]
    {
    "Cycles"
    };
        tChart7.Footer.Right = 694;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Footer.Shadow.Brush.Solid = true;
        tChart7.Footer.Shadow.Brush.Visible = true;
        tChart7.Footer.Top = 334;
        tChart7.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart7.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Header.Brush.Gradient.SigmaScale = 0F;
        tChart7.Header.Brush.Solid = true;
        tChart7.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Header.Font.Brush.Solid = true;
        tChart7.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Header.Font.Shadow.Brush.Solid = true;
        tChart7.Header.Font.Shadow.Brush.Visible = true;
        tChart7.Header.Font.Size = 8;
        tChart7.Header.Font.SizeFloat = 8F;
        tChart7.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Header.ImageBevel.Brush.Solid = true;
        tChart7.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart7.Header.Shadow.Brush.Solid = true;
        tChart7.Header.Shadow.Brush.Visible = true;
        tChart7.Header.Shadow.Height = 0;
        tChart7.Header.Shadow.Width = 0;
        tChart7.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart7.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart7.Legend.Brush.Gradient.Visible = true;
        tChart7.Legend.Brush.Solid = true;
        tChart7.Legend.Brush.Visible = true;
        tChart7.Legend.CheckBoxes = false;
        tChart7.Legend.ClipText = false;
        // 
        // 
        // 
        tChart7.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart7.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart7.Legend.Font.Brush.Solid = true;
        tChart7.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Legend.Font.Shadow.Brush.Solid = true;
        tChart7.Legend.Font.Shadow.Brush.Visible = true;
        tChart7.Legend.Font.Size = 8;
        tChart7.Legend.Font.SizeFloat = 8F;
        tChart7.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Legend.ImageBevel.Brush.Solid = true;
        tChart7.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Legend.Shadow.Brush.Solid = true;
        tChart7.Legend.Shadow.Brush.Visible = true;
        tChart7.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart7.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart7.Legend.Title.Brush.Solid = true;
        tChart7.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart7.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart7.Legend.Title.Font.Brush.Solid = true;
        tChart7.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart7.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart7.Legend.Title.Font.Size = 8;
        tChart7.Legend.Title.Font.SizeFloat = 8F;
        tChart7.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart7.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Legend.Title.Shadow.Brush.Solid = true;
        tChart7.Legend.Title.Shadow.Brush.Visible = true;
        tChart7.Legend.Visible = false;
        //tChart7.Name = "tChart7";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart7.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart7.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart7.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart7.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart7.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart7.Panel.Brush.Gradient.UseMiddle = false;
        tChart7.Panel.Brush.Gradient.Visible = true;
        tChart7.Panel.Brush.Solid = true;
        tChart7.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Panel.ImageBevel.Brush.Solid = true;
        tChart7.Panel.ImageBevel.Brush.Visible = true;
        tChart7.Panel.MarginBottom = 7D;
        tChart7.Panel.MarginLeft = 4D;
        tChart7.Panel.MarginRight = 10D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Panel.Shadow.Brush.Solid = true;
        tChart7.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.Series.Add(area1);
        tChart7.Series.Add(line1);
        tChart7.Series.Add(line2);
        tChart7.Series.Add(bar3D1);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart7.SubFooter.Brush.Solid = true;
        tChart7.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart7.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart7.SubFooter.Font.Brush.Solid = true;
        tChart7.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart7.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart7.SubFooter.Font.Size = 8;
        tChart7.SubFooter.Font.SizeFloat = 8F;
        tChart7.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.SubFooter.ImageBevel.Brush.Solid = true;
        tChart7.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.SubFooter.Shadow.Brush.Solid = true;
        tChart7.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart7.SubHeader.Brush.Solid = true;
        tChart7.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart7.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart7.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart7.SubHeader.Font.Brush.Solid = true;
        tChart7.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart7.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart7.SubHeader.Font.Size = 12;
        tChart7.SubHeader.Font.SizeFloat = 12F;
        tChart7.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.SubHeader.ImageBevel.Brush.Solid = true;
        tChart7.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart7.SubHeader.Shadow.Brush.Solid = true;
        tChart7.SubHeader.Shadow.Brush.Visible = true;
        tChart7.TabIndex = 0;
        tChart7.Tools.Add(cursorTool1);
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart7.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart7.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart7.Walls.Back.Brush.Solid = true;
        tChart7.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart7.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Walls.Back.Shadow.Brush.Solid = true;
        tChart7.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart7.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart7.Walls.Bottom.Brush.Solid = true;
        tChart7.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart7.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart7.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart7.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart7.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart7.Walls.Left.Brush.Solid = true;
        tChart7.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart7.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Walls.Left.Shadow.Brush.Solid = true;
        tChart7.Walls.Left.Shadow.Brush.Visible = true;
        tChart7.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart7.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart7.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart7.Walls.Right.Brush.Solid = true;
        tChart7.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart7.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart7.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart7.Walls.Right.Shadow.Brush.Solid = true;
        tChart7.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart7.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart7.Zoom.Brush.Solid = true;
        tChart7.Zoom.Brush.Visible = false;
        tChart7.AfterDraw += TChart7_AfterDraw;
        // 
        // axis1
        // 
        // 
        // 
        // 
        axis1.AxisPen.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)128, (int)(byte)0);
        axis1.AxisPen.Visible = true;
        axis1.EndPosition = 70D;
        // 
        // 
        // 
        axis1.Grid.Visible = false;
        axis1.Horizontal = false;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Labels.Brush.Color = System.Drawing.Color.White;
        axis1.Labels.Brush.Solid = true;
        axis1.Labels.Brush.Visible = true;
        // 
        // 
        // 
        axis1.Labels.Font.Bold = false;
        // 
        // 
        // 
        axis1.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        axis1.Labels.Font.Brush.Solid = true;
        axis1.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis1.Labels.Font.Shadow.Brush.Solid = true;
        axis1.Labels.Font.Shadow.Brush.Visible = true;
        axis1.Labels.Font.Size = 9;
        axis1.Labels.Font.SizeFloat = 9F;
        axis1.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis1.Labels.ImageBevel.Brush.Solid = true;
        axis1.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis1.Labels.Shadow.Brush.Solid = true;
        axis1.Labels.Shadow.Brush.Visible = true;
        axis1.OtherSide = true;
        axis1.RelativePosition = -11D;
        // 
        // 
        // 
        axis1.Title.Angle = 270;
        // 
        // 
        // 
        axis1.Title.Brush.Color = System.Drawing.Color.Silver;
        axis1.Title.Brush.Solid = true;
        axis1.Title.Brush.Visible = true;
        axis1.Title.Caption = "Freq. Hz.";
        // 
        // 
        // 
        axis1.Title.Font.Bold = false;
        // 
        // 
        // 
        axis1.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        axis1.Title.Font.Brush.Solid = true;
        axis1.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis1.Title.Font.Shadow.Brush.Solid = true;
        axis1.Title.Font.Shadow.Brush.Visible = true;
        axis1.Title.Font.Size = 8;
        axis1.Title.Font.SizeFloat = 8F;
        axis1.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis1.Title.ImageBevel.Brush.Solid = true;
        axis1.Title.ImageBevel.Brush.Visible = true;
        axis1.Title.Lines = new string[]
    {
    "Freq. Hz."
    };
        // 
        // 
        // 
        // 
        // 
        // 
        axis1.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis1.Title.Shadow.Brush.Solid = true;
        axis1.Title.Shadow.Brush.Visible = true;
        axis1.ZPosition = 0D;
        // 
        // axis2
        // 
        // 
        // 
        // 
        axis2.AxisPen.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)255);
        axis2.AxisPen.Visible = true;
        axis2.Horizontal = false;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Labels.Brush.Color = System.Drawing.Color.White;
        axis2.Labels.Brush.Solid = true;
        axis2.Labels.Brush.Visible = true;
        // 
        // 
        // 
        axis2.Labels.Font.Bold = false;
        // 
        // 
        // 
        axis2.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        axis2.Labels.Font.Brush.Solid = true;
        axis2.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis2.Labels.Font.Shadow.Brush.Solid = true;
        axis2.Labels.Font.Shadow.Brush.Visible = true;
        axis2.Labels.Font.Size = 9;
        axis2.Labels.Font.SizeFloat = 9F;
        axis2.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis2.Labels.ImageBevel.Brush.Solid = true;
        axis2.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis2.Labels.Shadow.Brush.Solid = true;
        axis2.Labels.Shadow.Brush.Visible = true;
        axis2.OtherSide = false;
        axis2.StartPosition = 72D;
        // 
        // 
        // 
        axis2.Title.Angle = 90;
        // 
        // 
        // 
        axis2.Title.Brush.Color = System.Drawing.Color.Silver;
        axis2.Title.Brush.Solid = true;
        axis2.Title.Brush.Visible = true;
        axis2.Title.Caption = "Buffer range";
        // 
        // 
        // 
        axis2.Title.Font.Bold = false;
        // 
        // 
        // 
        axis2.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        axis2.Title.Font.Brush.Solid = true;
        axis2.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis2.Title.Font.Shadow.Brush.Solid = true;
        axis2.Title.Font.Shadow.Brush.Visible = true;
        axis2.Title.Font.Size = 8;
        axis2.Title.Font.SizeFloat = 8F;
        axis2.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        axis2.Title.ImageBevel.Brush.Solid = true;
        axis2.Title.ImageBevel.Brush.Visible = true;
        axis2.Title.Lines = new string[]
    {
    "Buffer range"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        axis2.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        axis2.Title.Shadow.Brush.Solid = true;
        axis2.Title.Shadow.Brush.Visible = true;
        // 
        // area1
        // 
        // 
        // 
        // 
        area1.AreaBrush.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        area1.Gradient.Transparency = 40;
        area1.Gradient.Visible = true;
        area1.AreaBrush.Solid = true;
        area1.AreaBrush.Visible = false;
        // 
        // 
        // 
        area1.AreaLines.Color = System.Drawing.Color.FromArgb((int)(byte)71, (int)(byte)92, (int)(byte)128);
        area1.AreaLines.Visible = false;
        // 
        // 
        // 
        area1.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        area1.Brush.Solid = true;
        area1.Brush.Visible = true;
        area1.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Legend.Brush.Color = System.Drawing.Color.White;
        area1.Legend.Brush.Solid = true;
        area1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        area1.Legend.Font.Bold = false;
        // 
        // 
        // 
        area1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        area1.Legend.Font.Brush.Solid = true;
        area1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        area1.Legend.Font.Shadow.Brush.Solid = true;
        area1.Legend.Font.Shadow.Brush.Visible = true;
        area1.Legend.Font.Size = 8;
        area1.Legend.Font.SizeFloat = 8F;
        area1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        area1.Legend.ImageBevel.Brush.Solid = true;
        area1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        area1.Legend.Shadow.Brush.Solid = true;
        area1.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        area1.Marks.Brush.Solid = true;
        area1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        area1.Marks.Font.Bold = false;
        // 
        // 
        // 
        area1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        area1.Marks.Font.Brush.Solid = true;
        area1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        area1.Marks.Font.Shadow.Brush.Solid = true;
        area1.Marks.Font.Shadow.Brush.Visible = true;
        area1.Marks.Font.Size = 8;
        area1.Marks.Font.SizeFloat = 8F;
        area1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        area1.Marks.ImageBevel.Brush.Solid = true;
        area1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        area1.Marks.Shadow.Brush.Solid = true;
        area1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        area1.Marks.Symbol.Brush.Solid = true;
        area1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        area1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        area1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        area1.Marks.Symbol.Shadow.Brush.Solid = true;
        area1.Marks.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        area1.Pointer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        area1.Pointer.Brush.Solid = true;
        area1.Pointer.Brush.Visible = true;
        area1.Title = "area1";
        // 
        // 
        // 
        area1.XValues.DataMember = "X";
        area1.XValues.DateTime = true;
        area1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        area1.YValues.DataMember = "Y";

        // 
        // line1
        // 
        // 
        // 
        // 
        line1.AreaBrush.Color = System.Drawing.Color.White;
        line1.AreaBrush.Solid = true;
        line1.AreaBrush.Visible = false;
        // 
        // 
        // 
        line1.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)207, (int)(byte)104);
        line1.Brush.Solid = true;
        line1.Brush.Visible = true;
        line1.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)207, (int)(byte)104);
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Legend.Brush.Color = System.Drawing.Color.White;
        line1.Legend.Brush.Solid = true;
        line1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        line1.Legend.Font.Bold = false;
        // 
        // 
        // 
        line1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        line1.Legend.Font.Brush.Solid = true;
        line1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line1.Legend.Font.Shadow.Brush.Solid = true;
        line1.Legend.Font.Shadow.Brush.Visible = true;
        line1.Legend.Font.Size = 8;
        line1.Legend.Font.SizeFloat = 8F;
        line1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line1.Legend.ImageBevel.Brush.Solid = true;
        line1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line1.Legend.Shadow.Brush.Solid = true;
        line1.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        line1.LinePen.Width = 2;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line1.Marks.Brush.Solid = true;
        line1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        line1.Marks.Font.Bold = false;
        // 
        // 
        // 
        line1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        line1.Marks.Font.Brush.Solid = true;
        line1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line1.Marks.Font.Shadow.Brush.Solid = true;
        line1.Marks.Font.Shadow.Brush.Visible = true;
        line1.Marks.Font.Size = 8;
        line1.Marks.Font.SizeFloat = 8F;
        line1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line1.Marks.ImageBevel.Brush.Solid = true;
        line1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        line1.Marks.Shadow.Brush.Solid = true;
        line1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        line1.Marks.Symbol.Brush.Solid = true;
        line1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        line1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line1.Marks.Symbol.Shadow.Brush.Solid = true;
        line1.Marks.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line1.Pointer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line1.Pointer.Brush.Solid = true;
        line1.Pointer.Brush.Visible = true;
        line1.Title = "line1";
        line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
        // 
        // 
        // 
        line1.XValues.DataMember = "X";
        line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        line1.YValues.DataMember = "Y";
        // 
        // line2
        // 
        // 
        // 
        // 
        line2.AreaBrush.Color = System.Drawing.Color.White;
        line2.AreaBrush.Solid = true;
        line2.AreaBrush.Visible = false;
        // 
        // 
        // 
        line2.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)127, (int)(byte)71);
        line2.Brush.Solid = true;
        line2.Brush.Visible = true;
        line2.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)127, (int)(byte)71);
        line2.CustomVertAxis = axis1;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Legend.Brush.Color = System.Drawing.Color.White;
        line2.Legend.Brush.Solid = true;
        line2.Legend.Brush.Visible = true;
        // 
        // 
        // 
        line2.Legend.Font.Bold = false;
        // 
        // 
        // 
        line2.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        line2.Legend.Font.Brush.Solid = true;
        line2.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line2.Legend.Font.Shadow.Brush.Solid = true;
        line2.Legend.Font.Shadow.Brush.Visible = true;
        line2.Legend.Font.Size = 8;
        line2.Legend.Font.SizeFloat = 8F;
        line2.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line2.Legend.ImageBevel.Brush.Solid = true;
        line2.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line2.Legend.Shadow.Brush.Solid = true;
        line2.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        line2.LinePen.Width = 2;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line2.Marks.Brush.Solid = true;
        line2.Marks.Brush.Visible = true;
        // 
        // 
        // 
        line2.Marks.Font.Bold = false;
        // 
        // 
        // 
        line2.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        line2.Marks.Font.Brush.Solid = true;
        line2.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line2.Marks.Font.Shadow.Brush.Solid = true;
        line2.Marks.Font.Shadow.Brush.Visible = true;
        line2.Marks.Font.Size = 8;
        line2.Marks.Font.SizeFloat = 8F;
        line2.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line2.Marks.ImageBevel.Brush.Solid = true;
        line2.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        line2.Marks.Shadow.Brush.Solid = true;
        line2.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        line2.Marks.Symbol.Brush.Solid = true;
        line2.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        line2.Marks.Symbol.ImageBevel.Brush.Solid = true;
        line2.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        line2.Marks.Symbol.Shadow.Brush.Solid = true;
        line2.Marks.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        line2.Pointer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        line2.Pointer.Brush.Solid = true;
        line2.Pointer.Brush.Visible = true;
        line2.Title = "line2";
        line2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom;
        // 
        // 
        // 
        line2.XValues.DataMember = "X";
        line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        line2.YValues.DataMember = "Y";
        // 
        // bar3D1
        // 
        bar3D1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
        // 
        // 
        // 
        bar3D1.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)129, (int)(byte)202, (int)(byte)219);
        bar3D1.Brush.Solid = true;
        bar3D1.Brush.Visible = true;
        bar3D1.Color = System.Drawing.Color.FromArgb((int)(byte)129, (int)(byte)202, (int)(byte)219);
        bar3D1.CustomVertAxis = axis2;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Legend.Brush.Color = System.Drawing.Color.White;
        bar3D1.Legend.Brush.Solid = true;
        bar3D1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        bar3D1.Legend.Font.Bold = false;
        // 
        // 
        // 
        bar3D1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        bar3D1.Legend.Font.Brush.Solid = true;
        bar3D1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        bar3D1.Legend.Font.Shadow.Brush.Solid = true;
        bar3D1.Legend.Font.Shadow.Brush.Visible = true;
        bar3D1.Legend.Font.Size = 8;
        bar3D1.Legend.Font.SizeFloat = 8F;
        bar3D1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        bar3D1.Legend.ImageBevel.Brush.Solid = true;
        bar3D1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        bar3D1.Legend.Shadow.Brush.Solid = true;
        bar3D1.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        bar3D1.Marks.Brush.Solid = true;
        bar3D1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        bar3D1.Marks.Font.Bold = false;
        // 
        // 
        // 
        bar3D1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        bar3D1.Marks.Font.Brush.Solid = true;
        bar3D1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        bar3D1.Marks.Font.Shadow.Brush.Solid = true;
        bar3D1.Marks.Font.Shadow.Brush.Visible = true;
        bar3D1.Marks.Font.Size = 8;
        bar3D1.Marks.Font.SizeFloat = 8F;
        bar3D1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        bar3D1.Marks.ImageBevel.Brush.Solid = true;
        bar3D1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        bar3D1.Marks.Shadow.Brush.Solid = true;
        bar3D1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        bar3D1.Marks.Symbol.Brush.Solid = true;
        bar3D1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        bar3D1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        bar3D1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        bar3D1.Marks.Symbol.Shadow.Brush.Solid = true;
        bar3D1.Marks.Symbol.Shadow.Brush.Visible = true;
        bar3D1.Marks.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        bar3D1.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        bar3D1.Shadow.Brush.Solid = true;
        bar3D1.Shadow.Brush.Visible = true;
        bar3D1.Title = "bar3D1";
        bar3D1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom;
        // 
        // 
        // 
        bar3D1.XValues.DataMember = "X";
        bar3D1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        bar3D1.YValues.DataMember = "Bar";

        // 
        // cursorTool1
        // 
        cursorTool1.FastCursor = false;
        // 
        // 
        // 
        cursorTool1.Pen.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        cursorTool1.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Dash;
        cursorTool1.Series = line2;
        cursorTool1.SeriesIndex = -1;
        cursorTool1.Change += CursorTool1_Change;

        // tChart5
        tChart5.Aspect.Chart3DPercent = 90;
        tChart5.Aspect.ColorPaletteIndex = 21;
        tChart5.Aspect.Elevation = 348;
        tChart5.Aspect.ElevationFloat = 348D;
        tChart5.Aspect.Orthogonal = false;
        tChart5.Aspect.Perspective = 96;
        tChart5.Aspect.Rotation = 327;
        tChart5.Aspect.RotationFloat = 327D;
        tChart5.Aspect.View3D = true;
        tChart5.Aspect.Zoom = 63;
        tChart5.Aspect.ZoomFloat = 63D;
        // 
        tChart5.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.Bottom.Labels.Brush.Solid = true;
        tChart5.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart5.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Bottom.Labels.Font.Size = 8;
        tChart5.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.Bottom.Title.Brush.Solid = true;
        tChart5.Axes.Bottom.Title.Brush.Visible = true;
        tChart5.Axes.Bottom.Title.Caption = "m2 area";
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        tChart5.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart5.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Bottom.Title.Font.Size = 11;
        tChart5.Axes.Bottom.Title.Font.SizeFloat = 11F;
        tChart5.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        tChart5.Axes.Bottom.Title.Lines = new string[]
    {
    "m2 area"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Depth.Increment = 0.2D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.Depth.Labels.Brush.Solid = true;
        tChart5.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart5.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Depth.Labels.Font.Size = 8;
        tChart5.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.Depth.Title.Brush.Solid = true;
        tChart5.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart5.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Depth.Title.Font.Size = 8;
        tChart5.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart5.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.Depth.Title.Shadow.Brush.Visible = true;
        tChart5.Axes.Depth.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart5.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart5.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.DepthTop.Labels.Font.Size = 8;
        tChart5.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.DepthTop.Title.Brush.Solid = true;
        tChart5.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart5.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.DepthTop.Title.Font.Size = 8;
        tChart5.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart5.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.Left.Labels.Brush.Solid = true;
        tChart5.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart5.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Left.Labels.Font.Size = 8;
        tChart5.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.Left.Title.Brush.Solid = true;
        tChart5.Axes.Left.Title.Brush.Visible = true;
        tChart5.Axes.Left.Title.Caption = "ºC range";
        // 
        // 
        // 
        tChart5.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        tChart5.Axes.Left.Title.Font.Brush.Solid = true;
        tChart5.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Left.Title.Font.Size = 11;
        tChart5.Axes.Left.Title.Font.SizeFloat = 11F;
        tChart5.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        tChart5.Axes.Left.Title.Lines = new string[]
    {
    "ºC range"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.Right.Labels.Brush.Solid = true;
        tChart5.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart5.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Right.Labels.Font.Size = 8;
        tChart5.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.Right.Title.Brush.Solid = true;
        tChart5.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Axes.Right.Title.Font.Brush.Solid = true;
        tChart5.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Right.Title.Font.Size = 8;
        tChart5.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart5.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart5.Axes.Top.Labels.Brush.Solid = true;
        tChart5.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart5.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Top.Labels.Font.Size = 8;
        tChart5.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart5.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart5.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Axes.Top.Title.Brush.Solid = true;
        tChart5.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Axes.Top.Title.Font.Brush.Solid = true;
        tChart5.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Axes.Top.Title.Font.Size = 8;
        tChart5.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart5.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart5.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart5.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Footer.Alignment = Steema.TeeChart.Drawing.StringAlignment.Near;
        // 
        // 
        // 
        tChart5.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart5.Footer.Brush.Solid = true;
        tChart5.Footer.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart5.Footer.Font.Brush.Solid = true;
        tChart5.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Footer.Font.Shadow.Brush.Solid = true;
        tChart5.Footer.Font.Shadow.Brush.Visible = true;
        tChart5.Footer.Font.Size = 8;
        tChart5.Footer.Font.SizeFloat = 8F;
        tChart5.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Footer.ImageBevel.Brush.Solid = true;
        tChart5.Footer.ImageBevel.Brush.Visible = true;
        tChart5.Footer.Lines = new string[]
    {
    "Heat profile"
    };
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Footer.Shadow.Brush.Solid = true;
        tChart5.Footer.Shadow.Brush.Visible = true;
        tChart5.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart5.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Header.Brush.Gradient.SigmaScale = 0F;
        tChart5.Header.Brush.Solid = true;
        tChart5.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Header.Font.Brush.Solid = true;
        tChart5.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Header.Font.Shadow.Brush.Solid = true;
        tChart5.Header.Font.Shadow.Brush.Visible = true;
        tChart5.Header.Font.Size = 8;
        tChart5.Header.Font.SizeFloat = 8F;
        tChart5.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Header.ImageBevel.Brush.Solid = true;
        tChart5.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart5.Header.Shadow.Brush.Solid = true;
        tChart5.Header.Shadow.Brush.Visible = true;
        tChart5.Header.Shadow.Height = 0;
        tChart5.Header.Shadow.Width = 0;
        tChart5.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart5.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart5.Legend.Brush.Gradient.Visible = true;
        tChart5.Legend.Brush.Solid = true;
        tChart5.Legend.Brush.Visible = true;
        tChart5.Legend.CheckBoxes = false;
        tChart5.Legend.ClipText = false;
        // 
        // 
        // 
        tChart5.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart5.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart5.Legend.Font.Brush.Solid = true;
        tChart5.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Legend.Font.Shadow.Brush.Solid = true;
        tChart5.Legend.Font.Shadow.Brush.Visible = true;
        tChart5.Legend.Font.Size = 8;
        tChart5.Legend.Font.SizeFloat = 8F;
        tChart5.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Legend.ImageBevel.Brush.Solid = true;
        tChart5.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Legend.Shadow.Brush.Solid = true;
        tChart5.Legend.Shadow.Brush.Visible = true;
        tChart5.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart5.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart5.Legend.Title.Brush.Solid = true;
        tChart5.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart5.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart5.Legend.Title.Font.Brush.Solid = true;
        tChart5.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart5.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart5.Legend.Title.Font.Size = 8;
        tChart5.Legend.Title.Font.SizeFloat = 8F;
        tChart5.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart5.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Legend.Title.Shadow.Brush.Solid = true;
        tChart5.Legend.Title.Shadow.Brush.Visible = true;
        tChart5.Legend.Visible = false;
        //tChart5.Name = "tChart5";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart5.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart5.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart5.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart5.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart5.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart5.Panel.Brush.Gradient.UseMiddle = false;
        tChart5.Panel.Brush.Gradient.Visible = true;
        tChart5.Panel.Brush.Solid = true;
        tChart5.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Panel.ImageBevel.Brush.Solid = true;
        tChart5.Panel.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Panel.Shadow.Brush.Solid = true;
        tChart5.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.Series.Add(surface);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart5.SubFooter.Brush.Solid = true;
        tChart5.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart5.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart5.SubFooter.Font.Brush.Solid = true;
        tChart5.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart5.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart5.SubFooter.Font.Size = 8;
        tChart5.SubFooter.Font.SizeFloat = 8F;
        tChart5.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.SubFooter.ImageBevel.Brush.Solid = true;
        tChart5.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.SubFooter.Shadow.Brush.Solid = true;
        tChart5.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart5.SubHeader.Brush.Solid = true;
        tChart5.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart5.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart5.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart5.SubHeader.Font.Brush.Solid = true;
        tChart5.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart5.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart5.SubHeader.Font.Size = 12;
        tChart5.SubHeader.Font.SizeFloat = 12F;
        tChart5.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.SubHeader.ImageBevel.Brush.Solid = true;
        tChart5.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart5.SubHeader.Shadow.Brush.Solid = true;
        tChart5.SubHeader.Shadow.Brush.Visible = true;
        tChart5.TabIndex = 0;
        tChart5.Tools.Add(rotate1);
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart5.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart5.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart5.Walls.Back.Brush.Solid = true;
        tChart5.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart5.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Walls.Back.Shadow.Brush.Solid = true;
        tChart5.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart5.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart5.Walls.Bottom.Brush.Solid = true;
        tChart5.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart5.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart5.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart5.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart5.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart5.Walls.Left.Brush.Solid = true;
        tChart5.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart5.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Walls.Left.Shadow.Brush.Solid = true;
        tChart5.Walls.Left.Shadow.Brush.Visible = true;
        tChart5.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart5.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart5.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart5.Walls.Right.Brush.Solid = true;
        tChart5.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart5.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart5.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart5.Walls.Right.Shadow.Brush.Solid = true;
        tChart5.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart5.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart5.Zoom.Brush.Solid = true;
        tChart5.Zoom.Brush.Visible = false;
        // 
        // surface
        // 
        // 
        // 
        // 
        surface.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)220, (int)(byte)92, (int)(byte)5);
        surface.Brush.Solid = true;
        surface.Brush.Transparency = 30;
        surface.Brush.Visible = true;
        surface.Color = System.Drawing.Color.FromArgb((int)(byte)220, (int)(byte)92, (int)(byte)5);
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Legend.Brush.Color = System.Drawing.Color.White;
        surface.Legend.Brush.Solid = true;
        surface.Legend.Brush.Visible = true;
        // 
        // 
        // 
        surface.Legend.Font.Bold = false;
        // 
        // 
        // 
        surface.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        surface.Legend.Font.Brush.Solid = true;
        surface.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        surface.Legend.Font.Shadow.Brush.Solid = true;
        surface.Legend.Font.Shadow.Brush.Visible = true;
        surface.Legend.Font.Size = 8;
        surface.Legend.Font.SizeFloat = 8F;
        surface.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        surface.Legend.ImageBevel.Brush.Solid = true;
        surface.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        surface.Legend.Shadow.Brush.Solid = true;
        surface.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        surface.Marks.Brush.Solid = true;
        surface.Marks.Brush.Visible = true;
        // 
        // 
        // 
        surface.Marks.Font.Bold = false;
        // 
        // 
        // 
        surface.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        surface.Marks.Font.Brush.Solid = true;
        surface.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        surface.Marks.Font.Shadow.Brush.Solid = true;
        surface.Marks.Font.Shadow.Brush.Visible = true;
        surface.Marks.Font.Size = 8;
        surface.Marks.Font.SizeFloat = 8F;
        surface.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        surface.Marks.ImageBevel.Brush.Solid = true;
        surface.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        surface.Marks.Shadow.Brush.Solid = true;
        surface.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        surface.Marks.Symbol.Brush.Solid = true;
        surface.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        surface.Marks.Symbol.ImageBevel.Brush.Solid = true;
        surface.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        surface.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        surface.Marks.Symbol.Shadow.Brush.Solid = true;
        surface.Marks.Symbol.Shadow.Brush.Visible = true;
        surface.PaletteMin = 0D;
        surface.PaletteStep = 0D;
        surface.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
        // 
        // 
        // 
        surface.Pen.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        // 
        // 
        // 
        surface.SideBrush.Color = System.Drawing.Color.Black;
        surface.SideBrush.Solid = true;
        surface.SideBrush.Visible = false;
        surface.Title = "surface1";
        surface.UseColorRange = false;
        surface.UsePalette = true;
        // 
        // 
        // 
        surface.XValues.DataMember = "X";

        // 
        // 
        surface.YValues.DataMember = "Y";

        // 
        // 
        // 
        surface.ZValues.DataMember = "Z";
        // 
        // rotate1
        // 
        // 
        // 
        // 
        rotate1.Pen.Visible = false;
        // 
        // stdDeviation1
        // 
        stdDeviation1.Period = 4D;

        // tChart8
        tChart8.Aspect.ColorPaletteIndex = -1;
        // 
        // 
        tChart8.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.Bottom.Labels.Brush.Solid = true;
        tChart8.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart8.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Bottom.Labels.Font.Size = 8;
        tChart8.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.Bottom.Title.Brush.Solid = true;
        tChart8.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart8.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Bottom.Title.Font.Size = 8;
        tChart8.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart8.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.Depth.Labels.Brush.Solid = true;
        tChart8.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart8.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Depth.Labels.Font.Size = 8;
        tChart8.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.Depth.Title.Brush.Solid = true;
        tChart8.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart8.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Depth.Title.Font.Size = 8;
        tChart8.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart8.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart8.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart8.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.DepthTop.Labels.Font.Size = 8;
        tChart8.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.DepthTop.Title.Brush.Solid = true;
        tChart8.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart8.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.DepthTop.Title.Font.Size = 8;
        tChart8.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart8.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.Left.Labels.Brush.Solid = true;
        tChart8.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart8.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Left.Labels.Font.Size = 8;
        tChart8.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.Left.Title.Brush.Solid = true;
        tChart8.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.Left.Title.Font.Brush.Solid = true;
        tChart8.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Left.Title.Font.Size = 8;
        tChart8.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart8.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.Right.Labels.Brush.Solid = true;
        tChart8.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart8.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Right.Labels.Font.Size = 8;
        tChart8.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.Right.Title.Brush.Solid = true;
        tChart8.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.Right.Title.Font.Brush.Solid = true;
        tChart8.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Right.Title.Font.Size = 8;
        tChart8.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart8.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart8.Axes.Top.Labels.Brush.Solid = true;
        tChart8.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart8.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Top.Labels.Font.Size = 8;
        tChart8.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart8.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart8.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Axes.Top.Title.Brush.Solid = true;
        tChart8.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Axes.Top.Title.Font.Brush.Solid = true;
        tChart8.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Axes.Top.Title.Font.Size = 8;
        tChart8.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart8.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart8.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart8.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart8.Footer.Brush.Solid = true;
        tChart8.Footer.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Footer.Font.Brush.Color = System.Drawing.Color.Red;
        tChart8.Footer.Font.Brush.Solid = true;
        tChart8.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Footer.Font.Shadow.Brush.Solid = true;
        tChart8.Footer.Font.Shadow.Brush.Visible = true;
        tChart8.Footer.Font.Size = 8;
        tChart8.Footer.Font.SizeFloat = 8F;
        tChart8.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Footer.ImageBevel.Brush.Solid = true;
        tChart8.Footer.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Footer.Shadow.Brush.Solid = true;
        tChart8.Footer.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart8.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Header.Brush.Gradient.SigmaScale = 0F;
        tChart8.Header.Brush.Solid = true;
        tChart8.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Header.Font.Brush.Solid = true;
        tChart8.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Header.Font.Shadow.Brush.Solid = true;
        tChart8.Header.Font.Shadow.Brush.Visible = true;
        tChart8.Header.Font.Size = 8;
        tChart8.Header.Font.SizeFloat = 8F;
        tChart8.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Header.ImageBevel.Brush.Solid = true;
        tChart8.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart8.Header.Shadow.Brush.Solid = true;
        tChart8.Header.Shadow.Brush.Visible = true;
        tChart8.Header.Shadow.Height = 0;
        tChart8.Header.Shadow.Width = 0;
        tChart8.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart8.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart8.Legend.Brush.Gradient.Visible = true;
        tChart8.Legend.Brush.Solid = true;
        tChart8.Legend.Brush.Visible = true;
        tChart8.Legend.CheckBoxes = false;
        tChart8.Legend.ClipText = false;
        // 
        // 
        // 
        tChart8.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart8.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart8.Legend.Font.Brush.Solid = true;
        tChart8.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Legend.Font.Shadow.Brush.Solid = true;
        tChart8.Legend.Font.Shadow.Brush.Visible = true;
        tChart8.Legend.Font.Size = 8;
        tChart8.Legend.Font.SizeFloat = 8F;
        tChart8.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Legend.ImageBevel.Brush.Solid = true;
        tChart8.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Legend.Shadow.Brush.Solid = true;
        tChart8.Legend.Shadow.Brush.Visible = true;
        tChart8.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart8.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart8.Legend.Title.Brush.Solid = true;
        tChart8.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart8.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart8.Legend.Title.Font.Brush.Solid = true;
        tChart8.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart8.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart8.Legend.Title.Font.Size = 8;
        tChart8.Legend.Title.Font.SizeFloat = 8F;
        tChart8.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart8.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Legend.Title.Shadow.Brush.Solid = true;
        tChart8.Legend.Title.Shadow.Brush.Visible = true;
        tChart8.Legend.Visible = false;
        //tChart8.Name = "tChart8";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart8.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart8.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart8.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart8.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart8.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart8.Panel.Brush.Gradient.UseMiddle = false;
        tChart8.Panel.Brush.Gradient.Visible = true;
        tChart8.Panel.Brush.Solid = true;
        tChart8.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Panel.ImageBevel.Brush.Solid = true;
        tChart8.Panel.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Panel.Shadow.Brush.Solid = true;
        tChart8.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart8.SubFooter.Brush.Solid = true;
        tChart8.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart8.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart8.SubFooter.Font.Brush.Solid = true;
        tChart8.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart8.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart8.SubFooter.Font.Size = 8;
        tChart8.SubFooter.Font.SizeFloat = 8F;
        tChart8.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.SubFooter.ImageBevel.Brush.Solid = true;
        tChart8.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.SubFooter.Shadow.Brush.Solid = true;
        tChart8.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart8.SubHeader.AdjustFrame = false;
        tChart8.SubHeader.Alignment = Steema.TeeChart.Drawing.StringAlignment.Far;
        tChart8.SubHeader.Bottom = 42;
        // 
        // 
        // 
        tChart8.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart8.SubHeader.Brush.Solid = true;
        tChart8.SubHeader.Brush.Visible = true;
        tChart8.SubHeader.CustomPosition = true;
        // 
        // 
        // 
        tChart8.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart8.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart8.SubHeader.Font.Brush.Solid = true;
        tChart8.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart8.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart8.SubHeader.Font.Size = 8;
        tChart8.SubHeader.Font.SizeFloat = 8F;
        tChart8.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.SubHeader.ImageBevel.Brush.Solid = true;
        tChart8.SubHeader.ImageBevel.Brush.Visible = true;
        tChart8.SubHeader.Left = 616;
        tChart8.SubHeader.Lines = new string[]
    {
    "Resonance"
    };
        tChart8.SubHeader.Right = 684;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart8.SubHeader.Shadow.Brush.Solid = true;
        tChart8.SubHeader.Shadow.Brush.Visible = true;
        tChart8.SubHeader.Top = 27;
        tChart8.SubHeader.Visible = true;
        tChart8.TabIndex = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart8.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart8.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart8.Walls.Back.Brush.Solid = true;
        tChart8.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart8.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Walls.Back.Shadow.Brush.Solid = true;
        tChart8.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart8.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart8.Walls.Bottom.Brush.Solid = true;
        tChart8.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart8.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart8.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart8.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart8.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart8.Walls.Left.Brush.Solid = true;
        tChart8.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart8.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Walls.Left.Shadow.Brush.Solid = true;
        tChart8.Walls.Left.Shadow.Brush.Visible = true;
        tChart8.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart8.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart8.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart8.Walls.Right.Brush.Solid = true;
        tChart8.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart8.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart8.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart8.Walls.Right.Shadow.Brush.Solid = true;
        tChart8.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart8.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart8.Zoom.Brush.Solid = true;
        tChart8.Zoom.Brush.Visible = false;

        // tChart1
        tChart1.Aspect.ColorPaletteIndex = -1;
        tChart1.Aspect.Elevation = 315;
        tChart1.Aspect.ElevationFloat = 315D;
        tChart1.Aspect.Orthogonal = false;
        tChart1.Aspect.Perspective = 0;
        tChart1.Aspect.Rotation = 360;
        tChart1.Aspect.RotationFloat = 360D;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Bottom.Labels.Brush.Solid = true;
        tChart1.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart1.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Bottom.Labels.Font.Size = 8;
        tChart1.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.Bottom.Title.Brush.Solid = true;
        tChart1.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart1.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Bottom.Title.Font.Size = 8;
        tChart1.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart1.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Depth.Labels.Brush.Solid = true;
        tChart1.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart1.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Depth.Labels.Font.Size = 8;
        tChart1.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.Depth.Title.Brush.Solid = true;
        tChart1.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart1.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Depth.Title.Font.Size = 8;
        tChart1.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart1.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart1.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart1.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.DepthTop.Labels.Font.Size = 8;
        tChart1.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.DepthTop.Title.Brush.Solid = true;
        tChart1.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart1.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.DepthTop.Title.Font.Size = 8;
        tChart1.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart1.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.AxisPen.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Left.Labels.Brush.Solid = true;
        tChart1.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart1.Axes.Left.Labels.Font.Brush.Visible = true;
        tChart1.Axes.Left.Labels.Font.Name = "Yu Gothic";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Left.Labels.Font.Size = 8;
        tChart1.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Left.MinorTicks.Color = System.Drawing.Color.FromArgb((int)(byte)100, (int)(byte)100, (int)(byte)100);
        tChart1.Axes.Left.MinorTicks.Length = 1;
        tChart1.Axes.Left.MinorTicks.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Left.Ticks.Color = System.Drawing.Color.FromArgb((int)(byte)100, (int)(byte)100, (int)(byte)100);
        tChart1.Axes.Left.Ticks.Length = 12;
        tChart1.Axes.Left.Ticks.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.Left.Title.Brush.Solid = true;
        tChart1.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart1.Axes.Left.Title.Font.Brush.Solid = true;
        tChart1.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Left.Title.Font.Size = 8;
        tChart1.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart1.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Right.Labels.Brush.Solid = true;
        tChart1.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart1.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Right.Labels.Font.Size = 8;
        tChart1.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.Right.Title.Brush.Solid = true;
        tChart1.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Axes.Right.Title.Font.Brush.Solid = true;
        tChart1.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Right.Title.Font.Size = 8;
        tChart1.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart1.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart1.Axes.Top.Labels.Brush.Solid = true;
        tChart1.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart1.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Top.Labels.Font.Size = 8;
        tChart1.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart1.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart1.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Axes.Top.Title.Brush.Solid = true;
        tChart1.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Axes.Top.Title.Font.Brush.Solid = true;
        tChart1.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Axes.Top.Title.Font.Size = 8;
        tChart1.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart1.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart1.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart1.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Footer.Bottom = 176;
        // 
        // 
        // 
        tChart1.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart1.Footer.Brush.Solid = true;
        tChart1.Footer.Brush.Visible = true;
        tChart1.Footer.CustomPosition = true;
        // 
        // 
        // 
        tChart1.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart1.Footer.Font.Brush.Solid = true;
        tChart1.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Footer.Font.Shadow.Brush.Solid = true;
        tChart1.Footer.Font.Shadow.Brush.Visible = true;
        tChart1.Footer.Font.Size = 8;
        tChart1.Footer.Font.SizeFloat = 8F;
        tChart1.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Footer.ImageBevel.Brush.Solid = true;
        tChart1.Footer.ImageBevel.Brush.Visible = true;
        tChart1.Footer.Left = 6;
        tChart1.Footer.Lines = new string[]
    {
    "Flue Gen"
    };
        tChart1.Footer.Right = 72;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Footer.Shadow.Brush.Solid = true;
        tChart1.Footer.Shadow.Brush.Visible = true;
        tChart1.Footer.Top = 161;
        tChart1.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart1.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Header.Brush.Gradient.SigmaScale = 0F;
        tChart1.Header.Brush.Solid = true;
        tChart1.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Header.Font.Brush.Solid = true;
        tChart1.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Header.Font.Shadow.Brush.Solid = true;
        tChart1.Header.Font.Shadow.Brush.Visible = true;
        tChart1.Header.Font.Size = 8;
        tChart1.Header.Font.SizeFloat = 8F;
        tChart1.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Header.ImageBevel.Brush.Solid = true;
        tChart1.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart1.Header.Shadow.Brush.Solid = true;
        tChart1.Header.Shadow.Brush.Visible = true;
        tChart1.Header.Shadow.Height = 0;
        tChart1.Header.Shadow.Width = 0;
        tChart1.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart1.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart1.Legend.Brush.Gradient.Visible = true;
        tChart1.Legend.Brush.Solid = true;
        tChart1.Legend.Brush.Visible = true;
        tChart1.Legend.CheckBoxes = false;
        tChart1.Legend.ClipText = false;
        // 
        // 
        // 
        tChart1.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart1.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart1.Legend.Font.Brush.Solid = true;
        tChart1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Legend.Font.Shadow.Brush.Solid = true;
        tChart1.Legend.Font.Shadow.Brush.Visible = true;
        tChart1.Legend.Font.Size = 8;
        tChart1.Legend.Font.SizeFloat = 8F;
        tChart1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Legend.ImageBevel.Brush.Solid = true;
        tChart1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Legend.Shadow.Brush.Solid = true;
        tChart1.Legend.Shadow.Brush.Visible = true;
        tChart1.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart1.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart1.Legend.Title.Brush.Solid = true;
        tChart1.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart1.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart1.Legend.Title.Font.Brush.Solid = true;
        tChart1.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart1.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart1.Legend.Title.Font.Size = 8;
        tChart1.Legend.Title.Font.SizeFloat = 8F;
        tChart1.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart1.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Legend.Title.Shadow.Brush.Solid = true;
        tChart1.Legend.Title.Shadow.Brush.Visible = true;
        //tChart1.Name = "tChart1";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart1.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart1.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart1.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart1.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart1.Panel.Brush.Gradient.UseMiddle = false;
        tChart1.Panel.Brush.Gradient.Visible = true;
        tChart1.Panel.Brush.Solid = true;
        tChart1.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Panel.ImageBevel.Brush.Solid = true;
        tChart1.Panel.ImageBevel.Brush.Visible = true;
        tChart1.Panel.MarginBottom = 20D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Panel.Shadow.Brush.Solid = true;
        tChart1.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.Series.Add(circularGauge1);
        // 
        // 
        // 
        tChart1.SubFooter.Alignment = Steema.TeeChart.Drawing.StringAlignment.Near;
        tChart1.SubFooter.Bottom = 176;
        // 
        // 
        // 
        tChart1.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart1.SubFooter.Brush.Solid = true;
        tChart1.SubFooter.Brush.Visible = true;
        tChart1.SubFooter.CustomPosition = true;
        // 
        // 
        // 
        tChart1.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart1.SubFooter.Font.Brush.Color = System.Drawing.Color.Silver;
        tChart1.SubFooter.Font.Brush.Solid = true;
        tChart1.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart1.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart1.SubFooter.Font.Size = 8;
        tChart1.SubFooter.Font.SizeFloat = 8F;
        tChart1.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.SubFooter.ImageBevel.Brush.Solid = true;
        tChart1.SubFooter.ImageBevel.Brush.Visible = true;
        tChart1.SubFooter.Left = 6;
        tChart1.SubFooter.Right = 21;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.SubFooter.Shadow.Brush.Solid = true;
        tChart1.SubFooter.Shadow.Brush.Visible = true;
        tChart1.SubFooter.Top = 161;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart1.SubHeader.Brush.Solid = true;
        tChart1.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart1.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart1.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart1.SubHeader.Font.Brush.Solid = true;
        tChart1.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart1.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart1.SubHeader.Font.Size = 12;
        tChart1.SubHeader.Font.SizeFloat = 12F;
        tChart1.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.SubHeader.ImageBevel.Brush.Solid = true;
        tChart1.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart1.SubHeader.Shadow.Brush.Solid = true;
        tChart1.SubHeader.Shadow.Brush.Visible = true;
        tChart1.TabIndex = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart1.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart1.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart1.Walls.Back.Brush.Solid = true;
        tChart1.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart1.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Walls.Back.Shadow.Brush.Solid = true;
        tChart1.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart1.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart1.Walls.Bottom.Brush.Solid = true;
        tChart1.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart1.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart1.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart1.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart1.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart1.Walls.Left.Brush.Solid = true;
        tChart1.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart1.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Walls.Left.Shadow.Brush.Solid = true;
        tChart1.Walls.Left.Shadow.Brush.Visible = true;
        tChart1.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart1.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart1.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart1.Walls.Right.Brush.Solid = true;
        tChart1.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart1.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart1.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart1.Walls.Right.Shadow.Brush.Solid = true;
        tChart1.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart1.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart1.Zoom.Brush.Solid = true;
        tChart1.Zoom.Brush.Visible = false;
        tChart1.AfterDraw += TChart1_AfterDraw;
        tChart1.BeforeDrawAxes += TChart1_BeforeDrawAxes;

        // circularGauge1
        // 
        // 
        // 
        // 
        circularGauge1.Brush.Color = System.Drawing.Color.Empty;
        circularGauge1.Brush.Solid = true;
        circularGauge1.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Center.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)130, (int)(byte)130, (int)(byte)130);
        circularGauge1.Center.Brush.Solid = true;
        circularGauge1.Center.Brush.Visible = true;
        circularGauge1.Center.HorizSize = 16;
        // 
        // 
        // 
        circularGauge1.Center.Pen.Color = System.Drawing.Color.FromArgb((int)(byte)130, (int)(byte)130, (int)(byte)130);
        circularGauge1.Center.Pen.Width = 2;
        circularGauge1.Center.Position = 0;
        circularGauge1.Center.Spiralled = false;
        circularGauge1.Center.VertSize = 16;
        circularGauge1.Center.Visible = true;
        circularGauge1.Circled = true;
        circularGauge1.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineEndValues.Add(100D);
        circularGauge1.ColorLineEndValues.Add(70D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(73D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(75D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        circularGauge1.ColorLineStartValues.Add(80D);
        circularGauge1.ColorLineStartValues.Add(0D);
        // 
        // 
        // 
        circularGauge1.FaceBrush.Color = System.Drawing.Color.FromArgb((int)(byte)15, (int)(byte)15, (int)(byte)15);
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.FaceBrush.Gradient.Style.CenterXOffset = 26;
        circularGauge1.FaceBrush.Gradient.Style.CenterYOffset = -26;
        circularGauge1.FaceBrush.Gradient.Style.Direction = Steema.TeeChart.Drawing.PathGradientMode.Radial;
        circularGauge1.FaceBrush.Gradient.Style.Visible = true;
        circularGauge1.FaceBrush.Gradient.Visible = true;
        circularGauge1.FaceBrush.Solid = true;
        circularGauge1.FaceBrush.Visible = true;
        // 
        // 
        // 
        circularGauge1.Frame.Circled = true;
        circularGauge1.Frame.FrameElementPercents = new double[]
    {
    39D,
    47D,
    13.06928673489992D
    };
        // 
        // 
        // 
        circularGauge1.Frame.InnerBand.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        circularGauge1.Frame.InnerBand.Solid = true;
        circularGauge1.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        circularGauge1.Frame.OuterBand.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        // 
        // 
        // 
        circularGauge1.Frame.OuterBand.Gradient.UseMiddle = true;
        circularGauge1.Frame.OuterBand.Gradient.Visible = true;
        circularGauge1.Frame.OuterBand.Solid = true;
        circularGauge1.Frame.OuterBand.Visible = true;
        circularGauge1.Frame.Visible = false;
        circularGauge1.Frame.Width = 9;
        circularGauge1.HandDistances.Add(80);
        circularGauge1.HandOffsets.Add(30);
        circularGauge1.LabelsInside = false;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Legend.Brush.Color = System.Drawing.Color.White;
        circularGauge1.Legend.Brush.Solid = true;
        circularGauge1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.Legend.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.Legend.Font.Brush.Solid = true;
        circularGauge1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.Legend.Font.Shadow.Brush.Solid = true;
        circularGauge1.Legend.Font.Shadow.Brush.Visible = true;
        circularGauge1.Legend.Font.Size = 8;
        circularGauge1.Legend.Font.SizeFloat = 8F;
        circularGauge1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.Legend.ImageBevel.Brush.Solid = true;
        circularGauge1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.Legend.Shadow.Brush.Solid = true;
        circularGauge1.Legend.Shadow.Brush.Visible = true;
        circularGauge1.Legend.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        circularGauge1.Marks.Brush.Solid = true;
        circularGauge1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.Marks.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.Marks.Font.Brush.Solid = true;
        circularGauge1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.Marks.Font.Shadow.Brush.Solid = true;
        circularGauge1.Marks.Font.Shadow.Brush.Visible = true;
        circularGauge1.Marks.Font.Size = 8;
        circularGauge1.Marks.Font.SizeFloat = 8F;
        circularGauge1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.Marks.ImageBevel.Brush.Solid = true;
        circularGauge1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
        circularGauge1.Marks.Shadow.Brush.Solid = true;
        circularGauge1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        circularGauge1.Marks.Symbol.Brush.Solid = true;
        circularGauge1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        circularGauge1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.Marks.Symbol.Shadow.Brush.Solid = true;
        circularGauge1.Marks.Symbol.Shadow.Brush.Visible = true;
        circularGauge1.Maximum = 100D;
        circularGauge1.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.MinorTicks.Brush.Color = System.Drawing.Color.Transparent;
        // 
        // 
        // 
        circularGauge1.MinorTicks.Brush.Gradient.Transparency = 100;
        circularGauge1.MinorTicks.Brush.Solid = true;
        circularGauge1.MinorTicks.Brush.Visible = true;
        circularGauge1.MinorTicks.HorizSize = 1;
        circularGauge1.MinorTicks.Position = 0;
        circularGauge1.MinorTicks.Spiralled = false;
        circularGauge1.MinorTicks.VertSize = 1;
        circularGauge1.MinorTicks.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Brush.Color = System.Drawing.Color.Empty;
        circularGauge1.NumericGauge.Brush.Solid = true;
        circularGauge1.NumericGauge.Brush.Visible = true;
        circularGauge1.NumericGauge.Color = System.Drawing.Color.Empty;
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineEndValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        circularGauge1.NumericGauge.ColorLineStartValues.Add(0D);
        // 
        // 
        // 
        circularGauge1.NumericGauge.FaceBrush.Color = System.Drawing.Color.FromArgb((int)(byte)170, (int)(byte)170, (int)(byte)130);
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.FaceBrush.Gradient.Style.Direction = Steema.TeeChart.Drawing.PathGradientMode.Radial;
        circularGauge1.NumericGauge.FaceBrush.Gradient.Style.Visible = true;
        circularGauge1.NumericGauge.FaceBrush.Gradient.Visible = true;
        circularGauge1.NumericGauge.FaceBrush.Solid = true;
        circularGauge1.NumericGauge.FaceBrush.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Frame.Circled = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Frame.InnerBand.Color = System.Drawing.Color.FromArgb((int)(byte)40, (int)(byte)40, (int)(byte)40);
        circularGauge1.NumericGauge.Frame.InnerBand.Solid = true;
        circularGauge1.NumericGauge.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Frame.OuterBand.Color = System.Drawing.Color.FromArgb((int)(byte)40, (int)(byte)40, (int)(byte)40);
        // 
        // 
        // 
        circularGauge1.NumericGauge.Frame.OuterBand.Gradient.UseMiddle = true;
        circularGauge1.NumericGauge.Frame.OuterBand.Gradient.Visible = true;
        circularGauge1.NumericGauge.Frame.OuterBand.Solid = true;
        circularGauge1.NumericGauge.Frame.OuterBand.Visible = true;

        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.GreenLine.Brush.Color = System.Drawing.Color.Black;
        // 
        // 
        // 
        circularGauge1.NumericGauge.GreenLine.Brush.Gradient.Sigma = true;
        circularGauge1.NumericGauge.GreenLine.Brush.Gradient.SigmaFocus = 0F;
        circularGauge1.NumericGauge.GreenLine.Brush.Gradient.UseMiddle = false;
        circularGauge1.NumericGauge.GreenLine.Brush.Solid = true;
        circularGauge1.NumericGauge.GreenLine.Brush.Visible = true;
        circularGauge1.NumericGauge.GreenLine.Position = 0;
        circularGauge1.NumericGauge.GreenLine.Spiralled = false;
        circularGauge1.NumericGauge.GreenLine.VertSize = 5;
        circularGauge1.NumericGauge.GreenLine.Visible = true;
        circularGauge1.NumericGauge.GreenLineEndValue = 0D;
        circularGauge1.NumericGauge.GreenLineStartValue = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Hand.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)0, (int)(byte)0);
        circularGauge1.NumericGauge.Hand.Brush.Solid = true;
        circularGauge1.NumericGauge.Hand.Brush.Visible = true;
        circularGauge1.NumericGauge.Hand.Position = 0;
        circularGauge1.NumericGauge.Hand.Spiralled = false;
        circularGauge1.NumericGauge.Hand.Visible = true;
        circularGauge1.NumericGauge.HorizAxis = Steema.TeeChart.Styles.HorizontalAxis.Custom;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.Brush.Color = System.Drawing.Color.White;
        circularGauge1.NumericGauge.Legend.Brush.Solid = true;
        circularGauge1.NumericGauge.Legend.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.NumericGauge.Legend.Font.Brush.Solid = true;
        circularGauge1.NumericGauge.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.Legend.Font.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.Legend.Font.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.Legend.Font.Size = 8;
        circularGauge1.NumericGauge.Legend.Font.SizeFloat = 8F;
        circularGauge1.NumericGauge.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.Legend.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.Legend.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        circularGauge1.NumericGauge.Marks.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        circularGauge1.NumericGauge.Marks.Font.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.Marks.Font.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Font.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.Marks.Font.Size = 8;
        circularGauge1.NumericGauge.Marks.Font.SizeFloat = 8F;
        circularGauge1.NumericGauge.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.Marks.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        circularGauge1.NumericGauge.Marks.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        circularGauge1.NumericGauge.Marks.Symbol.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.Marks.Symbol.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.Marks.Symbol.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.Marks.Symbol.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.Maximum = global::System.Double.PositiveInfinity;
        circularGauge1.NumericGauge.Minimum = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.MinorTicks.Brush.Color = System.Drawing.Color.Transparent;
        circularGauge1.NumericGauge.MinorTicks.Brush.Solid = true;
        circularGauge1.NumericGauge.MinorTicks.Brush.Visible = true;
        circularGauge1.NumericGauge.MinorTicks.HorizSize = 1;
        circularGauge1.NumericGauge.MinorTicks.Position = 0;
        circularGauge1.NumericGauge.MinorTicks.Spiralled = false;
        circularGauge1.NumericGauge.MinorTicks.VertSize = 1;
        circularGauge1.NumericGauge.MinorTicks.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.RedLine.Brush.Color = System.Drawing.Color.Black;
        // 
        // 
        // 
        circularGauge1.NumericGauge.RedLine.Brush.Gradient.Sigma = true;
        circularGauge1.NumericGauge.RedLine.Brush.Gradient.SigmaFocus = 0F;
        circularGauge1.NumericGauge.RedLine.Brush.Solid = true;
        circularGauge1.NumericGauge.RedLine.Brush.Visible = true;
        circularGauge1.NumericGauge.RedLine.Position = 0;
        circularGauge1.NumericGauge.RedLine.Spiralled = false;
        circularGauge1.NumericGauge.RedLine.VertSize = 5;
        circularGauge1.NumericGauge.RedLine.Visible = true;
        circularGauge1.NumericGauge.RedLineEndValue = 0D;
        circularGauge1.NumericGauge.RedLineStartValue = 0D;
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Active = false;
        circularGauge1.NumericGauge.TextMarker.AutoSize = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        circularGauge1.NumericGauge.TextMarker.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
        circularGauge1.NumericGauge.TextMarker.Callout.ArrowHeadSize = 8;
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Callout.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.NumericGauge.TextMarker.Callout.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Callout.Brush.Visible = true;
        circularGauge1.NumericGauge.TextMarker.Callout.Distance = 0;
        circularGauge1.NumericGauge.TextMarker.Callout.Draw3D = false;
        circularGauge1.NumericGauge.TextMarker.Callout.XPosition = 0;
        circularGauge1.NumericGauge.TextMarker.Callout.YPosition = 0;
        circularGauge1.NumericGauge.TextMarker.Callout.ZPosition = 0;
        circularGauge1.NumericGauge.TextMarker.Centered = false;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)40, (int)(byte)40, (int)(byte)40);
        circularGauge1.NumericGauge.TextMarker.Shape.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)170, (int)(byte)170, (int)(byte)130);
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Brush.Visible = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Name = "DS-Digital";
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Size = 11;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.SizeFloat = 11F;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        circularGauge1.NumericGauge.TextMarker.Shape.Font.UsePrivateFont = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.TextMarker.Shape.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Shape.ImageBevel.Brush.Visible = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Lines = new string[]
    {
    "FREQ"
    };
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Pen.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.TextMarker.Shape.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        circularGauge1.NumericGauge.TextMarker.Shape.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.TextMarker.Shape.Shadow.Visible = false;
        circularGauge1.NumericGauge.TextMarker.Text = "FREQ";
        circularGauge1.NumericGauge.TextMarker.TextAlign = Steema.TeeChart.Drawing.StringAlignment.Center;
        circularGauge1.NumericGauge.TextMarker.UsePalette = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.Ticks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        circularGauge1.NumericGauge.Ticks.Brush.Solid = true;
        circularGauge1.NumericGauge.Ticks.Brush.Visible = true;
        circularGauge1.NumericGauge.Ticks.Position = 0;
        circularGauge1.NumericGauge.Ticks.Spiralled = false;
        circularGauge1.NumericGauge.Ticks.VertSize = 20;
        circularGauge1.NumericGauge.Ticks.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Active = false;
        circularGauge1.NumericGauge.UnitsMarker.AutoSize = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        circularGauge1.NumericGauge.UnitsMarker.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
        circularGauge1.NumericGauge.UnitsMarker.Callout.ArrowHeadSize = 8;
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Callout.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.NumericGauge.UnitsMarker.Callout.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Callout.Brush.Visible = true;
        circularGauge1.NumericGauge.UnitsMarker.Callout.Distance = 0;
        circularGauge1.NumericGauge.UnitsMarker.Callout.Draw3D = false;
        circularGauge1.NumericGauge.UnitsMarker.Callout.XPosition = 0;
        circularGauge1.NumericGauge.UnitsMarker.Callout.YPosition = 0;
        circularGauge1.NumericGauge.UnitsMarker.Callout.ZPosition = 0;
        circularGauge1.NumericGauge.UnitsMarker.Centered = false;
        circularGauge1.NumericGauge.UnitsMarker.Position = Steema.TeeChart.Tools.AnnotationPositions.LeftBottom;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)170, (int)(byte)170, (int)(byte)130);
        circularGauge1.NumericGauge.UnitsMarker.Shape.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Brush.Visible = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Bold = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)40, (int)(byte)40, (int)(byte)40);
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Brush.Visible = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Name = "DS-Digital";
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Size = 18;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.SizeFloat = 18F;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Font.UsePrivateFont = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.UnitsMarker.Shape.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.ImageBevel.Brush.Visible = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Lines = new string[]
    {
    "MHz"
    };
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Pen.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.UnitsMarker.Shape.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        circularGauge1.NumericGauge.UnitsMarker.Shape.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.UnitsMarker.Shape.Shadow.Visible = false;
        circularGauge1.NumericGauge.UnitsMarker.Text = "MHz";
        circularGauge1.NumericGauge.UnitsMarker.TextAlign = Steema.TeeChart.Drawing.StringAlignment.Center;
        circularGauge1.NumericGauge.UnitsMarker.UsePalette = true;
        circularGauge1.NumericGauge.Value = 24.5123920145037D;
        circularGauge1.NumericGauge.ValueFormat = "N";
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Active = false;
        circularGauge1.NumericGauge.ValueMarker.AutoSize = false;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        circularGauge1.NumericGauge.ValueMarker.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
        circularGauge1.NumericGauge.ValueMarker.Callout.ArrowHeadSize = 8;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Callout.Brush.Color = System.Drawing.Color.Black;
        circularGauge1.NumericGauge.ValueMarker.Callout.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Callout.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Callout.Distance = 0;
        circularGauge1.NumericGauge.ValueMarker.Callout.Draw3D = false;
        circularGauge1.NumericGauge.ValueMarker.Callout.XPosition = 0;
        circularGauge1.NumericGauge.ValueMarker.Callout.YPosition = 0;
        circularGauge1.NumericGauge.ValueMarker.Callout.ZPosition = 0;
        circularGauge1.NumericGauge.ValueMarker.Centered = true;
        circularGauge1.NumericGauge.ValueMarker.Height = 18;
        circularGauge1.NumericGauge.ValueMarker.Left = 82;
        circularGauge1.NumericGauge.ValueMarker.Position = Steema.TeeChart.Tools.AnnotationPositions.Custom;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Bottom = 152;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)170, (int)(byte)170, (int)(byte)130);
        circularGauge1.NumericGauge.ValueMarker.Shape.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.CustomPosition = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Bold = true;
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Name = "DS-Digital";
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Size = 12;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.SizeFloat = 12F;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        circularGauge1.NumericGauge.ValueMarker.Shape.Font.UsePrivateFont = true;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        circularGauge1.NumericGauge.ValueMarker.Shape.ImageBevel.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.ImageBevel.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Left = 82;
        circularGauge1.NumericGauge.ValueMarker.Shape.Lines = new string[]
    {
    "24.51"
    };
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Pen.Visible = false;
        circularGauge1.NumericGauge.ValueMarker.Shape.Right = 112;
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.NumericGauge.ValueMarker.Shape.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        circularGauge1.NumericGauge.ValueMarker.Shape.Shadow.Brush.Solid = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Shadow.Brush.Visible = true;
        circularGauge1.NumericGauge.ValueMarker.Shape.Shadow.Visible = false;
        circularGauge1.NumericGauge.ValueMarker.Shape.Top = 134;
        circularGauge1.NumericGauge.ValueMarker.Text = "24.51";
        circularGauge1.NumericGauge.ValueMarker.TextAlign = Steema.TeeChart.Drawing.StringAlignment.Far;
        circularGauge1.NumericGauge.ValueMarker.Top = 134;
        circularGauge1.NumericGauge.ValueMarker.UsePalette = false;
        circularGauge1.NumericGauge.ValueMarker.Width = 30;
        circularGauge1.NumericGauge.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom;
        // 
        // 
        // 
        circularGauge1.NumericGauge.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        // 
        // 
        // 
        // 
        // 
        circularGauge1.Ticks.Brush.Color = System.Drawing.Color.Transparent;
        // 
        // 
        // 
        circularGauge1.Ticks.Brush.Gradient.Transparency = 100;
        circularGauge1.Ticks.Brush.Solid = true;
        circularGauge1.Ticks.Brush.Visible = true;
        circularGauge1.Ticks.Position = 0;
        circularGauge1.Ticks.Spiralled = false;
        circularGauge1.Ticks.VertSize = 12;
        circularGauge1.Ticks.Visible = true;
        circularGauge1.Title = "circularGauge1";
        circularGauge1.TotalAngle = 300D;
        circularGauge1.UniqueCustomRadius = true;
        circularGauge1.Value = 44.2240265984547D;
        // 
        // 
        // 
        circularGauge1.XValues.DataMember = "Angle";
        circularGauge1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        circularGauge1.YValues.DataMember = "Y";

        // tChart9
        tChart9.Aspect.ColorPaletteIndex = -1;
        tChart9.Aspect.Elevation = 315;
        tChart9.Aspect.ElevationFloat = 315D;
        tChart9.Aspect.Orthogonal = false;
        tChart9.Aspect.Perspective = 0;
        tChart9.Aspect.Rotation = 360;
        tChart9.Aspect.RotationFloat = 360D;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.Bottom.Labels.Brush.Solid = true;
        tChart9.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart9.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Bottom.Labels.Font.Size = 8;
        tChart9.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.Bottom.Title.Brush.Solid = true;
        tChart9.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart9.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Bottom.Title.Font.Size = 8;
        tChart9.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart9.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.Depth.Labels.Brush.Solid = true;
        tChart9.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart9.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Depth.Labels.Font.Size = 8;
        tChart9.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.Depth.Title.Brush.Solid = true;
        tChart9.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart9.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Depth.Title.Font.Size = 8;
        tChart9.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart9.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart9.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart9.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.DepthTop.Labels.Font.Size = 8;
        tChart9.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.DepthTop.Title.Brush.Solid = true;
        tChart9.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart9.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.DepthTop.Title.Font.Size = 8;
        tChart9.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart9.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.Left.Labels.Brush.Solid = true;
        tChart9.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart9.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Left.Labels.Font.Size = 8;
        tChart9.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.Left.Title.Brush.Solid = true;
        tChart9.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.Left.Title.Font.Brush.Solid = true;
        tChart9.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Left.Title.Font.Size = 8;
        tChart9.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart9.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.Right.Labels.Brush.Solid = true;
        tChart9.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart9.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Right.Labels.Font.Size = 8;
        tChart9.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.Right.Title.Brush.Solid = true;
        tChart9.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.Right.Title.Font.Brush.Solid = true;
        tChart9.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Right.Title.Font.Size = 8;
        tChart9.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart9.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart9.Axes.Top.Labels.Brush.Solid = true;
        tChart9.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart9.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Top.Labels.Font.Size = 8;
        tChart9.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart9.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart9.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart9.Axes.Top.Title.Brush.Solid = true;
        tChart9.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Axes.Top.Title.Font.Brush.Solid = true;
        tChart9.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Axes.Top.Title.Font.Size = 8;
        tChart9.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart9.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart9.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart9.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Footer.Bottom = 186;
        // 
        // 
        // 
        tChart9.Footer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        tChart9.Footer.Brush.Solid = true;
        tChart9.Footer.Brush.Visible = true;
        tChart9.Footer.CustomPosition = true;
        // 
        // 
        // 
        tChart9.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart9.Footer.Font.Brush.Solid = true;
        tChart9.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Footer.Font.Shadow.Brush.Solid = true;
        tChart9.Footer.Font.Shadow.Brush.Visible = true;
        tChart9.Footer.Font.Size = 8;
        tChart9.Footer.Font.SizeFloat = 8F;
        tChart9.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Footer.ImageBevel.Brush.Solid = true;
        tChart9.Footer.ImageBevel.Brush.Visible = true;
        tChart9.Footer.Left = 6;
        tChart9.Footer.Lines = new string[]
    {
    "Oven 4"
    };
        tChart9.Footer.Right = 64;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Footer.Shadow.Brush.Solid = true;
        tChart9.Footer.Shadow.Brush.Visible = true;
        tChart9.Footer.Top = 171;
        tChart9.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart9.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Header.Brush.Gradient.SigmaScale = 0F;
        tChart9.Header.Brush.Solid = true;
        tChart9.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Header.Font.Brush.Solid = true;
        tChart9.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Header.Font.Shadow.Brush.Solid = true;
        tChart9.Header.Font.Shadow.Brush.Visible = true;
        tChart9.Header.Font.Size = 8;
        tChart9.Header.Font.SizeFloat = 8F;
        tChart9.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Header.ImageBevel.Brush.Solid = true;
        tChart9.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart9.Header.Shadow.Brush.Solid = true;
        tChart9.Header.Shadow.Brush.Visible = true;
        tChart9.Header.Shadow.Height = 0;
        tChart9.Header.Shadow.Width = 0;
        tChart9.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart9.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart9.Legend.Brush.Gradient.Visible = true;
        tChart9.Legend.Brush.Solid = true;
        tChart9.Legend.Brush.Visible = true;
        tChart9.Legend.CheckBoxes = false;
        tChart9.Legend.ClipText = false;
        // 
        // 
        // 
        tChart9.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart9.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart9.Legend.Font.Brush.Solid = true;
        tChart9.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Legend.Font.Shadow.Brush.Solid = true;
        tChart9.Legend.Font.Shadow.Brush.Visible = true;
        tChart9.Legend.Font.Size = 8;
        tChart9.Legend.Font.SizeFloat = 8F;
        tChart9.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Legend.ImageBevel.Brush.Solid = true;
        tChart9.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Legend.Shadow.Brush.Solid = true;
        tChart9.Legend.Shadow.Brush.Visible = true;
        tChart9.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart9.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart9.Legend.Title.Brush.Solid = true;
        tChart9.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart9.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart9.Legend.Title.Font.Brush.Solid = true;
        tChart9.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart9.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart9.Legend.Title.Font.Size = 8;
        tChart9.Legend.Title.Font.SizeFloat = 8F;
        tChart9.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart9.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Legend.Title.Shadow.Brush.Solid = true;
        tChart9.Legend.Title.Shadow.Brush.Visible = true;
        tChart9.Legend.Visible = false;
        //tChart9.Name = "tChart9";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart9.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart9.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart9.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart9.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart9.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart9.Panel.Brush.Gradient.UseMiddle = false;
        tChart9.Panel.Brush.Gradient.Visible = true;
        tChart9.Panel.Brush.Solid = true;
        tChart9.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Panel.ImageBevel.Brush.Solid = true;
        tChart9.Panel.ImageBevel.Brush.Visible = true;
        tChart9.Panel.MarginBottom = 2D;
        tChart9.Panel.MarginLeft = 7D;
        tChart9.Panel.MarginRight = 7D;
        tChart9.Panel.MarginTop = 6D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Panel.Shadow.Brush.Solid = true;
        tChart9.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.Series.Add(donut4);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart9.SubFooter.Brush.Solid = true;
        tChart9.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart9.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart9.SubFooter.Font.Brush.Solid = true;
        tChart9.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart9.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart9.SubFooter.Font.Size = 8;
        tChart9.SubFooter.Font.SizeFloat = 8F;
        tChart9.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.SubFooter.ImageBevel.Brush.Solid = true;
        tChart9.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.SubFooter.Shadow.Brush.Solid = true;
        tChart9.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart9.SubHeader.Brush.Solid = true;
        tChart9.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart9.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart9.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart9.SubHeader.Font.Brush.Solid = true;
        tChart9.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart9.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart9.SubHeader.Font.Size = 12;
        tChart9.SubHeader.Font.SizeFloat = 12F;
        tChart9.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.SubHeader.ImageBevel.Brush.Solid = true;
        tChart9.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart9.SubHeader.Shadow.Brush.Solid = true;
        tChart9.SubHeader.Shadow.Brush.Visible = true;
        tChart9.TabIndex = 4;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart9.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart9.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart9.Walls.Back.Brush.Solid = true;
        tChart9.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart9.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Walls.Back.Shadow.Brush.Solid = true;
        tChart9.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart9.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart9.Walls.Bottom.Brush.Solid = true;
        tChart9.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart9.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart9.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart9.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart9.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart9.Walls.Left.Brush.Solid = true;
        tChart9.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart9.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Walls.Left.Shadow.Brush.Solid = true;
        tChart9.Walls.Left.Shadow.Brush.Visible = true;
        tChart9.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart9.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart9.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart9.Walls.Right.Brush.Solid = true;
        tChart9.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart9.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart9.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart9.Walls.Right.Shadow.Brush.Solid = true;
        tChart9.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart9.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart9.Zoom.Brush.Solid = true;
        tChart9.Zoom.Brush.Visible = false;
        tChart9.AfterDraw += TChart9_AfterDraw;
        tChart9.BeforeDrawAxes += TChart9_BeforeDrawAxes;
        // 
        // donut4
        // 
        // 
        // 
        // 
        donut4.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)243, (int)(byte)144);
        donut4.Brush.Solid = true;
        donut4.Brush.Visible = true;
        donut4.Circled = true;
        donut4.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        donut4.Frame.Circled = true;
        donut4.Frame.FrameElementPercents = new double[]
    {
    25D,
    60D,
    15D
    };
        // 
        // 
        // 
        donut4.Frame.InnerBand.Color = System.Drawing.Color.Gray;
        donut4.Frame.InnerBand.Solid = true;
        donut4.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        donut4.Frame.OuterBand.Color = System.Drawing.Color.Gray;
        // 
        // 
        // 
        donut4.Frame.OuterBand.Gradient.Visible = true;
        donut4.Frame.OuterBand.Solid = true;
        donut4.Frame.OuterBand.Visible = true;
        donut4.LabelMember = "Labels";
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Legend.Brush.Color = System.Drawing.Color.White;
        donut4.Legend.Brush.Solid = true;
        donut4.Legend.Brush.Visible = true;
        // 
        // 
        // 
        donut4.Legend.Font.Bold = false;
        // 
        // 
        // 
        donut4.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        donut4.Legend.Font.Brush.Solid = true;
        donut4.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut4.Legend.Font.Shadow.Brush.Solid = true;
        donut4.Legend.Font.Shadow.Brush.Visible = true;
        donut4.Legend.Font.Size = 8;
        donut4.Legend.Font.SizeFloat = 8F;
        donut4.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut4.Legend.ImageBevel.Brush.Solid = true;
        donut4.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut4.Legend.Shadow.Brush.Solid = true;
        donut4.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Arrow.Color = System.Drawing.Color.Black;
        // 
        // 
        // 
        donut4.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        donut4.Marks.Brush.Solid = true;
        donut4.Marks.Brush.Visible = true;
        // 
        // 
        // 
        donut4.Marks.Font.Bold = false;
        // 
        // 
        // 
        donut4.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        donut4.Marks.Font.Brush.Solid = true;
        donut4.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut4.Marks.Font.Shadow.Brush.Solid = true;
        donut4.Marks.Font.Shadow.Brush.Visible = true;
        donut4.Marks.Font.Size = 8;
        donut4.Marks.Font.SizeFloat = 8F;
        donut4.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut4.Marks.ImageBevel.Brush.Solid = true;
        donut4.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        donut4.Marks.Shadow.Brush.Solid = true;
        donut4.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        donut4.Marks.Symbol.Brush.Solid = true;
        donut4.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut4.Marks.Symbol.ImageBevel.Brush.Solid = true;
        donut4.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut4.Marks.Symbol.Shadow.Brush.Solid = true;
        donut4.Marks.Symbol.Shadow.Brush.Visible = true;
        donut4.Marks.Visible = false;
        // 
        // 
        // 
        donut4.MarksPie.InsideSlice = false;
        donut4.MarksPie.LegSize = 0;
        donut4.MarksPie.Rotated = false;
        donut4.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        donut4.MarksPie.VertCenter = false;
        donut4.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        // 
        // 
        // 
        donut4.OtherSlice.Color = System.Drawing.Color.Empty;
        donut4.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        donut4.OtherSlice.Text = "";
        donut4.OtherSlice.Value = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        donut4.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut4.Shadow.Brush.Solid = true;
        donut4.Shadow.Brush.Visible = true;
        donut4.Title = "donut1";
        donut4.UniqueCustomRadius = true;
        // 
        // 
        // 
        donut4.XValues.DataMember = "Angle";

        // 
        // 
        donut4.YValues.DataMember = "Pie";

        // tChart4
        tChart4.Aspect.ColorPaletteIndex = -1;
        tChart4.Aspect.Elevation = 315;
        tChart4.Aspect.ElevationFloat = 315D;
        tChart4.Aspect.Orthogonal = false;
        tChart4.Aspect.Perspective = 0;
        tChart4.Aspect.Rotation = 360;
        tChart4.Aspect.RotationFloat = 360D;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.Bottom.Labels.Brush.Solid = true;
        tChart4.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart4.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Bottom.Labels.Font.Size = 8;
        tChart4.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.Bottom.Title.Brush.Solid = true;
        tChart4.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart4.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Bottom.Title.Font.Size = 8;
        tChart4.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart4.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.Depth.Labels.Brush.Solid = true;
        tChart4.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart4.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Depth.Labels.Font.Size = 8;
        tChart4.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.Depth.Title.Brush.Solid = true;
        tChart4.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart4.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Depth.Title.Font.Size = 8;
        tChart4.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart4.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart4.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart4.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.DepthTop.Labels.Font.Size = 8;
        tChart4.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.DepthTop.Title.Brush.Solid = true;
        tChart4.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart4.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.DepthTop.Title.Font.Size = 8;
        tChart4.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart4.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.Left.Labels.Brush.Solid = true;
        tChart4.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart4.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Left.Labels.Font.Size = 8;
        tChart4.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.Left.Title.Brush.Solid = true;
        tChart4.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.Left.Title.Font.Brush.Solid = true;
        tChart4.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Left.Title.Font.Size = 8;
        tChart4.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart4.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.Right.Labels.Brush.Solid = true;
        tChart4.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart4.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Right.Labels.Font.Size = 8;
        tChart4.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.Right.Title.Brush.Solid = true;
        tChart4.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.Right.Title.Font.Brush.Solid = true;
        tChart4.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Right.Title.Font.Size = 8;
        tChart4.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart4.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart4.Axes.Top.Labels.Brush.Solid = true;
        tChart4.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart4.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Top.Labels.Font.Size = 8;
        tChart4.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart4.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart4.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart4.Axes.Top.Title.Brush.Solid = true;
        tChart4.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Axes.Top.Title.Font.Brush.Solid = true;
        tChart4.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Axes.Top.Title.Font.Size = 8;
        tChart4.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart4.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart4.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart4.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Footer.Bottom = 176;
        // 
        // 
        // 
        tChart4.Footer.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)224, (int)(byte)224, (int)(byte)224);
        tChart4.Footer.Brush.Solid = true;
        tChart4.Footer.Brush.Visible = true;
        tChart4.Footer.CustomPosition = true;
        // 
        // 
        // 
        tChart4.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart4.Footer.Font.Brush.Solid = true;
        tChart4.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Footer.Font.Shadow.Brush.Solid = true;
        tChart4.Footer.Font.Shadow.Brush.Visible = true;
        tChart4.Footer.Font.Size = 8;
        tChart4.Footer.Font.SizeFloat = 8F;
        tChart4.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Footer.ImageBevel.Brush.Solid = true;
        tChart4.Footer.ImageBevel.Brush.Visible = true;
        tChart4.Footer.Left = 6;
        tChart4.Footer.Lines = new string[]
    {
    "Oven 3"
    };
        tChart4.Footer.Right = 64;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Footer.Shadow.Brush.Solid = true;
        tChart4.Footer.Shadow.Brush.Visible = true;
        tChart4.Footer.Top = 161;
        tChart4.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart4.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Header.Brush.Gradient.SigmaScale = 0F;
        tChart4.Header.Brush.Solid = true;
        tChart4.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Header.Font.Brush.Solid = true;
        tChart4.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Header.Font.Shadow.Brush.Solid = true;
        tChart4.Header.Font.Shadow.Brush.Visible = true;
        tChart4.Header.Font.Size = 8;
        tChart4.Header.Font.SizeFloat = 8F;
        tChart4.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Header.ImageBevel.Brush.Solid = true;
        tChart4.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart4.Header.Shadow.Brush.Solid = true;
        tChart4.Header.Shadow.Brush.Visible = true;
        tChart4.Header.Shadow.Height = 0;
        tChart4.Header.Shadow.Width = 0;
        tChart4.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart4.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart4.Legend.Brush.Gradient.Visible = true;
        tChart4.Legend.Brush.Solid = true;
        tChart4.Legend.Brush.Visible = true;
        tChart4.Legend.CheckBoxes = false;
        tChart4.Legend.ClipText = false;
        // 
        // 
        // 
        tChart4.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart4.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart4.Legend.Font.Brush.Solid = true;
        tChart4.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Legend.Font.Shadow.Brush.Solid = true;
        tChart4.Legend.Font.Shadow.Brush.Visible = true;
        tChart4.Legend.Font.Size = 8;
        tChart4.Legend.Font.SizeFloat = 8F;
        tChart4.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Legend.ImageBevel.Brush.Solid = true;
        tChart4.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Legend.Shadow.Brush.Solid = true;
        tChart4.Legend.Shadow.Brush.Visible = true;
        tChart4.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart4.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart4.Legend.Title.Brush.Solid = true;
        tChart4.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart4.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart4.Legend.Title.Font.Brush.Solid = true;
        tChart4.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart4.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart4.Legend.Title.Font.Size = 8;
        tChart4.Legend.Title.Font.SizeFloat = 8F;
        tChart4.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart4.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Legend.Title.Shadow.Brush.Solid = true;
        tChart4.Legend.Title.Shadow.Brush.Visible = true;
        tChart4.Legend.Visible = false;
        //tChart4.Name = "tChart4";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart4.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart4.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart4.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart4.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart4.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart4.Panel.Brush.Gradient.UseMiddle = false;
        tChart4.Panel.Brush.Gradient.Visible = true;
        tChart4.Panel.Brush.Solid = true;
        tChart4.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Panel.ImageBevel.Brush.Solid = true;
        tChart4.Panel.ImageBevel.Brush.Visible = true;
        tChart4.Panel.MarginBottom = 2D;
        tChart4.Panel.MarginLeft = 7D;
        tChart4.Panel.MarginRight = 7D;
        tChart4.Panel.MarginTop = 6D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Panel.Shadow.Brush.Solid = true;
        tChart4.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.Series.Add(donut3);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart4.SubFooter.Brush.Solid = true;
        tChart4.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart4.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart4.SubFooter.Font.Brush.Solid = true;
        tChart4.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart4.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart4.SubFooter.Font.Size = 8;
        tChart4.SubFooter.Font.SizeFloat = 8F;
        tChart4.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.SubFooter.ImageBevel.Brush.Solid = true;
        tChart4.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.SubFooter.Shadow.Brush.Solid = true;
        tChart4.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart4.SubHeader.Brush.Solid = true;
        tChart4.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart4.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart4.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart4.SubHeader.Font.Brush.Solid = true;
        tChart4.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart4.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart4.SubHeader.Font.Size = 12;
        tChart4.SubHeader.Font.SizeFloat = 12F;
        tChart4.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.SubHeader.ImageBevel.Brush.Solid = true;
        tChart4.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart4.SubHeader.Shadow.Brush.Solid = true;
        tChart4.SubHeader.Shadow.Brush.Visible = true;
        tChart4.TabIndex = 3;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart4.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart4.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart4.Walls.Back.Brush.Solid = true;
        tChart4.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart4.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Walls.Back.Shadow.Brush.Solid = true;
        tChart4.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart4.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart4.Walls.Bottom.Brush.Solid = true;
        tChart4.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart4.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart4.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart4.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart4.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart4.Walls.Left.Brush.Solid = true;
        tChart4.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart4.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Walls.Left.Shadow.Brush.Solid = true;
        tChart4.Walls.Left.Shadow.Brush.Visible = true;
        tChart4.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart4.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart4.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart4.Walls.Right.Brush.Solid = true;
        tChart4.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart4.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart4.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart4.Walls.Right.Shadow.Brush.Solid = true;
        tChart4.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart4.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart4.Zoom.Brush.Solid = true;
        tChart4.Zoom.Brush.Visible = false;
        tChart4.AfterDraw += TChart4_AfterDraw;
        // 
        // donut3
        // 
        // 
        // 
        // 
        donut3.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)243, (int)(byte)144);
        donut3.Brush.Solid = true;
        donut3.Brush.Visible = true;
        donut3.Circled = true;
        donut3.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        donut3.Frame.Circled = true;
        donut3.Frame.FrameElementPercents = new double[]
    {
    25D,
    60D,
    15D
    };
        // 
        // 
        // 
        donut3.Frame.InnerBand.Color = System.Drawing.Color.Gray;
        donut3.Frame.InnerBand.Solid = true;
        donut3.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        donut3.Frame.OuterBand.Color = System.Drawing.Color.Gray;
        // 
        // 
        // 
        donut3.Frame.OuterBand.Gradient.Visible = true;
        donut3.Frame.OuterBand.Solid = true;
        donut3.Frame.OuterBand.Visible = true;
        donut3.LabelMember = "Labels";
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Legend.Brush.Color = System.Drawing.Color.White;
        donut3.Legend.Brush.Solid = true;
        donut3.Legend.Brush.Visible = true;
        // 
        // 
        // 
        donut3.Legend.Font.Bold = false;
        // 
        // 
        // 
        donut3.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        donut3.Legend.Font.Brush.Solid = true;
        donut3.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut3.Legend.Font.Shadow.Brush.Solid = true;
        donut3.Legend.Font.Shadow.Brush.Visible = true;
        donut3.Legend.Font.Size = 8;
        donut3.Legend.Font.SizeFloat = 8F;
        donut3.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut3.Legend.ImageBevel.Brush.Solid = true;
        donut3.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut3.Legend.Shadow.Brush.Solid = true;
        donut3.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Arrow.Color = System.Drawing.Color.Black;
        // 
        // 
        // 
        donut3.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        donut3.Marks.Brush.Solid = true;
        donut3.Marks.Brush.Visible = true;
        // 
        // 
        // 
        donut3.Marks.Font.Bold = false;
        // 
        // 
        // 
        donut3.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        donut3.Marks.Font.Brush.Solid = true;
        donut3.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut3.Marks.Font.Shadow.Brush.Solid = true;
        donut3.Marks.Font.Shadow.Brush.Visible = true;
        donut3.Marks.Font.Size = 8;
        donut3.Marks.Font.SizeFloat = 8F;
        donut3.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut3.Marks.ImageBevel.Brush.Solid = true;
        donut3.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        donut3.Marks.Shadow.Brush.Solid = true;
        donut3.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        donut3.Marks.Symbol.Brush.Solid = true;
        donut3.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut3.Marks.Symbol.ImageBevel.Brush.Solid = true;
        donut3.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut3.Marks.Symbol.Shadow.Brush.Solid = true;
        donut3.Marks.Symbol.Shadow.Brush.Visible = true;
        donut3.Marks.Visible = false;
        // 
        // 
        // 
        donut3.MarksPie.InsideSlice = false;
        donut3.MarksPie.LegSize = 0;
        donut3.MarksPie.Rotated = false;
        donut3.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        donut3.MarksPie.VertCenter = false;
        donut3.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        // 
        // 
        // 
        donut3.OtherSlice.Color = System.Drawing.Color.Empty;
        donut3.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        donut3.OtherSlice.Text = "";
        donut3.OtherSlice.Value = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        donut3.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut3.Shadow.Brush.Solid = true;
        donut3.Shadow.Brush.Visible = true;
        donut3.Title = "donut1";
        donut3.UniqueCustomRadius = true;
        // 
        // 
        // 
        donut3.XValues.DataMember = "Angle";
        donut3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
        // 
        // 
        donut3.YValues.DataMember = "Pie";

        // tChart3
        tChart3.Aspect.ColorPaletteIndex = -1;
        tChart3.Aspect.Elevation = 315;
        tChart3.Aspect.ElevationFloat = 315D;
        tChart3.Aspect.Orthogonal = false;
        tChart3.Aspect.Perspective = 0;
        tChart3.Aspect.Rotation = 360;
        tChart3.Aspect.RotationFloat = 360D;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.Bottom.Labels.Brush.Solid = true;
        tChart3.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart3.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Bottom.Labels.Font.Size = 8;
        tChart3.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.Bottom.Title.Brush.Solid = true;
        tChart3.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart3.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Bottom.Title.Font.Size = 8;
        tChart3.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart3.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.Depth.Labels.Brush.Solid = true;
        tChart3.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart3.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Depth.Labels.Font.Size = 8;
        tChart3.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.Depth.Title.Brush.Solid = true;
        tChart3.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart3.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Depth.Title.Font.Size = 8;
        tChart3.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart3.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart3.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart3.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.DepthTop.Labels.Font.Size = 8;
        tChart3.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.DepthTop.Title.Brush.Solid = true;
        tChart3.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart3.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.DepthTop.Title.Font.Size = 8;
        tChart3.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart3.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.Left.Labels.Brush.Solid = true;
        tChart3.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart3.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Left.Labels.Font.Size = 8;
        tChart3.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.Left.Title.Brush.Solid = true;
        tChart3.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.Left.Title.Font.Brush.Solid = true;
        tChart3.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Left.Title.Font.Size = 8;
        tChart3.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart3.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.Right.Labels.Brush.Solid = true;
        tChart3.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart3.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Right.Labels.Font.Size = 8;
        tChart3.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.Right.Title.Brush.Solid = true;
        tChart3.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.Right.Title.Font.Brush.Solid = true;
        tChart3.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Right.Title.Font.Size = 8;
        tChart3.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart3.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart3.Axes.Top.Labels.Brush.Solid = true;
        tChart3.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart3.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Top.Labels.Font.Size = 8;
        tChart3.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart3.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart3.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Axes.Top.Title.Brush.Solid = true;
        tChart3.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Axes.Top.Title.Font.Brush.Solid = true;
        tChart3.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Axes.Top.Title.Font.Size = 8;
        tChart3.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart3.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart3.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart3.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Footer.Bottom = 176;
        // 
        // 
        // 
        tChart3.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Footer.Brush.Solid = true;
        tChart3.Footer.Brush.Visible = true;
        tChart3.Footer.CustomPosition = true;
        // 
        // 
        // 
        tChart3.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Footer.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart3.Footer.Font.Brush.Solid = true;
        tChart3.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Footer.Font.Shadow.Brush.Solid = true;
        tChart3.Footer.Font.Shadow.Brush.Visible = true;
        tChart3.Footer.Font.Size = 8;
        tChart3.Footer.Font.SizeFloat = 8F;
        tChart3.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Footer.ImageBevel.Brush.Solid = true;
        tChart3.Footer.ImageBevel.Brush.Visible = true;
        tChart3.Footer.Left = 6;
        tChart3.Footer.Lines = new string[]
    {
    "Oven 2"
    };
        tChart3.Footer.Right = 64;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Footer.Shadow.Brush.Solid = true;
        tChart3.Footer.Shadow.Brush.Visible = true;
        tChart3.Footer.Top = 161;
        tChart3.Footer.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart3.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Header.Brush.Gradient.SigmaScale = 0F;
        tChart3.Header.Brush.Solid = true;
        tChart3.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Header.Font.Brush.Color = System.Drawing.Color.Silver;
        tChart3.Header.Font.Brush.Solid = true;
        tChart3.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Header.Font.Shadow.Brush.Solid = true;
        tChart3.Header.Font.Shadow.Brush.Visible = true;
        tChart3.Header.Font.Size = 8;
        tChart3.Header.Font.SizeFloat = 8F;
        tChart3.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Header.ImageBevel.Brush.Solid = true;
        tChart3.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart3.Header.Shadow.Brush.Solid = true;
        tChart3.Header.Shadow.Brush.Visible = true;
        tChart3.Header.Shadow.Height = 0;
        tChart3.Header.Shadow.Width = 0;
        tChart3.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart3.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart3.Legend.Brush.Gradient.Visible = true;
        tChart3.Legend.Brush.Solid = true;
        tChart3.Legend.Brush.Visible = true;
        tChart3.Legend.CheckBoxes = false;
        tChart3.Legend.ClipText = false;
        // 
        // 
        // 
        tChart3.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart3.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart3.Legend.Font.Brush.Solid = true;
        tChart3.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Legend.Font.Shadow.Brush.Solid = true;
        tChart3.Legend.Font.Shadow.Brush.Visible = true;
        tChart3.Legend.Font.Size = 8;
        tChart3.Legend.Font.SizeFloat = 8F;
        tChart3.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Legend.ImageBevel.Brush.Solid = true;
        tChart3.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Legend.Shadow.Brush.Solid = true;
        tChart3.Legend.Shadow.Brush.Visible = true;
        tChart3.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart3.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart3.Legend.Title.Brush.Solid = true;
        tChart3.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart3.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart3.Legend.Title.Font.Brush.Solid = true;
        tChart3.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart3.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart3.Legend.Title.Font.Size = 8;
        tChart3.Legend.Title.Font.SizeFloat = 8F;
        tChart3.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart3.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Legend.Title.Shadow.Brush.Solid = true;
        tChart3.Legend.Title.Shadow.Brush.Visible = true;
        tChart3.Legend.Visible = false;
        //tChart3.Name = "tChart3";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart3.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart3.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart3.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart3.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart3.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart3.Panel.Brush.Gradient.UseMiddle = false;
        tChart3.Panel.Brush.Gradient.Visible = true;
        tChart3.Panel.Brush.Solid = true;
        tChart3.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Panel.ImageBevel.Brush.Solid = true;
        tChart3.Panel.ImageBevel.Brush.Visible = true;
        tChart3.Panel.MarginBottom = 2D;
        tChart3.Panel.MarginLeft = 7D;
        tChart3.Panel.MarginRight = 7D;
        tChart3.Panel.MarginTop = 6D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Panel.Shadow.Brush.Solid = true;
        tChart3.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.Series.Add(donut2);
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubFooter.Brush.Color = System.Drawing.Color.Silver;
        tChart3.SubFooter.Brush.Solid = true;
        tChart3.SubFooter.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart3.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
        tChart3.SubFooter.Font.Brush.Solid = true;
        tChart3.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart3.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart3.SubFooter.Font.Size = 8;
        tChart3.SubFooter.Font.SizeFloat = 8F;
        tChart3.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.SubFooter.ImageBevel.Brush.Solid = true;
        tChart3.SubFooter.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.SubFooter.Shadow.Brush.Solid = true;
        tChart3.SubFooter.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart3.SubHeader.Brush.Solid = true;
        tChart3.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart3.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart3.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart3.SubHeader.Font.Brush.Solid = true;
        tChart3.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart3.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart3.SubHeader.Font.Size = 12;
        tChart3.SubHeader.Font.SizeFloat = 12F;
        tChart3.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.SubHeader.ImageBevel.Brush.Solid = true;
        tChart3.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart3.SubHeader.Shadow.Brush.Solid = true;
        tChart3.SubHeader.Shadow.Brush.Visible = true;
        tChart3.TabIndex = 2;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart3.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart3.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart3.Walls.Back.Brush.Solid = true;
        tChart3.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart3.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Walls.Back.Shadow.Brush.Solid = true;
        tChart3.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart3.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart3.Walls.Bottom.Brush.Solid = true;
        tChart3.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart3.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart3.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart3.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart3.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart3.Walls.Left.Brush.Solid = true;
        tChart3.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart3.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Walls.Left.Shadow.Brush.Solid = true;
        tChart3.Walls.Left.Shadow.Brush.Visible = true;
        tChart3.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart3.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart3.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart3.Walls.Right.Brush.Solid = true;
        tChart3.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart3.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart3.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart3.Walls.Right.Shadow.Brush.Solid = true;
        tChart3.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart3.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart3.Zoom.Brush.Solid = true;
        tChart3.Zoom.Brush.Visible = false;
        tChart3.AfterDraw += TChart3_AfterDraw;

        // 
        // donut2
        // 
        // 
        // 
        // 
        donut2.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)243, (int)(byte)144);
        donut2.Brush.Solid = true;
        donut2.Brush.Visible = true;
        donut2.Circled = true;
        donut2.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        // 
        // 
        // 
        donut2.Frame.Circled = true;
        donut2.Frame.FrameElementPercents = new double[]
    {
    25D,
    60D,
    15D
    };
        // 
        // 
        // 
        donut2.Frame.InnerBand.Color = System.Drawing.Color.Gray;
        donut2.Frame.InnerBand.Solid = true;
        donut2.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        donut2.Frame.OuterBand.Color = System.Drawing.Color.Gray;
        // 
        // 
        // 
        donut2.Frame.OuterBand.Gradient.Visible = true;
        donut2.Frame.OuterBand.Solid = true;
        donut2.Frame.OuterBand.Visible = true;
        donut2.LabelMember = "Labels";
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Legend.Brush.Color = System.Drawing.Color.White;
        donut2.Legend.Brush.Solid = true;
        donut2.Legend.Brush.Visible = true;
        // 
        // 
        // 
        donut2.Legend.Font.Bold = false;
        // 
        // 
        // 
        donut2.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        donut2.Legend.Font.Brush.Solid = true;
        donut2.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut2.Legend.Font.Shadow.Brush.Solid = true;
        donut2.Legend.Font.Shadow.Brush.Visible = true;
        donut2.Legend.Font.Size = 8;
        donut2.Legend.Font.SizeFloat = 8F;
        donut2.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut2.Legend.ImageBevel.Brush.Solid = true;
        donut2.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut2.Legend.Shadow.Brush.Solid = true;
        donut2.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Arrow.Color = System.Drawing.Color.Black;
        // 
        // 
        // 
        donut2.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        donut2.Marks.Brush.Solid = true;
        donut2.Marks.Brush.Visible = true;
        // 
        // 
        // 
        donut2.Marks.Font.Bold = false;
        // 
        // 
        // 
        donut2.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        donut2.Marks.Font.Brush.Solid = true;
        donut2.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut2.Marks.Font.Shadow.Brush.Solid = true;
        donut2.Marks.Font.Shadow.Brush.Visible = true;
        donut2.Marks.Font.Size = 8;
        donut2.Marks.Font.SizeFloat = 8F;
        donut2.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut2.Marks.ImageBevel.Brush.Solid = true;
        donut2.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        donut2.Marks.Shadow.Brush.Solid = true;
        donut2.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        donut2.Marks.Symbol.Brush.Solid = true;
        donut2.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut2.Marks.Symbol.ImageBevel.Brush.Solid = true;
        donut2.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut2.Marks.Symbol.Shadow.Brush.Solid = true;
        donut2.Marks.Symbol.Shadow.Brush.Visible = true;
        donut2.Marks.Visible = false;
        // 
        // 
        // 
        donut2.MarksPie.InsideSlice = false;
        donut2.MarksPie.LegSize = 0;
        donut2.MarksPie.Rotated = false;
        donut2.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        donut2.MarksPie.VertCenter = false;
        donut2.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        // 
        // 
        // 
        donut2.OtherSlice.Color = System.Drawing.Color.Empty;
        donut2.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        donut2.OtherSlice.Text = "";
        donut2.OtherSlice.Value = 0D;
        // 
        // 
        // 
        // 
        // 
        // 
        donut2.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut2.Shadow.Brush.Solid = true;
        donut2.Shadow.Brush.Visible = true;
        donut2.Title = "donut1";
        donut2.UniqueCustomRadius = true;
        // 
        // 
        // 
        donut2.XValues.DataMember = "Angle";
        donut2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        // 
        // 
        donut2.YValues.DataMember = "Pie";

        // tChart2
        tChart2.Aspect.ColorPaletteIndex = -1;
        tChart2.Aspect.Elevation = 315;
        tChart2.Aspect.ElevationFloat = 315D;
        tChart2.Aspect.Orthogonal = false;
        tChart2.Aspect.Perspective = 0;
        tChart2.Aspect.Rotation = 360;
        tChart2.Aspect.RotationFloat = 360D;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.Bottom.Labels.Brush.Solid = true;
        tChart2.Axes.Bottom.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.Bottom.Labels.Font.Brush.Solid = true;
        tChart2.Axes.Bottom.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Bottom.Labels.Font.Size = 8;
        tChart2.Axes.Bottom.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.Bottom.Title.Brush.Solid = true;
        tChart2.Axes.Bottom.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.Bottom.Title.Font.Brush.Solid = true;
        tChart2.Axes.Bottom.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Bottom.Title.Font.Size = 8;
        tChart2.Axes.Bottom.Title.Font.SizeFloat = 8F;
        tChart2.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Bottom.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.Bottom.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.Depth.Labels.Brush.Solid = true;
        tChart2.Axes.Depth.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.Depth.Labels.Font.Brush.Solid = true;
        tChart2.Axes.Depth.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Depth.Labels.Font.Size = 8;
        tChart2.Axes.Depth.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Depth.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.Depth.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.Depth.Title.Brush.Solid = true;
        tChart2.Axes.Depth.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.Depth.Title.Font.Brush.Solid = true;
        tChart2.Axes.Depth.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Depth.Title.Font.Size = 8;
        tChart2.Axes.Depth.Title.Font.SizeFloat = 8F;
        tChart2.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Depth.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.Depth.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.DepthTop.Labels.Brush.Solid = true;
        tChart2.Axes.DepthTop.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.DepthTop.Labels.Font.Brush.Solid = true;
        tChart2.Axes.DepthTop.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.DepthTop.Labels.Font.Size = 8;
        tChart2.Axes.DepthTop.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.DepthTop.Title.Brush.Solid = true;
        tChart2.Axes.DepthTop.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.DepthTop.Title.Font.Brush.Solid = true;
        tChart2.Axes.DepthTop.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.DepthTop.Title.Font.Size = 8;
        tChart2.Axes.DepthTop.Title.Font.SizeFloat = 8F;
        tChart2.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.Left.Labels.Brush.Solid = true;
        tChart2.Axes.Left.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.Left.Labels.Font.Brush.Solid = true;
        tChart2.Axes.Left.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Left.Labels.Font.Size = 8;
        tChart2.Axes.Left.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Left.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.Left.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.Left.Title.Brush.Solid = true;
        tChart2.Axes.Left.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Left.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.Left.Title.Font.Brush.Solid = true;
        tChart2.Axes.Left.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Left.Title.Font.Size = 8;
        tChart2.Axes.Left.Title.Font.SizeFloat = 8F;
        tChart2.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Left.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Left.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Left.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.Left.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.Right.Labels.Brush.Solid = true;
        tChart2.Axes.Right.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.Right.Labels.Font.Brush.Solid = true;
        tChart2.Axes.Right.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Right.Labels.Font.Size = 8;
        tChart2.Axes.Right.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Right.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.Right.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.Right.Title.Brush.Solid = true;
        tChart2.Axes.Right.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Right.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.Right.Title.Font.Brush.Solid = true;
        tChart2.Axes.Right.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Right.Title.Font.Size = 8;
        tChart2.Axes.Right.Title.Font.SizeFloat = 8F;
        tChart2.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Right.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Right.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Right.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.Right.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
        tChart2.Axes.Top.Labels.Brush.Solid = true;
        tChart2.Axes.Top.Labels.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Axes.Top.Labels.Font.Brush.Solid = true;
        tChart2.Axes.Top.Labels.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Top.Labels.Font.Size = 8;
        tChart2.Axes.Top.Labels.Font.SizeFloat = 8F;
        tChart2.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Top.Labels.Shadow.Brush.Solid = true;
        tChart2.Axes.Top.Labels.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Axes.Top.Title.Brush.Solid = true;
        tChart2.Axes.Top.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Axes.Top.Title.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Axes.Top.Title.Font.Brush.Solid = true;
        tChart2.Axes.Top.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Axes.Top.Title.Font.Size = 8;
        tChart2.Axes.Top.Title.Font.SizeFloat = 8F;
        tChart2.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Axes.Top.Title.ImageBevel.Brush.Solid = true;
        tChart2.Axes.Top.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Axes.Top.Title.Shadow.Brush.Solid = true;
        tChart2.Axes.Top.Title.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Footer.Brush.Color = System.Drawing.Color.Silver;
        tChart2.Footer.Brush.Solid = true;
        tChart2.Footer.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Footer.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Footer.Font.Brush.Color = System.Drawing.Color.Red;
        tChart2.Footer.Font.Brush.Solid = true;
        tChart2.Footer.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Footer.Font.Shadow.Brush.Solid = true;
        tChart2.Footer.Font.Shadow.Brush.Visible = true;
        tChart2.Footer.Font.Size = 8;
        tChart2.Footer.Font.SizeFloat = 8F;
        tChart2.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Footer.ImageBevel.Brush.Solid = true;
        tChart2.Footer.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Footer.Shadow.Brush.Solid = true;
        tChart2.Footer.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Header.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart2.Header.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Header.Brush.Gradient.SigmaScale = 0F;
        tChart2.Header.Brush.Solid = true;
        tChart2.Header.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Header.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Header.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Header.Font.Brush.Solid = true;
        tChart2.Header.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Header.Font.Shadow.Brush.Solid = true;
        tChart2.Header.Font.Shadow.Brush.Visible = true;
        tChart2.Header.Font.Size = 8;
        tChart2.Header.Font.SizeFloat = 8F;
        tChart2.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Header.ImageBevel.Brush.Solid = true;
        tChart2.Header.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart2.Header.Shadow.Brush.Solid = true;
        tChart2.Header.Shadow.Brush.Visible = true;
        tChart2.Header.Shadow.Height = 0;
        tChart2.Header.Shadow.Width = 0;
        tChart2.Header.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart2.Legend.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Legend.Brush.Gradient.SigmaScale = 0F;
        tChart2.Legend.Brush.Gradient.Visible = true;
        tChart2.Legend.Brush.Solid = true;
        tChart2.Legend.Brush.Visible = true;
        tChart2.Legend.ClipText = false;
        // 
        // 
        // 
        tChart2.Legend.Font.Bold = false;
        // 
        // 
        // 
        tChart2.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        tChart2.Legend.Font.Brush.Solid = true;
        tChart2.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Legend.Font.Shadow.Brush.Solid = true;
        tChart2.Legend.Font.Shadow.Brush.Visible = true;
        tChart2.Legend.Font.Size = 8;
        tChart2.Legend.Font.SizeFloat = 8F;
        tChart2.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Legend.ImageBevel.Brush.Solid = true;
        tChart2.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Legend.Shadow.Brush.Solid = true;
        tChart2.Legend.Shadow.Brush.Visible = true;
        tChart2.Legend.Shadow.Width = 0;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Legend.Symbol.Shadow.Brush.Solid = true;
        tChart2.Legend.Symbol.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Title.Brush.Color = System.Drawing.Color.White;
        tChart2.Legend.Title.Brush.Solid = true;
        tChart2.Legend.Title.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Legend.Title.Font.Bold = true;
        // 
        // 
        // 
        tChart2.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
        tChart2.Legend.Title.Font.Brush.Solid = true;
        tChart2.Legend.Title.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Legend.Title.Font.Shadow.Brush.Solid = true;
        tChart2.Legend.Title.Font.Shadow.Brush.Visible = true;
        tChart2.Legend.Title.Font.Size = 8;
        tChart2.Legend.Title.Font.SizeFloat = 8F;
        tChart2.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Legend.Title.ImageBevel.Brush.Solid = true;
        tChart2.Legend.Title.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Legend.Title.Shadow.Brush.Solid = true;
        tChart2.Legend.Title.Shadow.Brush.Visible = true;
        tChart2.Legend.Visible = false;
        //tChart2.Name = "tChart2";
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.Raised;
        // 
        // 
        // 
        tChart2.Panel.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)240, (int)(byte)240, (int)(byte)240);
        // 
        // 
        // 
        tChart2.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart2.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0, (int)(byte)0);
        tChart2.Panel.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Panel.Brush.Gradient.SigmaScale = 0F;
        tChart2.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart2.Panel.Brush.Gradient.UseMiddle = false;
        tChart2.Panel.Brush.Gradient.Visible = true;
        tChart2.Panel.Brush.Solid = true;
        tChart2.Panel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Panel.ImageBevel.Brush.Solid = true;
        tChart2.Panel.ImageBevel.Brush.Visible = true;
        tChart2.Panel.MarginBottom = 2D;
        tChart2.Panel.MarginLeft = 7D;
        tChart2.Panel.MarginRight = 7D;
        tChart2.Panel.MarginTop = 6D;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Panel.Shadow.Brush.Solid = true;
        tChart2.Panel.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.Series.Add(donut1);
        // 
        // 
        // 
        tChart2.SubFooter.AdjustFrame = false;
        tChart2.SubFooter.Bottom = 176;
        // 
        // 
        // 
        tChart2.SubFooter.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)192);
        tChart2.SubFooter.Brush.Solid = true;
        tChart2.SubFooter.Brush.Visible = true;
        tChart2.SubFooter.CustomPosition = true;
        // 
        // 
        // 
        tChart2.SubFooter.Font.Bold = false;
        // 
        // 
        // 
        tChart2.SubFooter.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart2.SubFooter.Font.Brush.Solid = true;
        tChart2.SubFooter.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.SubFooter.Font.Shadow.Brush.Solid = true;
        tChart2.SubFooter.Font.Shadow.Brush.Visible = true;
        tChart2.SubFooter.Font.Size = 8;
        tChart2.SubFooter.Font.SizeFloat = 8F;
        tChart2.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.SubFooter.ImageBevel.Brush.Solid = true;
        tChart2.SubFooter.ImageBevel.Brush.Visible = true;
        tChart2.SubFooter.Left = 6;
        tChart2.SubFooter.Lines = new string[]
    {
    "Oven 1"
    };
        tChart2.SubFooter.Right = 181;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.SubFooter.Shadow.Brush.Solid = true;
        tChart2.SubFooter.Shadow.Brush.Visible = true;
        tChart2.SubFooter.Top = 161;
        tChart2.SubFooter.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubHeader.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        tChart2.SubHeader.Brush.Solid = true;
        tChart2.SubHeader.Brush.Visible = true;
        // 
        // 
        // 
        tChart2.SubHeader.Font.Bold = false;
        // 
        // 
        // 
        tChart2.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        tChart2.SubHeader.Font.Brush.Solid = true;
        tChart2.SubHeader.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.SubHeader.Font.Shadow.Brush.Solid = true;
        tChart2.SubHeader.Font.Shadow.Brush.Visible = true;
        tChart2.SubHeader.Font.Size = 12;
        tChart2.SubHeader.Font.SizeFloat = 12F;
        tChart2.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.SubHeader.ImageBevel.Brush.Solid = true;
        tChart2.SubHeader.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)169, (int)(byte)169, (int)(byte)169);
        tChart2.SubHeader.Shadow.Brush.Solid = true;
        tChart2.SubHeader.Shadow.Brush.Visible = true;
        tChart2.TabIndex = 1;
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
        // 
        // 
        // 
        tChart2.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb((int)(byte)120, (int)(byte)120, (int)(byte)120);
        tChart2.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb((int)(byte)70, (int)(byte)70, (int)(byte)70);
        tChart2.Walls.Back.Brush.Solid = true;
        tChart2.Walls.Back.Brush.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Walls.Back.ImageBevel.Brush.Solid = true;
        tChart2.Walls.Back.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Walls.Back.Shadow.Brush.Solid = true;
        tChart2.Walls.Back.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
        // 
        // 
        // 
        tChart2.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
        tChart2.Walls.Bottom.Brush.Solid = true;
        tChart2.Walls.Bottom.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Walls.Bottom.ImageBevel.Brush.Solid = true;
        tChart2.Walls.Bottom.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Walls.Bottom.Shadow.Brush.Solid = true;
        tChart2.Walls.Bottom.Shadow.Brush.Visible = true;
        tChart2.Walls.Bottom.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
        // 
        // 
        // 
        tChart2.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Walls.Left.Brush.Gradient.SigmaScale = 0F;
        tChart2.Walls.Left.Brush.Solid = true;
        tChart2.Walls.Left.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Walls.Left.ImageBevel.Brush.Solid = true;
        tChart2.Walls.Left.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Walls.Left.Shadow.Brush.Solid = true;
        tChart2.Walls.Left.Shadow.Brush.Visible = true;
        tChart2.Walls.Left.Visible = false;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)192, (int)(byte)192, (int)(byte)192);
        // 
        // 
        // 
        tChart2.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
        tChart2.Walls.Right.Brush.Gradient.SigmaScale = 0F;
        tChart2.Walls.Right.Brush.Solid = true;
        tChart2.Walls.Right.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        tChart2.Walls.Right.ImageBevel.Brush.Solid = true;
        tChart2.Walls.Right.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        tChart2.Walls.Right.Shadow.Brush.Solid = true;
        tChart2.Walls.Right.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        tChart2.Zoom.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)127, (int)(byte)0, (int)(byte)0, (int)(byte)255);
        tChart2.Zoom.Brush.Solid = true;
        tChart2.Zoom.Brush.Visible = false;
        tChart2.AfterDraw += TChart2_AfterDraw;
        // 
        // donut1
        // 
        donut1.AngleSize = 237;
        // 
        // 
        // 
        donut1.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)243, (int)(byte)144);
        donut1.Brush.Solid = true;
        donut1.Brush.Visible = true;
        donut1.Circled = true;
        donut1.Color = System.Drawing.Color.FromArgb((int)(byte)119, (int)(byte)153, (int)(byte)214);
        donut1.DonutPercent = 70;
        // 
        // 
        // 
        donut1.Frame.Circled = true;
        donut1.Frame.FrameElementPercents = new double[]
    {
    25D,
    60D,
    15D
    };
        // 
        // 
        // 
        donut1.Frame.InnerBand.Color = System.Drawing.Color.Gray;
        donut1.Frame.InnerBand.Solid = true;
        donut1.Frame.InnerBand.Visible = true;
        // 
        // 
        // 
        donut1.Frame.OuterBand.Color = System.Drawing.Color.Gray;
        // 
        // 
        // 
        donut1.Frame.OuterBand.Gradient.Visible = true;
        donut1.Frame.OuterBand.Solid = true;
        donut1.Frame.OuterBand.Visible = true;
        donut1.LabelMember = "Labels";
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Legend.Brush.Color = System.Drawing.Color.White;
        donut1.Legend.Brush.Solid = true;
        donut1.Legend.Brush.Visible = true;
        // 
        // 
        // 
        donut1.Legend.Font.Bold = false;
        // 
        // 
        // 
        donut1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
        donut1.Legend.Font.Brush.Solid = true;
        donut1.Legend.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut1.Legend.Font.Shadow.Brush.Solid = true;
        donut1.Legend.Font.Shadow.Brush.Visible = true;
        donut1.Legend.Font.Size = 8;
        donut1.Legend.Font.SizeFloat = 8F;
        donut1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut1.Legend.ImageBevel.Brush.Solid = true;
        donut1.Legend.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut1.Legend.Shadow.Brush.Solid = true;
        donut1.Legend.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Arrow.Color = System.Drawing.Color.Black;
        donut1.Marks.Arrow.Visible = false;
        // 
        // 
        // 
        donut1.Marks.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)255, (int)(byte)255, (int)(byte)255);
        donut1.Marks.Brush.Solid = true;
        donut1.Marks.Brush.Visible = true;
        // 
        // 
        // 
        donut1.Marks.Font.Bold = false;
        // 
        // 
        // 
        donut1.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)0, (int)(byte)0);
        donut1.Marks.Font.Brush.Solid = true;
        donut1.Marks.Font.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut1.Marks.Font.Shadow.Brush.Solid = true;
        donut1.Marks.Font.Shadow.Brush.Visible = true;
        donut1.Marks.Font.Size = 8;
        donut1.Marks.Font.SizeFloat = 8F;
        donut1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut1.Marks.ImageBevel.Brush.Solid = true;
        donut1.Marks.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb((int)(byte)128, (int)(byte)128, (int)(byte)128);
        donut1.Marks.Shadow.Brush.Solid = true;
        donut1.Marks.Shadow.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
        donut1.Marks.Symbol.Brush.Solid = true;
        donut1.Marks.Symbol.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
        donut1.Marks.Symbol.ImageBevel.Brush.Solid = true;
        donut1.Marks.Symbol.ImageBevel.Brush.Visible = true;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut1.Marks.Symbol.Shadow.Brush.Solid = true;
        donut1.Marks.Symbol.Shadow.Brush.Visible = true;
        donut1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.None;
        donut1.Marks.Visible = false;
        // 
        // 
        // 
        donut1.MarksPie.InsideSlice = true;
        donut1.MarksPie.LegSize = 0;
        donut1.MarksPie.Rotated = false;
        donut1.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        donut1.MarksPie.VertCenter = false;
        donut1.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        // 
        // 
        // 
        donut1.OtherSlice.Color = System.Drawing.Color.Empty;
        donut1.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        donut1.OtherSlice.Text = "";
        donut1.OtherSlice.Value = 0D;
        // 
        // 
        // 
        donut1.Pen.Width = 3;
        donut1.RotationAngle = 332;
        // 
        // 
        // 
        // 
        // 
        // 
        donut1.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
        donut1.Shadow.Brush.Solid = true;
        donut1.Shadow.Brush.Visible = true;
        donut1.Title = "donut1";
        donut1.UniqueCustomRadius = true;
        // 
        // 
        // 
        donut1.XValues.DataMember = "Angle";
        donut1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
        // 
        // 
        // 
        donut1.YValues.DataMember = "Pie";

    }

    //************************ running config procs *********************

    Random rand;

    public void Config()
    {
        rand = new Random();
        ConfigGauge1();
        ConfigGauge2();
        ConfigGauge3();
        ConfigGauge4();
        ConfigGauge5();
        ConfigSurface();
        ConfigMultiSeries1();
        ConfigHarmonics();
    }

    private void ConfigGauge1()
    {
        circularGauge1.GreenLine.Pen.Visible = false;
        circularGauge1.GreenLine.Gradient.Visible = false;
        circularGauge1.GreenLine.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(104))))); ; // Color.LightGreen;
        circularGauge1.RedLine.Pen.Visible = false;
        circularGauge1.RedLine.Gradient.Visible = false;
        circularGauge1.RedLine.Brush.Color = System.Drawing.Color.Red;
        circularGauge1.Frame.OuterBand.Visible = false;
        circularGauge1.Frame.MiddleBand.Visible = false;
        circularGauge1.Frame.InnerBand.Visible = false;
        circularGauge1.FaceBrush.Visible = false;

        circularGauge1.Value = rand.NextDouble() * 70;

        this.circularGauge1.Axis.GetAxisDrawLabel += Axis_GetAxisDrawLabel;

    }

    private void Axis_GetAxisDrawLabel(object sender, Steema.TeeChart.GetAxisDrawLabelEventArgs e)
    {
        if ((e.Text != "70") && (e.Text != "0") && (e.Text != "100"))
            e.Text = "";
    }

    private void ConfigGauge2()
    {
        donut1.Add(rand.NextDouble() * 1000);
        donut1.Add(1000 - donut1.YValues.Last);

        //donut1.Pen.Fill.Color = donut1.Chart.Panel.Brush.Gradient.StartColor; //  Color.Black;
        donut1.Pen.Color = donut1.Chart.Panel.Brush.Gradient.StartColor; // donut1.Pen.Fill.Color;
        donut1.Pen.Width = 3;
        donut1.AutoPenColor = false;
    }

    private void ConfigGauge3()
    {
        // donut2
        donut2.Pen.Color = donut2.Chart.Panel.Brush.Gradient.StartColor;
        donut2.AutoPenColor = false;
        this.donut2.AngleSize = 237;
        this.donut2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(144)))));
        this.donut2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
        this.donut2.DonutPercent = 70;
        this.donut2.Frame.Circled = true;
        this.donut2.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
        this.donut2.Frame.OuterBand.Gradient.UseMiddle = false;
        this.donut2.LabelMember = "Labels";
        this.donut2.Marks.Visible = false;
        this.donut2.MarksPie.InsideSlice = true;
        this.donut2.MarksPie.LegSize = 0;
        this.donut2.MarksPie.Rotated = false;
        this.donut2.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        this.donut2.MarksPie.VertCenter = false;
        this.donut2.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        this.donut2.OriginalCursor = null;
        this.donut2.OtherSlice.Color = System.Drawing.Color.Empty;
        this.donut2.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        this.donut2.OtherSlice.Text = "";
        this.donut2.OtherSlice.Value = 0D;
        this.donut2.Pen.Width = 3;
        this.donut2.RotationAngle = 332;
        this.donut2.Title = "donut2";
        this.donut2.UniqueCustomRadius = true;
        this.donut2.UseExtendedNumRange = false;
        this.donut2.XValues.DataMember = "Angle";
        this.donut2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        this.donut2.YValues.DataMember = "Pie";

        donut2.Add(rand.NextDouble() * 1000);
        donut2.Add(1000 - donut2.YValues.Last);
        donut2.Pen.Fill.Color = donut1.Chart.Panel.Brush.Gradient.StartColor; //  Color.Black;
        donut2.Pen.Fill.Visible = true;
    }

    private void ConfigGauge4()
    {
        // donut3
        donut3.Pen.Color = donut2.Chart.Panel.Brush.Gradient.StartColor;
        donut3.AutoPenColor = false;
        this.donut3.AngleSize = 237;
        this.donut3.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(144)))));
        this.donut3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
        this.donut3.DonutPercent = 70;
        this.donut3.Frame.Circled = true;
        this.donut3.Frame.FrameElementPercents = new double[] {
    25D,
    60D,
    15D};
        this.donut3.Frame.OuterBand.Gradient.UseMiddle = false;
        this.donut3.LabelMember = "Labels";
        this.donut3.Marks.Visible = false;
        this.donut3.MarksPie.InsideSlice = true;
        this.donut3.MarksPie.LegSize = 0;
        this.donut3.MarksPie.Rotated = false;
        this.donut3.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        this.donut3.MarksPie.VertCenter = false;
        this.donut3.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        this.donut3.OriginalCursor = null;
        this.donut3.OtherSlice.Color = System.Drawing.Color.Empty;
        this.donut3.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        this.donut3.OtherSlice.Text = "";
        this.donut3.OtherSlice.Value = 0D;
        this.donut3.Pen.Width = 3;
        this.donut3.RotationAngle = 332;
        this.donut3.Title = "donut3";
        this.donut3.UniqueCustomRadius = true;
        this.donut3.UseExtendedNumRange = false;
        this.donut3.XValues.DataMember = "Angle";
        this.donut3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        this.donut3.YValues.DataMember = "Pie";

        donut3.Add(rand.NextDouble() * 1000);
        donut3.Add(1000 - donut3.YValues.Last);
        donut3.Pen.Fill.Color = donut1.Chart.Panel.Brush.Gradient.StartColor; //  Color.Black;
        donut3.Pen.Fill.Visible = true;
    }

    private void ConfigGauge5()
    {
        // donut4
        donut4.Pen.Color = donut2.Chart.Panel.Brush.Gradient.StartColor;
        donut4.AutoPenColor = false;
        this.donut4.AngleSize = 237;
        this.donut4.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(144)))));
        this.donut4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
        this.donut4.DonutPercent = 70;
        this.donut4.Frame.Circled = true;
        this.donut4.Frame.FrameElementPercents = new double[] {
    25D,
    60D,
    15D};
        this.donut4.Frame.OuterBand.Gradient.UseMiddle = false;
        this.donut4.LabelMember = "Labels";
        this.donut4.Marks.Visible = false;
        this.donut4.MarksPie.InsideSlice = true;
        this.donut4.MarksPie.LegSize = 0;
        this.donut4.MarksPie.Rotated = false;
        this.donut4.MarksPie.RotateStyle = Steema.TeeChart.Styles.Pie.MarksRotateStyle.Radial;
        this.donut4.MarksPie.VertCenter = false;
        this.donut4.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
        this.donut4.OriginalCursor = null;
        this.donut4.OtherSlice.Color = System.Drawing.Color.Empty;
        this.donut4.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
        this.donut4.OtherSlice.Text = "";
        this.donut4.OtherSlice.Value = 0D;
        this.donut4.Pen.Width = 3;
        this.donut4.RotationAngle = 332;
        this.donut4.Title = "donut4";
        this.donut4.UniqueCustomRadius = true;
        this.donut4.UseExtendedNumRange = false;
        this.donut4.XValues.DataMember = "Angle";
        this.donut4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

        this.donut4.YValues.DataMember = "Pie";

        donut4.Add(rand.NextDouble() * 1000);
        donut4.Add(1000 - donut4.YValues.Last);
        donut4.Pen.Fill.Color = donut1.Chart.Panel.Brush.Gradient.StartColor; //  Color.Black;
        donut4.Pen.Fill.Visible = true;
    }

    private void ConfigHighLow()
    {

        annotation1.PositionUnits = PositionUnits.Pixels;
        annotation2.PositionUnits = PositionUnits.Pixels;

        annotation1.Position = AnnotationPositions.Custom;
        annotation2.Position = AnnotationPositions.Custom;

        tChart6.Axes.Left.Maximum = 1000;

        highLow1.HighBrush.Visible = true;
        highLow1.HighBrush.Gradient.StartColor = System.Drawing.Color.FromArgb(192, 192, 255);
        highLow1.HighBrush.Gradient.EndColor = System.Drawing.Color.FromArgb(128, 128, 255);
        highLow1.LowBrush.Gradient.StartColor = System.Drawing.Color.FromArgb(128, 128, 255);
        highLow1.LowBrush.Gradient.EndColor = System.Drawing.Color.FromArgb(192, 192, 255);
        highLow1.HighBrush.Gradient.Visible = true;
        highLow1.HighBrush.Transparency = 50;
        highLow1.LowBrush.Visible = true;
        highLow1.LowBrush.Gradient.Visible = true;
        highLow1.LowBrush.Transparency = 50;

        for (int i = 0; i < line1.Count; i++)
        {
            highLow1.Add(line1.XValues[i], line1.YValues[i], line2.YValues[i]);
        }

        line3.CheckDataSource();
        line4.CheckDataSource();
    }

    private void addHighLow()
    {
        double newHigh = highLow1.HighValues.Last + Convert.ToDouble(100.0 - (rand.NextDouble() * 50));
        double newLow = highLow1.LowValues.Last + Convert.ToDouble(100.0 - (rand.NextDouble() * 50));

        if (newHigh > 999)
            newHigh = 1000 - (rand.NextDouble() * 200);

        if (newLow > 999)
            newLow = 1000 - (rand.NextDouble() * 200);

        highLow1.Add(highLow1.XValues.Last + (1 / 86400.0F / 2.0F), newHigh, newLow);

        if (highLow1.Count > 100)
        {
            highLow1.Delete(0);
            tChart6.Axes.Bottom.SetMinMax(highLow1.XValues[0], highLow1.XValues.Last);
        }

        line3.CheckDataSource();
        line4.CheckDataSource();

    }

    private void ConfigMultiSeries1()
    {
        area1.FillSampleValues(100);
        line1.FillSampleValues(100);
        line2.FillSampleValues(100);

        double startDT = DateTime.Now.ToOADate();

        for (int i = 0; i < area1.XValues.Count; i++)
        {
            area1.XValues[i] = startDT + (1.0 / 86400 * i / 2);

            line1.XValues[i] = area1.XValues[i];
            line2.XValues[i] = area1.XValues[i];

            if (line1.YValues[i] > 999)
                line1.YValues[i] = 1000 - (rand.NextDouble() * 200);

            if (line2.YValues[i] > 999)
                line2.YValues[i] = 1000 - (rand.NextDouble() * 200);

            if (i % 2 == 0)
                bar3D1.Add(area1.XValues[i], 400 - rand.Next(400), 400 + rand.Next(400));
        }

        ConfigHighLow();

    }

    private void modGauges()
    {
        void modDonut(Donut donut)
        {
            double delta1 = rand.NextDouble() * 5;

            if (donut.YValues[1] > 910) donut.YValues[1] = donut.YValues[1] - delta1;
            else if (donut.YValues[1] < 90) donut.YValues[1] = donut.YValues[1] + delta1;
            else donut.YValues[1] = donut.YValues[1] + (1 - delta1);
            donut.YValues[0] = 1000 - donut.YValues[1];
            donut.Repaint();

        }

        modDonut(donut1);
        modDonut(donut2);
        modDonut(donut3);
        modDonut(donut4);

        if (circularGauge1.Value > 65) circularGauge1.Value = circularGauge1.Value - rand.NextDouble() * 2;
        else if (circularGauge1.Value < 10) circularGauge1.Value = circularGauge1.Value + rand.NextDouble() * 2;
        else circularGauge1.Value = circularGauge1.Value + (2 - rand.NextDouble() * 3);
    }

    int OneYesOneNo = 0;
    private void addToMultiSeries()
    {
        double delta1 = rand.NextDouble() * 350;
        double delta2 = rand.NextDouble() * 350;
        double delta3 = (rand.NextDouble() * 350) + 10;

        double newAreaVal = area1.YValues.Last + ((area1.YValues.Last > 449) ? -delta1 : delta1);
        double newLine1Val = line1.YValues.Last + ((line1.YValues.Last > 449) ? -delta1 : delta1);
        double newLine2Val = line2.YValues.Last + ((line2.YValues.Last > 449) ? -delta3 : delta3);

        if (newAreaVal < 100) newAreaVal = 100;
        if (newLine1Val < 100) newLine1Val = 100;
        if (newLine2Val < 100) newLine2Val = 100;

        double timeStamp = area1.XValues.Last + (1 / 86400.0F / 2.0F);

        area1.Add(timeStamp, newAreaVal);
        area1.XValues.Modified = true;

        line1.Add(timeStamp, newLine1Val);
        line2.Add(timeStamp, newLine2Val);

        if (area1.Count == 102)
            OneYesOneNo = 0;

        OneYesOneNo++;

        if (OneYesOneNo == 1)
        {
            bar3D1.Add(timeStamp, 400 - rand.Next(400), 400 + rand.Next(400));
            OneYesOneNo = -1;
        }

        if (area1.Count > 110)
        {
            area1.Delete(0);
            area1.XValues.Modified = true;
            line1.Delete(0);
            line1.XValues.Modified = true;
            line2.Delete(0);
            line2.XValues.Modified = true;

            if (bar3D1.Count > 55)
            {
                bar3D1.Delete(0);
                bar3D1.XValues.Modified = true;
            }

            tChart7.Axes.Bottom.SetMinMax(area1.XValues[0], area1.XValues.Last);
        }
    }

    private void ConfigHarmonics()
    {
        tChart8.Axes.Left.SetMinMax(-1.2, 1.21);
        tChart8.Series.Add(new FastLine());
        tChart8.Series[0].Color = System.Drawing.Color.FromArgb(255, 255, 128);
        ((FastLine)(tChart8.Series[0])).LinePen.UseStyling = false;
        Harmonic();
    }

    double[] x = new double[3000];
    int N1 = 3000;
    double p2 = Math.PI * 2;
    int m = 0;
    double freq = 3;
    double aFactor = 1.0;

    private void Harmonic()
    {
        double a;

        {
            for (int n = 0; n < N1; n++)
            {
                x[n] = 0;
                for (int k = 1; k <= m; k++)
                {
                    a = aFactor / k;
                    if ((((k - 1) % 2) == 0))
                        x[n] = x[n] + (4.0 / Math.PI) * a * Math.Sin(p2 * freq * k * n / N1);
                }
            }
        }
        tChart8[0].Clear();
        for (int n = 0; n < N1; n++)
            tChart8[0].Add(n, x[n]);
    }

    bool deltaM = true;

    int tickCount = 0;

    protected void DoTimerTick()
    {
        if (deltaM)
        {
            m = m + 10;
            if (m == 200)
                deltaM = false;
        }
        else
        {
            m = m - 10;
            if (m == 10)
                deltaM = true;
        }

        tickCount++;

        Harmonic();

        addHighLow();

        rotateSurface();

        addToMultiSeries();

        modSurface();

        if (tickCount == 70)
        {
            modGauges();
            tickCount = 0;
        }

    }

    private void ConfigSurface()
    {

        tChart5.Panel.Color = System.Drawing.Color.FromArgb(70, 70, 70);
        tChart5.Axes.Left.Increment = 0.2;
        double[] xval = new double[10] { 0.1, 0.2, 0.3, 0.5, 0.8, 1.1, 1.5, 2.0, 2.2, 3.0 };
        double[] zval = new double[10] { 0.5, 0.6, 0.7, 0.75, 0.8, 1.1, 1.5, 2.0, 2.2, 5.6 };
        surface.IrregularGrid = true;
        surface.NumXValues = 10;
        surface.NumZValues = 10;

        double y;

        for (int x = 0; x < 9; x++) // = 10 rows
            for (int z = 0; z < 09; z++) // = 10 columns
            {
                y = 700 + Math.Sin(z * Math.PI / 10.0) * Math.Cos(x * Math.PI / 5.0);  // example Y value
                surface.Add(xval[x], y, zval[z]);
            }
    }

    private void modSurface()
    {
        var delta1 = 0.04 - rand.NextDouble() * 0.08;
        int whatPointX = 9 - rand.Next(8);
        int whatPointZ = 9 - rand.Next(8);

        for (int x = 0; x < 9; x++) // = 10 rows
            for (int z = 0; z < 9; z++) // = 10 columns
            {
                if ((x == whatPointX) && (z == whatPointZ))
                    surface.YValues[x * z] = surface.YValues[x * z] + delta1;
            }
    }

    int Delta = 1;
    int rotateBrake = 0;
    private void rotateSurface()
    {
        if (rotateBrake % 40 == 0)
        {
            rotateBrake = 0;

            if ((tChart5.Aspect.Rotation == 360)) Delta = -1;
            else if ((tChart5.Aspect.Rotation == 0)) Delta = 1;

            if ((tChart5.Aspect.Rotation <= 360) && (Delta == 1))
                tChart5.Aspect.Rotation++;
            else if ((tChart5.Aspect.Rotation >= 0) && (Delta == -1))
                tChart5.Aspect.Rotation--;
        }
        else
            rotateBrake++;
    }

    private void TChart1_AfterDraw(object sender, IGraphics3D g)
    {
        var x = tChart1.Graphics3D.ChartXCenter;
        var y = tChart1.Graphics3D.ChartYCenter + 23;

        if (x > -1)
        {
            g.Font.Color = System.Drawing.Color.White;
            g.Font.Bold = true;
            g.TextOut((int)(x - (g.TextWidth(circularGauge1.Value.ToString("#.00")) / 2)), (int)y, circularGauge1.Value.ToString("#.00"));
            g.TextOut((int)(x - (g.TextWidth("ºC") / 2)), (int)y + 20, "ºC");
        }
    }

    private void TChart2_AfterDraw(object sender, IGraphics3D g)
    {
        var x = tChart2.Graphics3D.ChartXCenter;
        var y = tChart2.Graphics3D.ChartYCenter;

        if (x > -1)
        {
            g.Font.Color = System.Drawing.Color.White;
            g.Font.Size = 16;
            g.TextOut((int)(x - (g.TextWidth(donut1.YValues[1].ToString("#.00")) / 2)), (int)(y - (g.TextHeight("H") / 2)), donut1.YValues[1].ToString("#.00"));
            g.Font.Size = 10;
            g.TextOut((int)(x - (g.TextWidth("ºC") / 2)), (int)y + 40, "ºC");
        }
    }

    private void TChart3_AfterDraw(object sender, IGraphics3D g)
    {
        var x = tChart3.Graphics3D.ChartXCenter;
        var y = tChart3.Graphics3D.ChartYCenter;

        if (x > -1)
        {
            g.Font.Color = System.Drawing.Color.White;
            g.Font.Size = 16;
            g.TextOut((int)(x - (g.TextWidth(donut2.YValues[1].ToString("#.00")) / 2)), (int)(y - (g.TextHeight("H") / 2)), donut2.YValues[1].ToString("#.00"));
            g.Font.Size = 10;
            g.TextOut((int)(x - (g.TextWidth("ºC") / 2)), (int)y + 40, "ºC");
        }
    }

    private void TChart4_AfterDraw(object sender, IGraphics3D g)
    {
        var x = tChart4.Graphics3D.ChartXCenter;
        var y = tChart4.Graphics3D.ChartYCenter;

        if (x > -1)
        {
            g.Font.Color = System.Drawing.Color.White;
            g.Font.Size = 16;
            g.TextOut((int)(x - (g.TextWidth(donut3.YValues[1].ToString("#.00")) / 2)), (int)(y - (g.TextHeight("H") / 2)), donut3.YValues[1].ToString("#.00"));
            g.Font.Size = 10;
            g.TextOut((int)(x - (g.TextWidth("ºC") / 2)), (int)y + 40, "ºC");
        }
    }

    string cursorText = "";
    int cursorX = -1;
    int cursorY = -1;
    private void CursorTool1_Change(object sender, CursorChangeEventArgs e)
    {
        cursorText = line2.YScreenToValue(e.y).ToString("#.00");
        cursorX = e.x;
        cursorY = e.y;


    }

    private void TChart7_AfterDraw(object sender, IGraphics3D g)
    {
        if (!stopWatch.IsRunning)
        {
            if (cursorX != -1)
            {
                g.Font.Color = System.Drawing.Color.White;
                g.Font.Size = 12;
                g.TextOut(cursorX + 3, (int)(cursorY - g.TextHeight("H") - 2), "Freq. Hz.: " + cursorText);
            }
        }
    }

    private void TChart9_AfterDraw(object sender, IGraphics3D g)
    {
        var x = tChart9.Graphics3D.ChartXCenter;
        var y = tChart9.Graphics3D.ChartYCenter;

        if (x > -1)
        {
            g.Font.Color = System.Drawing.Color.White;
            g.Font.Size = 16;
            g.TextOut((int)(x - (g.TextWidth(donut4.YValues[1].ToString("#.00")) / 2)), (int)(y - (g.TextHeight("H") / 2)), donut4.YValues[1].ToString("#.00"));
            g.Font.Size = 10;
            g.TextOut((int)(x - (g.TextWidth("ºC") / 2)), (int)y + 40, "ºC");
        }
    }

    private void TChart6_BeforeDrawSeries(object sender, IGraphics3D g)
    {
        var pRight = tChart6.Axes.Bottom.CalcPosValue(tChart6.Axes.Bottom.Maximum);

        annotation1.Left = (int)(pRight - g.TextWidth(annotation1.Text));
        annotation2.Left = (int)(pRight - g.TextWidth(annotation2.Text));

        annotation1.Top = (int)(tChart6.Axes.Custom[0].CalcPosValue(colorBand1.End) - g.TextHeight("H"));
        annotation2.Top = tChart6.Axes.Custom[0].CalcPosValue(colorBand1.Start);
    }

    private void TChart9_BeforeDrawAxes(object sender, IGraphics3D g)
    {
        tChart9.Footer.Top = tChart9.Chart.ChartBounds.Height - 30;
    }

    private void TChart1_BeforeDrawAxes(object sender, IGraphics3D g)
    {
        tChart1.Footer.Top = tChart1.Chart.ChartBounds.Height - 30;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        DoTimerTick();
    }


    private void StartStop_Click(object sender, RoutedEventArgs e)
    {
        currentTime = string.Empty;

        if (stopWatch.IsRunning) stopWatch.Stop();
        else
            stopWatch.Start();

        getDispatcherTimer();

        if (dispatcherTimer.IsEnabled) dispatcherTimer.Stop();
        else
            dispatcherTimer.Start();

        cursorTool1.Active = !stopWatch.IsRunning;
        if (cursorTool1.Active)
        {
            cursorTool1.XValue = tChart7.Axes.Bottom.Minimum + (tChart7.Axes.Bottom._iRange / 2);
            cursorTool1.YValue = tChart7.Axes.Left.Minimum + (tChart7.Axes.Left._iRange / 2);
        }
    }
}
