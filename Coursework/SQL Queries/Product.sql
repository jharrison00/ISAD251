CREATE TABLE Cafe_Products(
    ProductID INT NOT NULL,
    ProductType VARCHAR(5) NULL CHECK(ProductType IN ('Drink','Food')),
    ProductPrice DECIMAL(18,2),
    ProductName VARCHAR(20),
    ProductCalories INT,
    ProductDetails TEXT,  
    CONSTRAINT pk_Cafe_Products PRIMARY KEY (ProductID)
);