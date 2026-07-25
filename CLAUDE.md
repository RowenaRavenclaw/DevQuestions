# CLAUDE.md

This file guides Claude Code (claude.ai/code) and contributors when working with
code in this repository.

## Project Overview

DevQuestions is an ASP.NET Core Q&A service (a StackOverflow-style backend) where
users post questions, tag them, and submit answers, with the ability to mark one
answer as the accepted solution. The API is exposed over HTTP with OpenAPI/Swagger
documentation. The controller layer is currently scaffolded with stubbed responses;
domain logic and persistence are still to come.

## Tech Stack

- **Runtime**: .NET 10.0 (`net10.0`), C# with nullable reference types and implicit
  usings enabled.
- **Web**: ASP.NET Core Web API (controllers), OpenAPI via
  `Microsoft.AspNetCore.OpenApi`, Swagger UI via `Swashbuckle.AspNetCore`.
- **Analyzers**: .NET analyzers + StyleCop.Analyzers (`1.2.0-beta.556`), enforced
  through `Directory.Build.props` and `.editorconfig`.

## Common Commands

Run these from the `DevQuestions/` directory (where `DevQuestions.sln` lives):

```bash
dotnet restore                          # restore NuGet packages
dotnet build                            # build the whole solution
dotnet run --project src/DevQuestions.WebApp   # run the API host
```

The `http` launch profile serves at `http://localhost:5171` and opens Swagger UI at
`http://localhost:5171/swagger/index.html`; the `https` profile adds
`https://localhost:7021`. Both default `ASPNETCORE_ENVIRONMENT` to `Development`.

> Note: there is no test project yet. Add one under `DevQuestions/tests/` and run it
> with `dotnet test` when tests are introduced.

## Architecture

The solution lives under `DevQuestions/` and is layered into projects under
`DevQuestions/src/`:

| Project                   | Responsibility                                         |
| ------------------------- | ------------------------------------------------------ |
| `DevQuestions.Domain`     | Domain entities (e.g. `Tag`, questions, answers).      |
| `DevQuestions.Contracts`  | Request/response DTOs exchanged with the API.          |
| `DevQuestions.Presenters` | API controllers (e.g. `QuestionsController`).          |
| `DevQuestions.WebApp`     | ASP.NET Core host: DI, OpenAPI/Swagger, entry point.   |

Dependency direction (references flow inward toward the domain):

```
WebApp ──> Presenters ──> Contracts
   │            └────────> Domain
   └──────────────────────> Domain
```

- **`WebApp`** is the composition root — `Program.cs` registers controllers and
  OpenAPI, then maps Swagger UI and the controller routes. It has no business logic.
- **`Presenters`** holds the controllers. `QuestionsController` defines the REST
  surface: create/list/get-by-id/update/delete questions, add answers
  (`POST {id}/answers`), and select a solution (`PUT {id}/solution`). Actions
  currently return placeholder `Ok(...)` responses.
- **`Contracts`** contains DTOs as C# `record` types (e.g.
  `CreateQuestionDto`, `UpdateQuestionDto`, `GetQuestionDto`, `AddAnswerDto`).
- **`Domain`** contains plain entity classes (e.g. `Tag`) with no framework
  dependencies.

Shared build settings (target framework, nullable, implicit usings, analyzers) are
centralized in `DevQuestions/Directory.Build.props` and apply to every project.

## Code Style

Formatting and naming are enforced by `.editorconfig` and StyleCop — let the tools
drive; match the surrounding code. Key conventions:

- **Indentation**: 4 spaces; **line endings**: CRLF; **encoding**: UTF-8 BOM;
  files do **not** end with a final newline.
- **`var`**: preferred everywhere (built-in types, when apparent, and elsewhere).
- **Braces**: open brace on a new line (Allman); `else`/`catch`/`finally` on new lines.
- **`this.`** qualification is not used for fields, properties, methods, or events.
- **Naming**: PascalCase for constants; private/internal fields are camelCase with a
  leading underscore (`_field`); private/internal static fields use an `s_` prefix.
- **DTOs** are `record` types in `DevQuestions.Contracts`; **entities** are classes
  in `DevQuestions.Domain` using `required` members where appropriate.

## Commit convention

This repository uses **[Conventional Commits](https://www.conventionalcommits.org/)**.

### Format

```
<type>(<optional scope>): <short summary>

<optional body — what & why, wrapped at ~72 cols>

<optional footer — BREAKING CHANGE:, issue refs>
```

### Types

| Type       | Use for                                                             |
| ---------- | ------------------------------------------------------------------ |
| `feat`     | A new feature or capability.                                        |
| `fix`      | A bug fix.                                                          |
| `refactor` | Code change that neither fixes a bug nor adds a feature.           |
| `style`    | Formatting/whitespace only, no behavior change.                    |
| `docs`     | Documentation only.                                                 |
| `test`     | Adding or adjusting tests.                                          |
| `chore`    | Build config, tooling, dependencies, housekeeping.                 |
| `build`    | Changes to the build system or project/package references.         |
| `ci`       | CI configuration.                                                   |
| `perf`     | Performance improvement.                                            |

### Scope

Optional; use the affected project or area, e.g. `contracts`, `presenters`,
`webapp`, `domain`, `build`.

### Rules

- Summary in the **imperative mood**, lowercase, no trailing period
  (e.g. "add answer DTO", not "Added answer DTO.").
- Keep the summary under ~72 characters.
- One logical change per commit; split unrelated changes.
- Breaking changes: add `!` after the type/scope (`feat(api)!: ...`) **and** a
  `BREAKING CHANGE:` footer.
- Reference issues in the footer when applicable (`Refs #3`, `Closes #3`).

### Examples

```
feat(contracts): add question and answer DTOs
feat(presenters): scaffold Questions API controller
chore(build): add StyleCop analyzers and shared build props
style(domain): tidy whitespace in Tag entity
```

## Housekeeping

- Never commit build output — `bin/`, `obj/`, and IDE folders are covered by
  `.gitignore`.
- Match the surrounding code style; let `.editorconfig`/StyleCop drive formatting.
