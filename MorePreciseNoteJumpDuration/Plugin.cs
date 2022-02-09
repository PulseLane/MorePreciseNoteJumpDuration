using IPA;
using IPA.Config.Stores;
using MorePreciseNoteJumpDuration.Configuration;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace MorePreciseNoteJumpDuration
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static IPALogger logger;
        internal static PluginConfig config;

        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector, IPA.Config.Config conf)
        {
            var config = conf.Generated<PluginConfig>();
            Plugin.logger = logger;
            zenjector.Install<Installers.MenuInstaller>(Location.Menu, config);
        }

        [OnEnable]
        public void OnEnable()
        {

        }

        [OnDisable]
        public void OnDisable()
        {

        }
    }
}
