CREATE PROCEDURE [dbo].[spExpense_Insert]
	@RentId INT,
	@Name NVARCHAR(100),
	@Type INT,
	@Description NVARCHAR(1000),
	@Amount SMALLMONEY,
	@CustomDivision BIT,
	@PersonAmount PersonAmountType READONLY
AS
BEGIN

INSERT INTO dbo.Expense
([RentId], [Name], [Type], [Description], [Amount], [CustomDivsion])
VALUES
(@RentId, @Name, @Type, @Description, @Amount, @CustomDivision)

DECLARE @ExpenseId INT
SELECT @ExpenseId = SCOPE_IDENTITY()

IF (@CustomDivision = 1)
BEGIN
	INSERT INTO dbo.ExpensePerson
	([ExpenseId], [PersonId], [CustomAmount])
	SELECT @ExpenseId, [PersonId], [CustomAmount]
	FROM @PersonAmount
END

ELSE
BEGIN
	INSERT INTO dbo.ExpensePerson
	([ExpenseId], [PersonId])
	SELECT @ExpenseId, [PersonId]
	FROM @PersonAmount
END

END