using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Security.Cryptography;

namespace Lab5
{
    public partial class Form1 : Form
    {
        string[] id = new string[100];
        string[] nume = new string[100];
        string[] descriere = new string [100];
        string[] dataScadenta = new string[100];
        string[] prioritate = new string[100];
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        int optiune;
        char ch;
        string[] textLista = new string[500];
        int ok;
        string sir;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Fara Nume";
            fillListBox();
        }

        string output = "{0,-2}\t\t{1,-50}\t\t{2,-90}\t\t{3,-35}{4,-5}";
        string outputNume = "\t{1,-30}";

        void fillListBox()
        {
            listBox1.Items.Add(string.Format(output, "Id", "Nume", "Descriere", "Data Scadenta", "Prioritate "));
            id[0] = "Id";
            nume[0] = "Nume";
            descriere[0] = "Descriere";
            dataScadenta[0] = "Data Scadenta";
            prioritate[0] = "Prioritate";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int verif = 0;
            if(textBoxNume.Text == "" || textBoxDescriere.Text == "" || textBoxData.Text == "" || textBoxPrioritate.Text == "")
                {
                    MessageBox.Show("Completeaza toate campurile !");
                verif = 1;
                }
            char[] ch = new char[100];
            ch = textBoxNume.Text.ToCharArray();
            
                if (!char.IsLetter(ch[0]))
                {
                MessageBox.Show("Primul caracter al numelui trebuie sa fie o litera !");
                verif = 1;
                }
                
                for(int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == ' ' && ch[i+1] == ' ')
                {
                    MessageBox.Show("Numele nu trebuie sa contina 2 spati consecutive !");
                    verif = 1;
                    break;
                }
            }

            ch = textBoxDescriere.Text.ToCharArray();

