using MorePreciseNoteJumpDuration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace MorePreciseNoteJumpDuration.Installers
{
    class MenuInstaller : Installer
    {
        private readonly PluginConfig _config;

        public MenuInstaller(PluginConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();

            Container.BindInterfacesTo<Managers.NoteJumpDurationManager>().AsSingle().NonLazy();
        }
    }
}
