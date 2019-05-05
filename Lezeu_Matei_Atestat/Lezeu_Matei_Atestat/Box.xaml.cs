﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lezeu_Matei_Atestat
{
    /// <summary>
    /// Interaction logic for Box.xaml
    /// </summary>
    public partial class Box : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public Box()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
            
        }

        int cont=0, def=0, culoare=0;

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (Canvas.GetLeft(eu) <= image.Width - 140)
                {
                    Canvas.SetLeft(eu, Canvas.GetLeft(eu) + 3);
                }
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                
                if(Canvas.GetLeft(eu)>=20)
                {
                    Canvas.SetLeft(eu, Canvas.GetLeft(eu) - 3);
                }

            }

            if (Canvas.GetLeft(eu) + eu.Width >= Canvas.GetLeft(adversar))
              

            if (Keyboard.IsKeyDown(Key.K))
            {
                cont = 0;
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/blue1.jpg", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
                if (Canvas.GetLeft(eu) + eu.Width >= Canvas.GetLeft(adversar))
                    {
                        veataLUI.Value -= 1;

                    }


            }
            if (Keyboard.IsKeyDown(Key.J))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/yoloo.JPG", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
                def = 1;
            }
            if (Keyboard.IsKeyUp(Key.J) && def ==1)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/black.jpg", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
                def = 0;
            }
            cont++;
            culoare = 2;
            if (cont==10)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/black.jpg", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
            }

            
        }
    }
}
