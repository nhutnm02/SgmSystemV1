go
USE master
GO
--
IF EXISTS (select name from sys.databases where name = 'SGM') DROP DATABASE SGM
--
GO
CREATE DATABASE SGM
--
GO
USE SGM
go
create table tbl_Admin(
	AdminID int primary key identity(1,1),
	AdminName varchar(50),
	AdminPass varchar(50),
	AdminDes nvarchar(100)
)
go
insert into tbl_Admin values ('admin','123321', null)
go
create table tbl_Role(
	RoID int primary key identity(1,1),
	RoName nvarchar(50) unique,
	RoDes nvarchar(100)
)
go
insert into tbl_Role values ('Administrator',N'Toàn bộ chức năng.')
go
create table tbl_Users(
	UserID int primary key identity(1,1),
	UserName varchar(50) not null,
	UserPass varchar(20) not null,
	UserFullName nvarchar(200),
	UserAddress nvarchar(200),
	UserPhone varchar(50),
	UserExtention varchar(50),
	UserEmail varchar(50) unique,
	UserDOB date,
	UserCreateDate datetime default getdate(),
	UserComputer varchar(50),
	UserStatus bit,
	GroupID int,
	UserJoinDate date default getdate()
)
go
insert into tbl_Users values 
('nhutnm','123123',N'Nguyễn Minh Nhựt',N'178 Phan Đăng Lưu, P.3, Phú Nhuận','0932132370','2055', 'nhutnm@saigonmice.vn','02-02-1991',null,'nhutnm',1,3,'2016-05-02')
go
create table tbl_UserRole(
	UrID int primary key identity(1,1),
	RoID int,
	UserID int,
)
go
insert into tbl_UserRole values (1,1)
go
create table tbl_Attandance(
	AtID int primary key identity(1,1),
	UserID int,
	AtInOrOut int,
	AtDateCheckIn date,
	AtMonth int,
	AtDay int,
	AtYear int,
	AtTime datetime,
	AtNote nvarchar(200),
	UeID int
)
go
create table tbl_Group(
	GroupID int primary key identity(1,1),
	GroupCode varchar(10),
	GroupName nvarchar(100),
	GroupDes nvarchar(200),
	GroupStatus bit
)
go
insert tbl_Group values 
('BO',N'Lãnh Đạo',N'Các lãnh đạo phòng', 1),
('KT',N'Kế Toán',N'Kế toán của phòng', 1),
('IT',N'IT',N'IT của phòng',1),
('DH',N'Điều hành',N'Điều hành của phòng',1),
('D1',N'Kinh Doanh 1','Nhóm Kinh Doanh 1', 1),
('D2',N'Kinh Doanh 2','Nhóm Kinh Doanh 2', 1),
('D3',N'Kinh Doanh 3','Nhóm Kinh Doanh 3', 1),
('D4',N'Kinh Doanh 4','Nhóm Kinh Doanh 4', 1),
('EV',N'Event Dept','Nhóm Event', 1),
('TG',N'Tour Guide','HDV', 1)
go
create table tbl_YearCalendar(
	CalDate date not null
)
go
create table tbl_Event(
	EventID bigint primary key identity(1,1),
	EventName nvarchar(200),
	EventNote nvarchar(200)
)
go
create table tbl_UserEvent(
	UeID int primary key identity(1,1),
	EventID int,
	UserID int,
	UeNote nvarchar(200),
	UeCreateDate datetime default(getdate()),
	UeWillExpires datetime,
	UeDateExpires datetime,
	UeCount int,
	UeLeaderOk bit default(0),
	UeOk bit default(0)
)
go
create proc proc_as_UserCheckIn(
	@UserID int,
	@UserNote nvarchar(200) = null,
	@UserEvent int = 0,
	@Result int output
)
as
begin
	set nocount off
	declare @Err int
	declare @timeCheck time
	set @timeCheck = '08:40:00'

	declare @inOrOut int
	declare @dateCheck date
	declare @dateMonth int
	declare @dateDay int
	declare @dateYear int
	declare @dateTime time
	declare @dateAtt date

	set @dateAtt = (select TOP(1) AtDateCheckIn from tbl_Attandance where UserID = @UserID)
	set @dateCheck = (select getdate())
	set @dateMonth = (select DATEPART(MM,getdate()))
	set @dateDay = (select DATEPART(dd,getdate()))
	set @dateYear = (select DATEPART(yyyy,getdate()))
	set @dateTime = (select getdate())

	if(@dateAtt = @dateCheck)
	begin
		set @Result = 1;
	end
	else
	begin
	if(convert(time(7),@dateTime) > @timeCheck)
		begin
			set @inOrOut = 0
		end
	else
		begin
			set @inOrOut = 1
		end

	insert into tbl_Attandance	(UserID,AtInOrOut,AtDateCheckIn,AtMonth,AtDay,AtYear,AtTime,AtNote,UeID) values (@UserID, @inOrOut,@dateCheck,@dateMonth,@dateDay,@dateYear,@dateTime,@UserNote,@UserEvent)
	set @Result = 0;
	end
	set @Err = @@ERROR
	return @Err
