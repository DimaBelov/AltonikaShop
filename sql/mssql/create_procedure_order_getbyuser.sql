ALTER PROCEDURE Order_GetByUser
@user_id INT
AS
BEGIN
	SELECT * FROM Orders
	WHERE user_id=@user_id

	SELECT od.*, p.product_name, p.img_src FROM OrderDetails od
	INNER JOIN Product p ON od.product_id=p.product_id
	WHERE order_id IN (SELECT order_id FROM Orders WHERE user_id=@user_id)
	
END