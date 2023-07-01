using AkarEntities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkarEntities.Entities
{
    public class Group: BaseEntity
    {
        public string GroupName { get; set; }
        public List<User> MembersList { get; set; }
        public bool IsPublicOrPrivate { get; set; } = true;
        public int MaxUserCount { get; set; }
    }
}
