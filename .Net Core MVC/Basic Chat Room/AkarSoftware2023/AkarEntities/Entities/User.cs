using AkarEntities.Abstract;
using System.Collections.Generic;

namespace AkarEntities.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserPhoto { get; set; }
        public List<Group> Groups {get ; set;}
    }
}
