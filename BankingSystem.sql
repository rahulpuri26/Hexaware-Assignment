-- creating database named HMBank 
create database HMBank;
-- using that database
use HMBank;

-- create Table for Customers
create table Customers (
    CustomerId int primary key,  
    FirstName varchar(50) not null,
    LastName varchar(50) not null,  
    DateOfBirth date not null, 
    Email varchar(100) unique not null,
    PhoneNumber int not null,  
    Address varchar(255)        
);

-- create Table for Accounts
create table Accounts (
    AccountNumber int primary key, 
    CustomerId int not null,  
    AccountType varchar(50) not null,  
    Balance int not null,
    foreign key (CustomerId) references Customers(CustomerId)
);

-- create Table for Transactions
create table Transactions (
    TransactionId int primary key,  
    AccountNumber int,  
    TransactionType varchar(50) not null, 
    Amount int not null,
    TransactionDate datetime not null, 
    foreign key (AccountNumber) references Accounts(AccountNumber)
);

-- inserting values into the customers table
insert into Customers (CustomerId, FirstName, LastName, DateOfBirth, Email, PhoneNumber, Address)
values
(1, 'Rahul', 'Puri', '2002-12-26', 'purirahul2002@gmail.com', 91154302, '14/10 Amritsar, Punjab'),
(2, 'Ramesh', 'Yadav', '1990-08-22', 'rameshyadav@gmail.com', 98765432, '456, Lucknow, Uttar Pradesh'),
(3, 'Suresh', 'Yadav', '1978-04-30', 'sureshyadav@example.com', 95678912, '456, Lucknow, Uttar Pradesh'),
(4, 'Ratikant', 'Shukla', '1995-09-10', 'ratikantshukla@example.com', 93456789, '782, Patna, Bihar'),
(5, 'Vinay', 'Pandat', '1998-12-01', 'vinaypandat@example.com', 67890123, '390, Mirzapur, Uttar Pradesh'),
(6, 'Sukhpreet', 'Kaur', '1982-03-17', 'kaursukhpreet@example.com', 78901234, '590, Amritsar, Punjab'),
(7, 'Anil', 'Joshi', '1992-07-25', 'joshianilr@example.com', 78345878, '890, Amritsar, Punjab'),
(8, 'Divya', 'Joshi', '1980-11-11', 'divyajoshi@example.com', 67893612, '133, Manali, Himachal Pradesh'),
(9, 'Lara', 'Dutta', '1989-05-06', 'duttalara@example.com', 98134979, '123, Mumbai, Maharashtra'),
(10, 'Aakash', 'Mandal', '1998-10-29', 'manadalakash@example.com', 93456789, '328, Pune, Maharashtra');

-- inserting sample values into accounts table
insert into Accounts (AccountNumber, CustomerId, AccountType, Balance)
values
(1, 1, 'savings', 10000),
(2, 2, 'current', 20000),
(3, 3, 'savings', 15000),
(4, 4, 'savings', 100),
(5, 5, 'current', 30000),
(6, 6, 'savings', 5000),
(7, 7, 'zero_balance', 0),
(8, 8, 'current', 25000),
(9, 9, 'savings', 12000),
(10, 10, 'current', 40000);

-- inserting sample values into transactions table
insert into Transactions (TransactionId, AccountNumber, TransactionType, Amount, TransactionDate)
values
(1, 1, 'deposit', 5000, '2024-09-07'),
(2, 1, 'withdrawal', 2000, '2024-09-06'),
(3, 2, 'deposit', 10000, '2024-09-07'),
(4, 2, 'transfer', 5000, '2024-09-08'),
(5, 3, 'withdrawal', 7000, '2024-09-06'),
(6, 4, 'deposit', 3000, '2024-09-10'),
(7, 5, 'transfer', 10000, '2024-09-11'),
(8, 6, 'deposit', 2000, '2024-09-12'),
(9, 7, 'withdrawal', 1000, '2024-09-13'),
(10, 8, 'deposit', 15000, '2024-09-14');

