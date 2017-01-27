CREATE TABLE Accounts
(
	accountNumber varchar(255) PRIMARY KEY
);

CREATE TABLE BudgieUsers
(
	id int PRIMARY KEY,
	firstName varchar(255),
	lastName varchar(255),
	emailAddress varchar(255),
	dob int,
	Fk_accountNumber varchar(255) FOREIGN KEY REFERENCES [Accounts](accountNumber)
);

INSERT INTO Accounts VALUES('BB040191')
INSERT INTO Accounts VALUES('AN010494')
INSERT INTO Accounts VALUES('SN140792')
INSERT INTO Accounts VALUES('NL221292')
INSERT INTO Accounts VALUES('DM070694')
INSERT INTO Accounts VALUES('MR260993')
INSERT INTO Accounts VALUES('SK300792')
INSERT INTO Accounts VALUES('BM240888')
INSERT INTO Accounts VALUES('DK211289')

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (1,'Ben','Bowes','benjamin.bowes@fdmgroup.com',040191,'BB040191');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (2,'Andrew','Norman','andrew.norman@fdmgroup.com',010494,'AN010494');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (3,'Spencer','Newton','spencer.newton@fdmgroup.com',140792,'SN140792');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (4,'Nana','Li','nana.li@fdmgroup.com',221292,'NL221292');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (5,'Daniel','Mason','daniel.mason@fdmgroup.com',070694,'DM070694');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (6,'Mario','Reid','mario.reid@fdmgroup.com',260993,'MR260993');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (7,'Suleman','Khan','suleman.khan@fdmgroup.com',300792,'SK300792');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (8,'Bishan','Meghani','bishan.meghani@fdmgroup.com',240888,'BM240888');

INSERT INTO BudgieUsers (id,firstName,lastName,emailAddress,dob,Fk_accountNumber)
VALUES (9,'Daniel','Kloss','daniel.kloss@fdmgroup.com',211289,'DK211289');