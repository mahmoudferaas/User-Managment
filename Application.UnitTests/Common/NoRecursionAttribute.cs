#region Usings

using System;
using System.Threading;
using AutoFixture;
using AutoFixture.Xunit2;

#endregion

namespace Application.UnitTests.Common
{
    public class NoRecursionAttribute : AutoDataAttribute
    {
        public NoRecursionAttribute() :  base(() =>
        {
            var fixture = new Fixture();
            //fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
        {
            
        }

    }
}