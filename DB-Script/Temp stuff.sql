
SELECT Name, Email, Age, Country, Ranking, Level, Lastlogin FROM UserData WHERE Username = 'kanut' AND Password = 'F4FC41C034AE5FB43B209B9EE2B85A91'

SELECT XLocation, YLocation, type, Level FROM Buildings WHERE UserID = 0

select type from Units where groupid in (select groupid from groups where userid = 0)

--update units set groupid = 1 where unitid = 1

--insert into userdata(userid,name,username,password,email,age,country,ranking,level) values(1,'knud','kanut','pass','nope@haha','2200-1-1','denemark',1,1)
--insert into Buildings(buildingid, userid, xlocation, ylocation, type, level) values(0, 0, 0, 0, 'HeadQuaters', 1)
--insert into Groups(Userid, groupid) values(0, 0)
--insert into Units(unitid, groupid, type) values(0, 0, 'Tank')
--insert into Units(unitid, groupid, type) values(1, 0, 'Rifleman')
--insert into Upgrades(userid, damage, armor, resource, rifleman, tank) values(0, 1, 1, 1, 1, 1)
--insert into invaders(userid, invaderid) values(0,0)
--insert into battles(battleid, defenderid, attackerid, battleoutcome, plunderediron, plunderedwood) values(0, 0, 0, 'nope', 0, 0)

select * from userdata
select * from Buildings
select * from groups
select * from units
select * from upgrades
select * from invaders
select * from battles