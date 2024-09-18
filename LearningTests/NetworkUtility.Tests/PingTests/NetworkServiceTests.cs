using System.Net.NetworkInformation;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTests;

public class NetworkServiceTests
{

    private readonly NetworkService _pingService;

    public NetworkServiceTests()
    {
        _pingService = new NetworkService();
    }

    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        // Act
        var result = _pingService.SendPing();
        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
    {
        // Act
        var result = _pingService.PingTimeout(a, b);

        // Assert
        result.Should().Be(expected);
        result.Should().BeGreaterThanOrEqualTo(2);
        result.Should().NotBeInRange(-10000, 0);
    }

    [Fact]
    public void NetworkService_LastPingDate_ReturnDate()
    {
        var result = _pingService.LastPingDate();

        result.Should().BeAfter(1.January(2010));
        result.Should().BeBefore(1.January(2025));
    }

    [Fact]
    public void NetworkService_GetPingOptions_ReturnsObject()
    {
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        var result = _pingService.GetPingOptions();

        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
        result.Ttl.Should().Be(1);
    }

    [Fact]
    public void NetworkService_MostRecentPings_ReturnsObject()
    {
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        var result = _pingService.MostRecentPings();

        result.Should().ContainEquivalentOf(expected);
        result.Should().Contain(x => x.DontFragment == true);
    }
}