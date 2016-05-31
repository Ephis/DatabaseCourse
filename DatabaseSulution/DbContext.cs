namespace DatabaseSulution
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<PrefabAnswers> PrefabAnswers { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionSettings> QuestionSettings { get; set; }
        public virtual DbSet<QuestionTrigger> QuestionTrigger { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyAdmin> SurveyAdmin { get; set; }
        public virtual DbSet<SurveyUser> SurveyUser { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.answer1)
                .IsUnicode(false);

            modelBuilder.Entity<PrefabAnswers>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<PrefabAnswers>()
                .HasMany(e => e.Answer)
                .WithOptional(e => e.PrefabAnswers)
                .HasForeignKey(e => e.prefab_answer);

            modelBuilder.Entity<Question>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.question_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.PrefabAnswers)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.question_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionSettings>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.QuestionSettings)
                .HasForeignKey(e => e.question_settings_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionTrigger>()
                .HasMany(e => e.QuestionSettings)
                .WithOptional(e => e.QuestionTrigger)
                .HasForeignKey(e => e.trigger_id);

            modelBuilder.Entity<QuestionType>()
                .Property(e => e.typename)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionType>()
                .HasMany(e => e.QuestionSettings)
                .WithRequired(e => e.QuestionType)
                .HasForeignKey(e => e.question_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.Survey)
                .HasForeignKey(e => e.survey_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.Survey)
                .HasForeignKey(e => e.survey_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Rating)
                .WithRequired(e => e.Survey)
                .HasForeignKey(e => e.survey_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SurveyAdmin>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyAdmin>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyAdmin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyAdmin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyAdmin>()
                .HasMany(e => e.Survey)
                .WithRequired(e => e.SurveyAdmin)
                .HasForeignKey(e => e.admin_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SurveyUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyUser>()
                .Property(e => e.marital_status)
                .IsUnicode(false);

            modelBuilder.Entity<SurveyUser>()
                .HasMany(e => e.Answer)
                .WithOptional(e => e.SurveyUser)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<SurveyUser>()
                .HasMany(e => e.Rating)
                .WithRequired(e => e.SurveyUser)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
