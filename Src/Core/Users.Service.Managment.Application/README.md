# Application Layer

This layer contains all application logic. 
For example in case of booking the logic of going to payment and getting provider configurations all of these stuff will be handled in this layer.
It is an orchestrator that prepare all data needed for a domain service to accomplish a specific task.
It is dependent on the domain layer, but has no dependencies on any other layer or project.
This layer defines interfaces that are implemented by outside layers. 
For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
MediatR and Automapper are registered in this layer