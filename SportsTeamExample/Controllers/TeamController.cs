using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsTeamExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Controllers
{
    public class TeamController : Controller
    {
        public SportsTeamContext db;

        public TeamController(SportsTeamContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Teams.ToList().Where(p => p.Id == id).FirstOrDefault());
        }

        public IActionResult Create()
        {
            return View(new Team());
        }

        [HttpPost]
        public IActionResult Create(Team model)
        {
            bool isDuplicate = false;
            List<Team> teams = db.Teams.ToList();
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == model.Name)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                db.Teams.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Player");
            }
            else
            {
                ViewBag.Warning = "That team already exists!";
                return View(new Team());
            }
        }
    }
}
