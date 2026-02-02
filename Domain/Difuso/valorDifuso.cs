namespace SE_NEM.domain.difuso;

public class ValorDifuso
{
    public double Valor;        // ∈ [0,1]
    public NivelCompetencia Nivel;
    
    private ValorDifuso(double valor)
    {
        Valor = Math.Clamp(valor, 0.0, 1.0);
        Nivel = CalcularNivel(Valor);
    }

    public static ValorDifuso DesdeValor(double valor)
        => new(valor);

    private static NivelCompetencia CalcularNivel(double v)
    {
        if (v >= 0.90) return NivelCompetencia.E;
        if (v >= 0.66) return NivelCompetencia.M;
        if (v >= 0.33) return NivelCompetencia.P;
        return NivelCompetencia.I;
    }
}