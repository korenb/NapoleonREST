using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NapoleonNotes.Models
{
    public class DeleteNoteModel
    {
        [Required, BindRequired]
        public Guid Id { get; set; }
    }
}
