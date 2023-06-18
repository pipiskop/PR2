using PR2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2
{
    public class SerializotionAndDeserialization
    {
        public static void SaveNotes(List<Note> notes)
        {
            File.WriteAllText("Jsom.json", JsonConvert.SerializeObject(notes));
        }
        public static List<Note> LoadNotes(DateTime date = default)
        {
            List<Note> notes = new List<Note>();
            try
            {
                string json = File.ReadAllText("Jsom.json");
                if (json != "")
                {
                    notes = JsonConvert.DeserializeObject<List<Note>>(json);
                }
            }
            catch
            {
                File.WriteAllText("Jsom.json", JsonConvert.SerializeObject(notes));
            }
            return notes.Where(n => n.Date == date || date == default).ToList();
        }
    }
}



