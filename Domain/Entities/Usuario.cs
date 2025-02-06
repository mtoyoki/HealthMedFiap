using Core.Entities;

namespace Domain.Entities
{
    public abstract class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public void CriptografarSenha(string senha)
        {
            Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, Senha);
        }
    }
}
