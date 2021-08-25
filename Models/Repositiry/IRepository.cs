using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Models.Repositiry
{
    interface IRepository
    {
        IEnumerable<Note> GetAllNotes();

        IEnumerable<Note> SearchNotes(string searchTitle);

        void AddNote(string title, string noteContent);

        void EditNote(Note note);

        void DeleteNote(int id);

        bool ViewNote(int id);

    }
}
