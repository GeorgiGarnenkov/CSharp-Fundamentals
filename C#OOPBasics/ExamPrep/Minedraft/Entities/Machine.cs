public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }
}