using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NapoleonNotes.Models
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset DateUpdate { get; set; }
    }
}
