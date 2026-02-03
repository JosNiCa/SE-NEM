// Domain/Hechos/HechoContenido.cs
using SE_NEM.domain.difuso;

namespace SE_NEM.domain.hechos;

public sealed class HechoContenido : IHecho
{
    public string Id { get; }
    public string Tipo => "CONTENIDO";

    public string ContenidoId { get; }
    public IReadOnlyList<string> AepsOrigen { get; }
    public ValorDifuso Valor { get; }

    public HechoContenido(string id, string contenidoId, IReadOnlyList<string> aepsOrigen, ValorDifuso valor)
    {
        Id = id;
        ContenidoId = contenidoId;
        AepsOrigen = aepsOrigen;
        Valor = valor;
    }
}