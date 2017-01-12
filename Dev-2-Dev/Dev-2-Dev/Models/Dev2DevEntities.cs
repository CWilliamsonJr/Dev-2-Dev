namespace Dev_2_Dev.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dev2DevEntities : DbContext
    {
        public Dev2DevEntities()
            : base("name=Dev2DevEntities")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Dev2DevEntities>());
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<MentorSkill> MentorSkills { get; set; }
        public virtual DbSet<MenteeSkill> MenteeSkills { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Mentee> Mentees { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRole)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
