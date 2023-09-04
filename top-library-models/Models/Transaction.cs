using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_library_models.Models
{
    public class Transaction : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
    }
}
