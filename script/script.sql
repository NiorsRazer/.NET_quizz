CREATE USER quizz WITH PASSWORD 'quizz';

ALTER USER quizz WITH SUPERUSER;

CREATE DATABASE quizz;
\c quizz;

CREATE TABLE type(
    id Serial PRIMARY KEY,
    name VARCHAR(20)
);

CREATE TABLE question(
    id Serial PRIMARY KEY,
    question TEXT
);

CREATE TABLE answer(
    id Serial PRIMARY KEY,
    answer TEXT,
    id_question INT,
    FOREIGN KEY (id_question) REFERENCES question(id)
    id_type INT,
    FOREIGN KEY (id_type) REFERENCES type(id)
);

CREATE VIEW v_answer AS
SELECT 
    answer.id,
    answer,
    id_question,
    id_type,
    name

FROM answer JOIN type ON type.id=answer.id_type;