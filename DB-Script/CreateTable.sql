use dmab0914_2Sem_7

create table UserData
(
UserID		int NOT NULL,
Name		varchar(20) NOT NULL,
Username	varchar(30) unique NOT NULL,
Password	varchar(50) unique NOT NULL,
Email		varchar(50) NOT NULL,
Age			date,
Country		varchar(20) NOT NULL,
Ranking		int NOT NULL,
Level		int NOT NULL,
LastLogin	datetime,
primary key (UserID)
);

create table Invaders
(
UserID		int NOT NULL,
InvaderID	int NOT NULL,
primary key (UserID, InvaderID),
foreign key (UserID) references UserData(UserID),
foreign key (InvaderID) references UserData(UserID)
);

create table Battles
(
BattleID		int NOT NULL,
DefenderID		int NOT NULL,
AttackerID		int NOT NULL,
BattleOutcome	varchar(10) NOT NULL,
PlunderedWood	int NOT NULL,
PlunderedIron	int NOT NULL,
primary key (BattleID),
foreign key (DefenderID) references UserData(UserID),
foreign key (AttackerID) references UserData(UserID)
);

create table Upgrades
(
UserID		int NOT NULL,
Damage		int NOT NULL,
Armor		int NOT NULL,
Resource	int NOT NULL,
Rifleman	int NOT NULL,
Tank		int NOT NULL,
Primary key (UserID),
foreign key (UserID) references UserData(UserID)
);

create table Buildings
(
BuildingID	int NOT NULL,
UserID		int NOT NULL,
Xlocation	int NOT NULL,
Ylocation	int NOT NULL,
type		varchar(20),
level		int NOT NULL,
primary key (BuildingID),
foreign key (UserID) references UserData(UserID)
);

create table Groups
(
UserID		int NOT NULL,
GroupID		int Unique NOT NULL,
Primary key (UserID),
Foreign key (UserID) references UserData(UserID)
);

create table Units
(
UnitID		int NOT NULL,
GroupID		int NOT NULL,
type		varchar(20) NOT NULL,
primary key (UnitID),
foreign key (GroupID) references Groups(GroupID)
);