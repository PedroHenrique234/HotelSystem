using HotelSystem.Models;
using HotelSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Make()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Make(ClientModel client)
        {
            _clientRepository.AddClient(client);
            return RedirectToAction("Index");
        }
    }
}
