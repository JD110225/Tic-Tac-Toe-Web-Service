using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Tarea3.Models
{
    public class x
    {
        public List<String> list;
        public x()
        {
            list = new List<string>();
        }
        public void append(string value)
        {
            list.Add(value);
        }

        public void viewList()
        {
            foreach(String val in list)
            {
                Debug.WriteLine(val);
            }
        }
    }
}