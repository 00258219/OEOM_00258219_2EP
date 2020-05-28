using System;

namespace SourceCode.Modelo
{
    public class Order
    {
        public int id { get; set; }
        public string date { get; set; }
        public string product { get; set; }
        public string address { get; set; }

        public Order()
        {
            id = 0;
            date = "";
            product = "";
            address = "";
        }
        
    }
}