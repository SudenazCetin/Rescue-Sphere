# 🚑 RescueSphere API - Portfolyo Özeti

## Proje Adı
**RescueSphere - Afet Yönetimi RESTful API**

## Teknoloji Stack'i
- **Backend Framework:** .NET 9.0
- **Programlama Dili:** C# 12.0
- **ORM:** Entity Framework Core 9.x
- **Veritabanı:** SQLite
- **API Dokümantasyonu:** Swagger/OpenAPI
- **Güvenlik:** BCrypt.Net (Password Hashing)

## Proje Kapsamı
Afet ve acil durumlarda yardım taleplerini dijitalleştiren, gönüllü yönetimi yapan ölçeklenebilir bir RESTful API çözümü.

## Temel Özellikler
✅ 4 ana modül (Users, Categories, Help Requests, Volunteer Assignments)
✅ 15+ RESTful API endpoint
✅ Global Exception Handling (Merkezi hata yönetimi)
✅ Soft Delete mekanizması
✅ Otomatik Migration ve Seed Data
✅ Swagger UI ile interaktif API test
✅ Clean Architecture yapısı

## Kullanılan Yazılım Prensipleri
1. **Clean Architecture** - Katmanlı mimari ve bağımlılık yönetimi
2. **SOLID Principles** - Single Responsibility, DI, Interface Segregation
3. **Repository Pattern** - EF Core ile implicit repository
4. **Global Exception Handling** - Middleware ile merkezi hata yönetimi
5. **Data Integrity** - Soft delete, FK constraints, migration-based schema

## Mimari Katmanlar
```
Controllers (Endpoints)
    ↓
Services (Business Logic)
    ↓
Data (Repository & DbContext)
    ↓
Domain (Entities)
```

## API Endpoint Sayıları
- **Users:** 5 endpoint (CRUD + List)
- **Categories:** 5 endpoint (CRUD + List)
- **Help Requests:** 5 endpoint (CRUD + List)
- **Volunteer Assignments:** 3 endpoint (Create, Read, List)

**Toplam:** 18 endpoint

## Veritabanı İlişkileri
- **1:N** - User → HelpRequest (Bir kullanıcı birden fazla talep oluşturabilir)
- **1:N** - SupportCategory → HelpRequest (Bir kategori birden fazla talep içerir)
- **1:1** - HelpRequest → VolunteerAssignment (Her talep bir atamaya sahip)
- **1:N** - User (Volunteer) → VolunteerAssignment (Bir gönüllü birden fazla atamada bulunabilir)

## Güvenlik Özellikleri
- BCrypt ile şifrelenmiş password storage
- Soft Delete ile veri kaybı önleme
- EF Core ile SQL Injection koruması
- Environment-aware configuration (Dev/Prod ayırımı)

## Seed Data
Proje ilk çalıştırıldığında otomatik olarak test verileri yüklenir:
- 5 örnek kullanıcı (Admin, Gönüllüler, Vatandaşlar)
- 4 destek kategorisi (Gıda, Barınma, Sağlık, Ulaşım)
- 3 örnek yardım talebi
- 2 gönüllü ataması

## Kod Kalitesi
✅ Tutarlı namespace kullanımı
✅ .gitignore ile hassas dosya koruması
✅ Connection string appsettings.json'da
✅ Swagger sadece Development'ta aktif
✅ Global exception middleware
✅ DTO pattern ile model güvenliği

## Kurulum Kolaylığı
```bash
git clone [repo]
cd Rescue-Sphere
dotnet restore
dotnet run
# Otomatik: DB oluşturulur, seed data yüklenir, Swagger açılır
```

## Demo & Test
- **Swagger UI:** http://localhost:5133/swagger
- **Interaktif API Testi:** Tarayıcıdan doğrudan test edilebilir
- **Hazır Senaryo:** README'de örnek kullanım senaryosu mevcut

## Gelecek Geliştirmeler (Roadmap)
- [ ] JWT Authentication & Authorization
- [ ] FluentValidation entegrasyonu
- [ ] Serilog ile logging
- [ ] Unit & Integration testleri
- [ ] Pagination, Filtering, Sorting
- [ ] Docker containerization
- [ ] CI/CD pipeline (GitHub Actions)

## Portfolyo Değeri
Bu proje şunları gösterir:
1. **Modern .NET bilgisi** - En güncel .NET 9 kullanımı
2. **API Design** - RESTful standartlara uygun tasarım
3. **Clean Code** - SOLID ve Clean Architecture prensipleri
4. **Database Design** - EF Core, migration, ilişkisel tasarım
5. **Security Awareness** - BCrypt, soft delete, configuration management
6. **Documentation** - Swagger, detaylı README, kod yorumları
7. **Best Practices** - Error handling, DTO pattern, dependency injection

## İletişim
**Geliştirici:** Sude
**GitHub:** [github.com/username]
**Proje Linki:** [github.com/username/rescue-sphere]

---

**🎯 Öne Çıkan Nokta:** Bu proje, gerçek dünya problemine (afet yönetimi) yazılım mühendisliği prensipleri ile yaklaşan, ölçeklenebilir ve sürdürülebilir bir çözüm sunar.
