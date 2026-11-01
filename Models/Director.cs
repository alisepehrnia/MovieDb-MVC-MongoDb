namespace MvcMovie.Models
{
    public class Director : Person
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}