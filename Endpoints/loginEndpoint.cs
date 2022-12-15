using Api.Models;
using Api.repo;
using FastEndpoints;
using FastEndpoints.Security;
using Api.data;

namespace Api;

public class LoginEndPoint : Endpoint<LoginRequest>{

    private readonly AppDbContext _context;
    private readonly userRepo _userRepo;

    public LoginEndPoint(){
      _userRepo = new userRepo(_context);
    }

    public override void Configure()
    {
        Verbs(Http.GET);

        Get("/login");

        AllowAnonymous();

    }

    public override async Task HandleAsync(LoginRequest req,CancellationToken ct){

        User user = await _userRepo.verifyIfExists(req);

        if(user is null){
            await SendNotFoundAsync();
        }
        
         var jwtToken = JWTBearer.CreateToken(
                signingKey: "123456789abcdefgh",
                expireAt: DateTime.UtcNow.AddDays(1),
                claims: new[] { ("Username", user.name), ("UserID", user.id.ToString()) },
                roles: new[] { "Admin" },
                permissions: new[] { "authenticated" });
 
        await SendAsync(new {
            user,
            jwtToken
        },cancellation:ct);
    }
}
