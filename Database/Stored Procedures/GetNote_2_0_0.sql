CREATE PROCEDURE GetNote_2_0_0
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Content, CreatedAt, UpdatedAt
    FROM Notes WITH (NOLOCK)
    WHERE Id = @id;
END