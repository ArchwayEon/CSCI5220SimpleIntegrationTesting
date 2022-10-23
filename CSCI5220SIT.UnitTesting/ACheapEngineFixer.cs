using Moq;
using MotorVehicleLib;
using NUnit.Framework;

namespace CSCI5220SIT.UnitTesting
{
   [Category("Unit Tests")]
   [Category("A CheapEngineFixer")]
   [TestFixture]
   public class ACheapEngineFixer
   {
      [Test]
      public void Has20PercentChanceOfFixingAnEngine()
      {
         var randomMock = new Mock<IRandom>();
         randomMock.Setup(r => r.GetNumber()).Returns(80);

         var engineMock = new Mock<IEngine>();

         var sut = new CheapEngineFixer(randomMock.Object);
         sut.FixEngine(engineMock.Object);
         engineMock.Verify(e => e.Fix());
      }

      [Test]
      public void Has80PercentChanceOfNotFixingAnEngine()
      {
         var randomMock = new Mock<IRandom>();
         randomMock.Setup(r => r.GetNumber()).Returns(79);

         var engineMock = new Mock<IEngine>();

         var sut = new CheapEngineFixer(randomMock.Object);
         sut.FixEngine(engineMock.Object);
         engineMock.Verify(e => e.Fix(), Times.Never);
      }
   }
}
