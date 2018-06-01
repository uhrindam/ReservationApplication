CREATE TABLE CATEGORIES (
    CategoryName			varchar(255) 	NOT NULL,
	Price 					int,
    ProcessLengthInMunites 	int,
	CONSTRAINT PK_CATEGORIESPRIMARY 		PRIMARY KEY (CategoryName),
	CONSTRAINT CH_PLIM 						CHECK (ProcessLengthInMunites>0 
											AND ProcessLengthInMunites <=480)
);

CREATE TABLE USERS (
	NickName 		varchar(255) 	NOT NULL,
    FullName 		varchar(255) 	NOT NULL,
    EmailAddress 	varchar(255) 	NOT NULL,
	Passwd	 		varchar(255) 	NOT NULL,
	RegistrationDate DATETIME		NULL,
	IsAdmin 		bit 			DEFAULT 'false',
    CONSTRAINT PK_USERS 			PRIMARY KEY (NickName),
	CONSTRAINT CH_USERS				CHECK (LEN(Passwd)>=6)
);

CREATE TABLE APPOINTMENTS(
	ID				varchar(255)	NOT NULL,
	NickName 		varchar(255) 	NOT NULL,
	CategoryName 	varchar(255) 	NOT NULL,
	ReservationDate	DATETIME		NULL,
	CurrentPrice	int				NULL,
	StartingPont	DATETIME		NULL,
	EndingPoint		DATETIME		NULL,
	IsNotDeleted	bit				DEFAULT 'true'
	CONSTRAINT PK_APPOINTMENTS 		PRIMARY KEY (ID),
	CONSTRAINT FK_APP_NickName 		FOREIGN KEY (NickName) 
									REFERENCES USERS(NickName),
	CONSTRAINT FK_APP_CategoryName 	FOREIGN KEY (CategoryName) 
									REFERENCES CATEGORIES(CategoryName)
);

INSERT INTO CATEGORIES VALUES('Férfi hajvágás', 1500, 30)
INSERT INTO CATEGORIES VALUES('Szakáll vágás', 1000, 20)
INSERT INTO CATEGORIES VALUES('Nõi hajvágás', 2000, 45)
INSERT INTO CATEGORIES VALUES('Hajfestés', 2500, 60)
INSERT INTO CATEGORIES VALUES('Dauer', 2500, 60)
INSERT INTO CATEGORIES VALUES('Besütés', 3000, 90)
INSERT INTO CATEGORIES VALUES('Konty', 3000, 90)
INSERT INTO CATEGORIES VALUES('Összetett konty', 4000, 120)


INSERT INTO USERS VALUES ('admin', 'Admin Admin', 'admin@admin.admin', 'd033e22ae348aeb5660fc2140aec35850c4da997','2018-06-01 12:00:00','true')
INSERT INTO USERS VALUES ('farkasnorbi', 'Farkas Norbert', 'farkas.norbert@nemezazemailem.rg','72bbc07271b28606ac421605c81ce1795d32e1f5','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('hajravasember', 'Robert Downey', 'hajravasember@azthiszemezajelszavam.com', 'ee0630b33f1de43c3eb21d240a6402ba0e6434d3','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('husospogacsa', 'Sipos Aladár', 'pogi@pontezazemailem.com', '29425a053210c9e1df6fad3aaeb2b4af87fab536','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('loki', 'Loki A Jegorjas', 'ipos@valami.om', 'a5b23f338648cb6f21e2cc1284e4d1b7b930ac97','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('Mephisto', 'Mephisto Lajos', 'lajosamephisto@hathatahat.com', '95b987fe656b033ea8cb3d4d9483ece5c133e3e4','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('nemjutotteszembetöbbfelhasznalonev', 'Valaki Valahonnan', 'igen@nesdgsgdm.com', 'c984aed014aec7623a54f0591da07a85fd4b762d','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('nemszeretemaDCt', 'Halal Bruce Waynre', 'nemszeretemaDCt@egjenaDC.com', '4591d5369f2331570b1c84bbec7153b49bacc74f','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('pokemberfanboy', 'Peter Parker', 'Peter.Parker@webshooting.com', '368f976940775c710aec525fe1e349f8a1fb9a39','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('randomfelhasznalo', 'random Vagyok', 'random@ezegyemail.com', 'a3e6b448867c57bf9ede101ceeeec67fcbb55ead','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('siposgergo', 'Sipos Gergo', 'gergo.sipos@nemezazemailem.com','182b3881fd2570a66c7c93de893f81e92339706d','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('starwarsfanvagyok', 'luk skajvalker', 'go.sip@nemezajelszavam.com', '3970fa36c7fa71217a99f14e41012e58436b7d5d','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('StrongGuy', 'Armin az USBnyaku', 'USB.nyaku@gs.com', '7706aa466c007f35e08bf751c84aa9702b21e66d','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('thor', 'Chris Hemswoth', 'krisz.hemszfort@asfg.com', '22d5c8366e997e1927887b06a9458fcff7367ed1','2018-06-01 12:00:00','false')
INSERT INTO USERS VALUES ('uhrindam', 'Uhrin Ádám Attila', 'uhrin.adam@nemezazemailem.com', '3d4f2bf07dc1be38b20cd6e46949a1071f9d0e3d','2018-06-01 12:00:00','true')

INSERT INTO APPOINTMENTS VALUES('00001FH','uhrindam', 'Férfi hajvágás','2018-06-01 12:00:00', 1500, '2018-06-01 14:00:00', '2018-06-01 14:30:00','false')
INSERT INTO APPOINTMENTS VALUES('00002SV','uhrindam', 'Szakáll vágás', '2018-06-01 12:00:00', 1000, '2018-06-01 14:30:00', '2018-06-01 14:45:00', 'false')
INSERT INTO APPOINTMENTS VALUES('00003OK', 'loki', 'Összetett konty','2018-06-01 12:00:00', 4000, '2018-06-01 15:30:00', '2018-06-01 17:30:00', 'false')
INSERT INTO APPOINTMENTS VALUES('00004OK', 'loki', 'Összetett konty','2018-06-01 12:00:00', 4000, '2018-06-02 15:30:00', '2018-06-02 17:30:00', 'false')
INSERT INTO APPOINTMENTS VALUES('00005FH','uhrindam', 'Férfi hajvágás', '2018-06-01 12:00:00', 1500, '2018-06-03 12:00:00', '2018-06-03 12:30:00', 'false')
INSERT INTO APPOINTMENTS VALUES('00006SV','uhrindam', 'Szakáll vágás', '2018-06-01 12:00:00', 1000, '2018-06-03 12:30:00', '2018-06-03 12:45:00', 'false')
INSERT INTO APPOINTMENTS VALUES('00007SV','pokemberfanboy', 'Szakáll vágás', '2018-06-01 12:00:00', 1000, '2018-06-03 13:00:00', '2018-06-03 13:15:00', 'false')