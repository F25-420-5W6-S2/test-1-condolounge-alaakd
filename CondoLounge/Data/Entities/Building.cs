namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        
        public int BuildingId { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ICollection<Condo> Condos { get; set; } = new List<Condo>();

    }
}
