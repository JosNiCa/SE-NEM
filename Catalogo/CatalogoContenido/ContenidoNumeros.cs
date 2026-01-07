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
                        new IndicadorDef("IND-Num-6-1-1", "Expresa sucesiones ascendentes hasta billones"),
                        new IndicadorDef("IND-Num-6-1-2", "Expresa sucesiones descendentes hasta billones"),
                        new IndicadorDef("IND-Num-6-1-3", "Lee números con más de 9 cifras"),
                        new IndicadorDef("IND-Num-6-1-4", "Escribe números con más de 9 cifras"),
                        new IndicadorDef("IND-Num-6-1-5", "Ordena un conjunto de números grandes"),
                        new IndicadorDef("IND-Num-6-1-6", "Interpreta decimales correctamente en problemas"),
                        new IndicadorDef("IND-Num-6-1-7", "Contrasta sistema decimal"),
                        new IndicadorDef("IND-Num-6-1-8", "Contrasta sistema romano"),
                        new IndicadorDef("IND-Num-6-1-9", "Contrasta sistema maya")
                    }
                )
            }
        );
    }
}