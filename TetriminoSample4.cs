using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Tetorimino
{
    class Program
    {
        static string[] minoTable = new string[50000];
        static char[] t = new char[7] { 'I', 'O', 'T', 'J', 'L', 'S', 'Z' };
        static List<string> minoPattern = new List<string>(5040);

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            GetTetriminoWave();
            sw.Stop();
            Console.WriteLine("かかった時間は{0}", sw.Elapsed);
            sw.Reset();

            sw.Start();
            GetTetriminoWave2();
            sw.Stop();
            Console.WriteLine("かかった時間は{0}", sw.Elapsed);

            sw.Reset();

            sw.Start();
            GetTetriminoWave3();
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

        static void GetTetriminoWave()
        {
            //全部を用意すると5040個の配列を用意する

            List<char> tl = new List<char>(t);
            char[] s = new char[t.Length];

            for (int i0 = 0; i0 < t.Length; i0++) {
                List<char> l1 = new List<char>(tl);
                s[0] = t[i0];
                l1.Remove(t[i0]);
                for (int i1 = 0; i1 < l1.Count; i1++) {
                    List<char> l2 = new List<char>(l1);
                    s[1] = l1[i1];
                    l2.Remove(l1[i1]);
                    for (int i2 = 0; i2 < l2.Count; i2++) {
                        List<char> l3 = new List<char>(l2);
                        s[2] = l2[i2];
                        l3.Remove(l2[i2]);
                        for (int i3 = 0; i3 < l3.Count; i3++) {
                            List<char> l4 = new List<char>(l3);
                            s[3] = l3[i3];
                            l4.Remove(l3[i3]);
                            for (int i4 = 0; i4 < l4.Count; i4++) {
                                List<char> l5 = new List<char>(l4);
                                s[4] = l4[i4];
                                l5.Remove(l4[i4]);
                                for (int i5 = 0; i5 < l5.Count; i5++) {
                                    List<char> l6 = new List<char>(l5);
                                    s[5] = l5[i5];
                                    l6.Remove(l5[i5]);
                                    for (int i6 = 0; i6 < l6.Count; i6++) {
                                        s[6] = l6[i6];
                                        minoPattern.Add(new string(s));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Random random = new Random();
            for (int i = 0; i < minoTable.Length; i++) {
                minoTable[i] = minoPattern[random.Next(0, minoPattern.Count)];
            }
        }
        static void GetTetriminoWave2()
        {
            Random random = new Random();
            List<char> tl2 = new List<char>(t);
            List<List<char>> getTable = new List<List<char>>();
            getTable = GetCombination<char>(tl2);
            for (int i = 0; i < minoTable.Length; i++) {
                minoTable[i] = getTable[random.Next(0, minoPattern.Count)].ToString();
            }
        }

        static void GetTetriminoWave3()
        {
            Random random = new Random();
            List<char> tl2 = new List<char>(t);
            List<List<char>> getTable = new List<List<char>>();
            getTable = GetCombination<char>(new List<char>(), tl2);
            for (int i = 0; i < minoTable.Length; i++) {
                minoTable[i] = getTable[random.Next(0, minoPattern.Count)].ToString();
            }
        }


        static private List<List<T>> GetCombination<T>(List<T> inList)
        {
            List<List<T>> val = new List<List<T>>();
            List<T> newList, tempList;
            List<List<T>> getList;
            if (inList.Count <= 1) {
                List<T> temp = new List<T>();
                temp.Add(inList[0]);
                val.Add(temp);
            }
            else {
                for (int i = 0; i < inList.Count; i++) {
                    newList = new List<T>(inList);
                    T topItem = newList[i];
                    newList.RemoveAt(i);
                    getList = GetCombination(newList);
                    foreach (List<T> getItem in getList) {
                        tempList = new List<T>();
                        tempList.Add(topItem);
                        tempList.AddRange(getItem);
                        val.Add(tempList);
                    }
                }
            }
            return val;
        }

        static private List<List<T>> GetCombination<T>(List<T> fixedList, List<T> inList)
        {
            List<List<T>> val = new List<List<T>>();
            List<T> newFixedList = new List<T>(fixedList);
            for (int i = 0; i < inList.Count; i++) {
                List<T> newList = new List<T>(inList);
                newFixedList.Add(inList[i]);
                newList.RemoveAt(i);
                if (newList.Count > 0) {
                    val.AddRange(GetCombination<T>(newFixedList, newList));
                }
                else {
                    val.Add(fixedList);
                }
            }
            return val;
        }

    }
}
