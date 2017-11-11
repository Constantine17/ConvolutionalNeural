using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIforNeuron
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string imagedirectory = "not directory";


        public void WriteConsole(object text)
        {
            OutputConsole.AppendText(text.ToString()+"\n");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InputDirectory_Click(object sender, EventArgs e)
        {
            WriteConsole("Open File:");

            OpenFileDialog directory = new OpenFileDialog();
            directory.Filter = "Images (*.png; *.jpg); *.ico|*.png; *.jpg; *.ico";
            //directory.FileName = "nets.snn";
            if (directory.ShowDialog() == DialogResult.OK)
            {
                imagedirectory = directory.FileName;
                WriteConsole(imagedirectory);
                var eye = new Eye(imagedirectory);
                pictureBox1.Image = eye.image;
            }
        }

        private void FistLayer_Click(object sender, EventArgs e)
        {
            var image = new Eye(imagedirectory);
            image.ConvertImage();
            pictureBox1.Image = image.image;
        }
    }
}
