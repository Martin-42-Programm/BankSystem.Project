namespace BankSystem.Services;

public interface IGenericService<TEntity, TModel>
{
    IQueryable<TModel> GetAll();
    
    TModel GetByIdAsync(int id);
    TModel AddAsync(TModel model);
    TModel UpdateAsync(TModel model);
    void DeleteAsync(int id);
}