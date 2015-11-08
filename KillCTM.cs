using System;
using Styx.Plugins;
using Styx.CommonBot;
using Styx.WoWInternals;
using Styx.Common;
using System.Windows.Media;

namespace HBtimer
{

    public class KillCTM : HBPlugin
    {

        public override string Author { get { return "JudgDr3dd"; } }
        public override string Name { get { return "KillCTM"; } }
        public override Version Version { get { return new Version("0.1"); } }
        public override void Pulse() { }


        public override void OnEnable()
        {
            base.OnEnable();
            BotEvents.OnBotStopped += OnBotStoppedEvent;
            BotEvents.OnBotPaused += OnBotPausedEvent;
        }
        
        public override void OnDisable()
        {
            base.OnDisable();
            BotEvents.OnBotStopped -= OnBotStoppedEvent;
            BotEvents.OnBotPaused -= OnBotPausedEvent;
        }

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
            Lua.DoString("SetCVar('autoInteract', '0')");
            Logging.Write(LogLevel.Normal, Colors.Aqua, "Click to Move Disabled");
        }

    }
}