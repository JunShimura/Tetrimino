using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tetorimino
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            char[] t = new char[7] { 'I', 'O', 'T', 'J', 'L', 'S', 'Z' };
            //全部を用意すると5040個の配列を用意すると大変
            string[] minoTable = new string[50000];
            Random random = new Random();
            for (int i = 0; i < minoTable.Length; i++)
            {   //ミノの順番を出力する
                List<char> minoList = new List<char>(t);
                for (int j = t.Length; j > 0; j--)
                {   //残りｊ文字から1文字取り出して繋げる
                    int r = random.Next(0, j);
                    minoTable[i] += minoList[r];
                    //一度引いた要素を取り除く
                    minoList.RemoveAt(r);
                }
            }
            sw.Stop();
            Console.WriteLine("かかった時間は{0}", sw.Elapsed);

            /*
            // 結果を出力
            for (int i = 0; i < minoTable.Length; i++)
            {
                Console.WriteLine("{0}番目：{1}", i, minoTable[i]);
            }
            */
        }
    }
}
