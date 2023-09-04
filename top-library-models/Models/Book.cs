namespace top_library_models.Models
{
    public class Book : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;
        [Required] public string Title { get; set; } = null!;
        [Required] public string AuthorName { get; set; } = null!;
        public int PagesCount { get; set; }
        public string Genre { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
        public bool IsAvailible { get; set; } //todo: calculate availibility


        [JsonIgnore]public virtual ICollection<Transaction> Transactions { get; set; } = null!;
        [JsonIgnore]public virtual ICollection<BookRoom> BookRooms { get; set; } = null!;



    }
}
