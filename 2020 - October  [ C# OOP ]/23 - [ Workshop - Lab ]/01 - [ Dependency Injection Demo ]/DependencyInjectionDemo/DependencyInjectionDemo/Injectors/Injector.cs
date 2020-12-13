namespace DependencyInjectionDemo.Injectors
{
    using Attributes;
    using Modules;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            if (desireClass == null)
            {
                return default(TClass);
            }

            var constructors = desireClass.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                if (CheckForConstructorInjection<TClass>() == false)
                {
                    continue; ;
                }

                var inject = (Inject)constructor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();
                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var index = 0;

                foreach (ParameterInfo parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttributes(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[index++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[index++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields();

            foreach (FieldInfo field in fields)
            {
                var injection = (Inject)field
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();
                Type dependency = null;

                var named = field.GetCustomAttributes(typeof(Named), true);
                var type = field.FieldType;

                if (named == null)
                {
                    dependency = this.module.GetMapping(type, injection);
                }
                else
                {
                    dependency = this.module.GetMapping(type, named);
                }

                if (type.IsAssignableFrom(dependency))
                {
                    object instance = this.module.GetInstance(dependency);
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance(dependency);
                        this.module.SetInstance(dependency, instance);
                    }

                    field.SetValue(desireClassInstance, instance);
                }
            }

            return (TClass)desireClassInstance;
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute & hasFieldAttribute)
            {
                throw new ArgumentException("There must be only one constructor or field annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
