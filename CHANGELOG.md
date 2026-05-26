# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

### Changed

### Deprecated

### Removed

### Fixed

### Security

## [1.2.0] - 2026-04-27

### Fixed

- Boundary crashes in `FirstOfMonth`, `EndOfMonth`, `FirstOfYear`,
  `EndOfYear`, `FirstOfWeek`, `EndOfWeek` near `DateTime.MaxValue` and
  `DateTime.MinValue` — methods now return the boundary value instead of
  throwing.
- `FirstOfWeek` no longer carries the input's time-of-day into the
  returned value (now consistently returns `00:00:00.0000000`).

### Changed

- Analyzer `PackageReference`s moved from `Directory.Build.props` into
  individual csproj files, allowing per-project opt-out where required.

## [1.1.0] - 2026-03-31

### Changed

- Dropped `netcoreapp3.1` target. Supported frameworks are now
  `net462`, `netstandard2.0`, `net8.0`, and `net10.0`.

### Fixed

- `TruncateMilliseconds` and `TruncateSeconds` now use the 8-parameter
  `DateTime` constructor with explicit `millisecond=0`, removing an
  ambiguity that surfaced under some culture settings.
- XML documentation corrections (`EndOfWeek` previously said "end of
  the month").

### Removed

- `StyleCop.Analyzers` PackageReference removed in favour of the
  consolidated analyzer set (Roslynator, Meziantou, SonarAnalyzer).

## [1.0.0] - 2026-01-18

### Added

- Initial release with `TruncateMilliseconds`, `TruncateSeconds`,
  `FirstOfMonth`, `EndOfMonth`, `FirstOfYear`, `EndOfYear`,
  `FirstOfWeek`, `EndOfWeek` extension methods on `System.DateTime`.
- Multi-framework targeting: `net462`, `netstandard2.0`,
  `netcoreapp3.1`, `net8.0`, `net10.0`.

[Unreleased]: https://github.com/Chris-Wolfgang/DateTime-Extensions/compare/v1.2.0...HEAD
[1.2.0]: https://github.com/Chris-Wolfgang/DateTime-Extensions/compare/v1.1.0...v1.2.0
[1.1.0]: https://github.com/Chris-Wolfgang/DateTime-Extensions/compare/v1.0.0...v1.1.0
[1.0.0]: https://github.com/Chris-Wolfgang/DateTime-Extensions/releases/tag/v1.0.0
