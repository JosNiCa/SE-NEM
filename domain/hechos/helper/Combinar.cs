using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;

namespace SE_NEM.domain.hechos.helper;


internal static partial class HechoCombiner
{
    internal static IHecho Combinar(IHecho anterior, IHecho nuevo)
    {
        if (anterior.Tipo != nuevo.Tipo)
            throw new InvalidOperationException(
                $"No se pueden combinar hechos de distinto tipo ({anterior.Tipo} vs {nuevo.Tipo}).");

        // max difuso → conserva el mejor desempeño
        var valorCombinado = Math.Max(
            anterior.Valor.Valor,
            nuevo.Valor.Valor
        );

        var valorDifuso = ValorDifuso.DesdeValor(valorCombinado);

        return anterior switch
        {
            HechoIndicador ind => CombinarIndicador(ind, (HechoIndicador)nuevo, valorDifuso),
            HechoAEP aep       => new HechoAEP(aep.Id, aep.AepId, aep.IndicadoresOrigen, valorDifuso),
            HechoContenido ct => new HechoContenido(ct.Id, ct.ContenidoId, ct.AepsOrigen, valorDifuso),
            HechoGrado g      => new HechoGrado(g.Id, g.GradoId, g.ContenidosOrigen,  valorDifuso),
            _ => throw new NotSupportedException("Tipo de hecho no soportado.")
        };
    }
}
