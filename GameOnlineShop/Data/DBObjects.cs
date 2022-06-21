using GameShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data
{
    public class DBObjects
    {
        public static void Initialize(AppDBContent content)
        {

            if (!content.DbCategory.Any())
                content.DbCategory.AddRange(DictCategories.Select(c => c.Value)); // if DbCategory is empty, initialize list of categories automatically

            if (!content.DbGame.Any()) // if DbGame is empty, initialize list of items automatically
            {
                content.AddRange(
                    new Game
                    {
                        Image = "/img/css.jpg",
                        Name = "Война и мир",
                        Desc = "Counter-Strike (CS) is a series of multiplayer first-person shooter video games in which " +
                                                     "teams of terrorists battle to perpetrate an act of terror (bombing, hostage-taking, assassination) " +
                                                     "while counter-terrorists try to prevent it (bomb defusal, hostage rescue, escort mission).",
                        Details = "",
                        IsAvailable = true,
                        Quantity = 15,
                        Price = 300,
                        Category = DictCategories["Action"]
                    },
                    new Game
                    {
                        Image = "/img/cof.jpg",
                        Name = "Cry of Fear",
                        Desc = "Cry of Fear is a psychological single-player and co-op horror game set in a deserted town filled with " +
                                                                                        "horrific creatures and nightmarish delusions.",
                        Details = "",
                        IsAvailable = true,
                        Quantity = 20,
                        Price = 100,
                        Category = DictCategories["Horror"]
                    },
                    new Game
                    {
                        Image = "/img/ylad.jpg",
                        Name = "Yakuza: Like a Dragon",
                        Desc = "Yakuza: Like a Dragon is a role-playing video game (RPG) developed and published by Sega. " +
                                "The first mainline title in the Yakuza franchise developed as a turn-based RPG, " +
                                "it was released in Japan and Asia for PlayStation 4 on January 16, 2020.",
                        Details = "",
                        IsAvailable = true,
                        Quantity = 10,
                        Price = 800,
                        Category = DictCategories["JRPG"]
                    },
                    new Game
                    {
                        Image = "/img/va11halla.jpg",
                        Name = "Va-11 Hall-a",
                        Desc = "The game puts the player in the role of a bartender at the eponymous VA-11 HALL-A, a small bar in a dystopian " +
                                "downtown which is said to attract the most fascinating of people. Gameplay consists of players making and " +
                                "serving drinks to bar attendees whilst listening to their stories and experiences.",
                        Details = "",
                        IsAvailable = false,
                        Quantity = 0,
                        Price = 200,
                        Category = DictCategories["Quest"]
                    },
                    new Game
                    {
                        Image = "/img/os.jpg",
                        Name = "One Shot",
                        Desc = "OneShot is a surreal top down Puzzle/Adventure game with unique gameplay capabilities, " +
                                "You are to guide a child through a mysterious world on a mission to restore its long-dead sun,",
                        Details = "",
                        IsAvailable = true,
                        Quantity = 7,
                        Price = 50,
                        Category = DictCategories["Quest"]
                    });
            }

            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> DictCategories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Action", CategoryDesc = "Action games are just that—games where the player is in control of and " +
                                            "at the center of the action, which is mainly comprised of physical challenges players must overcome." },
                        new Category { CategoryName = "Horror", CategoryDesc = "A horror game is a video game genre centered on horror fiction " +
                                                                                   "and typically designed to scare the player" },
                        new Category { CategoryName = "JRPG", CategoryDesc = "Japanese role-playing games (abbrev.: JRPG) are traditional " +
                                                                               "and live-action role-playing games written and published in Japan." },
                        new Category { CategoryName = "RPG", CategoryDesc = "A role-playing game (RPG) is a type of game in which players assume " +
                                                                               "the roles of characters and collaboratively create stories." },
                        new Category { CategoryName = "Quest", CategoryDesc = "A quest, or mission, is a task in video games that a " +
                                           "player-controlled character, party, or group of characters may complete in order to gain a reward." }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category c in list)
                        category.Add(c.CategoryName, c);
                }

                return category;
            }
        }
    }
}
