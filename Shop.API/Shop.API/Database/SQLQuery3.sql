--CREATE DATABASE SHOP_CSHARP

--CREATE TABLE PRODUCTS (
--	Id int identity (1,1) NOT NULL,
--	[Name] nvarchar(255) NULL,
--	[Description] nvarchar(max) NULL,
--	Quantity int NUll,
--	Price numeric(10,2) NUll,
--    Markdown FLOAT NULL,
--    Bogo BIT NULL
--)

--SELECT * FROM PRODUCTS

--CREATE SCHEMA Products

--CREATE PROCEDURE Products.InsertProduct
--@Name nvarchar(255),
--@Description nvarchar(max),
--@Quantity int,
--@Price numeric(10,2),
--@Markdown FLOAT,
--@Bogo BIT,
--@Id int output
--AS
--BEGIN
--	INSERT INTO PRODUCTS ([Name], [Description], Quantity, Price, Markdown, Bogo)
--	VALUES(@Name, @Description, @Quantity, @Price, @Markdown, @Bogo)

--	SET @Id = SCOPE_IDENTITY();
--END

--DECLARE @newId int
--EXEC Products.InsertProduct @Name='Test 2', 
--@Description='Test desc.', 
--@Quantity = 10, 
--@Price = 9.99, 
--@Markdown = 0.15, 
--@Bogo=1,
--@Id = @newId out

--select @newId

--CREATE PROCEDURE Products.UpdateProduct
--@Name nvarchar(255),
--@Description nvarchar(max),
--@Quantity int,
--@Price numeric(10,2),
--@Markdown FLOAT,
--@Bogo BIT,
--@Id int
--AS
--BEGIN
--	UPDATE PRODUCTS
--	SET
--		Name = @Name,
--		Description = @Description,
--		Quantity = @Quantity,
--		Price = @Price,
--		Markdown = @Markdown,
--		Bogo = @Bogo
--	WHERE 
--		Id = @Id
--END

--CREATE PROCEDURE PRODUCTS.DeleteProduct
--    @Id int
--AS
--BEGIN
--    DELETE FROM PRODUCTS
--    WHERE Id = @Id;
--END


SELECT * FROM PRODUCTS