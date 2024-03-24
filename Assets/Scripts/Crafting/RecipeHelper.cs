using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Crafting
{
    public static class RecipeHelper
    {
        public static bool CanCraftRecipe(List<ItemData> items, RecipeData recipeData)
        {
            return recipeData.data.Contains(items[0]) && recipeData.data.Contains(items[1]) && recipeData.data.Contains(items[2]);
        }
    }
}
