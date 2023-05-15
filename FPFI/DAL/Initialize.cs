using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FPFI.Models;


namespace FPFI.DAL
{
    public class FPFIInitializer : DropCreateDatabaseIfModelChanges<FPFIContext>
    {
        protected override void Seed(FPFIContext context)
        {
            var students = new List<Account>
            {
            new Account{Login="Carson",Password="Alexander"},
            new Account{Login="Meredith",Password="Alonso"},
            new Account{Login="Arturo",Password="Anand"},
            new Account{Login="Gytis",Password="Barzdukas"},
            new Account{Login="Yan",Password="Li"},
            new Account{Login="Peggy",Password="Justice"},
            new Account{Login="Laura",Password="Norman"},
            new Account{Login="Nino",Password="Olivetto"}
            };
            students.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges();

            //var ingredients = new List<Ingredient>
            //{
            //new Ingredient{Name="PenautButter", Allergen="nuts", Endurance="5", Nutriscore="A", Type="vegetables", Unit="1"},
            //new Ingredient{Name="Broccoli", Endurance="15", Nutriscore="C", Type="vegetables", Unit="1"},
            //new Ingredient{Name="OliveOil", Endurance="5", Nutriscore="E", Type="oils", Unit=1},
            //new Ingredient{Name="Apple", Endurance="5", Nutriscore="B", Type="fruits", Unit="1"},

            //};
            //ingredients.ForEach(s => context.Ingredients.Add(s));
            //context.SaveChanges();

            var meals = new List<Meal>
            {
            new Meal{Name="Kluski", Nationality="silesia", Difficulty="3", Nutriscore="A", Type="klyuskowate", TimeConsumption="2h"},
            new Meal{Name="Paruwy", Nationality="golen", Difficulty="1", Nutriscore="F", Type="szypkie", TimeConsumption="10m"},
            new Meal{Name="ParuwyParowe", Nationality="germany", Difficulty="2", Nutriscore="E", Type="parowe", TimeConsumption="20m"},
            new Meal{Name="ModroKapusta", Nationality="silesia", Difficulty="5", Nutriscore="C", Type="slunskie", TimeConsumption="3h"},
            new Meal{Name="TortilieKurczak", Nationality="mexico", Difficulty="2", Nutriscore="B", Type="tortilie", TimeConsumption="15m"},
            };
            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();


            var mealsingredients = new List<MealIngredient>
            {
            new MealIngredient{MealID=1, IngredientID=3, Quantity= 15},
            new MealIngredient{MealID=1, IngredientID=4, Quantity= 10},
            new MealIngredient{MealID=1, IngredientID=6, Quantity= 5},
            new MealIngredient{MealID=2, IngredientID=5, Quantity= 3},
            new MealIngredient{MealID=3, IngredientID=6, Quantity= 15},

            };
            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();
        }
    }
}