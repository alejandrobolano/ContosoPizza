namespace ContosoPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(Pizza other)
        {
            return Id == other.Id && Name == other.Name && IsGlutenFree == other.IsGlutenFree;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsGlutenFree);
        }
    }
}
