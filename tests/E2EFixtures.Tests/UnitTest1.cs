namespace E2EFixtures.Tests;

public class UnitTest1 : ITestClassFixture
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public UnitTest1(TestClassFixture classFixture)
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