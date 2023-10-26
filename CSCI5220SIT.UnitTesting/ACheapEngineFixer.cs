using MotorVehicleLib;
using NSubstitute;
using NUnit.Framework;

namespace CSCI5220SIT.UnitTesting;

[Category("Unit Tests")]
[Category("A CheapEngineFixer")]
[TestFixture]
public class ACheapEngineFixer
{
    [Test]
    public void Has20PercentChanceOfFixingAnEngine()
    {
        var randomSub = Substitute.For<IRandom>();
        randomSub.GetNumber().Returns(80);

        var engineSub = Substitute.For<IEngine>();

        var sut = new CheapEngineFixer(randomSub);
        sut.FixEngine(engineSub);
        engineSub.Received().Fix();
    }

    [Test]
    public void Has80PercentChanceOfNotFixingAnEngine()
    {
        var randomSub = Substitute.For<IRandom>();
        randomSub.GetNumber().Returns(79);

        var engineSub = Substitute.For<IEngine>();

        var sut = new CheapEngineFixer(randomSub);
        sut.FixEngine(engineSub);
        engineSub.DidNotReceive().Fix();
    }
}
