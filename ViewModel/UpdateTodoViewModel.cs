using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.ViewModel
{
    public class UpdateTodoViewModel : Notifiable<Notification>
    {
        public bool Done { get; set; }

        public bool MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNull(Done, "É necessário infornar um estado"));

            return Done;
        }
    }
}