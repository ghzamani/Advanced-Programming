using A10;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P1
{
    public class Equation
    {
        public List<string> Equations;
        public List<string> Variables; //e.g 2x,3y

        public SquareMatrix<double> Coefficients;//ماتریس ضرایب متغیرها
        public SquareMatrix<double> CoefficientsT; //ترانهاده ماتریس ضرایب
        public Vector<double> _co;
         
        public Matrix<char> Majhoolha;
        public Vector<char> _majhool; //e.g x,y
         
        public Matrix<double> Nums;
        public Vector<double> _nums; //عدد بعد از مساوی
         
        public Matrix<double> Answer;

        //Coefficients * Majhoolha = Nums
        //Majhoolha = (Coefficients) ^ -1 * Nums

        public List<string> CheckZeroCoeff (List<string> eq, List<string> vars)
            //اگر ضریب یکی از متغیرها در معادله صفر بود
        {
            var groups = vars.GroupBy(d => FindChar(d));
            foreach (var g in groups) 
            {
                if (g.Count() != eq.Count)
                {
                    for (int a = 0; a < eq.Count; a++)
                    {
                        if (!eq[a].Contains(g.Key))
                        {
                            eq[a] = eq[a].Split('=')[0] + "+0" + g.Key + "=" + eq[a].Split('=')[1];
                        }
                    }
                }
            }
            return eq;
        }


        public Matrix<double> InitializeNums(List<string> Equations)
        { 
            _nums = new Vector<double>(Equations.Count);
            Nums = new Matrix<double>(Equations.Count, 1);
            Variables = new List<string>();
            for (int i = 0; i < Equations.Count; i++)
            {
                Equations[i] = Equations[i].Replace(" ", string.Empty);
            }

            var splited = Equations.Select(eq => Regex.Split(eq, "(\\()|(\\))|(-)|(\\+)|(=)")).ToList();
            foreach (var s in splited)
            {
                List<string> list = s.Where(a => a != "" && a != " ").ToList();

                for (int i = 0; i < list.Count; i++) 
                {
                    if (list[i] == "-")
                    {
                        list[i + 1] = "-" + list[i + 1];
                    }
                }

                List<string> l = list.Where(a => a != "+" && a != "-" && a != "=" && a != "" && a != " ").ToList();

                for (int i = 0; i < l.Count() - 1; i++)
                {
                    bool hasDigit = l[i].Any(c => char.IsDigit(c));
                    if (!hasDigit) //اگر ضریب یک بود و وارد نشده بود
                    {
                        if (!l[i].Contains("-"))
                        {
                            l[i] = "1" + l[i];
                        }
                        else
                        {
                            l[i] = "-1" + l[i].Last();
                        }
                    }
                    Variables.Add(l[i]); //2x,-3y,x,-y,...
                }
                _nums.Add(double.Parse(l[l.Count() - 1]));
            }

            for (int i = 0; i < _nums.Size; i++)
            {
                Nums[i][0] = _nums[i];
            }
            return Nums;
        }

        char FindChar(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                    return s[i];
            }
            return 'a';
        }

        public SquareMatrix<double> InitializeCoeff(List<string> Variables, int n)
        {
            Coefficients = new SquareMatrix<double>(n);
            CoefficientsT = new SquareMatrix<double>(n);
            _majhool = new Vector<char>(n);
            Majhoolha = new Matrix<char>(n, 1);
            

            this.Equations = CheckZeroCoeff(Equations, Variables);
            Variables = new List<string>();

            var splited = Equations.Select(eq => Regex.Split(eq, "(\\()|(\\))|(-)|(\\+)|(=)")).ToList();
            foreach (var s in splited)
            {

                for (int i = 0; i < s.Length; i++) 
                {
                    if (s[i] == "-")
                    {
                        s[i + 1] = "-" + s[i + 1];
                    }
                }

                List<string> l = s.Where(a => a != "+" && a != "-" && a != "=" && a != "" && a != " ").ToList();

                for (int i = 0; i < l.Count() - 1; i++)
                {
                    bool hasDigit = l[i].Any(c => char.IsDigit(c));
                    if (!hasDigit) //اگر ضریب یک بود و وارد نشده بود
                    {
                        if (!l[i].Contains("-"))
                        {
                            l[i] = "1" + l[i];
                        }
                        else
                        {
                            l[i] = "-1" + l[i].Last();
                        }
                    }
                    Variables.Add(l[i]); //2x,-3y,x,-y,...
                }
            }

            int index = 0;
            var groups = Variables.GroupBy(d => FindChar(d));
            foreach (var group in groups)
            {
                _majhool.Add(group.Key);

                _co = new Vector<double>(n);
                foreach (var g in group)
                {
                    _co.Add(double.Parse(g.Trim(g.Last()))); //برای اینکه فقط ضریب مجهول درنظر گرفته شود                  
                }
                CoefficientsT[index] = _co;
                index++;
            }
            Coefficients = Coefficients.Transpose(CoefficientsT);

            for (int i = 0; i < _majhool.Size; i++)
            {
                Majhoolha[i][0] = _majhool[i];
            }
            return Coefficients;
        }
    }
}
