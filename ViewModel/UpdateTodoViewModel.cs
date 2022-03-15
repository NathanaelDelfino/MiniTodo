using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.ViewModel
{
    public class UpdateTodoViewModel : Notifiable<Notification>
    {
        public bool Done { get; set; }
        public string Title { get; set; }

        public bool MapToDone()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNull(Done, "É necessário infornar um estado"));
            Console.WriteLine("Validou");
            return Done;
        }

        public string MapToTitle()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Title, "Informe o título da tarefa")
                .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres"));

            return Title;
        }
    }
}