namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SurveyAdmin")]
    public partial class SurveyAdmin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SurveyAdmin()
        {
            Survey = new HashSet<Survey>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(75)]
        public string name { get; set; }

        [Required]
        [StringLength(20)]
        public string user_name { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Survey> Survey { get; set; }
    }
}
