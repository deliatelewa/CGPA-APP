using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CGPA_APP

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int w = 1;
        string[] y1s1 = {"FSC111","FSC112","FSC113","FSC114","FSC115","GST102","GST105"};
        int[] y1u1 = {3,3,3,3,3,0,0};
        string[] y1s2 = {"CSC120","CSC121","CSC122","MAT121","MAT122","PHS122","GST103", "MAT123", "PHS121", "PHS123", };
        int[] y1u2 = {3,3,2,3,3,3,0,2,2,2};
        int A = 1;
        int A1 = 1;
        int A2 = 1;
        
        int i = 0;
        int B = 0;
        int c = 1;
        int gp = 0;
        double[] t_p = new double[15];
        double[] t_u = new double[15];
        double[] g = new double[15];

        List<Control> itemsToRemove = new List<Control>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            B++;
            AddNewLabel();
            AddNewTextbox();
            AddNewLabel2();
            AddNewTextbox2();
            AddNewLabel3();
            AddNewTextbox3();
            i++;
        }

        public System.Windows.Forms.Label AddNewLabel()
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            this.panel4.Controls.Add(lbl);
            lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lbl.Top = A * 24;
            lbl.Left = 15;
            lbl.Text = "Course name " + this.B.ToString();
            A = A + 1;
            itemsToRemove.Add(lbl);
            return lbl;
        }

        public System.Windows.Forms.Label AddNewLabel2()
        {
            System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();
            this.panel4.Controls.Add(lbl2);
            lbl2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lbl2.Top = A1 * 24;
            lbl2.Left = 130;
            lbl2.Text = "Course unit " + this.B.ToString();
            itemsToRemove.Add(lbl2);
            A1 = A1 + 1;

            return lbl2;
        }

        public System.Windows.Forms.Label AddNewLabel3()
        {
            System.Windows.Forms.Label lbl3 = new System.Windows.Forms.Label();
            this.panel4.Controls.Add(lbl3);
            lbl3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lbl3.Top = A2 * 24;
            lbl3.Left = 240;
            lbl3.Text = "Course grade " + this.B.ToString();
            A2 = A2 + 1;
            itemsToRemove.Add(lbl3);
            return lbl3;
        }

        public System.Windows.Forms.TextBox AddNewTextbox()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            this.panel4.Controls.Add(txt);
            txt.Name = "txt" + B;
            if(w == 1)
                txt.Text = y1s1[i];
            else
            {
                txt.Text = y1s2[i];
            }
            txt.Top = A * 24;
            txt.Left = 15;
            A = A + 1;
            itemsToRemove.Add(txt);
            return txt;
        }

        public System.Windows.Forms.TextBox AddNewTextbox2()
        {
            System.Windows.Forms.TextBox txt2 = new System.Windows.Forms.TextBox();
            this.panel4.Controls.Add(txt2);
            txt2.Name = "txt2" + B;
            txt2.Top = A1 * 24;
            if (w == 1)
                txt2.Text = Convert.ToString(y1u1[i]);
            else
            {
                txt2.Text = Convert.ToString(y1u2[i]);
            }
            
            txt2.Left = 130;
            A1 = A1 + 1;
            itemsToRemove.Add(txt2);
            return txt2;

        }

        public System.Windows.Forms.TextBox AddNewTextbox3()
        {
            System.Windows.Forms.TextBox txt3 = new System.Windows.Forms.TextBox();
            this.panel4.Controls.Add(txt3);
            txt3.Name = "txt3" + B;
            txt3.Top = A2 * 24;
            txt3.Left = 240;
            A2 = A2 + 1;
            itemsToRemove.Add(txt3);
            return txt3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 0;
            string[] course_names = new string[B];
            int[] course_units = new int[B];
            string[] course_grade = new string[B];
            for (int i = 0; i < B; i++)
            {
                course_names[i] = ((TextBox)panel4.Controls["txt" + (i + 1).ToString()]).Text;
                course_units[i] = int.Parse(((TextBox)panel4.Controls["txt2" + (i + 1).ToString()]).Text);
                course_grade[i] = ((TextBox)panel4.Controls["txt3" + (i + 1).ToString()]).Text;
                Console.WriteLine(course_names[i]);
                Console.WriteLine(course_units[i]);
                Console.WriteLine(course_grade[i]);
            }
            
            double[] x = gpa.calc(course_names, course_units, course_grade,w);
            Console.WriteLine(x[0]);
            g[gp] = x[0];
            Console.WriteLine(c+"     "+g[gp]);
            t_u[gp] = x[1];
            
            t_p[gp] = x[2];
            Console.WriteLine("points = " + t_p[gp]);
            Console.WriteLine("units = " + t_u[gp]);
            AddNewLabel4();
            AddNewLabel5();
            gp++;

            foreach (Control ctrl in itemsToRemove)
            {
                Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            A = 1;
            B = 0;
            A1 = 1;
            A2 = 1;
            button3.Enabled = true;
            w = 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public System.Windows.Forms.Label AddNewLabel4()
        {
            System.Windows.Forms.Label lbl4 = new System.Windows.Forms.Label();
            this.panel2.Controls.Add(lbl4);
            lbl4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lbl4.Top = c * 40;
            lbl4.Left = 20;
            lbl4.Text = comboBox1.Text.ToUpper();
            c = c + 1;

            return lbl4;
        }

        public System.Windows.Forms.Label AddNewLabel5()
        {
            System.Windows.Forms.Label lbl5 = new System.Windows.Forms.Label();

            this.panel2.Controls.Add(lbl5);
            lbl5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lbl5.Top = c * 40;
            lbl5.Left = 20;
            lbl5.Text = "GPA: " + g[gp];

            c = c + 1;

            return lbl5;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            double x = 0,y=0;
            for(int i = 0; i < gp; i++)
            {
                x += t_u[i];
                y += t_p[i];
            }
            double z = y / x;
            string s = string.Format("{0:0.00}",z);
            textBox2.Text = s;
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

   

}

