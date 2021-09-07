using MicasaProperties.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicasaProperties.Models;

namespace MicasaProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BuildingsController : Controller
    {
        //injecting dependecy

        private readonly MicasaContext context;

        public BuildingsController(MicasaContext context)
        {
            this.context = context;
        }

        //Get all buildings
        public async Task<IActionResult> Index()
        {
            var buildings = await context.Buildings.OrderByDescending(b => b.BuildingID).ToListAsync();
            ViewBag.TotalBuildings = await context.Buildings.CountAsync();
            ViewBag.TotalUnits = await context.Buildings.SumAsync(b => b.UnitsAvailable);
            ViewBag.Revenue = await context.Buildings.SumAsync(b => b.ExpectedRevenue);

            return View(buildings);
        }

        public async Task<IActionResult> Details(int Id)
        {
            Building building = await context.Buildings.FirstOrDefaultAsync(x => x.BuildingID == Id);

            if (building == null)
                return NotFound();

            return View(building);
        }

        //returns view no need for async
        public IActionResult Create() => View();

        //post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Building building)
        {
            if (ModelState.IsValid)
            {

                context.Add(building);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(building);

        }

        public async Task<IActionResult> Edit(int Id)
        {
           
                Building building = await context.Buildings.FindAsync(Id);

            if (building == null)
                return NotFound();
           
            return View(building);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Building building)
        {
            if (ModelState.IsValid)
            {

                context.Update(building);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(building);

        }


        public async Task<IActionResult> Delete(int id)
        {
            Building building = await context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }
            else
            {
                context.Buildings.Remove(building);
                await context.SaveChangesAsync();

               
            }

            return RedirectToAction("Index");
        }

    }
}
