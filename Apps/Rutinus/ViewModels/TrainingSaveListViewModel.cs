using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Models;
using Rutinus.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Rutinus.ViewModels
{
    /// <summary>
    /// TrainingSaveListViewModel : TrainingSaveList 에서 사용되는 ViewModel
    /// </summary>
    public partial class TrainingSaveListViewModel : ObservableObject
    {
        #region Init
        private readonly TrainingService _service;
        private readonly CodeService _codeService;
        private readonly RoutineService _routineService;
        private RoutineModel _routineModel;
        public ObservableCollection<TrainingModel> ExerciseInputs { get; } = new();
        public ObservableCollection<CodeValueModel> ExerciseOptions { get; set; } = new();

        [ObservableProperty]
        private string routinNameOfTraining = "";

        public IRelayCommand AddExerciseCommand { get; }
        public IAsyncRelayCommand SaveCommand { get; }

        private int _routineId;
        private string _loginUserId;


        public TrainingSaveListViewModel()
        {
            _service = new TrainingService();
            _codeService = new CodeService();
            _routineService = new RoutineService();
            AddExerciseCommand = new RelayCommand(AddExerciseInput);
            SaveCommand = new AsyncRelayCommand(SaveExercisesAsync);
        }

        /// <summary>
        /// InitializeAsync : 화면 정보 초기화
        /// </summary>
        /// <param name="routineId"></param>
        /// <returns></returns>
        public async Task InitializeAsync(int routineId)
        {
            _routineId = routineId;
            _loginUserId = ((App)Application.Current).CurrentUser != null ? ((App)Application.Current).CurrentUser.LoginUserId : "KIMSANGKI";
            ApiResponse <RoutineModel> result = await _routineService.GetRoutineAsync(routineId);
            if (result != null && result.Success)
            {
                _routineModel = result.Data;
            }
            await LoadExerciseOptionsAsync();
            await LoadTrainingAsync();
        }

        #endregion

        #region Command
        /// <summary>
        /// AddExerciseInput : 훈련종목 화면에서 추가
        /// </summary>
        private void AddExerciseInput()
        {
            ExerciseInputs.Add(new TrainingModel());

        }

        /// <summary>
        /// LoadExerciseOptionsAsync : 훈련종목 코드 조회
        /// </summary>
        /// <returns></returns>
        private async Task LoadExerciseOptionsAsync()
        {

            var result = await _codeService.GetCodeValueRuleItemAsync(_routineModel.RoutinePart);
            var trainingParts = new ObservableCollection<CodeValueModel>();
            if (result?.Data != null)
            {
                foreach (var code in result.Data)
                {
                    CodeValueModel model = new CodeValueModel();
                    model.Code = code.Cd;
                    model.Name = code.CdNm;

                    trainingParts.Add(model);
                }

                ExerciseOptions = trainingParts;
            }
        }

        /// <summary>
        /// LoadTrainingAsync : 훈련 목록 조회
        /// </summary>
        /// <returns></returns>
        private async Task LoadTrainingAsync()
        {
            try
            {
                RoutinNameOfTraining = _routineModel.RoutineName;

                var response = await _service.GetTrainingListAsync(_routineId);
                if (response.Success && response.Data != null)
                {
                    ExerciseInputs.Clear();
                    int i = 0;
                    foreach (var item in response.Data)
                    {


                        ExerciseInputs.Add(item);
                        var selected = ExerciseOptions.FirstOrDefault(x => x.Code == item.TrainingCd);

                        if (selected == null)
                        {
                            ExerciseInputs[i].SelectedExercise = ExerciseOptions.First();
                        }
                        else
                        {
                            ExerciseInputs[i].SelectedExercise = ExerciseOptions.FirstOrDefault(x => x.Code == item.TrainingCd); // ✅ 직접 참조 할당
                        }
                        i++;
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

        /// <summary>
        /// SaveExercisesAsync : 훈련 저장
        /// </summary>
        /// <returns></returns>
        private async Task SaveExercisesAsync()
        {
            // 저장 로직 구현
            try
            {
                List<TrainingModel> request = new List<TrainingModel>();
                for (int i = 0; i < ExerciseInputs.Count; i++)
                {

                    if (ExerciseInputs[i].SelectedExercise == null)
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 종목을 선택하세요.", "확인");
                        return;
                    }

                    if (string.IsNullOrEmpty(ExerciseInputs[i].SelectedExercise.Code))
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 종목을 선택하세요.", "확인");
                        return;
                    }
                    ExerciseInputs[i].TrainingCd = ExerciseInputs[i].SelectedExercise.Code;


                    if (ExerciseInputs[i].TrainingWeight <= 0)
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 중량을 설정하세요.", "확인");
                        return;
                    }
                    if (ExerciseInputs[i].TrainingReps <= 0)
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 반복횟수를 설정하세요.", "확인");
                        return;
                    }

                    if (ExerciseInputs[i].TrainingSet <= 0)
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 세트수를 설정하세요.", "확인");
                        return;
                    }

                    if (string.IsNullOrEmpty(ExerciseInputs[i].TrainingNm))
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 이름을 입력하세요.", "확인");
                        return;
                    }

                    if (string.IsNullOrEmpty(ExerciseInputs[i].TrainingDesc))
                    {
                        await App.Current.MainPage.DisplayAlert("오류", "훈련 설명을 입력하세요.", "확인");
                        return;
                    }

                    ExerciseInputs[i].CreatedBy = _loginUserId;
                    ExerciseInputs[i].UpdatedBy = _loginUserId;
                    ExerciseInputs[i].RoutineId = _routineId;
                    request.Add(ExerciseInputs[i]);
                }


                ApiResponse<TrainingModel> deleteResult;
                TrainingModel deleteRequest = new TrainingModel();
                deleteRequest.RoutineId = _routineId;
                deleteResult = await _service.DeleteTraining(deleteRequest);

                if (deleteResult.Success)
                {
                    ApiResponse<TrainingModel> insertResult;

                    insertResult = await _service.SaveTraining(request);
                    if (insertResult.Success)
                    {
                        await App.Current.MainPage.DisplayAlert("성공", "훈련 종목을 저장했습니다.", "확인");
                        await Shell.Current.GoToAsync(nameof(RoutineList));
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("실패", "저장에 실패했습니다.", "확인");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("실패", "삭제에 실패했습니다.", "확인");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SaveTraining Error] {ex.Message}");
                await App.Current.MainPage.DisplayAlert("오류", ex.Message, "확인");
            }

        }

        #endregion


    }
}