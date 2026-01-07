using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;

namespace SE_NEM.domain.hechos.helper;

internal static partial class HechoCombiner
{
    private static HechoIndicador CombinarIndicador(
        HechoIndicador anterior,
        HechoIndicador nuevo,
        ValorDifuso valorFinal)
    {
        return new HechoIndicador(
            id: anterior.Id,
            indicatorId: anterior.IndicatorId,
            aepId: anterior.AepId,

            totalReactivos: Math.Max(anterior.TotalReactivos, nuevo.TotalReactivos),
            reactivosCorrectos: Math.Max(anterior.ReactivosCorrectos, nuevo.ReactivosCorrectos),
            intentosUsados: Math.Min(anterior.IntentosUsados, nuevo.IntentosUsados),
            tiempoTotalSegundos: Math.Min(anterior.TiempoTotalSegundos, nuevo.TiempoTotalSegundos),

            aciertos: Max(anterior.Aciertos, nuevo.Aciertos),
            tiempo: Max(anterior.Tiempo, nuevo.Tiempo),
            intentos: Max(anterior.Intentos, nuevo.Intentos),

            valorFinal: valorFinal
        );
    }

    private static ValorDifuso Max(ValorDifuso a, ValorDifuso b)
        => a.Valor >= b.Valor ? a : b;
}