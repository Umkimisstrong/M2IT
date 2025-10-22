using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    /// <summary>
    /// TrainingEntity : 훈련 테이블
    /// </summary>
    [Table("tb_rtn_training")]
    public class TrainingEntity
    {
        [Key]
        [Column("TRAINING_ID")]
        public int TrainingId { get; set; }

        [Column("TRAINING_NM")]
        public string TrainingNm { get; set; }
        [Column("TRAINING_DESC")]
        public string TrainingDesc { get; set; }
        [Column("TRAINING_CD")]
        public string TrainingCd { get; set; }
        [Column("TRAINING_SET")]
        public int TrainingSet { get; set; }
        [Column("TRAINING_REPS")]
        public int TrainingReps { get; set; }
        [Column("TRAINING_WEIGHT")]
        public int TrainingWeight { get; set; }
        [Column("ROUTINE_ID")]
        public int RoutineId {  get; set; }
        [Column("TRAINING_CREATE_ID")]
        public string CreatedBy { get; set; } = "";
        [Column("TRAINING_CREATE_DT")]
        public DateTime CreatedAt { get; set; }
        [Column("TRAINING_UPDATE_ID")]
        public string UpdatedBy { get; set; } = "";
        [Column("TRAINING_UPDATE_DT")]
        public DateTime UpdatedAt { get; set; }

    }
}
