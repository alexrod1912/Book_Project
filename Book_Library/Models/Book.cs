using System;
namespace Book_Library.Models
{
	public class Book
	{
		public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
        public string? BookDescription { get; set; }
		public int? BookRating { get; set; }
        public string? BookIMG { get; set; }
		public string? BookGenre { get; set; }
		public int Id { get; set; }
		public string? BookUserId { get; set; }

		public Book(string bookTitle, string bookDescription, string bookAuthor, int bookRating, string bookIMG, string bookGenre, string bookUserId)
		{
			BookTitle = bookTitle;
			BookAuthor = bookAuthor;
			BookDescription = bookDescription;
			BookRating = bookRating;
			BookIMG = bookIMG;
			BookGenre = bookGenre;
			BookUserId = bookUserId;
		}

		public Book()
		{

		}
	}
}

