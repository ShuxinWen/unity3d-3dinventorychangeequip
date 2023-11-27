using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;  // 玩家的库存
    [SerializeField] private Transform inventoryUIParent;  // 库存UI的父级对象
    [SerializeField] private Transform helmetAnchor;  // 头盔装备点
    [SerializeField] private Transform leftAnchor;  // 左手装备点
    [SerializeField] private Transform rightAnchor;  // 右手装备点
    [SerializeField] private Transform armorAnchor;  // 盔甲装备点
    private GameObject currentHelmetObj;  // 当前头盔对象
    private GameObject currentLeftHandObj;  // 当前左手对象
    private GameObject currentRightHandObj;  // 当前右手对象
    private GameObject currentArmorObj;  // 当前盔甲对象
    private int playerHealth = 0;

    private void Start()
    {
        inventory.InitInventory(this);  // 初始化玩家库存
        inventory.OpenInventoryUI();  // 打开库存UI
    }

    // 分配生命药水物品给玩家
    public void AssingHealthPotionItem(HealthPotionInventoryItem item)
    {
        inventory.RemoveItem(item, 1);// 消耗物品
        playerHealth += item.GetHealthPoints();//加血
        Debug.Log("玩家现在生命值" + playerHealth);
    }

    // 分配头盔物品给玩家
    public void AssignHelmetItem(HelmetInventoryItem item)
    {
        DestroyIfNotNull(currentHelmetObj);  // 如果当前有头盔对象，则销毁
        currentHelmetObj = CreateNewItemInstance(item, helmetAnchor);  // 创建新的头盔实例并赋值给当前头盔对象
    }

    // 创建新的装备实例
    private GameObject CreateNewItemInstance(InventoryItem item, Transform anchor)
    {
        var itemInstance = Instantiate(item.GetPrefab(), anchor);  // 实例化物品的预制体，并放置在指定的装备点
        itemInstance.transform.localPosition = item.GetLocalPosition();  // 设置物品相对于装备点的本地坐标
        itemInstance.transform.localRotation = item.GetLocalRotation();  // 设置物品相对于装备点的本地旋转
        return itemInstance;  // 返回创建的物品实例
    }

    // 销毁物体，如果不为空
    private void DestroyIfNotNull(GameObject obj)
    {
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    // 分配手部物品给玩家
    public void AssignHandItem(HandInventoryItem item)
    {
        switch (item.hand)
        {
            case Hand.LEFT:
                DestroyIfNotNull(currentLeftHandObj);
                currentLeftHandObj = CreateNewItemInstance(item, leftAnchor);
                break;
            case Hand.RIGHT:
                DestroyIfNotNull(currentRightHandObj);
                currentRightHandObj = CreateNewItemInstance(item, rightAnchor);
                break;
            default:
                break;
        }
    }

    // 分配盔甲物品给玩家
    public void AssignArmorItem(ArmorInventoryItem item)
    {
        DestroyIfNotNull(currentArmorObj);  // 如果当前有盔甲对象，则销毁
        currentArmorObj = CreateNewItemInstance(item, armorAnchor);  // 创建新的盔甲实例并赋值给当前盔甲对象
    }


    // 获取UI父级对象
    public Transform GetUIParent()
    {
        return inventoryUIParent;
    }
}
