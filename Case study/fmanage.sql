create database fmanage;

use fmanage;

create table users (
    user_id int primary key ,
    username varchar(50) not null unique,
    password varchar(255) not null,
    email varchar(100) not null unique
)

create table expensecategories (
    category_id int primary key,
    category_name varchar(50) not null unique
)

create table expenses (
    expense_id int primary key ,
    user_id int not null,
    amount int not null,
    category_id int not null,
    date date not null,
    description varchar(255),
    foreign key (user_id) references users(user_id),
    foreign key (category_id) references expensecategories(category_id)
)

insert into users values 
(1,'rahulpuri', '12345', 'purirahul2002@gmail.com'),
(2,'tanmaybhatt16', '78609', 'tbhatt@com')


insert into expensecategories values 
(1, 'food'),
(2, 'transportation')


insert into expenses  values 
(1, 1, 100, 1, '2024-09-23', 'groceries'),
(2,2, 50, 2, '2024-09-24', 'bus ticket')

select * from users
select* from expensecategories
select* from expenses