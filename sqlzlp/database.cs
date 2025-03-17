using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sqlzlp
{
    public class DataBase
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=College; port=3306; password=123456789");

        public List<students> GetStudents()
        {
            List<students> stud_list = new List<students>();
            try
            {
                connection.Open();
                string query = "SELECT id_student, firstname, lastname, group_num " +
                    "FROM students " +
                    "JOIN student_group ON group_nums = id_group";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    students Students = new students();
                    Students.Id_student = Convert.ToInt32(dataReader["id_student"]);
                    Students.Firstname = dataReader["firstname"].ToString();
                    Students.Lastname = dataReader["lastname"].ToString();
                    Students.Group_num = dataReader["group_num"].ToString();
                    stud_list.Add(Students);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return stud_list;
        }

        public List<teachers> GetTeachers()
        {
            List<teachers> teach_list = new List<teachers>();
            try
            {
                connection.Open();
                string query = "SELECT id_teacher, firstname, lastname, name_sub from teachers " +
                    "join teacher_subjects on id_teacher = teacher_id " +
                    "join subjects on subject_id = id_subjects";
               
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    teachers Teachers = new teachers();
                    Teachers.Id_teacher = Convert.ToInt32(dataReader["id_teacher"]);
                    Teachers.Firstname = dataReader["firstname"].ToString();
                    Teachers.Lastname = dataReader["lastname"].ToString();
                    Teachers.TeacherSubject = dataReader["name_sub"].ToString();
                    teach_list.Add(Teachers);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return teach_list;
        }

        public List<student_group> Get_Group()
        {
            List<student_group> Student_group = new List<student_group>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT id_group, group_num FROM student_group";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    student_group groups = new student_group
                    {
                        Id_group = Convert.ToInt32(dataReader["id_group"]),
                        Group_num = dataReader["group_num"].ToString()
                    };
                    Student_group.Add(groups);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка загрузки групп: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Student_group;
        }


        public List<subjects> GetSubjects()
        {
            List<subjects> sub_list = new List<subjects>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM subjects ";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    subjects Subjects = new subjects();
                    Subjects.Id_subject = Convert.ToInt32(dataReader["id_subjects"]);
                    Subjects.Name_sub = dataReader["name_sub"].ToString();
                    sub_list.Add(Subjects);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return sub_list;
        }

        public void App_Studens(string firstname, string lastname, int group_num)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "INSERT INTO students (firstname, lastname, group_nums) VALUES(@firstname, @lastname, @group_num)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.Parameters.AddWithValue("@firstname", firstname);
                mySqlCommand.Parameters.AddWithValue("@lastname", lastname);
                mySqlCommand.Parameters.AddWithValue("@group_num", group_num);
                mySqlCommand.ExecuteNonQuery();

                Console.WriteLine("Студент успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении студента: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void App_Teachers(string firstname, string lastname, int subjectId)
        {
            try
            {
                
                    connection.Open();
                string query = "INSERT INTO teachers (firstname, lastname) VALUES (@firstname, @lastname); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);

                int teacherId = Convert.ToInt32(cmd.ExecuteScalar());

                query = "INSERT INTO teacher_subjects (subject_id, teacher_id) VALUES (@subject_id, @teacher_id)";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@subject_id", subjectId);
                cmd.Parameters.AddWithValue("@teacher_id", teacherId);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Преподаватель успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении преподавателя: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void RemoveFromTeachers(int Id_teacher)
        {
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM teacher_subjects WHERE teacher_id = @teacherid", connection);
                command.Parameters.AddWithValue("@teacherid", Id_teacher);
                command.ExecuteNonQuery(); 

                command = new MySqlCommand("DELETE FROM teachers WHERE id_teacher = @teacherid", connection);
                command.Parameters.AddWithValue("@teacherid", Id_teacher);
                command.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при удалении: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void RemoveFromPatients(int patientId)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM students WHERE id_student = @patientId", connection);
           
            command.Parameters.AddWithValue("@patientId", patientId);

            command.ExecuteNonQuery();
            connection.Close();
        }


        public void App_Subjects(string Name_sub)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "INSERT INTO subjects (name_sub) VALUES(@sub_n)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.Parameters.AddWithValue("@sub_n", Name_sub);
                mySqlCommand.ExecuteNonQuery();

                Console.WriteLine("Предмет успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении предмета: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveFromSubjects(int Id_subject)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM subjects WHERE id_subjects = @subId", connection);

            command.Parameters.AddWithValue("@subId", Id_subject);

            command.ExecuteNonQuery();
            connection.Close();
        }

        
        public void App_Student(string firstname, string lastname, string group_num)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO students (firstname, lastname, group_num) VALUES (@firstname, @lastname, @group_num)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.Parameters.AddWithValue("@firstname", firstname);
                mySqlCommand.Parameters.AddWithValue("@lastname", lastname);
                mySqlCommand.Parameters.AddWithValue("@stud_group", group_num);

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
