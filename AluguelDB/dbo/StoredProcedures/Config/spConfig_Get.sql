CREATE PROCEDURE [dbo].[spConfig_Get]
	@key nvarchar(10)
AS
	BEGIN
	SELECT [Value] FROM [dbo].[Config] WHERE [Key] = @key
END