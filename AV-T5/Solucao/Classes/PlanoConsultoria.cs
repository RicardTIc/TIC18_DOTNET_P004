namespace AVT5.Solucao;
/*

Plano de Consultoria
o Título (string)
o Valor por mês (double)
o Benefícios (List<string>)

*/
public class PlanoConsultoria{
    public string Titulo { get; set; }
    public double ValorPorMes { get; set; }
    public List<string> Beneficios { get; set; }

    public PlanoConsultoria(string _titulo, double _valorPorMes, List<string> _beneficios)
    {
        this.Titulo = _titulo;
        this.ValorPorMes = _valorPorMes;
        this.Beneficios = _beneficios;
    }
}
