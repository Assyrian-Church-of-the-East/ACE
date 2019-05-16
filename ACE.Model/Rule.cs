using ACE.Shared;

namespace ACE.Model
{
    public class Rule : ObjectBase
    {
        public int RuleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsGlobalRule { get; set; }

        public string RuleCreator { get; set; }
    }
}
