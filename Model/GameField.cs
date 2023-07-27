using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Game_Life__WF_.Model
{
    public class GameField
    {
        public Square[,] Field;
        public int Columns {  get; set; }
        public int Rows { get; set; }
        public int SquareSize { get; set; }

        public int[,] Values { get; set; }

        public GameField(int rows, int columns, int size) 
        {
            Columns = columns;
            Rows = rows;
            SquareSize = size;
            Field = new Square[rows, columns];
            Values = new int[rows, columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Field[i,j] = new Square (i, j, size, 0, false, $"{i * Columns + j}");
                }
            }
        }

        public Control[] GetArrayButtons()
        {
            int count = 0;
            Control[] buttons = new Button[Field.Length];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                     buttons[count] = Field[i, j].Btn;
                    count++;
                }
            }
            return buttons;
        }

        public bool EvolutionStep(int generation)
        {
            int[,] tmp = new int[Rows, Columns];
            int count;
            for (int i = 0; i < Rows; i++)
            {
                Task task = new Task(() => LineTraversal(i, ref tmp));
                task.RunSynchronously();
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Field[i, j].Alive && (tmp[i,j] > 3 || tmp[i, j] < 2))
                        Field[i, j].SetLifeState(false, generation);
                    if (Field[i, j].Alive && (tmp[i, j] == 3 || tmp[i, j] == 2))
                        Field[i, j].SetLifeState(true, generation);
                    if (!Field[i, j].Alive && tmp[i, j] == 3)
                        Field[i, j].SetLifeState(true, generation);
                }
            }
            int num = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!Values[i, j].Equals(tmp[i, j]))
                        num++;
                }
            }
            Values = tmp;
            return num == 0;
        }

        private void LineTraversal(int i, ref int[,] tmp)
        {
            int count = 0;
            for (int j = 0; j < Columns; j++)
            {
                if (i > 0 && i < Rows - 1 && j > 0 && j < Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j + 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == 0 && j > 0 && j < Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[Rows - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j - 1].GetLifeState() ? 1 : 0) + (Field[Rows - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j + 1].GetLifeState() ? 1 : 0) + (Field[Rows - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == Rows - 1 && j > 0 && j < Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[0, j].GetLifeState() ? 1 : 0) +
                            (Field[0, j - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[0, j + 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i > 0 && i < Rows - 1 && j == 0)
                {
                    count = (Field[i, Columns - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, Columns - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, Columns - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j + 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i > 0 && i < Rows - 1 && j == Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, 0].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, 0].GetLifeState() ? 1 : 0) + (Field[i - 1, 0].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == 0 && j == 0)
                {
                    count = (Field[i, Columns - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[Rows - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, Columns - 1].GetLifeState() ? 1 : 0) + (Field[Rows - 1, Columns - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j + 1].GetLifeState() ? 1 : 0) + (Field[Rows - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == 0 && j == Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, 0].GetLifeState() ? 1 : 0) +
                            (Field[Rows - 1, j].GetLifeState() ? 1 : 0) + (Field[i + 1, j].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, j - 1].GetLifeState() ? 1 : 0) + (Field[Rows - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[i + 1, 0].GetLifeState() ? 1 : 0) + (Field[Rows - 1, 0].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == Rows - 1 && j == 0)
                {
                    count = (Field[i, Columns - 1].GetLifeState() ? 1 : 0) + (Field[i, j + 1].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[0, j].GetLifeState() ? 1 : 0) +
                            (Field[0, Columns - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, Columns - 1].GetLifeState() ? 1 : 0) +
                            (Field[0, j + 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j + 1].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                else if (i == Rows - 1 && j == Columns - 1)
                {
                    count = (Field[i, j - 1].GetLifeState() ? 1 : 0) + (Field[i, 0].GetLifeState() ? 1 : 0) +
                            (Field[i - 1, j].GetLifeState() ? 1 : 0) + (Field[0, j].GetLifeState() ? 1 : 0) +
                            (Field[0, j - 1].GetLifeState() ? 1 : 0) + (Field[i - 1, j - 1].GetLifeState() ? 1 : 0) +
                            (Field[0, 0].GetLifeState() ? 1 : 0) + (Field[i - 1, 0].GetLifeState() ? 1 : 0);
                    tmp[i, j] = count;
                }
                count = 0;
            }
        }

        public void AutoFill(int percentFill)
        {
            int tmp;
            if (percentFill <1 || percentFill > 100)
                percentFill = 40;
            Random  random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    tmp = random.Next(100);
                    if (tmp >= percentFill)
                        Field[i, j].SetLifeState(true, 0);
                }
            }
        }

    }
}
