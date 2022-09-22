using ECS.Redesign;
using NSubstitute;

namespace TestProject.Test.Unit
{
     public class Tests
     {
          private ECS.Redesign.ECS _uut;
          private IHeater _heater;
          private ITempSensor _tempSensor;



          //public ECS.Redesign.ECS uut = new ECS.Redesign.ECS(2, new FakeHeater(), new FakeTempSensor());

          [SetUp]
          public void Setup()
          {
               _heater = Substitute.For<IHeater>();
               _tempSensor = Substitute.For<ITempSensor>();

               _uut = new ECS.Redesign.ECS(25, _heater, _tempSensor);

          }

          // stubs 1 false
          [TestCase(true,false,false)]
          [TestCase(false,false, false)]
          [TestCase(true, true, true)]
          public void RunSelfTest_TempSensorFails_SelfTestFails(bool p1, bool p2, bool expected)
          {
               _tempSensor.RunSelfTest().Returns(p1);
               _heater.RunSelfTest().Returns(p2);

               Assert.That(_uut.RunSelfTest(),Is.EqualTo(expected));
               Assert.That(_uut.RunSelfTest(), Is.EqualTo(expected));
          }


          // mock
          [Test]
          public void Regulate_TempBelowThreshold_HeaterTurnedOn()
          {
               _tempSensor.GetTemp().Returns(24);
               _uut.Regulate();
               _heater.Received(1).TurnOn();

          }

          // mock
          [Test]
          public void Regulate_HeaterTurnedOn()
          {
               _tempSensor.GetTemp().Returns(26);
               _uut.Regulate();
               _heater.Received(1).TurnOff();
          }


          //[Test]
          //public void GetThreshold()
          //{
          //     Assert.That(uut.GetThreshold(),Is.EqualTo(2));
          //}


          //[Test]
          //public void RunSelfTest()
          //{
          //     Assert.That(uut.RunSelfTest(), Is.True);
          //}

          //[Test]
          //public void SetThreshold()
          //{
          //     uut.SetThreshold(2);
          //     Assert.That(uut.GetThreshold(), Is.EqualTo(2));
          //}


          //[Test]
          //public void GetCurTemp()
          //{
          //     Assert.That(uut.GetCurTemp(), Is.EqualTo(20));
          //}

          //[Test]
          //public void Window()
          //{
          //     Assert.That(uut.Window(), Is.EqualTo(1));
          //}
     }
}