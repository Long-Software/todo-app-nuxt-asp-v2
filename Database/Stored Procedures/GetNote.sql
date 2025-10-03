CREATE PROCEDURE GetNote
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Content, CreatedAt, UpdatedAt
    FROM Notes
    WHERE Id = @Id;
END