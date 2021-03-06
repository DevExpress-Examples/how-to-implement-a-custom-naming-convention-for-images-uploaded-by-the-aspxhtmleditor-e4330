﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxHtmlEditor.Localization;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxFileManager;

public partial class SelectDocumentForm : HtmlEditorUserControl {
    protected override void PrepareChildControls() {
        Localize();

        base.PrepareChildControls();

        PrepareFileManager();
    }
    void Localize() {
        SelectButton.Text = ASPxHtmlEditorLocalizer.GetString(ASPxHtmlEditorStringId.ButtonSelect);
        CancelButton.Text = ASPxHtmlEditorLocalizer.GetString(ASPxHtmlEditorStringId.ButtonCancel);
    }
    protected override ASPxEditBase[] GetChildDxEdits() {
        return new ASPxEditBase[] { };
    }
    protected override ASPxButton[] GetChildDxButtons() {
        return new ASPxButton[] { SelectButton, CancelButton };
    }
    protected override ASPxHtmlEditorRoundPanel[] GetChildDxHtmlEditorRoundPanels() {
        return new ASPxHtmlEditorRoundPanel[] { };
    }

    protected void PrepareFileManager() {
        FileManager.Styles.CopyFrom(HtmlEditor.StylesFileManager);
        FileManager.ControlStyle.CopyFrom(HtmlEditor.StylesFileManager.Control);
        FileManager.Images.CopyFrom(HtmlEditor.ImagesFileManager);
        FileManager.Settings.Assign(HtmlEditor.SettingsDocumentSelector.CommonSettings);
        FileManager.SettingsEditing.Assign(HtmlEditor.SettingsDocumentSelector.EditingSettings);
        FileManager.SettingsFolders.Assign(HtmlEditor.SettingsDocumentSelector.FoldersSettings);
        FileManager.SettingsToolbar.Assign(HtmlEditor.SettingsDocumentSelector.ToolbarSettings);
        FileManager.SettingsUpload.Assign(HtmlEditor.SettingsDocumentSelector.UploadSettings);
        FileManager.SettingsPermissions.Assign(HtmlEditor.SettingsDocumentSelector.PermissionSettings);

        FileManager.FolderCreating += new FileManagerFolderCreateEventHandler(FileManager_FolderCreating);
        FileManager.ItemDeleting += new FileManagerItemDeleteEventHandler(FileManager_ItemDeleting);
        FileManager.ItemMoving += new FileManagerItemMoveEventHandler(FileManager_ItemMoving);
        FileManager.ItemRenaming += new FileManagerItemRenameEventHandler(FileManager_ItemRenaming);
        FileManager.FileUploading += new FileManagerFileUploadEventHandler(FileManager_FileUploading);
    }
    protected void FileManager_FolderCreating(object sender, FileManagerFolderCreateEventArgs e) {
        HtmlEditor.RaiseDocumentSelectorFolderCreating(e);
    }
    protected void FileManager_ItemDeleting(object sender, FileManagerItemDeleteEventArgs e) {
        HtmlEditor.RaiseDocumentSelectorItemDeleting(e);
    }
    protected void FileManager_ItemMoving(object sender, FileManagerItemMoveEventArgs e) {
        HtmlEditor.RaiseDocumentSelectorItemMoving(e);
    }
    protected void FileManager_ItemRenaming(object sender, FileManagerItemRenameEventArgs e) {
        HtmlEditor.RaiseDocumentSelectorItemRenaming(e);
    }
    protected void FileManager_FileUploading(object sender, FileManagerFileUploadEventArgs e) {
        HtmlEditor.RaiseDocumentSelectorFileUploading(e);
    }
    protected void FileManager_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e) {
        e.Properties["cp_RootFolderRelativePath"] = FileManager.GetAppRelativeRootFolder();
    }
}