using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_lab3 {
    static class Calculator {
        private static async Task<StatDataPartial> CalculatePartialTask(int[] data, int start, int end) {
            long sum = 0;
            int[] moda = new int[Program.max];
            await Task.Run(() => {
                for (int i = start; i < end; ++i) {
                    sum += (long)data[i]; 
                    ++moda[data[i] - 1];
                }
            });
            return new StatDataPartial(sum, (double)sum / (end - start), moda);
        }

        public static async Task<StatData> CalculateParalelTask(int[] data, int thread_num) {
            Task<StatDataPartial>[] taskArr = new Task<StatDataPartial>[thread_num];
            for(int i = 0; i < thread_num; ++i) {
                taskArr[i] = CalculatePartialTask(data, i * data.Length / thread_num, (i + 1) * data.Length / thread_num);
            }
            await Task.WhenAll(taskArr);

            long sum = 0;
            int[] modaSum = new int[Program.max];
            for(int i = 0; i < thread_num; ++i) {
                sum += taskArr[i].Result.sum;
                modaSum = modaSum.Zip(taskArr[i].Result.moda, (a, b) => a + b).ToArray();
            }

            return new StatData(sum, (double)sum / data.Length, Array.IndexOf(modaSum, modaSum.Max()));
        }

        public static StatData CalculatePLINQ(int[] data, int thread_num) {
            long sum = data.AsParallel().WithDegreeOfParallelism(thread_num).Sum();
            double avrg = (double)sum / data.Length;
            int[] moda = data.AsParallel().WithDegreeOfParallelism(thread_num).Distinct().Select(uniq => data.Count(val => val == uniq)).ToArray();
            return new StatData(sum, avrg, Array.IndexOf(moda, moda.Max()));
        }

        private static StatDataPartial CalculatePartialPool(int[] data, int start, int end) {
            long sum = 0;
            int[] moda = new int[Program.max];
            for (int i = start; i < end; ++i) {
                sum += (long)data[i]; 
                ++moda[data[i] - 1];
            }
            return new StatDataPartial(sum, (double)sum / (end - start), moda);
        }

        public static StatData CalculateThreadPool(int[] data, int thread_num) {
            int counter = thread_num;
            int resCounter = 0;
            StatDataPartial[] resArr = new StatDataPartial[thread_num];

            using(ManualResetEvent resetEvent = new ManualResetEvent(false)) {
                Action<object> resultCallback = (result) => {
                    resArr[Interlocked.Increment(ref resCounter)-1] = (StatDataPartial)result;
                };

                WaitCallback workItem = (tuple) => {
                    Parameters prm = (Parameters)tuple;
                    resultCallback(CalculatePartialPool(prm.arr, prm.start, prm.end));
                };

                for(int i = 0; i < thread_num; ++i) {
                    ThreadPool.QueueUserWorkItem(workItem, 
                        new Parameters(data, i * data.Length/thread_num, (i+1) * data.Length/thread_num));
                } 

                resetEvent.WaitOne();
            }

            long sum = 0;
            int[] modaSum = new int[Program.max];
            for(int i = 0; i < thread_num; ++i) {
                sum += resArr[i].sum;
                modaSum = modaSum.Zip(resArr[i].moda, (a, b) => a + b).ToArray();
            }

            return new StatData(sum, (double)sum / data.Length, Array.IndexOf(modaSum, modaSum.Max()));
        }
    }
}
