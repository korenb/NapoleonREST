using System;
using System.Collections.Generic;

namespace NapoleonNotes.DAL
{
    /// <summary>
    /// Хранилище заметок (in memory)
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// Cоздать заметку
        /// </summary>
        /// <param name="note">инстанс</param>
        /// <returns></returns>
        Note Create(Note note);
        /// <summary>
        /// Получить заметку
        /// </summary>
        /// <param name="guid">идентификатор</param>
        /// <returns></returns>
        Note Get(Guid guid);
        /// <summary>
        /// Получить заметки
        /// </summary>
        /// <returns></returns>
        IEnumerable<Note> Get();
        /// <summary>
        /// Редактировать заметку
        /// </summary>
        /// <param name="note"></param>
        /// <exception cref="NotFoundException"></exception>
        void Edit(Note note);
        /// <summary>
        /// Удалить заметку
        /// </summary>
        /// <param name="guid">идентификатор</param>
        /// <exception cref="NotFoundException"></exception>
        void Remove(Guid guid);
        /// <summary>
        /// Удалить заметку
        /// </summary>
        /// <param name="note">заметка</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Remove(Note note);
    }
    public class NoteRepository : INoteRepository
    {
        private List<Note> _notes;

        public NoteRepository()
        {
            _notes = new List<Note>();
        }

        public Note Create(Note note)
        {
            note.Id = Guid.NewGuid();
            _notes.Add(note);
            return note;
        }

        public void Edit(Note note)
        {
            int index = _notes.FindIndex(e => e.Id == note.Id);
            if (index < 0)
                throw new NotFoundException()
                    .SetId(note.Id);

            _notes[index] = note;
        }

        public Note Get(Guid guid)
        {
            return _notes.Find(e => e.Id == guid);
        }

        public IEnumerable<Note> Get()
        {
            return _notes;
        }

        public void Remove(Guid guid)
        {
            var entity = _notes.Find(e => e.Id == guid);
            if (entity == null)
                throw new NotFoundException()
                    .SetId(guid);

            Remove(entity);
        }

        public void Remove(Note note)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            _notes.Remove(note);
        }
    }
}
