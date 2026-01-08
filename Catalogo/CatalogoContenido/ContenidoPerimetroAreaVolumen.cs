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
                        new IndicadorDef("IND-PA-6-1-1", "Descompone figuras en triángulos", true),
                        new IndicadorDef("IND-PA-6-1-2", "Descompone figuras en cuadriláteros", true),
                        new IndicadorDef("IND-PA-6-1-3", "Calcula perímetro", true),
                        new IndicadorDef("IND-PA-6-1-4", "Calcula área usando unidades convencionales", true),
                        new IndicadorDef("IND-PA-6-1-5", "Explica procedimiento de descomposición", false)
                    }
                ),
                new AepDef(
                    "AEP-PA-6-2",
                    "Noción de volumen y conteo de cubos",
                    new[]
                    {
                        new IndicadorDef("IND-PA-6-2-1", "Construye modelos con cubos", true),
                        new IndicadorDef("IND-PA-6-2-2", "Cuenta volumen por capas", true),
                        new IndicadorDef("IND-PA-6-2-3", "Compara sólidos con igual volumen", true),
                        new IndicadorDef("IND-PA-6-2-4", "Resuelve problemas de volumen", true)
                    }
                )
            }
        );
    }
}