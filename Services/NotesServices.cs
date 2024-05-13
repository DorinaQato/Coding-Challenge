using BLL.DTO;
using BLL.DTO.Requests;
using DAL.Repositories;

namespace BLL.Services
{

    public interface INotesService
    {
        bool AddNote(DTO.Requests.NoteAddModel model);
        bool DeleteNote(int noteId);
        bool EditNote(int noteId, NoteAddModel model);

        IEnumerable<DTO.Note> GetNotes();
        
    }
    internal class NotesServices : INotesService
    {
        private readonly INotesRepository _noteRepository;

        public NotesServices(INotesRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool AddNote(NoteAddModel model)
        {
            try
            {
                var addedNote = _noteRepository.Add(new DAL.Entities.Note
                {
                    Title = model.Title,
                    Description = model.Description

                });
                return addedNote;

            }
            catch 
            {

            }
            return false;
        }

        public bool DeleteNote(int noteId)
        {
            try
            {
                return _noteRepository.Delete(noteId);
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool EditNote(int noteId, NoteAddModel model)
        {
            try
            {

            var edited = _noteRepository.Edit(noteId, new DAL.Entities.Note
            {
                Title = model.Title,
                Description = model.Description
            });
            return edited;
        }
        catch (Exception ex)
        {
        }
        return false;
        }

        public IEnumerable<Note> GetNotes()
        {
            try
            {
                var notes = _noteRepository.GetAll();   
                List<DTO.Note> result = new List<DTO.Note>();
                foreach (var note in notes)
                {
                    result.Add(new DTO.Note 
                    {
                        Title = note.Title,
                        Description = note.Description 
                    });
                }
                return result;
            }
            catch (Exception ex)
            {

            }

            return new List<DTO.Note>();
        }
    }
}
