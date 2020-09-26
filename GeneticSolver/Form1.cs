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
        Dictionary<string, string> signs = new Dictionary<string, string>();
        List<string> gamets1 = new List<string>();
        List<string> gamets2 = new List<string>();
        string gen1 = "", gen2 = "", everything;
        List<string> allChilds = new List<string>();
        HashSet<char> evth;
        int fwdClicksCount = 0;
        int bwdClicksCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //googled something and found Application.ToString() method WTF actually
          private void generateButton_Click(object sender, EventArgs e)
        {


            if (generateButton.Text == "Generate")
            {
                fwdClicksCount = 0;
                bwdClicksCount = 0;
                generateButton.Text = "Submit";
                Generate();
            }
            else
            { 
                generateButton.Text = "Generate";
                listBox1.Items.Clear();
                allChilds.Clear();
                gen1 = Gen1.Text;
                gen2 = Gen2.Text;
                everything = gen1 + gen2;
                evth = new HashSet<char>(everything);
                everything = new string(evth.ToArray<char>());
                genLabel.Text = everything[0].ToString();
                signs.Clear();
                fwdClicksCount++;
            }
            }
        void EnterSigns()
        {
            
            if (signs.ContainsKey(genLabel.Text))
            {
                if(textBox1.Text!="")
                signs[genLabel.Text] = textBox1.Text;
            }
            else if (textBox1.Text != null) signs.Add(genLabel.Text, textBox1.Text);
            
        }
        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Generate();
        }
        private void Generate()
        {
            
            qwe = 0;
            dict.Clear();
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
                string description = "";
                for(int i = 0; i < p.Key.Length;i+=2)
                {
                    try
                    {
                        description += signs[p.Key[i].ToString()] + " ";
                    }
                    catch (Exception) { }
                }
                listBox1.Items.Add(p.Key + " " + (((double)p.Value)/allChilds.Count*100).ToString() + "%\n");
              
                listBox1.Items.Add(description);
                
                description = "";
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (fwdClicksCount > 0) 
            { 
                fwdClicksCount--;
                textBox1.Clear(); 
            }
            try
            {
                genLabel.Text = everything[fwdClicksCount].ToString();
            }
            catch (Exception) { }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            EnterSigns();
            
            try
            {
                genLabel.Text = everything[fwdClicksCount].ToString();
            }
            catch (Exception) { }
            if (fwdClicksCount <= everything.Length - 1)
            {
                if (fwdClicksCount < everything.Length - 1)
                    fwdClicksCount++;
                textBox1.Clear();
            }


        }

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
