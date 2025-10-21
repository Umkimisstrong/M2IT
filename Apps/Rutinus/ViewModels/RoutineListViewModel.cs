using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Models;
using Rutinus.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rutinus.ViewModels
{
    /// <summary>
    /// RoutineListViewModel : RoutineList 에서 사용되는 ViewModel
    /// </summary>
    public partial class RoutineListViewModel : ObservableObject
    {
        #region Init
        /* 변수 */
        private RoutineService _service;

        /* 관측속성 */

        [ObservableProperty]
        private ObservableCollection<RoutineModel> routines = new();

        [ObservableProperty]
        private bool isRefreshing;

        /* 커맨드 */
        public IAsyncRelayCommand RefreshCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }


        /* 생성자 */
        public RoutineListViewModel()
        {
            InitVariables();
            InitLoad();

            RefreshCommand = new AsyncRelayCommand(LoadRoutinesAsync);
            EditCommand = new Command<int>(OnEditRoutine);
            DeleteCommand = new Command<int>(DeleteRoutinesAsync);


        }

        /// <summary>
        /// InitVariables : 변수 할당
        /// </summary>
        private void InitVariables()
        {
            _service = new RoutineService();

        }

        /// <summary>
        /// InitLoad : 로드시 실행되는 메소드
        /// </summary>
        private void InitLoad()
        {
            _ = LoadRoutinesAsync();
        }

        #endregion

        #region Command
        /// <summary>
        /// LoadRoutinesAsync : Refresh 커맨드 목록조회
        /// </summary>
        /// <returns></returns>
        private async Task LoadRoutinesAsync()
        {
            try
            {
                IsRefreshing = true;

                var response = await _service.GetRoutineListAsync("KIMSANGKI");
                if (response.Success && response.Data != null)
                {
                    Routines.Clear();

                    foreach (var item in response.Data)
                    {
                        Routines.Add(item);
                    }
                }
                else
                {
                    Debug.WriteLine("루틴 목록을 불러오지 못했습니다.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoadRoutinesAsync Error] {ex.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        /// <summary>
        /// OnEditRoutine : 수정 버튼 클릭 커맨드
        /// </summary>
        /// <param name="routineId">루틴아이디</param>
        private async void OnEditRoutine(int routineId)
        {
            // 네비게이션으로 루틴 수정 페이지로 이동, routineId 전달
            await Shell.Current.GoToAsync($"///RoutineSave?routineId={routineId.ToString()}");
        }
        /// <summary>
        /// DeleteRoutinesAsync : 삭제 버튼 커맨드
        /// </summary>
        /// <param name="routineId">루틴아이디</param>
        private async void DeleteRoutinesAsync(int routineId)
        {
            try
            {

                bool confirmResult = await App.Current.MainPage.DisplayAlert("주의", "루틴이 삭제됩니다.", "확인", "취소");
                if (confirmResult)
                {
                    RoutineModel request = new RoutineModel();
                    request.RoutineId = routineId;
                    var response = await _service.DeleteRoutine(request);
                    if (response.Success)
                    {
                        await App.Current.MainPage.DisplayAlert("성공", "루틴이 삭제되었습니다.", "확인");
                        _ = LoadRoutinesAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DeleteRoutinesAsync Error] {ex.Message}");
            }
            finally
            {

            }
        }
        #endregion

    }
}