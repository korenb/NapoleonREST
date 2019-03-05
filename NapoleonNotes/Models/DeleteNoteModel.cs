using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NapoleonNotes.Models
{
    public class DeleteNoteModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
