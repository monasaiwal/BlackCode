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
    public partial class encafl : Form
    {
        private const string initVector = "pemgail9uzpgzl88";
        private const int keySize = 256;
        public encafl()
        { 

            InitializeComponent();
        }
        //key method
        public int getkey()
        {
            string key = textBox1.Text.ToLower();
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
            while (sum > 200)
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

        public string eencrypt(string pp,int sum)
        {

            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string plain = pp.ToLower();

            int i = 0;

            string final = "";
            i = 0;
            char cipher;

            foreach (char c in plain)
            {
                i = alpha.IndexOf(c);


                if ((c == 'a') || (c == 'b') || (c == 'c') || (c == 'd') || (c == 'e') || (c == 'f') || (c == 'g') || (c == 'h') || (c == 'i') || (c == 'j') || (c == 'k') || (c == 'l') || (c == 'm') || (c == 'n') || (c == 'o') || (c == 'p') || (c == 'q') || (c == 'r') || (c == 's') || (c == 't') || (c == 'u') || (c == 'v') || (c == 'w') || (c == 'x') || (c == 'y') || (c == 'z'))
                {

                    if ((i + sum) > 25)
                    {
                        cipher = alpha[(i + sum) - 26];
                        final = final + cipher;
                    }
                    else
                    {
                        cipher = alpha[(i + sum)];
                        final = final + cipher;
                    }
                }


                else
                {
                    final = final + c;
                }

            }

            //close
            string aa =final;
            return (aa);
        }


        //encrypt by using caesar cipher
    public string encrypt(string pp)
    {
        
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string plain = pp.ToLower();
            string key = textBox1.Text.ToLower();
            string alph = "Aabcdefghijklmnopqrstuvwxyz{}[];:'<>,.?/|0123456789!@#$%^&*()_+=-`~";
            alph = alph + '"';
            alph = alph + ' ';
            char[] a = alph.ToCharArray();
            char[] k = key.ToCharArray();
            int i = 0, sum = 0, no = 0;
            for (i = 0; i < key.Length; i++)
            {
                no = alph.IndexOf(k[i]);
                sum = sum + no;
            }
            while (sum >= 26)
            {
                sum = sum - 23;
            
            
            if (sum == 0)
            {
                sum = 4;
            }
          
            }
        
            string final = "";
            i = 0;
            char cipher;

            foreach (char c in plain)
            {
                i = alpha.IndexOf(c);


                if ((c == 'a') || (c == 'b') || (c == 'c') || (c == 'd') || (c == 'e') || (c == 'f') || (c == 'g') || (c == 'h') || (c == 'i') || (c == 'j') || (c == 'k') || (c == 'l') || (c == 'm') || (c == 'n') || (c == 'o') || (c == 'p') || (c == 'q') || (c == 'r') || (c == 's') || (c == 't') || (c == 'u') || (c == 'v') || (c == 'w') || (c == 'x') || (c == 'y') || (c == 'z'))
                {

                    if ((i + sum) > 25)
                    {
                        cipher = alpha[(i + sum) - 26];
                        final = final + cipher;
                    }
                    else
                    {
                        cipher = alpha[(i + sum)];
                        final = final + cipher;
                    }
                }
                
           
                else
                {
                    final = final + c;
                }
                
            }

          //close
            string aa = convert(final);
        return(aa);
    }

        //encrypt by using rail fence
   public string encryptrf(string pp)
    {
            string p = pp.ToLower();
            // string k = textBox1.Text;
            string key = textBox1.Text.ToLower();
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
            }
            if (sum >= p.Length)
            {
                while (sum >= p.Length)
                {
                    sum = sum - 5;

                    if (sum == 0)
                    {
                        sum = 2;
                    }
                    if (sum < 0)
                    {
                        sum = 3;
                    }
                    if (sum == 1)
                    {
                        sum = 2;
                    }
                }
            }
          
            string buffer = "";
            char[] plain = p.ToCharArray();
            List<string> rf = new List<string>();
            for (i = 0; i < sum; i++)
            {
                rf.Add("");
            }
            int num = 0;
            int incre = 1;
            foreach (char c in plain)
            {
                if (num + incre == sum)
                {
                    incre = -1;
                }
                else if (num + incre == -1)
                {
                    incre = 1;
                }
                rf[num] += c;
                num += incre;
             
            }
            foreach (string s in rf)
            {
                buffer += s;
            }

           // string aa = convert(buffer);
           // return (aa);
            return (buffer);

        }

        //encrypt by using crypto package
   public string encryptcry(string plainText,string passPhrase)
   {
       
        byte[] initVectorBytes=Encoding.UTF8.GetBytes(initVector);
        byte[] plainTextBytes=Encoding.UTF8.GetBytes(plainText);
        PasswordDeriveBytes password=new PasswordDeriveBytes(passPhrase,null);
        byte[] keyBytes=password.GetBytes(keySize/8);
        RijndaelManaged symmetricKey=new RijndaelManaged();
        symmetricKey.Mode=CipherMode.CBC;
        ICryptoTransform encryptor=symmetricKey.CreateEncryptor(keyBytes,initVectorBytes);
        MemoryStream memoryStream=new MemoryStream();
        CryptoStream cryptoStream=new CryptoStream(memoryStream,encryptor,CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes,0,plainTextBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] cipherTextBytes=memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(cipherTextBytes);
    }

   //encrypt by using security package
   public string encryptse(string inText, string key)
   {
       byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
       using (Aes aes = Aes.Create())
       {
           Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
           aes.Key = crypto.GetBytes(32);
           aes.IV = crypto.GetBytes(16);
           using (MemoryStream mStream = new MemoryStream())
           {
               using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
               {
                   cStream.Write(bytesBuff, 0, bytesBuff.Length);
                   cStream.Close();
               }
               inText = Convert.ToBase64String(mStream.ToArray());
           }
       }
       return inText;

   }

   //to encrypt characters to symbol
   public string convert(string pp)
   {


       string p = pp.ToLower();
       string final = "";
       // string k = textBox1.Text;
       char[] plain = p.ToCharArray();
       //  MessageBox.Show("encrypt function:" + buffer);
       foreach (char c in p)
       {
           if (c == 'a')
           {
               final = final + '!';
           }
           if (c == '!')
           {
               final = final + 'a';
           }
           if (c == 'b')
           {
               final = final + '@';
           }
           if (c == '@')
           {
               final = final + 'b';
           }

           if (c == 'c')
           {
               final = final + '#';
           }

           if (c == '#')
           {
               final = final + 'c';
           }

           if (c == 'd')
           {
               final = final + '$';
           }

           if (c == '$')
           {
               final = final + 'd';
           }

           if (c == 'e')
           {
               final = final + '%';
           }

           if (c == '%')
           {
               final = final + 'e';
           }

           if (c == 'f')
           {
               final = final + '^';
           }

           if (c == '^')
           {
               final = final + 'f';
           }

           if (c == 'g')
           {
               final = final + '&';
           }

           if (c == '&')
           {
               final = final + 'g';
           }

           if (c == 'h')
           {
               final = final + '*';
           }

           if (c == '*')
           {
               final = final + 'h';
           }

           if (c == 'i')
           {
               final = final + '(';
           }

           if (c == '(')
           {
               final = final + 'i';
           }

           if (c == 'j')
           {
               final = final + ')';
           }

           if (c == ')')
           {
               final = final + 'j';
           }

           if (c == 'k')
           {
               final = final + '_';
           }

           if (c == '_')
           {
               final = final + 'k';
           }

           if (c == 'l')
           {
               final = final + '-';
           }

           if (c == '-')
           {
               final = final + 'l';
           }

           if (c == 'm')
           {
               final = final + '+';
           }

           if (c == '+')
           {
               final = final + 'm';
           }

           if (c == 'n')
           {
               final = final + '=';
           }

           if (c == '=')
           {
               final = final + 'n';
           }

           if (c == 'o')
           {
               final = final + '{';
           }

           if (c == '{')
           {
               final = final + 'o';
           }
        
           if (c == 'p')
           {
               final = final + '}';
           }

           if (c == '}')
           {
               final = final + 'p';
           }

           if (c == 'q')
           {
               final = final + '[';
           }

           if (c == '[')
           {
               final = final + 'q';
           }

           if (c == 'r')
           {
               final = final + ']';
           }

           if (c == ']')
           {
               final = final + 'r';
           }

           if (c == 's')
           {
               final = final + ';';
           }

           if (c == ';')
           {
               final = final + 's';
           }

           if (c == 't')
           {
               final = final + ':';
           }

           if (c == ':')
           {
               final = final + 't';
           }

           if (c == 'u')
           {
               final = final + '"';
           }

           if (c == '"')
           {
               final = final + 'u';
           }

           if (c == 'v')
           {
               final = final + '<';
           }

           if (c == '<')
           {
               final = final + 'v';
           }

           if (c == 'w')
           {
               final = final + '>';
           }

           if (c == '>')
           {
               final = final + 'w';
           }

           if (c == 'x')
           {
               final = final + '?';
           }

           if (c == '?')
           {
               final = final + 'x';
           }

           if (c == 'y')
           {
               final = final + ',';
           }

           if (c == ',')
           {
               final = final + 'y';
           }

           if (c == 'z')
           {
               final = final + '.';
           }

           if (c == '.')
           {
               final = final + 'z';
           }

           if (c == '0')
           {
               final = final + '|';
           }

           if (c == '|')
           {
               final = final + '0';
           }

           if (c == '1')
           {
               final = final + '8';
           }

           if (c == '8')
           {
               final = final + '1';
           }

           if (c == '2')
           {
               final = final + '7';
           }

           if (c == '7')
           {
               final = final + '2';
           }

           if (c == '3')
           {
               final = final + '6';
           }

           if (c == '6')
           {
               final = final + '3';
           }

           if (c == '4')
           {
               final = final + '5';
           }

           if (c == '5')
           {
               final = final + '4';
           }
           if (c == '9')
           {
               final = final + '/';
           }
           if (c == '/')
           {
               final = final + '9';
           }
           if(c==' ')
           {
               final = final + c;
           }


       }




       return (final);

   }

        



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void encafl_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "TXT Files(*.txt)|*.txt|DOC Files(*.doc)|*.doc|XLSX Files(*.xlsx)|*.xlsx|XLS Files(*.xls)|*.xls|PDF Files(*.pdf)|*.pdf|DOCX Files(*.docx)|*.docx";
            if (open.ShowDialog() == DialogResult.OK)
             {
                string fn;
                fn = open.FileName;
                tbx.Text = fn;
             }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error: " + ex.Message);
           }
        }

       //to open excel files
        public void openxml()
        {
            //  MessageBox.Show("Rail fence cipher algorithm is used");
            string final = "";
            string ff = "";
            Excel.Application xlApp = new Excel.Application();
            //Excel.Application();
            string fn = tbx.Text;
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@fn, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel._Worksheet xlWorkSheet = (Excel._Worksheet)xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;

            //  string key = textBox2.Text();



          //  ff = (xlWorkSheet.Cells[1, 1].Value.ToString());

            //  MessageBox.Show("length " + ff);

            /*

            //hdgfyusuyd
            string key = textBox1.Text.ToLower();
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
            }
            if (sum > ff.Length || sum == ff.Length)
            {
                while (sum >= ff.Length)
                {
                    sum = sum - 5;

                    if (sum == 0)
                    {
                        sum = 2;
                    }
                    if (sum < 0)
                    {
                        sum = 3;
                    }
                    if (sum == 1)
                    {
                        sum = 2;
                    }
                }
            }
            */
            //    MessageBox.Show("key "+sum);
            //ny
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            // MessageBox.Show("Row " + rowCount + " col " + colCount);
            for (int ii = 1; ii <= rowCount; ii++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    string aa = (xlWorkSheet.Cells[ii, j].Value.ToString());
                   
                    string bb = encrypt(aa);
                    //   MessageBox.Show(aa+"   "+bb);
                    final = final + bb + "~";



                }
            }
            string plain = final;
             //  MessageBox.Show(final);
            xlWorkBook.Close();
            xlApp.Quit();

            xlApp = null;

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                xlWorkBook = null;
                xlWorkSheet = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured While  Releasing Object" + ex.ToString());
            }

            //   MessageBox.Show("XML file is opened"+plain);
            savexml(plain, rowCount, colCount);

       
        }


      //to open text file
        public void opentxt()
        {         
                string fn;
                fn = tbx.Text;
                //reading file
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(fn);
                string plain = objReader.ReadToEnd();
                string cipher = encryptrf(plain);
                string fnn;

              SaveFileDialog open = new SaveFileDialog();
              if (open.ShowDialog() == DialogResult.OK)
              {

                  fnn = open.FileName;
                  fnn = fnn + ".txt";


                  //writing into file

                  System.IO.StreamWriter objw;
                  objw = new System.IO.StreamWriter(fnn);
                  objw.Write(cipher);
                  objw.Close();
                  //end
              }       
        }

        //to open word file
        public void opendoc()
        {
            string plainn="";
            string fn;
            fn = tbx.Text;
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = fn;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            
            for (int p = 0; p < docs.Paragraphs.Count; p++)
            {
                plainn+=  docs.Paragraphs[p + 1].Range.Text.ToString();
            }
            docs.Close();
            word.Quit();          
            string key=textBox1.Text;
            string cipher=encrypt(plainn);
            string loc = "";

            SaveFileDialog open = new SaveFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                loc = open.FileName;

            }

            try
            {
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                winword.Visible = false;
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                document.Content.Document.Content.Text = cipher + Environment.NewLine;
                object filename = loc;
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            
           

        }


        //to open pdf file
        public void openpdf()
        {
            string fn;
            fn = tbx.Text;            
            string cipher = "";

            try
            {
                var text = new StringBuilder();
                PdfReader pdfr = new PdfReader(fn);

                for (int i = 1; i <= pdfr.NumberOfPages; i++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    var currentText = PdfTextExtractor.GetTextFromPage(pdfr, i, strategy);
                    currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }

                string pl = text.ToString();
                string key = textBox1.Text;
                cipher = encrypt(pl);
                //saving pdf file
                string loc = "";

                SaveFileDialog open = new SaveFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {

                    loc = open.FileName + ".pdf";

                }
                
                FileStream fs = new FileStream(loc, FileMode.Create, FileAccess.Write, FileShare.None);
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.Add(new para(cipher));
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message);
            } 
        }

        //save xml file
       public void savexml(string abcd,int r,int c)
        {
          //sjhdfg
            string loc = "";
            SaveFileDialog open = new SaveFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                loc = open.FileName;
            }
            
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel._Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           
            int Count = 0;
            char[] ab = abcd.ToCharArray();
      
            for (int ii = 0; ii <= (abcd.Length) - 1; ii++)
            {
                if (ab[ii] == '~')
                {
                    Count = Count + 1;
                    
                }
            }
          
            int row = r;
            int col = c;          
            int x = 0;
            string a = "";

            try
            {
                for (int i = 1; i <= row; i++)
                {
                    for (int j = 1; j <= col; j++)
                    {
                        while (x < (abcd.Length))                      
                        {                         
                            if (ab[x] == '~')
                           {
                                xlWorkSheet.Cells[i, j] = a;                          
                                a =null;
                                x++;
                                break;                            
                            }
                            else
                            {
                                a = a + ab[x];
                                x++;
                            }
                            
                        }

                    }
                }
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while Inserting Object :" + ex.Message);
            }
 
            xlWorkBook.SaveAs(loc+".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                xlWorkSheet = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured While  Releasing Object" + ex.ToString());
            }

       
        }
    
            
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            string fn = tbx.Text;
            char[] ext = fn.ToCharArray();
            int l = fn.Length;
            int a = fn.IndexOf('.');
            if (ext[a + 1] == 'x')
            {
                openxml();
            }
            else if (ext[a + 1] == 't')
            {
                opentxt();
            }
            else if (ext[a + 1] == 'd')
            {
                opendoc();
            }
            else if (ext[a + 1] == 'p' && ext[a + 2] == 'd')
            {
                openpdf();
            }
            else
            {
                opentxt();
                //MessageBox.Show("File Format Not Supported");
            }
            }
            catch (Exception)
            {
                opentxt();
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
            //    open.Filter = "TXT Files(*.txt)|*.txt|DOC Files(*.doc)|*.doc|XLSX Files(*.xlsx)|*.xlsx|PDF Files(*.pdf)|*.pdf|DOCX Files(*.docx)|*.docx|XLS Files(*.xls)|*.xls";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string fn;
                    fn = open.FileName;
                    tbx.Text = fn;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
