using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;
using WebAPI.Models;
using WebMVC.Models;
namespace WebMVC.Models
{
    public interface InterfaceClient{
            [Get("/users")]
            Task<IEnumerable<Users>> GetAllUsers();
            [Get("/brands")]
            Task<IEnumerable<Brand>> GetAllBrands();

            [Get("/users/{id}")]
            Task<Users> GetUser(int id);
            [Get("/brands/{id}")]
            Task<Brand> GetBrand(int id);
            [Post("/brands")]
            Task CreateBrand([Body] BrandDTO task);

            [Put("/users/{id}")]
            Task EditUser(int id, [Body] Users user);
            [Put("/brands/{id}")]
            Task EditBrand(int id, [Body] Brand task);

            [Delete("/users/{id}")]
            Task DeleteUser(int id);
            [Delete("/brands/{id}")]
            Task DeleteBrand(int id);

            [Post("/users/signIn")]
            Task<string> SignIn([Body] UserDTO user);

            [Post("/users")]
            Task<Users> SignUp([Body] Users user);
    }
    
}
