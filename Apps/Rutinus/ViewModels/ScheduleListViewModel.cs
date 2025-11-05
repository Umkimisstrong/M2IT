using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

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

        public string MonthText => CurrentMonth.ToString("yyyy년 M월");

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
    public class CalendarDate
    {
        public DateTime Date { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
