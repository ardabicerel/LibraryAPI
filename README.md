# Library API (KutuphaneAPI)

🌍 *[Türkçe sürüm için aşağı kaydırın / Scroll down for Turkish version](#turkce)*

A simple RESTful Web API built with .NET 10 and C# to manage a library system. This project performs basic CRUD (Create, Read, Update, Delete) operations using a SQLite database.

## Technologies
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger UI

## Features
* List all books
* Add a new book
* Update an existing book's details
* Delete a book

## API Endpoints

| HTTP Method | Endpoint | Description |
| :--- | :--- | :--- |
| **GET** | `/api/kitaplar` | Returns a list of all books. |
| **POST** | `/api/kitaplar` | Creates a new book. |
| **PUT** | `/api/kitaplar/{id}` | Updates an existing book by its ID. |
| **DELETE** | `/api/kitaplar/{id}` | Deletes a book by its ID. |

## How to Run

1. Clone the repository to your local machine:
   ```bash
   git clone <your-repository-url>
   ```
2. Navigate to the project directory:
   ```bash
   cd LibraryAPI
    ```
3. Update the database (creates the SQLite file):
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Open your browser and navigate to the Swagger UI to test the endpoints:
   ```bash
   http://localhost:<port>/swagger
   ```

<a id="turkce"></a>
# Kütüphane API (KutuphaneAPI)

Kütüphane sistemini yönetmek için .NET 10 ve C# ile geliştirilmiş basit bir RESTful Web API projesi. Bu proje, SQLite veritabanı kullanarak temel CRUD (Oluşturma, Okuma, Güncelleme, Silme) işlemlerini gerçekleştirir.

## Teknolojiler
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger UI

## Özellikler
* Tüm kitapları listeleme
* Yeni kitap ekleme
* Mevcut bir kitabın bilgilerini güncelleme
* Kitap silme

## API Uç Noktaları (Endpoints)

| HTTP Metodu | Uç Nokta | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/kitaplar` | Tüm kitapların listesini döndürür. |
| **POST** | `/api/kitaplar` | Yeni bir kitap oluşturur. |
| **PUT** | `/api/kitaplar/{id}` | ID'si belirtilen kitabı günceller. |
| **DELETE** | `/api/kitaplar/{id}` | ID'si belirtilen kitabı siler. |

## Nasıl Çalıştırılır

1. Depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone <depo-url-adresiniz>
   ```
2. Proje dizinine gidin:
   ```bash
   cd KutuphaneAPI
   ```
3. Veritabanını güncelleyerek SQLite dosyasını oluşturun:
   ```bash
   dotnet ef database update
   ```
4. Uygulamayı başlatın:
   ```bash
   dotnet run
   ```
5. Uç noktaları test etmek için tarayıcınızı açın ve Swagger arayüzüne gidin:
   ```bash
   http://localhost:<port>/swagger
   ```
