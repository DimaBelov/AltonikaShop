CREATE TABLE Product (
    product_id int IDENTITY(1,1) PRIMARY KEY,
    product_name varchar(255) NOT NULL,
    product_description varchar(900),
    img_src varchar(900)
);