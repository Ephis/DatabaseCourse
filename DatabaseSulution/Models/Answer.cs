namespace DatabaseSulution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int id { get; set; }

        public bool? bool_a { get; set; }

        [Column("answer")]
        [StringLength(255)]
        public string answer1 { get; set; }

        public int? prefab_answer { get; set; }

        public int survey_id { get; set; }

        public int question_id { get; set; }

        public int? user_id { get; set; }

        public virtual PrefabAnswers PrefabAnswers { get; set; }

        public virtual Question Question { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual SurveyUser SurveyUser { get; set; }
    }
}
