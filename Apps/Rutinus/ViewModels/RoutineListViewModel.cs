using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    public partial class RoutineListViewModel : ObservableObject
    {
        public ObservableCollection<RoutineViewModel> Routines { get; } = new();

        public RoutineListViewModel()
        {
            // 예시 데이터
            Routines.Add(new RoutineViewModel
            {
                RoutineName = "하체 루틴",
                Description = "스쿼트, 레그프레스 중심",
                BodyPart = "하체"
            });

            Routines.Add(new RoutineViewModel
            {
                RoutineName = "가슴 루틴",
                Description = "벤치프레스, 플라이 등",
                BodyPart = "가슴"
            });
        }

        [RelayCommand]
        private void AddRoutine()
        {
            // 루틴 추가 로직
        }

    }
}
