using FastEndpoints;
using Api.repo;
using Api.data;
using Api.Models;

namespace Api;

public class getUsersEndPoint : EndpointWithoutRequest<List<User>>{

    private readonly AppDbContext _context;
    private readonly userRepo _userRepo;

    public getUsersEndPoint(){
      _userRepo = new userRepo(_context);
    }

    public override void Configure()
    {
        Verbs(Http.GET);

        Routes("/user");

        AllowAnonymous();

    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        Response = await _userRepo.getAll();

        await SendAsync(Response,cancellation:ct);
    }
}
