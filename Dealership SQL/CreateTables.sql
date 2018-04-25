use Dealership
GO



if exists (select * from sysobjects where id = object_id('dbo.Sales Info') and sysstat & 0xf = 3)
	drop table "dbo"."Sales Info"
GO
if exists (select * from sysobjects where id = object_id('dbo.Mobile Suit') and sysstat & 0xf = 3)
	drop table "dbo"."Mobile Suit"
GO
if exists (select * from sysobjects where id = object_id('dbo.State') and sysstat & 0xf = 3)
	drop table "dbo"."State"
GO
if exists (select * from sysobjects where id = object_id('dbo.PurchaseType') and sysstat & 0xf = 3)
	drop table "dbo"."PurchaseType"
GO
if exists (select * from sysobjects where id = object_id('dbo.BodyStyle') and sysstat & 0xf = 3)
	drop table "dbo"."BodyStyle"
GO
if exists (select * from sysobjects where id = object_id('dbo.Weapon') and sysstat & 0xf = 3)
	drop table "dbo"."Weapon"
GO
if exists (select * from sysobjects where id = object_id('dbo.Color') and sysstat & 0xf = 3)
	drop table "dbo"."Color"
GO
if exists (select * from sysobjects where id = object_id('dbo.Special') and sysstat & 0xf = 3)
	drop table "dbo"."Special"
GO

if exists (select * from sysobjects where id = object_id('dbo.Contacts') and sysstat & 0xf = 3)
	drop table "dbo"."Contacts"
GO


if exists (select * from sysobjects where id = object_id('dbo.Users') and sysstat & 0xf = 3)
	drop table "dbo"."Users"
GO

if exists (select * from sysobjects where id = object_id('dbo.Roles') and sysstat & 0xf = 3)
	drop table "dbo"."Roles"
GO

if exists (select * from sysobjects where id = object_id('dbo.MakeTable') and sysstat & 0xf = 3)
	drop table "dbo"."MakeModel"
GO

if exists (select * from sysobjects where id = object_id('dbo.Type') and sysstat & 0xf = 3)
	drop table "dbo"."Type"
GO

if exists (select * from sysobjects where id = object_id('dbo.Make') and sysstat & 0xf = 3)
	drop table "dbo"."Make"
GO
if exists (select * from sysobjects where id = object_id('dbo.Model') and sysstat & 0xf = 3)
	drop table "dbo"."Model"
GO
if exists (select * from sysobjects where id = object_id('dbo.Century') and sysstat & 0xf = 3)
	drop table "dbo"."Century"
GO


CREATE TABLE Model(
ModelID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
   [ModelName] VARCHAR(20) NOT NULL,
   [User] NVARCHAR(128)  NOT NULL,

   CONSTRAINT FK_Dealership_MakeUser
		FOREIGN KEY ([User]) 
		REFERENCES AspNetUsers(Id),
)


GO
CREATE TABLE Make(
MakeID INT IDENTITY(1,1)Primary Key NOT NULL,
   [MakeName] VARCHAR(20) NOT NULL,
   [User] NVARCHAR(128)  NOT NULL,

   CONSTRAINT FK_Dealership_ModelUser
		FOREIGN KEY ([User]) 
		REFERENCES AspNetUsers(Id),
)
GO

CREATE TABLE MakeModel(
MakeModelID INT IDENTITY(1,1) Primary Key NOT NULL,
MakeID INT NOT NULL,
ModelID INT NOT NULL,

CONSTRAINT FK_Dealership_Model
		FOREIGN KEY (ModelID) 
		REFERENCES Model(ModelID),
		
CONSTRAINT FK_Dealership_Make
		FOREIGN KEY (MakeID) 
		REFERENCES Make(MakeID),
)
GO

CREATE TABLE [Type](
TypeID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 [TypeName] VARCHAR(20) NOT NULL
)
GO

