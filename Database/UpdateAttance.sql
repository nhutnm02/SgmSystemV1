/****** Script for SelectTopNRows command from SSMS  ******/
select * from tbl_Attandance where UserID = 26 and AtMonth = 3
update tbl_Attandance set AtInOrOut = 1 where AtID = 4306
insert tbl_Attandance values (26,1,'2017-03-16',3,16,2017,'2017-03-16 08:00:00',N'Thứ Năm',1)
update tbl_Attandance set AtNote = N'Thứ Tư' where AtID = 5354

update tbl_Attandance set AtInOrOut = 1 where UeID > 1 and AtMonth = 3 and AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật' and UserID <> 30
select * from tbl_Attandance where UeID > 1 and AtMonth = 3 and AtNote <> N'Thứ Bảy' and AtNote <> N'Chủ Nhật'