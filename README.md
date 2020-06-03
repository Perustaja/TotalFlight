# TotalFlight
Complete flight scheduling, maintenance, and billing software for schools and clubs. 

# Architectural overview
Eventually, the plan is to break up the scheduling(fleet incl), maintenance, and billing into microservices. 
Right now this is a monolithic application that contains:
- TotalFlight.Api - Application layer - Contains a web API, commands & command handlers, and queries(Dapper).
- TotalFlight.Domain - Domain layer - DDD, self-explanatory.
- TotalFlight.Infrastructure - Infrastructure layer - Repositories, data access, EF Core.

# Technical Features & Implementation
## Database Tenancy via EF Core

# Design Patterns
## DDD Implementation
### Entities
### Domain Events
Domain events are created... Entities inherit from a base class that includes a collection of domain events and methods for interaction. To cause deferred execution, a custom EF Core method exists to dispatch all domain events prior to being saved (exceptions result in a standard EF Core revert).
- Domain Events - The actual event in past-tense. Implements INotification and contains event info for handler usage. Only has get accessors (immutable).

## CQRS Implementation