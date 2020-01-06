namespace TheShop.BL.Interfaces
{
    public interface IArticleSellerLogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message);
    }
}