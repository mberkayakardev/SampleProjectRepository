using System;

namespace AkarEntities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate{ get; set; }
        public string ModUser { get; set; }
        public DateTime ModDate { get; set; }
        public bool GecerliFlg { get; set; } 


    }
}
