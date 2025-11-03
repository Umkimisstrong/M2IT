using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Rutinus.ViewModels
{
    public partial class ScheduleListViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime currentMonth = DateTime.Today;

        [ObservableProperty]
        private ObservableCollection<DateTime> dates = new();

        public string MonthText => CurrentMonth.ToString("yyyy년 M월");

        public ScheduleListViewModel()
        {
            GenerateCalendar();
        }

        [RelayCommand]
        private void PreviousMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
            GenerateCalendar();
            OnPropertyChanged(nameof(MonthText));
        }

        [RelayCommand]
        private void NextMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
            GenerateCalendar();
            OnPropertyChanged(nameof(MonthText));
        }

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
                if (dayNum <= 0) // 이전 달
                    Dates.Add(new DateTime(prevMonth.Year, prevMonth.Month, daysInPrevMonth + dayNum));
                else if (dayNum > daysInMonth) // 다음 달
                    Dates.Add(new DateTime(CurrentMonth.AddMonths(1).Year, CurrentMonth.AddMonths(1).Month, dayNum - daysInMonth));
                else // 이번 달
                    Dates.Add(new DateTime(CurrentMonth.Year, CurrentMonth.Month, dayNum));
            }
        }
    }

    public class DateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date && parameter is DateTime currentMonth)
            {
                if (date.Month != currentMonth.Month) return Colors.Gray;   // 이전/다음 달
                if (date.Date == DateTime.Today) return Colors.White;      // 오늘 강조
                return Colors.Black;                                       // 이번 달
            }
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class DateBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date.Date == DateTime.Today)
                    return Colors.Blue; // 오늘 강조
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
