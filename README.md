# OxideDisableSandbox

Disable oxide's sandbox using Harmony.  This will only work if loaded at server startup.

Since the load time of harmony mods precedes the full init of Oxide, this is ready in time to modify how Oxide sets the sandbox value on plugin load.  This mod alters their code at runtime to always ensure that the sandbox is disabled.
