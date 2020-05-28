namespace SourceCode.Modelo
{
    public class User
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        
        public User()
        {
            id = 0;
            fullname = "";
            username = "";
            password = "";
            admin = false;
        }
    }
}