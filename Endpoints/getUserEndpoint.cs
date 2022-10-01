using FastEndpoints;
using Api.Models;
using Api.repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api;

public class getUserEndPoint : Endpoint<idRequest>{

    public override void Configure()
    {
        Verbs(Http.GET);

        Routes("/user/{id}");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }
    public override async Task HandleAsync(idRequest request,CancellationToken ct)
    {

        User user = await userRepo.getById(request.id);
        
        if(user is not null)
            await SendAsync(user,cancellation:ct);
        
        else 
            await SendNotFoundAsync();
    }
}