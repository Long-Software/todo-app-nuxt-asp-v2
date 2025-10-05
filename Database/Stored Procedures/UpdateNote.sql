CREATE PROCEDURE UpdateNote
    @id INT,
    @title NVARCHAR(200),
    @content NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Notes
    SET Title = @title,
        Content = @content,
        UpdatedAt = GETUTCDATE()
    WHERE Id = @id;

    SELECT CAST(@@ROWCOUNT AS INT) AS Result;
END