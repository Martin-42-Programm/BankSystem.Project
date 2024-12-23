namespace BankSystem.Data.Entities;

public class MetadataBaseEntity : BaseEntity
{
    public User? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public User? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    public User? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}