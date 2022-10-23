namespace MotorVehicleLib;

public class Engine : IEngine
{
    private bool _hasProblem;

    public Engine(IRandom random = null)
    {
        random ??= new Random100();
        _hasProblem = false;
        if (random.GetNumber() >= 90)
        {
            _hasProblem = true;
        }
    }

    public void Fix()
    {
        _hasProblem = false;
    }

    public bool HasProblem()
    {
        return _hasProblem;
    }
}