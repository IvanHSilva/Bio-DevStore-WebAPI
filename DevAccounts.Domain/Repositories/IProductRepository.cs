using System;
using System.Collections.Generic;

namespace DevAccounts.Domain.Repositories {
    public interface IProductRepository : IDisposable {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
    }
}