            if (!char.IsLetter(ch[0]))
            {
                MessageBox.Show("Primul caracter al descrierii trebuie sa fie o litera !");
                verif = 1;
            }
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == ' ' && ch[i + 1] == ' ')
                {
                    MessageBox.Show("Descrierea nu trebuie sa contina 2 spati consecutive !");
                    verif = 1;
                    break;
                }
            }

            ch = textBoxData.Text.ToCharArray();
            if (ch[2] != '.' || ch[5] != '.' || ch[0] == '.' || ch[1] == '.' || ch[3] == '.' || ch[4] == '.' || ch[6] == '.' || ch[7] == '.' || ch[8] == '.' || ch[9] == '.' || textBoxData.TextLength < 10)
            {
                MessageBox.Show("Respecta formatul datei: dd.mm.yyyy (ex: 24.05.2022) !");
                verif = 1;
            }
            if (ch[0] == '3' && ch[1] > 1)
            {
                MessageBox.Show("O luna are maxim 31 de zile !");
                verif = 1;
            }

            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0 && verif == 0)
            {
                listBox1.Items[listBox1.SelectedIndex] = string.Format(output, id[listBox1.SelectedIndex] = Convert.ToString(listBox1.SelectedIndex), nume[listBox1.SelectedIndex] = textBoxNume.Text, descriere[listBox1.SelectedIndex] = textBoxDescriere.Text, dataScadenta[listBox1.SelectedIndex] = textBoxData.Text, prioritate[listBox1.SelectedIndex] = textBoxPrioritate.Text);
                textBoxNume.ReadOnly = true;
                textBoxDescriere.ReadOnly = true;
                textBoxData.ReadOnly = true;
                textBoxPrioritate.ReadOnly = true;
            }
            
            for(int i = 1; i < listBox1.Items.Count; i++)
            {
                if(verif == 0 && dataScadenta[i] != "")
                {
                    DateTime date2;
                DateTime date1 = DateTime.Parse(dataScadenta[listBox1.SelectedIndex]);
                    date2 = DateTime.Parse(dataScadenta[i]);
                    if(date1.Date < date2.Date && listBox1.SelectedIndex > i)
                    {
                        sir = Convert.ToString(listBox1.Items[listBox1.SelectedIndex]);
                        listBox1.Items[listBox1.SelectedIndex] = listBox1.Items[i];
                        listBox1.Items[i] = sir;

                        sir = nume[listBox1.SelectedIndex];
                        nume[listBox1.SelectedIndex] = nume[i];
                        nume[i] = sir;

                        sir = descriere[listBox1.SelectedIndex];
                        descriere[listBox1.SelectedIndex] = descriere[i];
                        descriere[i] = sir;

                        sir = dataScadenta[listBox1.SelectedIndex];
                        dataScadenta[listBox1.SelectedIndex] = dataScadenta[i];
                        dataScadenta[i] = sir;

                        sir = prioritate[listBox1.SelectedIndex];
                        prioritate[listBox1.SelectedIndex] = prioritate[i];
                        prioritate[i] = sir;

                        sir = id[listBox1.SelectedIndex];
                        id[listBox1.SelectedIndex] = id[i];
                        id[i] = sir;

                    }

                    if (date1.Date > date2.Date && listBox1.SelectedIndex < i)
                    {
                        sir = Convert.ToString(listBox1.Items[i]);
                        listBox1.Items[i] = listBox1.Items[listBox1.SelectedIndex];
                        listBox1.Items[listBox1.SelectedIndex] = sir;

                        sir = nume[i];
                        nume[i] = nume[listBox1.SelectedIndex];
                        nume[listBox1.SelectedIndex] = sir;

                        sir = descriere[i];
                        descriere[i] = descriere[listBox1.SelectedIndex];
                        descriere[listBox1.SelectedIndex] = sir;

                        sir = dataScadenta[i];
                        dataScadenta[i] = dataScadenta[listBox1.SelectedIndex];
                        dataScadenta[listBox1.SelectedIndex] = sir;

                        sir = prioritate[i];
                        prioritate[i] = prioritate[listBox1.SelectedIndex];
                        prioritate[listBox1.SelectedIndex] = sir;

                        sir = id[i];
                        id[i] = id[listBox1.SelectedIndex];
                        id[listBox1.SelectedIndex] = sir;

                    }
                
                    }
                



            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {ok = 0;
            int gol = 1;
            int lungime = 0;
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0)
            {
                using (StringReader sr1 = new StringReader(listBox1.GetItemText(listBox1.Items[listBox1.SelectedIndex])))
                {
                    do
                    {
                        ch = (char)sr1.Read();
                        char spatiu = ' ';
                        lungime++;
                        if (ch == spatiu)
                        {
                            ok++;
                        }
                    } while (lungime < 70);
                    if (ok >= lungime)
                        gol = 1;
                    else if (ok < lungime -5) gol = 0;
                }
            }
                if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0 && optiune == 2 && gol == 0)
                 {
                textLista[listBox1.SelectedIndex] = listBox1.GetItemText(listBox1.Items[listBox1.SelectedIndex]);
                textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(' '));
                char ch;
                using (StringReader sr = new StringReader(textLista[listBox1.SelectedIndex]))
                {
                    int gasitNume = 0;
                    int gasitDesc = 1;
                    int gasitData = 1;
                    int gasitPrioritate = 0;
                    do
                    {
                        ch = (char)sr.Read();
                        if ((ch >= 'A' && ch <= 'Z' && gasitNume == 0) || (ch >= 'a' && ch <= 'z' && gasitNume == 0))
                        {
                            int p = 0;
                            textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch));
                            char[] ch2 = new char[textLista[listBox1.SelectedIndex].Length];
                            ch2 = textLista[listBox1.SelectedIndex].ToCharArray();
                            while (ch2[p] != ' ' || ch2[p + 1] != ' ')
                            {
                                p++;
                            }

                                nume[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch), p - textLista[listBox1.SelectedIndex].IndexOf(ch));
                                textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(p);
                                gasitNume = 1;
                                textBoxNume.Text = nume[listBox1.SelectedIndex];
                                gasitDesc = 0;
                                gasitData = 0;
                                gasitPrioritate = 0;
                                for(int i = 0; i < nume[listBox1.SelectedIndex].Length; i++ )
                                ch = (char)sr.Read();
                            
                            
                        }
                        else if ((ch >= 'A' && ch <= 'Z' && gasitDesc == 0) || (ch >= 'a' && ch <= 'z' && gasitDesc == 0))
                        {
                            textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch));
                            char[] ch2 = new char[textLista[listBox1.SelectedIndex].Length];
                            ch2 = textLista[listBox1.SelectedIndex].ToCharArray();
                            int p = 0;
                            while (ch2[p] != ' ' || ch2[p+1] != ' ')
                            {
                                p++;
                            }

                            descriere[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch), p - textLista[listBox1.SelectedIndex].IndexOf(ch));
                            textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(p);
                            gasitDesc = 1;
                            textBoxDescriere.Text = descriere[listBox1.SelectedIndex];
                            gasitData = 0;
                            gasitPrioritate = 0;
                            for (int i = 0; i < descriere[listBox1.SelectedIndex].Length; i++)
                                ch = (char)sr.Read();
                        }

                        else if ((ch >= '0' && ch <= '9' && gasitData == 0) || (ch == '.' && gasitData == 0))
                        {
                            textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch));
                            char[] ch2 = new char[textLista[listBox1.SelectedIndex].Length];
                            ch2 = textLista[listBox1.SelectedIndex].ToCharArray();
                            int p = 0;
                            while (ch2[p] != ' ' || ch2[p+1] != ' ')
                            {
                                p++;
                            }

                            dataScadenta[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch), p - textLista[listBox1.SelectedIndex].IndexOf(ch));
                            textLista[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(p);
                            gasitData = 1;
                            textBoxData.Text = dataScadenta[listBox1.SelectedIndex];
                            gasitPrioritate = 0;
                            for (int i = 0; i < dataScadenta[listBox1.SelectedIndex].Length; i++)
                                ch = (char)sr.Read();
                        }
                        else if (ch >= '1' && ch <= '3' && gasitPrioritate == 0)
                        {
                            prioritate[listBox1.SelectedIndex] = textLista[listBox1.SelectedIndex].Substring(textLista[listBox1.SelectedIndex].IndexOf(ch));
                            gasitPrioritate = 1;
                            textBoxPrioritate.Text = prioritate[listBox1.SelectedIndex];
                            textLista[listBox1.SelectedIndex] = "";
                        }
                    } while (gasitPrioritate == 0);
                }
                 }
           else if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0 && gol == 1)
            {
                textBoxNume.Text = "";
                textBoxDescriere.Text = "";
                textBoxData.Text = "";
                textBoxPrioritate.Text = "";
            }
            else if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0)
            {
                textBoxNume.Text = nume[listBox1.SelectedIndex];
                textBoxDescriere.Text = descriere[listBox1.SelectedIndex];
                textBoxData.Text = dataScadenta[listBox1.SelectedIndex];
                textBoxPrioritate.Text = prioritate[listBox1.SelectedIndex];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0)
            {
                listBox1.Items[listBox1.SelectedIndex] = string.Format(output, id[listBox1.SelectedIndex] = id[listBox1.SelectedIndex], nume[listBox1.SelectedIndex] = "", descriere[listBox1.SelectedIndex] = "", dataScadenta[listBox1.SelectedIndex] = "", prioritate[listBox1.SelectedIndex] = "");
                nume[listBox1.SelectedIndex] = "";
                descriere[listBox1.SelectedIndex] = "";
                dataScadenta[listBox1.SelectedIndex] = "";
                prioritate[listBox1.SelectedIndex] = "";
            }
        }

        private void label2_Click(object sender, EventArgs e){ }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxData_TextChanged(object sender, EventArgs e)
        {
            textBoxData.MaxLength = 10;
        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
            textBoxNume.MaxLength = 20;
        }

        private void textBoxDescriere_TextChanged(object sender, EventArgs e)
        {
            textBoxDescriere.MaxLength = 50;
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formatul pentru data este : dd.mm.yyyy\nPrioritatea are 3 nivele ce se reprezinta prin valori de la 1 (neimportant) la 3 (urgent)\nNume - Maxim 20 caractere; Descriere - Maxim 50 caractere;");
        }

        private void textBoxPrioritate_TextChanged(object sender, EventArgs e)
        {
            textBoxPrioritate.MaxLength = 1;
        }

        private void nouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void adaugatiSarcinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(string.Format(output, id[listBox1.Items.Count] = Convert.ToString(listBox1.Items.Count), nume[listBox1.Items.Count] = "", descriere[listBox1.Items.Count] = "", dataScadenta[listBox1.Items.Count] = "", prioritate[listBox1.Items.Count] = ""));
        }

        private void editatiSarcinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxNume.ReadOnly = false;
            textBoxDescriere.ReadOnly = false;
            textBoxData.ReadOnly = false;
            textBoxPrioritate.ReadOnly = false;
        }

        private void stergetiSarcinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0)
            {
                for (int i = listBox1.SelectedIndex; i < listBox1.Items.Count - 1; i++)
                {
                    listBox1.Items[i] = string.Format(output, id[i] = id[i], nume[i] = nume[i + 1], descriere[i] = descriere[i + 1], dataScadenta[i] = dataScadenta[i + 1], prioritate[i] = prioritate[i + 1]);
                    nume[i] = nume[i + 1];
                    descriere[i] = descriere[i + 1];
                    dataScadenta[i] = dataScadenta[i + 1];
                    prioritate[i] = prioritate[i + 1];
                }
                nume[listBox1.Items.Count - 1] = "";
                descriere[listBox1.Items.Count - 1] = "";
                dataScadenta[listBox1.Items.Count - 1] = "";
                prioritate[listBox1.Items.Count - 1] = "";
                listBox1.Items.Remove(listBox1.Items[listBox1.Items.Count - 1]);
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deschidereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Title = "Deschide Fisier";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    listBox1.Items.Clear();
                    using (StreamReader sr = new StreamReader(s))
                    {
                        string ln;
                        while ((ln = sr.ReadLine()) != null)
                        {
                            listBox1.Items.Add(ln);
                        }
                        optiune = 2;
                    }
                    int L1 = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("\\") + 1).Length;
                    int L2 = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.')).Length;
                    this.Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("\\") + 1, L1 - L2);
                }
            }
        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Text == "Fara Nume")
            {
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.Title = "Salveaza Fisier";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate))
                    {
                        s.SetLength(0);
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        sw.Write(string.Format(output, Convert.ToString(id[i]), nume[i], descriere[i], dataScadenta[i], prioritate[i]) + "\n");
                        }
                        optiune = 1;
                    }  
                }
                if(!saveFileDialog.FileName.Equals(""))
                {
                    int L1 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1).Length;
                    int L2 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('.')).Length;
                    this.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1, L1 - L2);
                }
            }
            else if (this.Text != "Fara Nume")
            {
                switch (optiune)
                {
                    case 1:
                        {
                            using (Stream s = File.Open(saveFileDialog.FileName, FileMode.Open))
                            {
                                s.SetLength(0);
                                using (StreamWriter sw = new StreamWriter(s))
                                {
                                    for (int i = 0; i < listBox1.Items.Count; i++)
                                    sw.Write(string.Format(output, id[i], nume[i], descriere[i], dataScadenta[i], prioritate[i]) + "\n");
                                }
                            }
                            break;
                        }

                    case 2:
                        {
                            using (Stream s = File.Open(openFileDialog.FileName, FileMode.Open))
                            {
                                s.SetLength(0);
                                using (StreamWriter sw = new StreamWriter(s))
                                {
                                    for (int i = 0; i < listBox1.Items.Count; i++)
                                        sw.Write(string.Format(output, id[i], nume[i], descriere[i], dataScadenta[i], prioritate[i]) + "\n");
                                }
                            }
                            break;
                        }
                }
            }
        }

        private void salvareCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = "C:\"";
            saveFileDialog.Title = "Save text Files";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate))
                {
                    s.SetLength(0);
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        for(int i = 0; i < listBox1.Items.Count; i++)
                        sw.Write(string.Format(output, id[i], nume[i], descriere[i], dataScadenta[i], prioritate[i]) + "\n" );
                    }
                    optiune = 1;
                } 
            }
            if (!saveFileDialog.FileName.Equals(""))
            {
                int L1 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1).Length;
                int L2 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('.')).Length;
                this.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1, L1 - L2);
            }
        }

        private void textBoxPrioritate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar != '1') && (e.KeyChar != '2') && (e.KeyChar != '3'))
            {
                e.Handled = true;
            }
        }
    }
}
