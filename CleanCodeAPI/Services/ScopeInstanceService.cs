namespace CleanCodeAPI.Services
{
  public class ScopeInstanceService
  {
    public Guid Id { get; init; }
    public ScopeInstanceService()
    {
      Id = Guid.NewGuid();
    }
  }
}
