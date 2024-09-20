namespace CadastroCliente
{
    public interface IClienteMongoRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddToMongoAsync(Cliente cliente);
        Task UpdateInMongoAsync(Cliente cliente);
        Task DeleteFromMongoAsync(int id);
    }
}