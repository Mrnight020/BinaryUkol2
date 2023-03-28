using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ukol2Binarni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            FileStream data = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter zapisuj = new BinaryWriter(data, Encoding.GetEncoding("windows-1250"));
            BinaryReader ctibinary = new BinaryReader(data, Encoding.GetEncoding("windows-1250"));
            StreamReader cti = new StreamReader("sport.txt", Encoding.GetEncoding("windows-1250"));

            while(!cti.EndOfStream)
            {
                string radek = cti.ReadLine();
                string[] polozky = radek.Split(';');

                zapisuj.Write(int.Parse(polozky[0]));
                zapisuj.Write(polozky[1]);
                zapisuj.Write(polozky[2]);
                zapisuj.Write(char.Parse(polozky[3]));
                zapisuj.Write(int.Parse(polozky[4]));
                zapisuj.Write(int.Parse(polozky[5]));

            }

            ctibinary.BaseStream.Position = 0;
            while(ctibinary.BaseStream.Position < ctibinary.BaseStream.Length)
            {
                string celyradek = "" + ctibinary.ReadInt32() + ";"
                                      + ctibinary.ReadString() + ";" 
                                      + ctibinary.ReadString() + ";" 
                                      + ctibinary.ReadChar() + ";" 
                                      + ctibinary.ReadInt32() + ";" 
                                      + ctibinary.ReadInt32();

                textBox1.AppendText(celyradek + Environment.NewLine);
                
            }


            data.Close();
            cti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
