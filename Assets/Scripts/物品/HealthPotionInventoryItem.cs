using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/库存系统/物品/生命药水")]
public class HealthPotionInventoryItem : InventoryItem
{
    [SerializeField] private int healthPoints;  // 生命药水的恢复生命值

    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssingHealthPotionItem(this);
    }

    public int GetHealthPoints()  // 获取生命药水的恢复生命值
    {
        return healthPoints;
    }
}
