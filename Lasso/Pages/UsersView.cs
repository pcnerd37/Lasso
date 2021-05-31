using Lasso.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Lasso.Pages
{
    public partial class UsersView
    {
        public List<User> users { get; set; }

        public async Task AddUserAsync()
        {

            User AddedUser = await Http.GetFromJsonAsync<User>("https://localhost:44381/api/Users");
            users.Add(AddedUser);
        }

        private void InitializeUsers()
        {
            var User1 = new User
            {
                Name = "John Doe",
                Id = 123,
                Image = "randomimage.jpg"
            };

            var User2 = new User
            {
                Name = "Jane Doe",
                Id = 124,
                Image = "randomimage.jpg"
            };

            users = new List<User> { User1, User2 };
        }

        protected override async Task<Task> OnInitializedAsync()
        {
            users = new List<User> { };
            //User AddedUser = await Http.GetFromJsonAsync<User>("api/Users");
            return base.OnInitializedAsync();
        }
    }
}
