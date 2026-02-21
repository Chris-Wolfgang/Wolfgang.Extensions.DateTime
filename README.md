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

**Note:** These are the methods present at the time the documentation was last updated. For a complete list of methods, see the [API documentation](https://Chris-Wolfgang.github.io/DateTime-Extensions/api/Wolfgang.Extensions.DateTime.DateTimeExtensions.html).

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

## 🔧 Troubleshooting: DocFX Version Picker

The DocFX version-switcher dropdown (top-right corner of the docs site) lets readers jump between published versions. If the dropdown is missing, empty, or shows stale entries, work through the checklist below.

### Root Cause Summary

After a repo scan:
- ✅ **Templates & partials** – no custom `templates/` or `_overwrite/` folder; the project uses DocFX's built-in `default` and `modern` templates unmodified.
- ✅ **`docfx.json` config** – `_enableVersionDropdown: true`, `_versionScheme: "docfx"`, and a `versioning.groups` block that matches `v*` tags are all present and correct.
- ⚠️ **Asset cleanup** – the **critical** issue is that `keep_files: true` on every `peaceiris/actions-gh-pages` deploy step means old DocFX static files from a previous build accumulate at the gh-pages root and can conflict with a newer build's file paths, causing the version picker JavaScript to silently fail.

The workflow now includes an explicit **cleanup step** that removes all stale root-level files from `gh-pages` (except version folders such as `v1.0.0/`, the `latest/` alias, `CNAME`, and `.nojekyll`) before the latest docs are deployed.

---

### `docfx.json` Requirements

The following `globalMetadata` keys must be set for the version picker to appear:

```json
"globalMetadata": {
  "_enableVersionDropdown": true,
  "_versionScheme": "docfx"
}
```

The `versioning` block that generates per-tag builds must also be present:

```json
"versioning": {
  "groups": [
    { "tags": ["v*"], "version": "{tag}" }
  ]
}
```

---

### `versions.json` Format

The version picker reads a `versions.json` file from the **site root** (`/versions.json`). This file is generated automatically by the workflow. Its expected format is:

```json
[
  { "version": "latest", "url": "/" },
  { "version": "v1.2.3", "url": "/v1.2.3/" },
  { "version": "v1.0.0", "url": "/v1.0.0/" }
]
```

If this file is missing or malformed, the dropdown will appear empty or not render at all.

---

### Expected gh-pages Folder Structure

```
gh-pages root/
├── index.html          ← latest docs landing page
├── versions.json       ← consumed by the version picker dropdown
├── .nojekyll           ← disables Jekyll processing on GitHub Pages
├── CNAME               ← custom domain (if configured)
├── v1.2.3/             ← versioned docs (keep_files preserves these)
│   └── index.html
├── v1.0.0/
│   └── index.html
└── latest/             ← stable alias pointing to the latest version
    └── index.html
```

---

### Cleaning Up Old Files Manually

If stale files are already present on `gh-pages` and the automated cleanup step has not yet run, you can clean the branch locally:

```bash
# 1. Check out the gh-pages branch
git fetch origin gh-pages
git checkout gh-pages

# 2. Remove all root-level items except versioned folders, CNAME, and .nojekyll
find . -mindepth 1 -maxdepth 1 \
  ! -name '.git' \
  ! -name 'CNAME' \
  ! -name '.nojekyll' \
  ! -regex '.*/v[0-9].*' \
  ! -name 'latest' \
  -exec rm -rf {} +

# 3. Commit and push
git add -A
git commit -m "chore: manual cleanup of stale root DocFX assets"
git push origin gh-pages

# 4. Return to your working branch
git checkout main
```

---

### Post-Deploy Validation

Use the included validation script to verify the gh-pages branch after deployment:

```bash
bash scripts/Validate-DocsDeploy.sh
```

The script checks that:
- `index.html` exists at root
- `versions.json` exists at root and has the correct structure
- `.nojekyll` is present
- Every version referenced in `versions.json` has a corresponding folder with an `index.html`
- No known stale DocFX artifacts remain at root

---

### Common Issues

| Symptom | Likely Cause | Fix |
|---------|-------------|-----|
| Dropdown not visible at all | `_enableVersionDropdown` not set to `true` | Add `"_enableVersionDropdown": true` to `docfx.json` `globalMetadata` |
| Dropdown visible but empty | `versions.json` missing from site root | Re-run the workflow; verify the "Generate versions.json" step succeeded |
| Dropdown shows wrong versions | `versions.json` is stale | Trigger a new deployment to regenerate `versions.json` from current git tags |
| Version link returns 404 | Version folder missing from gh-pages | Redeploy that version tag via `workflow_dispatch` with `deploy_as_latest: false` |
| Picker JS fails silently | Old JS/CSS files from a previous build conflict with new build | Run the cleanup step or the manual cleanup commands above |

---

## 🤝 Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for:
- Code quality standards
- Build and test instructions
- Pull request guidelines
- Analyzer configuration details

---


## 🙏 Acknowledgments



