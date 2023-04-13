using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac4sharp
{
    class MyClass
    {
        public string name { get; set; }
        public string type_buy { get; set; }
        private int _money;
        public int money
        {
            get { return _money; }
            set
            {
                if (value < 0)
                {
                    plus_minus = false;
                    _money = value * -1;
                }
                else { plus_minus = true; _money = value; }
                
            }
        }

        public bool plus_minus;
        public object date_buy;

        public MyClass(string name, string type_buy, int money, object date_buy) 
        {
            this.name = name;
            this.type_buy = type_buy;
            this.money = money;
            this.date_buy = date_buy;
        }
    }
}
