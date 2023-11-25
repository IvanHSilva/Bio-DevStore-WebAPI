using DevAccounts.Domain;
using DevAccounts.Domain.Repositories;
using DevStore.Data.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DevStore.Data.Repositories {
    public class ProductRepository : IProductRepository {

        private readonly AppDataContext _db;

        public ProductRepository() {
            _db = new AppDataContext();
        }

        public List<Product> GetProducts() {
            return _db.Products.ToList();
        }

        public Product GetProduct(int id) {
            return _db.Products.Find(id);
        }

        public void InsertProduct(Product product) {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product) {
            _db.Entry<Product>(product).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void DeleteProduct(int id) {
            _db.Products.Remove(GetProduct(id));
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}
