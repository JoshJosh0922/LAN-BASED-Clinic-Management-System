using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            //Application.Run(new MainForm.dashboard());
            //Application.Run(new MainForm.logbook());
            //Application.Run(new MainForm.Report());
            //Application.Run(new MainForm.Profile());
            //Application.Run(new MainForm.AddProfile());
            //Application.Run(new MainForm.SvConfig());
            //Application.Run(new ControlLogbook.Arrive());
            //Application.Run(new ControlAdmission.miniadmission());
            //Application.Run(new ControlAdmission.AdmissionForm());
            //Application.Run(new ControlCamera.Camera());
            //Application.Run(new ControlProfile.ProfileForm());
            //Application.Run(new ControlProfile.viewadmilog());
            //Application.Run(new ControlProfile.editform());
            Application.Run(new ControlLogin.Login2());
            //Application.Run(new ControlProfile.viewMedicProfi());
            //Application.Run(new ControlFile.addfileform());
            //Application.Run(new ControlDashboard.listdesease());
            //Application.Run(new ControlAccount.changeaccount());
            //Application.Run(new ControlAccount.editacc());
            //Application.Run(new ControlLogbook.addmed());
            //Application.Run(new ControlReport.viewreport());
        }
    }
}
