namespace SE_NEM.Fuzzification;

public sealed class FuncionTrapezoidal : IFuncionPertenencia
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;
    private readonly double _d;

    public FuncionTrapezoidal(double a, double b, double c, double d)
    {
        if (!(a <= b && b <= c && c <= d))
            throw new ArgumentException("Parámetros inválidos para función trapezoidal");

        _a = a;
        _b = b;
        _c = c;
        _d = d;
    }

    public double Evaluar(double x)
    {
        if (x <= _a || x >= _d) return 0.0;
        if (x >= _b && x <= _c) return 1.0;
        if (x > _a && x < _b) return (x - _a) / (_b - _a);
        return (_d - x) / (_d - _c);
    }
}