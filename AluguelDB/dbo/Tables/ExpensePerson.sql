CREATE TABLE [dbo].[ExpensePerson]
(
	[ExpenseId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    [CustomAmount] SMALLMONEY NULL DEFAULT NULL, 
    CONSTRAINT [FK_ExpensePerson_Expense] FOREIGN KEY ([ExpenseId]) REFERENCES [Expense]([Id]),
    CONSTRAINT [FK_ExpensePerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
