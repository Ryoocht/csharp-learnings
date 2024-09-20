using System.Net.NetworkInformation;
using NetworkUtility.DNS;

namespace NetworkUtility.Ping;

public class NetworkService(IDNS dns)
{
    private readonly IDNS _dns = dns;

    public string SendPing()
    {
        var dnsSuccess = _dns.SendDNS();

        if (dnsSuccess)
        {
            return "Success: Ping Sent!";

        }
        else
        {
            return "Failed: Ping NOT Sent!";
        }
    }

    public int PingTimeout(int a, int b)
    {
        return a + b;
    }

    public DateTime LastPingDate()
    {
        return DateTime.Now;
    }

    public PingOptions GetPingOptions()
    {
        return new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };
    }

    public IEnumerable<PingOptions> MostRecentPings()
    {
        IEnumerable<PingOptions> pingOptions =
        [
            new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },
            new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },
            new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            },
        ];

        return pingOptions;
    }
}