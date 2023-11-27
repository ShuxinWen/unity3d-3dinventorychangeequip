using UnityEngine;

public enum Hand
{
    LEFT,  // 左手
    RIGHT  // 右手
}

[CreateAssetMenu(menuName = "ScriptableObjects/库存系统/物品/手部物品")]
public class HandInventoryItem : InventoryItem
{
    public Hand hand;  // 物品所属的手部类型，左手或右手
    
    // 将物品分配给玩家
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)  
    {
        playerEquipment.AssignHandItem(this);
    }
}


