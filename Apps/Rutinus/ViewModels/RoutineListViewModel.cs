using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Models;
using Rutinus.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    public partial class RoutineListViewModel : ObservableObject
    {
        private readonly RoutineService _service;

        [ObservableProperty]
        private ObservableCollection<RoutineModel> routines = new();

        [ObservableProperty]
        private bool isRefreshing;

        public IAsyncRelayCommand RefreshCommand { get; }

        public RoutineListViewModel()
        {
            _service = new RoutineService();
            RefreshCommand = new AsyncRelayCommand(LoadRoutinesAsync);

            // 페이지 로드시 자동 실행
            _ = LoadRoutinesAsync();
        }

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
    }
}