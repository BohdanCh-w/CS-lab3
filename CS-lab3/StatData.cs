using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_lab3 {
    class StatData {
        public long sum { get; set; }
        public double avrg { get; set; }
        public int moda { get; set; }

        public StatData() { }

        public StatData(long _sum, double _avrg, int _moda) {
            sum = _sum;
            avrg = _avrg;
            moda = _moda;
        }

        public override string ToString() {
            return String.Format("<StatData>(sum={0}, avrg={1}, moda={2})", sum, avrg, moda);
        }
    }
    
    class StatDataPartial : StatData {
        public new int[] moda { get; set; }

        public StatDataPartial(long _sum, double _avrg, int[] _moda) {
            sum = _sum;
            avrg = _avrg;
            moda = _moda;
        }        
    }

    class Parameters {
        public int[] arr { get; set; }
        public int start { get; set; }
        public int end { get; set; }

        public Parameters(int[] _arr, int _start, int _end) {
            arr = _arr;
            start = _start;
            end = _end;
        }
    };
}
