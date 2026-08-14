
# 🚑 RescueSphere API

<div align="center">

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-9.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

</div>

> **Afet yönetimi süreçlerini dijitalleştiren, ölçeklenebilir ve güvenli bir backend çözümü.**

**RescueSphere**, afet ve acil durumlarda yardım taleplerini ve gönüllü atamalarını yönetmek için geliştirilmiş, yüksek performanslı bir **.NET 9 RESTful API** çözümüdür. Vatandaşlar yardım talepleri oluşturabilir, gönüllüler akıllı eşleştirme algoritması ile bu taleplere atanabilir ve tüm süreç merkezi bir sistem üzerinden takip edilebilir.

---

## 📑 İçindekiler

- [🎯 Proje Hedefi](#-proje-hedefi)
- [🛠 Öne Çıkan Teknik Özellikler](#-öne-çıkan-teknik-özellikler)
- [🏗 Mimari Katmanlar](#-mimari-katmanlar)
- [📊 Entity İlişki Diyagramı](#-entity-i̇lişki-diyagramı)
- [🌐 API Endpoints](#-api-endpoints)
- [📦 API Response Formatı](#-api-response-formatı)
- [🚀 Kurulum ve Çalıştırma](#-kurulum-ve-çalıştırma)
- [🎬 Hızlı Başlangıç Senaryosu](#-hızlı-başlangıç-senaryosu)
- [💻 Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [✨ Öne Çıkan Yazılım Prensipleri](#-öne-çıkan-yazılım-prensipleri)
- [📚 Özellik Detayları](#-özellik-detayları)
- [🛡 Güvenlik Özellikleri](#-güvenlik-özellikleri)
- [🔮 Gelecek Geliştirmeler](#-gelecek-geliştirmeler-roadmap)
- [👨‍💻 Geliştirici](#-geliştirici)

---

## 🎯 Proje Hedefi

Afet anlarında koordinasyonu sağlamak, yardım taleplerini hızlı ve etkin bir şekilde gönüllülere ulaştırmak için **Clean Architecture** prensiplerine uygun, **ölçeklenebilir** ve **sürdürülebilir** bir API geliştirmek.

---

## Öne Çıkan Teknik Özellikler

| Özellik | Açıklama |
|---------|----------|
| **🔒 Global Hata Yönetimi** | Tüm API yanıtları için standartlaştırılmış JSON çıktıları ve merkezi exception handling |
| **♻️ Soft Delete** | Verilerin fiziksel olarak silinmeden işaretlenmesi, veri bütünlüğünün korunması |
| **🎯 Akıllı Gönüllü Yönetimi** | Yardım talepleri ve gönüllüler arasında otomatik eşleştirme mantığı |
| **📝 Seed Data** | Proje ilk çalıştırıldığında otomatik test verileri ile hazır kullanım |
| **📚 İnteraktif Dokümantasyon** | Swagger UI ile entegre, tarayıcıdan doğrudan test edilebilir API |
| **🔐 Güvenli Kimlik Doğrulama** | BCrypt ile şifrelenmiş kullanıcı yönetimi |
| **🏗 Katmanlı Mimari** | Clean Architecture prensiplerine uygun ayrıştırılmış yapı |

---

## 🏗 Mimari Katmanlar

Proje, **sürdürülebilirlik** ve **test edilebilirlik** için katmanlı bir yapıya sahiptir:

| Katman | Sorumluluk |
|--------|------------|
| **Controllers** | HTTP isteklerinin karşılanması ve endpoint tanımlamaları (Minimal API) |
| **Services** | İş mantığının (Business Logic) yürütüldüğü katman |
| **DTOs** | Veri transfer nesneleri ile model güvenliği ve validasyon |
| **Domain** | Entity tanımları ve domain modelleri |
| **Data** | Database context, konfigürasyonlar ve seed data |
| **Common** | Global middleware, exception handling ve paylaşılan yapılar |

### Proje Klasör Yapısı

```
rescuesphere/
├── Common/                    # Paylaşılan yapılar ve middleware
│   ├── ApiResponse.cs        # Standart API response modeli
│   ├── Exceptions/           # Custom exception sınıfları
│   └── Middleware/           # Global exception handler
├── Controllers/              # Minimal API endpoint tanımlamaları
│   ├── Users/
│   ├── Categories/
│   ├── HelpRequests/
│   └── VolunteerAssignments/
├── Domain/                   # Domain entities ve business models
│   └── Entities/
├── DTOs/                     # Data Transfer Objects
├── Services/                 # Business logic katmanı
│   ├── Interfaces/
│   └── Implementations/
├── Data/                     # Database context ve seed data
│   ├── AppDbContext.cs
│   ├── Configurations/       # Entity configurations
│   └── Seed/                 # Otomatik test verileri
└── Program.cs                # Uygulama entry point
```

---

## 📊 Entity İlişki Diyagramı

Veritabanı ilişkileri ve kardinalite:

```
┌─────────────────┐
│      User       │
│─────────────────│
│ • id            │
│ • username      │
│ • email         │
│ • passwordHash  │
│ • role          │
└────────┬────────┘
         │ 1:N (creator)
         │
         ▼
┌─────────────────────────┐       ┌──────────────────────┐
│   SupportCategory       │ 1:N   │    HelpRequest       │
│─────────────────────────│◄──────│──────────────────────│
│ • id                    │       │ • id                 │
│ • name                  │       │ • userId (creator)   │
│ • description           │       │ • categoryId         │
└─────────────────────────┘       │ • title              │
                                  │ • description        │
                                  │ • urgencyLevel       │
                                  │ • status             │
                                  └──────────┬───────────┘
                                             │ 1:1
                                             ▼
                        ┌────────────────────────────────────┐
                        │    VolunteerAssignment             │
                        │────────────────────────────────────│
                        │ • id                               │
                        │ • requestId (FK)                   │
                        │ • volunteerId (FK -> User)         │
                        │ • assignmentStatus                 │
                        │ • assignedAt                       │
                        └────────────────────────────────────┘
```

**İlişki Özeti:**
- Bir **User** birden fazla **HelpRequest** oluşturabilir *(1:N)*
- Bir **SupportCategory** birden fazla **HelpRequest** içerir *(1:N)*
- Bir **HelpRequest** sadece bir **VolunteerAssignment** alabilir *(1:1)*
- Bir **User** (gönüllü olarak) birden fazla **VolunteerAssignment**'a atanabilir *(1:N)*

---

## 🌐 API Endpoints

### 👤 Users
| Method | Endpoint | Açıklama | Response |
|--------|----------|----------|----------|
| POST | `/users` | Yeni kullanıcı oluştur | `201 Created` |
| GET | `/users` | Tüm kullanıcıları listele | `200 OK` |
| GET | `/users/{id}` | ID ile kullanıcı getir | `200 OK` / `404 Not Found` |
| PUT | `/users/{id}` | Kullanıcı güncelle | `200 OK` / `404 Not Found` |
| DELETE | `/users/{id}` | Kullanıcı sil (soft delete) | `200 OK` / `404 Not Found` |

### 📂 Categories
| Method | Endpoint | Açıklama | Response |
|--------|----------|----------|----------|
| POST | `/categories` | Yeni kategori oluştur | `201 Created` |
| GET | `/categories` | Tüm kategorileri listele | `200 OK` |
| GET | `/categories/{id}` | ID ile kategori getir | `200 OK` / `404 Not Found` |
| PUT | `/categories/{id}` | Kategori güncelle | `200 OK` / `404 Not Found` |
| DELETE | `/categories/{id}` | Kategori sil (soft delete) | `200 OK` / `404 Not Found` |

### 🆘 Help Requests
| Method | Endpoint | Açıklama | Response |
|--------|----------|----------|----------|
| POST | `/help-requests` | Yeni yardım talebi oluştur | `201 Created` |
| GET | `/help-requests` | Tüm yardım taleplerini listele | `200 OK` |
| GET | `/help-requests/{id}` | ID ile yardım talebi getir | `200 OK` / `404 Not Found` |
| PUT | `/help-requests/{id}` | Yardım talebi güncelle | `200 OK` / `404 Not Found` |
| DELETE | `/help-requests/{id}` | Yardım talebi sil (soft delete) | `200 OK` / `404 Not Found` |

### 🤝 Volunteer Assignments
| Method | Endpoint | Açıklama | Response |
|--------|----------|----------|----------|
| POST | `/volunteer-assignments` | Gönüllü ata | `201 Created` |
| GET | `/volunteer-assignments` | Tüm atamaları listele | `200 OK` |
| GET | `/volunteer-assignments/{id}` | ID ile atama getir | `200 OK` / `404 Not Found` |

---

## 📦 API Response Formatı

Tüm API yanıtları standart bir formatta döner. Bu sayede frontend geliştiriciler tutarlı bir yapı ile çalışır.

### ✅ Başarılı Response (Success)
```json
{
  "success": true,
  "message": "User created successfully",
  "data": {
    "id": 1,
    "username": "sude",
    "email": "sude@example.com",
    "role": "Vatandas",
    "createdAt": "2026-01-10T19:00:00Z"
  }
}
```

### ❌ Hata Response (404 Not Found)
```json
{
  "statusCode": 404,
  "message": "User not found",
  "timestamp": "2026-01-10T19:05:00Z"
}
```

### ⚠️ Hata Response (500 Internal Server Error)
```json
{
  "statusCode": 500,
  "message": "Internal server error",
  "timestamp": "2026-01-10T19:10:00Z"
}
```

> **Not:** Global Exception Middleware sayesinde tüm hatalar merkezi olarak yönetilir ve kullanıcıya anlaşılır mesajlar döndürülür.

---

## 🚀 Kurulum ve Çalıştırma

### 📋 Gereksinimler
- **.NET 9.0 SDK** veya üzeri
- **SQLite** (otomatik oluşturulur, ayrı kurulum gerektirmez)
- **Git** (projeyi klonlamak için)

### 📥 Adım Adım Kurulum

```bash
# 1. Repository'i klonla
git clone https://github.com/username/rescue-sphere.git
cd rescue-sphere/Rescue-Sphere

# 2. Bağımlılıkları yükle
dotnet restore

# 3. Veritabanını oluştur ve seed data'yı yükle (otomatik)
dotnet build

# 4. Uygulamayı çalıştır
dotnet run

# 5. Tarayıcıda Swagger UI'ı aç
# http://localhost:5133/swagger
```

> **İpucu:** Proje ilk çalıştırıldığında otomatik olarak:
> - `rescueSphere.db` veritabanı dosyası oluşturulur
> - Örnek kategoriler, kullanıcılar ve yardım talepleri yüklenir
> - Swagger UI'a yönlendirme yapılır

### 🔧 Alternatif Komutlar

```bash
# Veritabanını sıfırla (development)
dotnet ef database drop --force
dotnet run

# Migration oluştur (yeni değişiklikler için)
dotnet ef migrations add YourMigrationName

# Testleri çalıştır (gelecekte eklenecek)
dotnet test
```

---

## 🎬 Hızlı Başlangıç Senaryosu

Swagger UI üzerinden API'yi denemek için örnek kullanım senaryosu:

### Senaryo: Afet Bölgesinden Yardım Talebi ve Gönüllü Ataması

**1️⃣ Mevcut kategorileri listele**
```http
GET /categories
```
Response: Gıda, Barınma, Sağlık, Ulaşım kategorileri döner.

**2️⃣ Yeni bir yardım talebi oluştur**
```http
POST /help-requests
Content-Type: application/json

{
  "userId": 3,
  "categoryId": 1,
  "title": "Acil gıda yardımı",
  "description": "Deprem bölgesinde 50 kişilik aile için acil gıda desteği gerekiyor",
  "urgencyLevel": "Yüksek"
}
```
Response: Yeni talep oluşturulur ve ID döner.

**3️⃣ Talebi bir gönüllüye ata**
```http
POST /volunteer-assignments
Content-Type: application/json

{
  "requestId": 1,
  "volunteerId": 2
}
```
Response: Gönüllü atama kaydı oluşturulur.

**4️⃣ Gönüllü atamalarını listele**
```http
GET /volunteer-assignments
```
Response: Tüm aktif atamalar ve detayları döner.

> **💡 Bonus:** Swagger UI üzerinden "Try it out" butonuna tıklayarak bu senaryoyu interaktif olarak deneyebilirsiniz!

---

## 💻 Kullanılan Teknolojiler

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| **.NET** | 9.0 | Framework ve runtime |
| **Entity Framework Core** | 9.x | ORM ve database yönetimi |
| **SQLite** | - | Hafif, dosya tabanlı veritabanı |
| **Swagger/OpenAPI** | - | API dokümantasyonu ve test arayüzü |
| **BCrypt.Net** | - | Güvenli şifre hashleme |
| **Minimal API** | - | Performanslı ve modern endpoint tanımlamaları |

---

## ✨ Öne Çıkan Yazılım Prensipleri

Bu proje aşağıdaki **best practices** ve **design patterns** kullanılarak geliştirilmiştir:

### 1️⃣ **Clean Architecture**
- Katmanlar arası bağımlılık yönetimi
- Domain-driven design prensipleri
- Separation of Concerns (SoC)

### 2️⃣ **SOLID Principles**
- **Single Responsibility:** Her service tek bir sorumluluğa sahip
- **Dependency Injection:** Constructor-based DI kullanımı
- **Interface Segregation:** Service interface'leri ile loose coupling

### 3️⃣ **Repository Pattern**
- Entity Framework ile implicit repository
- DbContext üzerinden generic operasyonlar

### 4️⃣ **Global Exception Handling**
- Merkezi hata yönetimi middleware'i
- Standardize edilmiş hata response'ları
- Logging altyapısı için hazır

### 5️⃣ **Data Integrity**
- Soft delete ile veri korunması
- Foreign key constraints
- Migration-based schema yönetimi

---

## 📚 Özellik Detayları

### 🔒 Global Exception Middleware
[GlobalExceptionMiddleware.cs](Common/Middleware/GlobalExceptionMiddleware.cs) dosyasında tüm hatalar yakalanır ve standart formata dönüştürülür.

### ♻️ Soft Delete Mekanizması
Tüm entity'ler `BaseEntity` sınıfından türer ve `IsDeleted` property'sine sahiptir. Silme işlemleri fiziksel değil, mantıksaldır:

```csharp
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
```

### 📝 Seed Data
Proje ilk çalıştırıldığında otomatik olarak:
- 5 adet örnek kullanıcı
- 4 adet destek kategorisi
- 3 adet örnek yardım talebi
- 2 adet gönüllü ataması yüklenir

---

## 🛡 Güvenlik Özellikleri

- **Şifre Hashleme:** BCrypt algoritması ile güvenli şifre saklama
- **Soft Delete:** Veri kaybını önleme
- **Validasyon:** DTO katmanında veri doğrulama (gelecekte eklenecek)
- **SQL Injection Koruması:** EF Core parametrize sorguları

---


## 📸 Proje Görselleri

### Swagger UI
Proje çalıştırıldığında [http://localhost:5133/swagger](http://localhost:5133/swagger) adresinden tüm endpoint'leri test edebilirsiniz:

```
🌐 Root (/) → Otomatik Swagger'a yönlendirme
📚 /swagger → İnteraktif API dokümantasyonu
✅ Test verisi ile hazır kullanım
```

---

## Notlar

### 🔐 Güvenlik ve Best Practices
- **Connection String:** `appsettings.json` içinde tanımlı, SQLite kullanımı nedeniyle hassas bilgi içermiyor
- **Swagger:** Sadece Development ortamında aktif, Production'da kapalı
- **Environment Aware:** Ortam bazlı konfigürasyon desteği
- **Seed Data:** Otomatik test verileri ile hızlı başlangıç

### 🗄️ Veritabanı
- SQLite kullanımı nedeniyle ayrı bir DB kurulumu gerektirmez
- `rescueSphere.db` dosyası `.gitignore` ile versiyon kontrolü dışında tutulur
- Migration'lar Entity Framework Core Code First yaklaşımı ile yönetilir

### 📦 Dependency Management
Tüm bağımlılıklar `.csproj` dosyasında tanımlıdır:
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Swashbuckle.AspNetCore
- BCrypt.Net-Next

---


## 🙏 Teşekkürler

Bu projeyi incelediğiniz için teşekkür ederim! Sorularınız veya önerileriniz için issue açabilir veya pull request gönderebilirsiniz.

---

<div align="center">

```
╔══════════════════════════════════════════════════════════╗
║                                                          ║
║     ██████╗ ███████╗███████╗ ██████╗██╗   ██╗███████╗   ║
║     ██╔══██╗██╔════╝██╔════╝██╔════╝██║   ██║██╔════╝   ║
║     ██████╔╝█████╗  ███████╗██║     ██║   ██║█████╗     ║
║     ██╔══██╗██╔══╝  ╚════██║██║     ██║   ██║██╔══╝     ║
║     ██║  ██║███████╗███████║╚██████╗╚██████╔╝███████╗   ║
║     ╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝   ║
║                                                          ║
║              🚑 SPHERE - Disaster Relief API             ║
║                                                          ║
╚══════════════════════════════════════════════════════════╝
```

**⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!**

Made with ❤️ and .NET 9


</div>
