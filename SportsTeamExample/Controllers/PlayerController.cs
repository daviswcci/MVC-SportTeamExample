using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsTeamExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Controllers
{
    public class PlayerController : Controller
    {
        public SportsTeamContext db;

        public PlayerController(SportsTeamContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Players.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Players.ToList().Where(p => p.Id == id).FirstOrDefault());
        }
        public IActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams.ToList(), "Id", "Name");
            return View(new Player());
        }

        [HttpPost]
        public IActionResult Create(Player model)
        {
            bool isDuplicate = false;
            List<Player> players = db.Players.ToList();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name == model.Name)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                db.Players.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Warning = "That player already exists!";
                ViewBag.TeamId = new SelectList(db.Teams.ToList(), "Id", "Name");
                return View(new Player());
            }
        }

        public IActionResult Delete(int id)
        {
            Player player = db.Players.ToList().Where(p => p.Id == id).FirstOrDefault();
            return View(player);
        }

        [HttpPost]
        public IActionResult Delete(Player model)
        {
            IEnumerable<PlayerPosition> entries = db.PlayerPositions.ToList().Where(p => p.PlayerId == model.Id);
            foreach(PlayerPosition entry in entries)
            {
                db.PlayerPositions.Remove(entry);
            }
            db.Players.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.TeamId = new SelectList(db.Teams.ToList(), "Id", "Name");
            Player player = db.Players.ToList().Where(p => p.Id == id).FirstOrDefault();
            return View(player);
        }

        [HttpPost]
        public IActionResult Update(Player model)
        {
            db.Players.Update(model);
            db.SaveChanges();
            ViewBag.TeamId = new SelectList(db.Teams.ToList(), "Id", "Name");
            ViewBag.ResultMessage = model.Name + "was successfully updated.";
            return View(model);
        }
    }
}
