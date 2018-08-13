Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
	Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User  adds a new hotel and then  verifies if hotel is present by providing proper inputs
Given User provided valid Id '<id>'  and '<name>'for hotel
And User has added required details for hotel
And User has called AddHotel api
When User calls GetHotelById api and passes Id'<id>'
Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 4  | hotel4 |




Scenario Outline: User adds multiple hotels in database and checks for them 
Given User provided valid Id '<id>'  and '<name>'for hotel
And User has added required details for hotel
And User has called AddHotel api
Given User provided valid Id '<id1>'  and '<name1>'for hotel
And User has added required details for hotel
And User has called AddHotel api
When User calls GetAllHotels api
Then Then Hotel with name '<name>' and '<name1>' should be present in the response


Examples: 
| id | name  | id1 | name1 |
| 1  | hotel | 2   | hotel |
| 3  | hotel | 4   | hotel |


