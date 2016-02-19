using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub;
using NSubstitute;
using Xunit;

namespace UnitTests
{
    public class BeforeRunTests
    {
        [Fact]
        public void stuff()
        {
            int i = 0;
            var mock = Substitute.For<Tuple<Func<int>, Func<int>, Action>>();
            mock.Item1().Returns(i);
            mock.Item2().Returns(i);
            mock.Item3.Returns( () => { i = 1; });
            var mockAction = Substitute.For<Action>();
            


            var result = Scientist.Science<int>("success", experiment =>
            {
                experiment.BeforeRun(mock.Item3);
                experiment.Use(mock.Item1);
                experiment.Try(mock.Item2);
            });

            Assert.Equal(1, result);
        }
    }
}
