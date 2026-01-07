using SE_NEM.domain.difuso;

namespace SE_NEM.Explanation;

public sealed class Explicacion
{
    public string HechoGeneradoId { get; }
    public string TipoHecho { get; }
    public string ReglaId { get; }
    public string ReglaDescripcion { get; }

    public IReadOnlyList<HechoResumen> HechosUsados { get; }

    public ValorDifuso Resultado { get; }

    public DateTime Timestamp { get; }

    public Explicacion(
        string hechoGeneradoId,
        string tipoHecho,
        string reglaId,
        string reglaDescripcion,
        IEnumerable<HechoResumen> hechosUsados,
        ValorDifuso resultado)
    {
        HechoGeneradoId = hechoGeneradoId;
        TipoHecho = tipoHecho;
        ReglaId = reglaId;
        ReglaDescripcion = reglaDescripcion;
        HechosUsados = hechosUsados.ToList().AsReadOnly();
        Resultado = resultado;
        Timestamp = DateTime.UtcNow;
    }
}
