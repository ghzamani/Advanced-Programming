using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public delegate double f(double d);
        public Clock MyClock = new Clock();

        public MainWindow()
        {

            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(0.5);
            timer.Tick += timer_Tick;
            timer.Start();
            

        }


        #region clock
        void timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            HourHand h = new HourHand(3, 50, hour, d);
            MinuteHand m = new MinuteHand(4, 80, minute, d);
            SecondHand s = new SecondHand(5, 100, second, d);
            Clock c = MyClock;
        }


        public void RemoveItems()
        {
            foreach (var v in MyClock.nums)
            {
                clock.Children.Remove(v);
            }
            foreach (var v in MyClock.numsNotMultiplyBy3)
            {
                clock.Children.Remove(v);
            }
            foreach (var v in MyClock.lines)
            {
                clock.Children.Remove(v);
            }
        }

        public void Clock1_Click(object sender, RoutedEventArgs e)
        {
            RemoveItems();
            DateTime d = DateTime.Now;
            HourHand h = new HourHand(3, 50, hour, d);
            MinuteHand m = new MinuteHand(4, 80, minute, d);
            SecondHand s = new SecondHand(5, 100, second, d);
            MyClock = new Clock(h, m, s, clock);
        }

        public void Clock2_Click(object sender, RoutedEventArgs e)
        {
            RemoveItems();
            DateTime d = DateTime.Now;
            HourHand h = new HourHand(3, 50, hour, d);
            MinuteHand m = new MinuteHand(4, 80, minute, d);
            SecondHand s = new SecondHand(5, 100, second, d);
            MyClock = new Clock(h, m, s, clock, true, true);
        }

        public void Clock3_Click(object sender, RoutedEventArgs e)
        {
            RemoveItems();
            DateTime d = DateTime.Now;
            HourHand h = new HourHand(3, 50, hour, d);
            MinuteHand m = new MinuteHand(4, 80, minute, d);
            SecondHand s = new SecondHand(5, 100, second, d);
            MyClock = new Clock(h, m, s, clock, true, false);
        }

        public void Clock4_Click(object sender, RoutedEventArgs e)
        {
            RemoveItems();
            DateTime d = DateTime.Now;
            HourHand h = new HourHand(3, 50, hour, d);
            MinuteHand m = new MinuteHand(4, 80, minute, d);
            SecondHand s = new SecondHand(5, 100, second, d);
            MyClock = new Clock(h, m, s, clock, true, true);
            foreach (var n in MyClock.numsNotMultiplyBy3)
            {

                clock.Children.Remove(n);
            }
        }
        #endregion


        #region Equations
        Equation equ = new Equation();
        private void Button_Click(object sender, RoutedEventArgs e) //Calculate button
        {
            if (string.IsNullOrEmpty(equations.Text))
            {
                MessageBox.Show("Please enter your equations first");
                return;
            }

            equ.Equations = new List<string>();
            equ.Equations = this.equations.Text.Split('\n', ',').ToList();

            equ.Nums = equ.InitializeNums(equ.Equations);
            equ.Coefficients = equ.InitializeCoeff(equ.Variables, equ.Equations.Count);

            try
            {
                answer.Text = string.Empty;
                equ.Answer = equ.Coefficients.InverseMatrix(equ.Coefficients) * equ.Nums;

                for (int j = 0; j < equ.Equations.Count; j++)
                {
                    answer.Text = answer.Text + equ.Majhoolha[j][0] + " = " + equ.Answer[j][0] + "\n";
                }
            }
            catch (InvalidOperationException)
            {
                if (SquareMatrix<double>.CheckConsistent(equ.Coefficients, equ.Nums))
                {
                    answer.Text = "No Unique Solution";
                }

                else answer.Text = "No Solution";
            }
        }

        //clear button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            equations.Text = null;
            answer.Text = null;
        }


        //draw button
        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.f firstLine;
            MainWindow.f seconLine;
            XAxis x = new XAxis(-10, 10);
            YAxis y = new YAxis(-5, 5);

            try
            {
                if (equ.Equations.Count == 2)
                {
                    //move to the first tab
                    Tabs.SelectedIndex = 0;

                    firstLine = (input) =>
                    {
                        return (equ.Nums[0][0] - equ.Coefficients[0][0] * input) / equ.Coefficients[0][1];
                    };

                    seconLine = (input) =>
                    {
                        return (equ.Nums[1][0] - equ.Coefficients[1][0] * input) / equ.Coefficients[1][1];
                    };

                    if (answer.Text != "No Solution" && answer.Text != "No Unique Solution")
                    {
                        if (equ.Majhoolha[0][0] == 'x')
                        {
                            x = new XAxis(-(int)Math.Abs(equ.Answer[0][0]) - 1, (int)Math.Abs(equ.Answer[0][0]) + 1);
                            y = new YAxis(-(int)Math.Abs(equ.Answer[1][0]) - 1, (int)Math.Abs(equ.Answer[1][0]) + 1);
                        }
                        else
                        {
                            x = new XAxis(-(int)Math.Abs(equ.Answer[1][0]) - 1, (int)Math.Abs(equ.Answer[1][0]) + 1);
                            y = new YAxis(-(int)Math.Abs(equ.Answer[0][0]) - 1, (int)Math.Abs(equ.Answer[0][0]) + 1);
                        }
                    }

                    cartesian = new Grid();
                    if (!drawDiagram.Children.Contains(cartesian))
                    {
                        drawDiagram.Children.Add(cartesian);
                    }

                    Plane p = new Plane(cartesian, x, y, firstLine);
                    Plane p2 = new Plane(cartesian, x, y, seconLine);
                    cartesian.Margin = new Thickness((double)(624 - cartesian.Width) / 2, (double)(300 - cartesian.Height) / 2 + 27, 0, 0);
                }

                else MessageBox.Show("Not valid");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please click on Calculate button first");
            }
            return;
        }
        #endregion

        #region DrawDiagram
        //draw button 
        
        public void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(minxEntered.Text) || string.IsNullOrEmpty(minyEntered.Text) ||
                string.IsNullOrEmpty(maxxEntered.Text) || string.IsNullOrEmpty(maxyEntered.Text))
            {
                MessageBox.Show("Please fill all the fields");
            }

            else
            {
                int minx = 0;
                int maxx = 0;
                int miny = 0;
                int maxy = 0;
                try
                {
                    miny = int.Parse(minyEntered.Text);
                    maxy = int.Parse(maxyEntered.Text);
                    minx = int.Parse(minxEntered.Text);
                    maxx = int.Parse(maxxEntered.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter proper integers");
                    return;
                }

                cartesian = new Grid();
                if (!drawDiagram.Children.Contains(cartesian))
                {
                    drawDiagram.Children.Add(cartesian);
                }


                f function = GetFunction(func.Text);
                //XAxis x = new XAxis(xDirection, XStick, minX, maxX, minx, maxx);
                //YAxis y = new YAxis(yDirection, YStick, minY, maxY, miny, maxy);


                XAxis x = new XAxis(minx, maxx);
                YAxis y = new YAxis(miny, maxy);

                Plane p = new Plane(cartesian, x, y, function);
                
            }
        }
        
        public void DrawDeriv_Click(object sender, RoutedEventArgs e)
        {
            Der.Text = "fPrime(x) = " + Derivative(func.Text, 1);
            int miny = int.Parse(minyEntered.Text);
            int maxy = int.Parse(maxyEntered.Text);
            int minx = int.Parse(minxEntered.Text);
            int maxx = int.Parse(maxxEntered.Text);
            XAxis x = new XAxis(minx, maxx);
            YAxis y = new YAxis(miny, maxy);

            MainWindow.f Deriv = GetFunction(Derivative(func.Text, 1));
            Plane p = new Plane(cartesian, x, y, Deriv);
        }

        //clear button
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            minxEntered.Text = string.Empty;
            minyEntered.Text = string.Empty;
            maxxEntered.Text = string.Empty;
            maxyEntered.Text = string.Empty;
            func.Text = string.Empty;
            drawDiagram.Children.Remove(cartesian);
            Der.Text = string.Empty;
        }
        #endregion

        #region function
        public double Parse(string func, double x)
        {
            double result = 0;
            List<string> parts = new List<string>();
            var list = Regex.Split(func, "(cos\\({ 1} (\\s{ 0,}[x^0-9\\+-]{0,}\\s{0,}){1,}\\){1})|(sin\\({1}(\\s{0,}[x^0-9\\+-]{0,}\\s{0,}){1,}\\){1})|(-)|(\\+)|(=)")
                .ToList().Where(d => d != " " && d != "").ToArray();

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = list[i].Replace(" ", string.Empty);
                if (list[i].Contains("x"))
                    parts.Add(CalculatePart(list[i], x));
                else
                {
                    parts.Add(list[i]);
                }
            }

            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i] == "-") //ضربدر منفی باید بشه
                {
                    parts[i + 1] = (-1 * double.Parse(parts[i + 1])).ToString();
                }
            }

            List<string> l = parts.Where(a => a != "+" && a != "-" && a != "" && a != " ").ToList();
            foreach (var v in l)
                result += double.Parse(v);
            return result;
        }

        public string CalculatePart(string v, double x)
        {
            double coeff;
            if (v.Contains("sin"))
            {
                string input = v.Substring(v.IndexOf('(') + 1, v.Length - 5);

                return Math.Sin(Parse(input, x)).ToString();
            }
            if (v.Contains("cos"))
            {
                string input = v.Substring(v.IndexOf('(') + 1, v.Length - 5);
                return Math.Cos(Parse(input, x)).ToString();
            }

            List<string> l = v.Split('^').ToList();
            if (l[0].Length == 1) //اگر ضریب یک بود
            {
                coeff = 1;
            }
            else coeff = double.Parse(l[0].Trim(l[0].Last()));

            if (l.Count == 1) //اگر توان x
                              //یک بود و وارد نشده بود
            {
                return (coeff * x).ToString();
            }
            return (coeff * Math.Pow(x, double.Parse(l[1]))).ToString();
        }

        public f GetFunction(string s)
        {
            return (d) => Parse(s, d);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.PrintVisual(cartesian, "Printing");
        }
        #endregion

        #region Taylor
        public MainWindow.f TaylorSeries(int m, int a)
        {
            int count = 0; //تعداد جمله ای که حساب شده
            int n = 0; // همان n که در بسط هست
            List<MainWindow.f> list = new List<f>();
            //m was entered from the user
            while (count < m)
            {
                int b = n;
                f taylor = new f((input) =>
                {
                    return GetFunction(FindFPrime(b))(a) * Math.Pow((input - a), b) / Factorial(b);
                }); 
            
                if (GetFunction(FindFPrime(n))(a) != 0)
                {
                    count += 1;
                    list.Add(taylor);
                }
                n += 1;
            }

            return (x) =>
            {
                double result = 0;
                foreach (MainWindow.f l in list)
                {
                    result += l(x);
                }
                return result;
            };
           
        }

        //draw button in taylor
        public void DrawSin_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(nTaylor.Text) || string.IsNullOrEmpty(xTaylor.Text))
            {
                MessageBox.Show("Please enter n and x0");
                return;
            }            

            MainWindow.f sin = (input) =>
            {
                return Math.Sin(input);
            };

            MainWindow.f taylorEntered = TaylorSeries(int.Parse(nTaylor.Text), int.Parse(xTaylor.Text));

            int? maxx = null;
            int? minx = null;
            int a = int.Parse(xTaylor.Text);

            while (Math.Abs(taylorEntered(a) - Math.Sin(a)) < 0.01)
            {
                a++;
            }
            maxx = a * 2 - int.Parse(xTaylor.Text);
            minx = 2 * int.Parse(xTaylor.Text) - maxx;

            taylorPlane = new Grid();
            if (!taylor.Children.Contains(taylorPlane))
            {
                taylor.Children.Add(taylorPlane);
            }
            XAxis x = new XAxis(minx.Value, maxx.Value);
            YAxis y = new YAxis(-2, 2);
            Plane pl = new Plane(taylorPlane, x, y, sin);
            Plane pl2 = new Plane(taylorPlane, x, y, taylorEntered);
            taylorPlane.Margin = new Thickness((614 - taylorPlane.Width) / 2 , (340 - taylorPlane.Height) / 2 + 75, 0, 0);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            taylor.Children.Remove(taylorPlane);
            nTaylor.Text = string.Empty;
            xTaylor.Text = string.Empty;
        }

        #endregion

        public double Factorial(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            return n * Factorial(n - 1);
        }

        public string FindFPrime(int num)
        {
            string f = string.Empty;
            switch (num % 4)
            {
                case 0:
                    f = "sin(x)";
                    break;
                case 1:
                    f = "cos(x)";
                    break;
                case 2:
                    f = "-sin(x)";
                    break;
                case 3:
                    f = "-cos(x)";
                    break;
            }
            return f;
        }

        //change user button
        public void BackControl_Click(object sender, RoutedEventArgs e)
        {
            First firstWindow = new First();
            firstWindow.Show();
            this.Close();
        }

        #region Fractal
        Ellipse c = new Ellipse();
        List<Ellipse> circles = new List<Ellipse>();
        public void Fractal(Canvas canvas, double x, double y, double r, int depth, int userDepth)
        {
            c = new Ellipse();
            c.Stroke = System.Windows.Media.Brushes.Black;
            c.Width = c.Height = 2 * r;

            c.Margin = new Thickness(x - r, y - r, 0, 0);

            circles.Add(c);
            if (depth == userDepth)
                return;

            depth += 1;

            //right circles
            Fractal(canvas, x + r, y, r / 2, depth, userDepth);
            //left circles
            Fractal(canvas, x - r, y, r / 2, depth, userDepth);

        }

        //draw button for fractal    
        DispatcherTimer dispatcher = new DispatcherTimer();
        public void Button_Click_4(object sender, RoutedEventArgs e)
        {

            fractal.Children.Clear();
            try
            {
                Fractal(fractal, fractal.Width / 2, fractal.Height / 2, 150, 1, int.Parse(depth.Text));
                fractal.Background = (Brush)new BrushConverter().ConvertFrom("#FFD8FFDB");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please insert the depth");
                return;
            }

            dispatcher.Interval = TimeSpan.FromSeconds(0.8);
            dispatcher.Tick += DrawFractal;
            dispatcher.Start();

        }

        int i = 0;
        public void DrawFractal(object sender, EventArgs e)
        {
            if (i == circles.Count)
            {
                dispatcher.Tick -= DrawFractal;
                return;
            }

            fractal.Children.Add(circles[i]);
            i += 1;
        }

        #endregion


        #region deriv       
        public string Derivative (string func, int n)
        {
            var list = Regex.Split(func, "(cos\\({ 1} (\\s{ 0,}[x^0-9\\+-]{0,}\\s{0,}){1,}\\){1})|(sin\\({1}(\\s{0,}[x^0-9\\+-]{0,}\\s{0,}){1,}\\){1})|(-)|(\\+)|(=)")
                .ToList().Where(d => d != " " && d != "").ToArray();

            List<string> result = new List<string>();
            for(int i = 0; i < list.Count(); i++)
            {
                if (list[i] == "+" || list[i] == "-")
                {
                    result.Add(list[i]);
                }
                else
                {
                    result.Add(DerivativeParts(list[i], n));
                }
            }

            string res = null;
            for(int i = 0; i < result.Count; i++)
            {
                res += result[i];
            }
            return res;
        }

        public string DerivativeParts(string func, int n)
        {
            string result;
            double power = 0;
            double coeff = 0;
            if (func.Contains("^"))
            {
                power = double.Parse(func.Split('^')[1]);
                if (func.Split('^')[0].Length == 1)//اگر ضریب یک بود و وارد نشده بود
                {
                    coeff = 1;
                }
                else
                {
                    coeff = double.Parse(func.Split('^')[0].Trim('x'));
                }
                result = $"{power * coeff}x^{power - 1}";

                if (n == 1)
                    return result;
                else return DerivativeParts(result, n - 1);
            }

            else //اگر توان نداشت یا عدد ثابت بود
            {
                if (func.Contains("x"))
                {
                    if (func.Length == 1)
                    {
                        coeff = 1;
                    }
                    else
                    {
                        coeff = double.Parse(func.Trim('x'));
                    }

                    if (n == 1)
                    {
                        return $"{coeff}";
                    }
                    else return "0";

                }
                else
                {
                    return "0";
                }
            }
        }

        #endregion

        
    }
}
