<div align="center">

# ✨ Plog — Your Personal Blogging UI

[![Angular](https://img.shields.io/badge/Angular-16-DD0031?logo=angular&logoColor=white)](https://angular.io/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5-3178C6?logo=typescript&logoColor=white)](https://www.typescriptlang.org/)
[![RxJS](https://img.shields.io/badge/RxJS-7-B7178C?logo=reactivex&logoColor=white)](https://rxjs.dev/)
[![Node](https://img.shields.io/badge/Node.js-18-339933?logo=node.js&logoColor=white)](https://nodejs.org/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](#-license)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](#-contributing)

💖 Crafted with care to make writing and managing posts a joy.

</div>

---

## 🌟 Overview
Plog is an Angular-based UI for creating, editing, and exploring blog posts. It integrates with a backend API and provides a smooth authoring experience with category management, lists, and detail pages.

If you’re running this within the full-stack solution, this is the UI portion located at `UI/Plog`.

## ✨ Features
- 📝 Create and edit blog posts
- 🗂️ Categorize posts and filter by category
- ⚡ Instant updates powered by RxJS Observables
- 🧭 Angular routing for a clean, SPA experience
- 🎯 Typed models with TypeScript

## 🧰 Tech Stack
- Angular 16
- TypeScript
- RxJS
- HTML/CSS

## 🚀 Getting Started

### 1) Prerequisites
- Node.js 16+ (18+ recommended)
- Angular CLI globally installed: `npm i -g @angular/cli`

### 2) Install dependencies
```
npm install
```

### 3) Start the dev server
```
ng serve
```
Then visit: http://localhost:4200/

The app will auto-reload as you change files. ✅

## 🛠️ Available Scripts
- `ng serve` — start dev server
- `ng build` — build for production (output in `dist/`)
- `ng test` — run unit tests with Karma
- `ng e2e` — run end-to-end tests (if an e2e runner is configured)

## 🗂️ Project Structure (UI)
```
UI/Plog
├─ src/
│  ├─ app/
│  │  └─ features/
│  │     ├─ blog-post/
│  │     │  ├─ add-blog-post/
│  │     │  ├─ edit-blogpost/
│  │     │  ├─ blog-post-list/
│  │     │  ├─ models/
│  │     │  └─ services/
│  │     └─ category/
│  │        ├─ add-category/
│  │        ├─ edit-category/
│  │        ├─ category-list/
│  │        ├─ models/
│  │        └─ services/
│  └─ environments/
├─ angular.json
├─ package.json
└─ README.md
```

## 🗃️ Categories
- Manage categories (add, edit, delete) under the Admin routes.
- Categories are used in blog post forms (multi-select) via CategoryService.
- Related code lives in `src/app/features/category`.

## 🧩 Tips & Notes
- Use `ng generate component <name>` to scaffold new components.
- Make sure your API is running if the UI relies on live data.
- Adjust environment files in `src/environments` for API base URLs.

## 📸 Screenshots (optional)
Add your UI screenshots here to make the README even more lovely!

## 🤝 Contributing
Have ideas to make Plog better? PRs are welcome! Please open an issue or pull request.

## 📜 License
This project is licensed under the MIT License.

---

Made with ❤️ on 2025-10-20
