using Microsoft.AspNetCore.Mvc;
using Repository_pattern.Models;
using Repository_pattern.Repository;

namespace Repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Diarycontroller : Controller
    {
        private readonly Irepo<Diary> _userRepository;
        public Diarycontroller(Irepo<Diary> userRepository) { _userRepository = userRepository; }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllRecords();
            return users != null ? Ok(users) : NoContent();
        }

        [HttpGet]
        [Route("[Action]/{userId}")]
        public IActionResult GetUserById(long userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user != null ? Ok(user) : NoContent();
        }




        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateUser(Diary user)
        {
            bool isCreated = await _userRepository.Insertrecords(user);
            return Ok(isCreated ? "User Created Sucessfully." : "User Creation Failed.");
        }

        [HttpDelete]
        [Route("[Action]/{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            var user = _userRepository.GetUserById(userId);
            bool isDeleted = await _userRepository.DeleteRecords(user);
            return Ok(isDeleted ? "User Deleted Sucessfully." : "User Deletion Failed.");
        }

    }
}
