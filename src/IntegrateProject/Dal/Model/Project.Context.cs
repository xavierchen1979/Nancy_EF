using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrateProject.Dal.Model
{
	using System.Data.Entity;

	public partial class ProjectEntityDB:DbContext
	{
        public ProjectEntityDB() : base("IntergrateProject") { }

        public virtual DbSet<Team> TeamSet { set; get; }
        public virtual DbSet<Member> MemberSet { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Team>().HasKey(e=>e.TeamID);
            modelBuilder.Entity<Member>().HasKey(e=>e.MemberID);

            modelBuilder.Entity<Team>().HasMany(e => e.MemberList).WithRequired(e=>e.team);

            base.OnModelCreating(modelBuilder);
        }
	}
}