using System;
public class Books
{
    public string BookName { get; set; }
    public string AuthorName { get; set; }

    public Books(string bookName, string authorName)
    {
        BookName = bookName;
        AuthorName = authorName;
    }
    public void Display()
    {
        Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        Console.ReadLine();
    }
}

public class BookShelf
{
    private Books[] books = new Books[5];

    public Books this[int index]
    {
        get
        {
            if (index >= 0 && index < books.Length)
                return books[index];
            else
                throw new IndexOutOfRangeException("Index out of range");
        }
        set
        {
            if (index >= 0 && index < books.Length)
                books[index] = value;
            else
                throw new IndexOutOfRangeException("Index out of range");
        }
    }
    public void DisplayAllBooks()
    {
        for (int i = 0; i < books.Length; i++)
        {
            Console.Write($"Book {i + 1}: ");
            books[i]?.Display();
        }
    }
}
class Prog01
{
    static void Main()
    {
        BookShelf shelf = new BookShelf();

        shelf[0] = new Books("1984", "George Orwell");
        shelf[1] = new Books("To Kill a Mockingbird", "Harper Lee");
        shelf[2] = new Books("The Great Gatsby", "F. Scott Fitzgerald");
        shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
        shelf[4] = new Books("Moby Dick", "Herman Melville");
        shelf.DisplayAllBooks();
    }
}
