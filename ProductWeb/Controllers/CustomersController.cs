using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductWeb.Data;
using ProductWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductWeb.Controllers
{
    public class CustomersController : Controller
    {
        IRepository<CustomerDto> repository;
        public CustomersController(IConfiguration configuration)
        {
            repository = new CustomerRepository(configuration);
        }
        public async Task<IActionResult> Index()
        {
            var customers = await repository.GetAllAsync();
            return View(customers);
        }

        public IActionResult Create()
        {
            var customer = new CustomerDto
            {
                CustomerId = 0,
                ProductId = 12,
                EmployerId = "0116474008",
                Name = "Cliente name",
                RFC = "JAVA781105M35",
                Email = "angel_java@hotmail.com"
            };
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.CreateAsync(customer);
                if (result.ProductId > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await repository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await repository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.UpdateAsync(customer);
                if (result.ProductId > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await repository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            CustomerDto customer = null;
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               
                var result = await repository.DeleteAsync(id.Value);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                customer = await repository.GetByIdAsync(id.Value);
            }
            return View(customer);
        }

    }
}
