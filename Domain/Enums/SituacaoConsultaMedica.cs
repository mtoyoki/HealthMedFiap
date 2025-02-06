namespace Domain.Enums
{
    [Serializable]
    public enum SituacaoConsultaMedica : short
    {
        Agendada = 1,
        Aceita = 2,
        Cancelada = 3,
        Recusada = 4,
        Concluida = 5
    }

    public static class SituacaoConsultaMedicaExtensions
    {
        public static string Descricao(this SituacaoConsultaMedica situacao)
        {
            switch (situacao)
            {
                case SituacaoConsultaMedica.Agendada: return "Agendada";
                case SituacaoConsultaMedica.Aceita: return "Aceita";
                case SituacaoConsultaMedica.Cancelada: return "Cancelada";
                case SituacaoConsultaMedica.Recusada: return "Recusada";
                case SituacaoConsultaMedica.Concluida: return "Concluída";
                default: throw new Exception("Situação inválida: " + situacao);
            }
        }
    }
}
