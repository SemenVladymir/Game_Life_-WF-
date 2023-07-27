using Game_Life__WF_.Model;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Game_Life__WF_
{
    public partial class Form1 : Form
    {
        public GameField MyGameField;
        public int squareSize = 20;
        private bool stop = false;
        private int gen = 0;
        Timer _timer = new Timer();
        private bool autoFill = false;
        private int percentFill = 40;


        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 100;
            _timer.Tick += OnTimerTick;
            Fill.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyGameField = new GameField(Field.Height / squareSize, Field.Width / squareSize, squareSize);
            Field.Controls.AddRange(MyGameField.GetArrayButtons());
            Delay.Text = $"300";
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            stop = false;
            if (gen == 0 && AutoFill.Checked && !string.IsNullOrEmpty(Fill.Text))
            {
                autoFill = true;
                if (Int32.TryParse(Fill.Text, out int num))
                    percentFill = num;
            }
            AutoFill.Enabled = false;
            Fill.Enabled = false;
            _timer.Start();
            Task ts = Task.Factory.StartNew(() => { Life(); });
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            Generation.Text = gen.ToString();
        }

        private async Task Life()
        {
            int delay;
            if (Int32.TryParse(Delay.Text, out int num))
                delay = num;
            else
                delay = 300;
            if (gen == 0 && autoFill)
                MyGameField.AutoFill(percentFill);
            int col = Field.Width / squareSize;
            int i, j;
            while (!stop)
            {
                gen++;
                if (!MyGameField.EvolutionStep(gen))
                {
                    foreach (var button in Field.Controls)
                    {
                        if (button is Button btn)
                        {
                            i = Convert.ToInt32(btn.Name) / col;
                            j = Convert.ToInt32(btn.Name) % col;
                            btn.BackColor = MyGameField.Field[i, j].Btn.BackColor;
                        }
                    }
                    await Task.Delay(delay);
                }
                else
                {
                    MessageBox.Show("Evolution stoped! You can add some food to the game-field for evolution continue.");
                    stop = true;
                }
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            stop = true;
            _timer.Stop();
        }

        private void Delay_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void Fill_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void AutoFill_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoFill.Checked == true)
            {
                Fill.Enabled = true;
            }
            else
                Fill.Enabled = false;
        }
    }
}