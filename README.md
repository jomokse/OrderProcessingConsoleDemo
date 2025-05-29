# OrderProcessingDemo

This is a simple .NET console application that demonstrates the **value of software testing** by showcasing different types of automated tests:

- ✅ **Unit tests**
- ✅ **Integration tests**
- ✅ **End-to-end (E2E) tests**

The project uses an in-memory data model to simulate order processing and optionally stores orders in a SQLite database. Tests are executed automatically in a CI pipeline using GitHub Actions.

---

## 🧪 Testing Types Explained

### Unit Tests
- Test small, isolated pieces of logic (e.g., order total calculation)
- Fast and easy to write
- No dependencies on database or external systems

### Integration Tests
- Verify that components work together (e.g., database save/retrieve)
- Use Entity Framework with SQLite for testing
- Require a real or testable infrastructure

### End-to-End (E2E) Tests
- Launch the full console application
- Check that the user-facing output behaves as expected
- Simulate a real run from start to finish

---

## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQLite (no manual setup required)

### Build the project
dotnet build

### Run the app
dotnet run --project OrderProcessingDemo

### Run all tests
dotnet test

## ⚙️ Project Structure
OrderProcessingConsoleDemo/         # Main console application
OrderProcessingConsoleDemo.Tests/   # Unit, integration and E2E tests
  ├── Unit/
  ├── Integration/
  └── E2E/
.github/workflows/ci.yml     # GitHub Actions CI pipeline

## 🛠 Technologies Used
.NET 9 Console App
Entity Framework Core (SQLite)
xUnit
GitHub Actions

## 📦 CI/CD
A GitHub Actions workflow is included in .github/workflows/ci.yml. It automatically builds and runs all tests on push and pull requests to main or master.

## 📚 Project Goal
This project aims to demonstrate:

- The benefits of having automated tests at multiple levels
- How each test type contributes to confidence and maintainability
- How to integrate testing into CI/CD workflows

It can serve as a starting point for learning software testing in .NET.

## 📄 License
MIT – feel free to use, fork and modify!
