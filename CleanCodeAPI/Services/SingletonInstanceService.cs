namespace CleanCodeAPI.Services
{
  public class SingletonInstanceService
  {
    public Guid Id { get; init; }
    public SingletonInstanceService()
    {
      Id = Guid.NewGuid();
    }

  }
}
