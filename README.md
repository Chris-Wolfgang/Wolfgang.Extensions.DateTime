# Wolfgang.Extensions.DateTime

A collection of extension methods for `DateTime` data type in .Net

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-Multi--Targeted-purple.svg)](https://dotnet.microsoft.com/)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?logo=github)](https://github.com/Chris-Wolfgang/DateTime-Extensions)

---

## 📦 Installation

```bash
dotnet add package Wolfgang.Extensions.DateTime
```

**NuGet Package:** [Wolfgang.Extensions.DateTime](https://www.nuget.org/packages/Wolfgang.Extensions.DateTime)

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📚 Documentation

- **GitHub Repository:** [https://github.com/Chris-Wolfgang/DateTime-Extensions](https://github.com/Chris-Wolfgang/DateTime-Extensions)
- **API Documentation:** https://Chris-Wolfgang.github.io/DateTime-Extensions/
- **Formatting Guide:** [README-FORMATTING.md](README-FORMATTING.md)
- **Contributing Guide:** [CONTRIBUTING.md](CONTRIBUTING.md)

---

## 🚀 Quick Start



---

## ✨ Features

## Methods
| Method | Description |
|--------|-------------|
| `TruncateMilliseconds` | Removes fractional seconds, returning a DateTime accurate to the whole second. |
| `TruncateSeconds`| Strips seconds and smaller units, yielding a DateTime rounded down to the minute. |
| `FirstOfMonth`| Produces a new `DateTime` set to the first day of the month at midnight of the specified `DateTime`. |
| `EndOfMonth`| Computes the final tick of the month for the specified `DateTime`. |
| `FirstOfYear`| Creates a `DateTime` corresponding to January 1 of the same year as the specified `DateTime`. |
| `EndOfYear`| Returns the final tick of the year of the specified `DateTime`. |
| `FirstOfWeek()`| Uses the current culture’s first day of the week to locate the week’s starting `DateTime`. |
| `FirstOfWeek(DayOfWeek firstDayOfWeek)`| Uses the specified first day of the week to locate the week’s starting `DateTime`. |
| `EndOfWeek()`| Uses the current culture’s first day, calculates the final tick of the week. |
| `EndOfWeek(DayOfWeek firstDayOfWeek)`| Uses the specified first day, calculates the final tick of the week. |

**Note** These are the methods present at the time the documentation was last updated. For a complete of methods see the [API Documentation](https://Chris-Wolfgang.github.io/DateTime-Extensions/)

**Examples:**

---

## 🎯 Target Frameworks

| Framework | Versions |
|-----------|----------|
| .Net Framework | .net 4.6.2, .net 4.7.0, .net 4.7.1, .net 4.7.2, .net 4.8, .net 4.8.1 | 
| .Net Core | |
| .Net | .Net 5.0, .Net 6.0, .Net 7.0, .Net 8.0, .Net 9.0, .Net 10.0

---

## 🔍 Code Quality & Static Analysis

This project enforces **strict code quality standards** through **7 specialized analyzers** and custom async-first rules:

### Analyzers in Use

1. **Microsoft.CodeAnalysis.NetAnalyzers** - Built-in .NET analyzers for correctness and performance
2. **Roslynator.Analyzers** - Advanced refactoring and code quality rules
3. **AsyncFixer** - Async/await best practices and anti-pattern detection
4. **Microsoft.VisualStudio.Threading.Analyzers** - Thread safety and async patterns
5. **Microsoft.CodeAnalysis.BannedApiAnalyzers** - Prevents usage of banned synchronous APIs
6. **Meziantou.Analyzer** - Comprehensive code quality rules
7. **SonarAnalyzer.CSharp** - Industry-standard code analysis


---

## 🛠️ Building from Source

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
- Optional: [PowerShell Core](https://github.com/PowerShell/PowerShell) for formatting scripts

### Build Steps

```bash
# Clone the repository
git clone https://github.com/Chris-Wolfgang/DateTime-Extensions.git
cd DateTime-Extensions

# Restore dependencies
dotnet restore

# Build the solution
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Run code formatting (PowerShell Core)
pwsh ./format.ps1
```

### Code Formatting

This project uses `.editorconfig` and `dotnet format`:

```bash
# Format code
dotnet format

# Verify formatting (as CI does)
dotnet format --verify-no-changes
```

See [README-FORMATTING.md](README-FORMATTING.md) for detailed formatting guidelines.

### Building Documentation

This project uses [DocFX](https://dotnet.github.io/docfx/) to generate API documentation:

```bash
# Install DocFX (one-time setup)
dotnet tool install -g docfx

# Generate API metadata and build documentation
cd docfx_project
docfx metadata  # Extract API metadata from source code
docfx build     # Build HTML documentation

# Documentation is generated in the docs/ folder at the repository root
```

The documentation is automatically built and deployed to GitHub Pages when changes are pushed to the `main` branch.

**Local Preview:**
```bash
# Serve documentation locally (with live reload)
cd docfx_project
docfx build --serve

# Open http://localhost:8080 in your browser
```

**Documentation Structure:**
- `docfx_project/` - DocFX configuration and source files
- `docs/` - Generated HTML documentation (published to GitHub Pages)
- `docfx_project/index.md` - Main landing page content
- `docfx_project/docs/` - Additional documentation articles
- `docfx_project/api/` - Auto-generated API reference YAML files

---

## 🤝 Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for:
- Code quality standards
- Build and test instructions
- Pull request guidelines
- Analyzer configuration details

---


## 🙏 Acknowledgments



