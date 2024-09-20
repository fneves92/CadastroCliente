namespace CadastroCliente
{
    public interface IClienteCommandRepository
    {
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}