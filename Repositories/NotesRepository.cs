using DAL.Entities;
using Microsoft.Data.SqlClient;


namespace DAL.Repositories
{

    public interface INotesRepository
    {
        bool Add(Note note);
        bool Edit(int Id, Note note);
        bool Delete(int id);
        Note GetById(int id);
        List<Note> GetAll();
    }
    internal class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext _dbContext;
        public NotesRepository(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@$"delete from Notes where Id = {id}", con))
                {
                    con.Open();
                    var noAffectedRows = cmd.ExecuteNonQuery();
                    con.Close();
                    return noAffectedRows == 1;
                }
            }
        }

        public List<Note> GetAll()
        {
            //List<Note> notes = new List<Note>();
            //using (SqlConnection conn = new SqlConnection(Utils.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select * from notes ", conn))
            //    {
            //        conn.Open();
            //        var reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            notes.Add(new Note
            //            {
            //                Id = (int)reader["Id"],
            //                Title = (string)reader["Title"],
            //                Description = (string)reader["Description"]
            //            });
            //            conn.Close();
            //        }
            //    }
            //    return notes;
            var list = new List<Note>();
            var accounts = _dbContext.Notes;
            list = accounts.ToList();
            return list;
        }
    


        

        public bool Add(Note note)
        {
            //using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand($@"
            //               Insert into Notes(Id,Title,Description)
            //                values ('{note.Id}''{note.Title}',{note.Description})", con))
            //    {
            //        con.Open();
            //        var noAffectedRows = cmd.ExecuteNonQuery();
            //        con.Close();
            //        return noAffectedRows == 1;
            //    }
            //}

            _dbContext.Notes.Add(note);
            return true;
        }

        public bool Edit(int Id, Note note)
        {
            //using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(@$"
            //        update Notes set Name = '{note.Title}'
            //        where Id = {Id}
            //", con))
            //    {
            //        con.Open();
            //        var noAffectedRows = cmd.ExecuteNonQuery();
            //        con.Close();
            //        return noAffectedRows == 1;
            //    }
            //}

            _dbContext.Notes.Update(note);
            return true;
        }

        public Note GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Utils.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"select * from Notes where Id = {id}", conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var n = new Note()
                        {
                            Id = (int)reader["id"],
                            Title = (string)reader["title"],
                            Description = (string)reader["description"]
                        };
                        return n;
                    }
                    conn.Close();
                }
            }
            return null;
        }
    }
}
