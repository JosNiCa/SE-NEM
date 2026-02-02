using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;
using SE_NEM.Explanation;

namespace SE_NEM.Domain.Reglas.GeneradorReglas;

public sealed class ReglaAutoAepAContenido : ReglaDifusaBase, IReglaConHechos
{
    private readonly string _contenidoId;
    private readonly IReadOnlyList<string> _aepIds;

    public ReglaAutoAepAContenido(
        string reglaId,
        string contenidoId,
        IEnumerable<string> aepIds
    )
        : base(reglaId, $"Inferir contenido {contenidoId}")
    {
        _contenidoId = contenidoId;
        _aepIds = aepIds.ToList().AsReadOnly();
    }

    public override bool EsAplicable(IBaseHechos hechos)
        => _aepIds.All(hechos.Contiene);

    public override IHecho Ejecutar(IBaseHechos hechos)
    {
        var aeps = _aepIds.Select(hechos.ObtenerPorId).ToList();

        var valorDifuso = aeps.Min(h => h.Valor.Valor);

        return new HechoContenido(
            id: $"CT-{_contenidoId}",
            contenidoId: _contenidoId,
            aepsOrigen: _aepIds,
            valor: ValorDifuso.DesdeValor(valorDifuso)
        );
    }

    public IEnumerable<IHecho> ObtenerHechosUsados(IBaseHechos hechos)
        => _aepIds.Select(hechos.ObtenerPorId);
}
