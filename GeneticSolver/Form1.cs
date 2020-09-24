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
        Dictionary<string, int> dict = new Dictionary<string, int>();
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
        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Generate();
        }
        private void Generate()
        {
            
            qwe = 0;
            listBox1.Items.Clear();
            listView1.Items.Clear();
            allChilds.Clear();
            gen1 = Gen1.Text;
            gen2 = Gen2.Text;
            ExtractGamets();
            try
            {
                Merge();
                MessageBox.Show(qwe.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("WTF?\nEnter Gens");
                return;
            }
            foreach(KeyValuePair<string, int> p in dict)
            {
                listBox1.Items.Add(p.Key + " " + ((double)p.Value)/allChilds.Count*100 + "%");
            }
        }
        void ExtractGamets()
        {
            gamets1.Clear();
            gamets2.Clear();
            
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
            rec(0, "");
        }
        string temp = "";
        int qwe=0;
        void rec(int index, string s)
        {
            qwe++;
            if (index >= gamets1.Count)
            {
                if(!dict.ContainsKey(s))
                    dict.Add(s, 1);
                else dict[s]++;
                allChilds.Add(s);
                return;
            }
            temp = gamets1[index][0].ToString() + gamets2[index][0].ToString();
            if (temp[1] < temp[0])
            {
                char[] charray = temp.ToCharArray();
                Array.Reverse(charray);
                temp = new string(charray);
            }
            rec(index + 1, s + temp);
            if (gamets1[index].Length >= 2)
            {
                temp = gamets1[index][1].ToString() + gamets2[index][0].ToString();
                if (temp[1] < temp[0])
                {
                    char[] charray = temp.ToCharArray();
                    Array.Reverse(charray);
                    temp = new string(charray);
                }
                rec(index + 1, s + temp);
            }
            if (gamets2[index].Length >= 2)
            {
                temp = gamets1[index][0].ToString() + gamets2[index][1].ToString();
                if (temp[1] < temp[0])
                {
                    char[] charray = temp.ToCharArray();
                    Array.Reverse(charray);
                    temp = new string(charray);
                }
                rec(index + 1, s + temp);
            }
            if (gamets1[index].Length >= 2&& gamets2[index].Length >= 2)
            {
                temp = gamets1[index][1].ToString() + gamets2[index][1].ToString();
                if (temp[1] < temp[0])
                {
                    char[] charray = temp.ToCharArray();
                    Array.Reverse(charray);
                    temp = new string(charray);
                }
                rec(index + 1, s + temp);
            }
            
        }
    }
}
