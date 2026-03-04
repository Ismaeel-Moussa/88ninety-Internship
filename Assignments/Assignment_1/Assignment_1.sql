

create database University

use University

--Users
create table Users (UserId INT PRIMARY KEY, UserName VARCHAR(64) NOT NULL, FirstName VARCHAR(64) NOT NULL, LastName VARCHAR(64) NOT NULL, EmailAddress VARCHAR(128) NOT NULL, PhoneNumber VARCHAR(16) NOT NULL, Role VARCHAR(32) NOT NULL)

-- Courses
create table Courses (CourseId INT PRIMARY KEY, CourseName VARCHAR(100) NOT NULL, TeacherId INT NULL, StartDate DateTime NOT NULL, EndDate DateTime NOT NULL, SyllabusId NULL)


--Assignments
create table Assignments (AssignmentId INT PRIMARY KEY, CourseId INT NOT NULL, AssignmentTitle VARCHAR(128) NOT NULL, Description TEXT NULL, Weight float NOT NULL, MaxGrade INT NOT NULL, DueDate DATE NOT NULL)

--Comments
create table Comments(CommentId INT PRIMARY KEY, AssignmentId INT NOT NULL, CreatedByUserId int not null, CreatedDate DATETIME NOT NULL, CommentContent TEXT NULL)


--Grades
create table Grades (GradeId INT PRIMARY KEY, AssignmentId INT NOT NULL, StudentId INT NOT NULL, Grade INT NULL)


--Syllabus
create table Syllabus (SyllabusId INT PRIMARY KEY, Description TEXT NULL)


--Add Unique key for Email Address
ALTER TABLE Users
ADD CONSTRAINT UQ_EmailAddress UNIQUE (EmailAddress);

-- Requirments:

--#1
insert into Users (UserName,FirstName,LastName,EmailAddress,PhoneNumber,Role)
values 
('Ismaeel-Moussa','Ismaeel','Moussa','ismaeel.moussa1@gmail.com','+905346917747','Student'),
('Abdulsalam-Fateh','Abdulsalam','Fateh','fatehabdalsalam@gmail.com','+963958361088','Student'),
('Ahmad-Thaer-Ater','Ahmad','Ater','aeter520@gmail.com','+963946946565','Student'),
('Ihap-Abuwarda','Ihap','Abuwarda','ihababuwardah@gmail.com','+905355807082','Student'),
('Muhammed-Elrimi','Muhammed','Elrimi','mohamadrimi12345@gmail.com','+905343346036','Student'),
('Wasem-Alhariri','Wasem','Alhariri','wasemalhariri13@gmail.com','+963994801706','Student')


--#2
insert into Users (UserName,FirstName,LastName,EmailAddress,PhoneNumber,Role)
values 
('Sami-Hijazi','Sami','Hijazi','sami.hijazi@88ninety.com','+1(240)381-9639','Teacher'),
('Feryal-Tulaimat','Feryal','Tulaimat','feryal.tulaimat@88ninety.com','+905523381309','Teacher')

-- Add Foreign key Constranints
ALTER TABLE Courses
ADD FOREIGN KEY (SyllabusId) REFERENCES Syllabus(SyllabusId);

ALTER TABLE Courses
ADD FOREIGN KEY (TeacherId) REFERENCES Users(UserId);

ALTER TABLE Assignments
ADD FOREIGN KEY (CourseId) REFERENCES Courses(CourseId);

ALTER TABLE Grades
ADD FOREIGN KEY (AssignmentId) REFERENCES Assignments(AssignmentId);

ALTER TABLE Grades
ADD FOREIGN KEY (StudentId) REFERENCES Users(UserId);

ALTER TABLE Comments
ADD FOREIGN KEY (AssignmentId) REFERENCES Assignments(AssignmentId);

ALTER TABLE Comments
ADD FOREIGN KEY (CreatedByUserId) REFERENCES Users(UserId);

--#7
insert into Syllabus (Description)
values 
('Study fundamentals of sql'),
('Learn C# fundamentals'),
('Learn fundamentals of Entity Framework'),
('Learn Requests and Status code of web api'),
('Learn Components and state management in react')


--#3
insert into Courses (CourseName,TeacherId,StartDate, EndDate ,SyllabusId) 
values 
('SQL',7,'2026-12-03','2027-01-01',1),
('C#',8,'2026-09-03','2026-11-03',2),
('Entity Framework',7,'2025-03-03','2025-06-03',3),
('Web api',8,'2026-02-03','2026-09-03',4),
('React',7,'2026-01-03','2026-04-03',5)


