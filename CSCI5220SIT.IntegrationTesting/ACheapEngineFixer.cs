using MotorVehicleLib;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CSCI5220SIT.IntegrationTesting;

[Category("Integration Tests")]
[Category("A CheapEngineFixture")]
[TestFixture]
public class ACheapEngineFixer
{
    [Category("Integration: EngineFixer -uses-> IEngine")]
    [Test]
    public void Has20PercentChanceOfFixingAnEngine()
    {
        var fixerRandomSub = Substitute.For<IRandom>();
        fixerRandomSub.GetNumber().Returns(80);

        var engineRandomSub = Substitute.For<IRandom>();
        engineRandomSub.GetNumber().Returns(90);

        var engine = new Engine(engineRandomSub);
        Assert.That(engine.HasProblem(), Is.True);

        var sut = new CheapEngineFixer(fixerRandomSub);
        sut.FixEngine(engine);
        Assert.That(engine.HasProblem(), Is.False);
    }

    [Category("Integration: EngineFixer -uses-> IEngine")]
    [Test]
    public void Has80PercentChanceOfNotFixingAnEngine()
    {
        var fixerRandomSub = Substitute.For<IRandom>();
        fixerRandomSub.GetNumber().Returns(79);

        var engineRandomSub = Substitute.For<IRandom>();
        engineRandomSub.GetNumber().Returns(90);

        var engine = new Engine(engineRandomSub);
        Assert.That(engine.HasProblem(), Is.True);

        var sut = new CheapEngineFixer(fixerRandomSub);
        sut.FixEngine(engine);
        Assert.That(engine.HasProblem(), Is.True);
    }
}
