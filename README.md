### Doktor E-Randevu Sistemi
#### Proje Özeti
Bu proje, doktor, hasta ve yönetici (admin) kullanıcılarının yetkilere dayalı olarak yönetilebildiği bir E-Randevu sistemidir. Kullanıcılar, randevu kayıtları oluşturabilir ve yönetebilir. Proje, .NET Core 8.0, Angular ve MSSQL Server kullanılarak geliştirilmiştir.

#### Teknolojiler ve Kullanılan Teknikler
##### Backend:
.NET Core 8.0: Modern ve güçlü bir backend geliştirme platformu.
C#: Projenin ana programlama dili.
Entity Framework: ORM (Object-Relational Mapping) aracı.
JWT (JSON Web Tokens): Kullanıcı kimlik doğrulama ve yetkilendirme.
Clean Architecture: Kod yapısını temiz ve sürdürülebilir tutmak için kullanılan mimari desen.
CQRS (Command Query Responsibility Segregation): Veri sorgulama ve komut işlemlerini ayırma deseni.
Mediator Tasarım Deseni: Bağımsız bileşenler arasında iletişimi sağlamak için kullanılır.
Scrutor: Bağımlılık enjeksiyonu için tarama ve kayıt kütüphanesi.
Ardalis Smart Enum: Daha tip güvenli ve bakımı kolay sabitler için kullanılan kütüphane.
AutoMapper: Nesneler arasında otomatik eşleştirme.

##### Frontend:
Angular: Popüler bir frontend frameworkü.
DevExtreme Scheduler: Takvim ve randevu yönetimi için kullanılan bileşen.
JWT-Decode: JWT işleme kütüphanesi.
Router: Angular yönlendirme modülü.
SweetAlert2: Güzel uyarı mesajları için kullanılan kütüphane.
Bootstrap Modal: Popup modal bileşeni.
JavaScript: Ek fonksiyonlar ve etkileşimler için.
HTML/CSS: Ön yüz tasarımı ve stil.

##### Veritabanı:
SQL Server: Veritabanı yönetim sistemi.

##### Diğer:
Swagger: API dokümantasyonu ve test aracı.
Cors Politikaları: Cross-Origin Resource Sharing politikaları.

#### Proje Detayları:
Proje kapsamında aşağıdaki özellikler ve işlevler geliştirilmiştir:

#### Kullanıcı Yetkilendirme:
Kullanıcılar hasta, doktor ve admin rolleriyle sisteme erişebilir. JWT kullanılarak güvenli kimlik doğrulama sağlanmıştır.
Randevu Yönetimi: DevExtreme Scheduler kullanılarak kullanıcıların takvim üzerinden çift tıklama ile başlangıç ve bitiş tarihleri belirlenerek randevu oluşturabilmeleri sağlanmıştır.
CRUD Operasyonları: Appointment, Doctor, Patient, Admin, AppUser, ve AppUserRole varlıkları için Create, Read, Update, Delete işlemleri CQRS ve Mediator deseni ile yönetilmiştir.
Swagger Entegrasyonu: API uç noktalarının dokümantasyonu ve test edilebilirliği için Swagger kullanılmıştır.
Clean Code ve SOLID Prensipleri: Kodun anlaşılabilir, bakımı kolay ve genişletilebilir olması için bu prensiplere dikkat edilmiştir.
Kullanıcı Rolleri ve İşlevleri
Admin: Kullanıcı ve randevu yönetimi, sistem ayarları.
Doktor: Hasta kayıtları ve randevu yönetimi.
Hasta: Randevu oluşturma ve yönetme.

