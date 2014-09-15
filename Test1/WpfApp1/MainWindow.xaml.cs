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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> _customers = new List<Customer>();

        public MainWindow()
        {
            InitializeComponent();
        }

        void print(string msg)
        {
            txtReport.AppendText(msg);
        }

        void println(string msg)
        {
            print(msg + "\n");
        }

        void setupData1()
        {
            _customers.Clear();

            _customers.Add(new Customer { 年齢 = 37, 性別 = "女", 職業 = "会社員", 月収 = 28 });
            _customers.Add(new Customer { 年齢 = 22, 性別 = "男", 職業 = "会社員", 月収 = 25 });
            _customers.Add(new Customer { 年齢 = 29, 性別 = "男", 職業 = "自営業", 月収 = 35 });
            _customers.Add(new Customer { 年齢 = 27, 性別 = "女", 職業 = "公務員", 月収 = 40 });
            _customers.Add(new Customer { 年齢 = 34, 性別 = "男", 職業 = "会社員", 月収 = 31 });
        }

        private void btEx01_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var nums = from a in numbers 
                       where a < 5 
                       select (a*2).ToString();

            foreach (var x in nums)
            {
                println(x);
            }
        }

        private void btEx02_Click(object sender, RoutedEventArgs e)
        {
            setupData1();

            var men = from p in _customers
                       where p.性別 == "男"
                       select p.月収;

            println("*** 男 ***");
            foreach (var x in men)
            {
                println(x.ToString());
            }
            int sumMen = men.Sum();
            println(string.Format("sum={0}", sumMen));

            double avgMen = ((double)sumMen) / men.Count();
            println(string.Format("average={0}", avgMen));

            var women = from p in _customers
                        where p.性別 == "女"
                        select p.月収;

            println("*** 女 ***");
            foreach (var x in women)
            {
                println(x.ToString());
            }
            int sumWomen = women.Sum();
            println(string.Format("sum={0}", sumWomen));

            double avgWomen = ((double)sumWomen) / women.Count();
            println(string.Format("average={0}", avgWomen));
        }

        // ソート(OrderBy)
        private void btEx03_Click(object sender, RoutedEventArgs e)
        {
            setupData1();

            var sortedData = _customers.OrderBy(a => a.年齢);

            foreach (var p in sortedData)
            {
                println(string.Format("年齢={0}, 性別={1}, 職業={2}, 月収={3}",
                    p.年齢, p.性別, p.職業, p.月収));
            }
        }
    }

    public class Customer
    {
        public int 年齢 { get; set; }
        public string 性別 { get; set; }
        public string 職業 { get; set; }
        public int 月収 { get; set; }
    }
}
