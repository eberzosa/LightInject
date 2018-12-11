﻿namespace LightInject.Tests
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using SampleLibrary;
    using Xunit;

    public class OpenGenericTests : TestBase
    {
        [Fact]
        public void GetInstance_PartiallyClosedGeneric_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof (IFoo<,>), typeof (HalfClosedFoo<>));

            var instance = container.GetInstance<IFoo<string, int>>();

            Assert.IsType<HalfClosedFoo<int>>(instance);
        }

        [Fact]
        public void GetInstance_PartiallyClosedGenericWithNestedArgument_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof(IFoo<,>), typeof(HalfClosedFooWithNestedGenericParameter<>));

            var instance = container.GetInstance<IFoo<Lazy<int>, string>>();

            Assert.IsType<HalfClosedFooWithNestedGenericParameter<int>>(instance);
        }

        [Fact]
        public void GetInstance_PartiallyClosedGenericWithDoubleNestedArgument_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof(IFoo<,>), typeof(HalfClosedFooWithDoubleNestedGenericParameter<>));

            var instance = container.GetInstance<IFoo<Lazy<Nullable<int>>, string>>();

            Assert.IsType<HalfClosedFooWithDoubleNestedGenericParameter<int>>(instance);
        }

        [Fact]
        public void GetInstance_PartialClosedAbstractClass_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof (Foo<,>), typeof (HalfClosedFooInhertingFromBaseClass<>));

            var instance = container.GetInstance<Foo<string,int>>();

            Assert.IsType<HalfClosedFooInhertingFromBaseClass<int>>(instance);
        }

        [Fact]
        public void GetInstance_ConcreteClass_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof (Foo<>));

            var instance = container.GetInstance<Foo<int>>();

            Assert.IsType<Foo<int>>(instance);
        }

        [Fact]
        public void GetInstance_InheritFromOpenGeneric_ReturnsInstance()
        {
            var container = CreateContainer();
            container.Register(typeof(GenericFoo<>), typeof(AnotherGenericFoo<>));

            var instance = container.GetInstance<GenericFoo<int>>();

            Assert.IsType<AnotherGenericFoo<int>>(instance);
        }

        [Fact]
        public void GetInstance_NamedServiceWithInvalidConstraint_ThrowsException()
        {
            var container = CreateContainer();
            container.Register(typeof(IFoo<>), typeof(FooWithGenericConstraint<>), "SomeService");

            Assert.Throws<InvalidOperationException>(() => container.GetInstance<IFoo<int>>("SomeService"));
        }

        [Fact]
        public void GetInstance_NoMatchingOpenGeneric_ThrowsException()
        {
             var container = CreateContainer();

             Assert.Throws<InvalidOperationException>(() => container.GetInstance<IFoo<int>>());
            
        }
    }
}