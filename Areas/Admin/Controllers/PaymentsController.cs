using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicasaProperties.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MicasaProperties.Models;
using Microsoft.EntityFrameworkCore;

namespace MicasaProperties.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PaymentsController : Controller
    {
        private readonly MicasaContext context;

        public PaymentsController(MicasaContext context)
        {
            this.context = context;
        }



        public async Task<IActionResult> Index()
        {
            var payments = await context.Payments.Include(x => x.Tenant).ToListAsync();

            return View(payments);
        }

        public IActionResult Create()
        {

            ViewBag.TenantID = new SelectList(context.Tenants.OrderBy(x => x.TenantID), "TenantID", "Name");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            ViewBag.TenantID = new SelectList(context.Tenants.OrderBy(x => x.TenantID), "TenantID", "Name");

            if (ModelState.IsValid)
            {

                context.Add(payment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(payment);

        }


    }
}
