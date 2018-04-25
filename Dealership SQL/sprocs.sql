use Dealership
go

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TypeSelectAll')
BEGIN
   DROP PROCEDURE TypeSelectAll
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialsAll')
BEGIN
   DROP PROCEDURE SpecialsAll
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
BEGIN
   DROP PROCEDURE StatesSelectAll
END

GO
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitInsert')
BEGIN
   DROP PROCEDURE MobileSuitInsert
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectDetails')
BEGIN
   DROP PROCEDURE MobileSuitSelectDetails
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectCustom')
BEGIN
   DROP PROCEDURE MobileSuitSelectCustom
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectMassProduced')
BEGIN
   DROP PROCEDURE MobileSuitSelectMassProduced
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectBroken')
BEGIN
   DROP PROCEDURE MobileSuitSelectBroken
END
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitDelete')
BEGIN
   DROP PROCEDURE MobileSuitDelete
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsSelect')
BEGIN
   DROP PROCEDURE ContactsSelect
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsertDirect')
BEGIN
   DROP PROCEDURE ContactsInsertDirect
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsSelectAll')
BEGIN
   DROP PROCEDURE ContactsSelectAll
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsDelete')
BEGIN
   DROP PROCEDURE ContactsDelete
END
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsert')
BEGIN
   DROP PROCEDURE ContactsInsert
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsertByUser')
BEGIN
   DROP PROCEDURE ContactsInsertByUser
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelect')
BEGIN
   DROP PROCEDURE MobileSuitSelect
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByMake')
BEGIN
   DROP PROCEDURE MobileSuitSelectByMake
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByModel')
BEGIN
   DROP PROCEDURE MobileSuitSelectByModel
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByYear')
BEGIN
   DROP PROCEDURE MobileSuitSelectByYear
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByPrice')
BEGIN
   DROP PROCEDURE MobileSuitSelectByPrice
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectRecent')
BEGIN
   DROP PROCEDURE MobileSuitSelectRecent
END
GO
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitUpdate')
BEGIN
   DROP PROCEDURE MobileSuitUpdate
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByMakeBroken')
BEGIN
   DROP PROCEDURE MobileSuitSelectByMakeBroken
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByModelBroken')
BEGIN
   DROP PROCEDURE MobileSuitSelectByModelBroken
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByYearBroken')
BEGIN
   DROP PROCEDURE MobileSuitSelectByYearBroken
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByPriceBroken')
BEGIN
   DROP PROCEDURE MobileSuitSelectByPriceBroken
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByMakeMassProduced')
BEGIN
   DROP PROCEDURE MobileSuitSelectByMakeMassProduced
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByModelMassProduced')
BEGIN
   DROP PROCEDURE MobileSuitSelectByModelMassProduced
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByYearMassProduced')
BEGIN
   DROP PROCEDURE MobileSuitSelectByYearMassProduced
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByPriceMassProduced')
BEGIN
   DROP PROCEDURE MobileSuitSelectByPriceMassProduced
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByMakeCustom')
BEGIN
   DROP PROCEDURE MobileSuitSelectByMakeCustom
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByModelCustom')
BEGIN
   DROP PROCEDURE MobileSuitSelectByModelCustom
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByYearCustom')
BEGIN
   DROP PROCEDURE MobileSuitSelectByYearCustom
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectByPriceCustom')
BEGIN
   DROP PROCEDURE MobileSuitSelectByPriceCustom
END
GO


CREATE PROCEDURE MobileSuitUpdate ( 
@InventoryNumber int,
@Name VARCHAR(30),
@SerialNumber VARCHAR(30),
@MakeModelID INT,
@TypeID INT,
@BodyStyleID INT,
@Year INT,
@CenturyID INT,
@WeaponID INT,
@ColorID INT,
@Interior INT,
@MSRP INT ,
@SalePrice INT,
@Description VARCHAR(800),
@Image VARCHAR(30),
@UserID NVARCHAR(128),
@Featured BIT
)AS
BEGIN
UPDATE [Mobile Suit] SET [Name] =@Name,
SerialNumber = @SerialNumber,
MakeModelID = @MakeModelID,
TypeID = @TypeID,
[BodyStyleID] = @BodyStyleID,
[Year] = @Year,
[CenturyID] = @CenturyID,
WeaponID = @WeaponID,
ColorID = @ColorID,
Interior = @Interior,
MSRP=@MSRP,
SalePrice = @SalePrice,
[Description] = @Description,
UserID = @UserID,
 [Image] = @Image,
 Featured = @Featured
 Where InventoryNumber = @InventoryNumber

