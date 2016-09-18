using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundRussianRoulette
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        private Timer timer1;
        private int counter = 20;
        private Dictionary<string, SoundPlayer> music = new Dictionary<string, SoundPlayer>();
        
        public Form1()
        {
            music.Add("SHREK", new SoundPlayer(Properties.Resources.shrek));
            music.Add("HARRY POTTER", new SoundPlayer(Properties.Resources.potter));
            music.Add("JOOOHN CENAAA", new SoundPlayer(Properties.Resources.cena));
            music.Add("THOMAS THE PAIN ENGINE", new SoundPlayer(Properties.Resources.thomas));
            music.Add("SAD VIOLINS", new SoundPlayer(Properties.Resources.violin));
            music.Add("SPONGEBOB", new SoundPlayer(Properties.Resources.spongebob));
            music.Add("SANIC", new SoundPlayer(Properties.Resources.sanic));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (rnd.Next(7)) // 1/7 chance
            {
                case 2: Boom();
                    break;
                default: Saved();
                    break;
            }
        }

        private void Boom()
        {
            var entry = music.ElementAt(rnd.Next(music.Count));

            label1.ForeColor = Color.Red;
            label1.Text = entry.Key + " TIME";
            button1.Enabled = false;
            entry.Value.Play();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            label2.Text = counter.ToString();
        }

        private void Saved()
        {
            label1.ForeColor = Color.Green;
            label1.Text = "You're safe...";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                label2.Text = "";
                counter = 20;
                button1.Enabled = true;
                return;
            }
            label2.Text = counter.ToString();
        }
    }
}
