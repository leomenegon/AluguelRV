CREATE PROCEDURE [dbo].[spExpense_GetPersons]
	@ExpenseId INT
AS
BEGIN

SELECT p.[Id], p.[Name]
FROM dbo.ExpensePerson ep
INNER JOIN dbo.Person p
ON ep.PersonId = p.Id
WHERE ep.ExpenseId = @ExpenseId
AND p.[Deleted] = 0

END