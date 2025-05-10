
# 🎓 TP6 - ASP.NET Core Web API + MVC Client

## 🏫 Project Name: SchoolAPI + SchoolWebAppClient  
---

## 📌 Objective

The goal of this lab is to:
- Build a .NET 8 **Web API** to manage engineering schools.
- Create an ASP.NET Core **MVC client** to consume the API.
- Implement full CRUD operations.
- Apply DTOs, AutoMapper, and Repository Pattern (optional).
---

## 🗂️ Folder Structure

TP6-YourName/
├── SchoolAPI/
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── wwwroot/
│   ├── Controllers/
│   │   └── SchoolsController.cs
│   ├── Pages/
│   ├── appsettings.json
│   └── Program.cs
└── SchoolWebAppClient/
    ├── Properties/
    │   └── launchSettings.json
    ├── wwwroot/
    ├── Controllers/
    │   └── SchoolClientController.cs
    ├── Models/
    │   ├── ErrorViewModel.cs
    │   └── SchoolClient.cs
    ├── Views/
    │   ├── Home/
    │   ├── SchoolClient/
    │   │   ├── GetAllSchools.cshtml
    │   │   ├── GetSchoolById.cshtml
    │   │   ├── CreateSchool.cshtml
    │   │   ├── EditSchool.cshtml
    │   │   ├── DeleteSchool.cshtml
    │   │   └── GetSchoolByName.cshtml
    │   └── Shared/
    │       ├── _Layout.cshtml
    │       ├── _ViewImports.cshtml
    │       ├── _ViewStart.cshtml
    │       ├── Error.cshtml
    │       └── ValidationScriptsPartial.cshtml
    ├── appsettings.json
    └── Program.cs

---

## 🌐 API Endpoints (Tested via Swagger)

| Method | Endpoint                                | Description             |
|--------|------------------------------------------|-------------------------|
| GET    | `/api/Schools`                           | Get all schools         |
| GET    | `/api/Schools/{id}`                      | Get school by ID        |
| GET    | `/api/Schools/search-by-name/{keyword}`  | Search school by name   |
| POST   | `/api/Schools`                           | Create new school       |
| PUT    | `/api/Schools/{id}`                      | Edit school by ID       |
| DELETE | `/api/Schools/{id}`                      | Delete school by ID     |

---

## 🧪 API Tests (via Swagger)

✅ Sample tests successfully passed:

- 🔍 Search by Name (partial match):  
  `GET /api/Schools/search-by-name/ENI`

- 🔄 Update school:
  ```json
  PUT /api/Schools/1
  {
    "id": 1,
    "name": "ENISoUUUU",
    "sections": "Info, Meca",
    "director": "Dr. A",
    "rating": 4.5,
    "webSite": "http://www.eniso.rnu.tn"
  }
  ```

- ➕ Create school:
  ```json
  POST /api/Schools
  {
    "name": "ISAMM",
    "sections": "Media, Info",
    "director": "Dr. D",
    "rating": 3.8,
    "webSite": "http://www.isamm.rnu.tn"
  }
  ```

- ❌ Delete school:
  `DELETE /api/Schools/3`

- 📄 Get by ID:
  `GET /api/Schools/1`

---

## 🖥️ MVC Client Features

✅ Implemented using `HttpClient` injection in `SchoolClientController.cs`.

| Action               | View                 | Route                                  |
|----------------------|----------------------|----------------------------------------|
| List Schools         | `GetAllSchools`      | `/SchoolClient/GetAllSchools`         |
| View Details         | `GetSchoolById`      | `/SchoolClient/GetSchoolById/{id}`    |
| Search by Name       | `GetSchoolByName`    | `/SchoolClient/GetSchoolByName?keyword=...` |
| Create School        | `CreateSchool`       | `/SchoolClient/CreateSchool`          |
| Edit School          | `EditSchool`         | `/SchoolClient/EditSchool/{id}`       |
| Delete School        | `DeleteSchool`       | `/SchoolClient/DeleteSchool/{id}`     |

---

## 🧱 Sample Model (Used in Both API & Client)

```csharp
public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sections { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
    public string WebSite { get; set; }
}
```

---

## ⚙️ Setup Instructions

### ✅ Prerequisites:
- Visual Studio 2022+
- .NET SDK 8.0+
- SQL Server (if using EF Core)

### ▶️ Run the Projects

1. Set both **API** and **MVC Client** as startup projects:
   - Right-click solution > Set Startup Projects > Multiple projects > Start both.

2. Run the solution:
   - API will open at `https://localhost:7189`
   - MVC Client will open at `https://localhost:7229`

3. Ensure API base URL in MVC is correct:
```csharp
private readonly string _apiUrl = "https://localhost:7189/api/Schools";
```

---

## 📸 Screenshots

### ✅ Swagger Tests:
![6a](https://github.com/user-attachments/assets/39a417ff-baeb-4afe-9b7e-d892c8cc98b1)
![6b](https://github.com/user-attachments/assets/62bb2368-8e65-4029-a53c-a033514db712)
![6C](https://github.com/user-attachments/assets/55f2b36e-2fc8-4b12-9b05-8bcf42f22a2e)
![6d](https://github.com/user-attachments/assets/e5ffc800-2b55-4632-9f64-f80ac7cdd322)
![6f](https://github.com/user-attachments/assets/ca7313a8-f053-4f68-8f94-41435cab43a5)
![6g](https://github.com/user-attachments/assets/0249233b-f7ea-413e-b770-e08008c1a19f)
![6h](https://github.com/user-attachments/assets/43ad278c-35ed-46b3-99a9-32e49bafe1e2)
![6j](https://github.com/user-attachments/assets/5856032e-778b-40ba-ba42-1f44d217cdcc)

### ✅ MVC App Output:
- Empty table if no data returned
- Table with correct fields (`Id`, `Name`, `Sections`, etc.)

---

## 📤 Submission

Push to GitHub:
```bash
git init
git add .
git commit -m "TP6 Complete - API + MVC Client"
git remote add origin https://github.com/YOUR_USERNAME/tp6-school-app.git
git push -u origin main
