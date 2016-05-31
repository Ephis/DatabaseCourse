namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answer = new HashSet<Answer>();
            PrefabAnswers = new HashSet<PrefabAnswers>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string text { get; set; }

        public int number { get; set; }

        public int survey_id { get; set; }

        public int question_settings_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrefabAnswers> PrefabAnswers { get; set; }

        public virtual QuestionSettings QuestionSettings { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
