# Persistence Layer

This layer conatins dbcontext, all database migrations, database seeding, and entities configurations
It implements interfaces defined in the application layer
The logic of accessing database will be in the application layer in the command or the query.
This layer is pluggable but any other layer must be based on the Entity framework core