END
GO


CREATE PROCEDURE MobileSuitDelete ( 
@InventoryNumber int
)
AS 
BEGIN 
BEGIN TRANSACTION

DELETE FROM [Mobile Suit] WHERE InventoryNumber = @InventoryNumber;
COMMIT TRANSACTION


END
GO

CREATE PROCEDURE ContactsDelete ( 
   @UserId NVarChar(128),
   @InventoryNumber int

)
AS 
BEGIN 
BEGIN TRANSACTION

DELETE FROM Contacts WHERE UserId = @UserId AND InventoryNumber = @InventoryNumber;
COMMIT TRANSACTION


END
GO

CREATE PROCEDURE MobileSuitInsert ( 
@InventoryNumber int output,
@Name VARCHAR(30),
@UserID NVARCHAR(128),
@SerialNumber VARCHAR(30),
@MakeModelID INT,
@TypeID INT,
@BodyStyleID INT,
@Year INT,
@WeaponID INT,
@ColorID INT,
@Interior INT,
@MSRP INT ,
@SalePrice INT,
@Description VARCHAR(800),
@Image VARCHAR(30),
@CenturyID INT,
@Featured BIT


)AS
BEGIN
insert into [Mobile Suit]([Name],SerialNumber,UserID, MakeModelID,TypeID,[BodyStyleID],[Year],[CenturyID],WeaponID,ColorID,Interior,MSRP,SalePrice, [Description], [Image], [Creation Date], Featured)
VALUES (@Name,@SerialNumber,@UserID, @MakeModelID,@TypeID,@BodyStyleID,@Year,@CenturyID,@WeaponID,@ColorID,@Interior,@MSRP,@SalePrice,@Description,@Image, SYSDATETIME(), @Featured)
Set @InventoryNumber = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE MobileSuitSelect (
   
   @InventoryNumber int
   )
   AS 
   BEGIN
   SELECT [Name],SerialNumber,UserID, MakeModelID,TypeID,[BodyStyleID],[Year],[CenturyID],WeaponID,ColorID,Interior,MSRP,SalePrice, [Description], [Image], [Creation Date], Featured
   from [Mobile Suit]
   Where InventoryNumber = @InventoryNumber
   END
   GO


CREATE PROCEDURE StatesSelectAll AS BEGIN

SELECT StateID, StateAB From State
END
GO


CREATE PROCEDURE TypeSelectAll AS BEGIN

SELECT TypeID, [TypeName] From [Type]
END
Go

CREATE PROCEDURE MobileSuitSelectRecent AS 
BEGIN

SELECT TOP 6 InventoryNumber, MA.MakeName,MO.ModelName, SalePrice, [Image], M.Name
 FROM ((([Mobile Suit] M
 INNER JOIN MakeModel MAMO ON M.MakeModelID = MAMO.MakeModelID)
 INNER JOIN MAKE MA ON MAMO.MakeID = MA.MakeID)
 INNER JOIN Model MO ON MAMO.ModelID = MO.ModelID)
 ORDER BY M.[Creation Date] DESC
END
Go


CREATE PROCEDURE MobileSuitSelectDetails(@InventoryNumber int) AS 
BEGIN

SELECT InventoryNumber,M.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior
 FROM [Mobile Suit] M
 INNER JOIN MakeModel MAMO ON M.MakeModelID = MAMO.MakeModelID
 INNER JOIN MAKE MA ON MAMO.MakeID = MA.MakeID
 INNER JOIN Model MO ON MAMO.ModelID = MO.ModelID
 INNER JOIN [Type] T ON M.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON M.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON M.WeaponID = W.WeaponID
 INNER JOIN Color C ON M.ColorID = C.ColorID
  INNER JOIN Color I ON M.Interior = I.ColorID
  INNER JOIN Century CEN on M.CenturyID = CEN.CenturyID
   Where InventoryNumber = @InventoryNumber
END
Go

