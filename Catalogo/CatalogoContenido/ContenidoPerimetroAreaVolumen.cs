namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoPerimetroAreaVolumen()
    {
        return new ContenidoDef(
            Id: "CT-PAV",
            Nombre: "Perímetro, área y volumen",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-PA-6-1",
                    "Perímetro y área de figuras compuestas",
                    new[]
                    {
                        new IndicadorDef("IND-PA-6-1-1", "Descompone figuras en triángulos"),
                        new IndicadorDef("IND-PA-6-1-2", "Descompone figuras en cuadriláteros"),
                        new IndicadorDef("IND-PA-6-1-3", "Calcula perímetro"),
                        new IndicadorDef("IND-PA-6-1-4", "Calcula área usando unidades convencionales"),
                        new IndicadorDef("IND-PA-6-1-5", "Explica procedimiento de descomposición")
                    }
                ),
                new AepDef(
                    "AEP-PA-6-2",
                    "Noción de volumen y conteo de cubos",
                    new[]
                    {
                        new IndicadorDef("IND-PA-6-2-1", "Construye modelos con cubos"),
                        new IndicadorDef("IND-PA-6-2-2", "Cuenta volumen por capas"),
                        new IndicadorDef("IND-PA-6-2-3", "Compara sólidos con igual volumen"),
                        new IndicadorDef("IND-PA-6-2-4", "Resuelve problemas de volumen")
                    }
                )
            }
        );
    }
}