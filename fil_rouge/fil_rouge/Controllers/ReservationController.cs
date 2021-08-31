using fil_rouge.Data;
using fil_rouge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fil_rouge.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ReservationController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var client = await _userManager.GetUserAsync(HttpContext.User);
                var list = _context.reservation_Hotels.Include(c => c.client).Include(h=>h.hotel).Where(c => c.IdClient == client.Id).ToList();
                return View("Index", list);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            var list = _context.hotels;
            ViewBag.hotels = list.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation_Hotel reservation)
        {

            if (ModelState.IsValid)
            {
                var hotel = _context.hotels.Where(r => r.Id == reservation.Idhotel).FirstOrDefault();
                var client = await _userManager.GetUserAsync(HttpContext.User);

                var reser = new Reservation_Hotel();
                reser.Datedebut = reservation.Datedebut;
                reser.Datefin = reservation.Datefin;
                reser.IsValid = reservation.IsValid;
                reser.IdClient = client.Id;
                reser.Idhotel = hotel.Id;


                _context.Add(reser);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(reservation);
        }


        public ActionResult Edit(int? id)
        {
            var getid = _context.reservation_Hotels.Find(id);
            ViewBag.getHotel = _context.hotels.ToList();
            return View(getid);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Reservation_Hotel reservation)
        {

            if (ModelState.IsValid)
            {
                var Hotel = _context.hotels.Where(r => r.Id == reservation.Idhotel).FirstOrDefault();
                //reservation.ReservationType.Id = type.ToString();
                var client = await _userManager.GetUserAsync(HttpContext.User);
                //var studentId = student.Id;


                reservation.IdClient = client.Id;
                reservation.Idhotel = Hotel.Id;

                _context.Update(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(reservation);
        }


        public IActionResult Delete(int? id)
        {
            var list = _context.reservation_Hotels.Include(s => s.client).Include(rt => rt.hotel);
            ViewBag.data = list.AsEnumerable();
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var del = _context.reservation_Hotels.Find(id);
            return View(del);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var del = _context.reservation_Hotels.Find(id);
            _context.reservation_Hotels.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
