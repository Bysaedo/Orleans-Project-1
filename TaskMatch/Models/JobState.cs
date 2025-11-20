//Data container for everything that belongs to a specific job in the app.
using Orleans;

namespace TaskMatch.Models; //Puts JobState inside the models folder.

[GenerateSerializer]
public class JobState
{
  [Id(0)]
  public string Id { get; set; } = "";

  [Id(1)]
  public string Title { get; set; } = "";

  [Id(2)]
  public string Description { get; set; } = "";

  [Id(3)]
  public string HelperId { get; set; } = "";

  [Id(4)]
  public string Status { get; set; } = "";
}

