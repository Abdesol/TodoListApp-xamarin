using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TodoListApp
{
    partial class TodoListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public TodoListViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();
            TodoItems.Add(new TodoItem("Opening TodoList app", false));
        }

        public ICommand AddTodoCommand => new Command(AddTodoItem);

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _newTodoInputValue;
        public string NewTodoInputValue
        {
            get
            {
                return _newTodoInputValue;
            }
            set
            {
                if (value != this._newTodoInputValue)
                {
                    _newTodoInputValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        void AddTodoItem()
        {
            TodoItems.Add(new TodoItem(NewTodoInputValue, false));
            NewTodoInputValue = String.Empty;
        }

        public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);

        void RemoveTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            TodoItems.Remove(todoItemBeingRemoved);
        }
    }
}
