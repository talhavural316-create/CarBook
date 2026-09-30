# 🚗 CarBook - Kurumsal Araç Kiralama & Yönetim Platformu

CarBook; modern yazılım mimarileri, kurumsal desenler ve güncel .NET teknolojileri kullanılarak geliştirilmiş kapsamlı bir araç kiralama ve filo yönetim sistemidir. Proje; sürdürülebilir, test edilebilir ve gevşek bağlı (loosely coupled) bir mimari sunmak amacıyla **Onion Architecture** prensiplerine göre katmanlandırılmıştır.

---

## 🏛️ Mimari ve Tasarım Desenleri

* **Onion Architecture (Soğan Mimarisi):** Çekirdek iş mantığını dış bağımlılıklardan izole eden katmanlı yapı (`Core`, `Infrastructure`, `Presentation`).
* **CQRS Pattern (Command Query Responsibility Segregation):** Veri okuma (Query) ve veri yazma/güncelleme (Command) işlemlerinin ayrılması.
* **MediatR (Mediator Pattern):** Katmanlar arası doğrudan bağımlılıkları ortadan kaldırarak iş isteklerini handler sınıfları üzerinden merkezi olarak yönetme.
* **Repository & Unit of Work:** Veri tabanı erişim mantığının soyutlanması ve veri bütünlüğü yönetimi.

---

## 🛠️ Kullanılan Teknolojiler & Kütüphaneler

* **Backend:** C#, .NET 8.0, ASP.NET Core Web API
* **Frontend / UI:** ASP.NET Core MVC (WebUI), Razor, Bootstrap, CSS3, JavaScript
* **ORM & Veritabanı:** Entity Framework Core, Microsoft SQL Server, LINQ
* **Haberleşme & Entegrasyon:** RESTful API mimarisi, `IHttpClientFactory` ile API tüketimi
* **Görsel / Yardımcı:** SweetAlert2, dinamik dashboard metrikleri

---

## 📂 Çözüm / Proje Yapısı

```text
CarBook/
├── Core/
│   ├── CarBook.Application/      # CQRS Komutları, Sorguları, Handler sınıfları, DTO'lar, Arayüzler
│   └── CarBook.Domain/           # Entity modelleri, kurumsal iş nesneleri
├── Infrastructure/
│   └── CarBook.Persistence/      # DbContext, Migrations, Repository implementasyonları
└── Presentation/
    ├── CarBook.WebApi/           # RESTful API Controller katmanı
    └── Frontends/
        └── CarBook.WebUI/        # Kullanıcı arayüzü ve yönetim paneli MVC katmanı
