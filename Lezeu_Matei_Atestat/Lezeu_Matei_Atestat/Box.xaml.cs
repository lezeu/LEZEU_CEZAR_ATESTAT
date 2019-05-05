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

        int cont=0;

        private void timer_tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.D))
            {
                Canvas.SetLeft(eu, Canvas.GetLeft(eu) + 3);
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                Canvas.SetLeft(eu, Canvas.GetLeft(eu) - 3);
            }
            if (Keyboard.IsKeyDown(Key.K))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/blue.jpg", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
                cont = 0;
            }
            if (Keyboard.IsKeyDown(Key.J))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/yoloo.JPG", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
            }
            if (Keyboard.IsKeyUp(Key.J))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri("/res/black.jpg", UriKind.RelativeOrAbsolute);
                bmp.EndInit();
                eu.Source = bmp;
            }
            cont++;
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