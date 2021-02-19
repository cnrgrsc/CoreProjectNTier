using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IManager<T> where T:BaseEntity
    {
        string Add(T item);

        List<T> GetAll();
    }
}
