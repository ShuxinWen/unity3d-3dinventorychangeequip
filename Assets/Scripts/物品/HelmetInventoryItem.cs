using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/库存系统/物品/头盔")]
public class HelmetInventoryItem : InventoryItem  // 头盔物品类，继承自InventoryItem
{
	// 分配头盔物品给玩家
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)  
    {
        playerEquipment.AssignHelmetItem(this);
    }
}
