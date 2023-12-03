using EfCorePractise.Datas.Contexts;
using EfCorePractise.Datas.Entities;

public class Program
{
    public static void Main(string[] args)
    {
        #region Entity Framework Te Veriye yaklaşım modelleri : 

        /// Model First : EDMX dosyası üzerinden desinger sayfası üzerinden modellerinizi tıpkı Sql Server Desinger inde olduğu gibi tasarladığınız bir verisyonduır. 

        /// Db First : Var olan bir veritabanı şeması üzerinden çalışılır. ilk adım olarak var olan veritabanı şemasında bir DbContext sınıfı ve varlık sınıfları oluşturulur. bu şekilde erişim yapabildiğiniz bir yöntemdir.  

        /// Code First : Kodlayarak her şeyi yaptığınız ve en çok tercih edilen yöntemdir. 

        /// Bu başlık altında code first ağırlıklı gideceğiz, dbfirst i çok rahat öğrenirsin DbFirst code first in tersi olarak düşünebilirsiniz. 

        #endregion

        #region Entity Framework Kurulumları 

        /// Entity Framework için 4 paket kurulumu gerekecektir. 

        /// 1.Microsoft.EntityFrameworkCore : Entity Framework ün kendisi için gerekli pakettir
        /// 
        /// 2.Microsoft.EntityFrameworkCore.SqlServer : Hangi Veritabanı teknolojisi ile çalışacaksak (Mongo, Sql, Oracle, MySql ...) İlgili provider yüklenecek
        /// 
        /// 3.Microsoft.EntityFrameworkCore.Tools : Migration komutlarını çalıştırabilmemiz için gerekli olacak olan kütüphanedir. (bu paket aracılığı ile Package Manager Console üzerinden ilgili migration komutlarını çalıştırabilirim)  
        /// 
        /// 4.Microsoft.EntityFrameworkCore.Design : (Migration komutlarını UI üzerinden uygulayabilmemiz için gereklidir, Model First gibi yapılarda yürütme zamanında tasarım yapmanı sağlar. Sınıflar ve ilişkileri grafiksel bir arayüz ile belirleyebilirsin veritabanı şemasını temsil eder. ama direk kodlama yapacaksan çokta gerek yok.  )

        #endregion

        #region Veritabanı oluşturulması 
        /// Entity Framework için 4 paket kurulumu gerekecektir. 

        /// 1.Microsoft.EntityFrameworkCore : Entity Framework ün kendisi için gerekli pakettir
        /// 
        /// 2.Microsoft.EntityFrameworkCore.SqlServer : Hangi Veritabanı teknolojisi ile çalışacaksak (Mongo, Sql, Oracle, MySql ...) İlgili provider yüklenecek
        /// 
        /// 3.Microsoft.EntityFrameworkCore.Tools : Migration komutlarını çalıştırabilmemiz için gerekli olacak olan kütüphanedir. (bu paket aracılığı ile Package Manager Console üzerinden ilgili migration komutlarını çalıştırabilirim)  
        /// 
        /// 4.Microsoft.EntityFrameworkCore.Design : (Migration komutlarını UI üzerinden uygulayabilmemiz için gereklidir, Model First gibi yapılarda yürütme zamanında tasarım yapmanı sağlar. Sınıflar ve ilişkileri grafiksel bir arayüz ile belirleyebilirsin veritabanı şemasını temsil eder. ama direk kodlama yapacaksan çokta gerek yok.  )
        #endregion

        #region Entities & Contexts

        /// Data klasörümün içerisinde 2 tip sınıf olacaktır.

        /// 1.) Veri Tabanımdaki Tablolarına karşılık gelecek olan Entityler, 
        /// 2.) Contextimiz 

        /// Entity : 

        /// * Veritabanımızdaki tabloları karşılayan programatik classlara Entity denmektedir. .
        /// * Veri Tabanındaki tabloların kolonlarının her birisi Sınıflarımızda Property olarak yazılacaktır. 
        /// * Veritabanındaki tabloları Classlar olarak ele alacağız.


        /// Context: 

        /// * Veritabanının Sessiondır.
        /// * Veritabanındaki varlıklar bilgisidir. 
        /// (Ef nin sınıflarından birisidir. Veritbanı işlemlerinin üzerinde yapıldığı alan olarak adlandırabiliriz.)


        /// Costume bir Cotnext sınıfı oluşturalım ve Entity Frameworkteki DbContext ten kalıtım alalım.
        /// Veritabanındaki varlıkların bilgisi olan Context imiz için DbSet<> şeklinde propertyleri tek tek yayınlayalım.
        /// Dbset şeklinde oluşturduğumuz Propertyler in isimleri varsaylılanda attribte ve fluent api geçmediğin sürece tablo ismi olarak entity framework core behaivor u gereği yansıyacaktır. 


        /// Costume Oluşturmuş olduğumuz context içerisinde ben bir methodu ezeceğim
        /// Polymorphizm dir.
        /// DbContext in içerisinde 2 method var bir tanesi OnModelCreating() biri OnConfiguring() tir. 
        /// Ezeceğim method OnConfiguring Methodudur. 
        /// ben OnConfiguring methodu ile DbContext nesnemi Configure edip kullanabilirim. (Log ayarı, Load ayarı, Bağlantı ve Pool Ayarı, Loglama ayarı ....)


        /// Yapılan her değişiklikle bir migration alıp bunu Database e yansıtmamız gerekecektir. 
        /// Migration işlemlerinde 2 önemli dosyamız vardır .



        /// ()
        /// 
        /// Snapshot için son oluşturulan migration bilgisi tutulmaktadır. 
        /// Migraiton ise neler yapacağını barındırmaktadır. 
        /// 
        /// ()



        /// Migration:

        /// Migration işlemi yapıldığında SnapShot dosyasına bakarak ilgili migration için neler yapacağımızı oluşturduğumuz 
        /// (güncellicem, tablo oluşturacam, drop edecem vs gibi.)


        /// Snapshot dosyası :

        /// her migration işleminde öncelikle SnapShot dosyası oluşur. bu dosya neticesinde entitylerimin ve configurasyonlarımın anlık yansımasıdır. 
        /// sonrasında migration dosyası buradaki anlık duruma (veritabanı seviyesinde değil program seviyesindeki entitylere ve ilişilere bakar) bakarak verison geçişi için ilgili değişiklikleri up ve Down olarak oluşturacaktır. 


        #endregion

        #region DbContext & Create 

        /// Bu bölümde DbContext nesnesini detaylı bir şekilde işleyeceğiz 

        /// siz bir DbContext nesnesi ile veritbanı işlemleri gerçekleştirebilirsiniz (CRUD) (database ile ilgili işlemleriniz CRUD işlemlerinizi )

        /// Sizler bir dbcontext ile query atabilir, veri okuyabilir, güncelleyebilir, silebilir ve ekleyebilirsiniz.

        /// DbContext ile bu işlemleri gerçekleştirebilmeniz için bir dbcontext örneği almanız gerekecektir 

        //MyDbContext context = new (); /// c# 9.0 dan sonra böyle hareket edebilirsiniz.         

        ////////////////////////////////////////////////////////////////////////////////////

        /// context.Add diyerek sizler veritabanına ekleme işlemi gerçekleştirebilirsiniz 
        //context.Add(new Product { Description = "Yeni ekleme", Name = "Berkay", Price = 120 });

        /// Add methodu sizlere bir EntityEntry nesnesi dönecektir. 
        //var entityEntry = context.Add(new Product { Description = "Yeni ekleme", Name = "Berkay", Price = 120 }); /// Entity entry içerisinde Statü (data statüsü), datanın kendisi , Context gibi bir takım değerler barındırmaktadır.  

        /// Context üzerinden propertylerinize giderek te sizler ekleme işlemini gerçekleştirebilirsiniz 
        //var entityEntry2 = context.Products.Add(new Product { Name = "BBerkay ", Price = 123, Description = "123" });

        /// bu şekilde de sizlere entity Entry dönecektir. yukarıda örneği mevcut.

        /// İdentity inert otomatik olarak açık olduğu için sen default value dışında herhangi bir şekilde elle id ye ekleme işlemlerinde müdahalae edemezsin inner excepion yersin id vermiceksin id nin önceden olup olmadığına bakamaz direk identity insert hatası atar. 

        /// add methodu ile sizler bir ekleme işlemi yaptığınızda değişiklikler direk veritabanına yansımaz. Direk bir ekleme işleminin gerçekleşmesi bekleniyor ama gerçekleşmez.

        /// Hatırlanıyorsa bir üstte ADD methodu geriye EntityEntry dönmektedir. aynı şekilde Update ve Delete de sizlere Entity Entry dönmektedir. 

        /// EntityEntry sizlere ilgili entitynin kendisi, Context ve entity Statüsü vermektedir (Untracking, unchanced, modified, deleted, Added ) 

        /// State i ilgili kaydın aksiyonunu belirtecektir. 

        /// sizlerin bu add methodu ile birlikte bir ekleme işlemini gerçekleştirelmeniz için changes methodunu kullanmanız gerekecektir. 
        //context.SaveChanges();

        /// Context.savechanges sizlere int şekilde etkilenen satır sayısını çevirecektir. (ado.net teki ExecuteNonQuery gibi aklınızda canlandırabilirsiniz.)

        /// Şuan yapılan değişiklikler veritabanına yansımıştır. 

        /// Aslında Add() Update(), Delete() gibi methodlar ile Entity Framework e şunu belirtiyorsunuz. ben bu nesneyi ekleyecem, güncelleyeceğim, sileceğim gibi belirtiyorsunuz. EntityEntry ile salında bu methodlar sadece Statelerinin değişlemsine sebebiyet vermektedir. 

        /// İşlemin gerçekleştirilebilmesi için SaveChanges ile işlemin gerçekleşmesi gerekecektir. 

        #region Ekleme çalışmaları 
        /// çektiğin datayı elle eklersen identity hatası atar aynı şekilde kendinde disconnected da oluşturduğun entity hata atar elle id veremezsin.
        //var comtext2 = new MyDbContext();
        //var model = comtext2.Products.FirstOrDefault();
        //var modelstatus = comtext2.Entry(model).State;
        //comtext2.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //var modelstatus2 = comtext2.Entry(model).State;
        //model.Id = 0;

        //var context2 = new MyDbContext();
        //var product = new Product { Name = "DisconnectedPRoduct", Price = 123, Description = "Selamlar" };
        //var status = context2.Entry(product).State;  // Detached yani takip edilmiyor 
        //var modelbilmemne = context.Products.FirstOrDefault();
        //var statusTakipedilen = context.Entry(modelbilmemne).State;


        //context2.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //var status2 = context2.Entry(product).State;
        //context2.SaveChanges();







        //var comtext2 = new MyDbContext();
        //comtext2.Add(new Product {Id = 12500, Description = "a", Name = "b", Price = 3 });




        #endregion
        #endregion

        #region Update Operation

        ///// Bir önceki dersimizde veri ekleme işlemini gerçekleştirmiştik.

        ///// Bu dersimizde bizler bir veriyi güncelleyelim. 

        ///// Bizler bir veriyi eklerken add methodunu kullanıyorsak güncellerken de update methodunu kullanmamız gerekir. 

        //MyDbContext c = new();
        ////c.Update();
        //c.Products.Update(new Product { Id = 2, Name = "Berkay", Description = "Akar" });
        //c.SaveChanges();

        ///// bu şekjilde disconnected entity kullanmamız bizim için bir problemdir. vermediğpimiz property bizlerin karşısına null alanlar olarak çıkacaktır.


        ///// Bu sebepten ötürü bizler veriyi güncellerken 2 yöntem kullanırız.


        ///// 1.Connected Entity : en çok kullanılan yöntem budur. VeriTabanından veri çekilir. Sonrasında sadece istenen alan güncellenir ve tekrardan kaydedilir. 

        //var model = c.Products.FirstOrDefault(x => x.Id == 4);
        //model.Name = "Connected güncellendi";
        ////c.Products.Update(model);
        //c.SaveChanges();

        ///// Disconnected entity : genellikle tercih edilmez çünkü esasında sorunlara sebebiyet verecektir. bu sebepten ötürü 



        #region Aklımda kalan sorular 

        //MyDbContext c = new MyDbContext();
        ////c.Update(new Product { Name = "Berkay", Price = 213, Description = "akar" , Id = 0 }); // insert atar, olmayan bir id verirsen hata verir
        //c.Kategoriler.Update(new Category { Name = "AHMET MEHMET HASAN HÜSEYİN CABBAR" ,Id = "asasdd"});
        //c.SaveChanges();



        #endregion




        #endregion

        #region Delete Operation 

        MyDbContext c = new MyDbContext();
        var model = c.Products.FirstOrDefault();
        var entityEntyry = c.Entry(model).State;
        c.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        var entityEntyr2 = c.Entry(model).State;

        c.SaveChanges();


        #endregion
    }
}