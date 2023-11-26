using DevAccounts.Domain;
using DevAccounts.Domain.Repositories;
using DevStore.Data.Contexts;
using DevStore.Data.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DevStore.Web.Controllers {
    public class ProductsController : Controller {
        
        private IProductRepository _repository = new ProductRepository();

        // GET: Products
        public ActionResult Index() {
            return View(_repository.GetProducts().ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetProduct(id.Value);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Product product) {
            if (ModelState.IsValid) {
                _repository.InsertProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetProduct(id.Value);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Product product) {
            if (ModelState.IsValid) {
                _repository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetProduct(id.Value);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Product product = _repository.GetProduct(id);
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
