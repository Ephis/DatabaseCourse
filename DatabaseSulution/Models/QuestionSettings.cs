namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuestionSettings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionSettings()
        {
            Question = new HashSet<Question>();
        }

        public int id { get; set; }

        public int a_amount { get; set; }

        public int question_type { get; set; }

        public int? trigger_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Question { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual QuestionTrigger QuestionTrigger { get; set; }
    }
}
