using System;
using System.Collections.Generic;
using System.ServiceModel;
using OnlineStore.Domain.Model;

namespace OnlineStore.ServiceContracts
{
    [ServiceContract(Namespace = "")]
    public interface IProductService
    {
        #region Methods
        // 获得所有商品的契约方法
        [OperationContract]
        IEnumerable<Product> GetProducts();

        // 获得新上市的商品的契约方法
        [OperationContract]
        IEnumerable<Product> GetNewProducts(int count);

        // 获得所有类别的契约方法
        [OperationContract]
        IEnumerable<Category> GetCategories();

        // 根据商品Id来获得商品的契约方法
        [OperationContract]
        Product GetProductById(Guid id);

        #endregion
    }
}
