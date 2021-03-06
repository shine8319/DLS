﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraRichEdit;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.Utils.About;
using DevExpress.MailDemo.Win;
using DevExpress.MailClient.Win;
using DevExpress.MailClient.Win.Forms;
using DevExpress.Demos;
using DevExpress.Description.Controls;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.Utils.Taskbar;

using ServerProgram;

namespace DevExpress.ProductsDemo.Win {
    public partial class frmMain : RibbonForm, IfmMain
    {
        ModulesNavigator modulesNavigator;
        ZoomManager zoomManager;
        List<BarItem> AllowCustomizationMenuList = new List<BarItem>();
        GuideGenerator guideGenerator;
        public frmMain() {

            TaskbarHelper.InitDemoJumpList(TaskbarAssistant.Default, this);
            InitializeComponent();
            SkinHelper.InitSkinGallery(rgbiSkins);
            RibbonButtonsInitialize();
            modulesNavigator = new ModulesNavigator(ribbonControl1, pcMain);
            zoomManager = new ZoomManager(ribbonControl1, modulesNavigator, beiZoom);
            InitNavBarItemLinks();
            NavigationInitialize();
            SetPageLayoutStyle();
            guideGenerator = new GuideGenerator();
            guideGenerator.CreateWhatsThisItem(ribbonControl1, () => { return this; });


            MainPresenter = new fmMainPresenter(this);
            
        }
        void NavigationInitialize() {
            //foreach (NavBarItemLink link in nbgModules.ItemLinks)
            //{
            //    BarButtonItem item = new BarButtonItem(ribbonControl1.Manager, link.Item.Caption);
            //    item.Tag = link;
            //    item.Glyph = link.Item.SmallImage;
            //    item.ItemClick += new ItemClickEventHandler(item_ItemClick);
            //    bsiNavigation.ItemLinks.Add(item);
            //}
            foreach (NavBarItemLink link in this.navBarGroup1.ItemLinks)
            {
                BarButtonItem item = new BarButtonItem(ribbonControl1.Manager, link.Item.Caption);
                item.Tag = link;
                item.Glyph = link.Item.SmallImage;
                item.ItemClick += new ItemClickEventHandler(item1_ItemClick);
                bsiNavigation.ItemLinks.Add(item);
            }
            foreach (NavBarItemLink link in this.navBarGroup2.ItemLinks)
            {
                BarButtonItem item = new BarButtonItem(ribbonControl1.Manager, link.Item.Caption);
                item.Tag = link;
                item.Glyph = link.Item.SmallImage;
                item.ItemClick += new ItemClickEventHandler(item2_ItemClick);
                bsiNavigation.ItemLinks.Add(item);
            }

        }

