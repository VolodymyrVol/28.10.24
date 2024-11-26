using System.Diagnostics.Metrics;

namespace _2task
{
    internal class Program
    {
        class Library
        {
            public string[] Book { get; set; }

            #region constructors
            public Library()
            {
                Book = null;
            }
            public Library(string[] book)
            {
                this.Book = book;
            }
            public Library(string book)
            {
                if (Book == null)
                {
                    Book[0] = book;
                }
                else
                {
                    Book[Book.Length - 1] = book;
                }
            }
            public Library(string[] books, string book)
            {
                Book = books;
                Book[books.Length - 1] = book; 
            }

            #endregion

            public void Show()
            {
                Console.WriteLine("Book list: ");
                for (int i = 0; i < Book.Length; i++)
                {
                    Console.WriteLine($"- {Book[i]}");
                }
            }

            #region overloads
            public static Library operator +(Library obj, string book) => new Library(obj.Book, book);
            public static Library operator - (Library obj, string book)
            {
                int index = Array.IndexOf(obj.Book, book);

                if (index == -1)
                {
                    Console.WriteLine($"Book wasn`t found.");
                    return obj;
                }
                for (int i = index; i < obj.Book.Length - 1; i++)
                {
                    obj.Book[i] = obj.Book[i + 1];
                }

                int count = obj.Book.Length;
                obj.Book[count - 1] = null;
                return new Library(obj.Book); 
            }
            public static bool operator == (Library obj, string book)
            {
                for (int i = 0; i < obj.Book.Length; i++)
                {
                    if (obj.Book[i] == book)
                    {
                        return true;
                    }
                }
                return false;
            }
            public static bool operator !=(Library obj, string book)
            {
                for (int i = 0; i < obj.Book.Length; i++)
                {
                    if (obj.Book[i] != book)
                    {
                        return true;
                    }
                }
                return false;
            }



            #endregion

        }

        static void Main(string[] args)
        {
            
        }
    }
}
