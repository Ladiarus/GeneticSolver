using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

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
        int fwdClicksCount = 0, searchClcksCount = -2;
        public Form1()
        {
            InitializeComponent();
        }
        //googled something and found Application.ToString() method WTF actually

        void SearchInLB(string keyword)
        {
            List<string> keywords = new List<string>();
            string addable = "";
            for (int i = 0; i < keyword.Length; i++)
            {
                if (keyword[i] == ' ' || keyword[i] == ',' || i == keyword.Length - 1)
                {
                    keywords.Add(addable);
                    addable = "";
                }
                else addable += keyword[i];
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                bool check = true;
                foreach(string c in keywords)
                {
                    if (!listBox1.Items[i].ToString().Contains(c))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    listBox1.SetSelected(i, true);
                    try
                    {
                        if (listBox1.Items[i - 1].ToString() != "\n")
                        {
                            listBox1.SetSelected(i - 1, true);
                        }
                        if (listBox1.Items[i + 1].ToString() != "\n")
                        {
                            listBox1.SetSelected(i + 1, true);
                        }
                    }
                    catch (Exception) { }
                }
            }
        }

        void generClick()
        {
            if (Gen1.Text == "" || Gen2.Text == "" || Gen2.Text.Length != Gen1.Text.Length)
            {
                MessageBox.Show("Input error", "Avtor dodik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (generateButton.Text == "Generate")
            {
                fwdClicksCount = 0;
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
                textBox1.Clear();
                signs.Clear();
                searchClcksCount = -2;
                listBox1.ClearSelected();
            }
        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            generClick();
        }
        void EnterSigns()
        {

            if (signs.ContainsKey(genLabel.Text))
            {
                if (textBox1.Text != "")
                    signs[genLabel.Text] = textBox1.Text;
            }
            else if (textBox1.Text != null) signs.Add(genLabel.Text, textBox1.Text);

        }
        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (this.ActiveControl.Name)
                {
                    case "Gen1":
                        Gen2.Focus();
                        break;
                    case "Gen2":
                        generClick();
                        textBox1.Focus();
                        break;
                    case "textBox1":
                        if (fwdClicksCount != everything.Length - 1)
                            button1_Click(button1, new EventArgs());
                        else
                        {
                            generateButton_Click(generateButton, new EventArgs());
                            genLabel.Focus();
                        }
                        break;
                    case "searchTB":
                        button3_Click(button3, new EventArgs());
                        break;
                    default:
                        MessageBox.Show("не жми на энтер просто так сука");
                        break;
                }

            }
        }
        private void Generate()
        {
            dict.Clear();
            ExtractGamets();
            EnterSigns();
            textBox1.Clear();
            genLabel.Text = "";
            fwdClicksCount = 0;
            try
            {
                Merge();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("WTF?\nEnter Gens");
                return;
            }
            foreach (KeyValuePair<string, int> p in dict)
            {
                string description = "";
                for (int i = 0; i < p.Key.Length; i += 2)
                {
                    try
                    {
                        description += signs[p.Key[i].ToString()] + " ";
                    }
                    catch (Exception) { }
                }
                listBox1.Items.Add(p.Key + " " + (((double)p.Value) / allChilds.Count * 100).ToString() + "%\n");
                listBox1.Items.Add(description);
                listBox1.Items.Add("\n");

                description = "";
            }
            signs.Clear();
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
                else if (gamets1[i / 2][0] != gen1[i])
                {
                    gamets1[i / 2] += gen1[i];
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (searchClcksCount == -2)
            {
                SearchInLB(searchTB.Text+" ");
            }
            if (searchClcksCount < listBox1.SelectedIndices.Count - 2)
                searchClcksCount += 2;
            listBox1.TopIndex = listBox1.SelectedIndices[searchClcksCount];

        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            searchClcksCount = -2;
            listBox1.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnterSigns();
            if (fwdClicksCount > 0)
            {
                fwdClicksCount--;
                textBox1.Clear();
            }
            try
            {
                genLabel.Text = everything[fwdClicksCount].ToString();
                textBox1.Text = signs[genLabel.Text];
            }
            catch (Exception) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterSigns();
            if (fwdClicksCount < everything.Length - 1)
            {
                fwdClicksCount++;
                textBox1.Clear();
            }
            try
            {
                genLabel.Text = everything[fwdClicksCount].ToString();
                textBox1.Text = signs[genLabel.Text];
            }
            catch (Exception) { }
        }

        void rec(int index, string s)
        {
            if (index >= gamets1.Count)
            {
                if (!dict.ContainsKey(s))
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
            if (gamets1[index].Length >= 2 && gamets2[index].Length >= 2)
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
