using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NapoleonNotes.DAL;
using AutoMapper;
using NapoleonNotes.Models;

namespace NapoleonNotes.Controllers
{
    [Route("/")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteRepository _notes;
        IMapper _mapper;

        public NoteController(INoteRepository repo, IMapper mapper)
        {
            _notes = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var notes = _notes.Get();
            var data = _mapper.Map<IEnumerable<NoteModel>>(notes);

            return Ok(data);
        }
        
        [HttpPost]
        public IActionResult Get([FromBody]CreateNoteModel model)
        {
            var note = _mapper.Map<Note>(model);
            note = _notes.Create(note);
            var data = _mapper.Map<NoteModel>(note);
            return Ok(data);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody]UpdateNoteModel model)
        {
            try
            {
                var note = _notes.Get(model.Id);
                if (note == null) return NotFound();
                _mapper.Map(model, note);
                _notes.Edit(note);
                var data = _mapper.Map<NoteModel>(note);
                return Ok(data);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpDelete]
        public IActionResult Delete([FromBody]DeleteNoteModel model)
        {
            try
            {
                _notes.Remove(model.Id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