CREATE TABLE [BodyStyle](
[BodyStyleID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[BodyStyleName] VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Weapon(
WeaponID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
   [WeaponName] VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Color(
ColorID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[ColorName] VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Special(
SpecialID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Title VARCHAR(30) NOT NULL,
[Description] VARCHAR(800) NOT NULL
)
GO


--CREATE TABLE Roles(
--RolesID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--[RolesName] VARCHAR(20) NOT NULL
--)
--GO


--CREATE TABLE Users(
--UserID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--AspID NVARCHAR(128) NOT NULL,
--[FirstName] VARCHAR(20) NOT NULL,
--[LastName] VARCHAR(20) NOT NULL,
--[Email] VARCHAR(40) NOT NULL,
--RolesID INT NOT NULL

--CONSTRAINT FK_Dealership_Roles
--		FOREIGN KEY (RolesID) 
--		REFERENCES Roles(RolesID)
--)
--GO
CREATE TABLE [Century](
CenturyID INT Identity(1,1) PRIMARY KEY NOT NULL,
[CenturyName] VARCHAR(20) NOT NULL
)
GO

CREATE TABLE [Mobile Suit](
Name VARCHAR(30) NOT NULL,
SerialNumber VARCHAR(10) NOT NULL,
InventoryNumber INT IDENTITY(1,1),
UserID NVARCHAR(128) NOT NULL,
MakeModelID INT NOT NULL,
TypeID INT NOT NULL,
[BodyStyleID] INT NOT NULL,
[Year] INT NOT NULL,
WeaponID INT NOT NULL,
ColorID INT NOT NULL,
Interior INT NOT NULL,
MSRP INT NOT NULL,
SalePrice Int NOT NULL,
CenturyID INT NOT NULL,
[Image] VARCHAR(30) NOT NULL,
[Creation Date] DATETIME2(7) NOT NULL,
Featured BIT NOT NULL,
Description VARCHAR(800) NOT NULL,
Constraint PK_Dealership
PRIMARY KEY(InventoryNumber,SerialNumber, TypeID),

CONSTRAINT FK_Dealership_MakeModel
		FOREIGN KEY (MakeModelID) 
		REFERENCES MakeModel(MakeModelID),
CONSTRAINT FK_Dealership_Type
		FOREIGN KEY (TypeID) 
		REFERENCES Type(TypeID),
CONSTRAINT FK_Dealership_BodyStyle
		FOREIGN KEY ([BodyStyleID]) 
		REFERENCES [BodyStyle]([BodyStyleID]),
CONSTRAINT FK_Dealership_Weapon
		FOREIGN KEY (WeaponID) 
		REFERENCES Weapon(WeaponID),
CONSTRAINT FK_Dealership_Color
		FOREIGN KEY (ColorID) 
		REFERENCES Color(ColorID),
CONSTRAINT FK_Dealership_Interior
		FOREIGN KEY (Interior) 
		REFERENCES Color(ColorID),
CONSTRAINT FK_Dealership_Century
		FOREIGN KEY (CenturyID) 
		REFERENCES Century(CenturyID),

		CONSTRAINT FK_Dealership_UserID_MobileSuit
		FOREIGN KEY (UserID) 
		REFERENCES AspNetUsers(ID),
)
GO




CREATE TABLE [State](
StateID VARCHAR(2) PRIMARY KEY NOT NULL,
StateAb VARCHAR(20) NOT NULL
)
GO

CREATE TABLE PurchaseType(

TypeID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[Type] VARCHAR(15) NOT NULL
)
GO

CREATE TABLE Contacts(
ContactID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[Name] VARCHAR(40) NULL,
Email VARCHAR(50) NULL,
Phone VARCHAR(12) NULL,
[Message] VARCHAR(800) NULL,
InventoryNumber int NULL,
SerialNumber VARCHAR(10) null,
[TypeID] INT NULL,
UserId NVarChar(128) null,

		CONSTRAINT FK_Dealership_MobileSuit_Contacts
		FOREIGN KEY (InventoryNumber,SerialNumber, [TypeID]) 
		REFERENCES [Mobile Suit](InventoryNumber,SerialNumber, TypeID),
		CONSTRAINT FK_Dealership_MobileSuit_Contacts_user
		FOREIGN KEY (UserId) 
		REFERENCES AspNetUsers(Id)

)
GO

CREATE TABLE SalesInfo(
PurchaseID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[InventoryNumber] INT NOT NULL,
UserID NVARCHAR(128) NOT NULL,
[SerialNumber] VARCHAR(10) Not Null,
[Type] INT NULL,
[Name] VARCHAR(40) NOT NULL,
Email VARCHAR(40) NOT NULL,
Phone VARCHAR(13) NOT NULL,
Street1 VARCHAR(40) NOT NULL,
Street2 VARCHAR(40) NULL,
City VARCHAR(30) NOT NULL,
ZipCode VARCHAR(12) NOT NULL,
[StateID] VARCHAR(2) NOT NULL,
[TypeID] INT NOT NULL,
Price INT NOT NULL


CONSTRAINT FK_Dealership_State
		FOREIGN KEY (StateID) 
		REFERENCES [State](StateID),
CONSTRAINT FK_Dealership_Type_sales
		FOREIGN KEY (TypeID) 
		REFERENCES PurchaseType(TypeID),
CONSTRAINT FK_Dealership_MobileSuit
		FOREIGN KEY (InventoryNumber,SerialNumber, [Type]) 
		REFERENCES [Mobile Suit](InventoryNumber,SerialNumber, TypeID),
			CONSTRAINT FK_Dealership_UserID_SalesInfo
		FOREIGN KEY (UserID) 
		REFERENCES AspNetUsers(ID)

)

