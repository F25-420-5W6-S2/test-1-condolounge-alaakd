namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public int Id { get; set; }
        public int CondoId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; } = default!;

    }
}
