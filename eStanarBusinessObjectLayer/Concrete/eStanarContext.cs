using System.Data.Entity;
using eStanar.Domain.Entities;

namespace eStanar.Domain.Concrete
{
    public partial class eStanarContext : DbContext
    {
        public eStanarContext()
            : base("name=eStanarContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Entrance> Entrances { get; set; }
        public virtual DbSet<EntranceType> EntranceTypes { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MeetingType> MeetingTypes { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<NoticeComment> NoticeComments { get; set; }
        public virtual DbSet<NoticeType> NoticeTypes { get; set; }
        public virtual DbSet<Occupant> Occupants { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<PollOption> PollOptions { get; set; }
        public virtual DbSet<PollVote> PollVotes { get; set; }
        public virtual DbSet<Representative> Representatives { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<StructurePart> StructureParts { get; set; }
        public virtual DbSet<StructurePartType> StructurePartTypes { get; set; }
        public virtual DbSet<StructureType> StructureTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Structure)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.IdAuthor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Entrance>()
                .Property(e => e.IdStructure)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Entrance>()
                .HasMany(e => e.StructutrePart)
                .WithRequired(e => e.Entrance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntranceType>()
                .HasMany(e => e.Entrance)
                .WithRequired(e => e.EntranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MeetingType>()
                .HasMany(e => e.Meeting)
                .WithRequired(e => e.MeetingType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notice>()
                .HasMany(e => e.NoticeComment)
                .WithRequired(e => e.Notice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notice>()
                .HasMany(e => e.Poll)
                .WithRequired(e => e.Notice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NoticeComment>()
                .Property(e => e.IdAuthor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NoticeType>()
                .HasMany(e => e.Notice)
                .WithRequired(e => e.NoticeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.IdPerson)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Account)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdAuthor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Notice)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdAuthor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.NoticeComment)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdAuthor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Occupant)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Owner)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PollVote)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Representative)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Poll>()
                .HasMany(e => e.PollOption)
                .WithRequired(e => e.Poll)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PollOption>()
                .HasMany(e => e.PollVote)
                .WithRequired(e => e.PollOption)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Structure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Entrance)
                .WithRequired(e => e.Structure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Notice)
                .WithRequired(e => e.Structure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Representative)
                .WithRequired(e => e.Structure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructurePart>()
                .Property(e => e.AreaInSquareMeters)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StructurePart>()
                .HasMany(e => e.Occupant)
                .WithRequired(e => e.StructurePart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructurePart>()
                .HasMany(e => e.Owner)
                .WithRequired(e => e.StructurePart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructurePartType>()
                .HasMany(e => e.StructurePart)
                .WithRequired(e => e.StructurePartType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureType>()
                .HasMany(e => e.Structure)
                .WithRequired(e => e.StructureType)
                .WillCascadeOnDelete(false);
        }
    }
}
