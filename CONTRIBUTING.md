# 🤝 Katkıda Bulunma Rehberi

RescueSphere API'ye katkıda bulunmayı düşündüğünüz için teşekkür ederiz! Bu rehber, projeye nasıl katkıda bulunabileceğinizi açıklar.

## 🚀 Başlamadan Önce

1. Projeyi fork'layın
2. Değişikliklerinizi yeni bir branch'te yapın
3. Pull Request açın

## 📋 Katkı Türleri

### 🐛 Bug Raporları
- Issue açmadan önce mevcut issue'ları kontrol edin
- Sorunu yeniden oluşturma adımlarını detaylı yazın
- Beklenen ve gerçekleşen davranışı açıklayın
- Ekran görüntüsü veya log ekleyin

### ✨ Yeni Özellik Önerileri
- Özelliğin neden gerekli olduğunu açıklayın
- Kullanım senaryoları ekleyin
- Varsa alternatif çözümlerden bahsedin

### 📝 Dokümantasyon İyileştirmeleri
- Yazım hatalarını düzeltin
- Eksik açıklamaları tamamlayın
- Örnekler ekleyin

## 🛠️ Geliştirme Ortamı Kurulumu

```bash
# 1. Repository'i fork'layın ve klonlayın
git clone https://github.com/YOUR_USERNAME/rescue-sphere.git
cd rescue-sphere/Rescue-Sphere

# 2. Yeni bir branch oluşturun
git checkout -b feature/amazing-feature

# 3. Bağımlılıkları yükleyin
dotnet restore

# 4. Projeyi çalıştırın
dotnet run
```

## 📐 Kod Standartları

### Naming Conventions
- **Classes/Interfaces:** PascalCase (örn: `UserService`, `IUserRepository`)
- **Methods:** PascalCase (örn: `GetUserById()`)
- **Variables:** camelCase (örn: `userId`, `userName`)
- **Private Fields:** _camelCase (örn: `_dbContext`)

### Best Practices
- SOLID prensiplerine uyun
- Her method tek bir sorumluluğa sahip olmalı
- Exception'ları uygun şekilde handle edin
- Async/await kullanımına dikkat edin
- XML documentation yorumları ekleyin

### Örnek Kod
```csharp
/// <summary>
/// Kullanıcıyı ID'ye göre getirir
/// </summary>
/// <param name="id">Kullanıcı ID'si</param>
/// <returns>Kullanıcı bilgileri veya null</returns>
public async Task<UserResponseDto?> GetUserByIdAsync(int id)
{
    var user = await _dbContext.Users
        .Where(u => !u.IsDeleted && u.Id == id)
        .FirstOrDefaultAsync();
    
    if (user == null)
        throw new ApiException(404, "User not found");
    
    return _mapper.Map<UserResponseDto>(user);
}
```

## 🧪 Test

Yeni özellikler eklerken:
- Unit testler yazın (gelecekte eklenecek)
- Swagger UI'dan manuel test yapın
- Tüm endpoint'leri test edin

```bash
# Testleri çalıştır (gelecekte)
dotnet test
```

## 📤 Pull Request Süreci

1. **Branch Naming:**
   - `feature/new-feature` - Yeni özellik
   - `bugfix/fix-something` - Bug düzeltme
   - `docs/update-readme` - Dokümantasyon

2. **Commit Messages:**
   ```
   feat: Add JWT authentication
   fix: Resolve user deletion bug
   docs: Update API documentation
   refactor: Improve service layer structure
   ```

3. **PR Açarken:**
   - Açıklayıcı başlık yazın
   - Yapılan değişiklikleri detaylı açıklayın
   - İlgili issue'ları etiketleyin (#123)
   - Ekran görüntüsü ekleyin (UI değişiklikleri için)

4. **PR Checklist:**
   - [ ] Kod standartlarına uygun
   - [ ] Tüm testler geçiyor
   - [ ] README güncel
   - [ ] Yeni endpoint'ler Swagger'a eklendi
   - [ ] Migration'lar oluşturuldu (DB değişiklikleri için)

## 🔄 Review Süreci

- PR'ınız en az 1 review alacak
- Geri bildirimler doğrultusunda düzenlemeler yapın
- Onay aldıktan sonra merge edilecek

## 📝 Dokümantasyon

Yeni özellik eklerken:
- README'yi güncelleyin
- API endpoint'lerini dokümante edin
- Swagger açıklamaları ekleyin
- Örnek request/response ekleyin

## 🚫 Yapılmaması Gerekenler

- Hassas bilgileri (şifreler, API keys) commit'lemeyin
- `bin/`, `obj/`, `.db` dosyalarını commit'lemeyin
- Büyük refactoring'leri tek PR'da yapmayın
- Breaking changes yapmadan önce tartışma açın

## 💬 İletişim

Sorularınız için:
- Issue açın
- Discussion başlatın
- Email: [email@example.com]

## 📜 Lisans

Katkılarınız MIT lisansı altında yayınlanacaktır.

---

**Teşekkürler! 🙏**

Her katkı projeyi daha iyi hale getirir. Desteğiniz için teşekkür ederiz!
