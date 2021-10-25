using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace CS_lab3 {
    class Program {
        public static int max = 50;

        static void Main(string[] args) {
            int num = 1_000_000;
            int[] data = generateArr(1, max, num);
            var TaskTime = ParalellTaskTest(data);
            var PLINQTime = ParalellPLINQTest(data);
            var TPoolTime = ParalellThreadPoolTest(data);

            Console.WriteLine("Threads       Tasks       PLINQ       TPool");
            foreach(var key in TaskTime.Keys) {
                Console.WriteLine($"  {key, 2:d}  :    {TaskTime[key], 8:d}    "
                    + $"{PLINQTime[key], 8:d}    {TPoolTime[key], 8:d}");
            }
        }

        static Dictionary<int, long> ParalellTaskTest(int[] data) {
            Stopwatch stopwatch = new Stopwatch();
            Dictionary<int, long> time_dict = new Dictionary<int, long>();
            int[] threadCount = new int[] { 1, 2, 4, 8, 10 };
            
            foreach( int c in threadCount ) {
                stopwatch.Restart();
                var res = Calculator.CalculateParalelTask(data, c);
                stopwatch.Stop();
                time_dict[c] = stopwatch.ElapsedTicks;
            }
            return time_dict;
        }

        static Dictionary<int, long> ParalellPLINQTest(int[] data) {
            Stopwatch stopwatch = new Stopwatch();
            Dictionary<int, long> time_dict = new Dictionary<int, long>();
            int[] threadCount = new int[] { 1, 2, 4, 8, 10 };
            
            foreach( int c in threadCount ) {
                stopwatch.Restart();
                var res = Calculator.CalculatePLINQ(data, c);
                stopwatch.Stop();
                time_dict[c] = stopwatch.ElapsedTicks;
            }
            return time_dict;
        }

        static Dictionary<int, long> ParalellThreadPoolTest(int[] data) {
            Stopwatch stopwatch = new Stopwatch();
            Dictionary<int, long> time_dict = new Dictionary<int, long>();
            int[] threadCount = new int[] { 1, 2, 4, 8, 10 };
            
            foreach( int c in threadCount ) {
                stopwatch.Restart();
                var res = Calculator.CalculateThreadPool(data, c);
                stopwatch.Stop();
                time_dict[c] = stopwatch.ElapsedTicks;
            }
            return time_dict;
        }

        static int[] generateArr(int min, int max, int count) {
            Random randNum = new Random();
            int[] arr = Enumerable.Repeat(0, count)
                .Select(i => randNum.Next(min, max)).ToArray();
            return arr;
        }
    }
}
