using System;
using LightInject.SampleLibrary;
using Xunit;

namespace LightInject.Tests
{
    public class LazyTests : TestBase
    {
        [Fact]
        public void GetInstance_LazyService_ReturnsInstance()
        {            
            var container = CreateContainer();
            container.Register<IFoo, Foo>();

            var lazyInstance = container.GetInstance<Lazy<IFoo>>();

            Assert.IsAssignableFrom<Lazy<IFoo>>(lazyInstance);
        }

        [Fact]
        public void GetInstance_LazyService_DoesNotCreateTarget()
        {
            var container = CreateContainer();
            container.Register<IFoo, LazyFoo>();
            LazyFoo.Instances = 0;
            container.GetInstance<Lazy<IFoo>>();
            Assert.Equal(0, LazyFoo.Instances);
        }

        [Fact]
        public void GetInstance_LazyService_CreatesTargetWhenValuePropertyIsAccessed()
        {
            var container = CreateContainer();
            container.Register<IFoo, Foo>();
            
            var instance = container.GetInstance<Lazy<IFoo>>();

            Assert.IsAssignableFrom<Foo>(instance.Value);
        }

         [Fact]
        public void CanGetInstance_LazyForKnownService_ReturnsTrue()
        {
            var container = CreateContainer();
            container.Register<IFoo, Foo>();
            Assert.True(container.CanGetInstance(typeof(Lazy<IFoo>), string.Empty));
        }

        [Fact]
        public void CanGetInstance_LazyForUnknownService_ReturnsFalse()
        {
            var container = CreateContainer();            
            Assert.False(container.CanGetInstance(typeof(Lazy<IFoo>), string.Empty));
        }

        [Fact]
        public void GetInstance_NamedService_ReturnsLazyThatResolvesNamedService()
        {
            var container = CreateContainer();
            container.Register<IFoo,Foo>();
            container.Register<IFoo,AnotherFoo>("AnotherFoo");

            var anotherLazyFoo = container.GetInstance<Lazy<IFoo>>("AnotherFoo");

            Assert.IsType<AnotherFoo>(anotherLazyFoo.Value);
        }

        [Fact]
        public void GetInstance_LazySingleton_GetsDisposedWhenContainerIsDisposed()
        {
            var container = CreateContainer();
            container.Register<IFoo,DisposableFoo>(new PerContainerLifetime());

            var lazyInstance = container.GetInstance<Lazy<IFoo>>();
            var instance = (DisposableFoo)lazyInstance.Value;
            container.Dispose();

            Assert.True(instance.IsDisposed);

        }
    }
}