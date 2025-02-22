namespace BankSystem.Services;

public class OfficeService : IOfficeService
{
    private readonly OfficeRepository _repository;

    public OfficeService(OfficeRepository officeRepository)
    {
        this._repository = officeRepository;
    }
    public IQueryable<OfficeServiceModel> GetAll()
    {
        return this.InternalGetAll().Select(c => c.ToModel());
    }

    public OfficeServiceModel GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<OfficeServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<OfficeServiceModel> AddAsync(OfficeServiceModel model)
    {
        if (model == null)
            return new OfficeServiceModel();
        await _repository.CreateAsync(model.ToEntity());
        return model;
    }

    public Task<OfficeServiceModel> UpdateAsync(OfficeServiceModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    private IQueryable<Office> InternalGetAll()
    {
        return _repository.GetAll();
    }
}