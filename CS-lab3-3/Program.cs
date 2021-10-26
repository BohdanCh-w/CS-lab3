using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_lab3_3 {
    class Program {
        static void Main(string[] args) {
            string path = "";
            while (true) {
                path = Console.ReadLine();
                if (path == "") break;
                Task.Run(() => WriteFile(path));
            }
        }

        static async void WriteFile(string path) {
            int len = 10000;
            int[] data = generateArr(0, 9, len);
            string txt = "";
            for(int i = 0; i < len; i++) {
                txt += data[i].ToString();
                Thread.Sleep(1);
            }
            File.WriteAllText(path, txt);
            System.Console.WriteLine($"File {path} written successfully");
        }

        static int[] generateArr(int min, int max, int count) {
            Random randNum = new Random();
            int[] arr = Enumerable.Repeat(0, count)
                .Select(i => randNum.Next(min, max)).ToArray();
            return arr;
        }
    }
}
