using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class BrandDTO
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 100 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string BrandName { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 1000 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string BrandDescription { get; set; } = string.Empty;
        public bool BrandIsConfirm { get; set; }
        public int BrandUserId { get; set; }
    }
}
