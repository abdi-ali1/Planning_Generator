# Planning Generator

This is a Schedule Generator application built using the ASP.NET MVC framework in C#. The application is designed to generate schedules for employment agencies. The agencies can request employees with specific skills, degree level and availability, and the employees can provide their weekly availability.

## Features

The Schedule Generator application provides the following features:

- Employment agencies can request employees with specific skills, degree level, and availability.
- The host of the application can add new companies that need staff and new staff members.
- The application generates schedules based on the requests and availability.
- The application can create example schedules that are close to the ideal schedule of the company that requested it.
- Schedules can be viewed and printed by employment agencies.

## Architecture

The Schedule Generator application is built with a three-tier architecture, as follows:

### Presentation Layer

The presentation layer is responsible for presenting the user interface to the user. In this application, the presentation layer is built using ASP.NET MVC, which provides a framework for building web applications. The presentation layer includes the views and controllers that handle user input and output.

### Logic Layer

The logic layer contains the business logic of the application. In this application, the logic layer is responsible for generating schedules based on the employment agency requests and employee availability. The logic layer is implemented as a separate class library that can be used by other applications if necessary.

### Data Layer

The data layer is responsible for storing and retrieving data from the binary file. In this application, the data layer is implemented as a separate class library that provides methods for reading and writing data to and from the binary file. The data layer is responsible for reading and writing the schedule data to and from the binary file.

## Installation

To install the Schedule Generator application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio.
3. Build the solution to restore the NuGet packages.
4. Run the application from within Visual Studio or deploy to a web server.

## Contributing

If you would like to contribute to the Schedule Generator application, please follow these guidelines:

1. Fork the repository
2. Make your changes on a feature branch
3. Submit a pull request

## License

This application is licensed under the MIT license. See the LICENSE file for more details.
