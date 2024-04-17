using CompanionCove.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CompanionCove.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser AgentUser {  get; set; }
        public ApplicationUser GuestUser {  get; set; }
        public Agent Agent { get; set; }
        public Models.Type DogType { get;set; }
        public Models.Type CatType { get; set; } 
        public Models.Type BirdType { get; set; }
        public Models.Type ExoticType { get; set; }
        public Animal FirstAnimal { get; set; }
        public Animal SecondAnimal { get; set; }
        public Animal ThirdAnimal { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedTypes();
            SeedAnimals();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };
            AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent123");

            GuestUser =new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(AgentUser, "guest123");

        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }

        private void SeedTypes()
        {
            DogType = new Models.Type()
            {
                Id = 1,
                Name = "Dog"
            };
            CatType = new Models.Type()
            {
                Id = 2,
                Name = "Cat"
            };
            BirdType = new Models.Type()
            {
                Id = 3,
                Name = "Bird"
            };
            ExoticType = new Models.Type()
            {
                Id = 4,
                Name = "Exotic"
            };

        }
        private void SeedAnimals()
        {
            FirstAnimal = new Animal()
            {
                Id = 1,
                Name = "Katy",
                Address = "North London, UK (near the border)",
                Description = "Cute and loving female cat. 2 years old. Sleeps all day long so dont worry!",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSthKCywFxFjV-2LHpE0xXIIBvgWyGRoQ1_fA&usqp=CAU",
                TypeId = CatType.Id,
                AgentId = Agent.Id,
                GuardianId = GuestUser.Id
            };
            SecondAnimal = new Animal()
            {
                Id = 2,
                Name = "Grisho",
                Address = "Bulgaria, Sofia, Lozenec neighborhood",
                Description = "Playful 4 years old male dog, he will alwaays acompany you when you have to go somewhere!",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_5ElLfEoTtQIyOm38WiEMesfB6mUaP8Dl6g&usqp=CAU",
                TypeId = DogType.Id,
                AgentId = Agent.Id,        
            };
            ThirdAnimal = new Animal()
            {
                Id = 3,
                Name = "Skizy",
                Address = "Bulgaria, Pazardzhik, Mladost neighborhood",
                Description = "A very friendly female snake. 1 year old. Will keep you warm at night!",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfeW8OwQhInDF9G4f-eOFGfISWdUsy0ZaUsw&usqp=CAU",
                TypeId = ExoticType.Id,
                AgentId = Agent.Id,           
            };
        }
    }
}
