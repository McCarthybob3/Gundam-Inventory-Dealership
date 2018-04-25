use Dealership
go

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
BEGIN
   DROP PROCEDURE DbReset
END
GO

CREATE PROCEDURE dbReset AS BEGIN
DELETE FROM [State];


DELETE FROM Contacts;
DELETE from [Mobile Suit];
DELETE From [Type];
DELETE FROM [Color];
DELETE FROM [MakeModel];
DELETE FROM [BodyStyle];
DELETE FROM [Model];
DELETE FROM [Make];
DELETE FROM [Century];
DELETE From AspNetUsers;
DELETE FROM AspNetRoles;
DELETE FROM Special;
Delete from weapon;
Delete from PurchaseType;

DBCC CHECKIDENT ('Mobile Suit',RESEED,0)
DBCC CHECKIDENT ('Type',RESEED,0)
DBCC CHECKIDENT ('Contacts',RESEED,0)
DBCC CHECKIDENT ('MakeModel',RESEED,0)
DBCC CHECKIDENT ('Make',RESEED,0)
DBCC CHECKIDENT ('Model',RESEED,0)
DBCC CHECKIDENT ('BodyStyle',RESEED,0)
DBCC CHECKIDENT ('Color',RESEED,0)
DBCC CHECKIDENT ('Century',RESEED,0)
DBCC CHECKIDENT ('Special',RESEED,0)
DBCC CHECKIDENT ('Weapon',RESEED,0)
DBCC CHECKIDENT ('PurchaseType',RESEED,0)

Insert INTO [State] (StateID, StateAb)
values ('OH','Ohio'),
('KY','Kentucky'),
('MN', 'Minnesota');

Insert INTO [Type]([TypeName])
values('Mass Produced'),
('Custom'),
('Broken');

INSERT INTO Contacts(Name,Email,Phone,Message)
values('Bill','Test@gmail.com','123-456-789','Can I get an Optimus Prime?'),
('George','Test34@gmail.com','123-111-789','Test');

Insert Into [PurchaseType](Type)
values('cash'),('card');

 Insert into AspNetUsers(Id,EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
 Values('00000000-0000-0000-0000-000000000000', 0, 0, 'Bob@gmail.com', 0,0,0,'Bob');

 Insert into AspNetUsers(Id,EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
 Values('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com', 0,0,0,'test2');

 Insert into AspNetRoles(Id,Name) values ('1','Disabled'), ('2', 'Sales'), ('3','Admin')

 Insert into Color([ColorName]) values ('Green'),('Red'),('Blue'),('White'), ('Pink'), ('Orange'), ('Camoflauge');
 Insert into Weapon([WeaponName]) values ('Machine Gun'), ('Beam Sword'), ('Bazooka'), ('Cannon'), ('Whip'), ('Beam Gun');
 Insert INTO [BodyStyle]([BodyStyleName]) values ('Bipedal'), ('Tank'), ('Cannon'), ('Ball');
 Insert INTO Model([ModelName],[User]) values ('06','00000000-0000-0000-0000-000000000000'), ('06S','00000000-0000-0000-0000-000000000000'), ('78-1','00000000-0000-0000-0000-000000000000'),('78-2','00000000-0000-0000-0000-000000000000'),('79','00000000-0000-0000-0000-000000000000');
 Insert INTO Make([MakeName],[User]) VALUES ('MS','00000000-0000-0000-0000-000000000000'),('RX','00000000-0000-0000-0000-000000000000'), ('RG','00000000-0000-0000-0000-000000000000'),('RB','00000000-0000-0000-0000-000000000000');
 Insert INTO Century([CenturyName]) Values ('UC'), ('FC'),('AC'),('CC');

 Insert INTO MakeModel(MakeID, ModelID) values (1,1), (1,2),(2,3),(2,4),(3,5),(4,5);
 

 Insert INTO Special(Title,Description) Values ('War over', 'get these gosh darn zeon gundams outta here'),('Test','afdsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss');


 insert into [Mobile Suit]([Name],SerialNumber,UserID, MakeModelID,TypeID,[BodyStyleID],[Year],WeaponID,ColorID,Interior,MSRP,SalePrice, [Description],[Image],[Creation Date], CenturyID, Featured)
 VALUES('Zaku II',1234567890,'11111111-1111-1111-1111-111111111111',1,1,1,0079,1,1,1,1200000,1000000,'The mainstay of the Zeon army. Faster, stronger, more durable, and better built than the first Zaku', 'zaku.jpg',SYSDATETIME(), 1,1),
 ('Zaku II Char Custom',2233445566,'11111111-1111-1111-1111-111111111111',2,2,1,0079,1,2,2,1700000,1200000,'Custom Red Zaku II, Customized for peak performance for commanders of the Zeon army. 3x Faster than the base model with an added shoulder shield attatchment.', 'char.jpg',SYSDATETIME(), 1,1),
 ('Zaku II',1234567891,'11111111-1111-1111-1111-111111111111',1,1,1,0079,1,7,1,1200000,1000000,'The mainstay of the Zeon army. Faster, stronger, more durable, and better built than the first Zaku', 'zakucamo.jpg',SYSDATETIME(), 1,1),
  ('Gundam',0000000001,'11111111-1111-1111-1111-111111111111',4,2,2,0079,2,4,1,2000000,1800000,'The Gundam was incredibly advanced for its time. Built from lightweight Luna Titanium Alloy, its frame was both lighter than that of Zeon mass-produced mobile suits and much sturdier, able to shrug off a Zaku IIs machine gun fire with little to no damage. Its offensive power was above and beyond that of the Zeon Zakus', '78.jpg',SYSDATETIME(), 1,1),
   ('GM',1234444891,'11111111-1111-1111-1111-111111111111',5,1,1,0079,6,4,4,1200000,1000000,'mass-produced mobile suit based on the technology of the RX-78-2 Gundam. Its basic frame is easily adaptable to modifications into mission specific GM models, and has a fairly high level of mobility', 'gm.jpg',SYSDATETIME(), 1,1),
   ('Ball',1111111111,'11111111-1111-1111-1111-111111111111',6,1,4,0079,4,3,3,1000000,800000,'The Federation refitted about 1200 of the civilian-model worker space pods, known as SP-W03 Space Pods. The Federation reinforced it with heavier armor and mounted a 180mm recoilless cannon on top. The Ball mobile pod also had vernier thrusters mounted all along the body.', 'ball.jpg',SYSDATETIME(), 1,0)
END

UPDATE
    State
SET
    StateAb = LTRIM(RTRIM(StateAb))