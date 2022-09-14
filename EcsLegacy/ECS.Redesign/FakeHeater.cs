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
            throw new NotImplementedException();
        }

        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}

