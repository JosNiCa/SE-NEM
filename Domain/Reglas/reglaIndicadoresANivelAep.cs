using SE_NEM.domain.difuso;
using SE_NEM.domain.hechos;

namespace SE_NEM.domain.reglas;

public sealed class ReglaIndicadoresANivelAep : ReglaDifusaBase
{
    private readonly string _aepId;
    private readonly IReadOnlyList<string> _indicadoresNucleares;

    public ReglaIndicadoresANivelAep(
        string id,
        string aepId,
        IEnumerable<string> indicadoresNucleares
    )
        : base(id, $"Inferir AEP {aepId} desde indicadores")
    {
        _aepId = aepId;
        _indicadoresNucleares = indicadoresNucleares.ToList().AsReadOnly();
    }

    public override bool EsAplicable(IBaseHechos hechos)
    {
        return _indicadoresNucleares.All(hechos.Contiene);
    }

    public override IHecho Ejecutar(IBaseHechos hechos)
    {
        var indicadores = _indicadoresNucleares
            .Select(id => (HechoIndicador)hechos.ObtenerPorId(id))
            .ToList();

        // Operador AND difuso → min
        double valorDifuso = indicadores
            .Min(i => i.Valor.Valor);

        var valor = ValorDifuso.DesdeValor(valorDifuso);

        return new HechoAEP(
            id: $"AEP-{_aepId}",
            aepId: _aepId,
            indicadoresOrigen: _indicadoresNucleares,
            valor: valor
        );
    }
}