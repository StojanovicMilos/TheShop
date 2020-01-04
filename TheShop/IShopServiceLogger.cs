namespace TheShop
{
    public interface IShopServiceLogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message);
    }
}