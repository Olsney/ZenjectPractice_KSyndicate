using CodeBase.Services;

namespace CodeBase.UI.Services.Factory
{
  public interface IUIFactory: IService
  {
    void CreateShop();
    void CreateUIRoot();
  }
}