using System.Collections.Generic;

static class ItemCategoryManager
{
    private static readonly int knownCategoriesCount;
    private static readonly int itemsPerCategoryCount;

    static ItemCategoryManager()
    {
        knownCategoriesCount = 3;
        itemsPerCategoryCount = 100;
    }

    public static ItemCategory GetItemCategory(Item item)
    {
        int categoryId = (int)item / itemsPerCategoryCount;

        if (categoryId < knownCategoriesCount)
        {
            return (ItemCategory)categoryId;
        }

        return ItemCategory.Unknown;
    }

    public static List<Item> GetAllItemsInCategory(ItemCategory category)
    {
        List<Item> categoryItems = new List<Item>();

        int firstCategoryItemId = (int)category * itemsPerCategoryCount;

        for (int itemInd = firstCategoryItemId; itemInd < firstCategoryItemId + itemsPerCategoryCount; itemInd++)
        {
            Item item = (Item)itemInd;

            if (!item.HasFlag(item))
            {
                break;
            }

            categoryItems.Add(item);
        }

        return categoryItems;
    }

    public static Item GetDefaultItemInCategory(ItemCategory category)
    {
        int defaultCategoryItemId = (int)category * itemsPerCategoryCount;
        return (Item)defaultCategoryItemId;
    }

    public static int GetNumberOfItemInCategory(Item item)
    {
        int itemId = (int)item;

        if (itemId / itemsPerCategoryCount < knownCategoriesCount)
        {
            return itemId % itemsPerCategoryCount;
        }

        return -1;
    }
}
