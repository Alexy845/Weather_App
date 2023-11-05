namespace Weather_App;

public class Internet
{
    public static bool DnsTest()
    {
        try
        {
            System.Net.IPHostEntry ipHe = System.Net.Dns.GetHostEntry("www.google.com");
            return true;
        }
        catch
        {
            return false;
        }
    }
}