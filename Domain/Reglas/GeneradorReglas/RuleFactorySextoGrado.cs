using SE_NEM.Catalogo;
using SE_NEM.domain.reglas;

namespace SE_NEM.Domain.Reglas.GeneradorReglas;

public sealed class RuleFactorySextoGrado : IRuleFactory
{
    public IReadOnlyCollection<IRegla> CrearReglas()
    {
        var reglas = new List<IRegla>();

        foreach (var contenido in CatalogoSextoGrado.Contenidos)
        {
            reglas.AddRange(CrearReglasAep(contenido));
            reglas.Add(CrearReglaContenido(contenido));
        }
        
        reglas.Add(CrearReglasGrado(CatalogoSextoGrado.Contenidos));
        
        return  reglas;
    }
    
    private IEnumerable<IRegla> CrearReglasAep(ContenidoDef contenido)
    {
        foreach (var aep in contenido.Aeps)
        {
            yield return new ReglaAutoIndicadoresAAep(
                reglaId: $"R-IND-AEP-{aep.Id}",
                aepId: aep.Id,
                indicadores: aep.Indicadores
            );
        }
    }
    
    private IRegla CrearReglaContenido(ContenidoDef contenido)
    {
        return new ReglaAepsANivelContenido(
            id: $"R-AEP-CT-{contenido.Id}",
            contenidoId: contenido.Id,
            aepIds: contenido.Aeps.Select(a => a.Id)
        );
    }
    
    private IRegla CrearReglasGrado(IEnumerable<ContenidoDef> contenidos)
    {
        return new ReglaAutoContenidosAGrado(
            reglaId: "R-CT-GRADO-6",
            gradoId: "6TO",
            contenidosIds: contenidos.Select(c => c.Id)
        );
    }
}