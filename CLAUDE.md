# CLAUDE.md

Guidance for Claude Code and contributors working in this repository.

## Project

DevQuestions — an ASP.NET Core (net10.0) Q&A service. The solution lives under
`DevQuestions/` and is layered into projects under `DevQuestions/src/`:

| Project                   | Responsibility                                         |
| ------------------------- | ------------------------------------------------------ |
| `DevQuestions.Domain`     | Domain entities (e.g. `Tag`, questions, answers).      |
| `DevQuestions.Contracts`  | Request/response DTOs exchanged with the API.          |
| `DevQuestions.Presenters` | API controllers (e.g. `QuestionsController`).          |
| `DevQuestions.WebApp`     | ASP.NET Core host: DI, OpenAPI/Swagger, entry point.   |

Shared build settings (target framework, nullable, analyzers) are centralized in
`DevQuestions/Directory.Build.props`; code style is enforced via `.editorconfig`
and StyleCop analyzers.

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
