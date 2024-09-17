--  DESENVOLVIMENTO INICIADO NO DIA 15/08/2024
-- Criação do banco de dados e uso
CREATE DATABASE AdaptableMgmtDB;
USE AdaptableMgmtDB;



-- Criação da tabela collaborator
CREATE TABLE collaborator (
    user_id INT(5) AUTO_INCREMENT PRIMARY KEY,

    first_name VARCHAR(15) NOT NULL,
    last_name VARCHAR(15) NOT NULL,
    salary DOUBLE NOT NULL,
    phone_number VARCHAR(15),
    cpf VARCHAR(25) NOT NULL UNIQUE,
    address_line1 VARCHAR(50) NOT NULL,
    address_line2 VARCHAR(50),
    city VARCHAR(30) NOT NULL,
    state VARCHAR(30) NOT NULL,
    postal_code VARCHAR(10),
    acces_manager BOOLEAN DEFAULT FALSE,
    acces_user BOOLEAN DEFAULT TRUE
);

-- Criação da tabela login
CREATE TABLE login (
    user_id INT(5)  AUTO_INCREMENT  PRIMARY KEY,
    
    FOREIGN KEY (user_id) REFERENCES collaborator(user_id),
    login_user VARCHAR(30) UNIQUE NOT NULL,
    password_user VARCHAR(255) NOT NULL,
    acces_master BOOLEAN DEFAULT FALSE,
    acces_manager BOOLEAN DEFAULT FALSE,
    acces_user BOOLEAN DEFAULT TRUE
);

-- Índice para CPF
CREATE INDEX idx_cpf ON collaborator(cpf);

-- Criação da tabela category
CREATE TABLE category (
    category_id INT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(30) NOT NULL UNIQUE
);

-- Criação da tabela supplier
CREATE TABLE supplier (
    supplier_id INT AUTO_INCREMENT PRIMARY KEY,
    supplier_name VARCHAR(30) NOT NULL UNIQUE
);

-- Criação da tabela product
CREATE TABLE product (
    id_product INT(8) AUTO_INCREMENT PRIMARY KEY,
    name_product VARCHAR(20) NOT NULL,
    brand_product VARCHAR(15),
    price_product DOUBLE NOT NULL,
    stock INT DEFAULT 0,
    is_service BOOLEAN NOT NULL,
    validity_product_service_month INT,
    about_product VARCHAR(30),
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES category(category_id),
    supplier_id INT,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

-- Teste para verificar a criação da tabela login
SELECT * FROM login;

SELECT * FROM collaborator;

-- Desabilita atualizações seguras para consultas
SET SQL_SAFE_UPDATES = 0;

drop table collaborator;
drop database adaptablemgmtdb;

-- Exemplo de consulta na tabela user (Nota: A tabela 'user' não está criada neste script, ajuste conforme necessário)
-- SELECT * FROM user WHERE login_user = 'gabriel.leopoldob' AND password_user = '1011007Grb#';
