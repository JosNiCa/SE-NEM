using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoIndicador :HechoBase
{
    public string IndicatorId { get; }
    public string AepId { get; }

    // Evidencia cruda
    public int TotalReactivos { get; }
    public int ReactivosCorrectos { get; }
    public int IntentosUsados { get; }
    public double TiempoTotalSegundos { get; }

    // Valores difusos por criterio
    public ValorDifuso Aciertos { get; }
    public ValorDifuso Tiempo { get; }
    public ValorDifuso Intentos { get; }

    public HechoIndicador(
        string id,
        string indicatorId,
        string aepId,
        int totalReactivos,
        int reactivosCorrectos,
        int intentosUsados,
        double tiempoTotalSegundos,
        ValorDifuso aciertos,
        ValorDifuso tiempo,
        ValorDifuso intentos,
        ValorDifuso valorFinal
    )
        : base(id, "IND", valorFinal)
    {
        IndicatorId = indicatorId;
        AepId = aepId;

        TotalReactivos = totalReactivos;
        ReactivosCorrectos = reactivosCorrectos;
        IntentosUsados = intentosUsados;
        TiempoTotalSegundos = tiempoTotalSegundos;

        Aciertos = aciertos;
        Tiempo = tiempo;
        Intentos = intentos;
    }
}