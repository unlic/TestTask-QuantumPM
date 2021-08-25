using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Models.Repositiry
{
    public class Repository:IRepository
    {
        private readonly DBContext _context;

        public Repository(DBContext context)
        {
            _context = context;
        }

        public void AddNote(string title, string noteContent)
        {
            Note newNote = new Note()
            {
                Title = title,
                NoteContent = noteContent,
                DateCreate = DateTime.Now
            };
            _context.Add(newNote);
            _context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var item = _context.NoteItems.Find(id);
            if (item != null)
            {
                _context.NoteItems.Remove(item);
                _context.SaveChanges();
            }

        }

        public void EditNote(Note editNote)
        {
            var item = _context.NoteItems.Attach(editNote);            
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var notes = _context.NoteItems.Where(p => p.NoteIsView == true);
            foreach (var item in notes)
            {
                item.NoteIsView = false;
            }

            return _context.NoteItems;
        }

        public IEnumerable<Note> SearchNotes(string searchTitle)
        {
            var notes = _context.NoteItems.Where(p => p.Title.Contains(searchTitle));
            return notes;
        }

        public bool ViewNote(int id)
        {
            var item = _context.NoteItems.Find(id);
           
            
            if (item != null)
            {
                if (item.NoteIsView == true)
                {
                    item.NoteIsView = !item.NoteIsView;
                    _context.NoteItems.Find(id).NoteIsView = item.NoteIsView;
                    _context.SaveChanges();
                    return item.NoteIsView;
                }
                else 
                {
                    var notes = _context.NoteItems.Where(p => p.NoteIsView == true);
                    foreach (var note in notes)
                    {
                        note.NoteIsView = false;
                    }

                    item.NoteIsView = !item.NoteIsView;
                    _context.NoteItems.Find(id).NoteIsView = item.NoteIsView;
                    _context.SaveChanges();
                }
                
                

            }
            return item.NoteIsView;
        }
    }
}
