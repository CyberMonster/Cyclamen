using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Cyclamen.Tests
{
    public class InjectAttributeTests
    {
        private static IServiceProvider _factory;
        static InjectAttributeTests()
            => _factory = new ServiceCollection()
                .AddSingleton<IIT1, IIIT1>()
                .AddSingleton<IIT2, IIIT2>()
                .AddSingleton<IIT3, IIIT3>()
                .AddSingleton<IIT4, IIIT4>()
                .BuildServiceProvider();

        public interface IIT1 { }
        public class IIIT1 : IIT1 { }
        public class InjectionTest1
        {
            [Inject]
            private IIT1 _;
            public InjectionTest1()
                => this.InjectProperties(_factory);
        }

        public interface IIT2 { }
        public class IIIT2 : IIT2 { }
        public class InjectionTest2
        {
            [Inject]
            private IIT2 _ { get; }
            public InjectionTest2()
                => this.InjectProperties(_factory);
        }

        public interface IIT3 { }
        public class IIIT3 : IIT3 { }
        public class InjectionTest3
        {
            [Inject]
            private IIT3 _ { get; set; }
            public InjectionTest3()
                => this.InjectProperties(_factory);
        }

        public interface IIT4 { }
        public class IIIT4 : IIT4 { }
        public class InjectionTest4
        {
            [Inject]
            private IIT4 _1 { get; set; }
            [Inject]
            private IIT4 _2 { get; set; }
            public InjectionTest4()
                => this.InjectProperties(_factory);
        }

        [Theory]
        [InlineData(typeof(InjectionTest1), typeof(IIT1))]
        [InlineData(typeof(InjectionTest2), typeof(IIT2), "Property set method not found.")]
        [InlineData(typeof(InjectionTest3), typeof(IIT3))]
        public void CheckInjection(Type testedType, Type interfaceType, string errorMessage = null)
        {
            try
            {
                CreateAndInject(testedType)
                    .Should()
                    .AllBeEquivalentTo(_factory.GetService(interfaceType));
            }
            catch (Exception ex)
            {
                if (errorMessage == null)
                    throw;

                ex.InnerException.Message.Should().Be(errorMessage);
            }
        }

        [Theory]
        [InlineData(typeof(InjectionTest4), typeof(IIT4), 2)]
        public void CheckMultipleInjection(Type testedType, Type interfaceType, int count)
        {
            var values = CreateAndInject(testedType);

            values.Should().AllBeEquivalentTo(_factory.GetService(interfaceType));
            values.Should().HaveCount(count);
        }

        private List<object> CreateAndInject(Type testedType)
        {
            var testedObject = Activator.CreateInstance(testedType);
            var type = testedObject.GetType();
            var members = type.GetMembers(BindingFlags.GetField
                | BindingFlags.GetProperty
                | BindingFlags.Instance
                | BindingFlags.NonPublic
                | BindingFlags.Public);

            var injectableMembers = members.Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute))).ToList();

            return injectableMembers.Select(member => member.MemberType switch
            {
                MemberTypes.Field => (member as FieldInfo).GetValue(testedObject),
                MemberTypes.Property => (member as PropertyInfo).GetValue(testedObject),
                _ => throw new NotImplementedException()
            }).ToList();
        }
    }
}
