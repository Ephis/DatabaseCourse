namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionTrigger")]
    public partial class QuestionTrigger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionTrigger()
        {
            QuestionSettings = new HashSet<QuestionSettings>();
        }

        public int id { get; set; }

        public bool answer { get; set; }

        public int jump_to { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionSettings> QuestionSettings { get; set; }
    }
}