CREATE PROCEDURE ContactsSelect (
   
   @UserId NVarChar(128),
   @InventoryNumber int
   )
   AS 
   BEGIN
   SELECT Name, Email, Phone, Message, userId,InventoryNumber
   from Contacts
   Where UserId = @UserId and InventoryNumber =@InventoryNumber
   

   END
   GO

   CREATE PROCEDURE ContactsSelectAll
   AS 
   BEGIN
   SELECT Name, Email, Phone, Message
   from Contacts
   END
   GO

   CREATE PROCEDURE ContactsInsert (
   @ContactID int output,
   @ContactName VARCHAR(40),
   @ContactEmail VARCHAR(50),
   @Phone VARCHAR(12),
   @Message VARCHAR(800)
   )
   AS 
   BEGIN
insert into Contacts(Name, Email, Phone, Message)
VALUES (@ContactName, @ContactEmail, @Phone, @Message)
Set @ContactID = SCOPE_IDENTITY();

   END
   GO

    CREATE PROCEDURE ContactsInsertDirect (
   @userId NVARCHAR(128),
   @InventoryNumber int
   )
   AS 
   BEGIN
insert into Contacts(UserId, InventoryNumber)
VALUES (@userId, @InventoryNumber)


   END
   GO

     CREATE PROCEDURE ContactsInsertByUser (
   @ContactID int output,
   @ContactName VARCHAR(40),
   @ContactEmail VARCHAR(50),
   @Phone VARCHAR(12),
   @Message VARCHAR(800),
   @InventoryNumber int
   )
   AS 
   BEGIN
