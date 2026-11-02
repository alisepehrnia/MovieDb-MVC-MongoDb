# 🎬 MovieDb – ASP.NET Core MVC + MongoDB

A sample **ASP.NET Core MVC** web application that manages a movie database using **MongoDB** as the data store.  
The project demonstrates how to build a full-stack .NET application with MongoDB, including RESTful API endpoints, Razor views, and complex filtering queries.

---

## 📖 Overview

`MovieDb-MVC-MongoDb` is a learning/demo project that implements a movie catalogue where you can:

- Perform **CRUD** operations on movies (Create, Read, Update, Delete).
- Store nested documents (director and actors) inside each movie record.
- Run **pre-defined queries** (Q1–Q9) that showcase MongoDB’s filtering capabilities.
- Access the data through both **MVC actions** (returning HTML views) and **API endpoints** (returning JSON).

The application follows a classic **MVC** pattern with a service layer (`MovieService`) that abstracts MongoDB access.  
It targets **.NET 5** and uses the official **MongoDB.Driver** NuGet package.

---

## ✨ Features

- **Movie Model** – Includes title, year, genre, summary, country, director, and a list of actors.
- **Person / Actor / Director Models** – A base `Person` class stores common fields (first name, last name, birth date); `Actor` adds a `Role` field, and `Director` overrides `ToString()`.
- **MovieService** – Encapsulates all MongoDB operations (Get, GetByFilter, Create, Update, Remove).
- **MovieController** – Provides:
  - **REST API endpoints** (`GET`, `POST`, `PUT`, `DELETE`) for movies.
  - **MVC actions** (`Index`, `Add`, `Remove`, `Update`) that return Razor views.
  - **Query actions** (`Q1`–`Q9`) that demonstrate filtering by country, year, title prefix, director’s first name, and more.
- **Razor Views** – Located in `Views/Home`, `Views/Movie`, and `Views/Shared`, they render the movie list and basic UI.
- **Configurable MongoDB settings** – `MovieDatabaseSettings` (connection string, database name, collection name) is injected via `IMovieDatabaseSettings`.

---

## 🛠️ Technologies

| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core MVC (.NET 5) |
| Database | MongoDB |
| Driver | MongoDB.Driver (official .NET driver) |
| Language | C# |
| Front-end | Razor Views (CSHTML) |
| IDE | Visual Studio / VS Code (solution file `MvcMovie.sln` provided) |

---

## 📋 Prerequisites

Before running the project, make sure you have:

- [.NET 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) (or later, with .NET 5 targeting pack).
- A **MongoDB** instance (local or cloud, e.g., MongoDB Atlas).
- (Optional) Visual Studio 2019/2022 or JetBrains Rider for a smoother experience.

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/alisepehrnia/MovieDb-MVC-MongoDb.git
cd MovieDb-MVC-MongoDb
```

### 2. Configure MongoDB

Open `appsettings.json` (or `appsettings.Development.json`) and set your MongoDB connection details:

```json
{
  "MovieDatabaseSettings": {
    "MoviesCollectionName": "Movies",
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MovieDb"
  }
}
```

> **Note:** If you use MongoDB Atlas, replace the connection string with your Atlas URI.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Run the application

```bash
dotnet run
```

The app will start on `https://localhost:5001` (or the port shown in the console).

### 5. Explore

- Navigate to `/Movie` to see the movie list (MVC view).
- Use the API endpoints (e.g., `GET /Movie` returns JSON) to interact programmatically.
- Try the query actions (`/Movie/Q1`, `/Movie/Q2`, …) to see different filters in action.

---

## 🗂️ Project Structure

```text
MovieDb-MVC-MongoDb/
├── Controllers/
│   └── MovieController.cs          # API + MVC actions
├── Data/
│   └── MovieService.cs             # MongoDB data access layer
├── Models/
│   ├── Actor.cs                    # Actor (inherits Person)
│   ├── Director.cs                 # Director (inherits Person)
│   ├── Movie.cs                    # Main movie document
│   ├── MovieDatabaseSettings.cs    # Configuration model
│   └── Person.cs                   # Base person class
├── Views/
│   ├── Home/                       # Home views
│   ├── Movie/                      # Movie views (Index, etc.)
│   └── Shared/                     # Layout & partial views
├── wwwroot/                        # Static assets (CSS, JS, images)
├── MvcMovie.csproj                 # Project file (.NET 5)
├── MvcMovie.sln                    # Solution file
└── appsettings.json                # Configuration (MongoDB settings)
```

---

## 🔌 API Endpoints (MovieController)

| Method | Route | Description |
|--------|-------|-------------|
| `GET` | `/Movie` | Returns all movies (JSON) |
| `GET` | `/Movie/{id}` | Returns a single movie by ID |
| `POST` | `/Movie` | Creates a new movie |
| `PUT` | `/Movie/{id}` | Updates an existing movie |
| `DELETE` | `/Movie/{id}` | Deletes a movie |

> **Note:** The controller also exposes MVC actions (`Index`, `Add`, `Remove`, `Update`) that return Razor views. These are intended for browser-based interaction.

---

## 🔍 Query Demonstrations (Q1–Q9)

The `MovieController` includes several query actions that illustrate MongoDB filtering:

| Action | Filter |
|--------|--------|
| `Q1` | Movies where `country` = `"USA"` |
| `Q2` | Movies with `year` > 2000 |
| `Q3` | All movies (no filter) |
| `Q5` | Movies from `"FR"` (limited to 3 results) |
| `Q6` | Movies from `"USA"` **and** `year` > 2000 |
| `Q7` | Movies whose `title` starts with `"T"` |
| `Q8` | Checks if any director has an empty `birth_date` |
| `Q9` | Movies where director’s first name = `"Steven"` |

These actions are useful for learning how to build filter definitions with the MongoDB C# driver.

---

## 🤝 Contributing

This is primarily a sample/learning project. If you find bugs or have suggestions, feel free to open an issue or submit a pull request.

---

## 📄 License

No license is specified in the repository. Please contact the repository owner for usage terms.

---

## 🙏 Acknowledgements

- Built with [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) and [MongoDB](https://www.mongodb.com/).
- Inspired by common MVC + MongoDB tutorials and sample projects.
- Done for Software Engineering BSc Database Lab Course

---

*Happy coding!* 🚀
