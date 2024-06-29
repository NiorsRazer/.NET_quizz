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
    FOREIGN KEY (id_question) REFERENCES question(id),
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

-- Insert types into the type table
INSERT INTO type (name) VALUES
('Parent'),
('Adult'),
('Child');

-- Insert questions into the question table
INSERT INTO question (question) VALUES
('How do you usually react when someone criticizes you?'),
('When making decisions, you:'),
('How do you typically handle conflicts?'),
('When you make a mistake, you:'),
('In a team setting, you are most likely to:'),
('How do you view rules and regulations?'),
('When you feel stressed, you:'),
('Your approach to planning is:'),
('How do you deal with new or unexpected situations?'),
('When someone asks for your help, you:'),
('When it comes to spending money, you:'),
('Your preferred way to relax is:'),
('When you receive a compliment, you:'),
('How do you approach learning new things?'),
('When faced with a problem, you:');

-- Insert answers into the answer table
INSERT INTO answer (answer, id_question, id_type) VALUES
('I feel hurt and defensive', 1, 3),
('I calmly consider if the criticism is valid', 1, 2),
('I dismiss it and think about how they could have done better', 1, 1),

('Follow your gut feeling', 2, 3),
('Analyze the facts and options', 2, 2),
('Rely on established rules and guidelines', 2, 1),

('Avoid them and hope they go away', 3, 3),
('Address them directly and logically', 3, 2),
('Assert authority and lay down rules', 3, 1),

('Feel guilty and worry about being scolded', 4, 3),
('Reflect on what went wrong and how to improve', 4, 2),
('Justify your actions and find someone else to blame', 4, 1),

('Go along with what others decide', 5, 3),
('Contribute ideas and discuss rationally', 5, 2),
('Take charge and direct the group', 5, 1),

('As restrictive and meant to be challenged', 6, 3),
('As necessary guidelines to be followed rationally', 6, 2),
('As essential and should be strictly adhered to', 6, 1),

('Seek comfort and reassurance', 7, 3),
('Look for practical solutions to manage it', 7, 2),
('Push through and expect others to do the same', 7, 1),

('Spontaneous and flexible', 8, 3),
('Methodical and organized', 8, 2),
('Structured and often includes contingency plans', 8, 1),

('Feel anxious and unsure', 9, 3),
('Assess the situation and adapt accordingly', 9, 2),
('Rely on past experiences and standard procedures', 9, 1),

('Feel obliged to help even if its inconvenient', 10, 3),
('Consider if you can genuinely assist and respond accordingly', 10, 2),
('Offer advice based on your knowledge and experience', 10, 1),

('Spend impulsively on things you enjoy', 11, 3),
('Budget and spend according to your needs', 11, 2),
('Save and invest wisely, thinking of the future', 11, 1),

('Play games or engage in fun activities', 12, 3),
('Read a book or watch a documentary', 12, 2),
('Do something productive or educational', 12, 1),

('Feel proud and seek more praise', 13, 3),
('Accept it graciously and modestly', 13, 2),
('Deflect it and highlight others contributions', 13, 1),

('With excitement and curiosity', 14, 3),
('With a systematic approach to understand fully', 14, 2),
('By referencing existing knowledge and experience', 14, 1),

('Hope someone else will solve it', 15, 3),
('Analyze the problem and find a logical solution', 15, 2),
('Take control and implement a solution based on past experiences', 15, 1);
