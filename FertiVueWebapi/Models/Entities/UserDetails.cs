using Microsoft.EntityFrameworkCore;

namespace FertiVueWebapi.Models.Entities
{
    public class UserDetails
    {
        
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public string clinicName { get; set; }
        public string country { get; set; }
        public string platform { get; set; }
        public string massage { get; set; }
        public string ipaddress { get; set; }

    }
}
