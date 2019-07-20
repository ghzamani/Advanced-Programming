using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace P1
{
    public class Plane
    {
        public Grid Grid;
        public Axis X;
        public Axis Y;
        MainWindow.f F;
        public Plane(Grid g, Axis x, Axis y,  MainWindow.f f)
        {
                        
            F = f;
            X = x;
            Y = y;

            double m = (double)540 / (X.MaxVal-X.MinVal) < (double)280 / (Y.MaxVal-Y.MinVal) ? (double)540 / (X.MaxVal-X.MinVal) : (double)280 / (Y.MaxVal-Y.MinVal);
            g.Height = m * (Y.MaxVal-Y.MinVal);
            g.Width = m * (X.MaxVal-X.MinVal);
            
            g.Background = System.Windows.Media.Brushes.White;

            //setting the Grid in the middle of the page
            g.Margin = new Thickness((double)(624 - g.Width) / 2, (double)(300 - g.Height) / 2 + 27, 0, 0);
            Grid = g;

            Line l;
            //horizontal lines
            for (int i = 1; i < Y.MaxVal-Y.MinVal; i++)
            {
                l = new Line();
                double X1 = 0;
                double Y1 = Grid.Height * i / (Y.MaxVal - Y.MinVal);
                double X2 = Grid.Width;
                double Y2 = Grid.Height * i / (Y.MaxVal - Y.MinVal);
                l = DrawLine( X1, Y1, X2, Y2, color.lightGray, 1);
                if (l.Y1 == Y.MaxVal-Y.O)
                {
                    continue;
                }
                
                Grid.Children.Add(l);
            }

            //vertical lines;
            for(int j = 1; j < X.MaxVal-X.MinVal; j++)
            {
                l = new Line();
                double Y1 = 0;
                double X1 = Grid.Width * j / (X.MaxVal - X.MinVal);
                double X2 = Grid.Width * j / (X.MaxVal - X.MinVal); 
                double Y2 = Grid.Height;
                l = DrawLine( X1, Y1, X2, Y2, color.lightGray, 1);
                if (l.X1 == X.O)
                {
                    continue;
                }
                Grid.Children.Add(l);
            }


            //محورها
            if(X.O.HasValue)
            {                           
                double X1 = X.O.Value * Grid.Width / (X.MaxVal - X.MinVal);
                double Y1 = 0;
                double X2 = X.O.Value * Grid.Width / (X.MaxVal - X.MinVal); 
                double Y2 = Grid.Height;
                Y.Line = DrawLine( X1, Y1, X2, Y2, color.black, 2);
                Grid.Children.Add(Y.Line);

                //برچسب محور                
                y.AxisTexts(Grid, X1 + 10, 0, Y.AxisName);

                //اعداد محور
                y.AxisTexts(Grid, X1 - 25, Grid.Height - 17, Y.MinVal.ToString());
                y.AxisTexts(Grid, X1 - 20, 0, Y.MaxVal.ToString());
                
            }
            if(Y.O.HasValue)
            {
                double X1 = 0;
                double Y1  = (Y.MaxVal-Y.MinVal-Y.O.Value) * Grid.Height / (Y.MaxVal - Y.MinVal);
                double X2 = Grid.Width;
                double Y2 = (Y.MaxVal-Y.MinVal-Y.O.Value) * Grid.Height / (Y.MaxVal - Y.MinVal);
                X.Line = DrawLine( X1, Y1, X2, Y2, color.black, 2);
                Grid.Children.Add(X.Line);

                //برچسب محور                
                x.AxisTexts(Grid, Grid.Width - 10, Y1 - 25, X.AxisName);

                //اعداد محور
                x.AxisTexts(Grid, Grid.Width - 20, Y1 + 3, X.MaxVal.ToString());
                x.AxisTexts(Grid, 3 , Y1 + 3, X.MinVal.ToString());
            }
            

            //drawing the diagram
            for (double i = X.MinVal; i < X.MaxVal; i += 0.01)
            {
                if (F(i) > Y.MaxVal || F(i) < Y.MinVal || F(i + 0.01) > Y.MaxVal || F(i + 0.01) < Y.MinVal)
                    continue;
                
                double X1 = (i - X.MinVal) * (Grid.Width / (X.MaxVal -X.MinVal));
                double X2 = (i + 0.01 - X.MinVal) * (Grid.Width / (X.MaxVal-X.MinVal));
                double Y1;
                double Y2;
                if (Y.O.HasValue)
                {
                    Y1 = ((double)Y.MaxVal - Y.MinVal - Y.O.Value - F(i)) * (Grid.Height / (Y.MaxVal - Y.MinVal));
                    Y2 = ((double)Y.MaxVal - Y.MinVal - Y.O.Value - F(i + (double)(0.01))) * (Grid.Height / (Y.MaxVal - Y.MinVal));
                }
                else
                {
                    Y1 = ((double)Y.MaxVal - F(i)) * (Grid.Height / (Y.MaxVal - Y.MinVal));
                    Y2 = ((double)Y.MaxVal - F(i + (double)(0.01))) * (Grid.Height / (Y.MaxVal - Y.MinVal));
                }
                
                Grid.Children.Add(DrawLine( X1, Y1, X2, Y2, color.red, 1));
            }
            
        }
        public enum color
        {
            red = 0,
            lightGray = 1,
            black =2
        }
        public Line DrawLine( double x1, double y1, double x2, double y2, color c, double thickness)
        {
            Line l = new Line();
            l.X1 = x1;
            l.X2 = x2;
            l.Y1 = y1;
            l.Y2 = y2;
            switch (c)
            {
                case color.red:
                    l.Stroke = Brushes.Red;
                    break;
                case color.lightGray:
                    l.Stroke = Brushes.LightGray;
                    break;
                case color.black:
                    l.Stroke = Brushes.Black;
                    break;
            }
            l.StrokeThickness = thickness;
            return l;
        }
    }

    public abstract class Axis
    {
        public Line Line;
        public int MinVal;
        public int MaxVal;
        public int? O;
        public string AxisName;
        public Axis( int minval , int maxval)
        {
            MinVal = minval;
            MaxVal = maxval;
            FindO();
        }

        private void FindO()
        {
            for(int i = 0; i < MaxVal - MinVal; i++)
            {
                if (i + MinVal == 0)
                {
                    O = i;
                }
            }
        }

        public void AxisTexts (Grid g , double left, double top , string num)
        {
            TextBlock block = new TextBlock();
            block.Text = num;
            block.FontSize = 14;
            block.Margin = new System.Windows.Thickness(left, top, 0, 0);
            g.Children.Add(block);
        }
    }

    public class XAxis : Axis
    {
        public XAxis(int minval, int maxval) : base(minval, maxval)
        {
            this.AxisName = "x";
        }
    }

    public class YAxis : Axis
    {
        public YAxis(int minval, int maxval) : base(minval, maxval)
        {
            this.AxisName = "y";
        }
    }
}
