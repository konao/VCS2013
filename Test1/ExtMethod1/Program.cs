// **************************************************************
//  拡張メソッドの実験
//
//  2014/7/11 konao
// **************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethod1
{
    class MyData
    {
        public double _x;
        public double _y;

        public MyData(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }

    static class MyExtension1
    {
        public static double Add(this MyData d)
        {
            return d._x + d._y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyData d = new MyData(2, 3);

            // 拡張メソッド
            Console.WriteLine(d.Add());

            // 拡張メソッドの引数にはthisが付いているが、このように普通のstatic methodとしても呼び出せる．
            Console.WriteLine(MyExtension1.Add(d));
        }
    }
}
