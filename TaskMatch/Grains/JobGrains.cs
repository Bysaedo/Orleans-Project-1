//Same as UserGrain but handles job data.
using Orleans;
using Orleans.Runtime;
using TaskMatch.Models;

namespace TaskMatch.Grains;

public class JobGrain: Grain, IJobGrain
{
  private readonly IPersistentState<JobState> _state;

  public JobGrain([PersistentState("job", "memoryStore")] IPersistentState<JobState> state)
  {
    _state = state;
  }

  public async Task Create(string title, string description) //Initializes a job
  {
    _state.State.Id = this.GetPrimaryKeyString();
    _state.State.Title = title;
    _state.State.Description = description;
    await _state.WriteStateAsync();
  }

  public async Task AssignHelper(string helperId) //Updates job status and worker
  {
    _state.State.HelperId = helperId;
    _state.State.Status = "Assigned";
    await _state.WriteStateAsync();
  }

  public async Task UpdateStatus(string status) //Setter with persistence
  {
    _state.State.Status = status;
    await _state.WriteStateAsync();
  }

  public Task<JobState> GetState() => Task.FromResult(_state.State);
}