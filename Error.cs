using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Error
    {
        private string type;
        public Error(string type)
        {
            this.type = type;
        }
        public override string ToString()
        {
            return this.type + "Error";
        }
    }
}
