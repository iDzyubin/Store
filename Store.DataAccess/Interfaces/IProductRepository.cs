using Store.DataAccess.DataModels;

namespace Store.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с товарами.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
    }
}