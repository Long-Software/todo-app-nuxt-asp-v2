CREATE OR ALTER PROCEDURE spCreateNote
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Notes (Title, Content, CreatedAt, UpdatedAt)
    VALUES (@Title, @Content, GETUTCDATE(), GETUTCDATE());

    SELECT SCOPE_IDENTITY() AS NewId;
END