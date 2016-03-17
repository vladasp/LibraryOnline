namespace LibraryOnline
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelLib : DbContext
    {
        public ModelLib()
            : base("name=ModelLib")
        {
        }
        public virtual DbSet<Book> Books { get; set; }
    }
}