using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_library_models.Models
{
    public class Room : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        

        [JsonIgnore] public virtual ICollection<Book> Books { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<BookRoom> BookRooms { get; set; } = null!;
    }
}
