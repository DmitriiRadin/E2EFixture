namespace E2EFixtures.Tests;

public class UnitTest2 : ITestClassFixture
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public UnitTest2(TestClassFixture classFixture)
    {
        _dateTimeProvider = classFixture.GetService<IDateTimeProvider>();
    }

    [Fact]
    public void Test1()
    {
    }

    [Fact]
    public void Test2()
    {
    }
}