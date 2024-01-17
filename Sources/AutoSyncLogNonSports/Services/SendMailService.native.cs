using Fanex.MailDeliver.MailClient.Model;

namespace AutoSyncLogNonSports.Services;

public interface SendMailService
{
    void SendMail(string message);
}

public class SendMailServiceImp : SendMailService
{
    private readonly AppSettingsKey appSettingsKey;

    public SendMailServiceImp(IOptions<AppSettingsKey> appSettingsKey)
    {
        this.appSettingsKey = appSettingsKey.Value;
    }

    public void SendMail(string message)
    {
        var mailRecord = new MailRecord
        {
            MailTo = appSettingsKey.EmailGroup,
            Title = "NAP - Sync Log Non Sports",
            Subject = $"[{appSettingsKey.EnvironmentName}] - Sync Log Non Sports issue",
            Body = message
        };

        using var mailClient = new Fanex.MailDeliver.MailClient.API.MailDeliver();

        mailClient.SendMail(mailRecord);
    }
}