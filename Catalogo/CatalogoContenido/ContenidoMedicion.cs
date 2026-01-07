namespace SE_NEM.Catalogo;

internal static partial class ContenidosCatalogo
{
    internal static ContenidoDef ContenidoMedicion()
    {
        return new ContenidoDef(
            Id: "CT-MED",
            Nombre: "Medición",
            Aeps: new[]
            {
                new AepDef(
                    "AEP-Med-6-1",
                    "Medición de longitud, masa y capacidad",
                    new[]
                    {
                        new IndicadorDef("IND-MED-6-1-1", "Selecciona unidad correcta"),
                        new IndicadorDef("IND-MED-6-1-2", "Convierte unidades"),
                        new IndicadorDef("IND-MED-6-1-3", "Resuelve problemas"),
                        new IndicadorDef("IND-MED-6-1-4", "Justifica su elección de unidad")
                    }
                )
            }
        );
    }

}