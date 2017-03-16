select * from tbl_Attandance where convert(time(7),AtTime) > '08:40:00' and AtMonth = 3 and UeID = 1

 update tbl_Attandance set AtInOrOut = 1 where AtID = 1130 and convert(time(7),AtTime) > '08:40:00' and AtMonth = 3 and UeID = 1