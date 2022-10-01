using FastEndpoints;
using Api.repo;
using Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api;

public class updateUsersEndPoint : EndpointWithoutRequest<User>{

    public override void Configure()
    {
        Verbs(Http.PUT);

        Routes("/user/{id}");

        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);

    }
    public override async Task HandleAsync(CancellationToken ct)
    {

        await SendAsync(Response,cancellation:ct);
    }
}