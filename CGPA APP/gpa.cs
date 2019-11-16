using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPA_APP
{ 
    class gpa
    {
        public gpa()
        {

        }

        
        //gpa formula and calculation
        public static double[] calc(String[] course, int[] course_units, string[] grade,int sem)
        {

            double t_points = 0;
            double t_cunits = 0;
            

            //get course units using below for loop & condition
            int[] units = new int[course.Length];
            for (int i = 0; i < course.Length; i++)
            {
                if (grade[i].Equals("A")|| grade[i].Equals("a"))
                {
                    units[i] = 5;
                }
                else if (grade[i].Equals("B") || grade[i].Equals("b"))
                {
                    units[i] = 4;
                }
                else if (grade[i].Equals("C") || grade[i].Equals("c"))
                {
                    units[i] = 3;
                }
                else if (grade[i].Equals("D") || grade[i].Equals("d"))
                {
                    units[i] = 2;
                }
                else if (grade[i].Equals("E") || grade[i].Equals("e"))
                {
                    units[i] = 1;
                }
                else
                {
                    units[i] = 0;
                }
            }

            //main calculation
            for (int i = 0; i < course.Length; i++)
            {
                t_cunits += course_units[i];
                t_points += course_units[i] * units[i];
            }

            if (sem == 1 && t_cunits<15)
            {
                t_cunits = 15;
            }
            if(sem == 2 && t_cunits<19)
            {
                t_cunits = 19;
            }

            double gpa = t_points / t_cunits;
            string d = string.Format("{0:0.00}", gpa);
            double aa = Convert.ToDouble(d);

            double[] x = {aa, t_cunits, t_points};

            return x;
        }

    }
}
