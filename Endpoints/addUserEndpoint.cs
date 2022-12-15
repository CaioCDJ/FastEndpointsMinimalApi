using Api.Models;
using FastEndpoints;
using Api.repo;
using Api.data;

namespace Api;

public class addUserEndPoint : Endpoint<UserRequest>{

    private readonly AppDbContext _context;
    private readonly userRepo _userRepo;

    public addUserEndPoint(){
      _userRepo = new userRepo(_context);
    }

    public override void Configure()
    {
        Verbs(Http.POST);

        Post("/user");

        AllowAnonymous();
    }


    public override async Task HandleAsync(UserRequest req,CancellationToken ct) {
        
        await _userRepo.add(req);

        await SendAsync("conta criada com sucesso");
    }
}
