using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T:BaseEntity
    {


        List<T> GetAll();

        void Add(T item);



    }
}
