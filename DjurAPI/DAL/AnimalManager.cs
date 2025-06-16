using DjurAPI.Models;

namespace DjurAPI.DAL
{
    public class AnimalManager
    {
        private static int dbSpeed = 1000;

        public static async Task<List<Models.Animal>> GetAllAnimals()
        {
            if (DB.Animals.Any() == false)
            {
                DB.Animals.AddRange(new List<Models.Animal>
               {
                    new Animal {
                    Id = 1,
                    Species = "Cat",
                    Weight = 4.5,
                    IsFlying = false},

                    new Animal {
                    Id = 2,
                    Species = "Fish",
                    Weight = 2.5,
                    IsFlying = false
                    },

                    new Animal
                    {
                    Id = 3,
                    Species = "Bird",
                    Weight = 1.2,
                    IsFlying = true
                    }
               });
            }
            await Task.Delay(dbSpeed);
            return DB.Animals;
        }

        public static async Task<Models.Animal> GetAnimalById(int id)
        {
            await Task.Delay(dbSpeed);
            return DB.Animals.Where(a => a.Id == id).SingleOrDefault();
        }

        public static async Task UpdateAnimal(int id, Models.Animal animal)
        {
            await Task.Delay(dbSpeed);
            var existingAnimal = DB.Animals.Where(a => a.Id == id).SingleOrDefault();
            if (existingAnimal != null)
            {
                existingAnimal.Species = animal.Species;
                existingAnimal.Weight = animal.Weight;
                existingAnimal.IsFlying = animal.IsFlying;
            }
        }

        public static async Task CreateAnimal(Models.Animal animal)
        {
            if (DB.Animals == null)
                DB.Animals = new List<Models.Animal>();

            animal.Id = DB.Animals.Any() ? DB.Animals.Max(e => e.Id) + 1 : 1;
            DB.Animals.Add(animal);

            await Task.Delay(dbSpeed);
        }

        public static async Task DeleteAnimal(int id)
        {
            await Task.Delay(dbSpeed);
            var animalToDelete = DB.Animals.Where(a => a.Id == id).SingleOrDefault();
            DB.Animals.Remove(animalToDelete);
        }
    }
}
