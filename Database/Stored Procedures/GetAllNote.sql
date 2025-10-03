CREATE PROCEDURE GetAllNotes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Content, CreatedAt, UpdatedAt
    FROM Notes
    ORDER BY CreatedAt DESC;
END
