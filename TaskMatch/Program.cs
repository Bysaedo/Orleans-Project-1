using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskMatch.Grains;
using Orleans;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add Orleans
builder.Host.UseOrleans(silo =>
{
    silo.UseLocalhostClustering();
    silo.AddMemoryGrainStorage("memoryStore");
});

var app = builder.Build();

// USER ENDPOINTS
app.MapGet("/users/{id}/register", async (string id, string name, IGrainFactory grains) =>
{
    var grain = grains.GetGrain<IUserGrain>(id);
    await grain.Register(name);
    return Results.Ok(await grain.GetState());
});

// JOB ENDPOINTS
app.MapGet("/jobs/{id}/create", async (string id, string title, string description, IGrainFactory grains) =>
{
    var grain = grains.GetGrain<IJobGrain>(id);
    await grain.Create(title, description);
    return Results.Ok(await grain.GetState());
});

app.MapGet("/jobs/{id}/assign/{helperId}", async (string id, string helperId, IGrainFactory grains) =>
{
    var grain = grains.GetGrain<IJobGrain>(id);
    await grain.AssignHelper(helperId);
    return Results.Ok(await grain.GetState());
});

app.MapGet("/jobs/{id}/status", async (string id, string status, IGrainFactory grains) =>
{
    var grain = grains.GetGrain<IJobGrain>(id);
    await grain.UpdateStatus(status);
    return Results.Ok(await grain.GetState());
});

app.MapGet("/jobs/{id}/get", async (string id, IGrainFactory grains) =>
{
    var grain = grains.GetGrain<IJobGrain>(id);
    return Results.Ok(await grain.GetState());
});

app.Run();