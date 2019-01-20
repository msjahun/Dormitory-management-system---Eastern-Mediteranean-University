using System.Collections.Generic;

namespace Dau.Services.Email
{
    public interface IEmailAccountService
    {
        long AddNewEmail(EmailAccountCrud vm);
        bool DeleteEmailAccount(EmailAccountCrud vm);
        EmailAccountCrud GetEmailAccountById(long EmailAccountId);
        bool SetEmailAccountToDefault(long EmailAccountId);
        bool UpdateEmailAccount(EmailAccountCrud vm);
        bool UpdateEmailAccountPassword(EmailAccountCrud vm);
        List<EmailAccountsTable> GetEmailAccountsTableList();
    }
}