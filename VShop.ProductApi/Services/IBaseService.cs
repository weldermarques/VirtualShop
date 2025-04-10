using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface IBaseService<T>
{
    Task<bool> Add(T value);
    Task<T> Update(T value);
    Task<bool> Delete(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
}
