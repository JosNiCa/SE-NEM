namespace SE_NEM.domain.reglas;

public interface IRuleFactory
{
    IReadOnlyCollection<IRegla> CrearReglas();
}