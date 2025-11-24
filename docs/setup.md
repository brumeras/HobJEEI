## Setup Notes

### Backend
1. `cd backend/HobJeei.Api`
2. `dotnet new webapi -n HobJeei.Api`
3. Add folders: `Controllers/`, `Models/`, `Services/`, `Data/`
4. Configure EF Core (connection string in `appsettings.json`)

### Backend Tests
1. `cd backend/HobJeei.Api.Tests`
2. `dotnet new xunit -n HobJeei.Api.Tests`
3. Reference the API project: `dotnet add reference ..\\HobJeei.Api\\HobJeei.Api.csproj`

### Frontend
1. `cd frontend`
2. `npm create vite@latest . -- --template react-ts` (or preferred starter)
3. Organize route-level UI in `src/pages` and shared pieces in `src/components`

### Razor + React
- Razor `.cshtml` files produce HTML on the server using C# expressions. They are similar to React components in that both define UI and can include logic, but Razor executes before the response reaches the browser, while React runs in the browser.
- You can mix them by rendering Razor layouts that include a `<div id="root"></div>` where React hydrates, or keep them separate (API + SPA).

