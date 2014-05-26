namespace LRDNUG_V2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class lrdnugweb : DbContext
    {
        public lrdnugweb(string connectionStringName) :
            base(connectionStringName)
        {
        }

        public lrdnugweb()
            : base("name=lrdnugweb")
        {
        }

        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
