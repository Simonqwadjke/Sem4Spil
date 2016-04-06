use dmab0914_2Sem_7

create table UserData
(
UserID		int NOT NULL,
Name		varchar(20) NOT NULL,
Username	varchar(30) NOT NULL,
Password	varchar(50) NOT NULL,
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
BattleID	int NOT NULL,
DefenderID	int NOT NULL,
AttackerID	int NOT NULL,
BattleOutcome	varchar(10) NOT NULL,
PlunderedWood	int NOT NULL,
PlunderedIron	int NOT NULL,
primary key (BattleID),
foreign key (DefenderID) references UserData(UserID),
foreign key (AttackerID) references UserData(UserID)
);