public class Status
{
    public float defaultHP;
    public float plusHP;
    public float CurrentHP { get { return defaultHP + plusHP; } }

    public float defaultSpeed;
    public float plusSpeed;
    public float CurrentSpeed { get { return defaultSpeed + plusSpeed; } }

    public Status()
    {
        defaultSpeed = 10;
    }
}
