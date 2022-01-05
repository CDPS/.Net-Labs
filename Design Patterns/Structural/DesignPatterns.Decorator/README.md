**Decorator Pattern**

*"Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality"*

*"Wraps an existing object, allowing you to add a new functionality to that object without altering its structure, assign extra behaviors to your object at runtime without breaking the code that uses that object. Using Decorator Pattern we apply the Single Responsibility and Open-Closed principles, becuase each behavior is isolated in a separate class, and you have the ability to introduce new decorators without modifying existing classes"*

Example:

In this example we implement the decorator pattern on a Http Weather Service, we add two new features to the request wich are Logging service and Cache Service. See Diagram bellow 

![DesingPatterns-Decorator](https://user-images.githubusercontent.com/11037848/148302684-fd879f7d-6b8c-4085-a440-61c86acc3794.png)

to learn in more detail, please check: https://www.youtube.com/watch?v=v6tpISNjHf8
