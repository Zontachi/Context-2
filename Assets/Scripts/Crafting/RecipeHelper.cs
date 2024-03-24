using System.Collections.Generic;
using Itemsystem;

namespace Crafting
{
    public static class RecipeHelper
    {
        public static bool CanCraftRecipe(List<ItemData> items, RecipeData recipeData)
        {
            // If the lists are not the same length, they are not equal
            if (items.Count != recipeData.data.Count)
            {
                return false;
            }

            // Create copies of the lists so we can modify them without affecting the original lists
            List<ItemData> copyList1 = new List<ItemData>(items);
            List<ItemData> copyList2 = new List<ItemData>(recipeData.data);

            // For each item in the first list, if it's in the second list, remove it from both lists
            foreach (var item in items)
            {
                if (copyList2.Contains(item))
                {
                    copyList1.Remove(item);
                    copyList2.Remove(item);
                }
            }

            // If both lists are now empty, they were equal
            return copyList1.Count == 0 && copyList2.Count == 0;
        }
    }
}
