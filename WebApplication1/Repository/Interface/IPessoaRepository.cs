using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.DTO;

namespace VoteInRestaurant.Repository.Interface
{
    public interface IPessoaRepository
    {
        Task<List<PessoaDTO>> RetornaTodasAsPessoas();
        Task<PessoaDTO> CadastraNovaPessoa(PessoaDTO pessoaDTO);
        Task<PessoaDTO> RetornaPessoaPorId(long id);
    }
}
