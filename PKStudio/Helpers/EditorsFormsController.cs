using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using PKStudio.Forms.Editors;
using PKStudio.ItemWrappers;
using System.Diagnostics;
using PKStudio.Forms.BaseForms;
//using PKStudio.PKWrapper;

namespace PKStudio.Helpers
{
    /// <summary>
    /// Ru: Класс, содержащий открытие для редоктирования документы.
    /// En: Class contains documents opened for editing
    /// </summary>
    /// <remarks>
    /// Ru: Сериализуемый класс, который используется при загрузче, чтобы узнать, какие компоненты были открыты для редактирования
    /// En: Serializable class used for save and restore opened documents
    /// </remarks>
    [Serializable]
    class OpenedDocumentsList
    {
        private List<string> _files = new List<string>();
        private List<ComponentWrapper> _components = new List<ComponentWrapper>();

        /// <summary>
        /// Ru: Список открытых для редактировани файлов
        /// En: Opened files list
        /// </summary>
        public List<string> Files { get { return _files; } }
        /// <summary>
        /// Ru: Cписок открытых для редактирования компонентов
        /// En: Opened components list
        /// </summary>
        public List<ComponentWrapper> Components { get { return _components; } }



        public void Serialize(OpenedDocumentsList list, string path)
        {
            BinaryFormatter sf = new BinaryFormatter();
            using (FileStream fs = new FileStream
               (path, FileMode.Create, FileAccess.Write))
            {
                sf.Serialize(fs, list);
            }
        }
        public OpenedDocumentsList Deserialize(string path)
        {
            BinaryFormatter sf = new BinaryFormatter();
            OpenedDocumentsList e;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length != 0)
                {
                    e = (OpenedDocumentsList)sf.Deserialize(fs);
                }
                else
                    e = new OpenedDocumentsList();
            }
            return e;
        }
    }

    /// <summary>
    /// Класс, контролирующий все формы редактирования
    /// This class controls all edit forms
    /// </summary>
    public class EditorsFormsController : IDisposable
    {

        public class EditFileDescriptor
        {
            public string Path { get; set; }
            public int Line { get; set; }
            public int Column { get; set; }
        }

        private DockPanel DockPanel;

        SourceFileEditor SFE = null;
        FeatureEditor FE = null;
        LibraryCategoryEditor LCE = null;
        LibraryEditor LE = null;

        private const string FileName = "edlist.dat";

        public EditorsFormsController(DockPanel DockPanel)
        {
            this.DockPanel = DockPanel;
        }


        /// <summary>
        /// Ru: Возвращает Названия активного в текущий момент редактора
        /// En: Returns name of active editor
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string ActivedEditorName
        {
            get
            {
                string res = string.Empty;
                if (DockPanel.ActiveContent != null)
                {
                    if ((DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor)) ||
                        (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.LibraryCategoryEditor)) ||
                        (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.LibraryEditor)) ||
                        (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.FeatureEditor))
                        )
                    {
                        PKStudio.Forms.BaseForms.EditorBaseForm editor = (PKStudio.Forms.BaseForms.EditorBaseForm)DockPanel.ActiveContent;
                        res = editor.EditedItemDesc.Name;
                    }
                }
                return res;
            }
        }


        /// <summary>
        /// Ru: Загружает формы для редактирования из списка
        /// En: Loads edit forms from list from file
        /// </summary>
        public void LoadEditorFormsState()
        {
            //Загрузка редакторов
            OpenedDocumentsList modlist = new OpenedDocumentsList();
            if (File.Exists(Application.StartupPath + "\\" + FileName))
            {
                modlist = modlist.Deserialize(Application.StartupPath + "\\" + FileName);
                foreach (string path in modlist.Files)
                {
                    SFE = new Forms.Editors.SourceFileEditor();
                    SFE.OpenContainingFolderEvent += new EventHandler<Forms.BaseForms.PathEventArgs>(OpenContainingFolderEvent);
                    SFE.SetFile(path);
                    SFE.Show(DockPanel, DockState.Document);
                }
                foreach (ComponentWrapper comp in modlist.Components)
                {
                    this.ShowEditor(comp);
                }
            }
        }

        /// <summary>
        /// Ru: Сохраняет список открытых для редактирования форм
        /// En: Saves edit forms list to file
        /// </summary>
        public void SaveEditorsFormsState()
        {
            PKStudio.Helpers.OpenedDocumentsList modlist = new Helpers.OpenedDocumentsList();

            foreach (DockContent item in DockPanel.Contents)
            {
                if (item.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor))
                {
                    PKStudio.Forms.Editors.SourceFileEditor file = (PKStudio.Forms.Editors.SourceFileEditor)item;
                    modlist.Files.Add(file.EditingFilePath);
                }
                else if (item.GetType() == typeof(PKStudio.Forms.Editors.LibraryCategoryEditor))
                {
                    PKStudio.Forms.Editors.LibraryCategoryEditor editor = (PKStudio.Forms.Editors.LibraryCategoryEditor)item;
                    modlist.Components.Add(ComponentWrapper.GetComponentWrapper(editor.LibraryCategory));
                }
                else if (item.GetType() == typeof(PKStudio.Forms.Editors.LibraryEditor))
                {
                    PKStudio.Forms.Editors.LibraryEditor editor = (PKStudio.Forms.Editors.LibraryEditor)item;
                    modlist.Components.Add(ComponentWrapper.GetComponentWrapper(editor.Library));
                }
                else if (item.GetType() == typeof(PKStudio.Forms.Editors.FeatureEditor))
                {
                    PKStudio.Forms.Editors.FeatureEditor editor = (PKStudio.Forms.Editors.FeatureEditor)item;
                    modlist.Components.Add(ComponentWrapper.GetComponentWrapper(editor.Feature));
                }
            }

            string Path = Application.StartupPath + "\\edlist.dat";

            if (File.Exists(Path))
            {
                FileInfo FI = new FileInfo(Path);

                if ((FI.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    FI.Attributes -= FileAttributes.ReadOnly;

                    modlist.Serialize(modlist, Path);
                }
                else
                {
                    modlist.Serialize(modlist, Path);
                }
            }
            else
            {
                modlist.Serialize(modlist, Path);
            }

            
        }

        /// <summary>
        /// Ru: Проверяет, если ли измененные формы
        /// En: Checks if any edit form have been modified
        /// </summary>
        /// <returns>modifien - true,no modified forms - false</returns>
        public bool CheckModified()
        {
            bool modified = false;
            foreach (DockContent item in DockPanel.Contents)
            {
                EditorBaseForm editor = item as EditorBaseForm;
                if (editor != null)
                {
                    if (editor.Modified)
                    {
                        modified = true;
                        break;
                    }
                }
            }
            return modified;
        }

        /// <summary>
        /// Возвращает список названий всех измененных форм
        /// Returns list of modified forms names
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public List<PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription> ModifiedEditorsList 
        {
            get
            {
                List<PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription> list = new List<PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription>();

                foreach (DockContent item in DockPanel.Contents)
                {
                    EditorBaseForm editor = item as EditorBaseForm;
                    if (editor != null)
                    {
                        if (editor.Modified)
                        {
                            if (editor.Modified)
                                list.Add(editor.EditedItemDesc);
                        }
                    }

                }

                return list;
            }
        }

        protected void ShowLibraryEditorByGuid(string guid)
        {
            bool exist = false;
            foreach (DockContent item in DockPanel.Contents)
            {
                if (item.GetType() == typeof(LibraryEditor))
                {
                    LibraryEditor editor = (LibraryEditor)item;
                    if (editor.Library.Guid == guid)
                    {
                        editor.Show();
                        exist = true;
                    }
                }
            }

            if (!exist)
            {
                LibraryWrapper lib = PK.Wrapper.FindLibrary(guid);
                if (lib != null)
                {
                    LE = new LibraryEditor();
                    LE.OpenContainingFolderEvent +=new EventHandler<Forms.BaseForms.PathEventArgs>(OpenContainingFolderEvent);
                    LE.SetLib(lib);
                    LE.Show(DockPanel, DockState.Document);
                }
            }

        }

        protected void ShowFeatureEditorByGuid(string guid)
        {
            bool exist = false;
            foreach (DockContent item in DockPanel.Contents)
            {
                if (item.GetType() == typeof(FeatureEditor))
                {
                    FeatureEditor editor = (FeatureEditor)item;
                    if (editor.Feature.Guid == guid)
                    {
                        editor.Show();
                        exist = true;
                    }
                }
            }

            if (!exist)
            {
                FeatureWrapper feat = PK.Wrapper.FindFeature(guid);
                if (feat != null)
                {
                    FE = new FeatureEditor();
                    FE.OpenContainingFolderEvent += new EventHandler<Forms.BaseForms.PathEventArgs>(OpenContainingFolderEvent);
                    FE.SetFeat(feat);
                    FE.Show(DockPanel, DockState.Document);
                }
            }
        }

        protected void ShowLibraryCategoryEditorByGuid(string guid)
        {
            bool exist = false;
            foreach (DockContent item in DockPanel.Contents)
            {
                if (item.GetType() == typeof(PKStudio.Forms.Editors.LibraryCategoryEditor))
                {
                    LibraryCategoryEditor editor = (LibraryCategoryEditor)item;
                    if (editor.LibraryCategory.Guid == guid)
                    {
                        editor.Show();
                        exist = true;
                    }
                }
            }

            if (!exist)
            {
                LibraryCategoryWrapper libcat = PK.Wrapper.FindLibraryCategory(guid);
                if (libcat != null)
                {
                    LCE = new LibraryCategoryEditor();
                    LCE.OpenContainingFolderEvent += new EventHandler<Forms.BaseForms.PathEventArgs>(OpenContainingFolderEvent);
                    LCE.SetLibCat(libcat);
                    LCE.Show(DockPanel, DockState.Document);
                }
            }
        }

        /// <summary>
        /// Ru: Открывает редактор для объекта. Если такой уже открыт, то показывает его
        /// En: If object editor has been shown, opens it. I it has not been shown , creates it
        /// </summary>
        /// <param name="obj"></param>
        public void ShowEditor(object obj)
        {
            if (obj is LibraryWrapper)
            {
                LibraryWrapper library = (LibraryWrapper)obj;
                ShowLibraryEditorByGuid(library.Guid);
            }
            else if (obj is FeatureWrapper)
            {
                FeatureWrapper feature = (FeatureWrapper)obj;
                ShowFeatureEditorByGuid(feature.Guid);
            }
            else if (obj is LibraryCategoryWrapper)
            {
                LibraryCategoryWrapper libcat = (LibraryCategoryWrapper)obj;
                ShowLibraryCategoryEditorByGuid(libcat.Guid);
            }
            else if (obj is ComponentWrapper)
            {
                ComponentWrapper comp = (ComponentWrapper)obj;
                switch (comp.ComponentType)
                {
                    case ComponentTypeWrapper.Library:
                        ShowLibraryEditorByGuid(comp.Guid);
                        break;
                    case ComponentTypeWrapper.Feature:
                        ShowFeatureEditorByGuid(comp.Guid);
                        break;
                    case ComponentTypeWrapper.LibraryCategory:
                        ShowLibraryCategoryEditorByGuid(comp.Guid);
                        break;
                    default:
                        break;
                }
            }
            else if (obj is BuildFileWrapper)//En: Need to open file editor Ru: Нужно отрыть редактор файлов
            {
                BuildFileWrapper file = (BuildFileWrapper)obj;
                if(!string.IsNullOrEmpty(file.FullPath) && (File.Exists(file.FullPath)))
                    OpenTextEditor(file.FullPath);
            }
            else if (obj is EditFileDescriptor)
            {
                EditFileDescriptor file = (EditFileDescriptor)obj;
                SourceFileEditor editor = OpenTextEditor(file.Path);
                if (editor != null)
                    editor.GotoLine(file.Line - 1);
            }
        }

        private SourceFileEditor OpenTextEditor(string Path)
        {
            bool exist = false;

            foreach (DockContent item in DockPanel.Contents)
            {
                if (item.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor))
                {

                    PKStudio.Forms.Editors.SourceFileEditor editor = (PKStudio.Forms.Editors.SourceFileEditor)item;

                    if (editor.EditingFilePath == Path)
                    {
                        editor.Show();
                        return editor;
                    }
                }
            }

            if (!exist)
            {
                SFE = new Forms.Editors.SourceFileEditor();
                SFE.OpenContainingFolderEvent += new EventHandler<Forms.BaseForms.PathEventArgs>(OpenContainingFolderEvent);
                if (SFE.SetFile(Path))
                    SFE.Show(DockPanel, DockState.Document);
                return SFE;
            }
            return null;
        }

        /// <summary>
        /// Ru: Сохранить все изменения
        /// En: Save all changes
        /// </summary>
        public void SaveAllModifiedEditors()
        {
            foreach (DockContent item in DockPanel.Contents)
            {
                if ((item.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor)) ||
                    (item.GetType() == typeof(PKStudio.Forms.Editors.LibraryCategoryEditor)) ||
                    (item.GetType() == typeof(PKStudio.Forms.Editors.LibraryEditor)) ||
                    (item.GetType() == typeof(PKStudio.Forms.Editors.FeatureEditor))
                    )
                {
                    PKStudio.Forms.BaseForms.EditorBaseForm editor = (PKStudio.Forms.BaseForms.EditorBaseForm)item;
                    editor.Save();
                }
            }
        }

        /// <summary>
        /// Ru: Сохраняет изменения в активном(который в фокусе) редакторе
        /// En: Save changes in active (focused) editor
        /// </summary>
        public void SaveActiveEditor()
        {
            if ((DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor)) ||
                (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.LibraryCategoryEditor)) ||
                (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.LibraryEditor)) ||
                (DockPanel.ActiveContent.GetType() == typeof(PKStudio.Forms.Editors.FeatureEditor))
                )
            {
                PKStudio.Forms.BaseForms.EditorBaseForm editor = (PKStudio.Forms.BaseForms.EditorBaseForm)DockPanel.ActiveContent;
                if (editor.Modified) editor.Save();
            }
        }


        //private bool Contains(object obj)
        //{
        //    bool res = false;

        //    foreach (DockContent item in DockPanel.Contents)
        //    {
        //        if (item.GetType() == typeof(PKStudio.Forms.Editors.SourceFileEditor))
        //        {

        //            PKStudio.Forms.Editors.SourceFileEditor editor = (PKStudio.Forms.Editors.SourceFileEditor)item;

        //            if (editor.EditingFilePath == file.FullPath)
        //            {
        //                editor.Show();
        //                exist = true;
        //            }
        //        }
        //    }

        //    return res;
        //}

        void OpenContainingFolderEvent(object sender, Forms.BaseForms.PathEventArgs e)
        {
            if (File.Exists(Path.GetFullPath(e.Path)))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + Path.GetFullPath(e.Path) + "\"");
            }
        }




        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (SFE != null) SFE.Dispose();
                if (FE != null) FE.Dispose();
                if (LCE != null) LCE.Dispose();
                if (LE != null) LE.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}
