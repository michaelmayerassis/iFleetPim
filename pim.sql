CREATE DATABASE Pim;

USE Pim;

CREATE TABLE Empresa
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(250) NOT NULL,
    Cnpj VARCHAR(50) NOT NULL UNIQUE,
    Telefone VARCHAR(50) NOT NULL,
    Email VARCHAR(250) NOT NULL,
    Endereco VARCHAR(250) NOT NULL,
    Numero INT UNSIGNED NOT NULL,
    Cidade VARCHAR(200) NOT NULL,
    Bairro VARCHAR(200),
    PRIMARY KEY(Id)
);

CREATE TABLE Veiculo
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(250) NOT NULL,
    Marca VARCHAR(200) NOT NULL ,
    Modelo VARCHAR(250) NOT NULL,
    Cor VARCHAR(50) NOT NULL,
    Renavan VARCHAR(50) NOT NULL UNIQUE,
    Placa VARCHAR(50) NOT NULL UNIQUE,
    Ano INT UNSIGNED NOT NULL,
    PRIMARY KEY(Id)

);

CREATE TABLE Seguro
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Veiculo_Id INT UNSIGNED NOT NULL,
    Seguradora VARCHAR(250) NOT NULL,
    Plano VARCHAR(150) NOT NULL,
    Apolice VARCHAR(150) NOT NULL,
    Validade DATE NOT NULL,
    PRIMARY KEY (Id, Veiculo_Id),
    CONSTRAINT fk_Vei_Seguro FOREIGN KEY(Veiculo_id) REFERENCES Veiculo (id)
);

CREATE TABLE Motorista
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Cpf VARCHAR(50) NOT NULL UNIQUE,
    Nome VARCHAR(250) NOT NULL,
    Cnh VARCHAR(50) NOT NULL UNIQUE,
    Categoria_Cnh VARCHAR(50) NOT NULL,
    Dt_Nascimento DATE NOT NULL,
    Exame_Medico VARCHAR(250) NOT NULL,
    Email VARCHAR(250) NOT NULL,
    Endereco VARCHAR(250) NOT NULL,
    Numero INT UNSIGNED NOT NULL,
    Cidade VARCHAR(150) NOT NULL,
    Bairro VARCHAR(150),
    Cep INT UNSIGNED,
    PRIMARY KEY(Id, Cpf)
);

CREATE TABLE Contato
(
	Telefone_PK INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Motorista_Id INT UNSIGNED NOT NULL,
    Telefone VARCHAR(50) NOT NULL,
    PRIMARY KEY(Telefone_PK),
    CONSTRAINT fk_Mot_Contato FOREIGN KEY(Motorista_id) REFERENCES Motorista (id)
);

CREATE TABLE Viagem
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Motorista_Cpf INT UNSIGNED NOT NULL,
    Local VARCHAR(250) NOT NULL,
    Dt_Saida DATE NOT NULL,
    Dt_Entrada DATE NOT NULL,
    km_Saida DOUBLE UNSIGNED NOT NULL,
    Km_Entrada DOUBLE UNSIGNED NOT NULL,
    Situacao VARCHAR(30),
    PRIMARY KEY(Id),
	CONSTRAINT fk_Cpf_Viagem FOREIGN KEY(Motorista_Cpf) REFERENCES Motorista (id)
);

CREATE TABLE VeiculoViagem
(
   Veiculo_Id INT UNSIGNED NOT NULL,
    Viagem_Id INT UNSIGNED NOT NULL,
    PRIMARY KEY(Veiculo_Id, Viagem_Id),
    CONSTRAINT fk_Via_veiculo FOREIGN KEY(Veiculo_Id) REFERENCES Veiculo (id),
	CONSTRAINT fk_Vei_Viagem FOREIGN KEY(Viagem_Id) REFERENCES Viagem (id)
);
CREATE TABLE Multa
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Veiculo_Id INT UNSIGNED NOT NULL,
    Endereco VARCHAR(250) NOT NULL,
    Cidade varchar(250) NOT NULL,
    Estado VARCHAR(4) NOT NULL,
    Cep VARCHAR(50) NOT NULL,
    Gravidade VARCHAR(150) NOT NULL,
    Data DATE NOT NULL,
    PRIMARY KEY(Id),
    CONSTRAINT fk_Vei_Multa FOREIGN KEY(Veiculo_Id) REFERENCES Veiculo (Id)
);

CREATE TABLE Manutencao
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Veiculo_Id INT UNSIGNED NOT NULL,
    Descricao VARCHAR(250) NOT NULL,
    Data DATE NOT NULL,
    Valor DOUBLE UNSIGNED,
    PRIMARY KEY(Id),
    CONSTRAINT fk_Vei_Manutencao FOREIGN KEY(Veiculo_id) REFERENCES Veiculo (id)
);


