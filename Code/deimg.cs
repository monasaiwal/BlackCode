using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cryptography
{
    public partial class deimg : Form
    {
        public deimg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fn;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                fn = dialog.FileName;

                textBox1.Text = fn;
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string fn;
            int key = getkey();
            byte[] ImageBytes;
            ImageBytes = File.ReadAllBytes(textBox1.Text);
            for (int i = 0; i < ImageBytes.Length; i++)
            {
                ImageBytes[i] = (byte)(ImageBytes[i] - key);
            }

            SaveFileDialog open = new SaveFileDialog();
            open.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";
           
            if (open.ShowDialog() == DialogResult.OK)
            {

                fn = open.FileName;
                File.WriteAllBytes(fn, ImageBytes);
            }
        }

        public int getkey()
        {
            string key = textBox2.Text.ToLower();
            string alpha = "AAabcdefghijklmnopqrstuvwxyz{}[];:'<>,.?/|0123456789!@#$%^&*()_+=-`~";
            alpha = alpha + '"';
            alpha = alpha + ' ';
            char[] a = alpha.ToCharArray();
            char[] k = key.ToCharArray();
            int i = 0, sum = 0, no = 0;
            for (i = 0; i < key.Length; i++)
            {
                no = alpha.IndexOf(k[i]);
                sum = sum + no;
            }
            while (sum > 26)
            {
                sum = sum - 23;



                if (sum == 0)
                {
                    sum = 4;
                }

                if (sum == 1)
                {
                    sum = 5;
                }
                if (sum < 0)
                {
                    sum = 6;
                }
            }

            return (sum);
        }

    }
}
