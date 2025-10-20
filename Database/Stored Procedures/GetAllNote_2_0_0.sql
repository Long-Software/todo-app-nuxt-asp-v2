CREATE PROCEDURE GetAllNotes_2_0_0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Content, CreatedAt, UpdatedAt
    FROM Notes WITH (NOLOCK)
    ORDER BY CreatedAt DESC;
END
