using Exiled.API.Features;
using HarmonyLib;
using MEC;
using System;
using System.Collections.Generic;

namespace AnimatedServerTitle
{
    public class MainClass : Plugin<PluginConfig>
    {
        public override string Name { get; } = "AnimatedServerTitle";
        public override string Prefix { get; } = "animatedservertitle";
        public override string Author { get; } = "Killers0992";
        public override Version Version { get; } = new Version(1, 0, 0);

        private CoroutineHandle Handler;
        private Harmony Harmony;

        public override void OnEnabled()
        {
            Harmony = new Harmony($"animatedservertitle.{DateTime.Now.Ticks}");
            Harmony.PatchAll();
            Exiled.Events.Handlers.Server.WaitingForPlayers += PrepareAnimation;
            Exiled.Events.Handlers.Server.RestartingRound += EndAnimation;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Harmony.UnpatchAll();
            Harmony = null;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= PrepareAnimation;
            Exiled.Events.Handlers.Server.RestartingRound -= EndAnimation;
            base.OnDisabled();
        }

        private void EndAnimation()
        {
            if (Handler != null)
                Timing.KillCoroutines(Handler);
        }

        private void PrepareAnimation()
        {
            Handler = Timing.RunCoroutine(Animation());
        }

        public IEnumerator<float> Animation()
        {
            while (true)
            {
                if (PlayerList.singleton == null || ServerConsole.singleton == null)
                {
                    yield return Timing.WaitForOneFrame;
                    continue;
                }

                foreach (var title in Config.Titles)
                {
                    string str = string.Join("\n", title.Title);

                    if (!ServerConsole.singleton.NameFormatter.TryProcessExpression(str, "player list title", out str))
                    {
                        Log.Error($"Failed parsing title \"{str}\" !");
                        continue;
                    }
                    PlayerList.singleton.NetworksyncServerName = str;

                    yield return Timing.WaitForSeconds(title.DisplayTime);
                }
            }
        }
    }
}
