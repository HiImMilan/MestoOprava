using Xamarin.Forms;

namespace MestoOpravaV2
{
    public class Post 
    {
        public string creator{get;set;}
        public string title { get;set;}
        public string description { get;set;}
        public string latitude { get;set;}
        public string longitude { get;set;}
        public string imageURL { get;set;}
        public int creationID { get; set; }
        public string adress { get; set; }
    }
}