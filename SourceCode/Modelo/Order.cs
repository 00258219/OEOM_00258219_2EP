using System;

namespace SourceCode.Modelo
{
    public class Order
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int idProduct { get; set; }
        public int idAddres { get; set; }

        public Order()
        {
            id = 0;
            date = DateTime.Now;
            idProduct = 0;
            idAddres = 0;
        }
        
    }
}