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
        _aepId = NormalizarAepId(aepId);
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
            id: _aepId,
            aepId: _aepId,
            indicadoresOrigen: _indicadoresNucleares,
            valor: valor
        );
    }
    
    private static string NormalizarAepId(string aepId)
    {
        if (string.IsNullOrWhiteSpace(aepId))
            return aepId;

        // Quita duplicados tipo AEP-AEP-SR-6-1 → AEP-SR-6-1 (repetidas veces si aplica)
        const string prefijo = "AEP-";
        while (aepId.StartsWith(prefijo + prefijo, StringComparison.OrdinalIgnoreCase))
            aepId = prefijo + aepId.Substring((prefijo + prefijo).Length);

        return aepId;
    }
}