using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Milo.Core;
using Milo.Core.Services;
using NLog;

namespace Milo.Apps.Bootstrapper.WPF;

internal class PcServiceManager : IMiloServiceManager
{
    private readonly Dictionary<Type, object> _services = new();

    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public void Start()
    {
        var executing = Assembly.GetExecutingAssembly();
        if (executing?.Location != null)
        {
            var fileInfo = new FileInfo(executing.Location);
            if (fileInfo.Directory != null)
            {
                AddDirectory(fileInfo.Directory);
            }
        }
    }

    private void AddDirectory(DirectoryInfo dir)
    {
        foreach (var file in dir.EnumerateFiles("*Milo*.dll"))
        {
            try
            {
                var ass = Assembly.LoadFrom(file.FullName);
                foreach (var miloService in MiloCore.GetAssemblyInstances<IMiloService>(ass))
                {
                    _services.Add(miloService.GetType(), miloService);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        foreach (var directory in dir.EnumerateDirectories())
        {
            AddDirectory(directory);
        }
    }

    public void Stop()
    {
        _services.Clear();
    }

    public TInstanceType? CreateInstance<TInstanceType>()
    {
        return Activator.CreateInstance<TInstanceType>();
    }

    public TMiloService? GetService<TMiloService>() where TMiloService : IMiloService
    {
        return (TMiloService)_services.FirstOrDefault(kvp => typeof(TMiloService).IsAssignableFrom(kvp.Key)).Value;
    }

    public IEnumerable<TMiloService> GetServices<TMiloService>() where TMiloService : IMiloService
    {
        List<TMiloService> list = new List<TMiloService>();

        foreach (var keyValuePair in _services.Where(kvp => kvp.Key.IsAssignableFrom(typeof(TMiloService))))
        {
            if (keyValuePair.Key.IsAssignableFrom(typeof(TMiloService)))
            {
                list.Add((TMiloService)keyValuePair.Value );
            }
        }
        return list;
    }
}