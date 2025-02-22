using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankSystem.Services;

public class CardService : ICardService
{
    private readonly CardRepository _cardRepository;

    public CardService(CardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    public IQueryable<CardServiceModel> GetAll()
    {
        return this.InternalGetAll().Select(c => c.ToModel());
    }

    public CardServiceModel GetById(object id)
    {
        return _cardRepository.GetById(id).ToModel();
    }

    public Task<CardServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<CardServiceModel> AddAsync(CardServiceModel model)
    {
        if (model == null)
            return new CardServiceModel();
        await _cardRepository.CreateAsync(model.ToEntity());
        return model;
    }

    public async Task<CardServiceModel> UpdateAsync(CardServiceModel model)
    {
        //return await InternalUpdateAsync(model).Select(entity => entity.ToModel);
        throw new NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    private IQueryable<Card> InternalGetAll()
    {
        return _cardRepository.GetAll();
    }

    private IQueryable<Card> InternalUpdateAsync(CardServiceModel model)
    {
        //return _cardRepository.EditAsync(model.ToEntity());
        throw new NotImplementedException();
    }
}