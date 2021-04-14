-- USE jcontractor;

-- CREATE TABLE job
--  (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   price DECIMAL(6 , 2) NOT NULL,
--   PRIMARY KEY (id)
-- ); 

-- INSERT INTO job
-- (name, price)
-- VALUES
-- ("Cabinet", 75.99);

-- CREATE TABLE contractor
--  (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   position VARCHAR(255),
--   PRIMARY KEY (id)
-- ); 

-- INSERT INTO contractor
-- (name, position)
-- VALUES
-- ("Anthony Pinkston", "Cabinet Painter");

-- SELECT * FROM job

-- CREATE TABLE contractorjobs
--  (
--   id INT AUTO_INCREMENT,
--   jobId INT,
--   contractorId INT,
--   PRIMARY KEY (id),

-- FOREIGN KEY (jobId)
--    REFERENCES job (id)
--    ON DELETE CASCADE,

--    FOREIGN KEY (contractorId)
--    REFERENCES contractor (id)
--    ON DELETE CASCADE
-- ); 

-- DROP TABLE contractorjobs 
