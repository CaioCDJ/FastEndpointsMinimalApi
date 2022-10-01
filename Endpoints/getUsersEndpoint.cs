using FastEndpoints;
using Api.repo;
using Api.Models;

namespace Api;

public class getUsersEndPoint : EndpointWithoutRequest<List<User>>{

    public override void Configure()
    {
        Verbs(Http.GET);

        Routes("/user");

        AllowAnonymous();

    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        Response = await userRepo.getAll();

        await SendAsync(Response,cancellation:ct);
    }
}