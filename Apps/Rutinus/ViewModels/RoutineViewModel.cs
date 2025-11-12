using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Models;
using Rutinus.Services;
using System.Diagnostics;


namespace Rutinus.ViewModels
{
    /// <summary>
    /// RoutineViewModel : RoutineSave 에서 사용되는 ViewModel
    /// </summary>
    public partial class RoutineViewModel : ObservableObject
    {

        #region Init
        private RoutineService _service;
        private CodeService _codeService;

        private int? _routineId; // 내부에서 사용할 ID 저장 (null이면 새로 만들기)
        private string _loginUserId;
        [ObservableProperty]
        private string routineName = string.Empty;
        [ObservableProperty]
        private string routineDescription = string.Empty;
        [ObservableProperty]
        private string routinePart = string.Empty;
        [ObservableProperty]
        private bool alertEnabled;
        [ObservableProperty]
        private List<CodeValueModel> bodyParts = new List<CodeValueModel>();   // Picker에 바인딩할 목록
        [ObservableProperty]
        private CodeValueModel? selectedBodyPart;         // Picker에서 선택된 항목

        public IAsyncRelayCommand SaveCommand { get; }

        /// <summary>
        /// RoutineViewModel : 생성자
        /// </summary>
        public RoutineViewModel()
        {
            InitVariables();
            InitLoad();
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        private void InitVariables()
        {
            _service = new RoutineService();
            _codeService = new CodeService();
            _loginUserId = ((App)Application.Current).CurrentUser != null ? ((App)Application.Current).CurrentUser.LoginUserId : "KIMSANGKI";
        }

        private void InitLoad()
        {
            _ = LoadBodyPartsAsync(); // 페이지 진입 시 호출
        }

        #endregion

        #region Command
        /// <summary>
        /// LoadRoutineAsync : 루틴 1개 로드 커맨드
        /// </summary>
        /// <param name="routineId">루틴아이디</param>
        /// <returns></returns>
        public async Task LoadRoutineAsync(int routineId)
        {
            try
            {
                var routine = await _service.GetRoutineAsync(routineId);
                if (routine != null)
                {
                    RoutineName = routine.Data.RoutineName;
                    RoutineDescription = routine.Data.RoutineDescription;
                    RoutinePart = routine.Data.RoutinePart;
                    AlertEnabled = routine.Data.AlertYn == "Y";

                    // BodyParts 로딩이 끝나기 전이면 대기
                    if (!BodyParts.Any())
                        await LoadBodyPartsAsync();
                    else
                        SelectedBodyPart = BodyParts.FirstOrDefault(x => x.Code == RoutinePart);

                    // 수정 모드 플래그 관리도 가능
                    _routineId = routineId;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoadRoutine Error] {ex.Message}");
                await App.Current.MainPage.DisplayAlert("오류", "루틴을 불러오지 못했습니다.", "확인");
            }
        }

        /// <summary>
        /// LoadBodyPartsAsync : 루틴 부위 콤보조회  커맨드
        /// </summary>
        /// <returns></returns>
        private async Task LoadBodyPartsAsync()
        {
            // 예시: BodyPart 코드 리스트 가져오기
            var codes = await _codeService.GetCodeValueItemAsync("CMM", "BODY_PART");
            var bodyParts = new List<CodeValueModel>();
            if (codes != null && codes.Data != null && codes.Data.Count > 0)
            {
                foreach (var code in codes.Data)
                {
                    CodeValueModel model = new CodeValueModel();
                    model.Code = code.Cd;
                    model.Name = code.CdNm;

                    bodyParts.Add(model);
                }
            }
            BodyParts = bodyParts; // 바인딩

            // 기본 선택: 수정 모드가 아니면 첫 번째 선택
            if (string.IsNullOrEmpty(RoutinePart) && BodyParts.Any())
            {
                SelectedBodyPart = BodyParts.First();
            }
            // 수정 모드일 경우: RoutinePart 값을 이용해 선택된 항목 설정
            else if (!string.IsNullOrEmpty(RoutinePart))
            {
                SelectedBodyPart = BodyParts.FirstOrDefault(x => x.Code == RoutinePart);
            }
        }


        /// <summary>
        /// OnSaveAsync : 저장 버튼 커맨드(입력 / 수정
        /// </summary>
        /// <returns></returns>
        private async Task OnSaveAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(routineName))
                {
                    await App.Current.MainPage.DisplayAlert("오류", "루틴 이름을 입력하세요.", "확인");
                    return;
                }

                var routine = new RoutineModel
                {
                    RoutineId = (int)(_routineId != null ? _routineId : 0),
                    RoutineName = routineName,
                    RoutinePart = SelectedBodyPart.Code,
                    RoutineDescription = RoutineDescription,
                    AlertYn = AlertEnabled ? "Y" : "N",
                    CreatedBy = _loginUserId,
                    UpdatedBy = _loginUserId

                };


                ApiResponse<RoutineModel> result;
                if (_routineId != null)
                {
                    result = await _service.UpdateRoutine(routine);
                }
                else
                {
                    result = await _service.SaveRoutine(routine);
                }

                if (result.Success)
                {
                    await App.Current.MainPage.DisplayAlert("성공", "루틴이 저장되었습니다.", "확인");
                    await Shell.Current.GoToAsync(nameof(RoutineList));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("실패", "저장에 실패했습니다.", "확인");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SaveRoutine Error] {ex.Message}");
                await App.Current.MainPage.DisplayAlert("오류", ex.Message, "확인");
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// ResetFields : 필드 비우기(외부에서 실행)
        /// </summary>
        public void ResetFields()
        {
            RoutineName = string.Empty;
            RoutineDescription = string.Empty;
            AlertEnabled = false;
            RoutinePart = string.Empty;
            SelectedBodyPart = BodyParts.FirstOrDefault(); // 또는 null

            _routineId = null; // 내부 ID도 리셋
        }
        #endregion


    }
}