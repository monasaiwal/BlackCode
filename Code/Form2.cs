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

namespace cryptography
{
    public partial class Form2 : Form
    {
        public Form2()
        { 
        
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            // frm.MdiParent = this;
            this.Hide();
            this.Close();
        }

        private void caesarsCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void methodToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enrftxt tt = new enrftxt();
            tt.Show();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encatxt tt = new encatxt();
            tt.Show();
        }

        private void textToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            decatxt ab = new decatxt();
            ab.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            derftxt ss = new derftxt();
            ss.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                inputTextBox.Undo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { inputTextBox.Cut(); }
            catch (Exception Ex)
            { Console.WriteLine(Ex.Message); }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encafl aa = new encafl();
            aa.Show();
        }

        private void fileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            decafl d = new decafl();
            d.Show();
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
    
        }

        private void fileToolStripMenuItem3_Click(object sender, EventArgs e)
        {
     
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { inputTextBox.Copy(); }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { inputTextBox.Paste(); }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((inputTextBox.Text.Length != 0) & (inputTextBox.SelectionStart != inputTextBox.Text.Length))
            {
                if (!inputTextBox.SelectedText.Equals(""))
                {
                    try
                    {
                        int cursorPosition = inputTextBox.SelectionStart;
                        inputTextBox.Text = inputTextBox.Text.Remove(cursorPosition, inputTextBox.SelectedText.Length);
                        inputTextBox.SelectionStart = cursorPosition;
                    }
                    catch (Exception Ex) { Console.WriteLine(Ex.Message); }
                }
                else
                {
                    try
                    {
                        int cursorPosition = inputTextBox.SelectionStart;
                        inputTextBox.Text = inputTextBox.Text.Remove(cursorPosition, 1);
                        inputTextBox.SelectionStart = cursorPosition;
                    }
                    catch (Exception Ex) { Console.WriteLine(Ex.Message); }
                }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { inputTextBox.SelectAll(); }
            catch (Exception Ex) { Console.WriteLine(Ex.Message); }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

               if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                inputTextBox.Font = fontDialog1.Font;
               //SaveSettings("FONT");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                inputTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = "";
                OpenFileDialog open = new OpenFileDialog();
                //open.Filter = "TXT Files(*.txt)|*.txt|DOC Files(*.doc)|*.doc|XLSX Files(*.xlsx)|*.xlsx|PDF Files(*.pdf)|*.pdf|DOCX Files(*.docx)|*.docx";
                if (open.ShowDialog() == DialogResult.OK)
                {

                    fn = open.FileName;
                    textBox1.Text = fn;
                }
                char[] ext = fn.ToCharArray();
                int l = fn.Length;
                int a = fn.IndexOf('.');
                if (ext[a + 1] == 'x')
                {
                    openxml(fn);
                }
                else if (ext[a + 1] == 't')
                {
                    opentxt(fn);
                }
                else if (ext[a + 1] == 'd')
                {
                    opendoc(fn);
                }
                else if (ext[a + 1] == 'p' && ext[a + 2] == 'd')
                {
                    openpdf(fn);
                }
                else
                {
                    MessageBox.Show("File Format Not Supported");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :"+ex.Message);
            }
           
        }
        public void openxml(string fn)
        {

            string final = "";

            Excel.Application xlApp = new Excel.Application();
            //Excel.Application();
       
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@fn, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel._Worksheet xlWorkSheet = (Excel._Worksheet)xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {

                    final = final + (xlWorkSheet.Cells[i, j].Value.ToString()) + " ";
                    // final = (string)(xlRange.Cells[i, j] as Excel.Range).Value2;
                }
            }
            inputTextBox.Text = final;
            xlWorkBook.Close();
            xlApp.Quit();

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

          //  MessageBox.Show("XML file is opened");

            textBox2.Text=Convert.ToString(rowCount);
            textBox3.Text = Convert.ToString(colCount);
        }
        public void opentxt(string fn)
        {

            //reading file
            System.IO.StreamReader objReader;
            objReader = new System.IO.StreamReader(fn);


            inputTextBox.Text = objReader.ReadToEnd();




           // MessageBox.Show("TXT file is opened");
        }
        public void opendoc(string fn)
        {
 
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = fn;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            for (int p = 0; p < docs.Paragraphs.Count; p++)
            {
                inputTextBox.Text += docs.Paragraphs[p + 1].Range.Text.ToString();
            }
            docs.Close();
            word.Quit();


          //  MessageBox.Show("DOC file is opened");
        }
        public void openpdf(string fn)
        {



            try
            {
                // FileStream fs=new FileStream(fn,FileMode.Create,FileAccess.Write,FileShare.None);
                var text = new StringBuilder();
                PdfReader pdfr = new PdfReader(fn);

                for (int i = 1; i <= pdfr.NumberOfPages; i++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    var currentText = PdfTextExtractor.GetTextFromPage(pdfr, i, strategy);
                    currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                inputTextBox.Text = text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message);
            }



          //  MessageBox.Show("PDF file is opened");
        }
    

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            
                
                    SaveFileDialog open = new SaveFileDialog();
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        string fn;
                        fn = open.FileName+".txt";


                        //writing into file

                        System.IO.StreamWriter objw;
                        objw = new System.IO.StreamWriter(fn);
                        objw.Write(inputTextBox.Text);
                        objw.Close();
                        //end
                    
                }
               /* else
                {
                    string aa = textBox1.Text;

                    char[] ext = aa.ToCharArray();
                    int l = aa.Length;

                    int a = aa.IndexOf('.');
                    if (ext[a + 1] == 'x')
                    {
                        int r = Convert.ToInt32(textBox2.Text);
                        int c = Convert.ToInt32(textBox3.Text);
                        savexml(r, c);
                    }
                    else if (ext[a + 1] == 't')
                    {
                        savetxt();
                    }
                    else if (ext[a + 1] == 'd')
                    {
                        savedoc();
                    }
                    else if (ext[a + 1] == 'p' && ext[a + 2] == 'd')
                    {
                        savepdf();
                    }
                    else
                    {
                        SaveFileDialog open = new SaveFileDialog();
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            string fn;
                            fn = open.FileName;


                            //writing into file

                            System.IO.StreamWriter objw;
                            objw = new System.IO.StreamWriter(fn);
                            objw.Write(inputTextBox.Text);
                            objw.Close();
                            //end
                        }
                    }
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message);
            }
           
           
        }



        public void savexml(int r, int c)
        {
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

            char[] ab = inputTextBox.Text.ToCharArray();
            // xlWorkSheet.Cells[1,1]="Sheet 2 Content";
            for (int ii = 0; ii <= (inputTextBox.Text.Length) - 1; ii++)
            {

                if (ab[ii] == ' ')
                {
                    Count = Count + 1;
                }
            }
            //MessageBox.Show("count is" + Count + "Length of Plain Text" + (textBox2.Text.Length) + "Contents" + textBox2.Text);


            int row = r;
            int col = c;
            //MessageBox.Show("row=" + row + "column" + col);
            int x = 0;
            string a = "";
            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= col; j++)
                {
                    while (x < (inputTextBox.Text.Length))
                    {
                        if (ab[x] == ' ')
                        {
                            xlWorkSheet.Cells[i, j] = a;
                            a = null;
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




            xlWorkBook.SaveAs(loc + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
        //    MessageBox.Show("XML file is saved");
        }


        public void savetxt()
        {
            SaveFileDialog open = new SaveFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fn;
                fn = open.FileName+".txt";


                //writing into file

                System.IO.StreamWriter objw;
                objw = new System.IO.StreamWriter(fn);
                objw.Write(inputTextBox.Text);
                objw.Close();
                //end
            }
           // MessageBox.Show("TXT file is saved");
        }
        public void savedoc()
        {
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
                document.Content.Document.Content.Text = inputTextBox.Text + Environment.NewLine;
                object filename = loc;
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
               // MessageBox.Show("DOC file is saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }


        }
        public void savepdf()
        {
            string loc = "";
            SaveFileDialog open = new SaveFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                loc = open.FileName + ".pdf";

            }
            //string fn = textBox2.Text;
            FileStream fs = new FileStream(loc, FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new para(inputTextBox.Text));
            doc.Close();
        //    MessageBox.Show("PDF file is saved");

        }



        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
               if (wordWrapMenuItem.Checked == true)
            {
                wordWrapMenuItem.Checked = false;
                inputTextBox.WordWrap = false;
            }
            else
            {
                wordWrapMenuItem.Checked = true;
                inputTextBox.WordWrap = true;
            }
            SaveSettings("WRAPPING");
             */
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about tt = new about();
            tt.Show();
        }

        private void caesarsCipherToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        
        }

        private void railToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void fileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            encafl aa = new encafl();
            aa.Show();
        }

        private void fileToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            decafl aa = new decafl();
            aa.Show();
        }

        private void method1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encatxt aa = new encatxt();
            aa.Show();
        }

        private void methodBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enrftxt aa = new enrftxt();
            aa.Show();
        }

        private void methodAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decatxt aa = new decatxt();
            aa.Show();
        }

        private void methodBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            derftxt aa = new derftxt();
            aa.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info aa = new info();
            aa.Show();
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enimg aa = new enimg();
            aa.Show();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deimg aa = new deimg();
            aa.Show();
        }

        private void methodCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ensetxt a = new ensetxt();
            a.Show();
        }

        private void methodCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            desetxt a = new desetxt();
            a.Show();
        }

        private void methodCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ensetxt a = new ensetxt();
            a.Show();
        }

        private void methodCToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            desetxt a = new desetxt();
            a.Show();
        }

        private void textToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            enrftxt a = new enrftxt();
           // encatxt a = new encatxt();
            a.Show();
        }

        private void textToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            derftxt a = new derftxt();
           // decatxt a = new decatxt();
            a.Show();
        }
    }
}