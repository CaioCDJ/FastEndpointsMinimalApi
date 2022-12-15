using FastEndpoints;
using Api.repo;
using Api.Models;
using Api.data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api;

public class updateUsersEndPoint : EndpointWithoutRequest<User>{

    private readonly AppDbContext _context;
    private readonly userRepo _userRepo;

    public updateUsersEndPoint(){
      _userRepo = new userRepo(_context);
    }

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
