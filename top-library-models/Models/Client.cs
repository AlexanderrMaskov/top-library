using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_library_models.Models
{
    public class Client : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;
        [Required] [StringLength(20)] public string? Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; } = null!;
        public Gender Gender { get; set; }


        [JsonIgnore] public virtual ICollection<Book> Books { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Transaction> Transactions { get; set; } = null!;


    }
}
