using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HelpDeskWeb.Models;
using HelpDeskWeb.ViewModels;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using HelpDeskWeb.Data;

namespace HelpDeskWeb.Controllers
{
    public class TicketPriorityController : Controller
    {
        AppDbContext _appDbContext;
        public TicketPriorityController(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<TicketPriority> TicketPriorityList = _appDbContext.TicketPriority.ToList();
            return View(TicketPriorityList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.TicketPriority.Add(ticketPriority);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPriority);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketPriority = _appDbContext.TicketPriority.Find(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }
            return View(ticketPriority);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.TicketPriority.Update(ticketPriority);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPriority);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketPriority = _appDbContext.TicketPriority.Find(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }
            _appDbContext.TicketPriority.Remove(ticketPriority);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}