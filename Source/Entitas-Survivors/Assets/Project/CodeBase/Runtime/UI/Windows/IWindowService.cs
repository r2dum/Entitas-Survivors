namespace CodeBase.Runtime.UI.Windows
{
  public interface IWindowService
  {
    void Open(WindowTypeId windowTypeId);
    void Close(WindowTypeId windowTypeId);
  }
}