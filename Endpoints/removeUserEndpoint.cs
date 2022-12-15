using Api.Models;
using FastEndpoints;
using Api.repo;
using Api.data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api;

public class removeUserEndPoint : Endpoint<idRequest>{

    private readonly AppDbContext _context;
    private readonly userRepo _userRepo;

    public removeUserEndPoint(){
      _userRepo = new userRepo(_context);
    }

    public override void Configure()
    {
        Verbs(Http.DELETE);

        Delete("/user/{id}");

        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }
    public override async Task HandleAsync(idRequest req,CancellationToken ct)
    {
        await _userRepo.remove(req.id);

        await SendAsync(new{
            message="Usuario Deletado com sucesso"
        },cancellation:ct);
    }
}
