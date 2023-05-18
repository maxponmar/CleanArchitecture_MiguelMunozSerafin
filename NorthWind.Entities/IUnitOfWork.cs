namespace NorthWind.Entities
{
    public interface IUnitOfWork
    {
        ValueTask SaveChanges();
    }
}
