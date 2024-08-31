CREATE DATABASE AdaptableMgmtDB;
USE AdaptableMgmtDB;

--  DESENVOLVIMENTO INICIADO NO DIA 15/08/2024

CREATE TABLE login(

user_id int(5) PRIMARY KEY,
login_user VARCHAR(30) UNIQUE NOT NULL,
password_user VARCHAR(255) NOT NULL,

acces_master BOOLEAN DEFAULT FALSE,
acces_manager BOOLEAN DEFAULT FALSE,
acces_user BOOLEAN DEFAULT TRUE,

user_fullName VARCHAR(30)
);

CREATE TABLE user_master(

login_user varchar(100),
password_user varchar(100)

);

CREATE TABLE user(

login_user varchar(100),
password_user varchar(100)

);


CREATE TABLE collaborator(

collaborator_id INT(5) NOT NULL UNIQUE,
FOREIGN KEY (collaborator_id) REFERENCES login(user_id),

fist_name VARCHAR(15) NOT NULL,
last_name VARCHAR(15) NOT NULL,
salary DOUBLE NOT NULL,
phone_number INT(10),
cpf VARCHAR(25) NOT NULL UNIQUE,

	address_line1 VARCHAR(50) NOT NULL,
    address_line2 VARCHAR(50),
    city VARCHAR(30) NOT NULL,
    state VARCHAR(30) NOT NULL,
    postal_code VARCHAR(10),

acces_manager BOOLEAN DEFAULT FALSE,
acces_user BOOLEAN DEFAULT TRUE

);

CREATE INDEX idx_cpf ON collaborator(cpf);

CREATE TABLE category (
category_id INT NOT NULL UNIQUE,
category_name VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE supplier (
supplier_id INT NOT NULL UNIQUE,
supplier_name VARCHAR(30) NOT NULL UNIQUE
);



CREATE TABLE product (

	-- base of product
    id_product INT(8)  PRIMARY KEY,
    name_product VARCHAR(20) NOT NULL,
    brand_product VARCHAR(15),
    price_product DOUBLE NOT NULL	,
    stock INT DEFAULT 0,	
    
    IS_service BOOLEAN NOT NULL,
    
    validity_product_service_month INT,
    about_product VARCHAR(30),
    
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES category(category_id),
    
    supplier_id INT,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);


SELECT * FROM user ;

ALTER TABLE user_master MODIFY password_user VARCHAR(100);

DELETE FROM user_master WHERE login_user = 'jalimrabei';

SET SQL_SAFE_UPDATES = 0;

SELECT * FROM user WHERE login_user = 'gabriel.leopoldob' AND password_user = '1011007Grb#';


	