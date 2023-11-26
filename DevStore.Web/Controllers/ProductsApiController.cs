using DevAccounts.Domain;
using DevAccounts.Domain.Repositories;
using DevStore.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace DevStore.Web.Controllers {
    public class ProductsApiController : ApiController {

        private readonly IProductRepository _repository;

        public ProductsApiController() {
            _repository = new ProductRepository();
        }

        public List<Product> GetProducts() {
            return _repository.GetProducts();
        }

        protected override void Dispose(bool disposing) {
            _repository.Dispose();
        }
    }
}