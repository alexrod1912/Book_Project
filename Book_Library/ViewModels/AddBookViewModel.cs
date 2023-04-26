using System;
using System.ComponentModel.DataAnnotations;

namespace Book_Library.ViewModels
{
	public class AddBookViewModel
	{
        [Required(ErrorMessage = "Title is required.")]
        public string BookTitleVM { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string BookAuthorVM { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string? BookDescriptionVM { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0, 5, ErrorMessage ="Must be a number 0-5") ]
        public int? BookRatingVM { get; set; }

        [Required(ErrorMessage = "IMG Address is required.")]
        public string? BookIMG_VM { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string? BookGenreVM { get; set; }

        public AddBookViewModel()
		{
		}
	}
}

