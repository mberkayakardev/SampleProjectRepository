using System;

namespace AkarEntities.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get ; set ; }
        public string CreateUser { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public string ModUser { get ; set ; }
        public DateTime ModDate { get; set; } = DateTime.Now;
        public bool GecerliFlg { get; set; } = true;
    }
}
