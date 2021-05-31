namespace Lasso.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }

        public User()
        {

        }

        public User(string name, int id, string link)
        {
            Name = name;
            Id = id;
            Image = link;
        }
    }
}