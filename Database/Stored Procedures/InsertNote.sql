CREATE PROCEDURE InsertNote
    @Title NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Notes (Title, Content, CreatedAt, UpdatedAt)
    VALUES (@Title, '', GETUTCDATE(), GETUTCDATE());

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Result;
END