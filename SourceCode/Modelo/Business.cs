namespace SourceCode.Modelo
{
    public class Business
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public string description { get; set; }

        public Business()
        {
            id = 0;
            name = "";
            description = "";
        }
    }
}