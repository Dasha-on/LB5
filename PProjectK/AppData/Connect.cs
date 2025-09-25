using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PProjectK.AppData
{
    internal class Connect
    {
        public static TestEntities c;
        public static TestEntities context
        {
            get
            {
                if (c == null)
                {
                    c = new TestEntities();
                    return c;
                }
                else
                {
                    return c;
                }
            }

        }
    }
}
