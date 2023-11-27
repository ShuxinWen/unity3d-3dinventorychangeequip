using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/库存系统/库存")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();  // 存储物品及其数量的列表
    [SerializeField] private InventoryUI inventoryUIPrefab;

    private InventoryUI _inventoryUI;  // 与此库存相关联的UI

    private InventoryUI inventoryUI
    {
        get
        {
            if (!_inventoryUI)
            {
                _inventoryUI = Instantiate(inventoryUIPrefab, playerEquipment.GetUIParent());
            }
            return _inventoryUI;
        }

    }

    private Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();  // 将物品映射到数量的字典

    private PlayerEquipmentController playerEquipment;

    // 初始化库存，将物品及其数量添加到映射中
    public void InitInventory(PlayerEquipmentController playerEquipment)
    {
        this.playerEquipment = playerEquipment;
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
        }
    }

    public void OpenInventoryUI()
    {
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.InitInventoryUI(this);
    }

    // 分配物品给玩家
    public void AssignItem(InventoryItem item)
    {
        // Debug.Log("点击了物品：" + item.GetName());

        //将物品分配给玩家
        item.AssignItemToPlayer(playerEquipment);
    }

    // 返回所有物品及其数量的映射
    public Dictionary<InventoryItem, int> GetAllItemsMap()
    {
        return itemToCountMap;
    }

    // 添加物品到库存中，并更新UI
    public void AddItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount + count;
        }
        else
        {
            itemToCountMap.Add(item, count);
        }
        inventoryUI.CreateOrUpdateSlot(this, item, count);
    }

    // 从库存中移除物品，并更新UI
    public void RemoveItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount - count;
            if (currentItemCount - count <= 0)
            {
                inventoryUI.DestroySlot(item);
            }
            else
            {
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }
        else
        {
            Debug.Log("Can't remove item");
        }
    }
}
