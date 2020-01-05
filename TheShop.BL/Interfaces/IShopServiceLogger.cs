namespace TheShop.BL.Interfaces
{
    public interface IShopServiceLogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message);
    }
}