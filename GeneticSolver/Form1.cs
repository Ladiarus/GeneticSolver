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
        List<string> gamets1 = new List<string>();
        List<string> gamets2 = new List<string>();
        string gen1 = "", gen2 = "";
        List<string> allChilds = new List<string>();
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
            allChilds.Clear();
            gen1 = Gen1.Text;
            gen2 = Gen2.Text;
            ExtractGamets();
            rec(0, "");
            for (int c = 0; c < allChilds.Count; c++)
            {
                listView1.Items.Add(allChilds[c]);
            }
        }
        void ExtractGamets()
        {
            gamets1.Clear();
            gamets2.Clear();
            try
            {
                
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("WTF?\nEnter Gens");
                return;
            }
            for (int i = 0; i < gen1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    gamets1.Add("");
                    gamets1[i / 2] += gen1[i];
                }
                else if (gamets1[i/2][0] != gen1[i])
                {
                    gamets1[i/2] += gen1[i];
                }
            }
            for (int i = 0; i < gen2.Length; i++)
            {
                if (i % 2 == 0)
                {
                    gamets2.Add("");
                    gamets2[i / 2] += gen2[i];
                }
                else if (gamets2[i / 2][0] != gen2[i])
                {
                    gamets2[i / 2] += gen2[i];
                }
            }
        }
        void Merge()
        {
            
        }
        
        void rec(int index, string s)
        {
            if (index >= gamets1.Count)
            {
                allChilds.Add(s);
                return;
            }
            rec(index+1,s+gamets1[index][0]+gamets2[index][0]);
            if (gamets1[index].Length >= 2)
            {
                rec(index + 1, s + gamets1[index][1] + gamets2[index][0]);
            }
            if (gamets2[index].Length >= 2)
            {
                rec(index + 1, s + gamets1[index][0] + gamets2[index][1]);
            }
            if (gamets1[index].Length >= 2&& gamets2[index].Length >= 2)
            {
                rec(index + 1, s + gamets1[index][1] + gamets2[index][1]);
            }
            
        }
    }
}
