namespace TheShop.BL.Interfaces.BL
{
    public interface IArticleSellerLogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message);
    }
}