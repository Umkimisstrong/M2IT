using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Rutinus.Models;
using Rutinus.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Rutinus.ViewModels
{
    public partial class TrainingSaveListViewModel : ObservableObject
    {
        private readonly TrainingService _service;
        private readonly CodeService _codeService;

        public ObservableCollection<TrainingModel> ExerciseInputs { get; } = new();
        public ObservableCollection<CodeValueModel> ExerciseOptions { get; } = new();

        public IRelayCommand AddExerciseCommand { get; }
        public IAsyncRelayCommand SaveCommand { get; }

        private int _routineId;

        public TrainingSaveListViewModel()
        {
            _service = new TrainingService();
            _codeService = new CodeService();
            AddExerciseCommand = new RelayCommand(AddExerciseInput);
            SaveCommand = new AsyncRelayCommand(SaveExercisesAsync);
        }

        public async Task InitializeAsync(int routineId)
        {
            _routineId = routineId;
            await LoadExerciseOptionsAsync();
            await LoadTrainingAsync();
        }

        private void AddExerciseInput()
        {
            ExerciseInputs.Add(new TrainingModel());
        }

        private async Task LoadExerciseOptionsAsync()
        {
            var result = await _codeService.GetCodeValueRuleItemAsync("PART_003");
            if (result?.Data != null)
            {
                ExerciseOptions.Clear();
                // 첫 번째 항목을 원하는대로 추가하거나 세팅
                var firstItem = result.Data.FirstOrDefault(); // 첫 번째 아이템
                if (firstItem != null)
                {
                    ExerciseOptions.Add(new CodeValueModel { Code = firstItem.Cd, Name = firstItem.CdNm });
                }

                // 나머지 항목들을 추가
                foreach (var item in result.Data.Skip(1)) // 첫 번째 항목을 제외하고 추가
                {
                    ExerciseOptions.Add(new CodeValueModel { Code = item.Cd, Name = item.CdNm });
                }
            }
        }

        private async Task LoadTrainingAsync()
        {
            try
            {
                var response = await _service.GetTrainingListAsync(_routineId);
                if (response.Success && response.Data != null)
                {
                    ExerciseInputs.Clear();

                    foreach (var item in response.Data)
                    {
                        var selected = ExerciseOptions.FirstOrDefault(x => x.Code == item.TrainingCd);

                        if (selected == null)
                        {
                            Debug.WriteLine($"[경고] 일치하는 ExerciseOption이 없습니다: {item.TrainingCd}");
                        }
                        else
                        {
                            item.SelectedExercise = ExerciseOptions.FirstOrDefault(x => x.Code == item.TrainingCd); // ✅ 직접 참조 할당
                        }

                        ExerciseInputs.Add(item);
                    }
                }
                else
                {
                    Debug.WriteLine("훈련 목록을 불러오지 못했습니다.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoadTrainingAsync Error] {ex.Message}");
            }
        }

        private async Task SaveExercisesAsync()
        {
            // 저장 로직 구현
        }

        // 이 변수는 ViewModel에 추가해야 합니다.
        private CodeValueModel _selectedExercise;
        public CodeValueModel SelectedExercise
        {
            get => _selectedExercise;
            set => SetProperty(ref _selectedExercise, value);
        }
    }
}