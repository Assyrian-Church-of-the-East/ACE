using ACE.Shared;

namespace ACE.Model
{
    public class Debt : ObjectBase
    {
        public int DebtId { get; set; }

        public int DebtYear { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
