namespace Entities
{
    public class Note
    {
        private int id;
        private DateTime created;
        private string titel;
        private string text;

        public Note(int id, DateTime created, string titel, string text)
        {
            Id = id;
            Created = created;
            Titel = titel;
            Text = text;
        }
        public Note(DateTime created, string titel, string text)
            :this(0, created, titel, text)
        {
            
        }

        public int Id { get => id; set => id = value; }
        public DateTime Created { get => created; set => created = value; }
        public string Titel { get => titel; set => titel = value; }
        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}