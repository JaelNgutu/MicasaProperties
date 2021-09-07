using MicasaProperties.Data;
using MicasaProperties.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MicasaProperties.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MicasaProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TenantsController : Controller
    {

        private readonly MicasaContext context;

        public TenantsController(MicasaContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tenants = await context.Tenants.Include(x => x.Building).Include(x => x.Payments).ToListAsync();

            return View(tenants);
        }



        public IActionResult Create()
        {

            ViewBag.BuildingId = new SelectList(context.Buildings.OrderBy(x => x.BuildingID), "BuildingID", "BuildingName");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenant tenant)
        {
            ViewBag.BuildingId = new SelectList(context.Buildings.OrderBy(x => x.BuildingID), "BuildingID", "BuildingName");

            if (ModelState.IsValid)
            {

                context.Add(tenant);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(tenant);

        }

        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.BuildingId = new SelectList(context.Buildings.OrderBy(x => x.BuildingID), "BuildingID", "BuildingName");

            Tenant tenant = await context.Tenants.FindAsync(Id);

            if (tenant == null)
                return NotFound();

            return View(tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tenant tenant)
        {
            ViewBag.BuildingId = new SelectList(context.Buildings.OrderBy(x => x.BuildingID), "BuildingID", "BuildingName");

            if (ModelState.IsValid)
            {

                context.Update(tenant);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(tenant);

        }


        public async Task<IActionResult> Details(int Id)
        {
            

            Tenant tenant = await context.Tenants.Include(x => x.Building).Where(x => x.TenantID == Id).FirstOrDefaultAsync();
            var payments = context.Payments.OrderByDescending(x => x.PaymentID)
                                            .Where(x => x.TenantID == tenant.TenantID);

            ViewBag.TenantName = tenant.Name;
            ViewBag.PhoneNumber = tenant.PhoneNumber;
            ViewBag.Email = tenant.Email;
            ViewBag.BuildingName = tenant.Building.BuildingName;

            return View(await payments.ToListAsync());


        }


        public async Task<IActionResult> Delete(int id)
        {
            Tenant tenant = await context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }
            else
            {
                context.Tenants.Remove(tenant);
                await context.SaveChangesAsync();


            }

            return RedirectToAction("Index");
        }



    }
}
