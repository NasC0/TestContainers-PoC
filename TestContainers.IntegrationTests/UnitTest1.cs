namespace TestContainers.IntegrationTests;

public class UnitTest1 : IClassFixture<ApiFactory>
{
    private readonly ApiFactory _apiFactory;

    public UnitTest1(ApiFactory apiFactory)
    {
        _apiFactory = apiFactory;
    }
    
    [Fact]
    public void Test1()
    {
        var client = _apiFactory.CreateClient();
    }
}
