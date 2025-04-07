namespace VShop.ProductApi.Repositories
{
    public interface IBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<bool> Add(T value);
        Task<T> Update(T value);
        Task<bool> Delete(int id);
    }
}
