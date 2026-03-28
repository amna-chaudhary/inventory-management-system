using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCPro.Models;
using System.Data.Entity;

namespace MVCPro.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly MVCProEntities db = new MVCProEntities();

        // GET: SalesOrder
        public ActionResult Index()
        {
            var orders = db.SalesOrders.Include("CustomerTable").ToList();
            return View(orders);
        }

        // GET: SalesOrder/Create
        public ActionResult Create()
        {
            var viewModel = new SalesOrderViewModel
            {
                ProductIds = new List<int>(),
                Quantities = new List<int>()
            };

            ViewBag.Products = db.Products.ToList();
            ViewBag.Customers = new SelectList(db.CustomerTable.ToList(), "Id", "DisplayName");

            return View(viewModel);
        }

        // POST: SalesOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new SalesOrder
                {
                    CustomerName = viewModel.CustomerName,
                    SalesOrderNumber = viewModel.SalesOrderNumber,
                    OrderDate = DateTime.Now,
                    ExpectedShipmentDate = viewModel.ExpectedShipmentDate,
                    PaymentTerms = viewModel.PaymentTerms,
                    CustomerTable_Id = viewModel.CustomerId
                };

                db.SalesOrders.Add(order);
                db.SaveChanges();

                decimal totalAmount = 0;

                for (int i = 0; i < viewModel.ProductIds.Count; i++)
                {
                    var product = db.Products.Find(viewModel.ProductIds[i]);
                    if (product != null && product.Quantity >= viewModel.Quantities[i])
                    {
                        var item = new SalesOrderItem
                        {
                            SalesOrderId = order.Id,
                            ProductId = product.Id,
                            Quantity = viewModel.Quantities[i],
                            Price = product.SellingPrice  // Use SellingPrice for product price
                        };

                        product.Quantity -= viewModel.Quantities[i];
                        totalAmount += item.Price * item.Quantity;

                        db.SalesOrderItems.Add(item);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Stock not available for: " + product?.ItemName);
                    }
                }

                order.TotalAmount = totalAmount;
                db.SaveChanges();

                TempData["Success"] = "Sales Order Created Successfully.";
                return RedirectToAction("Index");
            }

            // Reload dropdowns if validation fails
            ViewBag.Products = db.Products.ToList();
            ViewBag.Customers = new SelectList(db.CustomerTable.ToList(), "Id", "DisplayName");
            TempData["Error"] = "Please correct the form.";
            return View(viewModel);
        }

        // GET: SalesOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var order = db.SalesOrders
                .Include(o => o.CustomerTable)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return HttpNotFound();

            return View(order);
        }

        // GET: SalesOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Find the SalesOrder in the database
            var salesOrder = db.SalesOrders.Include(s => s.CustomerTable)
                                           .Include(s => s.SalesOrderItems) // Include SalesOrderItems here
                                           .FirstOrDefault(s => s.Id == id);

            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            // Create a view model to bind data to the view
            var viewModel = new SalesOrderViewModel
            {
                Id = salesOrder.Id,
                SalesOrderNumber = salesOrder.SalesOrderNumber,
                CustomerName = salesOrder.CustomerName,
                ExpectedShipmentDate = salesOrder.ExpectedShipmentDate,
                PaymentTerms = salesOrder.PaymentTerms,
                TotalAmount = salesOrder.TotalAmount,
                CustomerId = salesOrder.CustomerTable_Id ?? 0, // Handle nullable CustomerTable_Id

                // Populate the list of product IDs and quantities from SalesOrderItems
                ProductIds = salesOrder.SalesOrderItems.Select(i => i.ProductId).ToList(),
                Quantities = salesOrder.SalesOrderItems.Select(i => i.Quantity).ToList()
            };

            // Populate the dropdown for customers and products
            ViewBag.Products = db.Products.ToList();
            ViewBag.Customers = new SelectList(db.CustomerTable, "Id", "DisplayName");

            return View(viewModel);
        }

        // POST: SalesOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var salesOrder = db.SalesOrders.Find(model.Id);
                if (salesOrder == null)
                {
                    return HttpNotFound();
                }

                // Update SalesOrder properties
                salesOrder.SalesOrderNumber = model.SalesOrderNumber;
                salesOrder.CustomerName = model.CustomerName;
                salesOrder.ExpectedShipmentDate = model.ExpectedShipmentDate;
                salesOrder.PaymentTerms = model.PaymentTerms;
                salesOrder.TotalAmount = model.TotalAmount;
                salesOrder.CustomerTable_Id = model.CustomerId;

                // Handle the SalesOrderItems (Products and Quantities)
                // First, remove existing items
                db.SalesOrderItems.RemoveRange(salesOrder.SalesOrderItems);

                // Add new items based on the form input
                for (int i = 0; i < model.ProductIds.Count; i++)
                {
                    var item = new SalesOrderItem
                    {
                        SalesOrderId = salesOrder.Id,
                        ProductId = model.ProductIds[i],
                        Quantity = model.Quantities[i],
                        Price = db.Products.Find(model.ProductIds[i]).SellingPrice  // Use SellingPrice instead of Price
                    };
                    db.SalesOrderItems.Add(item);
                }

                // Save changes
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Repopulate the dropdowns if the model is invalid
            ViewBag.Products = db.Products.ToList();
            ViewBag.Customers = new SelectList(db.CustomerTable, "Id", "DisplayName");

            return View(model);
        }

        // GET: SalesOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var order = db.SalesOrders
                .Include(o => o.CustomerTable)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return HttpNotFound();

            return View(order);
        }

        // POST: SalesOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
