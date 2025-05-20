using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public static class NotificationService
    {
        public static void Notify(string title, string text, ToolTipIcon icon)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.DiplomIcon;
            notifyIcon.BalloonTipClosed += notifyIcon_BalloonTipClosed;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(0, title, text, icon);
        }
        private static void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }

    //private void Notify(string title, string text, ToolTipIcon icon)
    //{
    //    NotifyIcon notifyIcon = new NotifyIcon();
    //    notifyIcon.Icon = Properties.Resources.DiplomIcon;
    //    notifyIcon.BalloonTipClosed += notifyIcon_BalloonTipClosed;
    //    notifyIcon.Visible = true;
    //    notifyIcon.ShowBalloonTip(0, title, text, icon);
    //}

    //private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
    //{
    //    NotifyIcon notifyIcon = sender as NotifyIcon;
    //    notifyIcon.Visible = false;
    //    notifyIcon.Dispose();
    //}
}
