using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_3_19_Strelkov_DN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class Compl<T>
        {
            private int Cena;
            private string God;
            T articul;
            public Compl(int cena, string god, T ar)
            {
                Cena = cena;
                God = god;
                articul = ar;
            }
            public virtual string Display()
            {
                return ($"Цена: {Cena}, Год выпуска: {God}, Артикул: {articul}");
            }
        }
        class CP<T> : Compl<T>
        {
            public string chas { get; set; }
            public int koly { get; set; }
            public int kolp { get; set; }
            public CP(string CH, int KY, int KP, int cena, string god, T ar) : base(cena, god, ar)
            {
                chas = CH;
                koly = KY;
                kolp = KP;
            }
            public override string Display()
            {
                return ($"Частота: {chas}, Кол-во ядер: {koly}, Кол-во потоков: {kolp}");
            }
        }
        class Video<T> : Compl<T>
        {
            private string GPU { get; set; }
            private string Proiz { get; set; }
            private int Ob { get; set; }
            public Video(string gpu, string pro, int ob, int cena, string god, T ar) : base(cena, god, ar)
            {
                GPU = gpu;
                Proiz = pro;
                Ob = ob;
            }
            public override string Display()
            {
                return ($"Частота GPU: {GPU}, Производитель: {Proiz}, Объём памяти: {Ob}");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            CP<int> n1 = new CP<int>(textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(n1.Display());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Video<int> n2 = new Video<int>(textBox6.Text, textBox7.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(n2.Display());
        }
    }
}
