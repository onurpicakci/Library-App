## Library-App

Bu uygulama işe alım sürecindeki verilen case sonucunda yapılmıştır. Uygulama tek bir katmanla da yapılabilecek düzeyde ve kolaylıkta olmasına rağmen tecrübelerimi gösterebilmek adına Çok Katmanlı Mimari yapısını kullandım. Entity, DataAccess, Business ve UI katmanı olarak ayırabilecek şekilde toplamda 4 katmana ayırdım.

- Entity katmanında Book klasörü içerisinde farklı property'lere sahip bir Book Entity'si oluşturdum. 
- DataAccess katmanında veri tabanına bağlanabilmek context sınıfını ekledim. Aynı zamanda ekleme, güncelleme, silme gibi CRUD işlemlerinin de yapıldığı işlemleri bu katmana yazdım.
- Business katmanında iş kurallarının yazıldığı yani Uİ ile veri tabanı arasındaki requestleri karşılamadan önce geçilmesi gereken kuralları bu katmana yazdım. Ekstra olarak validation işlemlerini de buraya ekledim. Validation için FluentValidation kütüphanesini kullandım.
- Son olarak UI katmanında Get ve Post işlemlerinin, veri alışverişini yapıldığı katmanda gerekli işlemleri yaptım. Kullanıcı arayüzü olarak farklı tema template'leri veya çok daha kullanıcı dostu tasarımlar yapılabilirdi ancak verdiğiniz case doğrultusunda işlemlerin doğru ve eksiksiz yapılmasında daha dikkatli oldum.


Verdiğiniz case doğrultusunda tek bir Book tablosuyla işlemleri gerçekleştirdim. Kitabın özellikleri haricinde kitabı ödünç alacak kişinin adını ve kitabı geri getirme tarihiyle alakalı property'i de bu entity içerisinde tuttum. Ödünç alan kişinin bilgisi login gibi bir işlem olsaydı User tablosu oluşturularak yapılabilirdi ancak uygulama çok komplike olmadığı için 2 tablo arasında ilişki kurmaya gerek kalmadığını düşündüm.

Anasayfada kitapların alfabetik sıraya göre listelenmesini backend tarafında yaptım. Status -> True olduğu durumda kitabın mevcut olarak kütüphanede bulunduğunu belirtiyor ve **Borrower** butonu aktif oluyor. Eğer kitap ödünç alındıysa Status -> False oluyor ve ödünç alan kişi ve geri dönüş tarihi listeye ekleniyor. Ekstra olarak ödünç al yani **Borrower** butonu da disabled oluyor.

Name, AuthorName ve Image dosyası ile birlikte yeni bir kitap ekleyebiliyoruz. Bu işlemleri FluentValidation kütüphanesiyle kontrollerini yapacak şekilde düzenledim. Eklediğimiz kitap resmini **wwwroot/img** klasörü içerisinde kaydedip veritabanında da resimin yolunu kaydederek kullanıcı arayüzünde gösterdim.

Son olarak ödünç alma yani **Borrow** sayfasına girdildiğinde üst tarafta ödünç alınacak kitabın adı geliyor. Form'da da ödünç alacak kişinin bilgisi ve kitabı geri getireceği tarihi giriş yapıp veri tabanına anlık olarak kaydediyoruz.

Uygulamanın ekran görüntüleri: 






