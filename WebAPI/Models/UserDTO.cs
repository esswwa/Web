using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserDTO
    {
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string UserName { get; set; } = string.Empty;

        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Поле не должно содержать спецсимволы")]
        public string UserPassword { get; set; } = string.Empty;
    }
}
