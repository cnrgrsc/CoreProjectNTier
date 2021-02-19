using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        public ProductManager(IRepository<Product> prp) : base(prp)
        {

        }

        public override string Add(Product item)
        {
            if (item.ProductName == null || item.ProductName.Trim() == "" || item.CreatedDate == null)
            {
                return "Ekleme basarsıız...Isim hatası veya tarih hatası  var";
            }
            _irp.Add(item);
            return "Ekleme basarılı";
        }
    }
}
