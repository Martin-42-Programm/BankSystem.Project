namespace BankSystem.Services;

public interface IGenericService<TEntity, TModel>
{
    IQueryable<TModel> GetAll();
    TModel GetById(object id);
    Task<TModel> GetByIdAsync(string id);
    Task<TModel> AddAsync(TModel model);
    Task<TModel> UpdateAsync(TModel model);
    void DeleteAsync(string id);
}