insert into Contacts(Name, Email, Phone, Message, InventoryNumber)
VALUES (@ContactName, @ContactEmail, @Phone, @Message, @InventoryNumber)
Set @ContactID = SCOPE_IDENTITY();

   END
   GO

   CREATE PROCEDURE MobileSuitSelectbyMake (
   
   @MakeID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior, MS.Featured
   from [Mobile Suit] MS
 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MA.MakeName = @MakeID
   END
   GO

     CREATE PROCEDURE MobileSuitSelectbyModel (
   @ModelID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
	  Where MO.ModelName = @ModelID
   END
   GO


     CREATE PROCEDURE MobileSuitSelectbyYear (
   
   @Year int
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MS.[Year] = @Year
   END
   GO

      CREATE PROCEDURE MobileSuitSelectbyPrice (
   
   @Price int
   )
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MS.SalePrice = @Price
   END
   GO


     CREATE PROCEDURE MobileSuitSelectMassProduced
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice,Ma.MakeID, MO.ModelID, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MS.TypeID = 1
   END
   GO

     CREATE PROCEDURE MobileSuitSelectCustom
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice,Ma.MakeID, MO.ModelID, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MS.TypeID = 2
   END
   GO

    CREATE PROCEDURE MobileSuitSelectBroken
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where MS.TypeID = 3
   END
   GO

   CREATE PROCEDURE SpecialsAll AS BEGIN
SELECT S.Description, S.Title From Special S
END
GO






   CREATE PROCEDURE MobileSuitSelectbyMakeMassProduced(
   
   @MakeID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS
 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MA.MakeName = @MakeID) AND (MS.TypeID = 1 )
   END
   GO

     CREATE PROCEDURE MobileSuitSelectbyModelMassProduced(
   @ModelID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
	  Where (MO.ModelName = @ModelID)AND (MS.TypeID = 1 )
   END
   GO



      CREATE PROCEDURE MobileSuitSelectbyMakeCustom(
   
   @MakeID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS
 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MA.MakeName = @MakeID) AND (MS.TypeID = 2 )
   END
   GO

     CREATE PROCEDURE MobileSuitSelectbyModelCustom(
   @ModelID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
	  Where (MO.ModelName = @ModelID)AND (MS.TypeID = 2)
   END
   GO


     CREATE PROCEDURE MobileSuitSelectbyYearCustom(
   
   @Year int
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MS.[Year] = @Year)AND (MS.TypeID = 2 )
   END
   GO

      CREATE PROCEDURE MobileSuitSelectbyPriceCustom(
   
   @Price int
   )
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MS.SalePrice = @Price) and (MS.TypeID = 2)
   END
   GO


   
      CREATE PROCEDURE MobileSuitSelectbyMakeBroken(
   
   @MakeID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS
 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MA.MakeName = @MakeID) AND (MS.TypeID = 3 )
   END
   GO

     CREATE PROCEDURE MobileSuitSelectbyModelBroken(
   @ModelID VARCHAR(20)
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
	  Where (MO.ModelName = @ModelID)AND (MS.TypeID = 3)
   END
   GO


     CREATE PROCEDURE MobileSuitSelectbyYearBroken(
   
   @Year int
   )
   AS 
   BEGIN
   SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MS.[Year] = @Year)AND (MS.TypeID = 3 )
   END
   GO

      CREATE PROCEDURE MobileSuitSelectbyPriceBroken(
   
   @Price int
   )
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
   Where (MS.SalePrice = @Price) and (MS.TypeID = 3)
   END
   GO


   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsertByUserId')
BEGIN
   DROP PROCEDURE ContactsInsertByUserId
END
GO





CREATE PROCEDURE ContactsInsertByUserId (
   @ContactID int output,
   @ContactName VARCHAR(40),
   @ContactEmail VARCHAR(50),
   @Phone VARCHAR(12),
   @Message VARCHAR(800),
   @userId nvarchar(128),
   @InventoryNumber int
   )
   AS 
   BEGIN
insert into Contacts(Name, Email, Phone, Message, UserId, InventoryNumber)
VALUES (@ContactName, @ContactEmail, @Phone, @Message, @userId, @InventoryNumber)
Set @ContactID = SCOPE_IDENTITY();

   END
   GO


     IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsertContactPage')
BEGIN
   DROP PROCEDURE ContactsInsertContactPage
END
GO



   CREATE PROCEDURE ContactsInsertContactPage (
   @ContactID int output,
   @ContactName VARCHAR(40),
   @ContactEmail VARCHAR(50),
   @Phone VARCHAR(12),
   @Message VARCHAR(800)
   )
   AS 
   BEGIN
insert into Contacts(Name, Email, Phone, Message)
VALUES (@ContactName, @ContactEmail, @Phone, @Message)
Set @ContactID = SCOPE_IDENTITY();

   END
   GO

        IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MobileSuitSelectAll')
BEGIN
   DROP PROCEDURE MobileSuitSelectAll
END
GO
  CREATE PROCEDURE MobileSuitSelectAll
   AS 
   BEGIN
 SELECT InventoryNumber,MS.Name, MA.MakeName,MO.ModelName, SalePrice,Ma.MakeID, MO.ModelID, [Image], SerialNumber, [Year],MSRP,T.TypeName,Description,BS.BodyStyleName,
W.WeaponName, C.ColorName, CEN.CenturyName, I.ColorName as Interior,MS.Featured
   from [Mobile Suit] MS

 INNER JOIN [Type] T ON MS.TypeID=T.TypeID
 INNER JOIN BodyStyle BS ON MS.BodyStyleID = BS.BodyStyleID
 INNER JOIN Weapon W ON MS.WeaponID = W.WeaponID
 INNER JOIN Color C ON MS.ColorID = C.ColorID
  INNER JOIN Color I ON MS.Interior = I.ColorID
  INNER JOIN Century CEN on MS.CenturyID = CEN.CenturyID
   Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID 
   INNER JOIN Make MA on MM.MakeID = MA.MakeID 
      INNER JOIN Model MO on MM.ModelID = MO.ModelID
  
   END
   GO


   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
BEGIN
   DROP PROCEDURE BodyStyleSelectAll
END
GO
CREATE PROCEDURE BodyStyleSelectAll AS BEGIN

SELECT BodyStyleID,BodyStyleName
 From BodyStyle
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CenturySelectAll')
BEGIN
   DROP PROCEDURE CenturySelectAll
END
GO
CREATE PROCEDURE CenturySelectAll AS BEGIN

SELECT CenturyID,CenturyName
 From Century
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ColorsSelectAll')
BEGIN
   DROP PROCEDURE ColorsSelectAll
END
GO
CREATE PROCEDURE ColorsSelectAll AS BEGIN

SELECT ColorID,ColorName
 From Color
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelectAll')
BEGIN
   DROP PROCEDURE ModelSelectAll
END
GO
CREATE PROCEDURE ModelSelectAll AS BEGIN

SELECT ModelID,ModelName, [User]
 From Model
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectAll')
BEGIN
   DROP PROCEDURE MakeSelectAll
END
GO
CREATE PROCEDURE MakeSelectAll AS BEGIN

SELECT MakeID,MakeName, [User]
 From Make
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'WeaponsSelectAll')
BEGIN
   DROP PROCEDURE WeaponsSelectAll
END
GO
CREATE PROCEDURE WeaponsSelectAll AS BEGIN

SELECT WeaponID,WeaponName
 From Weapon
END
Go

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeModelInsert')
BEGIN
   DROP PROCEDURE MakeModelInsert
END
GO

CREATE PROCEDURE MakeModelInsert (
@MakeModelID int output, 
@MakeId int,
@ModelId int

)AS
BEGIN
insert into MakeModel(ModelID, MakeID)
VALUES (@ModelId,@MakeId)
Set @MakeModelID = SCOPE_IDENTITY();
END
GO

 IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeModelSelectAll')
BEGIN
   DROP PROCEDURE MakeModelSelectAll
END
GO

CREATE PROCEDURE MakeModelSelectAll  as
begin
select MakeID, ModelID, MakeModelID
from MakeModel
end
GO

 IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeModelBoth')
BEGIN
   DROP PROCEDURE MakeModelBoth
END
GO
CREATE PROCEDURE MakeModelBoth (
@MakeID int,
@ModelID int

)AS
BEGIN
select MakeID, ModelID, MakeModelID
from MakeModel
Where MakeID = @MakeID and ModelID = @ModelID
END
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
BEGIN
   DROP PROCEDURE MakeInsert
END
GO
CREATE PROCEDURE MakeInsert (
@MakeID int output,
@MakeName varchar(20),
@UserID NVARCHAR(128)

)AS
BEGIN
insert into Make(MakeName, [User])
VALUES (@MakeName, @UserID)
Set @MakeID = SCOPE_IDENTITY();
END
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
BEGIN
   DROP PROCEDURE ModelInsert
END
GO
CREATE PROCEDURE ModelInsert (
@ModelID int output,
@ModelName varchar(20),
@UserID NVARCHAR(128)

)AS
BEGIN
insert into Model(ModelName, [User])
VALUES (@ModelName, @UserID)
Set @ModelID = SCOPE_IDENTITY();
END
GO




IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialInsert')
BEGIN
   DROP PROCEDURE SpecialInsert
END
Go
CREATE PROCEDURE SpecialInsert (
@SpecialID int output,
@Title varchar(30),
@Description NVARCHAR(800)

)AS
BEGIN
insert into Special(Title, Description)
VALUES (@Title, @Description)
Set @SpecialID = SCOPE_IDENTITY();
END
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaleInsert')
BEGIN
   DROP PROCEDURE SaleInsert
END
Go
CREATE PROCEDURE SaleInsert (
@PurchaseID int output,
@InventoryNumber int,
           @UserID nvarchar(128),
           @SerialNumber varchar(10),
           @Type int,
           @Name varchar(40),
           @Email varchar(40),
           @Phone varchar(13),
           @Street1 varchar(40),
           @Street2 varchar(40),
           @City varchar(30),
           @ZipCode varchar(12),
           @StateID varchar(2),
           @TypeID int,
           @Price int

)AS
BEGIN
insert into SalesInfo ([InventoryNumber]
           ,[UserID]
           ,[SerialNumber]
           ,[Type]
           ,[Name]
           ,[Email]
           ,[Phone]
           ,[Street1]
           ,[Street2]
           ,[City]
           ,[ZipCode]
           ,[StateID]
           ,[TypeID]
           ,[Price])
VALUES (@InventoryNumber,
            @UserID, 
           @SerialNumber,
            @Type,
            @Name,
            @Email,
            @Phone,
            @Street1,
            @Street2,
            @City,
           @ZipCode,
           @StateID,
           @TypeID,
            @Price)
Set @PurchaseID = SCOPE_IDENTITY();
END
GO

   IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelectAll')
BEGIN
   DROP PROCEDURE PurchaseSelectAll
END
GO
CREATE PROCEDURE PurchaseSelectAll AS BEGIN

SELECT [Type], TypeID
 From PurchaseType
END
Go