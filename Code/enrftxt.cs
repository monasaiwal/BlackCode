using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cryptography
{
    public partial class enrftxt : Form
    {
        public enrftxt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String p = textBox1.Text.ToLower();
                if (p.Length == 1)
                {
                    p = p + "  ";
                }
                if (p.Length == 2)
                {
                    p = p + "  ";
                }
                // string k = textBox1.Text;
                String key = textBox2.Text;
                String alpha = "AAabcdefghijklmnopqrstuvwxyz{}[];:'<>,.?/|0123456789!@#$%^&*()_+=-`~";
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
                            sum = 2;
                        }
                        if (sum == 1)
                        {
                            sum = 2;
                        }
                    }
                }

                // int key = Convert.ToInt32(k);
                try
                {

                    char[] plain = p.ToCharArray();
                    List<String> rf = new List<String>();
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
                    String buffer = "";
                    foreach (string s in rf)
                    {
                        buffer += s;
                    }
                   string aa = convert(buffer);
                    textBox3.Text = aa;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured: "+ex.Message);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
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
                if (c == ' ')
                {
                    final=final + " ";
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
                    final = final + '9';
                }

                if (c == '9')
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


            }




            return (final);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            derftxt ss = new derftxt();
            ss.Show();
        }
    }
}
