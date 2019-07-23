using System;
using System.Windows.Shapes;

namespace P1
{
    public abstract class Hands
    {
        public Hands(double width,double length,Line l,DateTime time)
        {
            DateTime = time;
            this.Width = width;
            this.Length = length;
            this.Line = l;
            Line.X1 = 115;
            Line.Y1 = 115;
            Line.StrokeThickness = Width;          
            
        }
        public double Width { get; set; }
        public double Length { get; set; }
        public Line Line;
        public double Degree;
        public DateTime DateTime;        
    }


    public class HourHand : Hands
    {
        public HourHand(double width, double length, Line l, DateTime time)
            : base(width, length, l, time)
        {
            Degree = 2 * Math.PI * (DateTime.Hour % 12 + (double)DateTime.Minute / 60) / 12; 
            
            Line.Stroke = System.Windows.Media.Brushes.Gold;
            Line.X2 = Length * Math.Sin(Degree) + 115;
            Line.Y2 = 115 - Length * Math.Cos(Degree);
        }

    }

    public class MinuteHand : Hands
    {
        public MinuteHand(double width, double length, Line l, DateTime time)
            : base(width, length, l, time)
        {
            Degree = 2 * Math.PI * DateTime.Minute / 60;
            Line.Stroke = System.Windows.Media.Brushes.Red;
            Line.X2 = Length * Math.Sin(Degree) + 115;
            Line.Y2 = 115 - Length * Math.Cos(Degree);
        }
    }

    public class SecondHand : Hands
    {
        public SecondHand(double width, double length, Line l, DateTime time)
            : base(width, length, l, time)
        {
            Degree = 2 * Math.PI * DateTime.Second / 60;
            Line.Stroke = System.Windows.Media.Brushes.Purple;
            Line.X2 = Length * Math.Sin(Degree) + 115;
            Line.Y2 = 115 - Length * Math.Cos(Degree);
        }
    }
}
