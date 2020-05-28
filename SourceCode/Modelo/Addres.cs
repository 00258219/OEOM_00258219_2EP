namespace SourceCode.Modelo
{
    public class Addres
    {
        public int id { get; set; }
        
        public int idUser { get; set; }
        
        public string address { get; set; }

        public Addres()
        {
            id = 0;
            idUser = 0;
            address = "";
        }
    }
}