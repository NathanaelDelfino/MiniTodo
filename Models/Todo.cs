namespace MiniTodo.Models
{
    public class Todo
    {
        public Todo(string title) => Title = title;

        public Todo(int id, bool done)
        {
            Id = id;
            done = done;
        }

        public Todo(int id, string title, bool done)
        {
            this.Id = id;
            this.Title = title;
            this.Done = done;

        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool Done { get; private set; } = false;

        public void AsFinished(bool done) => Done = done;
    }
}