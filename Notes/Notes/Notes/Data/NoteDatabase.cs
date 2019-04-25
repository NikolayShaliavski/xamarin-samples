using Notes.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class NoteDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            this.database = new SQLiteAsyncConnection(dbPath);
            this.database.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return this.database.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return this.database.Table<Note>().
                                 Where(n => n.ID == id).
                                 FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return this.database.UpdateAsync(note);
            }
            return this.database.InsertAsync(note);
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return this.database.DeleteAsync(note);
        }
    }
}
