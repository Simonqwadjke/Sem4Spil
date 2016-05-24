
SELECT Name, Email, Age, Country, Ranking, Level, Lastlogin FROM UserData WHERE Username = 'kanut' AND Password = 'F4FC41C034AE5FB43B209B9EE2B85A91'

SELECT XLocation, YLocation, type, Level FROM Buildings WHERE UserID = 0

--update userdata set LastLogin = null

--insert into userdata(userid,name,username,password,email,age,country,ranking,level) values(1,'knud','kanut','pass','nope@haha','2200-1-1','denemark',1,1)
--insert into Buildings(buildingid, userid, xlocation, ylocation, type, level) values(0, 0, 0, 0, 'HeadQuaters', 1)
--insert into Groups(Userid, groupid) values(0, 0)
--insert into Units(unitid, groupid, type) values(0, 0, 'Tank')

select * from userdata
select * from Buildings
select * from groups
select * from units