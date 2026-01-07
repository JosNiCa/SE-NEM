using static SE_NEM.Catalogo.ContenidosCatalogo;

namespace SE_NEM.Catalogo;

public static class CatalogoSextoGrado
{
    public static IReadOnlyList<ContenidoDef> Contenidos { get; } =
        new List<ContenidoDef>
        {
            ContenidoNumeros(),
            ContenidoSumaResta(),
            ContenidoMultDiv(),
            ContenidoProporcionalidad(),
            ContenidoGeometriaCuerpos(),
            ContenidoGeometriaFiguras(),
            ContenidoUbicacion(),
            ContenidoMedicion(),
            ContenidoPerimetroAreaVolumen(),
            ContenidoDatos(),
            ContenidoProbabilidad()
        };
}