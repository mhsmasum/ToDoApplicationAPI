using AutoMapper;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Mapper
{
    public class ApplicatinProfile:Profile
    {
        public ApplicatinProfile()
        {
            CreateMap<CreateToDo, ToDo>( ).ReverseMap();
            CreateMap<ToDo, ToDoVM>( ).ReverseMap();
            CreateMap<UpdateToDo, ToDo>().ReverseMap();


            /// Notes
            /// 

            CreateMap<CreateNote, Note>().ReverseMap();
            CreateMap<Note, NoteVM>().ReverseMap();
            CreateMap<UpdateNote, Note>().ReverseMap();

            /// Bookmark
            /// 

            CreateMap<CreateBookmark, Bookmark>().ReverseMap();
            CreateMap<Bookmark, BookmarkVM>().ReverseMap();
            CreateMap<UpdateBookmark, Bookmark>().ReverseMap();


            /// Reminder
            /// 

            CreateMap<CreateReminder, Reminder>().ReverseMap();
            CreateMap<Reminder, ReminderVM>().ReverseMap();
            CreateMap<UpdateReminder, Reminder>().ReverseMap();

        }
    }
}
