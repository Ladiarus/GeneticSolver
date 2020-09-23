using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticSolver
{
    public partial class Form1 : Form
    {
        string gen1, gen2;
        string gamets1 = "", gamets2 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Generate();
        }
        private void Generate()
        {
            listBox1.Items.Clear();
            listView1.Items.Clear();
            gen1 = Gen1.Text;
            gen2 = Gen2.Text;
            ExtractGamets();
            for (int i = 0; i < (gamets1 != "" ? 1:0); i++)
            {
                listView1.Items.Add(gamets1);
                listView1.Items.Add(gamets2);
                listBox1.Items.Add(gamets1);
                listBox1.Items.Add(gamets2);
            }
        }
        void ExtractGamets()
        {
            gamets1 = "";
            gamets2 = "";
            try
            {
                gamets1 += gen1[0];
                gamets2 += gen2[0];
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("WTF?\nEnter Gens");
                return;
            }
            for (int i = 1; i < gen1.Length; i++)
            {
                if (gamets1[gamets1.Length - 1] != gen1[i])
                {
                    gamets1 += gen1[i];
                }
            }
            for (int i = 1; i < gen2.Length; i++)
            {
                if (gamets2[gamets2.Length - 1] != gen2[i])
                {
                    gamets2 += gen2[i];
                }
            }
        }
    }
}
