//Copyright Maarten 't Hart 2019
using OpenGL;
using SolarSystem.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class MainForm : Form
  {
    private double timeStep = 0;
    private CompareForm compareForm; 
    private CelestialPropertiesForm celestialPropertiesForm = new CelestialPropertiesForm();
    private MeteoriteInitializationForm meteoriteInitializationForm;

    private bool SimulationRunning { get; set; } = false;
    private bool SimulationWorkerReady { get; set; } = true;
    private HistoricDateTime PreviousDateTime { get; set; } = new HistoricDateTime(); 
    private HistoricDateTime DateTime { get; set; } = new HistoricDateTime(); 
    private bool TimeUnlocked { get; set; } = true; 
    private ColorMapForm ColorMapForm { get; } = new ColorMapForm();
    private IRenderable ActiveObject { get; set; }
    private RecordScreen RecordScreen { get; set; }
    private int RecordIndex { get; set; }
    private bool RecordAddTimeStamp { get; set; } 
    private string RecordDirectory { get; set; }
    private double RecordTimeStep { get; set; }

    private bool RunRecordingThread { get; set; } = false; 
    public bool Recording => RecordScreen != null;
    private double pauseTime; 

    private BackgroundWorker SimulationWorker { get; set; } = new BackgroundWorker();

    private BackgroundWorker recordBackgroundWorker;

    public static MainForm Main; 

    private ImpactListForm ImpactListForm { get; set; }
    private double TimeStep
    {
      get => timeStep;
      set
      {
        timeStep = value; 
        CoreDll.SetTimeStep(value);
      }
    } 

    private CelestialPropertiesForm CelestialPropertiesForm
    {
      get
      {
        if (celestialPropertiesForm.IsDisposed)
        {
          celestialPropertiesForm = new CelestialPropertiesForm();
          SetSelectedObject(); 
        }
        return celestialPropertiesForm;
      }
    }

    private CompareForm CompareForm
    {
      get
      {
        if (compareForm == null || compareForm.IsDisposed)
          compareForm = new CompareForm(); 
        return compareForm; 
      }
    }

    private double Exxageration
    {
      get => Scene.Exxageration;
      set => Scene.Exxageration = value; 
    }
    private Camera Camera => GlView.Camera;
    private Scene Scene => GlView.Scene;


    //depricated hard coded planets. 
    public Planet Sun { get; private set; }
    public Planet Mercury { get; private set; }
    public Planet Venus { get; private set; }
    public Planet Earth { get; private set; }
    public Planet Moon { get; private set; }
    public Planet Mars { get; private set; }
    public Planet Jupiter { get; private set; }
    public Planet Saturn { get; private set; }
    public Planet Uranus { get; private set; }
    public Planet Neptune { get; private set; }
    public Planet Pluto { get; private set; }

    //Jupiters moons
    public Planet Io { get; private set; }
    public Planet Europa { get; private set; }
    public Planet Ganymede { get; private set; }
    public Planet Callisto { get; private set; }

    //Saturns moons
    public Planet Titan { get; private set; }
    public Planet Mimas { get; private set; }
    public Planet Enceladus { get; private set; }
    public Planet Tethys { get; private set; }
    public Planet Dione { get; private set; }
    public Planet Rhea { get; private set; }
    public Planet Hyperion { get; private set; }
    public Planet Iapetus { get; private set; }

    //Uranus moons
    public Planet Miranda { get; private set; }
    public Planet Ariel { get; private set; }
    public Planet Umbriel { get; private set; }
    public Planet Titania { get; private set; }
    public Planet Oberon { get; private set; }

    //Neptunes moon
    public Planet Triton { get; private set; }

    //Plutos moons
    public Planet Charon { get; private set; }

    //Other
    public Planet Ceres { get; private set; }
    public Planet Pallas { get; private set; }
    public Planet Vesta { get; private set; }

    public MainForm()
    {
      SplashScreen splashScreen = new SplashScreen();
      splashScreen.Show(); 
      InitializeComponent();
      string sourceFileName = "";
      using (InitializePlanetsFileForm initForm = new InitializePlanetsFileForm())
      {
        initForm.ShowDialog();
        sourceFileName = initForm.SourceFile; 
      }
      if (sourceFileName != "")
        InitializePlanets(sourceFileName);
      else
        InitializePlanetsHardCoded(); 

      TimeStep = 1.0 / 86400;
      Scene.SetAsMainScene();
      SetDateTime(new HistoricDateTime(0.0));
      GlView.Lookat(Earth, Earth.Name);
      splashScreen.Close();
      splashScreen.Dispose();
      if (Main == null)
        Main = this; 
    }

    private void InitializeEarth(object sender, DoWorkEventArgs e)
    {
      Earth = AddPlanet(SolarSystemPlanet.Earth);
      Earth.SetColorMap(new ColorMap("Earth"));
      Earth.ID = CoreDll.SetActivePlanet(Earth.Name);
    }
       
    private void TestButton_Click(object sender, EventArgs e)
    { 
      Camera.Eye = new PositionObject(-10, 0, 0);
    }

    private void Add(IRenderable renderable)
    {
      Scene.RenderableObjects.Add(renderable); 
    }

    private IRenderable SelectedRenderable()
    {
      if (SceneContentBox.SelectedIndex >= 0 && SceneContentBox.SelectedIndex < Scene.RenderableObjects.Count)
        return Scene.RenderableObjects[SceneContentBox.SelectedIndex];
      return null; 
    }

    private Planet SelectedPlanet()
    {
      return SelectedRenderable() as Planet; 
    }

    private Planet AddPlanet(SolarSystemPlanet planetID)
    {
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet existingPlanet)
          if (existingPlanet.PlanetID == planetID)
            return existingPlanet;

      Planet planet = new Planet(planetID);
      planet.RenderableObject.RenderGeometry.SetGeodesicGrid(9);
      Add(planet);
      GlView.Lookat(planet, planet.Name);
      return planet;
    }

    private Planet AddSun()
    {
      if (Sun != null)
        return Sun; 

      Sun = AddPlanet(SolarSystemPlanet.Sun);
      Sun.RenderableObject.UseLight = false;
      Scene.SunLight = new SunLight(Sun);
      Scene.Lights.Add(Scene.SunLight);
      Camera.Light.On = false;
      return Sun; 
    }

    private void ForceRender()
    {
      GlView.Refresh(); 
    }

    /*private void TetrahedronTestButton_Click(object sender, EventArgs e)
    {
      Mesh mesh = new Mesh
      {
        vertices = new double[]
        {
          -1, 0.5, 0,
          1, 0.5, 0,
          0, -1, 0,
          0, 0, 1 },

        indices = new int[]
        {
          2, 1, 0,
          3, 0, 1,
          3, 1, 2,
          3, 2, 0
        },

        colors = new float[]
        { 0, 1, 0, 1,
          1, 0, 0, 1,
          0, 0, 1, 1,
          1, 1, 0, 1}
      };

      Scene.RenderableObjects.Add(mesh); 
    }*/

    /*private void SampleFormTestButton_Click(object sender, EventArgs e)
    {
      using (HelloTriangle.ANGLE.SampleForm form = new HelloTriangle.ANGLE.SampleForm())
        form.ShowDialog(); 
    }*/

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      DateTime.TotalDays = CoreDll.GetTime(); 
      if (PreviousDateTime.TotalDays != DateTime.TotalDays)
      {
        DisplayDateTime();
        PreviousDateTime.TotalDays = DateTime.TotalDays;
        UpdatePlanetPositions(); 
      }

      if (Scene.Changed || Camera.Changed)
        ForceRender();

      if (SceneContentBox.Items.Count != Scene.RenderableObjects.Count)
      {
        SceneContentBox.Items.Clear();
        foreach (IRenderable renderable in Scene.RenderableObjects)
          SceneContentBox.Items.Add(renderable.Name, renderable.On);
      }
    }

    private void UpdatePlanetPositions()
    {
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          planet.TimeUpdate();

      Scene.Changed = true; 
    }

    private void ExxagerateTestButton_Click(object sender, EventArgs e)
    {
      double Exxageration = 25;
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          planet.SetExxageration(Exxageration);
      
    }

    private void ExxagerationBar_Scroll(object sender, EventArgs e)
    {
      double exxageration = ExxagerationBar.Value;
      exxageration /= 1000;
      exxageration *= exxageration;
      Math.Round(exxageration, 2); 
      ExxagerationTextBox.Text = exxageration.ToString();

      Exxageration = exxageration;  
    }

    private void ExxagerationTextBox_Apply(object sender, EventArgs e)
    {
      try
      {
        double exxageration = Convert.ToDouble(ExxagerationTextBox.Text);
        if (exxageration == Exxageration)
          return;
        if (exxageration < 0)
          exxageration = 0;
        else if (exxageration > 100)
          ExxagerationBar.Value = 10000;
        else
          ExxagerationBar.Value = Convert.ToInt32(exxageration * exxageration);

        Exxageration = exxageration; 
      }
      catch
      {
        ExxagerationTextBox.Text = Exxageration.ToString(); 
      }
    }

    private void ExxagerationTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ExxagerationTextBox_Apply(sender, e); 
    }

    private void SceneContentBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      bool on = (e.NewValue == CheckState.Checked);
      if (e.Index >= Scene.RenderableObjects.Count)
        return;
      Scene.RenderableObjects[e.Index].On = on;      
    }

    private void ColorMapEditorButton_Click(object sender, EventArgs e)
    {
      try
      {
        if (ColorMapForm.ShowDialog() != DialogResult.OK)
          return;
        if (SceneContentBox.SelectedIndex >= 0 && SceneContentBox.SelectedIndex < Scene.RenderableObjects.Count)
          Scene.RenderableObjects[SceneContentBox.SelectedIndex].SetColorMap(ColorMapForm.ColorMap);
      }
      catch
      {
        MessageBox.Show("Cannot apply color.");
      }
    }

    internal void AddMeteorShower(MeteorShower meteorShower, bool spherical)
    {
      //give meteor shower a unique name. 
      int i = 0;
      bool ok = false;
      while (!ok)
      {
        ok = true;
        foreach (IRenderable renderable in Scene.RenderableObjects)
        {
          if (renderable.Name == meteorShower.Name)
          {
            i++;
            string name = "Meteor Shower ";
            if (!spherical)
              name += "(sheet) ";
            meteorShower.Name = name + i.ToString();
            ok = false;
            break;
          }
        }
      }

      Scene.RenderableObjects.Add(meteorShower);
    }

    private void TestImageButton_Click(object sender, EventArgs e)
    {
 
    }

    private void PropertiesBoxButton_Click(object sender, EventArgs e)
    {
      CelestialPropertiesForm.Owner = this; 
      CelestialPropertiesForm.Show(); 
    }

    private void SceneContentBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetSelectedObject(); 
    }

    private void SetSelectedObject()
    {
      try
      {
        if (SceneContentBox.SelectedIndex >= Scene.RenderableObjects.Count || SceneContentBox.SelectedIndex < 0)
        {
          CelestialPropertiesForm.ActiveObject = ActiveObject = null; 
          return;
        }
        CelestialPropertiesForm.ActiveObject = ActiveObject = Scene.RenderableObjects[SceneContentBox.SelectedIndex];
      }
      catch
      {

      }
    }

    private void TestDateButton_Click(object sender, EventArgs e)
    {
      using (DateTesterForm form = new DateTesterForm())
        form.ShowDialog(); 
    }

    private void SetMonth(string monthName)
    {
      MonthDropDown.Text = monthName;
      SendDate(); 
    }

    private void SetADBC(string value)
    {
      ADBCDropDown.Text = value;
      SendDate(); 
    }

    private void MonthStripMenuItem_Click(object sender, EventArgs e)
    {
      SetMonth((sender as ToolStripMenuItem).Text);
    }

    private void DateTimeBox_Leave(object sender, EventArgs e)
    {
      SendDate(); 
    }

    private void SendDate(bool display = true)
    {
      try
      {
        HistoricDateTime dateTime = new HistoricDateTime(
          DayBox.Text + " " + MonthDropDown.Text + " " + YearBox.Text + " " + ADBCDropDown.Text +
          " " + TimeBox.Text
          );
        SetDateTime(dateTime, display); 
      }
      catch
      {
        SetDateTime(DateTime, display);
      }
    }

    private void DisplayDateTime()
    {
      DayBox.Text = DateTime.TwoDigits(DateTime.Day.ToString());
      MonthDropDown.Text = HistoricDateTime.MonthText(DateTime.Month);
      long year = DateTime.Year;
      if (year < 0)
        ADBCDropDown.Text = "BC";
      else
        ADBCDropDown.Text = "AD";
      YearBox.Text = Math.Abs(year).ToString();
      TimeBox.Text = DateTime.ToTimeString();
    }

    private void SetDateTime(HistoricDateTime dateTime, bool display = true)
    {
      DateTime = dateTime;
      if (display)
      {
        DisplayDateTime(); 
      }
      CoreDll.SetDaysSinceJ2000(dateTime.TotalDays);
      RenderablesTimeUpdate(); 
    }

    private void RenderablesTimeUpdate()
    {
      foreach (IRenderable renderable in Scene.RenderableObjects)
        renderable.TimeUpdate(); 
    }

    private void DayBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        SendDate(); 
    }

    private void ADBCToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetADBC((sender as ToolStripMenuItem).Text);
    }

    private void TimeLockButton_Click(object sender, EventArgs e)
    {
      SetTimeLock(!TimeUnlocked);
    }

    private void SetTimeLock(bool value)
    {
      TimeUnlocked = value;
      DayBox.Enabled = MonthDropDown.Enabled = YearBox.Enabled = ADBCDropDown.Enabled = TimeBox.Enabled = TimeUnlocked;
      if (TimeUnlocked)
        TimeLockButton.Image = Properties.Resources.TimeIcon;
      else
        TimeLockButton.Image = Properties.Resources.TimeLockIcon;
    }

    private void PlayPauseButton_Click(object sender, EventArgs e)
    {
      SimulationRunning = !SimulationRunning;
      if (SimulationRunning)
      {
        TimeLockButton.Enabled = false;
        InitializeMeteorShowerButton.Enabled = false; 
        DeleteMeteorShowerButton.Enabled = false; 
        SetTimeLock(false);
        SimulationWorker.DoWork -= Simulate;
        SimulationWorker.DoWork += Simulate;
        PlayPauseButton.Image = Properties.Resources.Pause;
        SimulationWorker.RunWorkerAsync();
      }
      else
      {
        PlayPauseButton.Image = Properties.Resources.Play;
        TimeLockButton.Enabled = true;
        InitializeMeteorShowerButton.Enabled = true; 
        DeleteMeteorShowerButton.Enabled = true; 
        CoreDll.Run(false); 
        while (!SimulationWorkerReady)
          System.Threading.Thread.Sleep(10); 
      }
    }

    private void StopRecordThread()
    {
      if (recordBackgroundWorker == null)
        return;
      RunRecordingThread = false; 
      recordBackgroundWorker.Dispose();
      recordBackgroundWorker = null;

      RecordButton.Image = Properties.Resources.Record;
      RecordButton.Text = "Record";
      CoreDll.SetPauseTime(1e99);
      return;
    }

    private void StartRecordThread()
    {
      RunRecordingThread = true;
      recordBackgroundWorker = new BackgroundWorker();
      recordBackgroundWorker.DoWork += RecordingWork; 
      recordBackgroundWorker.RunWorkerAsync();
      RecordButton.Image = Properties.Resources.Stop;
      RecordButton.Text = "Stop Recording";
    }

    private void RecordingWork(object sender, DoWorkEventArgs e)
    {
      using (RecordSettingsForm recordForm = new RecordSettingsForm())
      {
        if (recordForm.ShowDialog() != DialogResult.OK)
          return;

        RecordTimeStep = recordForm.timeStep;
        try
        {
          RecordScreen = new RecordScreen();
          RecordScreen.Width = recordForm.width;
          RecordScreen.Height = recordForm.height;
          RecordScreen.GlControl.Scene = Scene;
          RecordScreen.GlControl.Camera = Camera;
          RecordScreen.Visible = false;
          RecordAddTimeStamp = recordForm.addTimeStamp;

          RecordDirectory = recordForm.folderName;
          //this.Owner = RecordScreen;

        }
        catch
        {
          RecordScreen.Dispose();
          RecordScreen = null;
          MessageBox.Show("Error initializing recording."); 
        }
      }

      bool nextSet = false; 

      while (RunRecordingThread)
      {
        if (!nextSet)
          SetNextPauseTime();

        while (CoreDll.PausingAt()<pauseTime || Scene.paintingImpacts || Scene.applyingChanges)
        {
          System.Threading.Thread.Sleep(1);
          if (!RunRecordingThread)
          {
            RecordScreen.Dispose();
            RecordScreen = null;
            return;
          }
          Application.DoEvents(); 
        }

        nextSet = RecordFrame(true);

        Application.DoEvents();
      }

      RecordScreen.Dispose();
      RecordScreen = null;
    }

    private void Simulate(object sender, DoWorkEventArgs e)
    {      
      SimulationWorkerReady = false;
      //while (SimulationRunning)
      //  AddTimeStep(); 
      CoreDll.Run(true); 
      CoreDll.Simulate(); 
      SimulationWorkerReady = true;       
    }

    private void SetTimeStep()
    {
      double timeStep = Convert.ToDouble(TimeStepBox.Text);
      if (timeStep <= 0)
        throw new ArgumentOutOfRangeException(); 
      switch (TimeStepUnitButton.Text)
      {
        case "Seconds":
          timeStep /= 86400;
          break;
        case "Minutes":
          timeStep /= 1440;
          break;
        case "Hours":
          timeStep /= 24;
          break;
      }
      TimeStep = timeStep; 
    }

    private void SetStepUnit(object sender, EventArgs e)
    {
      TimeStepUnitButton.Text = sender.ToString(); 
      SetTimeStep(); 
    }

    private void TimeStepBox_Leave(object sender, EventArgs e)
    {
      try
      {
        SetTimeStep();
      }
      catch
      {
        TimeStepBox.Text = "1";
        SetTimeStep(); 
      }
    }

    private void TimeStepBox_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        SetTimeStep();
      }
      catch
      {
        TimeStepBox.Text = "1";
        SetTimeStep();
      }
    }

    private void InitializePlanets(string csvFileName)
    {
      InitializeEarth(null, null);
      SolarSystemSource source = new SolarSystemSource(csvFileName);
      foreach(PlanetProperties planetProperties in source.PlanetProperties)
      {
        if (planetProperties.Name == "Earth")
        {
          planetProperties.AddToScene(Scene, Camera); 
          break; 
        }
      }

      InitializeEquatorialCoordinateSystem();
      foreach (PlanetProperties planetProperties in source.PlanetProperties)
        if (planetProperties.Name != "Earth")
          planetProperties.AddToScene(Scene, Camera); 
    }

    /// <summary>
    /// Depricated: initializes hard coded planets. 
    /// </summary>
    private void InitializePlanetsHardCoded()
    {

      InitializeEarth(null,null); 
      Sun = AddSun();
      Mercury = AddPlanet(SolarSystemPlanet.Mercury);
      Venus = AddPlanet(SolarSystemPlanet.Venus);
      Moon = AddPlanet(SolarSystemPlanet.Moon);
      Moon.SetColorMap(new ColorMap("Grayscale"));    
      Mars = AddPlanet(SolarSystemPlanet.Mars);
      Mars.SetColorMap(new ColorMap("Mars"));
      Jupiter = AddPlanet(SolarSystemPlanet.Jupiter);
      Saturn = AddPlanet(SolarSystemPlanet.Saturn);
      Uranus = AddPlanet(SolarSystemPlanet.Uranus);
      Neptune = AddPlanet(SolarSystemPlanet.Neptune);
      Pluto = AddPlanet(SolarSystemPlanet.Pluto);

      //Mercury.Position = new Point3D(Sun.MaximumRadius + 2 * Mercury.MaximumRadius);
      //Venus.Position = new Point3D(Mercury.Position.x + Venus.MaximumRadius * 2);
      //Earth.Position = new Point3D(Venus.Position.x + Earth.MaximumRadius * 2);
      //Moon.Position = new Point3D(Earth.Position.x + Earth.MaximumRadius * 2);
      //Mars.Position = new Point3D(Moon.Position.x + Mars.MaximumRadius * 2);
      //Jupiter.Position = new Point3D(Mars.Position.x + Jupiter.MaximumRadius * 1.2);
      //Saturn.Position = new Point3D(Jupiter.Position.x + Jupiter.MaximumRadius * 2);
      //Uranus.Position = new Point3D(Saturn.Position.x + Saturn.MaximumRadius * 2);
      //Neptune.Position = new Point3D(Uranus.Position.x + Uranus.MaximumRadius * 2);
      //Pluto.Position = new Point3D(Neptune.Position.x + Neptune.MaximumRadius * 2);


      Sun.AddTexture(@"Resource\Texture\8k_sun.jpg",0,false);
      Mercury.AddTexture(@"Resource\Texture\8k_mercury.jpg",0, false);
      Venus.AddTexture(@"Resource\Texture\8k_venus_surface.jpg",0, false);
      Venus.AddTexture(@"Resource\Texture\8k_venus_atmosphere.jpg",0, false);
      Earth.AddTexture(@"Resource\Texture\8k_earth_daymap.jpg", -5, false);
      Earth.AddTexture(@"Resource\Texture\8k_earth_daymap+Atmosphere.jpg", -5, false);
      Moon.AddTexture(@"Resource\Texture\8k_moon.jpg", 180, false);
      Mars.AddTexture(@"Resource\Texture\8k_mars.jpg", 180, false);
      Jupiter.AddTexture(@"Resource\Texture\8k_jupiter.jpg", 0, false);
      Saturn.AddTexture(@"Resource\Texture\8k_saturn.jpg", 0, false);
      Uranus.AddTexture(@"Resource\Texture\2k_uranus.jpg", 0, false);
      Neptune.AddTexture(@"Resource\Texture\2k_neputune.jpg", 0, false);
      Pluto.AddTexture(@"Resource\Texture\Pluto.jpg", 0, false);

      InitializeMoons();

      //if (Camera.Eye is PositionObject eye)
      //  eye.Position = new Point3D(Pluto.Position.x, Pluto.MaximumRadius * 5);

      InitializeEquatorialCoordinateSystem(); 
    }

    private void InitializeMoons()
    {
      //Jupiters moons
      Io = AddPlanet(SolarSystemPlanet.Io);
      Europa = AddPlanet(SolarSystemPlanet.Europa);
      Ganymede = AddPlanet(SolarSystemPlanet.Ganymede);
      Callisto = AddPlanet(SolarSystemPlanet.Callisto);

      Io.AddTexture(@"Resource\Texture\Europa.jpg", 0, false);
      Ganymede.AddTexture(@"Resource\Texture\ganymede.jpg", 0, false);
      Callisto.AddTexture(@"Resource\Texture\callisto.jpg", 0, false);
      Europa.AddTexture(@"Resource\Texture\Europa.jpg", 0, false);

      //Saturns moons
      Titan = AddPlanet(SolarSystemPlanet.Titan);
      Mimas = AddPlanet(SolarSystemPlanet.Mimas);
      Enceladus = AddPlanet(SolarSystemPlanet.Enceladus);
      Tethys = AddPlanet(SolarSystemPlanet.Tethys);
      Dione = AddPlanet(SolarSystemPlanet.Dione);
      Rhea = AddPlanet(SolarSystemPlanet.Rhea);
      Hyperion = AddPlanet(SolarSystemPlanet.Hyperion);
      Iapetus = AddPlanet(SolarSystemPlanet.Iapetus);

      Titan.AddTexture(@"Resource\Texture\titan.jpg", 0, false);
      Mimas.AddTexture(@"Resource\Texture\mimas.jpg", 0, false);
      Enceladus.AddTexture(@"Resource\Texture\enceladus.jpg", 0, false);
      Tethys.AddTexture(@"Resource\Texture\tethys.jpg", 0, false);
      Dione.AddTexture(@"Resource\Texture\dione.jpg", 0, false);
      Rhea.AddTexture(@"Resource\Texture\rhea.jpg", 0, false);
      //Hyperion.AddTexture(@"Resource\Texture\hyperion.jpg", 0, false);
      Iapetus.AddTexture(@"Resource\Texture\iapetus.jpg", 0, false);

      //Uranus moons
      Miranda = AddPlanet(SolarSystemPlanet.Miranda);
      Ariel = AddPlanet(SolarSystemPlanet.Ariel);
      Umbriel = AddPlanet(SolarSystemPlanet.Umbriel);
      Titania = AddPlanet(SolarSystemPlanet.Titania);
      Oberon = AddPlanet(SolarSystemPlanet.Oberon);

      Miranda.AddTexture(@"Resource\Texture\miranda.jpg", 0, false);
      Ariel.AddTexture(@"Resource\Texture\areial.jpg", 0, false);
      Umbriel.AddTexture(@"Resource\Texture\umbriel.jpg", 0, false);
      Titania.AddTexture(@"Resource\Texture\titania.jpg", 0, false);
      Oberon.AddTexture(@"Resource\Texture\oberon.jpg", 0, false);

      //Neptunes moons
      Triton = AddPlanet(SolarSystemPlanet.Triton);

      Triton.AddTexture(@"Resource\Texture\triton.jpg", 0, false);

      //Plutos moons
      Charon = AddPlanet(SolarSystemPlanet.Charon);

      Charon.AddTexture(@"Resource\Texture\charon.jpg", 0, false);

      //Other
      Ceres = AddPlanet(SolarSystemPlanet.Ceres);
      Pallas = AddPlanet(SolarSystemPlanet.Pallas);
      Vesta = AddPlanet(SolarSystemPlanet.Vesta);

      Ceres.AddTexture(@"Resource\Texture\ceres.png", 0, false);
      Vesta.AddTexture(@"Resource\Texture\vesta.jpg", 0, false);
    }

    private void MaxRenderRatioBox_Click(object sender, EventArgs e)
    {
      try
      {
        Planet.MaxRenderRatio = Convert.ToDouble(MaxRenderRatioBox.Text);
      }
      catch
      {
        MaxRenderRatioBox.Text = Planet.MaxRenderRatio.ToString(); 
      }
    }

    private void InitializeEquatorialCoordinateSystem()
    {
      EquatorialCoordinateSystem equatorialCoordinateSystem = new EquatorialCoordinateSystem(Earth);

      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
        {
          Quaternion rotation = equatorialCoordinateSystem.PlanetQuaternion(planet.RightAscension, planet.Declination);

          planet.RotationAxis = rotation;
        }
    }

    private void TimeStepButton_Click(object sender, EventArgs e)
    {
      if (SimulationRunning)
        return;
      CoreDll.AddTimeStep(TimeStep); 
    }

    private void QualityBox_Leave(object sender, EventArgs e)
    {
      SetQuality();
    }

    private void SetQuality()
    {
      try
      {
        int quality = Convert.ToInt32(QualityBox.Text);
        if (quality < 0 || quality > 9)
          throw new Exception();
        Scene.MaximumDisplayGeneration = quality; 
      }
      catch
      {
        MessageBox.Show("Value must be between 0 and 9.");
      }
    }

    private void QualityBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        SetQuality(); 
    }

    private void CalibrationBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        double calibration = Convert.ToDouble(CalibrationBox.Text);
        if (ActiveObject is Planet planet)
        {
          planet.RotationCalibration = calibration;
          Scene.Changed = true;

          SetDateTime(DateTime);
        }
      }
      catch
      {

      }
    }

    private void InitializeMeteorShowerButton_Click(object sender, EventArgs e)
    {
      if (meteoriteInitializationForm == null || meteoriteInitializationForm.IsDisposed)
        meteoriteInitializationForm = new MeteoriteInitializationForm(Scene);

      meteoriteInitializationForm.Owner = this; 
      meteoriteInitializationForm.Show(); 
    }

    private void DeleteMeteorShowerButton_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < Scene.RenderableObjects.Count; i++)
      {
        IRenderable renderable = Scene.RenderableObjects[i];
        if (renderable is MeteorShower meteorShower)
        {
          Scene.RenderableObjects.RemoveAt(i); 
          meteorShower.Dispose();
          i--; 
        }
      }
    }

    private void LoadTextureMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        Planet planet = SelectedPlanet(); 
        if (planet == null)
          throw new Exception("Please select a planet in the list.");

        using (OpenFileDialog ofd = new OpenFileDialog())
        {
          if (ofd.ShowDialog() != DialogResult.OK)
            return;

          if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".zip")
          {
            try
            {
              TextureCache textureCache = new TextureCache(planet);
              textureCache.Load(ofd.FileName);
            }
            catch (Exception ex)
            {
              MessageBox.Show("This zip file does not contain a texture that can be drawn upon the object.\n" + ex.Message, "Error");
            }
          }
          else
          {
            using (Image image = Image.FromFile(ofd.FileName))
            {

            }
            string rotationText = Prompt.ShowDialog("Rotation of image in degrees.", "Rotation");
            double rotation = 0;
            try
            {
              rotation = Convert.ToDouble(rotationText);
            }
            catch
            {

            }

            planet.AddTexture(ofd.FileName, rotation);
          }
        }
      }

      catch (Exception ex)
      {
        MessageBox.Show("Cannot Apply Texture.\n" + ex.Message, "Error");
      }

    }

    private void SaveTextureToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Planet selectedPlanet = SelectedPlanet();
      if (selectedPlanet == null)
      {
        MessageBox.Show("Please select a planet.");
        return;
      }

      string fileName;
      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.Filter = "*.zip|*.zip";
        if (sfd.ShowDialog() != DialogResult.OK)
          return;
        fileName = sfd.FileName;
      }

      TextureCache cache = new TextureCache(selectedPlanet);
      cache.Save(fileName);
    }

    private void ClearCacheToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Do you want to delete the cache folder?", "Question", MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        foreach(string file in System.IO.Directory.GetFiles("Cache"))
          System.IO.File.Delete(file); 
        System.IO.Directory.Delete("Cache");
      }
    }

    private void RecordButton_Click(object sender, EventArgs e)
    {
      if (RecordScreen != null)
        StopRecordThread();
      else
        StartRecordThread();
    }

    private void SetNextPauseTime()
    {
      double simulationTime = CoreDll.GetTime();
      pauseTime += RecordTimeStep;
      if (pauseTime <= simulationTime)
        pauseTime = simulationTime + RecordTimeStep; 
      CoreDll.SetPauseTime(pauseTime); 
    }

    [DllImportAttribute("gdi32.dll")]
    private static extern bool BitBlt(
    IntPtr hdcDest,
    int nXDest,
    int nYDest,
    int nWidth,
    int nHeight,
    IntPtr hdcSrc,
    int nXSrc,
    int nYSrc,
    int dwRop);

    bool warnedCapture = false; 
    public Bitmap CaptureControl(Control control)
    {
      try
      {
        Bitmap controlBmp;
        using (Graphics g1 = control.CreateGraphics())
        {
          controlBmp = new Bitmap(control.Width, control.Height, g1);
          using (Graphics g2 = Graphics.FromImage(controlBmp))
          {
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, control.Width, control.Height, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
          }
        }

        return controlBmp;
      }
      catch
      {
        if (!warnedCapture)
        {
          warnedCapture = true;
          MessageBox.Show("Error capturing image"); 
        }
      }
      return null;
    }

    private void SaveControlImage(Control control, string fileName)
    {
      /*
      using (Bitmap bitmap = new Bitmap(control.Width, control.Height))
      {
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
        control.Refresh(); 
        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
      }*/
      using (Bitmap bitmap = CaptureControl(control))
      {
        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
      }
    }

    private bool RecordFrame(bool setNext = false)
    {
      if (RecordScreen == null)
        return false;

      RecordScreen.Location = new Point(0,0);

      string fileName = RecordDirectory + RecordIndex++.ToString() + ".png";
      RecordScreen.Show();
      RecordScreen.GlControl.Refresh();
      using (Bitmap bitmap = CaptureControl(RecordScreen))
      {
        if (bitmap == null)
          return false;

        if (setNext)
          SetNextPauseTime();

        //RecordScreen.Hide();
        if (RecordAddTimeStamp)
          AddTimeStamp(bitmap);

        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        return setNext; 
      }
    }

    private void AddTimeStamp(Bitmap bitmap)
    {
      try
      {
        int height = bitmap.Height / 20;
        int width = height * 11;
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          Rectangle rectangle = new Rectangle(
            bitmap.Width - width,
            bitmap.Height - height * 2,
            width,
            height);

          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
          g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
          g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

          string date = DateTime.ToBCADDateString() + " " + DateTime.ToRoundedTimeString();

          g.DrawString(date, new Font("Calibri", height, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, rectangle);

          g.Flush();
        }
      }
      catch
      {

      }
    }

    private void DebugSaveImageButton_Click(object sender, EventArgs e)
    {
      RecordFrame(); 
    }

    private void TestSaveFrame_Click(object sender, EventArgs e)
    {
      SaveControlImage(GlView, "D:\\test.png");
    }

    public static string GetPlanetName(int planetID)
    {
      foreach (IRenderable renderable in Main.Scene.RenderableObjects)
        if (renderable is Planet planet)
          if (planet.ID == planetID)
            return planet.Name;

      return "Unkown"; 
    }

    private void ShowImpactsButton_Click(object sender, EventArgs e)
    {
      if (ImpactListForm == null || ImpactListForm.IsDisposed)
        ImpactListForm = new ImpactListForm();
      ImpactListForm.Show();
    }

    private void SaveMeteorShowerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      IRenderable selected = SelectedRenderable();
      if (!(selected is MeteorShower meteorShower))
      {
        MessageBox.Show("Please select a meteor shower.");
        return;
      }
      try
      {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
          saveFileDialog.Filter = "*.sxml|*.sxml";
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            return;
          meteorShower.OriginalInput.Save(saveFileDialog.FileName);
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show("Cannot save meteor shower.\n" + ex.Message, "Error");
      }
    }

    private void LoadMeteorShowerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
          openFileDialog.Filter = "*.sxml|*.sxml";
          if (openFileDialog.ShowDialog() != DialogResult.OK)
            return;
          MeteorShowerOriginalInput input = MeteorShowerOriginalInput.FromFile(openFileDialog.FileName);
          if (input.time != CoreDll.GetTime())
          {
            HistoricDateTime date = new HistoricDateTime(input.time);
            if (MessageBox.Show("Do you want to set the time to " + date.ToPrettyDateString() + " " + date.ToTimeString() + "?", 
              "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
              input.SetTime();
          }
          AddMeteorShower(input.GetMeteorShower(), input.spherical);
        }        
      }
      catch (Exception ex)
      {
        MessageBox.Show("Cannot save meteor shower.\n" + ex.Message, "Error");
      }
    }

    private void LoadPlanetsTestButton_Click(object sender, EventArgs e)
    {
      string fileName; 
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Filter = "*.csv|*.csv";
        if (ofd.ShowDialog() != DialogResult.OK)
          return; 
        fileName = ofd.FileName;
      }
      SolarSystemSource solarSystemSource = new SolarSystemSource(fileName);
      foreach (PlanetProperties properties in solarSystemSource.PlanetProperties)
        properties.AddToScene(Scene,Camera);

      //resetting planet positions. 
      CoreDll.SetDaysSinceJ2000(CoreDll.GetTime()); 
    }

    private void SetGravityThresholdButton_Click(object sender, EventArgs e)
    {
      try
      {
        string result = Prompt.ShowDialog(
          "Don't do gravity calculations for gravity sources weaker than (default: 0.0005 km/s2):",
          "Set Gravity Threshold");
        double value = Convert.ToDouble(result);
        CoreDll.SetGravityThreshold(value); 
      }
      catch (Exception ex)
      {
        MessageBox.Show("An error occured.\n" + ex.Message, "Error");
      }
    }

    private void LoadHeightMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Planet planet = SelectedPlanet(); 
      if (planet == null)
      {
        MessageBox.Show("Please select a planet");
        return;
      }
      string fileName;
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.Filter = "*.tif|*.tif|*.map|*.map";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        fileName = openFileDialog.FileName; 
      }

      if (planet.HeightMap.Load(fileName))
      {
        planet.ExxagerationChanged = true;
        MessageBox.Show("Heightmap applied");
      }
      else
      {
        MessageBox.Show("Heightmap could not be applied.");
      }
    }

    private void SaveHeightMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Planet planet = SelectedPlanet();

      if (planet==null)
      {
        MessageBox.Show("Please select a planet.");
        return;
      }

      if (planet.HeightMap == null || !planet.HeightMap.Valid)
      {
        MessageBox.Show("Please select a planet with a valid heightmap.");
        return;
      }

      using (SaveFileDialog saveFileDialog = new SaveFileDialog())
      {
        saveFileDialog.Filter = "*.map|*.map";
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;

        planet.HeightMap.Save(saveFileDialog.FileName); 
      }
    }

    private void ComparePlanetsButton_Click(object sender, EventArgs e)
    {
      CompareForm.Show();
    }
  }
}
