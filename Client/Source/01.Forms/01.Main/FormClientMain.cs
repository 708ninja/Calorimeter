﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Ulee.Controls;
using Ulee.DllImport.Win32;
using Ulee.Threading;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public enum EMainMenuItem
    {
        Test,
        View,
        Log,
        Device,
        Config
    }

    public partial class FormClientMain : UlFormEng
    {
        public FormClientMain()
        {
            Opacity = 0;
            Cursor = Cursors.WaitCursor;
            Resource.MainForm = this;

            formSplash = new FormClientSplash();
            formSplash.Show();

            InitializeComponent();
            Initialize();
        }

        private const int WM_PROG_TERMINATE = (Win32.WM_USER + 0);

        private const int csInvalidTime = 500;

        private ETerminateCode terminateCode;

        private InvalidThread invalidThread;

        private Form formSplash;

        private void Initialize()
        {
            Resource.Create();

            terminateCode = ETerminateCode.None;

            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlTestLeft(), testButton);
            DefMenu.Add(new CtrlViewLeft(), viewButton);
            DefMenu.Add(new CtrlDeviceLeft(), deviceButton);
            DefMenu.Add(new CtrlLogLeft(), logButton);
            DefMenu.Add(new CtrlConfigLeft(), configButton);

            invalidThread = null;

            Resource.Client.Listener.NonAcknowledge += DoNonAcknowledge;
            Resource.Client.Listener.NotifyTermination += DoNotifyTermination;
            Resource.Client.Listener.RefreshConnectionState += DoRefreshConnectionState;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PROG_TERMINATE:
                    terminateCode = (ETerminateCode)m.WParam;
                    Close();
                    break;
            }

            base.WndProc(ref m);
        }

        private void FormClientMain_Load(object sender, EventArgs args)
        {
            Resource.TLog.Log((int)ELogItem.Note, "Start Calorimeter Client Program.");
            DispCaption();

            DefMenu.Index = 0;
            Location = new Point(0, 0);

            Resource.TLog.Log((int)ELogItem.Note, "Resume the thread for listener.");
            Resource.Client.Resume();

            Resource.TLog.Log((int)ELogItem.Note, "Send connection command to Server.");
            Resource.Client.Connect();

            Resource.TLog.Log((int)ELogItem.Note, "Resume invalidation thread of screen.");
            invalidThread = new InvalidThread(csInvalidTime);
            invalidThread.InvalidControls += InvalidForm;
            invalidThread.Resume();

            Resource.TLog.Log((int)ELogItem.Note, "Resume TestContext threads");
            CtrlTestLeft ctrlLeft = DefMenu.Controls((int)EMainMenuItem.Test) as CtrlTestLeft;
            for (int i=0; i<ctrlLeft.DefMenu.ControlsCount; i++)
            {
                CtrlTestRight ctrlRight = ctrlLeft.DefMenu.Controls(i) as CtrlTestRight;
                ctrlRight.Context.Resume();
            }

            SetUser();
        }

        private void FormClientMain_Shown(object sender, EventArgs e)
        {
            formSplash.Close();
            Opacity = 100;
            Resource.State = EClientState.Running;
            Cursor = Cursors.Default;
        }

        private void FormClientMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (terminateCode != ETerminateCode.None)
            {
                e.Cancel = false;
                Resource.TLog.Log((int)ELogItem.Note, "Raise main form close event");
                return;
            }

            if (Resource.Busy == true)
            {
                e.Cancel = true;
                return;
            }

            if (MessageBox.Show("Would you like to exit this program?",
                Resource.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Resource.TLog.Log((int)ELogItem.Note, "Raise main form close event");
            }
        }

        private void FormClientMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Resource.State = EClientState.Closing;

            Resource.TLog.Log((int)ELogItem.Note, "Terminate TestContext threads");
            CtrlTestLeft ctrlLeft = DefMenu.Controls((int)EMainMenuItem.Test) as CtrlTestLeft;

            for (int i = 0; i < ctrlLeft.DefMenu.ControlsCount; i++)
            {
                CtrlTestRight ctrlRight = ctrlLeft.DefMenu.Controls(i) as CtrlTestRight;
                ctrlRight.Context.Terminate();
            }

            if (invalidThread.IsAlive == true)
            {
                Resource.TLog.Log((int)ELogItem.Note, "Terminate an invalid thread");
                invalidThread.Terminate();
            }

            switch (terminateCode)
            {
                case ETerminateCode.None:
                    Resource.Client.Disconnect();
                    break;

                case ETerminateCode.ReceivedTerminateCommand:
                    MessageBox.Show("This program is terminated by termination command from server!",
                        Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;

                case ETerminateCode.NonAcknowledgement:
                    //MessageBox.Show("This program is terminated by non acknowledgement from server!",
                    //    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }

            Resource.TLog.Log((int)ELogItem.Note, "Terminate a client threads");
            Resource.Client.Terminate();

            Resource.TLog.Log((int)ELogItem.Note, "Exit Calorimeter Client Program");
        }

        private void FormClientMain_Resize(object sender, EventArgs e)
        {
            if (Width > 1936) Width = 1936;
            if (Height > 1066) Height = 1066;

            if (Width < 1280) Width = 1280;
            if (Height < 800) Height = 800;
        }

        private void FormClientMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((EMainMenuItem)DefMenu.Index)
            {
                case EMainMenuItem.Test:
                    break;

                case EMainMenuItem.View:
                    break;

                case EMainMenuItem.Log:
                    break;

                case EMainMenuItem.Device:
                    break;

                case EMainMenuItem.Config:
                    CtrlConfigLeft ctrl = DefMenu.Controls(DefMenu.Index) as CtrlConfigLeft;

                    if (ctrl.DefMenu.Index == 0)
                    {
                        CtrlConfigSchedule sch = ctrl.DefMenu.Controls(0) as CtrlConfigSchedule;
                        sch.CtrlConfigSchedule_KeyPress(sender, e);
                    }
                    else
                    {
                        CtrlConfigCondition cond = ctrl.DefMenu.Controls(1) as CtrlConfigCondition;
                        cond.CtrlConfigCondition_KeyPress(sender, e);
                    }
                    break;
            }
        }

        private void testLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tag = int.Parse((sender as ToolStripItem).Tag.ToString());

            DefMenu.Index = 0;
            (DefMenu.Controls(0) as CtrlTestLeft).DefMenu.Index = tag;
        }

        private void testViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tag = int.Parse((sender as ToolStripItem).Tag.ToString());

            DefMenu.Index = 1;
            (DefMenu.Controls(1) as CtrlViewLeft).DefMenu.Index = tag;
        }

        private void deviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tag = int.Parse((sender as ToolStripItem).Tag.ToString());

            DefMenu.Index = 2;
            (DefMenu.Controls(2) as CtrlDeviceLeft).DefMenu.Index = tag;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefMenu.Index = 3;
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tag = int.Parse((sender as ToolStripItem).Tag.ToString());

            DefMenu.Index = 4;
            (DefMenu.Controls(4) as CtrlConfigLeft).DefMenu.Index = tag;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsLogin() == false)
            {
                logoffButton.PerformClick();
            }
        }

        private void logoffButton_Click(object sender, EventArgs e)
        {
            Resource.UserNo = -1;
            Resource.Authority = EUserAuthority.Viewer;
            Resource.Ini.SetInteger("Login", "UserNo", Resource.UserNo);
            SetAuthority();
        }

        private void prtOptionMenuItem_Click(object sender, EventArgs e)
        {
            FormPrintingOption form = new FormPrintingOption();

            if (form.ShowDialog() == DialogResult.OK)
            {
                UlIniFile ini = Resource.Ini;
                string section = "Options";

                ini.SetBoolean(section, "AutoExcel", form.AutoExcel);
                ini.SetBoolean(section, "StoppedTestExcel", form.StoppedTestExcel);
                ini.SetBoolean(section, "Indoor11", form.Indoor11);
                ini.SetBoolean(section, "Indoor12", form.Indoor12);
                ini.SetBoolean(section, "Indoor21", form.Indoor21);
                ini.SetBoolean(section, "Indoor22", form.Indoor22);
                ini.SetBoolean(section, "Indoor1TC", form.IndoorTC1);
                ini.SetBoolean(section, "Indoor2TC", form.IndoorTC2);
                ini.SetBoolean(section, "OutdoorTC", form.OutdoorTC);

                Resource.Settings.Load();
            }
        }

        private void etcOptionMenuItem_Click(object sender, EventArgs e)
        {
            FormEtcOption form = new FormEtcOption();

            if (form.ShowDialog() == DialogResult.OK)
            {
                UlIniFile ini = Resource.Ini;
                string section = "Options";

                ini.SetBoolean(section, "FixedAtmPressure", form.FixedAtmPressure);
                ini.SetBoolean(section, "ForcedInteg", form.ForcedInteg);
                ini.SetString(section, "ExcelPath", form.ExcelPath);

                Resource.Settings.Load();
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoNotifyTermination(object sender, EventArgs e)
        {
            if (Resource.State == EClientState.Closing) return;

            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoNotifyTermination);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                Win32.PostMessage(this.Handle, WM_PROG_TERMINATE,
                    (IntPtr)ETerminateCode.ReceivedTerminateCommand, (IntPtr)0);
            }
        }

        private void DoRefreshConnectionState(object sender, EventArgs e)
        {
            if (Resource.State == EClientState.Closing) return;

            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoRefreshConnectionState);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                bool active;
                ClientReceiveArgs args = e as ClientReceiveArgs;

                active = (powerMeterLedLabel.BackColor == SystemColors.Control) ? false : true;
                if (active != args.PowerMeter)
                {
                    powerMeterLedLabel.BackColor = (active == true) ? Color.Khaki : SystemColors.Control;
                }

                active = (recorderLedLabel.BackColor == SystemColors.Control) ? false : true;
                if (active != args.Recorder)
                {
                    recorderLedLabel.BackColor = (active == true) ? Color.Khaki : SystemColors.Control;
                }

                active = (controllerLedLabel.BackColor == SystemColors.Control) ? false : true;
                if (active != args.Controller)
                {
                    controllerLedLabel.BackColor = (active == true) ? Color.Khaki : SystemColors.Control;
                }

                active = (plcLedLabel.BackColor == SystemColors.Control) ? false : true;
                if (active != args.Plc)
                {
                    plcLedLabel.BackColor = (active == true) ? Color.Khaki : SystemColors.Control;
                }
            }
        }

        private void DoNonAcknowledge(object sender, EventArgs e)
        {
            if (Resource.State == EClientState.Closing) return;

            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoNonAcknowledge);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                Win32.PostMessage(this.Handle,
                    WM_PROG_TERMINATE,
                    (IntPtr)ETerminateCode.NonAcknowledgement,
                    (IntPtr)0);
            }
        }

        public void DoDispStateMainForm(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoDispStateMainForm);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                TestDescriptionArgs args = e as TestDescriptionArgs;
                ToolStripStatusLabel[] stateLabels = { line1StateLabel, line2StateLabel, line3StateLabel, line4StateLabel };
                ToolStripProgressBar[] stateProgress = { line1Progress, line2Progress, line3Progress, line4Progress };

                ETestStep step = args.Step;
                int line = args.Index;
                int preMax = (int)args.PrepareMaxTime;
                int preCur = (int)args.PrepareCurTime;
                int judgeMax = (int)args.JudgeMaxTime;
                int judgeCur = (int)args.JudgeCurTime;
                int integMax = (int)args.IntegMaxTime;
                int integCur = (int)args.IntegCurTime;

                try
                {
                    stateLabels[line].Text = step.ToString();

                    switch (step)
                    {
                        case ETestStep.None:
                            stateProgress[line].Maximum = 100;
                            stateProgress[line].Value = 0;
                            break;

                        case ETestStep.Preparation:
                            stateProgress[line].Maximum = preMax;
                            stateProgress[line].Value = preCur;
                            break;

                        case ETestStep.Judgement:
                            stateProgress[line].Maximum = judgeMax;
                            stateProgress[line].Value = judgeCur;
                            break;

                        case ETestStep.Integration:
                            stateProgress[line].Maximum = integMax;
                            stateProgress[line].Value = integCur;
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        public override void InvalidForm(object sender, EventArgs e)
        {
            if (Resource.State == EClientState.Closing) return;

            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(InvalidForm);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                InvalidDateTime();
                InvalidUserControls(DefMenu);
            }
        }

        private void InvalidDateTime()
        {
            string dateTime = DateTime.Now.ToString(Resource.csDateTimeFormat);

            if (dateTimeStatusLabel.Text != dateTime)
            {
                dateTimeStatusLabel.Text = dateTime;
            }
        }

        private void InvalidUserControls(UlMenu menu)
        {
            if (menu == null) return;

            UlUserControlEng userControl = menu.Controls(menu.Index) as UlUserControlEng;

            userControl.InvalidControl(this, null);
            InvalidUserControls(userControl.DefMenu);
        }

        private bool IsLogin()
        {
            for (int i = 0; i < 3; i++)
            {
                FormUserLogin loginForm = new FormUserLogin();

                loginForm.ShowDialog();
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    Resource.ConfigDB.UserSet.Select(loginForm.UserCombo.Text.Trim());
                    Resource.ConfigDB.UserSet.Fetch();
                    string passwd = Resource.ConfigDB.UserSet.Passwd;
                    //string passwd = Encoding.ASCII.GetString(Convert.FromBase64String(Resource.ConfigDB.UserSet.Passwd));

                    if (loginForm.PasswdEdit.Text == passwd)
                    {
                        Resource.UserNo = Resource.ConfigDB.UserSet.RecNo;
                        Resource.Authority = (EUserAuthority)Resource.ConfigDB.UserSet.Authority;

                        if (loginForm.SaveCheck.Checked == true)
                        {
                            Resource.Ini.SetInteger("Login", "UserNo", Resource.UserNo);
                        }

                        SetAuthority();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid password!\r\nPlease keyin password again!",
                            Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else break;
            }

            return false;
        }

        private void SetAuthority()
        {
            userStatusLabel.Text = Resource.ConfigDB.UserSet.GetName(Resource.UserNo);

            switch (Resource.Authority)
            {
                case EUserAuthority.Maker:
                case EUserAuthority.Admin:
                    viewButton.Left = 64;
                    logButton.Left = 128;
                    loginButton.Left = 1716;

                    testButton.Visible = true;
                    deviceButton.Visible = true;
                    configButton.Visible = true;
                    logoffButton.Visible = true;

                    testMenuItem.Visible = true;
                    deviceMenuItem.Visible = true;
                    configMenuItem.Visible = true;
                    break;

                case EUserAuthority.Operator:
                    viewButton.Left = 64;
                    logButton.Left = 128;
                    loginButton.Left = 1716;

                    testButton.Visible = true;
                    deviceButton.Visible = true;
                    configButton.Visible = false;
                    logoffButton.Visible = true;

                    testMenuItem.Visible = true;
                    deviceMenuItem.Visible = true;
                    configMenuItem.Visible = false;

                    if (DefMenu.Index == 4) DefMenu.Index = 0;
                    break;

                case EUserAuthority.Viewer:
                    viewButton.Left = 0;
                    logButton.Left = 64;
                    loginButton.Left = 1780;

                    testButton.Visible = false;
                    deviceButton.Visible = false;
                    configButton.Visible = false;
                    logoffButton.Visible = false;

                    testMenuItem.Visible = false;
                    deviceMenuItem.Visible = false;
                    configMenuItem.Visible = false;

                    if ((DefMenu.Index != 1) && (DefMenu.Index != 2)) DefMenu.Index = 1;
                    break;
            }
        }

        private void SetUser()
        {
            Resource.UserNo = Resource.Ini.GetInteger("Login", "UserNo");
            Resource.ConfigDB.UserSet.Select(Resource.UserNo);

            if (Resource.ConfigDB.UserSet.GetRowCount() > 0)
            {
                Resource.ConfigDB.UserSet.Fetch();
                Resource.Authority = Resource.ConfigDB.UserSet.Authority;
            }
            else
            {
                Resource.UserNo = -1;
                Resource.Authority = EUserAuthority.Viewer;
            }

            SetAuthority();
        }

        private void DispCaption()
        {
            Text = "H&C System Calorimeter Client Program Ver " + GetVersion();
        }

        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
