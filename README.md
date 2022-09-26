# DigitalWareTest
Prueba técnica DigitalWare

#Required Setup

* Angular 13.0.1
* Net core 6.0

# Layered architecture in ASP.NET Core 6 Web API

´´´
└───Backend
        └───API
            ├───Properties
            ├───Controllers
            └───DTO
            |     └───Profiles
            ├───DAL
            │   └───Repositories
            │   
            ├───Domain
            │   └───Contrats
            │       ├───Contrats
            │       ├───Data
            │       ├───ModelConfigurations
            │       └───Models
            └───Cross-Cutting
                ├───Common
                └───DTO

´´´