        void item_ItemClick(object sender, ItemClickEventArgs e) {
            //nbgModules.SelectedLink = (NavBarItemLink)e.Item.Tag;
        }
        void item1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.navBarGroup1.SelectedLink = (NavBarItemLink)e.Item.Tag;
        }
        void item2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.navBarGroup2.SelectedLink = (NavBarItemLink)e.Item.Tag;
        }
        void RibbonButtonsInitialize() {
            InitBarButtonItem(bbiNewDevice, TagResources.TaskNew, Properties.Resources.NewTaskDescription);
            InitBarButtonItem(bbiEditDevice, TagResources.TaskEdit, Properties.Resources.EditTaskDescription);
            InitBarButtonItem(bbiDeleteDevice, TagResources.TaskDelete, Properties.Resources.DeleteTaskDescription);
            InitBarButtonItem(bbiTodayFlag, FlagStatus.Today, Properties.Resources.FlagTodayDescription);
            InitBarButtonItem(bbiTomorrowFlag, FlagStatus.Tomorrow, Properties.Resources.FlagTomorrowDescription);
            InitBarButtonItem(bbiThisWeekFlag, FlagStatus.ThisWeek, Properties.Resources.FlagThisWeekDescription);
            InitBarButtonItem(bbiNextWeekFlag, FlagStatus.NextWeek, Properties.Resources.FlagNextWeekDescription);
            InitBarButtonItem(bbiNoDateFlag, FlagStatus.NoDate, Properties.Resources.FlagNoDatekDescription);
            InitBarButtonItem(bbiCustomFlag, FlagStatus.Custom, Properties.Resources.FlagCustomDescription);
            InitBarButtonItem(bbiNewContact, TagResources.ContactNew, Properties.Resources.NewContactDescription);
            InitBarButtonItem(bbiEditContact, TagResources.ContactEdit, Properties.Resources.EditContactDescription);
            InitBarButtonItem(bbiDeleteContact, TagResources.ContactDelete, Properties.Resources.DeleteContactDescription);
            InitBarButtonItem(bbiFlipLayout, TagResources.FlipLayout, Properties.Resources.FlipLayoutDescription);
            
            InitBarButtonItem(this.bbiLoginHistorySearch, TagResources.LoginHistorySearch);

            InitBarButtonItem(bbiG02I01, TagResources.G02I01);


            // 세대 정보 등록/수정
            InitBarButtonItem(this.bbiNewSno, TagResources.SnoNew);
            InitBarButtonItem(this.bbiEditSno, TagResources.SnoEdit);
            InitBarButtonItem(this.bbiDeleteSno, TagResources.SnoDelete);

            // 네트워크 관리
            InitBarButtonItem(this.bbiNewDevice, TagResources.DeviceNew);
            InitBarButtonItem(this.bbiEditDevice, TagResources.DeviceEdit);
            InitBarButtonItem(this.bbiDeleteDevice, TagResources.DeviceDelete);
            InitBarButtonItem(this.bbiComSetup, TagResources.ComSetup);

            // 검침
            //InitBarButtonItem(this.bbiStartStopRealtimeStatus, TagResources.StartStopRealtimeStatus);
            InitBarButtonItem(this.bbiReadingStart, TagResources.ReadingStart);
            InitBarButtonItem(this.bbiReadingStop, TagResources.ReadingStop);

            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[0], TagResources.TaskList, Properties.Resources.TaskListDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[1], TagResources.TaskToDoList, Properties.Resources.TaskToDoListDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[2], TagResources.TaskCompleted, Properties.Resources.TaskCompletedDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[3], TagResources.TaskToday, Properties.Resources.TaskTodayDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[4], TagResources.TaskPrioritized, Properties.Resources.TaskPrioritizedDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[5], TagResources.TaskOverdue, Properties.Resources.TaskOverdueDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[6], TagResources.TaskSimpleList, Properties.Resources.TaskSimpleListDescription);
            //InitGalleryItem(rgbiCurrentViewTasks.Gallery.Groups[0].Items[7], TagResources.TaskDeferred, Properties.Resources.TaskDeferredDescription);
            //InitGalleryItem(rgbiCurrentView.Gallery.Groups[0].Items[0], TagResources.ContactList, Properties.Resources.ContactListDescription);
            //InitGalleryItem(rgbiCurrentView.Gallery.Groups[0].Items[1], TagResources.ContactAlphabetical, Properties.Resources.ContactAlphabeticalDescription);
            //InitGalleryItem(rgbiCurrentView.Gallery.Groups[0].Items[2], TagResources.ContactByState, Properties.Resources.ContactByStateDescription);
            //InitGalleryItem(rgbiCurrentView.Gallery.Groups[0].Items[3], TagResources.ContactCard, Properties.Resources.ContactCardDescription);
            bvbiSaveAs.Tag = TagResources.MenuSaveAs;
            bvbiSaveAttachment.Tag = TagResources.MenuSaveAttachment;
            bsiNavigation.Hint = Properties.Resources.NavigationDescription;
            
            AllowCustomizationMenuList.Add(bsiNavigation);
            AllowCustomizationMenuList.Add(rgbiSkins);
            ribbonControl1.Toolbar.ItemLinks.Add(rgbiSkins);
        }

        void InitGalleryItem(GalleryItem galleryItem, string tag, string description) {
            galleryItem.Tag = tag;
            galleryItem.Hint = description;
        }
        internal ZoomManager ZoomManager { get { return zoomManager; } }
        internal BackstageViewButtonItem SaveAsMenuItem { get { return bvbiSaveAs; } }
        internal BackstageViewButtonItem SaveAttachmentMenuItem { get { return bvbiSaveAttachment; } }
        internal InRibbonGallery TaskGallery { get { return rgbiCurrentViewTasks.Gallery; } }
        internal PopupMenu FlagStatusMenu { get { return pmFlagStatus; } }
        void InitBarButtonItem(DevExpress.XtraBars.BarButtonItem buttonItem, object tag) {
            InitBarButtonItem(buttonItem, tag, string.Empty);
        }
        void InitBarButtonItem(DevExpress.XtraBars.BarButtonItem buttonItem, object tag, string description) {
            buttonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(bbi_ItemClick);
            buttonItem.Hint = description;
            buttonItem.Tag = tag;
        }
        void InitNavBarItemLinks() {
            //nbiGrid.Tag = new NavBarGroupTagObject("UserManage", typeof(DevExpress.ProductsDemo.Win.Modules.GridModule));
            //nbiGridCardView.Tag = new NavBarGroupTagObject("NetworkManage", typeof(DevExpress.ProductsDemo.Win.Modules.Contacts));
            //nbiSpreadsheet.Tag = new NavBarGroupTagObject("Spreadsheet", typeof(DevExpress.ProductsDemo.Win.Modules.SpreadsheetModule));
            //nbiWord.Tag = new NavBarGroupTagObject("Word", typeof(DevExpress.ProductsDemo.Win.Modules.WordModule));
            //nbiSnap.Tag = new NavBarGroupTagObject("Snap", typeof(DevExpress.ProductsDemo.Win.Modules.SnapModule));
            //nbiReports.Tag = new NavBarGroupTagObject("Reports", typeof(DevExpress.ProductsDemo.Win.Modules.ReportsModule));
            //nbiPivot.Tag = new NavBarGroupTagObject("Pivot", typeof(DevExpress.ProductsDemo.Win.Modules.PivotModuleNew));
            //nbiCharts.Tag = new NavBarGroupTagObject("Charts", typeof(DevExpress.ProductsDemo.Win.Modules.AnalyticsModule));
            //nbiScheduler.Tag = new NavBarGroupTagObject("Scheduler", typeof(DevExpress.ProductsDemo.Win.Modules.SchedulerModule));
            //nbiPdf.Tag = new NavBarGroupTagObject("PdfViewer", typeof(DevExpress.ProductsDemo.Win.Modules.PdfViewerModule));
            //nbiMaps.Tag = new NavBarGroupTagObject("Maps", typeof(DevExpress.ProductsDemo.Win.Modules.MapsModule));
            //nbgModules.SelectedLinkIndex = 0;

            this.navBarGroup1Item1.Tag = new NavBarGroupTagObject("UserManage", typeof(DevExpress.ProductsDemo.Win.Modules.UserManage));
            this.navBarGroup1Item2.Tag = new NavBarGroupTagObject("LoginHistory", typeof(DevExpress.ProductsDemo.Win.Modules.UserControl1));
            this.navBarGroup1Item3.Tag = new NavBarGroupTagObject("AlamHistory", typeof(DevExpress.ProductsDemo.Win.Modules.AlamHistory));
            this.navBarGroup1Item4.Tag = new NavBarGroupTagObject("AptManage", typeof(DevExpress.ProductsDemo.Win.Modules.AptManage));
            this.navBarGroup1Item5.Tag = new NavBarGroupTagObject("HnoManage", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));
            this.navBarGroup1Item6.Tag = new NavBarGroupTagObject("NetworkManage", typeof(DevExpress.ProductsDemo.Win.Modules.NetworkManage));
            this.navBarGroup1Item7.Tag = new NavBarGroupTagObject("DBManage", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));
            this.navBarGroup1Item8.Tag = new NavBarGroupTagObject("ExternalInterface", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));
            this.navBarGroup1Item9.Tag = new NavBarGroupTagObject("SystemMonitoring", typeof(DevExpress.ProductsDemo.Win.Modules.DataAnalytics));
            //this.navBarGroup1.SelectedLinkIndex = 5;

            this.navBarGroup2Item1.Tag = new NavBarGroupTagObject("G02I01Module", typeof(DevExpress.ProductsDemo.Win.Modules.G02I01Module));
            this.navBarGroup2Item4.Tag = new NavBarGroupTagObject("G02I01Module", typeof(DevExpress.ProductsDemo.Win.Modules.G02I02Module));
            
            //this.navBarGroup2Item2.Visible = false;
            //this.navBarGroup2.SelectedLinkIndex = 0;




            // 검침
            this.navBarGroup3Item1.Tag = new NavBarGroupTagObject("Reading", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));
            //this.navBarGroup3Item1.Tag = new NavBarGroupTagObject("StartStop", typeof(DevExpress.ProductsDemo.Win.Controls.GridRealTime));
            
            this.navBarGroup3.SelectedLinkIndex = 0;

            // 정산
            this.navBarGroup4Item1.Tag = new NavBarGroupTagObject("Sum", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));

            // 도움말
            this.navBarGroup5Item1.Tag = new NavBarGroupTagObject("Help", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));
            this.navBarGroup5Item2.Tag = new NavBarGroupTagObject("Help", typeof(DevExpress.ProductsDemo.Win.Modules.BaseBackup));

        }
        internal void EnableLayoutButtons(bool enabled) {
            bbiFlipLayout.Enabled = enabled;
        }
        internal void EnableEditContact(bool enabled) {
            bbiDeleteContact.Enabled = enabled;
            bbiEditContact.Enabled = enabled;
        }
        internal void EnabledFlagButtons(bool enabledCurrentTask, bool enabledEdit, Task task) {
            List<BarButtonItem> list = new List<BarButtonItem> { bbiTodayFlag, bbiTomorrowFlag, bbiThisWeekFlag, 
                bbiNextWeekFlag, bbiNoDateFlag, bbiCustomFlag };
            foreach(BarButtonItem item in list) {
                item.Enabled = enabledCurrentTask;
                if(task != null)
                    item.Down = task.FlagStatus.Equals(item.Tag);
                else item.Down = false;
            }
            bbiDeleteDevice.Enabled = enabledCurrentTask;
            bbiEditDevice.Enabled = enabledEdit;
        }
        internal void EnableZoomControl(bool enabled) {
            beiZoom.Visibility = enabled ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
        internal void ShowInfo(int? count) {
            if(count == null) bsiInfo.Caption = string.Empty;
            else
                bsiInfo.Caption = string.Format(Properties.Resources.InfoText, count.Value);
            HtmlText = "서버 프로그램"; // string.Format("{0}{1}", GetModuleName(), GetModulePartName());
        }
        string GetModuleName() {
            if(string.IsNullOrEmpty(modulesNavigator.CurrentModule.PartName)) return CurrentModuleName;
            return string.Format("<b>{0}</b>", CurrentModuleName);
        }
        string GetModulePartName() {
            if(string.IsNullOrEmpty(modulesNavigator.CurrentModule.PartName)) return null;
            return string.Format(" - {0}", modulesNavigator.CurrentModule.PartName);
        }

        /// <summary>
        /// 모듈 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarControl1_SelectedLinkChanged(object sender, XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs e) {
            if(e.Link != null)
                modulesNavigator.ChangeSelectedItem(e.Link, null);
        }

        /// <summary>
        /// 리본 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

            if (e.Item.Tag.ToString() == "ReadingStart")
                CommandCenter.ReadingChanged.Execute(e.Item.Tag);
            else if (e.Item.Tag.ToString() == "ReadingStop")
                CommandCenter.ReadingChanged.Execute(e.Item.Tag);
            else
                modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", e.Item.Tag));
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e) {
            modulesNavigator.CurrentModule.SendKeyDown(e);
        }
        private void navBarControl1_NavPaneStateChanged(object sender, EventArgs e) {
            SetPageLayoutStyle();
        }
        private void bvbiExit_ItemClick(object sender, BackstageViewItemEventArgs e) {
            this.Close();
        }

        private void galleryControlGallery1_ItemClick(object sender, GalleryItemClickEventArgs e) {
            modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", e.Item.Tag));
        }

        private void backstageViewControl1_ItemClick(object sender, BackstageViewItemEventArgs e) {
            if(modulesNavigator.CurrentModule == null) return;
            modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", e.Item.Tag));
        }
        void SetPageLayoutStyle() {
            bbiNormal.Down = navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Expanded;
            bbiReading.Down = navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Collapsed;
        }

        private void bbiNormal_ItemClick(object sender, ItemClickEventArgs e) {
            if(bbiNormal.Down) navBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
            else
                bbiNormal.Down = true;
        }

        private void bbiReading_ItemClick(object sender, ItemClickEventArgs e) {
            if(bbiReading.Down) navBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
            else
                bbiReading.Down = true;
        }

        private void rgbiCurrentView_GalleryInitDropDownGallery(object sender, InplaceGalleryEventArgs e) {
            e.PopupGallery.GalleryDropDown.ItemLinks.Add(bbiManageView);
            e.PopupGallery.GalleryDropDown.ItemLinks.Add(bbiSaveCurrentView);
            e.PopupGallery.SynchWithInRibbonGallery = true;
        }

        private void rgbiCurrentViewTasks_GalleryItemClick(object sender, GalleryItemClickEventArgs e) {
            modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", e.Item.Tag));
        }

        private void bvtiPrint_SelectedChanged(object sender, BackstageViewItemEventArgs e) {
            if(backstageViewControl1.SelectedTab == bvtiPrint)
                this.printControl1.InitPrintingSystem();
        }
        private void ribbonControl1_BeforeApplicationButtonContentControlShow(object sender, EventArgs e) {
            if(backstageViewControl1.SelectedTab == bvtiPrint) backstageViewControl1.SelectedTab = bvtiInfo;
            bvtiPrint.Enabled = CurrentRichEdit != null || CurrentPrintableComponent != null;
            bvtiExport.Enabled = CurrentExportComponent != null;
        }
        public IPrintable CurrentPrintableComponent { get { return modulesNavigator.CurrentModule.PrintableComponent; } }
        public IPrintable CurrentExportComponent { get { return modulesNavigator.CurrentModule.ExportComponent; } }
        public RichEditControl CurrentRichEdit { get { return modulesNavigator.CurrentModule.CurrentRichEdit; } }
        public string CurrentModuleName { get { return modulesNavigator.CurrentModule.ModuleName; } }

        private void ribbonControl1_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e) {
            e.CustomizationMenu.InitializeMenu();
            if(e.Link == null || !AllowCustomizationMenuList.Contains(e.Link.Item))
                e.CustomizationMenu.RemoveLink(e.CustomizationMenu.ItemLinks[0]);
        }
        public RibbonStatusBar RibbonStatusBar { get { return ribbonStatusBar1; } }
        internal void ShowReminder(List<Task> reminders) {
            bool allowReminders = reminders != null && reminders.Count > 0;
            bbiReminder.Visibility = allowReminders ? BarItemVisibility.Always : BarItemVisibility.Never;
            bsiTemp.Visibility = allowReminders ? BarItemVisibility.Never : BarItemVisibility.Always;
            if(allowReminders) {
                bbiReminder.Caption = string.Format(Properties.Resources.ReminderText, reminders.Count);
                bbiReminder.Tag = reminders;
            }
        }
        public void ShowInfo(bool visible) {
            bsiInfo.Visibility = bsiTemp.Visibility = visible ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        private void biPrintPreview_ItemClick(object sender, ItemClickEventArgs e) {
            ShowPrintPreview();
        }
        protected void ShowPrintPreview() {
            if(CurrentPrintableComponent == null) return;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            if(modulesNavigator.CurrentModule.AllowRtfTitle) {
                link.RtfReportHeader = @"{\rtf1\ansi\ansicpg1251\deff0\deflang1049{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\qc\lang9\f0\fs32 " + CurrentModuleName + @"\par
}";
            } 
            link.Component = CurrentPrintableComponent;
            link.CreateDocument();
            link.ShowRibbonPreviewDialog(this.LookAndFeel);
        }

        internal void OnModuleShown(BaseModule baseModule) {
            rpgPrint.Visible = CurrentPrintableComponent != null;
        }

        private void bbiReminder_ItemClick(object sender, ItemClickEventArgs e) {
            using(frmReminders frm = new frmReminders()) {
                frm.InitData(bbiReminder.Tag as List<Task>);
                if(frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    modulesNavigator.CurrentModule.FocusObject(frm.CurrentTask);
                    modulesNavigator.CurrentModule.ButtonClick(TagResources.TaskEdit);
                }
            }

        }

        private void bbiColorMixer_ItemClick(object sender, ItemClickEventArgs e) {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void pcMain_Paint(object sender, PaintEventArgs e)
        {

        }


        #region IfmMain

        /// <summary>
        /// 현재 사용 데이터모델을 지정/반환합니다.
        /// </summary>
        public IBaseModel CurrentData { get; set; }

        /// <summary>
        /// 컨트롤러를 지정/반환합니다.
        /// </summary>
        public IfmMainPresenter MainPresenter { get; set; }


        public void ShowMessage(string msg)
        {
            XtraMessageBox.Show(msg, HtmlText, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
