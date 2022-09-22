using System;
namespace ECS.Redesign
{
    public class FakeHeater : IHeater
    {
        public FakeHeater()
        {
        }
        public void TurnOn()
        {
             System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
             System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
             return true;

        }
     }
}

