namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoGeometriaCuerpos()
    {
        return new ContenidoDef(
            Id: "CT-GEO-C",
            Nombre: "Cuerpos geométricos",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-GeoC-6-1",
                    "Cilindro y cono: características y desarrollos planos",
                    new[]
                    {
                        new IndicadorDef("IND-GEOC-6-1-1", "Identifica bases", true),
                        new IndicadorDef("IND-GEOC-6-1-2", "Identifica generatriz", true),
                        new IndicadorDef("IND-GEOC-6-1-3", "Identifica altura", true),
                        new IndicadorDef("IND-GEOC-6-1-4", "Reconoce diferencias cilindro vs cono", true),
                        new IndicadorDef("IND-GEOC-6-1-5", "Propone desarrollos planos funcionales", true),
                        new IndicadorDef("IND-GEOC-6-1-6", "Verifica construcción física o mental", false)
                    }
                )
            }
        );
    }
}