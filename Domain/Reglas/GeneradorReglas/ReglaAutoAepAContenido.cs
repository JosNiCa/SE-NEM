// Domain/Reglas/GeneradorReglas/ReglaAutoAepAContenido.cs
using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;
using SE_NEM.domain.reglas;

namespace SE_NEM.Domain.Reglas;

public sealed class ReglaAepsANivelContenido : ReglaDifusaBase
{
    private readonly string _contenidoId;
    private readonly IReadOnlyList<string> _aepIds;
    private readonly int _minimoAepsPresentes;

    public ReglaAepsANivelContenido(
        string id,
        string contenidoId,
        IEnumerable<string> aepIds,
        int minimoAepsPresentes = 1)
        : base(id, $"Inferir Contenido {contenidoId} desde AEPs")
    {
        _contenidoId = contenidoId;
        _aepIds = aepIds.ToList().AsReadOnly();
        _minimoAepsPresentes = Math.Max(1, minimoAepsPresentes);
    }

    public override bool EsAplicable(IBaseHechos hechos)
    {
        int presentes = _aepIds.Count(hechos.Contiene);
        return presentes >= _minimoAepsPresentes;
    }

    public override IHecho Ejecutar(IBaseHechos hechos)
    {
        var aepsPresentes = _aepIds
            .Where(hechos.Contiene)
            .Select(aepId => (HechoAEP)hechos.ObtenerPorId(aepId))
            .ToList();

        // Agregación difusa: min sobre los AEP presentes
        var valor = ValorDifuso.DesdeValor(aepsPresentes.Min(a => a.Valor.Valor));

        return new HechoContenido(
            id: _contenidoId,
            contenidoId: _contenidoId,
            aepsOrigen: aepsPresentes.Select(a => a.Id).ToList(),
            valor: valor
        );
    }
}