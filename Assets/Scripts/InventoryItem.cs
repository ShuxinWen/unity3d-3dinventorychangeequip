using UnityEngine;

public abstract class InventoryItem : ScriptableObject
{
    [SerializeField] private GameObject itemPrefab;  // 存储物品的预制体
    [SerializeField] private Sprite itemSprite;      // 存储物品的精灵
    [SerializeField] private string itemName;        // 存储物品的名称
    [SerializeField] private Vector3 itemLocalPosition;  // 存储物品的局部位置
    [SerializeField] private Vector3 itemLocalRotation;  // 存储物品的局部旋转

    // 返回存储的物品精灵
    public Sprite GetSprite()
    {
        return itemSprite;
    }

    // 返回存储的物品名称
    public string GetName()
    {
        return itemName;
    }

    // 返回存储的物品预制体
    public GameObject GetPrefab()
    {
        return itemPrefab;
    }

    // 返回存储的物品局部位置
    public Vector3 GetLocalPosition()
    {
        return itemLocalPosition;
    }

    // 返回存储的物品局部旋转（以四元数表示）
    public Quaternion GetLocalRotation()
    {
        return Quaternion.Euler(itemLocalRotation);
    }

    public abstract void AssignItemToPlayer(PlayerEquipmentController playerEquipment);
}
