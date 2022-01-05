**Facade Pattern**

*"Provide an unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use"*

Example:

In this example we implement WeataherFacade Interfaces wich provides GetTempInCity Method, On concrete Facade we call ConverterService, GeoLookupService, WeatherService dependencies to calculate Interface Method.

![DesingPatterns-Facade](https://user-images.githubusercontent.com/11037848/148261754-7ea86bc3-e369-49fe-b2fc-0ce5c4c5dec1.png)
