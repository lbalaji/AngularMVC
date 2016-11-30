using System.ComponentModel;

namespace AngularJSAuthentication.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CalculatorModal
    {
        public CalculatorModal()
        {
            OperationType = 0;
        }

        [Display(Name = "id")]
        public string Id { get; set; }

      
        [Display(Name = "Username")]
        public string Username { get; set; }

         [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number 1")]

        public decimal Number1 { get; set; }

        [Required]
        [Display(Name = "Number 2")]
        public decimal Number2 { get; set; }

        [Required]
        [Display(Name = "Operation")]
        public OperationTypes OperationType { get; set; }

        [Required]
        [ReadOnly(true)]
        [Display(Name = "Result")]

        public decimal Result { get; set; }
    }
}