using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Memory
    {
        public Memory parent;
        public Dictionary<string, object> variables = new Dictionary<string, object>();
        public Memory(Memory parent)
        {
            this.parent = parent;
        }
        public Memory()
        {
            this.parent = null;
        }
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
            if (parent != null) return parent.Get(name);
            return null;
        }
        public void Assign(Token name,object value)
        {
            if (variables.ContainsKey(name.value))
            {
                variables[name.value] = value;
            }
            if (parent != null) parent.Assign(name,value);
        }
    }
}
