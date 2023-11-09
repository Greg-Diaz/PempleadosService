using PempleadosService.models;

namespace PempleadosService.repository
{
    public interface iemployeRepository
    {
        Task<IEnumerable<employe>> GetEmployesDetails(string nombre);
        Task<IEnumerable<employe>> GetEmployes();
        Task<bool> CreateEmploye(employe employe);
        Task<bool> UpdateEmploye(employe employe);
        Task<bool> DeleteEmploye(int id);
    }
}
