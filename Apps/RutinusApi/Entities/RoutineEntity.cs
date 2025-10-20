namespace RutinusApi.Entities
{
    public class RoutineEntity
    {
        public string routineId { get; set; }
        public string routineName { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public double defaultWeight { get; set; }
        public bool receiveNotifications { get; set; }
        public List<string> bodyParts { get; set; }
        public string selectedBodyPart { get; set; }
        public string bodyPart { get; set; }
        
    }
}
