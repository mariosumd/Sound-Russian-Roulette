using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        private Timer timer1;
        private int counter = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (rnd.Next(6)) // 1/7 chance
            {
                case 2: Boom();
                    break;
                default: Saved();
                    break;
            }
        }

        private void Boom()
        {
            //random music chosen
            //music plays

            label1.ForeColor = Color.Red;
            label1.Text = "HORROR MUSIC"; // Name of the music will be displayed here
            button1.Enabled = false;

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
