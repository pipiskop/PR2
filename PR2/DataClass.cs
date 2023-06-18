using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PR2
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string NAMING { get; set; }
        public string Description { get; set; }
        public Note(int id, string nazvanie, string opisanie, DateTime date)
        {
            Id = id;
            NAMING = nazvanie;
            Description = opisanie;
            Date = date;
        }
    }
}

