CREATE PROCEDURE UpdateNote
    @Id INT,
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Notes
    SET Title = @Title,
        Content = @Content,
        UpdatedAt = GETUTCDATE()
    WHERE Id = @Id;
END
