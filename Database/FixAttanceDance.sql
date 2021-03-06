/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [AtID]
      ,[UserID]
      ,[AtInOrOut]
      ,[AtDateCheckIn]
      ,[AtMonth]
      ,[AtDay]
      ,[AtYear]
      ,[AtTime]
      ,[AtNote]
      ,[UeID]
  FROM [SGM].[dbo].[tbl_Attandance]

  select * from tbl_Attandance where AtMonth = 3 and UserId = 30

  update tbl_Attandance set AtInOrOut = 1 where AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật' and CONVERT(time(7),AtTime) <= '08:40:00'

  update tbl_Attandance set AtInOrOut = 0 where AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật' and CONVERT(time(7),AtTime) > '08:40:00'

  select * from tbl_Attandance where AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật' and UeID > 1
    update tbl_Attandance set AtInOrOut = 2 where AtNote = N'Thứ Bảy' or AtNote = N'Chủ Nhật' and UeID > 1
	update tbl_Attandance set AtInOrOut = 1 where AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật' and UeID > 1

	select * from tbl_Users where UserID = 27
	update tbl_Attandance set AtInOrOut = 1 where UserID = 1 and AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật'
	select * from tbl_UserEvent where UserId = 13

	update tbl_Attandance set AtInOrOut = 3 where UeID = 11
	update tbl_Attandance set AtInOrOut = 3 where UeID = 1017
	update tbl_Attandance set AtInOrOut = 3 where UeID = 2021
	update tbl_Attandance set AtInOrOut = 3 where UeID = 3029
	update tbl_Attandance set AtInOrOut = 3 where UeID = 4031

	select * from tbl_Attandance where UserID = 26
	update tbl_Attandance set AtInOrOut = 1 where AtID = 4306

	select * from tbl_Attandance