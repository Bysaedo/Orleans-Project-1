/*Represents the data stored inside UserGrain
Serializer: System that Convert C# objects into bytes and vice versa 
Orleans needs serializers because it moves and stores objects constantly
*/
using Orleans;

namespace TaskMatch.Models;

[GenerateSerializer]  //Generates an optimized serializer for this class. Without this, Orleans cannot store or send the object.
public class UserState
{
  [Id(0)] //Identifies fields in Orleans serialization system.
  public string Id { get; set; } = "";

  [Id(1)]
  public string Name { get; set; } = "";
}
