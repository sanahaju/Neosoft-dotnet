use petDb;
create table Customer(id int,Namee varchar(250),Zipcode int,Email varchar(250));
create table Login(id int,CustomerId int,Username varchar(250),Password varchar(250));

select * from Customer;
select * from Login;

create procedure CustomerRegistration @Namee @Zipcode @Email As insert into Customer(Namee,Zipcode,Email) values(@Namee,@Zipcode,@Email);
exec CustomerRegistration @Namee="sana",@Zipcode="123456",@Email="sanahaju1232gmail.com";

create procedure CustomerLogin @id @CustomerId @Username @Password As insert into Login(CustomerId,Username,Password) values(@CustomerId,@Username,@Password);
exec CustomerLogin @CustomerId="1",@Username="sanahaju",@Password="sana123";