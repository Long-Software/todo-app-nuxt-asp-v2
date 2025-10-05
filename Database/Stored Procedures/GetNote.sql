CREATE PROCEDURE GetNote
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Content, CreatedAt, UpdatedAt
    FROM Notes
    WHERE Id = @id;
END