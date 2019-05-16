using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACE.Shared
{
    public class ObjectBase
    {
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
