using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;

namespace SE_NEM.Explanation;

public sealed class HechoResumen
{
    public string HechoId { get; }
    public string Tipo { get; }
    public double ValorDifuso { get; }
    public NivelCompetencia Nivel { get; }

    public HechoResumen(IHecho hecho)
    {
        HechoId = hecho.Id;
        Tipo = hecho.Tipo;
        ValorDifuso = hecho.Valor.Valor;
        Nivel = hecho.Valor.Nivel;
    }
}
