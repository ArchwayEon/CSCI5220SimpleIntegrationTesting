using Moq;
using MotorVehicleLib;
using NUnit.Framework;
using System;

namespace CSCI5220SIT.IntegrationTesting
{
   [Category("Integration Tests")]
   [Category("A CheapEngineFixture")]
   [TestFixture]
   public class ACheapEngineFixer
   {
      [Category("Integration: EngineFixer -uses-> IEngine")]
      [Test]
      public void Has20PercentChanceOfFixingAnEngine()
      {
         var fixerRandomMock = new Mock<IRandom>();
         fixerRandomMock.Setup(r => r.GetNumber()).Returns(80);

         var engineRandomMock = new Mock<IRandom>();
         engineRandomMock.Setup(r => r.GetNumber()).Returns(90);

         var engine = new Engine(engineRandomMock.Object);
         Assert.That(engine.HasProblem(), Is.True);

         var sut = new CheapEngineFixer(fixerRandomMock.Object);
         sut.FixEngine(engine);
         Assert.That(engine.HasProblem(), Is.False);
      }

      [Category("Integration: EngineFixer -uses-> IEngine")]
      [Test]
      public void Has80PercentChanceOfNotFixingAnEngine()
      {
         var fixerRandomMock = new Mock<IRandom>();
         fixerRandomMock.Setup(r => r.GetNumber()).Returns(79);

         var engineRandomMock = new Mock<IRandom>();
         engineRandomMock.Setup(r => r.GetNumber()).Returns(90);

         var engine = new Engine(engineRandomMock.Object);
         Assert.That(engine.HasProblem(), Is.True);

         var sut = new CheapEngineFixer(fixerRandomMock.Object);
         sut.FixEngine(engine);
         Assert.That(engine.HasProblem(), Is.True);
      }
   }

}
