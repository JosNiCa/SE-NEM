namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoUbicacion()
    {
        return new ContenidoDef(
            Id: "CT-UB",
            Nombre: "Ubicación espacial",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-Ub-6-1",
                    "Elaboración e interpretación de planos",
                    new[]
                    {
                        new IndicadorDef("IND-UB-6-1-1", "Lee planos con escala"),
                        new IndicadorDef("IND-UB-6-1-2", "Ubica elementos correctamente"),
                        new IndicadorDef("IND-UB-6-1-3", "Elabora un plano sencillo"),
                        new IndicadorDef("IND-UB-6-1-4", "Resuelve problemas a partir del plano")
                    }
                ),
                new AepDef(
                    "AEP-Ub-6-2",
                    "Ubicación en el primer cuadrante",
                    new[]
                    {
                        new IndicadorDef("IND-UB-6-2-1", "Identifica ejes y cuadrantes"),
                        new IndicadorDef("IND-UB-6-2-2", "Ubica puntos (x,y) correctamente"),
                        new IndicadorDef("IND-UB-6-2-3", "Interpreta desplazamientos"),
                        new IndicadorDef("IND-UB-6-2-4", "Resuelve problemas con coordenadas")
                    }
                )
            }
        );
    }

}