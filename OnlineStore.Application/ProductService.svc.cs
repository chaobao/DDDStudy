using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using OnlineStore.Domain;
using OnlineStore.Domain.Model;
using OnlineStore.Infrastructure;
using OnlineStore.ServiceContracts;

namespace OnlineStore.Application
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ProductService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ProductService.svc 或 ProductService.svc.cs，然后开始调试。
    public class ProductService : IProductService
    {
        // 引用商品服务接口
        private readonly IProductService _productService;

        public ProductService()
        {
            _productService = ServiceLocator.Instance.GetService<IProductService>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        public IEnumerable<Product> GetNewProducts(int count)
        {
            return _productService.GetNewProducts(count);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _productService.GetCategories();
        }

        public Product GetProductById(Guid id)
        {
            return _productService.GetProductById(id);
        }
    }
}
