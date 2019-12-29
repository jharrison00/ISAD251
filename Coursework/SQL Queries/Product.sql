CREATE TABLE Cafe_Products(
    ProductID INT NOT NULL,
    ProductType VARCHAR(6) NULL CHECK(ProductType IN ('Drinks','Food')),
    ProductPrice DECIMAL(18,2),
    ProductName VARCHAR(20),
    ProductCalories INT,
    ProductDetails TEXT,
    ProductImage TEXT,  
    CONSTRAINT pk_Cafe_Products PRIMARY KEY (ProductID)
);