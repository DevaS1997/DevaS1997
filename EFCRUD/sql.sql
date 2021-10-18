use CourseDb


Select * from Cities
insert into Cities (CityName) values('Mumbai')

Select * from States
insert into States (StateName) values('Maharastra')

Select * from Countries
insert into Countries (CountryName) values('India')

Select * from Courses
insert into Courses (CourseName,Duration,Fees) values('Dot Net','60 hrs',15000.00)

select * from Students

alter table Students add Country int
alter table Students add State int
alter table Students add City int

alter table Students drop column CityId
alter table Students drop column StateId
alter table Students drop column CountryId

update Blogs set updatedby = 1  where Blogs.Id = 1

drop database CourseDb

select * from Users
select * from Roles
select * from Blogs
select * from Reviews

insert into Roles (RoleName) values('Teacher')

delete Blogs where Id = 4