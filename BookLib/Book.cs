namespace BookLib
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Book()
        {

        }
        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public void Validate()
        {
            ValidateName();
            ValidatePrice();
        }
        public void ValidateName()
        {
            if (Title == null)
            { throw new ArgumentNullException("Title can't be null"); }

            if (Title.Length <= 2)
            {
                throw new ArgumentException("Title must exceed 2 characters");
            }

        }
        public void ValidatePrice()
        {
            if (Price > 1200)
            { throw new ArgumentException("Price must be max 1200"); }

            if (Price == 0)
            { throw new ArgumentException("Book must have a price"); }

            if (Price < 0)
            { throw new ArgumentException("Price must be positive"); }
        }

        public override string ToString()
        {
            return $"Title: {Title}, Price: {Price}";
        }


    }
}