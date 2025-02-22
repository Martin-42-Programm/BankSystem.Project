using Microsoft.AspNetCore.Mvc;

public class CardController : Controller

{
    private CardRepository cardRepository;

    public CardController(CardRepository cardRepository)
    {
        this.cardRepository = cardRepository;
    }
    
}