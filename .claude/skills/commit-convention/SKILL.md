---
name: commit-convention
description: Use this skill whenever creating a git commit in this repository, drafting a commit message, or when the user asks about commit format, commit types, or commit conventions. Ensures commits follow this project's Conventional Commits style.
version: 1.0.0
---

# Commit Convention

This repository uses **[Conventional Commits](https://www.conventionalcommits.org/)**.

## Format

```
<type>(<optional scope>): <short summary>

<optional body — what & why, wrapped at ~72 cols>

<optional footer — BREAKING CHANGE:, issue refs>
```

## Types

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

## Scope

Optional; use the affected project or area, e.g. `contracts`, `presenters`,
`webapp`, `domain`, `build`.

## Rules

- Summary in the **imperative mood**, lowercase, no trailing period
  (e.g. "add answer DTO", not "Added answer DTO.").
- Keep the summary under ~72 characters.
- One logical change per commit; split unrelated changes.
- Breaking changes: add `!` after the type/scope (`feat(api)!: ...`) **and** a
  `BREAKING CHANGE:` footer.
- Reference issues in the footer when applicable (`Refs #3`, `Closes #3`).

## Examples

```
feat(contracts): add question and answer DTOs
feat(presenters): scaffold Questions API controller
chore(build): add StyleCop analyzers and shared build props
style(domain): tidy whitespace in Tag entity
```
