using FPFI.DAL;
using FPFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FPFI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            using (var context = new FPFIContext())
            {
                //Najpierw podstawowe

                /*var accountInitial = new List<Account>
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
                accountInitial.ForEach(s => context.Accounts.Add(s));
                context.SaveChanges();

                var mealsInitial = new List<Meal>
                 {

                     new Meal { Name = "Kluski", Nationality = "silesia", Difficulty = "3", Nutriscore = "A", Type = "klyuskowate", TimeConsumption = "2h", AccountID = 3 },
                     new Meal { Name = "Paruwy", Nationality = "golen", Difficulty = "1", Nutriscore = "F", Type = "szypkie", TimeConsumption = "10m", AccountID = 3 },
                     new Meal { Name = "ParuwyParowe", Nationality = "germany", Difficulty = "2", Nutriscore = "E", Type = "parowe", TimeConsumption = "20m", AccountID = 3 },
                     new Meal { Name = "ModroKapusta", Nationality = "silesia", Difficulty = "5", Nutriscore = "C", Type = "slunskie", TimeConsumption = "3h", AccountID = 3 },
                     new Meal { Name = "TortilieKurczak", Nationality = "mexico", Difficulty = "2", Nutriscore = "B", Type = "tortilie", TimeConsumption = "15m", AccountID = 3 },
                 };
                mealsInitial.ForEach(s => context.Meal.Add(s));
                context.SaveChanges();

                var unitsInitial = new List<Unit>
                 {
                     new Unit {Name="Gramy"},
                     new Unit {Name="Mililitr"},
                     new Unit {Name="£y¿eczka"},
                     new Unit {Name="Szczypta"},

                 };
                unitsInitial.ForEach(u => context.Units.Add(u));
                context.SaveChanges();

                var ingredientsInitial = new List<Ingredient>
                 {
                 new Ingredient{Name="PenautButter", Allergen="nuts", Endurance="5", Nutriscore="A", Type="vegetables", UnitID=1},
                 new Ingredient{Name="Broccoli", Endurance="15", Nutriscore="C", Type="vegetables", UnitID=1},
                 new Ingredient{Name="OliveOil", Endurance="5", Nutriscore="E", Type="oils", UnitID=1},
                 new Ingredient{Name="Apple", Endurance="5", Nutriscore="B", Type="fruits", UnitID=1},

                 };
                ingredientsInitial.ForEach(s => context.Ingredients.Add(s));
                context.SaveChanges();



                //Przy nastepnym odpaleniu tabela z relacjami 

                var mealsIngredientsInitial = new List<MealIngredient>
                 {
                 new MealIngredient{MealID=1, IngredientID=3, Quantity= 15},
                 new MealIngredient{MealID=1, IngredientID=4, Quantity= 10},
                 new MealIngredient{MealID=1, IngredientID=1, Quantity= 5},
                 new MealIngredient{MealID=2, IngredientID=4, Quantity= 3},
                 new MealIngredient{MealID=3, IngredientID=2, Quantity= 15},
                 };
                mealsIngredientsInitial.ForEach(s => context.MealIngredients.Add(s));
                context.SaveChanges();*/

            }
        }
    }
    }

    

