﻿Feature: timeand material
	As a turn up portal I would like to manage time and material effectively
@mytag
Scenario: create new time and material record
	Given I have logged in turn up loginpage successfully
	And I navigate to time and material
	When I create new time and material form 
	Then The record should be created successfully
	

Scenario: edit an existing time and material record
	Given I have logged in turn up loginpage successfully
	And I navigate to time and material
	When I edit an existing time and material
	Then The record should be edited successfully

Scenario: delete an existing time and material record
	Given I have logged in turn up loginpage successfully
	And I navigate to time and material
	When I delete an existing time and material
	Then The record should be deleted successfully



Scenario Outline: create multiple time and material record
	Given I have logged in turn up loginpage successfully
	And I navigate to time and material
	When I create time and material with below <code> and <Description>
	Then The record should be created with given values <code> and <Description> successfully 
	Examples: 
	| code  |   Description     |
	| test1  |   testdescription1 |
	| test2 |  testdescription2 |
		
	
	

