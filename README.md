# ODataBookStore

## Overview

ODataBookStore is a sample ASP.NET Core application that demonstrates the use of OData with Entity Framework Core. The project includes a web client that interacts with the OData API to perform CRUD operations on a collection of books.

## Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 or later

## Getting Started

### Clone the Repository

```
git clone https://github.com/gnaohuv22/Lab01_BookStoreOData8.git 
cd Lab01_BookStoreOData8
```


### Build and Run the API

1. Open the solution in Visual Studio.
2. Set `ODataBookStore` as the startup project.
3. Press `F5` to build and run the API.

### Build and Run the Web Client

1. Open the solution in Visual Studio.
2. Set `ODataBookStoreWebClient` as the startup project.
3. Press `F5` to build and run the web client.

## Project Structure

### ODataBookStore

- **Controllers**: Contains the API controllers.
- **Models**: Contains the data models and the `BookStoreContext` for Entity Framework Core.
- **Program.cs**: Configures the application and OData services.

### ODataBookStoreWebClient

- **Controllers**: Contains the MVC controllers for the web client.
- **wwwroot**: Contains static files like JavaScript and CSS.
- **Views**: Contains the Razor views for the web client.
- **Program.cs**: Configures the web client application.

## Key Features

- **OData Integration**: Supports OData queries like `$select`, `$filter`, `$count`, `$orderby`, and `$expand`.
- **Entity Framework Core**: Uses an in-memory database for simplicity.
- **CRUD Operations**: Supports Create, Read, Update, and Delete operations on books.
- **Swagger**: Integrated Swagger UI for API documentation and testing.

## Dependencies

- [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)
- [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.md) file for details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## Contact

For any questions or feedback, please contact [hoangmeo1905@gmail.com](mailto:hoangmeo1905@gmail.com).

