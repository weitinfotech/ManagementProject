using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace DisablingUAC_Schedular
{
    partial class DisableUACcs : ServiceBase
    {

        private System.Timers.Timer regTimer;
        const string DefaultTimerInterval = @"30000"; //every 30 seconds
        public DisableUACcs()
        {
            InitializeComponent();
        }

       

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            regTimer = new System.Timers.Timer { Interval=Convert.ToDouble(DefaultTimerInterval)};
            regTimer.Elapsed += regTimer_tick;
            regTimer.Enabled = true;
            Library.WriteLog("Disable UAC service has started");
        }

        private void regTimer_tick(object? sender, ElapsedEventArgs e)
        {
            try
            {
                Library.WriteUACRegistryValue();
            }
            catch(Exception ex) {
                Debug.Print("Exception!");
                Library.WriteErrorLog(ex);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            regTimer.Stop();
            Library.WriteLog("Service has stopped");
        }
    }
}
