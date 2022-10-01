using Api.Models;
using FastEndpoints;
using Api.repo;
namespace Api;

public class addUserEndPoint : Endpoint<UserRequest>{

    public override void Configure()
    {
        Verbs(Http.POST);

        Post("/user");

        AllowAnonymous();

    }
    public override async Task HandleAsync(UserRequest req,CancellationToken ct) {
        
        await userRepo.add(req);

        await SendAsync("conta criada com sucesso");
    }
}