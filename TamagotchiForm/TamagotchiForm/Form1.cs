using System;
using System.Windows.Forms;

public class Tamagotchi {
    public int Hunger { get; set; }
    public int Activity { get; set; }
    public int Tiredness { get; set; }

    public Tamagotchi() {
        Hunger = 50;
        Activity = 50;
        Tiredness = 50;
    }

    public void Feed() {
        Hunger += 10;
    }

    public void Play() {
        Activity += 10;
        Tiredness += 5;
    }

    public void Sleep() {
        Tiredness -= 10;
    }

    public bool IsDead() {
        return Hunger <= 0 || Hunger >= 100 || Activity <= 0 || Activity >= 100 || Tiredness <= 0 || Tiredness >= 100;
    }
}

public class TamagotchiForm : Form {
    private Tamagotchi tamagotchi;
    private Label hungerLabel;
    private Label activityLabel;
    private Label tirednessLabel;
    private Button feedButton;
    private Button playButton;
    private Button sleepButton;

    public TamagotchiForm() {
        tamagotchi = new Tamagotchi();

        hungerLabel = new Label();
        hungerLabel.Text = "Hunger: " + tamagotchi.Hunger;
        hungerLabel.Top = 10;
        hungerLabel.Left = 10;
        Controls.Add(hungerLabel);

        activityLabel = new Label();
        activityLabel.Text = "Activity: " + tamagotchi.Activity;
        activityLabel.Top = 30;
        activityLabel.Left = 10;
        Controls.Add(activityLabel);

        tirednessLabel = new Label();
        tirednessLabel.Text = "Tiredness: " + tamagotchi.Tiredness;
        tirednessLabel.Top = 50;
        tirednessLabel.Left = 10;
        Controls.Add(tirednessLabel);

        feedButton = new Button();
        feedButton.Text = "Feed";
        feedButton.Top = 80;
        feedButton.Left = 10;
        feedButton.Click += new EventHandler(FeedButton_Click);
        Controls.Add(feedButton);

        playButton = new Button();
        playButton.Text = "Play";
        playButton.Top = 110;
        playButton.Left = 10;
        playButton.Click += new EventHandler(PlayButton_Click);
        Controls.Add(playButton);

        sleepButton = new Button();
        sleepButton.Text = "Sleep";
        sleepButton.Top = 140;
        sleepButton.Left = 10;
        sleepButton.Click += new EventHandler(SleepButton_Click);
        Controls.Add(sleepButton);

        Timer timer = new Timer();
        timer.Interval = 1000; // update every second
        timer.Tick += new EventHandler(Timer_Tick);
        timer.Start();
    }

    private void FeedButton_Click(object sender, EventArgs e) {
        tamagotchi.Feed();
    }
    private void PlayButton_Click(object sender, EventArgs e) {
        tamagotchi.Play();
    }

    private void SleepButton_Click(object sender, EventArgs e) {
        tamagotchi.Sleep();
    }

    private void Timer_Tick(object sender, EventArgs e) {
        hungerLabel.Text = "Hunger: " + tamagotchi.Hunger;
        activityLabel.Text = "Activity: " + tamagotchi.Activity;
        tirednessLabel.Text = "Tiredness: " + tamagotchi.Tiredness;

        if (tamagotchi.IsDead()) {
            MessageBox.Show("Your Tamagotchi has died.");
            Close();
        }
    }
}

static class Program {
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TamagotchiForm());
    }
}