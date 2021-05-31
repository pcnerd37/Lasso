using LassoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace LassoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<string>> Getusers()
        {
            if (_context.users.Count() == 0)
            {
                _context.users.Add(new User("Bill", 123, "https://cdn.xxl.thumbs.canstockphoto.com/confident-businessman-portrait-of-handsome-young-man-in-blue-shirt-looking-at-camera-and-keeping-stock-image_csp18959962.jpg"));
                _context.users.Add(new User("Tom", 343, "https://i.pinimg.com/236x/51/ed/1e/51ed1e7daebb45af8216720f40ca8597.jpg"));
                _context.users.Add(new User("Stacy", 432, "https://e7.pngegg.com/pngimages/734/739/png-clipart-female-graphy-woman-thinking-woman-microphone-photography-thumbnail.png"));
                _context.users.Add(new User("Susan", 513, "https://w7.pngwing.com/pngs/282/823/png-transparent-juniper-networks-woman-women-hand-people-arm-thumbnail.png"));
                _context.users.Add(new User("Steve", 766, "https://i.pinimg.com/236x/79/23/fa/7923fa58dbae598577f0ff0d819a1701.jpg"));
                _context.users.Add(new User("Jessica", 979, "https://w7.pngwing.com/pngs/31/952/png-transparent-graphy-woman-businessperson-smiling-woman-arm-girl-business-thumbnail.png"));
                _context.users.Add(new User("James", 357, "https://i.pinimg.com/236x/6c/1a/43/6c1a438babf07d052e299495782e70a3.jpg"));
                _context.users.Add(new User("Paul", 235, "https://res.cloudinary.com/demo/image/upload/c_fill,w_100,h_100,g_face,dpr_3.0/smiling_man.jpg"));
                _context.users.Add(new User("Larry", 165, "https://i.pinimg.com/236x/50/d9/1a/50d91a77dbd834942a3e5cc62aaf83c7.jpg"));
                _context.users.Add(new User("George", 278, "https://www.morganstanley.com/pub/content/dam/msdotcom/ideas/themes/personal-journeys/thumbnail-personaljourneys.jpg"));
                _context.users.Add(new User("Jennifer", 345, "https://i.ytimg.com/vi/e46UBSxoPdo/mqdefault.jpg"));
                _context.users.Add(new User("Alan", 987, "https://s3-ap-southeast-2.amazonaws.com/anglican-diocese-of-perth/thumbnails/_392xAUTO_crop_center-center_none/St-Barts-Athol-man-thumbnail.jpg"));

            }
            await _context.SaveChangesAsync();




            int count = _context.users.Count();


            User[] users = new User[count];

            int arrCount = 0;

            foreach (User u in _context.users)
            {
                users[arrCount] = u;
                arrCount++;
            }

            Random rand = new Random();
            int randomNumber = rand.Next(count);
            //User[] userList = new User[count];

            //User user = await _context.users.FindAsync(randomNumber);
            string jsonString = JsonSerializer.Serialize(users[randomNumber]);
            return JsonSerializer.Serialize(users[randomNumber]);
            //return await _context.users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
