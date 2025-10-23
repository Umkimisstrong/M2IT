namespace RutinusApi.Models
{
    /// <summary>
    /// TrainingDto : 통신에 사용될 훈련 모델
    /// </summary>
    public class TrainingDto
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string AlertYn { get; set; } = "N";
        public string RoutinePartName { get; set; } = "";
        public int TrainingId { get; set; } = 0;
        public string TrainingNm { get; set; } = "";
        public string TrainingDesc { get; set; } = "";
        public string TrainingCd { get; set; } = "";
        public string TrainingCdName { get; set; } = "";
        public int TrainingSet { get; set; } = 0;
        public int TrainingReps { get; set; } = 0;
        public int TrainingWeight { get; set; } = 0;
        public string CreatedBy { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; } = "";
        public DateTime? UpdatedAt { get; set; }
    }
}
