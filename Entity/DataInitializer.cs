using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        //test verileri
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Ceket",Description="Ceket Urunleri"},
                new Category(){Name="Etek",Description="Etek Urunleri"},
                new Category(){Name="Pantolon",Description="Pantolon urunleri"},
                new Category(){Name="Sapka",Description="Sapka Urunleri"},
                new Category(){Name="Eldiven",Description="Eldiven Urunleri"},
                new Category(){Name="Ayakkabi",Description="Ayakkabi Urunleri"},
                new Category(){Name="Tshirt",Description="Tshirt Urunleri"},
                new Category(){Name="Pantolonn",Description="Pantolonn Urunleri"},


            };
            foreach(var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name="Siyah Kışlık Mont",Description="Kışlık Mont Koyu Renk Kalın",Price=150,Stock=100,IsApproved=true,CombinationNumber=1,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="Siyah Kısa Etek",Description="Siyah pileli etek",Price=65,Stock=10,IsApproved=true,CombinationNumber=1,CategoryId=2,IsHome=true,Image="2.jpg"},
                new Product(){Name="Siyah Kaban",Description="Siyah Renk Kaban Sert Kumas",Price=80,Stock=400,IsApproved=true,CombinationNumber=1,CategoryId=3,IsHome=true,Image="3.jpg"},
                new Product(){Name="Kislik Bere ",Description="Kislik Yun Bere Kulak Korumali",Price=35,Stock=80,IsApproved=true,CombinationNumber=1,CategoryId=4,IsHome=true,Image="4.jpg"},
                new Product(){Name="Deri Eldiven",Description="Siyah deri eldiven",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=5,IsHome=true,Image="1.jpg"},
                 new Product(){Name="Siyah Ayakkabi",Description="Siyah ayakkabi",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=6,IsHome=true,Image="6.jpg"},
                 new Product(){Name="Beyaz Ayakkabi",Description="Beyaz ayakkabi",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=6,IsHome=true,Image="7.jpg"},
                 new Product(){Name="Kirmizi Ayakkabi",Description="Kirmizi ayakkabi",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=6,IsHome=true,Image="8.jpg"},
                 new Product(){Name="Siyah Tshirt",Description="Siyah Tshirt",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=7,IsHome=true,Image="9.jpg"},
                 new Product(){Name="Beyaz Tshirt",Description="Beyaz Tshirt",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=7,IsHome=true,Image="10.jpg"},
                 new Product(){Name="Kirmizi Tshirt",Description="Kirmizi Tshirt",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=7,IsHome=true,Image="11.jpg"},
                 new Product(){Name="Siyah Pantolon",Description="Siyah Pantolon",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=8,IsHome=true,Image="12.jpg"},
                 new Product(){Name="Beyaz Pantolon",Description="Beyaz Pantolon",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=8,IsHome=true,Image="13.jpg"},
                 new Product(){Name="Kirmizi Pantolon",Description="Kirmizi Pantolon",Price=50,Stock=90,IsApproved=true,CombinationNumber=1,CategoryId=8,IsHome=true,Image="14.jpg"},



                new Product(){Name="Siyah Kot Ceket",Description="Mevsimlik Kot Cekket Siyah Renk",Price=180,Stock=100,IsApproved=false,CombinationNumber=1,CategoryId=1,IsHome=true,Image="5.jpg"},
                new Product(){Name="Sari Kisa Etek",Description="Sari Kisa pamuk etek",Price=95,Stock=10,IsApproved=false,CombinationNumber=2,CategoryId=2,IsHome=false,Image="1.jpg"},
                new Product(){Name="Siyah Kot Pantolon",Description="Kislik Pantolon Koyu Renk Yumusak Kumas",Price=180,Stock=400,IsApproved=true,CombinationNumber=1,CategoryId=3,IsHome=true,Image="2.jpg"},
                new Product(){Name="Yazlik Sapka ",Description="Yazlik Kumas Sapka",Price=35,Stock=80,IsApproved=true,CombinationNumber=2,CategoryId=4,IsHome=false,Image="4.jpg"},
                new Product(){Name="Pamuk Eldiven",Description="Pamuk gri eldiven",Price=50,Stock=90,IsApproved=true,CombinationNumber=2,CategoryId=5,IsHome=false,Image="3.jpg"},


            };

            foreach(var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();


            base.Seed(context);
        }


    }
}