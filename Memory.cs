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
            public bool constant;
        }
        public Dictionary<string, object> variables = new Dictionary<string, object>();
        public List<Variable> variabs = new List<Variable>();
        public void Define(string name, object value,bool constant)
        {
            variables.Add(name, value);
            Variable var;
            var.name = name;
            var.value = value;
            var.constant = constant;
            variabs.Add(var);
        }
        public object Get(Token name)
        {
            if (variables.ContainsKey(name.value))
            {
                return variables[name.value];
            }
            if(variabs.Co)
            return null;
        }
    }
}
