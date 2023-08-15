
using LAIT.Common;
using LAIT.Generic_Integration;
using LAIT.Generic_Integration.Entities;
using LAIT.Service;


class Program
{
    static async Task Main(string[] args)
    {

        //Demonstration of how a generic approach would work
        IRepository<UserEntity> user_repo = new Repository<UserEntity>("users");
        var user_response = await user_repo.Get("5");
        if (user_response is not null)
        {
            Console.WriteLine($"Getting user by ID! (Generic Integration Code) \n");
            Console.WriteLine($"ID: {user_response.ID}");
            Console.WriteLine($"Name: {user_response.FirstName} {user_response.LastName}");
            Console.WriteLine($"email: {user_response.Email}");
            Console.WriteLine("------------------------------------------- \n");
        }

        IRepository<PaintEntity> paint_repo = new Repository<PaintEntity>("paints");
        var paint_response = await paint_repo.Get("5");
        if (paint_response is not null)
        {
            Console.WriteLine($"Getting paint by ID! (Generic Integration Code) \n");
            Console.WriteLine($"ID: {paint_response.ID}");
            Console.WriteLine($"Color Name: {paint_response.Name}");
            Console.WriteLine($"Color: {paint_response.Color}");
            Console.WriteLine("------------------------------------------- \n");
        }


        Console.WriteLine("------------------------------------------- \n");
        Console.WriteLine("------------------------------------------- \n"); 




        //Demonstration of how a more structured approach would work
        UserService service = new();

        var user1 = await service.GetUserAsync("1");
        if (user1 is not null)
        {
            Console.WriteLine($"Getting user by ID! (Structured Integration Code)\n");
            Console.WriteLine($"ID: {user1.ID}");
            Console.WriteLine($"Name: {user1.FirstName} {user1.LastName}");
            Console.WriteLine($"email: {user1.Email}");
            Console.WriteLine("------------------------------------------- \n");
        }

        var user2 = await service.GetUserAsync("2");
        if (user2 is not null)
        {
            Console.WriteLine($"Getting user by ID! (Structured Integration Code) \n");
            Console.WriteLine($"ID: {user2.ID}");
            Console.WriteLine($"Name: {user2.FirstName} {user2.LastName}");
            Console.WriteLine($"email: {user2.Email}");
            Console.WriteLine("------------------------------------------- \n");
        }

        var list = await service.GetAllUsersAsync(12);
        if (list is not null)
        {
            Console.WriteLine($"Getting all users! (Structured Integration Code) \n");
            Console.WriteLine($"List size: {list.Count}");
            foreach (var user in list)
            {
                Console.WriteLine($" User ID {user.ID}   | email: {user.Email}");
            }
            Console.WriteLine("------------------------------------------- \n");
        }


        UserDTO new_user = new()
        {
            ID = "13",
            Email = "john@test.com",
            FirstName = "John",
            LastName = "Doe",
        };


        var status1 = await service.CreateUserAsync(new_user);
        if (status1 is not null)
        {
            Console.WriteLine($"Creating a new user! (Structured Integration Code) \n");
            Console.WriteLine($"User was created | Status Message {status1} \n");
            Console.WriteLine("------------------------------------------- \n");
        }


        string id = "13";
        var status2 = await service.DeleteUserAsync(id);
        if (status2 is not null)
        {
            Console.WriteLine($"Deleting user with id: {id}! (Structured Integration Code) \n");
            Console.WriteLine($"User was deleted | Status Message {status2} \n");
            Console.WriteLine("------------------------------------------- \n");
        }

        Console.Read();
    }
}






