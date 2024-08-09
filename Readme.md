# Example modular monolith architecture with .net C#

- The idea is to combine multiple solution in one deployable package. Each module follow S.O.L.I.D. principles and Clean Architecture

# Structure

- The App is the host wrapper that will include and run all modules
- A module (for example User) is:
  - Self enclosed application which can run on its own.
  - If required it can be extracted in microservice, and hosted separately.
  - Include and own Database / Table / Models
  - Provide API (http or internal) for other modules to connect and share data.
  - Must be loosely coupled with other modules using **ONLY** the exposed apis if data transfer is required.
  - Can Follow different patterns and architecture - e.g. Mediator pattern, SOLID principles, CLEAN architecture
- at this stage I am not sure if each module will also include separate UI

# Setup and requirements

- .net 8

```
dotnet run --project App
```
