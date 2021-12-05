# Online-Book-Library-POS-System
An online library POS system project  hosted in smarterasp.net made for school's final assesment.

A website written in C#, ASP.NET, JS. It has an interface both for the employees and users. 

Users - Can order a book, cancel an order, edit an order, create an account, delete an account, and edit their account.
Employees - Can manage the orders, track the orders, and manage the accounts of the users.

What makes the website a good POS is that the book's quantities are dynamic and updated in real time. Meaning that when a user buys a book that only has 1 stock left,
any other users would see the book as an "Out of Stock" item. Even if it isn't out of stock, the book's available quantity are also displayed on the website. So if 
a user buys a book having 50 stocks, it would then be updated into 49 once a user buys it. There are also other good features like showing the best authors, best selling books,
genres, etc. Most of which were done by using a little bit complex statements in MS SQL. 
