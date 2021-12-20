using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunya.Data
{
    [Table("Yerler")]
    public class Yer
    {
        public Yer()
        {
        }
        public Yer(string ad)
        {
            Ad = ad;
        }
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Ad { get; set; }

        public int? ParentId { get; set; }
        public virtual Yer Parent { get; set; }
        public virtual ICollection<Yer>  Children { get; set; } = new HashSet<Yer>();
    }
}
