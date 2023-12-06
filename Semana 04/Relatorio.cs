public class Relatorios
{
    public List<Advogado> AdvogadosEntreIdades(List<Advogado> advogados, int idadeMin, int idadeMax)
    {
        return advogados.Where(a => (DateTime.Now - a.DataNascimento).TotalDays >= idadeMin * 365 &&
                                     (DateTime.Now - a.DataNascimento).TotalDays <= idadeMax * 365)
                        .ToList();
    }

    public List<Cliente> ClientesEntreIdades(List<Cliente> clientes, int idadeMin, int idadeMax)
    {
        return clientes.Where(c => (DateTime.Now - c.DataNascimento).TotalDays >= idadeMin * 365 &&
                                   (DateTime.Now - c.DataNascimento).TotalDays <= idadeMax * 365)
                        .ToList();
    }

    public List<Cliente> ClientesPorEstadoCivil(List<Cliente> clientes, string estadoCivil)
    {
        return clientes.Where(c => c.EstadoCivil == estadoCivil)
                        .ToList();
    }

    public List<Cliente> ClientesOrdenadosPorNome(List<Cliente> clientes)
    {
        return clientes.OrderBy(c => c.Nome)
                        .ToList();
    }

    public List<Cliente> ClientesPorProfissao(List<Cliente> clientes, string textoProfissao)
    {
        return clientes.Where(c => c.Profissao.Contains(textoProfissao))
                        .ToList();
    }

    public List<Advogado> AdvogadosAniversariantesDoMes(List<Advogado> advogados, int mes)
    {
        return advogados.Where(a => a.DataNascimento.Month == mes)
                        .ToList();
    }

    public List<CasoJuridico> CasosEmAbertoOrdenadosPorData(List<CasoJuridico> casos)
    {
        return casos.Where(c => c.Status == "Em aberto")
                    .OrderBy(c => c.Abertura)
                    .ToList();
    }

    public List<Advogado> AdvogadosOrdenadosPorCasosConcluidos(List<Advogado> advogados, List<CasoJuridico> casos)
    {
        return advogados.OrderByDescending(a => casos.Count(c => c.Advogados.Contains(a) && c.Status == "Concluído"))
                        .ToList();
    }

    public List<CasoJuridico> CasosComCustoDescricao(List<CasoJuridico> casos, string palavraChave)
    {
        return casos.Where(c => c.Documentos.Any(d => d.Descricao.Contains(palavraChave)))
                    .ToList();
    }

    public List<string> Top10TiposDocumentosMaisInseridos(List<CasoJuridico> casos)
    {
        var tiposDocumentos = casos.SelectMany(c => c.Documentos)
                                   .GroupBy(d => d.Tipo)
                                   .OrderByDescending(g => g.Count())
                                   .Take(10)
                                   .Select(g => g.Key)
                                   .ToList();

        return tiposDocumentos;
    }
}