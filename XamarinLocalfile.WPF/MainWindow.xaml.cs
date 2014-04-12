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
using System.Xml.Linq;
using XamarinLocalfile.Core;

namespace XamarinLocalfile.WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MyData _model = new MyData();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ローカルファイルに保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var doc = _model.ToXDoc();
            doc.Save("mydata.xml");
            MessageBox.Show("保存しました");
        }
        /// <summary>
        /// ローカルファイルから読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var doc = XDocument.Load("mydata.xml");
            _model.FromXDoc(doc);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _model = new MyData();
            this.DataContext = _model;
        }
    }
}
