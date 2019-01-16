namespace Dau.Services.Email
{
    public interface IMessageQueueService
    {
        void QueueVerificationEmail(string verificationToken, string UserFullName, string ToAddress);
    }
}