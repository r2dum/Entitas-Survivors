namespace CodeBase.Runtime.Infrastructure.EntityView.Registrars
{
  public interface IEntityComponentRegistrar
  {
    void RegisterComponents();
    void UnregisterComponents();
  }
}