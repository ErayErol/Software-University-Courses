using System.Linq;
using DependencyInjectionDemo.Attributes;

namespace DependencyInjectionDemo.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (this.implementations.ContainsKey(typeof(TInterface)) == false)
            {
                this.implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available Mapping for class: {currentInterface.FullName}");
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;
                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (this.instances.ContainsKey(implementation) == false)
            {
                this.instances.Add(implementation, instance);
            }
        }

        public object GetInstance(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);
            return value;
        }

    }
}
