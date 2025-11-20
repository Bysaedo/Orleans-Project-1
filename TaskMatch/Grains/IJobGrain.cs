//Supports the operations supported by each job
using Orleans;
using TaskMatch.Models;

namespace TaskMatch.Grains;

public interface IJobGrain : IGrainWithStringKey
{
  Task Create(string title, string description);
  Task AssignHelper(string helperId);
  Task UpdateStatus(string status);
  Task<JobState> GetState();
}