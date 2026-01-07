namespace SE_NEM.domain.hechos;

public interface IBaseHechos
{
    void AgregarOActualizar(IHecho hecho);
    IEnumerable<IHecho> ObtenerPorTipo(string tipo);
    IHecho ObtenerPorId(string id);
    bool Contiene(string id);
}