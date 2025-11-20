//Grain is a virtual actor, activated on demand, unique identity, Orleans automatically loads/saves its state.
//Grain state = grains memory
using Orleans;
using Orleans.Runtime;
using TaskMatch.Models;

namespace TaskMatch.Grains;

public class UserGrain : Grain, IUserGrain
{
  private readonly IPersistentState<UserState> _state;//How Orleans persists grain data

  public UserGrain([PersistentState("user", "memoryStore")] IPersistentState<UserState> state)
  {
    _state = state;
  }

  public async Task Register(string name)
  {
    _state.State.Id = this.GetPrimaryKeyString();
    _state.State.Name = name;
    await _state.WriteStateAsync();
  }

  public Task<UserState> GetState() => Task.FromResult(_state.State);

}