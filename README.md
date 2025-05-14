CREATE TABLE Customer (
customerId SERIAL PRIMARY KEY,
customerCode VARCHAR(50) NOT NULL,
customerName VARCHAR(255) NOT NULL,
customerAddress VARCHAR(1000) DEFAULT '' NOT NULL,
createdBy INT NOT NULL,
createdAt TIMESTAMP NOT NULL,
modifiedBy INT NULL,
modifiedAt TIMESTAMP NULL
);
