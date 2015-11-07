using System;
using Styx.Plugins;
using Styx.CommonBot;
using Styx.WoWInternals;

namespace HBtimer
{

    public class KillCTM : HBPlugin
    {

        public override string Author { get { return "JudgDr3dd"; } }
        public override string Name { get { return "KillCTM"; } }
        public override Version Version { get { return new Version("0.1"); } }

        private void OnBotStoppedEvent(EventArgs args)
        {
            DisableCTM();
        }

        private void OnBotPausedEvent(object sender, EventArgs args)
        {
            DisableCTM();
        }

        private void DisableCTM()
        {
            if (TreeRoot.IsPaused || !TreeRoot.IsRunning)
            Lua.DoString(string.Format("RunMacroText(\"{0}\")", "/click InterfaceOptionsMousePanelClickToMove 0"), 0);
        }

        public override void OnEnable()
        {
            base.OnEnable();
            BotEvents.OnBotStopped += OnBotStoppedEvent;
            //BotEvents.OnBotPaused += OnBotPausedEvent;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            BotEvents.OnBotStopped -= OnBotStoppedEvent;
            //BotEvents.OnBotPaused -= OnBotPausedEvent;
        }

        public override void Pulse()
        {
            
        }

    }
}