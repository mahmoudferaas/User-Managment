# Domain Layer

This will contain all entities, enums, exceptions, types and logic specific to the domain.
The Entity Framework related classes are abstract, and should be considered in the same light as .NET Core.
For testing, use an InMemory provider such as InMemory or SqlLite.
Avoid using data annotation, use fluent validation instead
Use value objects if needed
Initialize all collection in the constructor of the entity and make its setter private.
Create custom domain exceptions

