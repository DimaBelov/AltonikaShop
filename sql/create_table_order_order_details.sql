--CREATE TABLE Orders (
--    order_id int IDENTITY(1,1) PRIMARY KEY,
--    user_id int NOT NULL
--);

CREATE TABLE OrderDetails (
    order_detail_id int IDENTITY(1,1) PRIMARY KEY,
	product_id int NOT NULL,
	quantity int NOT NULL,
    order_id int NOT NULL FOREIGN KEY REFERENCES Orders(order_id)
);
