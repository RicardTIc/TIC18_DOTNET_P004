public class GerenciadorCasoJuridico
{
    public void IniciarCaso(CasoJuridico caso)
    {
        caso.Abertura = DateTime.Now;
        caso.Status = "Em aberto";
    }

    public void AtualizarCaso(CasoJuridico caso)
    {
        if (caso.Status == "Concluído" && caso.Encerramento.HasValue && caso.Encerramento <= caso.Abertura)
        {
            throw new InvalidOperationException("A data de conclusão deve ser posterior à data de início.");
        }

        // Outras lógicas de atualização do caso
    }
}
