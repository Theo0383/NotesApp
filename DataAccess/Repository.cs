using Entities;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NotesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Repository()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Could not extablish a connection to the database", e);
            }
        }

        public List<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Notes";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Note note = new(
                        (int)reader["NoteId"],
                        (DateTime)reader["Created"],
                        (string)reader["Title"],
                        (string)reader["Text"]
                    );
                    notes.Add(note);
                }
                connection.Close();
                connection.Dispose();
                return notes;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Could not extablish a connection to the database", e);
            }
        }
        public void SaveNew(Note note)
        {
            string sql = $"INSERT INTO Notes(created, Title, Text) VALUES('{note.Created.ToString("yyyy-MM-dd HH:mm:ss")}', '{note.Titel}', '{note.Text}');";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
    }
}