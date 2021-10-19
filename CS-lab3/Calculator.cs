using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_lab3 {
    static class Calculator {
        public static async Task<StatDataPartial> CalculatePartial(int[] data, int start, int end) {
            ulong sum = 0;
            int[] moda = new int[Program.max];
            await Task.Run(() => {
                for (int i = start; i < end; ++i) {
                    sum += (ulong)data[i]; 
                    ++moda[data[i] - 1];
                }
            });
            return new StatDataPartial(sum, sum / (end - start + 0.0), moda);
        }

        public static async Task<StatData> CalculateParalelTask(int[] data, int thread_num) {
            Task<StatDataPartial>[] taskArr = new Task<StatDataPartial>[thread_num];
            for(int i = 0; i < thread_num; ++i) {
                taskArr[i] = CalculatePartial(data, i * data.Length / thread_num, (i + 1) * data.Length / thread_num);
            }
            await Task.WhenAll(taskArr);

            ulong sum = 0;
            int[] modaSum = new int[Program.max];
            for(int i = 0; i < thread_num; ++i) {
                sum += taskArr[i].Result.sum;
                modaSum = modaSum.Zip(taskArr[i].Result.moda, (a, b) => a + b).ToArray();
            }

            return new StatData(sum, (sum + 0.0) / data.Length, Array.IndexOf(modaSum, modaSum.Max()));
        }

    }
}
