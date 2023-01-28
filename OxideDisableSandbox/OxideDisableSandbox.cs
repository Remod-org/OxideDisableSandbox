using System.Collections.Generic;
using System.Reflection.Emit;
using Harmony;
using Oxide.Plugins;

namespace OxideDisableSandbox
{
    [HarmonyPatch(typeof(CSharpExtension), "Load")]
    public static class OxideDisableSandbox
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instr, ILGenerator il)
        {
            //System.Reflection.MethodInfo arrayReference = typeof(Array).GetMethod("Empty").MakeGenericMethod(typeof(object));
            List<CodeInstruction> codes = new List<CodeInstruction>(instr);

            int startIndex = 0;
            int i;
            for (i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Newobj && codes[i + 1].opcode == OpCodes.Callvirt)
                {
                    startIndex = i + 2;
                    break;
                }
            }

            List<CodeInstruction> instructionsToInsert = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(CSharpExtension), "set_SandboxEnabled")),
            };
            codes.InsertRange(startIndex, instructionsToInsert);
            codes.RemoveRange(startIndex + 2, 17);
            return codes;
        }
    }
}
