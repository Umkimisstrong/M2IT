using CommunityToolkit.Mvvm.ComponentModel;

namespace Rutinus.Models
{
    /// <summary>
    /// TrainingModel : 훈련 테이블과 매치
    /// </summary>
    public partial class TrainingModel : ObservableObject
    {
        [ObservableProperty]
        private int routineId;

        [ObservableProperty]
        private string routineName = "";

        [ObservableProperty]
        private string routineDescription = "";

        [ObservableProperty]
        private string routinePart = "";

        [ObservableProperty]
        private string alertYn = "N";

        [ObservableProperty]
        private string routinePartName = "";

        [ObservableProperty]
        private int trainingId;

        [ObservableProperty]
        private string trainingNm = "";

        [ObservableProperty]
        private string trainingDesc = "";

        [ObservableProperty]
        private string trainingCd = "";

        [ObservableProperty]
        private string trainingCdName = "";

        [ObservableProperty]
        private int trainingSet;

        [ObservableProperty]
        private int trainingReps;

        [ObservableProperty]
        private int trainingWeight;

        [ObservableProperty]
        private string createdBy = "";

        [ObservableProperty]
        private DateTime createdAt;

        [ObservableProperty]
        private string updatedBy = "";

        [ObservableProperty]
        private DateTime updatedAt;

        [ObservableProperty]
        private CodeValueModel? selectedExercise;
       
    }
}
