namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        [Key]
        [Column("rating", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rating1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int survey_id { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual SurveyUser SurveyUser { get; set; }
    }
}
