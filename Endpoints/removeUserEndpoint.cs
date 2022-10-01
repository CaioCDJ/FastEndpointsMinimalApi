using Api.Models;
using FastEndpoints;
using Api.repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api;

public class removeUserEndPoint : Endpoint<idRequest>{

    public override void Configure()
    {
        Verbs(Http.DELETE);

        Delete("/user/{id}");

        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }
    public override async Task HandleAsync(idRequest req,CancellationToken ct)
    {
        await userRepo.remove(req.id);

        await SendAsync(new{
            message="Usuario Deletado com sucesso"
        },cancellation:ct);
    }
}