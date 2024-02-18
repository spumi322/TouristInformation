namespace TouristInformation.Data.Models
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
