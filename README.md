<div align="center">

# 🌐 Plog — Full-Stack Blogging Platform

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Angular](https://img.shields.io/badge/Angular-16-DD0031?logo=angular&logoColor=white)](https://angular.io/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![AutoMapper](https://img.shields.io/badge/AutoMapper-13-FF6C37?logo=automapper&logoColor=white)](https://automapper.org/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208-68217A?logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](#-license)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](#-contributing)

💖 A full-stack blog management platform — crafted with ASP.NET Core + Angular.

</div>

---

## 🚀 Overview

Plog is a full-stack blogging platform built with ASP.NET Core 8 Web API on the backend and Angular 16 on the frontend. It allows users (or admins) to create, edit, categorize, and manage blog posts — all with a modern UI and scalable backend.

This repository contains the Angular UI at `UI/Plog`. If your backend API lives in a sibling folder named `Api`, the instructions below will work end-to-end.

---

## 🧱 Architecture

```
Plog
├─ Api/                 → ASP.NET Core Backend
│  ├─ Controllers/      → API endpoints
│  ├─ Models/           → Domain Models + DTOs
│  ├─ Repositories/     → Data Access Layer (EF Core)
│  ├─ Mappings/         → AutoMapper Profiles
│  ├─ appsettings.json  → Configuration (DB, CORS, etc.)
│  └─ Program.cs        → API Entry Point
│
└─ UI/Plog/             → Angular Frontend
   ├─ src/
   │  └─ app/features/
   │      ├─ blog-post/
   │      └─ category/
   ├─ angular.json
   └─ package.json
```

---

## 🧰 Tech Stack

### 🖥 Backend

- .NET 8 Web API
- Entity Framework Core 8
- SQL Server
- AutoMapper
- Repository Pattern 
- Swagger / OpenAPI for API testing
- CORS for frontend integration

### 💻 Frontend

- Angular 16
- TypeScript
- RxJS
- Bootstrap
- Angular Router
- Environment configuration for API endpoints

---

## 🛠 Getting Started (Full Stack)

### 1️⃣ Clone the repo

```bash
git clone https://github.com/MahmoodElbadri/Plog.git
cd Plog
```

### 2️⃣ Run the Backend

If your API is present at `Api/` next to `UI/`, follow these steps:

1. Go to the API folder:

   ```bash
   cd Api
   ```
2. Configure the connection string in `appsettings.json`.
3. Apply migrations (if using EF Core):

   ```bash
   dotnet ef database update
   ```
4. Run the API:

   ```bash
   dotnet run
   ```

   → The API will start at `https://localhost:7091`

> Note: If the API project is in a different location, adjust the paths accordingly.

### 3️⃣ Run the Frontend

From the repo root (or after starting the API), run the UI:

```bash
cd UI/Plog
npm install
ng serve
```

Then visit: http://localhost:4200

✅ The UI will communicate directly with the API through configured environment URLs.

---

## 🧩 Core Features

- 📝 Blog Post Management
  - Add, edit, delete, and view posts
  - Manage post visibility and publish date
- 🗂️ Category Management
  - Add or edit categories used by blog posts
- ⚙️ RESTful API
  - JSON-based communication between backend and frontend
- 🔄 AutoMapper Integration
  - Maps between domain models and DTOs seamlessly
- 💾 SQL Server Database
  - Persistent storage for blog posts and categories
- 🧭 Angular SPA
  - Responsive, component-driven interface with routing

---

## ⚙️ Environment Variables

### Backend (`Api/appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YourConnectionString"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### Frontend (`UI/Plog/src/environments/environment.ts`)

```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'https://localhost:7091/api'
};
```

---

## 🧠 Design Philosophy

- Dependency Injection: Every service follows interface-based dependency injection.
- Separation of Concerns: DTOs handle API contracts; domain models represent entities.

---

## 🧩 Example API Endpoints

| HTTP   | Endpoint              | Description          |
| ------ | --------------------- | -------------------- |
| GET    | `/api/BlogPosts`      | Get all blog posts   |
| GET    | `/api/BlogPosts/{id}` | Get blog post by ID  |
| POST   | `/api/BlogPosts`      | Create new blog post |
| PUT    | `/api/BlogPosts/{id}` | Update a blog post   |
| DELETE | `/api/BlogPosts/{id}` | Delete a blog post   |
| GET    | `/api/Categories`     | Get all categories   |

---

## 🧩 Tips

- Use Swagger at `/swagger` to explore API routes.
- Make sure your database is migrated before running.
- Use Angular environment.ts for different API base URLs (dev/prod).

---

## 🤝 Contributing

1. Fork the repo 🍴
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to your branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request 🚀

---

## 📜 License

This project is licensed under the MIT License — see LICENSE for details.

---

<div align="center">
Made with ❤️ by Mahmoud Salah Elbadri (Badri)
<br/>
<sub>Backend & Frontend Developer — turning caffeine into clean code ☕.</sub>
</div>
