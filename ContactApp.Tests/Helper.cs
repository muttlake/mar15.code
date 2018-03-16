using Xunit;
using ContactApp.Library.Models;
using ContactApp.Library;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Tests
{
    public class Helper
    {
        [Fact]
        public void Test_ContactHelper_Add()
        {
            //arrange
            var ch = new ContactHelper<Person>();

            //act
            var actual = ch.Add(new Person());

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void Test_ContactHelper_Read()
        {
            //arrange
            var ch = new ContactHelper<Person>();
            int expectation = 1;

            //act
            var container = ch.Read();
            int count = container.Count;

            //assert
            Assert.True(count >= expectation);
        }

        [Fact]
        public void Test_ContactHelper_AddPerson()
        {
            var p = new Person();
            var defaultName = new Name();

            var ch = new ContactHelper<Person>();
            ch.Add(p);

            var lastPerson = ch.Read().Last();

            Assert.True(defaultName.First == lastPerson.Name.First);
            Assert.True(defaultName.Last == lastPerson.Name.Last);
        }
    }
}