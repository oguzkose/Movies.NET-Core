using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_oguzkose.Models
{
    public class MovieViewModel
    {

        [Range(0, int.MaxValue, ErrorMessage = "Aralık dışında değer girdiniz. 0'dan büyük bir sayı giriniz")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Film adı alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yönetmen adı alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Oyuncu adı alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string Cast { get; set; }
        [Required(ErrorMessage = "Çekim Yılı alanı gereklidir.")]
        [Range(1900, 2020 , ErrorMessage = "Aralık dışında değer girdiniz. 1900 ve 2020 arasında bir değer giriniz")]
        public int ReleaseYear { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Writer { get; set; }
        //to do: seçiniz yazısı olmayacak ve bizim istediğimiz kategori dışında birşey yazılamayacak
        public string Category { get; set; }
        //to do: URL dışında birşey girilemeyecek
        [Url(ErrorMessage = "Url formatı hatalıdır.")]
        public string ImdbUrl { get; set; }
        [Range(0, 10, ErrorMessage = "Aralık dışında değer girdiniz. 0 ile 10 arasında bir sayı giriniz")]
        public decimal Score { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Aralık dışında değer girdiniz. 0'dan büyük bir sayı giriniz")]
        public int Review { get; set; }

        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (Category != "Drama" && Category != "Adventure" && Category != "Biography")
            {
                yield return new ValidationResult("Kategori Tercihi Yapınız.", new[] { nameof(Category) });
            }

            
        }


    }
}
