using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game_Life__WF_.Model
{
    public class Square
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Generation { get; set; }
        public bool Alive { get; set; }
        public Button Btn { get; set; } = new Button();

        public Square() 
        {
            X = 0;
            Y = 0;
            Size = 0;
            Generation = 0;
            Alive = false;
            Btn.BackColor = Color.White;
            Btn.Margin = new Padding(0);
            Btn.Width = 0;
            Btn.Height = 0;
            Btn.Location = new Point(X, Y);
            Btn.Click += Btn_Click;
        }

        public Square(int row, int column, int size, int generation, bool alive, string btnName)
        {
            X = size*column;
            Y = size*row;
            Size = size;
            Generation = generation;
            Alive = alive;
            if (Alive)
            {
                Btn.BackColor = Color.FromArgb(generation > 1000 ? 250 : generation - 750, generation > 750 ? 250 : generation - 500, generation > 500 ? 250 : generation-250, generation>250?250:generation);
                Btn.Width = size;
                Btn.Height = size;
                Btn.Location = new Point(X, Y);
                Btn.Name = btnName;
                Btn.Margin = new Padding(0);
            }
            else
            {
                Btn.BackColor = Color.White;
                Btn.Width = size;
                Btn.Height = size;
                Generation = 0;
                Btn.Location = new Point(X, Y);
                Btn.Click += Btn_Click;
                Btn.Name = btnName;
                Btn.Margin = new Padding(0);
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (Btn.BackColor == Color.White) 
            { 
                Btn.BackColor = Color.Black;
                Alive = true;
            }
        }

        public bool GetLifeState()
        {
            return Alive;
        }

        public void SetLifeState(bool value, int generation)
        {
            if (value && !Alive)
            {
                Alive = true;
                int R = 0;
                int G = 0;
                int B = 0;
                    generation %= 1530;
                if (generation > 255)
                {
                    if (generation > 510)
                    {
                        if (generation > 765)
                        {
                            if (generation <= 1020)
                            {
                                G = 1020 - generation;
                            }
                            else if (generation >1020 && generation <= 1275)
                            {
                                B = 1275 - generation;
                            }
                            else if (generation > 1275 && generation <= 1530)
                            {
                                R = 1530 - generation;
                            }
                        }
                        else
                        {
                            R = generation - 510;
                        }
                    }
                    else
                    {
                        G = generation - 255;
                    }
                }
                else
                {
                    B= generation;
                }
                Btn.BackColor = Color.FromArgb(180, R, G, B);
                generation++;
            }
            else if (value && Alive)
            {
                Alive = true;
            }
            else
            {
                Alive = false;
                Btn.BackColor = Color.White;
                Generation = 0;
            }
        }
    }
}
