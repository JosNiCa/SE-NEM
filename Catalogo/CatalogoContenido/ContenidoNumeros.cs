namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoNumeros()
    {
        return new ContenidoDef(
            Id: "CT-NUM",
            Nombre: "Estudio de los números",
            Aeps: new[]
            {
                new AepDef(
                    Id: "AEP-Num-6-1",
                    Descripcion: "Sucesiones, lectura y escritura de números naturales y decimales",
                    Indicadores: new[]
                    {
                        new IndicadorDef("IND-Num-6-1-1", "Expresa sucesiones ascendentes hasta billones", true),
                        new IndicadorDef("IND-Num-6-1-2", "Expresa sucesiones descendentes hasta billones", true),
                        new IndicadorDef("IND-Num-6-1-3", "Lee números con más de 9 cifras",true),
                        new IndicadorDef("IND-Num-6-1-4", "Escribe números con más de 9 cifras", true),
                        new IndicadorDef("IND-Num-6-1-5", "Ordena un conjunto de números grandes", true),
                        new IndicadorDef("IND-Num-6-1-6", "Interpreta decimales correctamente en problemas", true),
                        new IndicadorDef("IND-Num-6-1-7", "Contrasta sistema decimal", false),
                        new IndicadorDef("IND-Num-6-1-8", "Contrasta sistema romano", false),
                        new IndicadorDef("IND-Num-6-1-9", "Contrasta sistema maya", false)
                    }
                )
            }
        );
    }
}