namespace Core.Mailing;

public class MailSettings
{
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Password { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }

    public MailSettings()
    {
        
    }

    public MailSettings(string senderName, string senderEmail, string password, string server, int port, string username)
    {
        SenderName = senderName;
        SenderEmail = senderEmail;
        Password = password;
        Server = server;
        Port = port;
        Username = username;
    }


}