using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoGrado : HechoBase
{
    public string GradoId { get; }
    public IReadOnlyList<string> ContenidosOrigen { get; }
    
    public HechoGrado(
        string id,
        string gradoId,
        IEnumerable<string> contenidosOrigen,
        ValorDifuso valor
    )
        : base(id, "GRADO", valor)
    {
        GradoId = gradoId;
        ContenidosOrigen = contenidosOrigen.ToList().AsReadOnly();
    }
}