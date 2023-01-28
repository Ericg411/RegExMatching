namespace RegExMatching.Tests;

[TestClass]
public class RegExTest
{
    private readonly RegExMatching _regExMatching;

    public RegExTest()
    {
        _regExMatching = new RegExMatching();
    }

    [TestMethod]
    public void TestMethod1()
    {
        string inputString = "aa";
        string pattern = "a";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestMethod2()
    {
        string inputString = "aa";
        string pattern = "a*";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestMethod3()
    {
        string inputString = "ab";
        string pattern = ".*";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestMethod4()
    {
        string inputString = "bbbba";
        string pattern = ".*a*a";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestMethod5()
    {
        string inputString = "ab";
        string pattern = ".*..";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestMethod6()
    {
        string inputString = "aasdfasdfasdfasdfas";
        string pattern = "aasdf.*asdf.*asdf.*asdf.*s";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestMethod7()
    {
        string inputString = "abcdede";
        string pattern = "ab.*de";

        bool result = _regExMatching.IsMatch(inputString, pattern);

        Assert.IsTrue(result);
    }
}