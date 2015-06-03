CREATE TABLE photos (
   id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
   title VARCHAR(100) NOT NULL,
   description TEXT NOT NULL,
   file_ref VARCHAR(100) NOT NULL
);
INSERT INTO photos (title, description, file_ref)
VALUES ('TEST', 'This is a photo', 'photo.jpg');
