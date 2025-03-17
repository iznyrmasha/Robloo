drop database if exists College;
CREATE DATABASE College;
USE College;


create table if not exists student_group (
id_group int primary key auto_increment,
group_num char(255) not null
);

create table if not exists students(
id_student int primary key auto_increment,
firstname char(255) not null,
lastname char(255) not null,
group_nums int not null,
foreign key (group_nums) references student_group (id_group)
);


CREATE TABLE teachers (
    id_teacher INT AUTO_INCREMENT PRIMARY KEY,
    firstname CHAR(100) NOT NULL,
    lastname CHAR(100) NOT NULL
);

-- Таблица дисциплин
CREATE TABLE subjects (
    id_subjects INT AUTO_INCREMENT PRIMARY KEY,
    name_sub CHAR(100) NOT NULL
);

create table teacher_subjects (
id_teach_group int primary key auto_increment,
subject_id int not null,
teacher_id int not null,
foreign key (subject_id) references subjects (id_subjects),
foreign key (teacher_id) references teachers (id_teacher)
);



INSERT INTO `student_group` (`id_group`, `group_num`) VALUES (1, '237');
INSERT INTO `student_group` (`id_group`, `group_num`) VALUES (2, '120');
INSERT INTO `student_group` (`id_group`, `group_num`) VALUES (3, '493');
INSERT INTO `student_group` (`id_group`, `group_num`) VALUES (4, '471');
INSERT INTO `student_group` (`id_group`, `group_num`) VALUES (5, '336');

INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (1, 'Иван', 'Петров', 2);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (2, 'Алексей', 'Смирнов', 3);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (3, 'Ольга', 'Козлова', 4);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (4, 'Марина', 'Давыдова', 4);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (5, 'Матвей', 'Васильев', 3);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (6, 'Вероника', 'Федорова', 1);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (7, 'Николай', 'Братков', 1);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (8, 'Константин', 'Белый', 2);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (9, 'Галина', 'Гончарова', 3);
INSERT INTO `students` (`id_student`, `firstname`, `lastname`, `group_nums`) VALUES (10, 'Тимофей', 'Зеленов', 3);

INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (1, 'Дмитрий', 'Винтер');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (2, 'Маргарита', 'Битова');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (3, 'Левон', 'Горчанов');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (4, 'Карина', 'Функе');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (5, 'София', 'Фрамина');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (6, 'Марцелина', 'Шмелёва');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (7, 'Руфина', 'Визина');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (8, 'Каролина', 'Леушке');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (9, 'Делия', 'Трейтель');
INSERT INTO `teachers` (`id_teacher`, `firstname`, `lastname`) VALUES (10, 'Лаврентий', 'Коркеров');

INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (1, 'Алгоритмы и структуры данных');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (2, 'Базы данных');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (3, 'Операционные системы');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (4, 'Компьютерные сети');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (5, 'Программирование на Python');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (6, 'Веб-разработка');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (7, 'Машинное обучение');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (8, 'Кибербезопасность');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (9, 'Разработка мобильных приложений');
INSERT INTO `subjects` (`id_subjects`, `name_sub`) VALUES (10, 'Искусственный интеллект');

insert into teacher_subjects (subject_id, teacher_id) values (1, 5), (1,4), (7,8), (8,6), (4,2), (3,3);

/*SELECT students.id_student, students.firstname, students.lastname, student_group.group_num FROM students  JOIN student_group ON students.group_num = student_group.id_group;*/