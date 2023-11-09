Create table tableProducts(ID int Identity(1,1)Primary Key,
Name VARCHAR(100),Image VARCHAR(100),ActualPrice Decimal(18,2),DiscountedPrice Decimal(18,2));

Create table Cart(ID int Identity(1,1)Primary Key,ProductId INT)

Select * from tableProducts;

Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d5.jpg',115.00,60.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d1.jpg',195.00,95.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d8.jpg',95.00,40.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d4.jpg',195.00,95.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d7.jpg',95.00,40.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d2.jpg',65.00,25.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d3.jpg',95.00,50.00);
Insert into tableProducts(Name,Image,ActualPrice,DiscountedPrice)
Values('Shoes','d6.jpg',36.00,84.00);