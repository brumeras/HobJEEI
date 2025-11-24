## Architecture Overview

- **Backend (`backend/HobJeei.Api`)**
  - ASP.NET Core 8 Web API.
  - Exposes REST endpoints consumed by the frontend.
  - Optional Razor Pages if server-rendered views are needed (see `docs/setup.md`).
  - Entity Framework Core for data access lives under `Data/`.

- **Frontend (`frontend/`)**
  - React SPA rendered on the client.
  - Communicates with the API via `src/api/*`.
  - Pages/components split between `pages/` for route-level UI and `components/` for reusable parts.

- **Shared Contracts (`shared/contracts`)**
  - Source of truth for DTOs and API schema.
  - Consider storing OpenAPI specs or C# records shared via git submodule/nuget package.

- **Testing**
  - Backend integration/unit tests inside `backend/HobJeei.Api.Tests`.
  - Frontend testing strategy TBD (Jest/Vitest/React Testing Library).

- **Docs**
  - Keep ADRs and onboarding guides in `docs/`.

