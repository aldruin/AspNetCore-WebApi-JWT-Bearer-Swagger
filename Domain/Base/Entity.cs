namespace CashFlowAPI.Domain.Base;
public abstract class Entity
{

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; protected set; }
}