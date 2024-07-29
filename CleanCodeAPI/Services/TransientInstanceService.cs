namespace CleanCodeAPI.Services
{
  public class TransientInstanceService
  {
    // init ile sadece Contructor üzerinden değer set edebiliriz
    public Guid Id { get; init; }

    public TransientInstanceService()
    {
      Id = Guid.NewGuid();
    }
  }
}
