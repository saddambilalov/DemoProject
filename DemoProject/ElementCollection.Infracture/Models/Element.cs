namespace ElementCollection.Infracture.Models
{
    public class Element
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        protected bool Equals(Element other)
        {
            return Num == other.Num && string.Equals(Name, other.Name) && Age == other.Age;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Element other))
            {
                return false;
            }

            return Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Num;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Age;
                return hashCode;
            }
        }
    }
}
