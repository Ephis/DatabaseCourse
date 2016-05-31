namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrefabAnswers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrefabAnswers()
        {
            Answer = new HashSet<Answer>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string text { get; set; }

        public int question_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answer { get; set; }

        public virtual Question Question { get; set; }
    }
}