--#4
insert into Assignments(CourseId,AssignmentTitle,Weight,MaxGrade,DueDate) 
values 
(5,'Learn Fundamentals React',20,100,'2026-08-06'),
(5,'Learn State',20,100,'2026-07-06'),
(5,'Learn Components',20,100,'2026-02-06'),
(5,'Learn UseEffect',20,100,'2026-01-06'),
(5,'Learn Conditional Rendering',20,100,'2026-09-06')


--#5
insert into Comments (AssignmentId, CreatedByUserId, CreatedDate, CommentContent)
values 
(1,1,'2026-03-03','It was very good'),
(12,2,'2026-01-03','It was very good'),
(8,3,'2026-06-03','It was very good'),
(22,4,'2026-03-08','It was very good'),
(25,5,'2026-07-03','It was very good'),
(16,6,'2026-11-03','It was very good'),
(6,4,'2026-12-03','It was very good'),
(19,1,'2026-02-03','It was very good'),
(23,2,'2026-07-10','It was very good'),
(14,3,'2026-03-15','It was very good')


--#6
insert into Grades (AssignmentId,StudentId,Grade)
values
(1,6,99),
(2,6,55),
(3,6,80),
(4,6,30),
(5,6,55),
(6,6,70),
(7,6,20),
(8,6,50),
(9,6,44),
(10,6,35),
(11,6,45),
(12,6,30),
(13,6,50),
(14,6,40),
(15,6,50),
(16,6,77),
(17,6,20),
(18,6,50),
(19,6,44),
(20,6,35),
(21,6,45),
(22,6,30),
(23,6,50),
(24,6,40),
(25,6,75)

--#8
select * from Courses

--#9
select * from Assignments
where CourseId = 1

--#10
select * from Users where Role = 'Student'

--#11
update Users set Role = 'Teacher'
where FirstName = 'Ismaeel'

--#12
delete from Comments where CommentId = 1

--#13
select u.UserId,a.CourseId,u.UserName,u.Role,a.AssignmentTitle,g.Grade 
from Users u
join Grades g
on u.UserId = g.StudentId
join Assignments a
on g.AssignmentId = a.AssignmentId
where u.Role = 'Student' and a.CourseId = 1

--#14
select a.CourseId,AVG(g.Grade) As [Average Grade Per Course]
from Grades g join Assignments a
on g.AssignmentId = a.AssignmentId
group by a.CourseId

--#15 
select * from Courses c
join Syllabus s
on c.SyllabusId = s.SyllabusId

--#16
select * from Comments c
join Assignments a
on c.AssignmentId = a.AssignmentId
where CourseId = 4

--#17
create procedure sp_AddNewStudent (@UserName varchar(64), @FirstName varchar(64), @LastName varchar(64), @EmailAddress varchar(128), @PhoneNumber varchar(16))
AS
begin
insert into Users (UserName,FirstName,LastName,EmailAddress,PhoneNumber,Role)
values 
(@UserName,@FirstName,@LastName,@EmailAddress,@PhoneNumber,'Student')
end

--#18
create procedure sp_AddNewAssignment (@CourseId int,@AssignmentTitle varchar(128),@Description text, @Weight float, @MaxGrade int, @DueDate date)
As 
begin
insert into Assignments (CourseId,AssignmentTitle,Weight,MaxGrade,DueDate) 
values (@CourseId,@AssignmentTitle,@Weight,@MaxGrade,@DueDate) 
end

--Add Check Constraint to make sure the assingment weight not to be above 100
ALTER TABLE Assignments
ADD CHECK (Weight<=100);

--#19
create function ufn_CalculateStudentGradeInCourse (@StudentId int, @CourseId int)
returns char
AS
begin
	declare @Grade AS int;

	select @Grade = AVG(Grade) from Grades g
	join Assignments a 
	on g.AssignmentId = a.AssignmentId
	where g.StudentId = @StudentId and a.CourseId = @CourseId 

	if (@Grade > 91)
		return 'A'
	else if (@Grade > 81)
		return 'B'
	else if(@Grade > 71)
		return 'c'
	else if (@Grade > 61)
		return 'D'
	else if(@Grade > 40)
		return 'E'


	return 'F'
end


--#20
create function ufn_CalculateStudentGPA(@StudentId int)
returns float
As
begin
	declare @GPA As float
	select @GPA = sum(e.CourseGPA)/4
	from
	(select 
	case 
		when r.Grade = 'A' then 4
		when r.Grade = 'B' then 3.5
		when r.Grade = 'C' then 3
		when r.Grade = 'D' then 2.5
		when r.Grade = 'E' then 2
		else 0
	end As CourseGPA
	from  (select dbo.ufn_CalculateStudentGradeInCourse(@StudentId,c.CourseId) As Grade
	from Courses c) r) e

return @GPA
end

select dbo.ufn_CalculateStudentGPA(6) as [Student GPA]












































