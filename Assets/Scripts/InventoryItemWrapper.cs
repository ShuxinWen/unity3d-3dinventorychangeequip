using UnityEngine;

// 使用[System.Serializable]属性将该类标记为可序列化，以便在Unity编辑器中进行序列化
[System.Serializable]
public class InventoryItemWrapper
{
    [SerializeField] private InventoryItem item;  // 存储物品信息的对象
    [SerializeField] private int count;           // 存储物品数量

    // 返回存储的物品信息
    public InventoryItem GetItem()
    {
        return item;
    }

    // 返回存储的物品数量
    public int GetItemCount()
    {
        return count;
    }
}
