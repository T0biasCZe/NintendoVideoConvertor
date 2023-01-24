using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tamagotchi {
    public partial class Form1 : Form {
        private Tamagotchi tamagotchi;
        private ProgressBar hungerProgressBar;
        private ProgressBar activityProgressBar;
        private ProgressBar tirednessProgressBar;
        private Button feedButton;
        private Button playButton;
        private Button sleepButton;

        public Form1() {
            InitializeComponent();
            tamagotchi = new Tamagotchi();

            hungerProgressBar = new ProgressBar();
            hungerProgressBar.Value = tamagotchi.Hunger;
            hungerProgressBar.Top = 10;
            hungerProgressBar.Left = 10;
            hungerProgressBar.Width = 100;
            Controls.Add(hungerProgressBar);

            activityProgressBar = new ProgressBar();
            activityProgressBar.Value = tamagotchi.Activity;
            activityProgressBar.Top = 30;
            activityProgressBar.Left = 10;
            activityProgressBar.Width = 100;
            Controls.Add(activityProgressBar);

            tirednessProgressBar = new ProgressBar();
            tirednessProgressBar.Value = tamagotchi.Tiredness;
            tirednessProgressBar.Top = 50;
            tirednessProgressBar.Left = 10;
            tirednessProgressBar.Width = 100;
            Controls.Add(tirednessProgressBar);

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
            timer.Interval = 200; // update every second
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
            hungerProgressBar.Value = tamagotchi.Hunger;
            activityProgressBar.Value = tamagotchi.Activity;
            tirednessProgressBar.Value = tamagotchi.Tiredness;

            if(tamagotchi.IsDead()) {
                MessageBox.Show("Your Tamagotchi has died.", "DED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

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
    }
}