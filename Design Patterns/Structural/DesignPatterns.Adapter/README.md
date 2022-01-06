**Adapter Pattern**

*"Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfces"*

*"Adapter use inheritance and composition to enalbe objects with incompatible interfaces to collaborate with one another, it creates a middlie-layer class that serves as a trasnlator. applies the Single Responsibility and Open-Closed Principles becuase the adapting behavior is now separated and we can introduce new adapter without breaking existing code"*

Example:

In this example we need to use a customer Displayer that only accepts JSONMessages, right now on the application we support XMLMessages. We Implement the Adapter Pattern to trasnform the XML message into JSON message

![DesingPatterns-Adapter](https://user-images.githubusercontent.com/11037848/148468158-600e8b02-e395-42d6-b506-1c294be49156.png)
