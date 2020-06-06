use Laba;
Create table Person(
id int identity(1,1) primary key,
login nvarchar(300) not null,
password nvarchar(300) not null);
create table PersonInfo(
Nick nvarchar(300) primary key,
Surname nvarchar(300) not null,
age int not null);