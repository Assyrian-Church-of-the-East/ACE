using ACE.Shared;

namespace ACE.Model
{
    public class Note : ObjectBase
    {
        public int NoteId { get; set; }

        public string Comment { get; set; }

        public bool IsObsolete { get; set; }

        public int? MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
