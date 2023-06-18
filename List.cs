using PR2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PR2.List;

namespace PR2
{
    public class List
    {
        public List<Note> Note { get; set; }
        public DateTime VibData { get; set; }
        public int SEAzer { get; set; }
        public List<Note> AllNotes { get; set; }

        public List(DateTime date)
        {
            Note = SerializotionAndDeserialization.LoadNotes(date);
            AllNotes = SerializotionAndDeserialization.LoadNotes(default);
            VibData = date;
            SEAzer = -1;
        }
        public void UpNotes()
        {
            UpNote();
        }
        private void UpNote()
        {
            this.Note = SerializotionAndDeserialization.LoadNotes(this.VibData);
        }
        public void Update()
        {
            UpdateNotes();
        }
        private void UpdateNotes()
        {
            SerializotionAndDeserialization.SaveNotes(this.AllNotes);
        }
        public void CreateNote(string nazv, string opis, DateTime date)
        {
            Note note = new Note(this.AllNotes.Count, nazv, opis, date);
            this.AllNotes.Add(note);
            UpdateNotes();
            UpNote();
        }
        public void DeleteNote(int id = -1, int heaed = -1)
        {
            if (heaed != -1)
                id = this.Note[heaed].Id;
            this.AllNotes.RemoveAll(note => note.Id == id);
            UpdateNotes();
            UpNote();
        }
    }
}
