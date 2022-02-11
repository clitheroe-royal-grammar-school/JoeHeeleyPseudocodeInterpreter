using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Memory
    {
        public struct Variable
        {
            public string name;
            public object value;
        }
        public Dictionary<string, object> variables = new Dictionary<string, object>();
        public void Define(string name, object value)
        {
            variables.Add(name, value);
        }
        public object Get(Token name)
        {
            if (variables.ContainsKey(name.value))
            {
                return variables[name.value];
            }
            return null;
        }
    }
}
