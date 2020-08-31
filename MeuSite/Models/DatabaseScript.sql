CREATE DATABASE BancoEngComp
GO

USE BancoEngComp
GO

CREATE TABLE Produtos(
	ID INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR(255),
	Descricao NVARCHAR(255),
	Quantidade INT,
	ValorUnitario DECIMAL(18,2)
)

INSERT INTO Produtos(Nome,Descricao,Quantidade,ValorUnitario) VALUES
('Produto A','Alguma descrica��o do produto A',20,1.50),
('Produto B','Alguma descrica��o do produto B',30,2.50),
('Produto C','Alguma descrica��o do produto C',40,3.50),
('Produto D','Alguma descrica��o do produto D',50,4.50),
('Produto E','Alguma descrica��o do produto E',60,5.50)