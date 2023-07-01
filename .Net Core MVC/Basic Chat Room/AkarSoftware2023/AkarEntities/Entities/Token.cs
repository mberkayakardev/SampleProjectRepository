using AkarEntities.Abstract;
using System;

namespace AkarEntities.Entities
{
    public class Token : BaseEntity
    {

        public string OneTimeUsableToken { get; set; } = Guid.NewGuid().ToString();
        public User Person{ get; set; } 
        public Group Gruoup { get; set; }
        public bool IsUsed { get; set; } = false;


    }
}
