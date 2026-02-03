using SE_NEM.domain.hechos.helper;

namespace SE_NEM.domain.hechos;

public sealed class BaseHechosDifusa : IBaseHechos
{
    private readonly Dictionary<string, IHecho> _hechos =
        new(StringComparer.OrdinalIgnoreCase);

    public bool Contiene(string id)
        => _hechos.ContainsKey(id);

    public IHecho ObtenerPorId(string id)
        => _hechos.TryGetValue(id, out var hecho)
            ? hecho
            : throw new KeyNotFoundException($"Hecho '{id}' no encontrado.");

    public IEnumerable<IHecho> ObtenerPorTipo(string tipo)
        => _hechos.Values.Where(h => h.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase));

    public IReadOnlyCollection<IHecho> Todos()
        => _hechos.Values.ToList().AsReadOnly();

    public void AgregarOActualizar(IHecho hecho)
    {
        if (!_hechos.TryGetValue(hecho.Id, out var existente))
        {
            _hechos.Add(hecho.Id, hecho);
            return;
        }

        // Combinación difusa
        var combinado = HechoCombiner.Combinar(existente, hecho);
        _hechos[hecho.Id] = combinado;
    }   
    
    public bool TryObtenerPorId(string id, out IHecho hecho)
    {
        return _hechos.TryGetValue(id, out hecho);
    }

    public IEnumerable<IHecho> ObtenerTodos()
    {
        return _hechos.Values;
    }
}