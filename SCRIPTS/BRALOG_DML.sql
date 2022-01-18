
CREATE DATABASE BRALOG;

--Define o banco de dados "Filmes" como o principal (utilizado)
USE BRALOG;

CREATE TABLE Estados
(
	IdEstado			INT PRIMARY KEY IDENTITY 
	,Sigla			VARCHAR(200) NOT NULL
)

CREATE TABLE TiposUsuario
(
	IdTipoUsu			INT PRIMARY KEY IDENTITY 
	,Descricao			VARCHAR(200) NOT NULL
)

CREATE TABLE Usuarios
(
	IdUsuario			INT PRIMARY KEY IDENTITY 
	,IdTipoUsu			INT FOREIGN KEY REFERENCES TiposUsuario (idTipoUsu)
	,Nome				VARCHAR(200) NOT NULL
	,NomeCompleto		VARCHAR(200) NOT NULL
	,Email				VARCHAR(200) NOT NULL
	,Senha				VARCHAR(200) NOT NULL
)

CREATE TABLE TiposPagamento
(
	idTipoPag		INT PRIMARY KEY IDENTITY 
	,Descricao			VARCHAR(200) NOT NULL
)

CREATE TABLE Produtos
(
	idProduto			INT PRIMARY KEY IDENTITY 
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (idUsuario)
	,Descricao			VARCHAR(200) NOT NULL
	,Valor				VARCHAR(200) NOT NULL
	,Qtd				INT
)

CREATE TABLE Clientes
(
	IdCliente			INT PRIMARY KEY IDENTITY 
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (idUsuario)
	,IdEstado			INT FOREIGN KEY REFERENCES Estados  (idEstado)
	,Nome				VARCHAR(200) NOT NULL --N�O NULO
	,NomeCompleto		VARCHAR(200) NOT NULL --N�O NULO
	,Telefone			VARCHAR(200) NOT NULL --N�O NULO
	,Cidade				VARCHAR(200) NOT NULL --N�O NULO

);

CREATE TABLE Entregas
(
	idEntrega			INT PRIMARY KEY IDENTITY 
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuarios			(idUsuario)
	,IdProduto			INT FOREIGN KEY REFERENCES Produtos			(idProduto)
	,IdTipoPag			INT FOREIGN KEY REFERENCES TiposPagamento	(idTipoPag)
	,IdCliente			INT FOREIGN KEY REFERENCES Clientes			(idCliente)
	,IdEstado			INT FOREIGN KEY REFERENCES Estados			(idEstado)
	,Staus				BIT NOT NULL
	,Data				DATETIME NOT NULL
	,ValorTotal			VARCHAR(200) NOT NULL
	,QtdTotal			INT 
	,Cidade				VARCHAR(200) NOT NULL --N�O NULO
)
