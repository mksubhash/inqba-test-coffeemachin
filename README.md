# inqba-test-coffeemachin
Test for InQba
Develop a console application in .Net:

The aim of the coffee solution is to create a drink based on user input. You are required to provide the machine with the following capabilities:

Create a cappuccino drink. 
In order to make a cappuccino the user must provide the amount of sugar required. 
	A cappuccino requires 5 beans to make, 
	coffee requires 2 
	and a Latte requires 3.
Coffee should require the selection of whether a user would like Milk or not. We may assume other drinks always require milk.
Change the console app(user interface) so that a user has the ability to select more drinks whenever a drink is ready. The machine should only turn off when the user sends the command "off".
Implement tracking of the number of beans and remaining milk capacity in the machine. An appropriate message should be displayed should there be insufficient beans or milk remaining in the machine for the selection. 

Milk Requirements per drink: 
Coffee - 1 Milk unit, 
Latte - 2 Milk units, 
Cappuccino - 3 Milk units.
The machines maximum bean capacity is 25. The maximum milk capacity is 20.
 Pay special attention to the following:

SOLID.
Unit tests should be written where applicable.
Code readability. Imagine you are working in a team of developers that will need to maintain your code
 Bonus: Display a message to user when the bean capacity has reached 5 or lower, informing them of a low bean capacity.
