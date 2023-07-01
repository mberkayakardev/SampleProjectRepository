using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AkarDataAccess.Concrete.DataAccess.Configuration
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new List<User>
            {
                new User { Id = 1, CreateDate = DateTime.Now , UserPhoto = "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0", UserName = "mberkayakar",Password="mberkayakar",ModUser = "BERKAY AKAR" ,ModDate = DateTime.Now,GecerliFlg = true  , CreateUser = "BERKAY AKAR"},
                new User { Id = 2, CreateDate = DateTime.Now , UserPhoto = "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0", UserName = "atelyon",Password="atelyon",ModUser = "BERKAY AKAR" ,ModDate = DateTime.Now,GecerliFlg = true  , CreateUser = "BERKAY AKAR"}


            }); ;
        }
    }
}
