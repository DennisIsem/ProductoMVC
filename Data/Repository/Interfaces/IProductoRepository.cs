using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioMVC.Models;

namespace EjercicioMVC.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();

        //GetByID
        Task<Producto> GetById(int Id);

        //Create
        Task<int> Create(Producto producto);

        //Update
        Task<int> Update(Producto producto);

        //Delete
        Task<bool> DeleteById(int Id);
    }
}