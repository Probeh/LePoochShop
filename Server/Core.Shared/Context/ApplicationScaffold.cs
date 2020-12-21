using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Enums;
using Core.Shared.Models.Identity;
using Newtonsoft.Json;

namespace Core.Shared.Context
{
    public static class DataScaffold
    {
        public static void Initialize(ApplicationContext context, UserManager<User> manager)
        {
            context.Database.EnsureCreated();

            SetBreeds(context);
            SetMembers(context, manager);
            SetAppointments(context);
        }
        private static async void SetBreeds(ApplicationContext context)
        {
            if (!(await context.Set<BreedModel>().AnyAsync()))
            {
                var stream = await File.ReadAllTextAsync("../Core.Shared/Context/Breeds.json");
                JsonConvert
                    .DeserializeObject<List<BreedModel>>(stream)
                    .ForEach((BreedModel breed) => context.Set<BreedModel>().Add(breed));
            }
            await context.SaveChangesAsync();
        }

        private static async void SetMembers(ApplicationContext context, UserManager<User> manager)
        {
            if (!(await manager.Users.AnyAsync()))
            {
                var stream = await File.ReadAllTextAsync("../Core.Shared/Context/Members.json");
                JsonConvert
                    .DeserializeObject<List<MemberModel>>(stream)
                    .ForEach(async (MemberModel member) =>
                        await manager.CreateAsync(new User
                        {
                            UserName = member.UserName,
                            Email = member.Email,
                            Member = new MemberModel
                            {
                                Age = member.Age,
                                FirstName = member.FirstName,
                                Details = member.Details,
                                Email = member.Email,
                                Gender = member.Gender,
                                IsActive = member.IsActive,
                                LastName = member.LastName,
                                Picture = member.Picture,
                                Title = $"{member.FirstName} {member.LastName}",
                                UserName = member.UserName,
                                Pooch = new PoochModel
                                {
                                    Age = new Random().Next(15),
                                    BreedId = new Random().Next(1, 116),
                                    Gender = Enum.GetNames(typeof(Genders)) [new Random().Next(2)],
                                    Title = DogNames[new Random().Next(DogNames.Length)],
                                    IsActive = member.IsActive,
                                    Details = member.Details
                                }
                            }
                        }, "Password")
                    );
            }
        }

        private static async void SetAppointments(ApplicationContext context)
        {
            if (!(await context.Set<AppointmentModel>().AnyAsync()))
            {

            }
        }

        private static string[] DogNames => new string[] { "Ace", "Apollo", "Bailey", "Bandit", "Baxter", "Bear", "Beau", "Benji", "Benny", "Bentley", "Blue", "Bo", "Boomer", "Brady", "Brody", "Bruno", "Brutus", "Bubba", "Buddy", "Buster", "Cash", "Champ", "Chance", "Charlie", "Chase", "Chester", "Chico", "Coco", "Cody", "Cooper", "Copper", "Dexter", "Diesel", "Duke", "Elvis", "Finn", "Frankie", "George", "Gizmo", "Gunner", "Gus", "Hank", "Harley", "Henry", "Hunter", "Jack", "Jackson", "Jake", "Jasper", "Jax", "Joey", "Kobe", "Leo", "Loki", "Louie", "Lucky", "Luke", "Mac", "Marley", "Max", "Mickey", "Milo", "Moose", "Murphy", "Oliver", "Ollie", "Oreo", "Oscar", "Otis", "Peanut", "Prince", "Rex", "Riley", "Rocco", "Rocky", "Romeo", "Roscoe", "Rudy", "Rufus", "Rusty", "Sam", "Sammy", "Samson", "Scooter", "Scout", "Shadow", "Simba", "Sparky", "Spike", "Tank", "Teddy", "Thor", "Toby", "Tucker", "Tyson", "Vader", "Winston", "Yoda", "Zeus", "Ziggy" };
    }
}