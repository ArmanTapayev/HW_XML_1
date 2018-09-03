using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_XML_1_03._09._2018
{
    public class Bank
    {
        public string Buy { get; set; }
        public string Sale { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            string str = string.Format(">>Наименование банка: {0}\n" +
                "Покупка: {1}\n" +
                "Продажа: {2}\n\n", Name, Buy, Sale);
            return str;
        }
    }
}
