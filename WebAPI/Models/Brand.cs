using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BrandId")]
        public int BrandId { get; set; }
        [Column("BrandName")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 100 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string BrandName { get; set; } = string.Empty;
        [Column("BrandDescription")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 1000 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string BrandDescription { get; set; } = string.Empty;
        [Column("BrandDuration")]
        public bool BrandIsConfirm { get; set; }
        [Column("BrandUserId")]
        public int BrandUserId { get; set; }
        public Users user { get; set; } = new Users();
    }
}
