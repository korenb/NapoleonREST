using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NapoleonNotes.DAL;
using NapoleonNotes.Models;

namespace NapoleonNotes.Mapper
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteModel>()
                .ForMember(e => e.DateCreate, opt => opt.MapFrom(e => e.CreatedAt))
                .ForMember(e => e.DateUpdate, opt => opt.MapFrom(e => e.UpdatedAt))
                ;

            CreateMap<CreateNoteModel, Note>(MemberList.Source)
                .ForMember(e => e.CreatedAt, opt => opt.MapFrom(_ => DateTimeOffset.UtcNow))
                ;

            CreateMap<UpdateNoteModel, Note>(MemberList.Source)
                .ForMember(e => e.UpdatedAt, opt => opt.MapFrom(_ => DateTimeOffset.UtcNow))
                ;
        }
    }
}
