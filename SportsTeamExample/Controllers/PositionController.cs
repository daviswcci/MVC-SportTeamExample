using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Controllers
{
    public class PositionController : Controller
    {
        public SportsTeamContext db;

        public PositionController(SportsTeamContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Positions.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Positions.ToList().Where(p => p.Id == id).FirstOrDefault());
        }
    }
}