CREATE TABLE VeiculoManutencao
(
    Veiculo_Id INT UNSIGNED NOT NULL,
    Manutencao_Id INT UNSIGNED NOT NULL,
    PRIMARY KEY(Veiculo_Id, Manutencao_Id),
    CONSTRAINT fk_Man_vei FOREIGN KEY(Veiculo_Id) REFERENCES Veiculo (id),
    CONSTRAINT fk_Vei_Manu FOREIGN KEY(Manutencao_Id) REFERENCES Manutencao (id)
);

CREATE TABLE Peca
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(250) NOT NULL UNIQUE,
    Descricao VARCHAR(250) default"null",
    Prateleira VARCHAR(250) default "null",
    Quantidade INT UNSIGNED default "0",
    Valor DECIMAL(9,2) UNSIGNED default "0.00",
    EstoqueMinimo INT UNSIGNED default "0",
    PRIMARY KEY(Id)
);


CREATE TABLE OrdemServico
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Manutencao_Id INT UNSIGNED NOT NULL,
    peca_Id INT UNSIGNED NOT NULL,
    Dt_Saida DATE NOT NULL,
    Quantidade INT UNSIGNED NOT NULL,
    Valor DOUBLE UNSIGNED NOT NULL,
    PRIMARY KEY(Id),
    CONSTRAINT fk_Man_OrdemServico FOREIGN KEY(manutencao_id) REFERENCES Manutencao (id),
    CONSTRAINT fk_Pec_OrdemServico FOREIGN KEY(Peca_id) REFERENCES Peca (id)
);


CREATE TABLE Abastecimento
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Veiculo_Id INT UNSIGNED NOT NULL,
    Combustivel VARCHAR(100) NOT NULL,
    Valor DOUBLE UNSIGNED NOT NULL,
    Quantidade DOUBLE UNSIGNED,
    Km DOUBLE UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT fk_Abas_veiculo FOREIGN KEY(Veiculo_Id) REFERENCES Veiculo (id)
);


CREATE TABLE VeiculoAbastecimento
(
	Veiculo_Id INT UNSIGNED NOT NULL,
    Abastecimento_Id INT UNSIGNED NOT NULL,
    PRIMARY KEY(Veiculo_Id, Abastecimento_Id),
    CONSTRAINT fk_Vei_Abastecimento FOREIGN KEY(Abastecimento_Id) REFERENCES Abastecimento (id),
    CONSTRAINT fk_Aba_veiculo FOREIGN KEY(Veiculo_Id) REFERENCES Veiculo (id)
);



CREATE TABLE MovimentacaoPecaSaida
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Peca_Id INT UNSIGNED NOT NULL,
    OrdemServico_Id INT UNSIGNED NOT NULL,
    Data DATE NOT NULL,
    Quantidade INT UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT fk_Pec_MovimentacaoPeca FOREIGN KEY(Peca_Id) REFERENCES Peca (id),
    CONSTRAINT fk_Ord_MovimentacaoPeca FOREIGN KEY(OrdemServico_Id) REFERENCES OrdemServico (id)
);
CREATE TABLE MovimentacaoPecaEntrada
(
	Id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Peca_Id INT UNSIGNED NOT NULL,
    Data DATE NOT NULL,
    Quantidade INT UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT fk_Pec_MovimentacaoPecaEntrada FOREIGN KEY(Peca_Id) REFERENCES Peca (id)
);



INSERT INTO Veiculo(Nome, Marca, Modelo, Cor, Renavan, Placa, Ano)
VALUES("Fiesta","Chevrolet","2014","Preto","123456","ABC0001","2015"),
("BMW","Mercedez","2020","Cinza","98564","BOA9999","2019"),
("Toro","Fiat","2020","Vermelho","A67637","FIO5481","2019");

insert into veiculoviagem (Veiculo_Id, Viagem_Id) VALUES();

select * from pim.motorista;

INSERT INTO Motorista (Cpf, Nome, Cnh,Categoria_Cnh, Dt_Nascimento,Exame_Medico, Email, Endereco, Numero, Cidade, Bairro, Cep)
VALUES("47232843895","Joao Vitor Vizu", "854961", "A", "1999-05-21", "FEITO", "joaovizu@hotmail.com", "Rua dos Albergues", "159","Jabogua","Bairro 1", "14680000"),
("25019523089","Arlindo Torres", "90920", "D", "1970-11-15", "FEITO", "arlindinhozikamemu@zikas.com", "Rua dos Mosquitos", "666","Mosquitolandia", "Barrinho","85964001");

SELECT v.Id as IdVeiculo,v.Nome as Nome, v.Placa as Placa , via.situacao as Situacao,via.Local as Local, via.Km_Entrada as KmEntrada,via.Dt_Entrada as DataEntrada, 
via.Situacao as Situacao, date_format(via.Dt_Saida, '%d/%m/%Y') as DataSaida,via.Km_Saida as KmSaida,
m.Nome as `Nome Motorista`
FROM VeiculoViagem vv 
INNER JOIN veiculo v ON vv.veiculo_id = v.id 
INNER JOIN viagem via ON vv.viagem_id = via.id
inner join motorista m on via.Motorista_Cpf = m.id;