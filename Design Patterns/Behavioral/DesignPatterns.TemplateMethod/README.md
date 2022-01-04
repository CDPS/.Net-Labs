**Tempalete Method Pattern**

*"Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets sub-classes redefine certain steps of an alogorithm without changing the algorithm sctructure"*


*"The Template Method Pattern turns and algorithm into a series of indiviuals methods and keeps the structure of your base algorithm intact, the code that varies is split between different implementations and you can eliminate code duplication by pulling up the steps with similar implementation into the superclass housing the template method"*

Example:

In this impelementation we implement a GameLoaderAlgorithm, where we define some base steps that the algorithm must follow, also on BaseGameLoader class we define a public function load() wich calls all the function we define in the class in the order we expected. Finally we got to concrete implementation for the GameLoader, one for WoW and other for Diablo. see diagrama bellow

![DesingPatterns-TempalteMethod](https://user-images.githubusercontent.com/11037848/148094742-3bdfaafb-bba7-4c66-8225-0310eb7fbae5.png)

to learn in more detail, please check: https://www.youtube.com/watch?v=cGoVDzHvD4A
