using Api.Models;
using Api.data;
using Microsoft.EntityFrameworkCore;

namespace Api.repo;

public class userRepo{

    private readonly AppDbContext context;

    public userRepo(AppDbContext context){
      this.context = context;
    }

    public async Task <List<User>> getAll()
      => await context.users.ToListAsync();

    public async Task<User> verifyIfExists(LoginRequest login)
        => await context.users.FirstAsync(
            x => x.email == login.email && x.password == login.password);

    public async Task<User> getById(Guid id) 
        => await context.users.FirstOrDefaultAsync(x => x.id == id);
    
    public async Task add(UserRequest req){

        await context.users.AddAsync(new User(){
            id = Guid.NewGuid(),
            email = req.email,
            password = req.password,
            name = req.name
        });

        await context.SaveChangesAsync();
    }
    
    public async Task upadate(User user){

        context.users.Update(user);

        await context.SaveChangesAsync();

    }

    public async Task remove(Guid id){

        User user = await getById(id);

        context.Remove(user);
    
        await context.SaveChangesAsync();
    }    
}
