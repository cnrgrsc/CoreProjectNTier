using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        protected IRepository<T> _irp;

        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }

        public virtual string Add(T item)
        {
            if(item.CreatedDate != null)
            {
                _irp.Add(item);
                return "Ekleme basarılı!!";
            }
            return "Ekleme basarısız";
        }

        public List<T> GetAll()
        {
            return _irp.GetAll();
        }
    }
}
