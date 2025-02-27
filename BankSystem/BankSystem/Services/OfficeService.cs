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
            return _repository.GetById(Guid.Parse((string)id)).ToModel();
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

    public async Task<OfficeServiceModel> DeleteAsync(string id)
    {
        var card = _repository.GetById(Guid.Parse(id));
        if (card == null)
            throw new KeyNotFoundException();
        var model = await _repository.DeleteAsync(card);
        return model.ToModel();

    }

    private IQueryable<Office> InternalGetAll()
    {
        return _repository.GetAll();
    }
}