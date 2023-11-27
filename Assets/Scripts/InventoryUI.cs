using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotsParent;  // 插槽的父级对象
    [SerializeField] private InventorySlot slotPrefab;  // 插槽的预制体
    private Dictionary<InventoryItem, InventorySlot> itemToSlotMap = new Dictionary<InventoryItem, InventorySlot>();  // 将物品映射到插槽的字典

    // 初始化库存UI
    public void InitInventoryUI(Inventory inventory)
    {
        var itemsMap = inventory.GetAllItemsMap();
        foreach (var kvp in itemsMap)
        {
            CreateOrUpdateSlot(inventory, kvp.Key, kvp.Value);
        }
    }

    // 创建或更新物品插槽
    public void CreateOrUpdateSlot(Inventory inventory, InventoryItem item, int itemCount)
    {
        if (!itemToSlotMap.ContainsKey(item))
        {
            var slot = CreateSlot(inventory, item, itemCount);
            itemToSlotMap.Add(item, slot);
        }
        else
        {
            UpdateSlot(item, itemCount);
        }
    }

    // 更新已存在的物品插槽
    public void UpdateSlot(InventoryItem item, int itemCount)
    {
        itemToSlotMap[item].UpdateSlotCount(itemCount);
    }

    // 创建物品插槽
    private InventorySlot CreateSlot(Inventory inventory, InventoryItem item, int itemCount)
    {
        var slot = Instantiate(slotPrefab, slotsParent);
        slot.InitSlotVisualisation(item.GetSprite(), item.GetName(), itemCount);
        slot.AssignSlotButtonCallback(() => inventory.AssignItem(item));
        return slot;
    }

    // 销毁物品插槽
    public void DestroySlot(InventoryItem item)
    {
        Destroy(itemToSlotMap[item].gameObject);
        itemToSlotMap.Remove(item);
    }
}
