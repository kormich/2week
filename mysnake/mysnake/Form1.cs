using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    public partial class Form1 : Form
    {
        private Label labelScore;
        private int width = 600;
        private int height = 600;
        private int sizesnake = 40;
        private int forX, forY;
        private int rX, rY;
        private PictureBox fruit;




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            
            InitializeComponent();
            this.Width = width+60;
            this.Height = height+120;

            Map();

            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(this.Width/2-30, 40);
            this.Controls.Add(labelScore);

            this.KeyDown += new KeyEventHandler(Run);
            forX = 1;
            forY = 0;

            timer1.Tick += new EventHandler(update);
            timer1.Interval = 250;
            timer1.Start();

            fruit = new PictureBox();
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(sizesnake, sizesnake);
            generateFruit();

        }


        private void Map()
        {
            for (int i = 2; i <= width / sizesnake +1; i++)
            {
                PictureBox lines = new PictureBox();
                lines.BackColor = Color.Black;
                lines.Location = new Point(40, sizesnake * i);
                lines.Size = new Size(width-40, 1);
                this.Controls.Add(lines);
            }
            for (int i = 1; i <= height / sizesnake ; i++)
            {
                PictureBox lines = new PictureBox();
                lines.BackColor = Color.Black;
                lines.Location = new Point(sizesnake * i, 80);
                lines.Size = new Size(1, width-40);
                this.Controls.Add(lines);
            }
        }
        private void update(Object myObject, EventArgs eventsArgs)
        {
            cube.Location = new Point(cube.Location.X + forX * sizesnake, cube.Location.Y + forY * sizesnake);
        }
        private void Run(object sender, KeyEventArgs a)
        {
            switch (a.KeyCode.ToString())
            {
                case "Right":
                    forX = 1;
                    forY = 0;
                    break;
                case "Left":
                    forX = -1;
                    forY = 0;
                    break;
                case "Up":
                    forY = -1;
                    forX = 0;
                    break;
                case "Down":
                    forY = 1;
                    forX = 0;
                    break;
            }
        }
        private void generateFruit()
        {
            Random r = new Random();
            rX = r.Next(40, width-40);
            int tempI = rX % sizesnake;
            rX -= tempI;
            rY = r.Next(80, width - 40);
            int tempJ = rY % sizesnake;
            rY -= tempJ;
            fruit.Location = new Point(rX, rY);
            this.Controls.Add(fruit);
        }




    }



}
