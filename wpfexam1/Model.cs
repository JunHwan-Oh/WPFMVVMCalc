using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfexam1
{
    class Model
    {
        private int _num = 0;
        
        public int num { get { return _num;} set {_num = value; } }

        private int _first;
        public int first { get { return _first; } set { _first = value; } }

        private int _second;
        public int second { get { return _second; } set { _second = value; } }
    }
}