select * from transactions
drop table customers
-- sql queries task 2 ****************
/*
-- 1) Write a SQL query to retrieve the name, account type and email of all customers
select customers.first_name,  customers.last_name, customers.phone_number,customers.email, 
    accounts.account_type
from customers , accounts 
where customers.customer_id = accounts.customer_id
 
--2) 2. Write a SQL query to list all transaction corresponding customer.
select c.customer_id,c.first_name, c.last_name,
       t.transaction_id,t.transaction_type,t.amount,t.transaction_date
from customers c, accounts a, transactions t
where  c.customer_id = a.customer_id
    and a.account_id = t.account_id
 
--3) 3. Write a SQL query to increase the balance of a specific account by a certain amount.
update accounts
set balance = balance + 5000
where account_id = 5

--4) Write a SQL query to Combine first and last names of customers as a full_name.
select 
     concat_ws(' ',first_name,last_name)  as full_name
from customers
  
--5) Write a SQL query to remove accounts with a balance of zero where the account type is savings.
alter table transactions
add constraint FK__transactions__account_id
foreign key (account_id) 
references accounts(account_id)
on delete cascade

insert into accounts values ( 14, 5, 'savings', 0) -- run this query alone
delete from accounts
where account_type = 'savings' and balance = 0

--6) Write a SQL query to Find customers living in a specific city.
   
select * from customers
where address like '%Amritsar%'

--7)  Write a SQL query to Get the account balance for a specific account.
select balance , customer_id
from accounts
where account_id = 5

--8)  Write a SQL query to List all current accounts with a balance greater than $1,000.

select account_id, balance, account_type
from accounts
where account_type = 'current' and balance > 1000

--9) Write a SQL query to Retrieve all transactions for a specific account.
select *
from transactions where account_id = 6

--10) Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
select  customer_id,account_id, balance,
(balance * 0.05) as [interest accrued ]
from accounts
where account_type = 'savings'


--11)Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.
insert into accounts (account_id, customer_id, account_type, balance)values
(11, 1, 'current', -5000),  
(12, 2, 'savings', -3000)

declare @overdraft_limit INT = -100
select  * from accounts
where balance < @overdraft_limit


--12) Write a SQL query to Find customers not living in a specific city.
select * from customers
where address not like '%Amritsar%'

-- Task 3 **************


--1) Write a SQL query to Find the average account balance for all customers.
select avg(balance) as average_balance_customers from accounts


--2) Write a SQL query to Retrieve the top 10 highest account balances.

select top 10 * from accounts
order by balance desc

--3) Write a SQL query to Calculate Total Deposits for All Customers in specific date.

select sum(amount) as total_deposits ,count(*) as[Number of Transactions]
from transactions 
where transaction_type = 'deposit'
and transaction_date = '2024-09-07'

--4) Write a SQL query to Find the Oldest and Newest Customers.
-- Find the Oldest Customer
select top 1 first_name, last_name, dob
from customers
order by dob asc

-- Find the Newest Customer
select top 1 first_name, last_name, dob
from customers
order by dob desc

--5)Write a SQL query to Retrieve transaction details along with the account type.
select * from 
    transactions as t, accounts as a
where t.account_id = a.account_id


--6) Write a SQL query to Get a list of customers along with their account details.
select c.customer_id, concat(c.first_name,' '  ,c.last_name) as [Name], a.* from 
  customers as c, accounts as a
  where c.customer_id = a.account_id


--7) Write a SQL query to Retrieve transaction details along with customer information for a specific account.
select t.transaction_id,  t.transaction_type, t.amount, t.transaction_date, 
    c.customer_id, c.first_name, c.last_name, c.email, 
    a.account_id, a.account_type, a.balance
from transactions t , accounts a, customers c
where  t.account_id = a.account_id  and a.customer_id = c.customer_id and a.account_id = 5

--8) Write a SQL query to Identify customers who have more than one account.
insert into accounts values (13 , 2, 'savings', '10050'),
(14,1,'current', '1200')

select  customer_id,  count(account_id) AS [account count]
from  accounts
group by customer_id 
having  count(account_id) > 1

--9) Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
select 
(select sum(amount) from transactions where transaction_type = 'deposit') - 
(select sum(amount) from transactions where transaction_type = 'withdrawal')
as difference

--10) Write a SQL query to Calculate the average daily balance for each account over a specified period.
select  a.account_id,  AVG(t.amount) as [Average Daily Balance]
from  accounts a
inner join transactions t on a.account_id = t.account_id
where t.transaction_date between '2024-09-01' AND '2024-09-30' 
group by a.account_id

--11)  Calculate the total balance for each account type.
select account_type,sum(balance) as [total balance]
from accounts 
group by account_type 

--12) Identify accounts with the highest number of transactions order by descending order.
select  t.account_id, count(t.transaction_id) as [Transactions Count]
from transactions t 
group by t.account_id
order by [Transactions Count] desc

--13) List customers with high aggregate account balances, along with their account types.
select  c.customer_id, c.first_name, c.last_name, a.account_type, sum(a.balance) as [Aggregate]
from customers c
join accounts a on c.customer_id = a.customer_id
group by c.customer_id, c.first_name, c.last_name, a.account_type
order by [Aggregate] desc

--14) Identify and list duplicate transactions based on transaction amount, date, and account.
insert into transactions (transaction_id, account_id, transaction_type, amount, transaction_date)
values
(11, 1, 'deposit', 5000, '2024-09-07')

select account_id, amount, transaction_date, count(*) as [Duplicate Count]
from transactions
group by account_id, amount, transaction_date
having count(*) > 1




--Task 4 ********




--1) Retrieve the customer(s) with the highest account balance.

select c.customer_id, c.first_name, c.last_name, c.email, a.balance
from customers c
join accounts a on c.customer_id = a.customer_id
where a.balance = (select max(balance) from accounts)

--2) Calculate the average account balance for customers who have more than one account

select customer_id, avg(balance) as [Average balance]
from accounts
group by customer_id
having count(account_id) > 1

--3) Retrieve accounts with transactions whose amounts exceed the average transaction amount.

select distinct a.account_id, a.account_type, t.transaction_id, t.amount
from accounts a
join transactions t on a.account_id = t.account_id
where t.amount > (select avg(amount) from transactions)


--4) Identify customers who have no recorded transactions.
select customer_id, c.first_name, c.last_name from customers c 
where customer_id in(
select customer_id from accounts
where account_id not in(
select account_id from transactions
))  

-- these customer ids have multiple account and those account does not have transactions

--5) Calculate the total balance of accounts with no recorded transactions.
select sum(balance) as [Total Balance], account_id
from Accounts
where account_id not in (select account_id from Transactions)
group by account_id


--6) Retrieve transactions for accounts with the lowest balance.

select a.account_id, a.balance, t.transaction_id, t.transaction_type, t.amount, t.transaction_date
from accounts a
left join transactions t on a.account_id = t.account_id
where a.balance = (select min(balance) from accounts where balance >= 0)

--7) Identify customers who have accounts of multiple types.

select c.customer_id, c.first_name, c.last_name
from customers c
join accounts a on c.customer_id = a.customer_id
group by c.customer_id, c.first_name, c.last_name
having count(distinct a.account_type) > 1


--8) Calculate the percentage of each account type out of the total number of accounts.

select account_type, 
       count(*) * 100.0 / (select count(*) from accounts) as percentage
from accounts
group by account_type


--9) Retrieve all transactions for a customer with a given customer_id.
select transaction_id, transaction_type, amount, transaction_date
from transactions
where account_id in (select account_id from accounts where customer_id = 5)

--10) Calculate the total balance for each account type, including a subquery within the SELECT clause.
select account_type, 
       (select sum(balance) 
        from accounts a 
        where a.account_type = accounts.account_type) as [Total Balance]
from accounts
group by account_type
*/