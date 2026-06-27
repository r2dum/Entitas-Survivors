using System;

namespace CodeBase.Runtime.Infrastructure.StateMachine.Registrar
{
  public interface IStatesRegistrar : IDisposable
  {
    void RegisterStates();
  }
}