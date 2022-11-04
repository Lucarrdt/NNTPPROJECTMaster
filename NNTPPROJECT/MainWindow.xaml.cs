using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NNTPPROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NNTPConnection nntp = new NNTPConnection("news.dotsrc.org", 119);
            nntp.GetGroups();
            Debug.WriteLine(nntp.GetGroups()[1]);
            
        }

        private void GetNewsGroup_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onGetArticlesClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onGetArticleClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onPostArticleClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}