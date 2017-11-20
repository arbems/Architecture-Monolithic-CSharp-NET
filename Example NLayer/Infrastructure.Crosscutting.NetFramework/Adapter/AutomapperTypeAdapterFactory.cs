namespace Infrastructure.Crosscutting.NetFramework.Adapter
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Crosscutting.Adapter;
    using System.Reflection;

    public class AutomapperTypeAdapterFactory
        :ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            try
            {
                //scan all assemblies finding Automapper Profile
                var profiles = AppDomain.CurrentDomain.GetAssemblies()
                      .SelectMany(a => a.GetTypes())
                      .Where(t => t.BaseType == typeof(Profile));

                Mapper.Initialize(
                   cfg =>
                   {
                       foreach (var item in profiles)
                       {
                           if (item.FullName != "AutoMapper.SelfProfiler`2" 
                           && item.FullName != "AutoMapper.Configuration.MapperConfigurationExpression" 
                           && item.FullName != "AutoMapper.Configuration.MapperConfigurationExpression+NamedProfile")
                           {
                               cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                           }
                       }
                   });
            }
            catch (Exception ex)
            {
                if (ex is System.Reflection.ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                }
            }
            
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
