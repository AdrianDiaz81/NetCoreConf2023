using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using GrpcAvenger;

namespace Avengers.Controllers;

[ApiController]
[Route("api/[controller]")]

public class gRPCController : ControllerBase
{


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {

        using var channel = GrpcChannel.ForAddress("https://localhost:7297");
        var client = new Avenger.AvengerClient(channel);
        var empty = new Google.Protobuf.WellKnownTypes.Empty();
        var reply = await client.GetAllAsync(empty);

        return Ok(reply);
    }

    [HttpGet("{id}", Name = "GetByIDAvenger")]
    public async Task<IActionResult> Get(int id)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:7297");
        var client = new Avenger.AvengerClient(channel);
        var empty = new Google.Protobuf.WellKnownTypes.Empty();
        IdAvenger idAvenger = new() { Name= id.ToString() };
        var reply = await client.GetAsync(idAvenger);

        return Ok(reply);


    }
}