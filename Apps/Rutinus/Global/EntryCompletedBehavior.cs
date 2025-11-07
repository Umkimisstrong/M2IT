using System.Windows.Input;

namespace Rutinus.Global
{
    /// <summary>
    /// EntryCompletedBehavior : Entry 컨트롤의 Completed Behavior 커스텀
    /// </summary>
    public class EntryCompletedBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CommandProperty =
                BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EntryCompletedBehavior));

        public ICommand Command 
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        { 
            base.OnAttachedTo(bindable);

            this.BindingContext = bindable.BindingContext;
            bindable.BindingContextChanged += (s, e) =>
            {
                this.BindingContext = bindable.BindingContext;
            };

            bindable.Completed += OnEntryCompleted;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Completed -= OnEntryCompleted;
            bindable.BindingContextChanged -= (s, e) =>
            {
                this.BindingContext = bindable.BindingContext;
            };
        }
        private void OnEntryCompleted(object sender, EventArgs e)
        {
            if (Command?.CanExecute(null) == true)
            { 
                Command.Execute(null);
            }
        }
    }
}
