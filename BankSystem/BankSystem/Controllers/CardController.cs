using Microsoft.AspNetCore.Mvc;

public class CardController : Controller

{
    private ICardService _cardService;

    public CardController(ICardService cardService)
    {
        this._cardService = cardService;
    }
    
}