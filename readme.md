# Greeting Avalara!

Thank you in advance for checking out my code! Here are a few highlights that might interest you.

## Live Demo

You can view this app here: https://avalara.kemmis.info/.

## Architecture
Lately I've been impressed with the [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) design pattern. This project gave me a nice opportunity to give this pattern a try. You'll notice that the dependencies are setup in a very particular way. The more I work with it, the more I really like it.

Additionally, I'm using the [MediatR](https://github.com/jbogard/MediatR) library which gives you an epic amount of decoupling via the CQRS and mediator patterns. All the API's business logic, validation, etc are completely moved out of the web app project, and into discrete testable classes.

Though I did put a lot of time into this, I have to give credit to these two example solutions, of which I followed many of their design approaches:

https://github.com/jasontaylordev/NorthwindTraders

https://github.com/iayti/CleanArchitecture

## More Details
The latest NC sales tax rate data was pulled from ncdor.gov's public [Sales Tax Rate Databases page](https://www.ncdor.gov/taxes-forms/sales-and-use-tax/streamlined-sales-tax-information/streamlined-sales-and-use-tax/sales-tax-rate-databases). After a bit of cleanup, the data is able to be used to [seed my sql database](Infrastructure/Persistence/StateTaxDbContextSeedExtensions.cs#L20).

I've setup [NSWAG](https://github.com/RicoSuter/NSwag) and [SwaggerUI](https://github.com/swagger-api/swagger-ui) so that you can easily access the OpenAPI doc for this app, as well as test out the API call via a nice GUI.

I have two test projects in the solution. First, the Application.Tests project is an XUnit project that tests the main *Calculate* API call functionality that is handled in the [GetSalesTaxForTransactionQueryHandler](Application/Tax/Queries/GetSalesTaxForTransactionQueryHandler.cs#L14) class. You can view those tests [here](Application.Tests/Tax/Queries/GetSalesTaxForTransactionQueryHandlerTests.cs#L16). In addition, the WebApi.IntegrationTests project actually executes the API call itself, and tests that the [GetSalesTaxForTransactionQueryValidator](Application/Tax/Queries/GetSalesTaxForTransactionQueryValidator.cs#L12) class is working. You can view those tests [here](WebApi.IntegrationTests/Controllers/StateTax/Calculate.cs#L14).

## Other Misc
- .Net 5 **everything**! (Well, except for class library projects - those are .Net Standard 2.1).
- Entity Framework (EF) Core 5
- AutoMapper for easy conversion between domain and other model types.
- FluentValidation for consistent approach to data validation.
- API Versioning - Microsoft now [has your back](https://github.com/microsoft/aspnet-api-versioning). It's much easier than it used to be!


## To Do
- [x] Add API Versioning.
- [ ] Add data caching or make db queries dynamic so it doesn't load all 300+ records on each call.
- [ ] Add interstate rate logic.
- [ ] Add food+drug rate logic.