using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using para = iTextSharp.text.Paragraph;
using System.IO;
using System.Security.Cryptography;
using System.Security;

namespace cryptography
{
    public partial class desetxt : Form
    {
        private const string initVector = "pemgail9uzpgzl88";
        private const int keySize = 256;
        public desetxt()
        {
            InitializeComponent();
        }

        //to decrypt using crypto package
        public string decryptse(string cryptTxt, string key)
        {

            cryptTxt = cryptTxt.Replace(" ", "+"); 
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt); 
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        MessageBox.Show("  "+bytesBuff.Length);
                        cStream.Write(bytesBuff, 0, bytesBuff.Length); 
                        cStream.Close();
                    } 
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            } 
            return cryptTxt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cipher = textBox1.Text.ToLower();
            string key = textBox2.Text.ToLower();
            string plain = decryptse(cipher, key);
            textBox3.Text = plain;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
