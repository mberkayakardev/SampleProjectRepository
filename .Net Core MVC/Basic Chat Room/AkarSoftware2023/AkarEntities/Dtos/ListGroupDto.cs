using AkarEntities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace AkarEntities.Dtos
{
    public class ListGroupDto
    {
        public int Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public bool GecerliFlg { get; set; } = true;
        public string GroupName { get; set; }
        public bool IsPublicOrPrivate { get; set; }
        public List<User> MembersList { get; set; }
        public bool KatilimSaglanabilirmi { get; set; }


    }
}
