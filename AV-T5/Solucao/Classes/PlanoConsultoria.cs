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

    public PlanoConsultoria(string _titulo, double _valorPorMes, List<string> _beneficios){
        this.Titulo = _titulo;
        this.ValorPorMes = _valorPorMes;
        this.Beneficios = _beneficios;
    }

    public override string ToString(){
        return this.Titulo + " - " + this.ValorPorMes + " - " + this.Beneficios;
    }

    public override bool Equals(object? obj){
        if (obj == null)
            return false;
        if (obj is PlanoConsultoria){
            PlanoConsultoria plano = (PlanoConsultoria)obj;
            return this.Titulo == plano.Titulo && this.ValorPorMes == plano.ValorPorMes && this.Beneficios == plano.Beneficios;
        }
        return false;
    }

    public override int GetHashCode(){
        return base.GetHashCode();
    }

    public static bool operator ==(PlanoConsultoria plano1, PlanoConsultoria plano2){
        return plano1.Equals(plano2);
    }

    public static bool operator !=(PlanoConsultoria plano1, PlanoConsultoria plano2){
        return !plano1.Equals(plano2);
    }
}
