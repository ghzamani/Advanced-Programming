using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P1
{
    public class Clock
    {
        public HourHand hourH;
        public MinuteHand minH;
        public SecondHand secH;
        public List<TextBlock> nums = new List<TextBlock>();
        public List<TextBlock> numsNotMultiplyBy3 = new List<TextBlock>();
        public List<Line> lines = new List<Line>();

        public Clock() { } //default constructor

        public Clock(HourHand hh, MinuteHand mh, SecondHand sh, Canvas canvas)
        {
            this.hourH = hh;
            this.minH = mh;
            this.secH = sh;

            // Create Image and set its width and height  
            Image dynamicImage = new Image();
            dynamicImage.Stretch = Stretch.Fill;

            // Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"..\..\Clock.JPG" , UriKind.Relative);
            bitmap.EndInit();

            // Set Image.Source  
            dynamicImage.Source = bitmap;            

            canvas.Background = new ImageBrush(dynamicImage.Source);
        }



        public Clock(HourHand hh,MinuteHand mh, SecondHand sh, Canvas canvas, bool drawHourLines, bool drawMinLines)
            
        {
            this.hourH = hh;
            this.minH = mh;
            this.secH = sh;

            canvas.Background = System.Windows.Media.Brushes.White;

            if (drawHourLines)//خط در محل ساعت ها
            {
                double Radius = 115;
                double r = 100;
                Line l; 
                TextBlock t;
                for (int i = 0; i < 12; i++)
                {

                    l = new Line();
                    l.X1 = r * Math.Cos(5 * i * Math.PI / 30) + 115;
                    l.Y1 = 115 - r * Math.Sin(5 * i * Math.PI / 30);
                    l.X2 = Radius * Math.Cos(5 * i * Math.PI / 30) + 115;
                    l.Y2 = 115 - Radius * Math.Sin(5 * i * Math.PI / 30);
                    l.Stroke = System.Windows.Media.Brushes.Black;
                    lines.Add(l);
                    canvas.Children.Add(l);
                    

                    t = new TextBlock();
                    if (i <= 2)
                    {
                        t.Text = (3 - i).ToString();
                        t.Margin = new System.Windows.Thickness(l.X1 - 10, l.Y1 - 8, 200 - l.X1, 230 - l.Y1 - 15);
                    }
                    else
                    {
                        t.Text = (15 - i).ToString();
                        if (i > 2 && i < 6)
                        {
                            t.Margin = new System.Windows.Thickness(l.X1 - 8, l.Y1 - 2, 200 - l.X1, 230 - l.Y1 - 15);
                        }
                        else
                        {
                            if(i>5 && i < 9)
                            {
                                t.Margin = new System.Windows.Thickness(l.X1 +2 , l.Y1 - 14, 190- l.X1, 250 - l.Y1);
                            }
                            else
                            {
                                t.Margin = new System.Windows.Thickness(l.X1 -7, l.Y1 - 17, 220 - l.X1, 250 - l.Y1);
                            }
                        }
                    }                    
                  
                    t.FontSize = 15;
                    nums.Add(t);
                    if (i % 3 != 0) 
                    {
                        numsNotMultiplyBy3.Add(t);
                    }
                    canvas.Children.Add(t);
                }
            }

            //خط در محل دقیقه ها
            if (drawMinLines)
            {
                double Radius = 110;
                double r = 105;
                Line l;
                for (int i = 0; i < 60 ; i++)
                {
                    if (i % 5 == 0)
                        continue;
                    l = new Line();
                    l.X1 = r * Math.Cos( i * Math.PI / 30) + 115;
                    l.Y1 = 115 - r * Math.Sin( i * Math.PI / 30);
                    l.X2 = Radius * Math.Cos(i * Math.PI / 30) + 115;
                    l.Y2 = 115 - Radius * Math.Sin(i * Math.PI / 30);
                    l.Stroke = System.Windows.Media.Brushes.LightSlateGray;
                    lines.Add(l);
                    canvas.Children.Add(l);
                }
            }
        }
        
    }

    
}
