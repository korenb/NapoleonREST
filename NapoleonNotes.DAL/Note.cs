using System;
using System.Collections.Generic;
using System.Text;

namespace NapoleonNotes.DAL
{
    /// <summary>
    /// Заметка
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Время создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Время обновления
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
