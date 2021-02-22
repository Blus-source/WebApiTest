create table Product (
ProductId int Identity(1,1),
ProductName varchar(32),
ProductDescription varchar(32),
ProductPrice decimal(18,3),
ProductImage varchar(500)
)


insert into dbo.Product values ('Viande', 'Le top de la viande', 12.5,''), ('Savon', 'Le top du savon', 1,'')