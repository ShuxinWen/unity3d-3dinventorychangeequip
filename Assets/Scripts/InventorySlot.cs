using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;  // 物品图像
    [SerializeField] private TextMeshProUGUI itemNameText;  // 物品名称文本
    [SerializeField] private TextMeshProUGUI itemCountText;  // 物品数量文本
    [SerializeField] private Button slotButton;  // 插槽按钮

    // 初始化插槽的可视化表示
    public void InitSlotVisualisation(Sprite itemSprite, string itemName, int itemCount)
    {
        itemImage.sprite = itemSprite;
        itemNameText.text = itemName;
        UpdateSlotCount(itemCount);
    }

    // 更新插槽中物品的数量显示
    public void UpdateSlotCount(int itemCount)
    {
        itemCountText.text = itemCount.ToString();
    }

    // 分配插槽按钮的回调函数
    public void AssignSlotButtonCallback(System.Action onClickCallback)
    {
        slotButton.onClick.AddListener(() => onClickCallback());
    }
}
