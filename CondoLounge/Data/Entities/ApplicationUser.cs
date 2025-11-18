using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public Building Building {  get; set; }

        public ICollection<Condo> Condo {  get; set; } = new List<Condo>();

    }
}
