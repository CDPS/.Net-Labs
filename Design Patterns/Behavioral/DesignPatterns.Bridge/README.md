**Bridge Pattern**

- *"Decouple an abstraction from its implementation so that the two can vary independently"*
- *"Split a class hirearchy through composition to reduce couping"*

Example:

In this example we got a Movies Shopping, where we have two kinds of licenses (TwoDaysLicense and LifeLongLicense)

![DesingPatterns-Bidge](https://user-images.githubusercontent.com/11037848/147512899-29f41f45-d4c7-46f4-a573-a921c12beea1.png)

For some reason we got a new requeriment which we have to implement special disccounts (SeniorDiscount, MilitaryDiscount). One of the naive solutions will just to create a class for every type of license combine with every type of discounts, se diagram bellow:

![DesingPatterns-Bidge (1)](https://user-images.githubusercontent.com/11037848/147512966-bb7fe169-b7a4-4b3f-89c2-0b6aea9a9426.png)

this is a bad practice because as we add new discounts or license are added, the numbers of class will grow exponentially.

So applying Bridge Pattern we can separate class hireachy into disccounts and lincese, now they represent two differents aspects of the application and each of then serves their own porpuse. 

![DesingPatterns-Bridge](https://user-images.githubusercontent.com/11037848/147513370-0a69f0a3-0906-4324-a628-94eafc632945.png)

The bridge relation is just a composition relationship that allow us to vary the two parts of the hireachy independently.
