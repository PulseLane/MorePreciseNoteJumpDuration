using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace MorePreciseNoteJumpDuration.Configuration
{
    internal class PluginConfig
    {
        public virtual float Step { get; set; } = 0.025f; 
    }
}