using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/库存系统/物品/护甲")]
public class ArmorInventoryItem : InventoryItem
{
    // 将物品分配给玩家
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignArmorItem(this);
    }
}


