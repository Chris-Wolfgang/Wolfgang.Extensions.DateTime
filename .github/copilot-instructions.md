# Copilot Instructions for Wolfgang.Extensions.DateTime

## Project Overview
- **Package:** Wolfgang.Extensions.DateTime
- **Namespace:** Wolfgang.Extensions.DateTime
- **Purpose:** Extension methods for System.DateTime — truncation and date boundary navigation

## Key Types
- `DateTimeExtensions` — static class with extension methods on `System.DateTime`

## Extension Methods
- `TruncateMilliseconds()` — zeroes out milliseconds
- `TruncateSeconds()` — zeroes out seconds and milliseconds
- `FirstOfMonth()` / `EndOfMonth()` — month boundary navigation
- `FirstOfYear()` / `EndOfYear()` — year boundary navigation
- `FirstOfWeek()` / `EndOfWeek()` — week boundary navigation (culture-aware + explicit DayOfWeek overloads)

## Important Notes
- All methods preserve `DateTimeKind`
- Use `System.DateTime` (fully qualified) to avoid namespace conflicts with the library namespace
- `EndOfMonth/Year/Week` returns the last tick before the next period (`.AddTicks(-1)`)

## Code Style
- Allman brace style
- 3 blank lines between members
- File-scoped namespaces
- Warnings as errors in Release builds

## Target Frameworks
- net462, netstandard2.0, net8.0, net10.0
