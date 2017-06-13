/*To create table*/
create table VisitingFaculty
(
VisitingId int identity(1,1) not null primary Key ,
VisitingName nvarchar(30) not null,
VisitingGander nvarchar(15) not null,
VisitingCNIC nvarchar(20) not null,
VisitingQualification nvarchar(50) null,
VisitingCellNo nvarchar(50) not null,
VisitingEmail nvarchar(50) null,
AddedBy nvarchar(100)
)
insert into VisitingFaculty values('Wajid','Male','498-48555-2','MCS','4554','dskf@df.nf','sjflkjds')
insert into VisitingFaculty values('Hanif','Male','3345-3459-6','MCS','455-464','etre@df.nf','sjflkjds')
insert into VisitingFaculty values('Muddasir','Male','8927-4766-9','MCS','455-564','fdg@df.nf','dgd')
insert into VisitingFaculty values('Tania Irshad','Female','45-48595-2','MCS','4543554','ds45fkf@df.nf','sjflkjds')
insert into VisitingFaculty values('Lafeef Bajwa','Male','357-3459-6','MCS','455-46344','tete@df.nf','sjflkjds')
insert into VisitingFaculty values('Nosheen','Female','827-465436-9','MCS','453455-564','dsfg@df.nf','dgd')
/*** Procedure to Select All Visiting Faculty***/
create proc getAllVisitingFaculty
as
begin
	select * from VisitingFaculty
end
/*** Procedure to select single Visiting Faculty By ID****/
create proc getVisitingFacultyById 
@id int
as
begin
  select * from VisitingFaculty where VisitingId=@id
end
/****Procedure To Insert or Update Faculty****/
create proc insertUpdateVisitingFaculty
@VId int,
@VName nvarchar(30),
@VGander nvarchar(15),
@VCNIC nvarchar(20),
@VQualification nvarchar(50),
@VCellNo nvarchar(50),
@VEmail nvarchar(50),
@AddedBy nvarchar(100)
as
Begin
 if EXISTS(select * from VisitingFaculty where VisitingId=@VId)
 begin
 update VisitingFaculty set
 VisitingFaculty.VisitingName =@VName ,
 VisitingFaculty.VisitingGander =@VGander ,
 VisitingFaculty.VisitingCNIC =@VCNIC ,
 VisitingFaculty.VisitingQualification =@VQualification ,
 VisitingFaculty.VisitingCellNo =@VCellNo ,
 VisitingFaculty.VisitingEmail =@VEmail ,
 VisitingFaculty.AddedBy =@AddedBy 
 where VisitingId=@VId
 End
 else
  begin
  insert into VisitingFaculty (VisitingName ,VisitingGander, VisitingCNIC ,VisitingQualification ,VisitingCellNo ,VisitingEmail ,AddedBy )
  Values
  (@VName,@VGander, @VCNIC,@VQualification,@VCellNo,@VEmail,@AddedBy)
 end
 end
 /******Procedure to Delete Record By ID*****/
 create proc deleteVisitingFacultyByID
 @id int
 as
 begin
	delete from VisitingFaculty where VisitingId =@id
 end
 /******Procedur To Delete All Records ******/
 create proc deleteAllVisitingFaculty
 as
 Begin
	Delete from VisitingFaculty
 End
 /*****Procedur to Delete Visiting Faculty Table******/
 create proc truncateVisitingFaculty
 as
 begin
 drop table VisitingFaculty
 end