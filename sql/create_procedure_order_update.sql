ALTER PROCEDURE Order_Update
@user_id INT,
@details OrderDetailTvp READONLY
AS
BEGIN
	SET NOCOUNT ON
    SET XACT_ABORT ON

    BEGIN TRY
        BEGIN TRANSACTION
        
		DECLARE @order_id INT;
        --IF @is_deleted = 1
        --    DELETE  
        --    FROM    OrderDetails
        --    WHERE   OrderId = @orderId
                    
		INSERT INTO Orders (user_id, create_dt) VALUES (@user_id, GETDATE())

		SET @order_id = SCOPE_IDENTITY();
        
		INSERT INTO OrderDetails (product_id, quantity, order_id)
		SELECT product_id, quantity, @order_id FROM @details
        
		SELECT @order_id
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION
        
        DECLARE @error int, @message varchar(4000);
		SELECT @error = ERROR_NUMBER(), @message = ERROR_MESSAGE();
		RAISERROR ('Order_Update: %d: %s', 16, 1, @error, @message);
    END CATCH
END