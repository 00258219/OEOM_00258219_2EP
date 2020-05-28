namespace SourceCode.Modelo
{
    public class Product
    {
        public int id { get; set; }
        public int idBusiness { get; set; }
        public string name { get; set; }

        public Product()
        {
            id = 0;
            idBusiness = 0;
            name = "";
        }
    }
}