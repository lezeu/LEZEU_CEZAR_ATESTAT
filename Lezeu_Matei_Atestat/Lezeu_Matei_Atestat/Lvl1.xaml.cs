using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lezeu_Matei_Atestat
{
    /// <summary>
    /// Interaction logic for Lvl1.xaml
    /// </summary>
    public partial class Lvl1 : Page
    {
        DispatcherTimer timer = new DispatcherTimer();


        public Lvl1()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
        private void timer_tick(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.A))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/OmStanga.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                om.Source = bmp;//updateza source cu bmp
                if (Left(om) == Left(wall1) + wall1.Width && Top(om) > Top(wall1) || Left(om) == Left(wall3) + wall3.Width && Top(om) > Top(wall3) && Top(om) < Top(wall3) + wall3.Height)
                {

                }
                else
                {
                    if (Canvas.GetLeft(om) > 0)
                    {
                        Canvas.SetLeft(om, Canvas.GetLeft(om) - 5);
                    }
                }

            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/omuletw.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                om.Source = bmp;//updateza source cu bmp

                if ((Left(om) > Left(wall3) && Left(om) < Left(wall3) + wall3.Width && Top(om) < 710 && Top(om) >Top(wall2))
                    ||(Left(om)+om.Width < Left(wall3)+wall3.Width && Left(om)+om.Width > Left(wall3) && Top(om) < 710 && Top(om) > Top(wall2)))
                {

                }
                else
                if (Canvas.GetTop(om) > 0)
                {
                    Canvas.SetTop(om, Canvas.GetTop(om) - 5);
                }


            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/OmDreapta.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                om.Source = bmp;//updateza source cu bmp

                if (Left(om) + om.Height == Left(wall1) && Top(om) > Top(wall1) || Left(om) + om.Height == Left(wall3) && Top(om) > Top(wall3) && Top(om) < Top(wall3) + wall3.Height)
                {

                }
                else
                {
                    if (Canvas.GetLeft(om) + om.Height < 1200)
                    {
                        Canvas.SetLeft(om, Canvas.GetLeft(om) + 5);
                    }
                }



            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/omulet.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                om.Source = bmp;//updateza source cu bmp
                if (Top(om)+om.Height>Top(wall2) && (Left(om)>Left(wall2) && Left(om)<Left(wall2)+wall2.Width)
                    ||(Left(om)+om.Width<Left(wall2)+wall2.Width && Left(om)+om.Width>Left(wall2) && Top(om)+om.Width>Top(wall2)))
                //Left(om) > Left(wall3) && Left(om) < Left(wall3) + wall3.Width && Top(om) < 710 && Top(om) >Top(wall2)
                {

                }
                else
                {
                    if (Canvas.GetTop(om) + om.Height < 1000)
                    {
                        Canvas.SetTop(om, Canvas.GetTop(om) + 5);
                    }
                }


            }
            prof1Behaviour();
            prof2Behaviour();
            prof3Behaviour();
            prof4Behaviour();
            detection();
        }
        public double Top(Image obj)
        {
            return Canvas.GetTop(obj);
        }

        public double Left(Image obj)
        {
            return Canvas.GetLeft(obj);
        }

        public double Top(Rectangle obj)
        {
            return Canvas.GetTop(obj);
        }

        public double Left(Rectangle obj)
        {
            return Canvas.GetLeft(obj);
        }
        /// <summary>
        /// 
        /// </summary>

        public void SetTop(Image obj, double value)
        {
            Canvas.SetTop(obj, value);
        }

        public void SetLeft(Image obj, double value)
        {
            Canvas.SetLeft(obj, value);
        }
        public void SetTop(Rectangle obj, double value)
        {
            Canvas.SetTop(obj, value);
        }

        public void SetLeft(Rectangle obj, double value)
        {
            Canvas.SetLeft(obj, value);
        }

        int speed = 3;
        public void prof1Behaviour()
        {
            BitmapImage bmp = new BitmapImage(); // se face pt  a schimba source la imagini
            if (Top(prof1) > 55)
            {
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/prf1W.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                prof1.Source = bmp;//updateza source cu bmp
                SetTop(prof1, Top(prof1) - 5);
                prof1.Tag = "0";
            }
            else
            {
                if (Left(prof1) < cv.Width)
                {
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("/res/prf1D.jpg", UriKind.Relative);
                    bmp.EndInit();
                    prof1.Source = bmp;
                    SetLeft(prof1, Left(prof1) + speed);
                    prof1.Tag = "1";
                }
                else
                {
                    SetTop(prof1, 1200);
                    SetLeft(prof1, 945);
                }
            }
        }
        int tmPr2 = 0;
        public void prof2Behaviour()
        {
            BitmapImage bmp = new BitmapImage();
            if (Left(prof2) < Left(wall1))
            {
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/prf1D.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                prof2.Source = bmp;//updateza source cu bmp
                SetLeft(prof2, Left(prof2) + speed);
                prof2.Tag = "1";
            }
            else
            {
                tmPr2++;
                if (tmPr2 == 100)
                {
                    SetLeft(prof2, 361);
                    tmPr2 = 0;
                }
            }

        }
        bool stage2 = false;
        public void prof3Behaviour()
        {
            BitmapImage bmp = new BitmapImage();
            if (Top(prof3) < 50 && stage2 == false)
            {
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/prf1S.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                prof3.Source = bmp;//updateza source cu bmp
                SetTop(prof3, Top(prof3) + speed);
                prof3.Tag = "2";
            }
            else
            {
                if (Left(prof3) > 125 && stage2 == false)
                {
                    bmp.BeginInit(); // incepe init la bmp
                    bmp.UriSource = new Uri("/res/prf1A.jpg", UriKind.Relative); // schimba img source in bmp
                    bmp.EndInit();
                    prof3.Source = bmp;//updateza source cu bmp
                    SetLeft(prof3, Left(prof3) - speed);
                    prof3.Tag = "3";
                }
                else
                {
                    stage2 = true;
                    if (Top(prof3) >= 50 && Left(prof3) <= 125 && Top(prof3) < 815)
                    {
                        bmp.BeginInit(); // incepe init la bmp
                        bmp.UriSource = new Uri("/res/prf1S.jpg", UriKind.Relative); // schimba img source in bmp
                        bmp.EndInit();
                        prof3.Source = bmp;//updateza source cu bmp
                        SetTop(prof3, Top(prof3) + speed);
                        prof3.Tag = "2";
                    }
                    else
                    {
                        if (Left(prof3) < 513)
                        {
                            bmp.BeginInit(); // incepe init la bmp
                            bmp.UriSource = new Uri("/res/prf1D.jpg", UriKind.Relative); // schimba img source in bmp
                            bmp.EndInit();
                            prof3.Source = bmp;//updateza source cu bmp
                            SetLeft(prof3, Left(prof3) + speed);
                            prof3.Tag = "1";
                        }
                        else
                        {
                            if (Top(prof3) > 163)
                            {
                                bmp.BeginInit(); // incepe init la bmp
                                bmp.UriSource = new Uri("/res/prf1W.jpg", UriKind.Relative); // schimba img source in bmp
                                bmp.EndInit();
                                prof3.Source = bmp;//updateza source cu bmp
                                SetTop(prof3, Top(prof3) - speed);
                                prof3.Tag = "0";
                            }
                            else
                            {
                                SetTop(prof3, 0);
                                SetLeft(prof3, 540);
                                stage2 = false;
                            }
                        }
                    }
                }

            }
        }
        public void prof4Behaviour()
        {
            BitmapImage bmp = new BitmapImage();
            if (Left(prof4) > 805)
            {
                bmp.BeginInit(); // incepe init la bmp
                bmp.UriSource = new Uri("/res/prf1A.jpg", UriKind.Relative); // schimba img source in bmp
                bmp.EndInit();
                prof4.Source = bmp;//updateza source cu bmp
                SetLeft(prof4, Left(prof4) - speed);
                prof4.Tag = "3";
            }
            else
            {
                if (Top(prof4) > -110)
                {
                    bmp.BeginInit(); // incepe init la bmp
                    bmp.UriSource = new Uri("/res/prf1W.jpg", UriKind.Relative); // schimba img source in bmp
                    bmp.EndInit();
                    prof4.Source = bmp;//updateza source cu bmp
                    SetTop(prof4, Top(prof4) - speed);
                    prof4.Tag = "0";
                }
                else
                {
                    SetTop(prof4, 270);
                    SetLeft(prof4, 1350);
                }
            }

        }


        public void detection()
        {
            foreach (Image img in cv.Children.OfType<Image>())
            {
                if (img.Name != "om")
                {
                    if (img.Tag.ToString() == "0")
                    {
                        if ((Top(om) + om.Height >= Top(img) - 150) && Top(om) + om.Height < Top(img) && (Left(om) < Left(img) && Left(om) + om.Width > Left(img)))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                        if ((Top(om) + om.Height >= Top(img) - 150) && Top(om) + om.Height < Top(img) && (Left(om) < Left(img) + img.Width && Left(om) + om.Width > Left(img) + img.Width))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                    }
                    if (img.Tag.ToString() == "2")
                    {
                        if ((Top(om) <= Top(img) + img.Height + 150) && Top(om) > Top(img) + img.Height && (Left(om) < Left(img) && Left(om) + om.Width > Left(img)))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                        if ((Top(om) <= Top(img) + img.Height + 150) && Top(om) > Top(img) + img.Height && (Left(om) < Left(img) + img.Width && Left(om) + om.Width > Left(img) + img.Width))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                    }
                    if (img.Tag.ToString() == "1" && img.Name == "prof2")
                    {
                        if ((Left(om) <= Left(img) + img.Height + 25) && Left(om) > Left(img) + img.Height && (Top(om) < Top(img) && Top(om) + om.Width > Top(img)))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                        if ((Left(om) <= Left(img) + img.Height + 25) && Left(om) > Left(img) + img.Height && (Top(om) < Top(img) + img.Width && Top(om) + om.Width > Top(img) + img.Width))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                    }
                    if (img.Tag.ToString() == "1" && img.Name != "prof2")
                    {
                        if ((Left(om) <= Left(img) + img.Height + 150) && Left(om) > Left(img) + img.Height && (Top(om) < Top(img) && Top(om) + om.Width > Top(img)))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                        if ((Left(om) <= Left(img) + img.Height + 150) && Left(om) > Left(img) + img.Height && (Top(om) < Top(img) + img.Width && Top(om) + om.Width > Top(img) + img.Width))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                    }
                    if (img.Tag.ToString() == "3")
                    {
                        if ((Left(om) + om.Height >= Left(img) - 150) && Left(om) + om.Height < Left(img) && (Top(om) < Top(img) && Top(om) + om.Width > Top(img)))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                        if ((Left(om) + om.Height >= Left(img) - 150) && Left(om) + om.Height < Left(img) && (Top(om) < Top(img) + img.Width && Top(om) + om.Width > Top(img) + img.Width))
                        {
                            SetTop(om, 861);
                            SetLeft(om, 1100);
                        }
                    }
                }
            }
        }
    }
}
