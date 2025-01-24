using TMPro;

namespace CodeBase.UI.Windows
{
  public class ShopWindow : WindowBase
  {
    public TextMeshProUGUI SkullText;

    protected override void Init() => 
      RefreshSkullTextText();

    protected override void SubscribeUpdates() => 
      Progress.WorldData.LootData.Changed += SubscribeUpdates;

    protected override void Cleanup()
    {
      base.Cleanup();
      Progress.WorldData.LootData.Changed -= SubscribeUpdates;
    }

    private string RefreshSkullTextText() => 
      SkullText.text = Progress.WorldData.LootData.Collected.ToString();
  }
}