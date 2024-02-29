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
            List<ClientModel> client = _clientRepository.FindAll();
            return View(client);
        }
        public IActionResult Make()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ClientModel client = _clientRepository.FindById(id);
            return View(client);
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
        [HttpPost]
        public IActionResult Update(ClientModel client)
        {
            _clientRepository.UpdateClient(client);
            return RedirectToAction("Index");
        }
    }
}
