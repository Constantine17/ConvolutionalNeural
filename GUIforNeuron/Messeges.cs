using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIforNeuron
{
    class Messeges
    {
        static public List<string> messeges = new List<string>();

        static public void Write(object sTring)
        {
            messeges.Add(sTring.ToString());
        }
    }
}
