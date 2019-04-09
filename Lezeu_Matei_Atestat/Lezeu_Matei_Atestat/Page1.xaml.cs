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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        
        public Page1()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
            dialogcipri = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+@"\res\dialogulcipri.txt");
            dialogelev = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\res\dialogulelev.txt");



        }
        string[] dialogcipri;
        string[] dialogelev;
        int i = 0, j = 0;
        private void timer_tick(object sender, EventArgs e)
        {
            GrCipri = GrCipri == true ? false : true;
            if (GrCipri)
            {
                GraiCipri.Text = dialogcipri[i];
                i = i < dialogelev.Length ? i + 1 : i;
                GraiElev.Visibility = Visibility.Hidden;
                GraiCipri.Visibility = Visibility.Visible;

            }
            if (GrCipri==false)
            {
                GraiElev.Text = dialogelev[j];
                j = j < dialogelev.Length ? j + 1 : j;
                GraiCipri.Visibility = Visibility.Hidden;
                GraiElev.Visibility = Visibility.Visible;
            }


        }
        bool GrCipri=true;
        private void GraiCipri_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
