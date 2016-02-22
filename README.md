# TodoList

A simple TodoList to help teach TDD. This is a start implementation intended to be continued with the following instructions:


## Console application that handle a list of todo items.

Reqirements:
* The list of items are first displayed with the form "\<id\> \<item text\>" where \<id\> is a unique number for the item. After that take commands, which will update the list
* Add item with command "add \<item text\>"
* Update an item with command "text \<id\> \<new item text\>" with the id the same as returned from list
* Complete an item with command "complete \<id\>" with the id the same as returned from list
* Close the application with "quit"


These next couple of requirements can be used as a next step. They should not be shown before the above is implemented!
Add pomodoros
* Each item should have the form "\<item text\> \<pomodoros\>" where pomodoros is an integer with the number of pomodoros to complete it
* Complete an pomodoro "pomodoro \<id\>" will decrese the number of pomodoros for the item of id with 1, if pomodoros become 0 remove the item
* Update the number of pomodoros for an item with "pomodoro \<id\> \<new number\>"
