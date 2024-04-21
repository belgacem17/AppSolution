using Business.DTO;
using Business.IServices;
using DomainLayer.Utility;
using DomainLayer.UtilityObject;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<UserDTO> Rechercher([FromQuery] UserRecherche userRecherche)
        {
            return _userService.Rechercher(userRecherche);
        }

        [HttpGet("{id}")]
        public UserDTO Modifier(int id)
        {
            return _userService.GetByID(id);
        }

        [HttpPost]
        public UserDTO Ajouter([FromBody] UserDTO userDto)
        {
            return _userService.Ajouter(userDto);
        }

        [HttpPut("{id}")]
        public UserDTO Modifier(int id, [FromBody] UserDTO userDto)
        {
            return _userService.Modifier(id,userDto);
        }

        [HttpDelete]
        public void SupprimerListe([FromBody] List<int> listeASupprimer)
        {
            _userService.SupprimerListe(listeASupprimer);
        }

    }
}
