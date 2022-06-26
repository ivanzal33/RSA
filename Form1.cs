using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //считывает данные из textbox
            int p = Convert.ToInt32(textBox1.Text);
            // проверка числа p 
            int numberp = p;
            int peremenp = 0;
            int sp = 0;
            int jp = 2;
            if (numberp > 1)
            {
                for (; jp < numberp; jp++)//перебирает числа на которые делить
                {
                    peremenp = numberp % jp;// проверка на остаток
                    if (peremenp == 0)
                    {
                        sp = 1;
                        break;
                    }

                }
                if (sp == 0)
                {
                    int q = Convert.ToInt32(textBox2.Text);
                    // проверка числа q
                    int numberq = q;
                    int peremenq = 0;
                    int sq = 0;
                    int jq = 2;
                    if (numberq > 1)
                    {
                        for (; jq < numberq; jq++)//перебирает числа на которые делить
                        {
                            peremenq = numberq % jq;// проверка на остаток
                            if (peremenq == 0)
                            {

                                sq = 1;
                                break;
                            }

                        }
                        if (sq == 0)
                        {
                            //вычисляем модуль
                            int n = p * q;
                            //вычисляем функцию Эйлера
                            int function = (p - 1) * (q - 1);
                            //ищем простые числа и заносим их в массив
                            int max = function; //число до которого искать
                            int peremen = 0;
                            int s = 0;
                            int r = 0;
                            int[] mas1 = new int[max];
                            for (int i = 2; i <= max; i++)//перебирает все числа до max
                            {
                                int j = 2;
                                for (; j < i; j++)//перебирает числа на которые делить
                                {
                                    peremen = i % j;// проверка на остаток
                                    if (peremen == 0)
                                    {
                                        s = 1;
                                        break;
                                    }

                                }
                                if (s == 0)
                                {
                                    mas1[r] = i;
                                    r = r + 1;
                                }
                                s = 0;
                            }
                            int c = 0; // Вычисляем сколько значимых чисел (не нулей) в массиве
                            for (int i = 0; i < max; i++)
                            {
                                if (mas1[i] != 0)
                                {
                                    c = c + 1;
                                }
                            }
                            int[] mass2 = new int[c]; // создаем массив где хранятся только числа из 1 массива
                            for (int i = 0; i < c; i++)
                            {
                                mass2[i] = mas1[i];
                            }
                            //ищим взаимно простое число относительно функции Эйлера
                            int E = 0;
                            for (int i = 0; i < (c - 1); i++)
                            {
                                int number = function % mass2[i];
                                if (mass2[i] < function && number != 0)
                                {
                                    E = mass2[i];
                                    break;
                                }
                            }
                            //ищим закрытый ключ 
                            int d = 0;
                            for (int i = 1; i < 1000; i++)
                            {
                                d = (i * E) % function;
                                if (d == 1)
                                {
                                    d = i;
                                    break;
                                }
                            }
                            //зашивровка
                            int P = Convert.ToInt32(textBox4.Text);
                            if (P < n)
                            {
                                ulong a = Convert.ToUInt64(Math.Pow(P, E) % n);

                                // расшифровка
                                ulong B = Convert.ToUInt64(Math.Pow(a, d) % n);
                                //
                                textBox3.Text = ("открытые ключи: e = " + E + "; n = " + n) +
                                    Environment.NewLine + ("закрытые ключи: d = " + d + "; n = " + n) +
                                        Environment.NewLine + ("Вы зашифровываете число: " + P) +
                                            Environment.NewLine + ("Зашифровонное число: " + a) +
                                                Environment.NewLine + ("Расшифрованое число: " + B);
                            }
                            else
                            {
                                textBox3.Text = ("Вы хотите зашифровать слишком большое число!");
                            }
                        }
                        else
                        {
                            textBox3.Text = ("Число '" + q + "' - нелязя использовать так как оно не простое");
                        }
                    }
                    else
                    {
                        textBox3.Text = ("Число '" + q + "' - нелязя использовать так как оно не простое");
                    }

                }
                else
                {
                    textBox3.Text = ("Число '" + p + "' - нелязя использовать так как оно не простое");
                }
            }
            else
            {
                textBox3.Text = ("Число '" + p + "' - нелязя использовать так как оно не простое");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
