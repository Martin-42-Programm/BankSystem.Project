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

    public IQueryable<CardServiceModel> GetAllAsNoTracking()
    {
        return _cardRepository.GetAllAsNoTracking().Select(c => c.ToModel());
    }

    public CardServiceModel GetById(object id)
    {
        return _cardRepository.GetById((string)id).ToModel();
    }

    public async  Task<CardServiceModel> GetByIdAsync(string id)
    {
        var entity = await _cardRepository.GetByIdAsync(id);
        return entity.ToModel();
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
        var updatedEntity = await InternalUpdateAsync(model);
        return updatedEntity.ToModel();
        
    }

    public async Task<CardServiceModel> DeleteAsync(string id)
    {
        var card = _cardRepository.GetById(id);
        if (card == null)
            throw new KeyNotFoundException();
        var model = await _cardRepository.DeleteAsync(card);
        return model.ToModel();
        
    }

    private IQueryable<Card> InternalGetAll()
    {
        return _cardRepository.GetAll();
    }

    private async Task<Card> InternalUpdateAsync(CardServiceModel model)
    {
        return await _cardRepository.EditAsync(model.ToEntity());
    }
}