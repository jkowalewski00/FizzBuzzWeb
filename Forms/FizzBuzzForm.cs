using System.ComponentModel.DataAnnotations;
using System;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {

        [Required(ErrorMessage ="Pole jest wymagane")]
        [Range(1899,2022, ErrorMessage ="Oczekiwana wartość {0} z zakresu <{1} , {2}>")]
        [Display(Name="Rok urodzenia")]
        public int Year { get; set; }

        [RegularExpression("[A-Za-z]*", ErrorMessage ="Nie można wpisać cyfr i znaków specjalnych")]
        [Required(ErrorMessage ="Pole {0} jest wymagane")]
        [Display(Name="Imię")]
        [MaxLength(100)]
        public String Name { get; set; }

        public bool leapYear { get; set; }

        public void checkYear()
        {
            leapYear = ((Year % 4 == 0) && (Year % 100 != 0) || (Year % 400 == 0));
        }

    }
}
