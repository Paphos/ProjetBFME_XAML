using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib
{
    public class NameFactionChangedEventArgs : EventArgs
    {

        public string Nom
        {
            get;
            private set;
        }

        public NameFactionChangedEventArgs(string name)
        {
           Nom=name;
        }
    }
}
