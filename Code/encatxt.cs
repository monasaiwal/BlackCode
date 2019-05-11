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
    public partial class encatxt : Form
    {
        public encatxt()
        {
            InitializeComponent();
        }

        //to convert char
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
                if (c == ' ')
                {
                    final = final + " ";
                }


            }




            return (final);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string alpha = "abcdefghijklmnopqrstuvwxyz";
            string plain = textBox1.Text.ToLower();
            // int key = Convert.ToInt32(textBox2.Text);
            string key = textBox2.Text.ToLower();
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
         
            
            // key = key - 1;
            string final = "";
            i = 0;
            char cipher;

            foreach (char c in plain)
            {
                i = alpha.IndexOf(c);

                if (c == ' ')
                {
                    final = final + " ";
                }
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
                else if (c == ' ')
                {
                    final=final+" ";
                }
                else
                {
                    final = final + c;
                }
            }

            textBox3.Clear();
            string aa = convert(final);
            textBox3.Text = aa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            decatxt aa = new decatxt();
            aa.Show();
        }
    }
}
