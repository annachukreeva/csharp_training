using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Figure
    {
        private bool Colored = false;
        public bool colored
        {
            get
            {
                return Colored;
            }
            set
            {
                Colored = value;
            }
        }
    }
}
