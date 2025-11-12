using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Rutinus.ViewModels
{
    /// <summary>
    /// ScheduleListViewModel : ScheduleList 에서 사용되는 ViewModel 
    /// </summary>
    public partial class ScheduleListViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime currentMonth = DateTime.Today;

        [ObservableProperty]
        private ObservableCollection<CalendarDate> dates = new();

        [ObservableProperty]
        private CalendarDate selectedDate;

        public string MonthText => CurrentMonth.ToString("yyyy년 M월");

        /// <summary>
        /// ScheduleListViewModel : 생성자
        /// </summary>

        public ScheduleListViewModel()
        {
            GenerateCalendar();
        }

        /// <summary>
        /// PreviousMonth : 이전 달 클릭
        /// </summary>
        [RelayCommand]
        private void PreviousMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
            GenerateCalendar();
            OnPropertyChanged(nameof(MonthText));
        }

        /// <summary>
        /// NextMonth : 다음 달 클릭
        /// </summary>
        [RelayCommand]
        private void NextMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
            GenerateCalendar();
            OnPropertyChanged(nameof(MonthText));
        }

        /// <summary>
        /// CreateSchedule : 일정 생성 클릭
        /// </summary>
        [RelayCommand]
        private async void CreateSchedule()
        {
            if (SelectedDate == null)
            {
                await App.Current.MainPage.DisplayAlert("오류", "날짜를 선택해주세요", "확인");
            }

        }

        /// <summary>
        /// OnSelectedDateChanged : 선택 시 색상을 바꾼다.
        /// </summary>
        /// <param name="value"></param>
        partial void OnSelectedDateChanged(CalendarDate value)
        {
            if (value == null)
                return;

            foreach (var date in Dates)
            {
                if (date.BackgroundColor == Colors.Green)
                    date.BackgroundColor = date.Date == DateTime.Today ? Colors.Blue : Colors.Transparent;
            }

            value.BackgroundColor = Color.FromArgb("#0baf4d");
        }
        /// <summary>
        /// GenerateCalendar : 달력 그리기
        /// </summary>
        public void GenerateCalendar()
        {
            Dates.Clear();

            var firstDay = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);
            int startOffset = (int)firstDay.DayOfWeek;

            var prevMonth = CurrentMonth.AddMonths(-1);
            int daysInPrevMonth = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);

            for (int i = 0; i < 42; i++)
            {
                int dayNum = i - startOffset + 1;
                DateTime date;

                if (dayNum <= 0) // 이전 달
                    date = new DateTime(prevMonth.Year, prevMonth.Month, daysInPrevMonth + dayNum);
                else if (dayNum > daysInMonth) // 다음 달
                    date = new DateTime(CurrentMonth.AddMonths(1).Year, CurrentMonth.AddMonths(1).Month, dayNum - daysInMonth);
                else // 이번 달
                    date = new DateTime(CurrentMonth.Year, CurrentMonth.Month, dayNum);

                // 색상 계산
                Color textColor;
                Color backgroundColor = Colors.Transparent;

                if (date.Month != CurrentMonth.Month)
                    textColor = Colors.LightGray; // 이번 달이 아닌 날짜
                else if (date.Date == DateTime.Today)
                {
                    textColor = Colors.White;
                    backgroundColor = Colors.Blue; // 오늘
                }
                else
                    textColor = Colors.Black;

                Dates.Add(new CalendarDate
                {
                    Date = date,
                    TextColor = textColor,
                    BackgroundColor = backgroundColor
                });
            }
        }
    }

    /// <summary>
    /// CalendarDate : 바인딩 되는 달력 속성
    /// </summary>
    public partial class CalendarDate : ObservableObject
    {
        public DateTime Date { get; set; }
        [ObservableProperty]
        private Color textColor;

        [ObservableProperty]
        private Color backgroundColor;
    }
}
