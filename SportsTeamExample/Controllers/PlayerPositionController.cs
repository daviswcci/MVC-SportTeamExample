using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsTeamExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Controllers
{
    public class PlayerPositionController : Controller
    {
        public SportsTeamContext db;

        public PlayerPositionController(SportsTeamContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players.ToList(), "Id", "Name");
            ViewBag.PositionId = new SelectList(db.Positions.ToList(), "Id", "Name");

            return View(new PlayerPosition());
        }

        [HttpPost]
        public IActionResult Create(PlayerPosition playerPosition)
        {
            bool isDuplicate = false;
            List<PlayerPosition> entries = db.PlayerPositions.ToList();
            for(int i = 0; i < entries.Count; i++)
            {
                if(entries[i].PlayerId == playerPosition.PlayerId && entries[i].PositionId == playerPosition.PositionId)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                db.PlayerPositions.Add(playerPosition);
                db.SaveChanges();
                return RedirectToAction("Index", "Player");
            }
            else
            {
                ViewBag.Warning = "That player already plays that position!";
                ViewBag.PlayerId = new SelectList(db.Players.ToList(), "Id", "Name");
                ViewBag.PositionId = new SelectList(db.Positions.ToList(), "Id", "Name");
                return View(new PlayerPosition());
            }

        }
    }
}
