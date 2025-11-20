//Defines what the grain can do
using Orleans;
using TaskMatch.Models;

namespace TaskMatch.Grains;

public interface IUserGrain: IGrainWithStringKey
{
  Task Register(string name);
  Task<UserState> GetState();
}