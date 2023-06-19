using System.ComponentModel.DataAnnotations.Schema;
using PersonalData.Model.Base;

namespace PersonalData.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}

