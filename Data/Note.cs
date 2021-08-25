using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Data
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteContent { get; set; }
        public DateTime DateCreate { get; set; }
        public bool NoteIsView { get; set; }
    }
}
