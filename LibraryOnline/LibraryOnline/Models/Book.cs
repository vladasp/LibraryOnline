using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryOnline.Models

{
    public class Book
    {
        [Key]
        [Column("Id book")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        //public object[,] Story { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}