using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.SD;
using WangYc.Models.SD;
using WangYc.Services.Interfaces.SD;
using WangYc.Services.ViewModels.SD;
using WangYc.Services.Mapping.SD;
using WangYc.Services.Messaging;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Services.Implementations.SD {
    public class ProductService : IProductService {

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork uow
        ) {

            this._productRepository = productRepository;
            this._uow = uow;
        }

        #region 查找


        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProduct(Query request) {

            IEnumerable<Product> model = _productRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取产品视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductView> GetProductView(Query request) {

            IEnumerable<Product> model = _productRepository.FindBy(request);
            return model.ConvertToProductView();
        }
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductView> GetProductViewByAll() {

            return this._productRepository.FindAll().ConvertToProductView();
           
        }

        /// <summary>
        /// 根据名称获取产品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductView> GetProductViewByName(string name) {
            
            Query query = new Query();
            query.Add(Criterion.Create<Product>(c => c.EnglishName, name+"%", CriteriaOperator.Like));
            query.Add(Criterion.Create<Product>(c => c.ChineseName, name + "%", CriteriaOperator.Like));
            query.QueryOperator = QueryOperator.Or;
            return this._productRepository.FindAll().ConvertToProductView();

        }
        #endregion

        #region 添加

        public void AddProduct(AddProductRequest request) {

            Product model = new Product(request.ChineseName, request.EnglishName, request.Price, request.Currency, request.Note, request.ProductTypeId);
            this._productRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProduct(AddProductRequest request) {

            Product model = this._productRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.ChineseName = request.ChineseName;
            model.EnglishName = request.EnglishName;
            model.Price = request.Price;
            model.Currency = request.Currency;
            model.ProductTypeId = request.ProductTypeId;
            model.Note = request.Note;

            this._productRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProduct(int id) {

            Product model = this._productRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._productRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion



    }
}
