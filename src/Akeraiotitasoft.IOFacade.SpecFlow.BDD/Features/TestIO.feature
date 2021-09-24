Feature: TestIO

Scenario: Add two numbers
	Given the user types "input" followed by enter
	Given the user types "1" followed by enter
	Given the user types "add" followed by enter
	Given the user types "input" followed by enter
	Given the user types "2" followed by enter
	Given the user types "equals" followed by enter
	Given the user types "quit" followed by enter
	When I run the program
	Then the program terminates in less than 10 seconds
	Then the number of output lines is 41
	Then the value of output line 32 is "result = 3"

Scenario: Interactive add
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "1" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "add" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "2" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "equals" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "quit" followed by enter
	Then the number of output lines is 41
	Then the value of output line 32 is "result = 3"
	Then the program terminates in less than 2 seconds

Scenario: Interactive add 2
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "1" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "add" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "2" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the standard output is cleared
	Given the user types "equals" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Then the value of output line 0 is "result = 3"
	Given the user types "quit" followed by enter
	Then the program terminates in less than 2 seconds

Scenario: Interactive subtract
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "5" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "subtract" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "3" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the standard output is cleared
	Given the user types "equals" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Then the value of output line 0 is "result = 2"
	Given the user types "quit" followed by enter
	Then the program terminates in less than 2 seconds

Scenario: Interactive multiply
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "5" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "multiply" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "3" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the standard output is cleared
	Given the user types "equals" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Then the value of output line 0 is "result = 15"
	Given the user types "quit" followed by enter
	Then the program terminates in less than 2 seconds

Scenario: Interactive divide
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "12" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "divide" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "input" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the user types "3" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Given the standard output is cleared
	Given the user types "equals" followed by enter
	Then the standard input is blocked on wait in less than 2 seconds
	Then the value of output line 0 is "result = 4"
	Given the user types "quit" followed by enter
	Then the program terminates in less than 2 seconds

Scenario: Validate Menu
	When I run the program
	Then the standard input is blocked on wait in less than 2 seconds
	Then the number of output lines is 8
	Then the value of output line 0 is "-- MENU --"
	Then the value of output line 1 is "input) input a number"
	Then the value of output line 2 is "add) add command"
	Then the value of output line 3 is "subtract) subtract command"
	Then the value of output line 4 is "multiply) multiply command"
	Then the value of output line 5 is "divide) divide command"
	Then the value of output line 6 is "equals) equals command"
	Then the value of output line 7 is "quit) quit program"
	Given the user types "quit" followed by enter
	Then the program terminates in less than 2 seconds
