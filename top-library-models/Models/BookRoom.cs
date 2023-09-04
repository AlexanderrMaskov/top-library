using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_library_models.Models
{
    public class BookRoom : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public int Count { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;

    }
}
