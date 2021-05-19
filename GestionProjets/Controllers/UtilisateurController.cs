using GestionProjets.Data;
using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UtilisateurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUtilisateurRepository utilisateurRepository)
        {
            _context = context;
            _userManager = userManager;
            _utilisateurRepository = utilisateurRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//RequestContext.Principal.Identity.GetUserId();


           Utilisateur utilisateur=  _utilisateurRepository.GetUtilisateurByID(userId);

            return new OkObjectResult(utilisateur);
        }

        [Authorize(Roles = "Admin")]
        [Route("/getallusers")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var utilisateurs = _utilisateurRepository.GetUtilisateurs();
            return new OkObjectResult(utilisateurs);


        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllRoles")]

        public Dictionary<string, string> GetAllRoles()
        {

            var roles = _context.Roles.ToDictionary(x => x.Id, x => x.Name);

            return roles;

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/AddRole")]

        public async Task<IActionResult> AddRole(Role role)
        {

            var user = await _userManager.FindByIdAsync(role.UserId);

            await _userManager.AddToRoleAsync(user, role.Nom);

            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/RemoveRole")]

       
        public async Task<IActionResult> RemoveRole(Role role)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(role.UserId);

            await _userManager.RemoveFromRoleAsync(user, role.Nom);
            return new OkResult();

        }
    }
}