end
go
create proc proc_as_UserCongTac(
	@UserID int,
	@AtDate date,
	@AtNote nvarchar(200) = null,
	@UserEvent int = 0,
	@CongType int,
	@Result int output
)
as
begin
	declare @AtMonth int
	declare @AtDay int
	declare @AtYear int
	declare @IsInsert int

	set @AtMonth = (select DATEPART(MM,getdate()))
	set @AtDay = (select DATEPART(dd,getdate()))
	set @AtYear = (select DATEPART(yyyy,getdate()))
	
	set @IsInsert = (select Count(UserID) from tbl_Attandance where UserID = @UserID and AtDateCheckIn = @AtDate)

	if(@IsInsert = 0)
	begin
		insert into tbl_Attandance		(UserID,AtInOrOut,AtDateCheckIn,AtMonth,AtDay,AtYear,AtTime,AtNote,UeID) 
		values 
		(@UserID, @CongType,@AtDate,@AtMonth,@AtDay,@AtYear,(select getdate()),@AtNote,@UserEvent)
		set @Result = (select SCOPE_IDENTITY())
	end
	else
	begin
		declare @IsSatSun int
		set @IsSatSun = (select DATEPART(dw,@AtDate))
		if(@IsSatSun = 1 or @IsSatSun = 7)
			begin
				set @CongType = 2
			end
		else
			begin
				set @CongType = 1
			end
		update tbl_Attandance set AtInOrOut = @CongType where UserID = @UserID and AtDateCheckIn = @AtDate
		set @Result = 0
	end
end
go
create proc proc_as_UpdateAttandaceWithEvent
(
	@AtID int,
	@AtInOrOut int,
	@UeID int
)
as
begin
	set nocount off
	declare @Err int

	update tbl_Attandance set AtInOrOut = @AtInOrOut, UeID = @UeID where AtID = @AtID

	set @Err = @@ERROR
	return @Err
end
go
create proc proc_as_DeleteAttandanceAndUserEvent
(
	@UeID int,
	@UserID int
)
as
begin
	set nocount off
	declare @Err int
	begin tran
		delete tbl_UserEvent where UeID = @UeID and UserID = @UserID
		delete tbl_Attandance where UserID = @UserID and UeID = @UeID
	commit
	set @Err = @@ERROR
	return @Err

end
go
create proc proc_as_AcceptUpdateAttanceDanceForUser
(
	@UserID int,
	@UeType int,
	@UeID int
)
as
begin
	set nocount off
	declare @Err int
	declare @CongThem int
	declare @CongPhep int
	set @CongThem = 2
	set @CongPhep = 3
	begin tran
		if(@UeType = 2)
			begin
				update tbl_Attandance set AtInOrOut = @CongPhep where UeID = @UeID and UserID = @UserID and AtNote not like N'Chủ Nhật' or AtNote not like N'Thứ Bảy'
				
			end	
		else
			begin
				update tbl_Attandance set AtInOrOut = @CongThem where UeID = @UeID and UserID = @UserID and AtNote like N'Chủ Nhật' or AtNote like N'Thứ Bảy'
				update tbl_Attandance set AtInOrOut = 1 where UeID = @UeID and UserID = @UserID and AtNote not like N'Chủ Nhật' and AtNote not like N'Thứ Bảy'
			end
		update tbl_UserEvent set UeOk = 1 where UeID = @UeID and UserID = @UserID
	commit tran
	set @Err = @@ERROR
	return @Err

end
go


