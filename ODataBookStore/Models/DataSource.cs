namespace ODataBookStore.Models
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }

        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }
            listBooks = new List<Book>();
            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-306-40615-7",
                Title = "Essential C# 6.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address
                {
                    City = "Redmond",
                    Street = "156TH AVE NE"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            Book book1 = new Book
            {
                Id = 2,
                ISBN = "978-1-59327-584-6",
                Title = "The Art of Exploitation",
                Author = "Jon Erickson",
                Price = 49.99m,
                Location = new Address
                {
                    City = "San Francisco",
                    Street = "Howard St"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "No Starch Press",
                    Category = Category.Book
                }
            };
            listBooks.Add(book1);

            Book book2 = new Book
            {
                Id = 3,
                ISBN = "978-0-596-52068-7",
                Title = "Programming Python",
                Author = "Mark Lutz",
                Price = 69.99m,
                Location = new Address
                {
                    City = "Sebastopol",
                    Street = "Gravenstein Hwy North"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            };
            listBooks.Add(book2);

            return listBooks;
        }
    }
}
