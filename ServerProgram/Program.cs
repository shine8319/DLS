﻿using System;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.MailClient.Win;
using DevExpress.MailDemo.Win;
using DevExpress.ProductsDemo.Win.Forms;
using DevExpress.ProductsDemo.Win.Controls;
using DevExpress.ProductsDemo.Win.Common;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using ServerProgram.DB;

namespace DevExpress.ProductsDemo.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments) {
            WindowsFormsSettings.ApplyDemoSettings();
            //new DevExpress.DemoReports.ConnectionStringConfigurator(System.Configuration.ConfigurationManager.ConnectionStrings)
            //    .SelectDbEngine()
            //    .ExpandDataDirectory(fileName => DevExpress.DemoData.Helpers.DataFilesHelper.FindFile(fileName, DevExpress.DemoData.Helpers.DataFilesHelper.DataPath));

            //string path = DevExpress.Utils.FilesHelper.FindingFileName(AppDomain.CurrentDomain.BaseDirectory, @"Data\NWind.mdf", false);
            //XtraReportsDemos.ConnectionHelper.ApplyDataDirectory(System.IO.Path.GetDirectoryName(path));

            DataHelper.ApplicationArguments = arguments;

            
            //System.Globalization.CultureInfo enUs = new System.Globalization.CultureInfo("en-US");
            //System.Threading.Thread.CurrentThread.CurrentCulture = enUs;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = enUs;
            DevExpress.Utils.LocalizationHelper.SetCurrentCulture(DataHelper.ApplicationArguments);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 8);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Light");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Black");
            SkinManager.EnableFormSkins();
            EnumProcessingHelper.RegisterEnum<TaskStatus>();


            //SplashScreenManager.ShowForm(null, typeof(ssMain), true, true, false, 1000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            fmLogin login = new fmLogin();
            Application.Run(login);

            if( login.DialogResult == DialogResult.OK )
            {
                //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

                Application.Run(new frmMain());

                MySqlManage db = new MySqlManage(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);

                string sql = string.Format("insert into amr_iqr03 values('{0}', '{1}', '1234', '{2}')", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), login.User, 14);
                db.InsertMariaDB(db.Connection, sql);

                db.Dispose();

            }

            
        }
    }
}
