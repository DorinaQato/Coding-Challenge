using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Note> Notes { get; set; }
    }
}
