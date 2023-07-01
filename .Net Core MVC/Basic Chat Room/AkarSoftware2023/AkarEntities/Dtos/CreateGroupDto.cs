using AkarEntities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkarEntities.Dtos
{
    public class CreateGroupDto
    {
        public string GroupName { get; set; }
        public User Admin { get; set; }
        public string IsPublicOrPrivate { get; set; }
        public int MaxUserCount { get; set; }
    }
}
