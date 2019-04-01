using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerAnimatie = new DispatcherTimer();
        DispatcherTimer dlgTimer = new DispatcherTimer();
        AdditionalCode additional;
        public Start(AdditionalCode adc)
        {
            InitializeComponent();
            dlgTimer.Interval = TimeSpan.FromMilliseconds(30);
            dlgTimer.Tick += new EventHandler(dialog_tick);

            timerAnimatie.Interval = TimeSpan.FromMilliseconds(1);
            timerAnimatie.Tick += new EventHandler(animatieTick);

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += new EventHandler(tm_tick);

            QuestionARRAY = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/bubbleDialog.txt");
            cv2.Visibility = Visibility.Visible;
            timer.Start();
            dlgTimer.Start();

            initpozI = Canvas.GetTop(eu);
            initpozJ = Canvas.GetLeft(eu);

            additional = adc;
        }

        int p = 0;
        string[] QuestionARRAY;
        string[] literaculitera = new string[100];
        int lft = 0;
        bool dlg = false;
        public void tm_tick(object sender, EventArgs e)
        {
            if (dlg == false)
            {
                init();
                p = 0;
                if (nrStr < QuestionARRAY.Length - 1)
                {
                    nrStr++;
                    dlgTimer.Start();
                }
                else
                {

                    dlgTimer.Stop();
                    QuestionARRAY = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/Dialog.txt");
                    dlg = true;
                    nrStr = 0;
                }
            }
            if (dlg == true)
            {
                init();
                if (nrStr % 2 == 0)
                {
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    if (lft % 2 == 0)
                        bmp.UriSource = new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/cezarel1.jfif", UriKind.RelativeOrAbsolute);
                    else
                        bmp.UriSource = new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/cezarel.jfif", UriKind.RelativeOrAbsolute);
                    lft++;
                    cv1.Visibility = Visibility.Hidden;
                    bmp.EndInit();
                    img.Height = 800;
                    img.Source = bmp;
                }
                else
                {
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/prof.jpg", UriKind.RelativeOrAbsolute);

                    bmp.EndInit();
                    img.Height = 1000;
                    img.Source = bmp;
                }
                p = 0;


                if (nrStr < QuestionARRAY.Length - 1)
                {
                    nrStr++;
                    dlgTimer.Start();
                }
                else
                {
                    timer.Stop();
                    dlgTimer.Stop();

                    cv1.Visibility = Visibility.Visible;
                    cv2.Visibility = Visibility.Hidden;
                    timerAnimatie.Start();
                }
            }
        }
        double initpozI = 0;
        double initpozJ = 0;
        int what_to_do = 0;
        public void animatieTick(object sender, EventArgs e)
        {
            if (what_to_do == 0)
                if (Canvas.GetLeft(eu) - initpozJ <= 55)
                {
                    Canvas.SetLeft(eu, Canvas.GetLeft(eu) + 2);
                }
                else
                {
                    what_to_do = 1;
                }
            if (what_to_do == 1)
                if (Canvas.GetTop(eu) - initpozI <= 235)
                {
                    Canvas.SetTop(eu, Canvas.GetTop(eu) + 2);
                }
                else
                {
                    what_to_do = 2;
                    initpozJ = Canvas.GetLeft(eu);
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/cezarel1.jfif", UriKind.RelativeOrAbsolute);
                    bmp.EndInit();
                    eu.Source = bmp;
                }
            if (what_to_do == 2)
            {
                if (initpozJ - Canvas.GetLeft(eu) <= 190)
                {
                    Canvas.SetLeft(eu, Canvas.GetLeft(eu) - 2);
                }
                else
                {
                    additional.lvl = 1;
                    additional.update = true;
                }
            }

        }
        public void dialog_tick(object sender, EventArgs e)
        {
            if (dlg == false)
            {
                bubble.Text += literaculitera[p];
            }
            if (dlg == true)
            {
                Dialog.Content += literaculitera[p];
            }
            if (p < literaculitera.Length)
                p++;
            else
            {
                dlgTimer.Stop();

            }
        }
        int nrStr = 0;
        public void init()
        {
            p = 0;
            for (int i = 0; i < literaculitera.Length; i++)
            {
                literaculitera[i] = "";
            }
            foreach (char c in QuestionARRAY[nrStr])
            {

                literaculitera[p] += c;
                p++;
            }
            if (dlg == true)
                Dialog.Content = "";
            if (dlg == false)
                bubble.Text = "";
        }
    }
}
