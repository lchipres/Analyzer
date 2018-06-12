using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizer
{
    class Datax
    {
            private char _what;
            private Datax _left;
            private Datax _right;
            private Datax _before;
            private Datax _next;

            public Datax Left { get { return _left; } set { _left = value; } }
            public Datax Right { get { return _right; } set { _right = value; } }
            public Datax Before { get { return _before; } set { _before = value; } }
            public Datax Next { get { return _next; } set { _next = value; } }
            public char What { get { return _what; } }

            public Datax(char what)
            {
                _what = what;
            }
    }
}
