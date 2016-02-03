using System;
using System.Windows.Forms;
using PKStudio.ItemWrappers;
using PKStudio.Forms.BaseForms;
using PKStudio.Forms.BaseForms.ComponentEditor;

namespace PKStudio.Forms.Editors
{
    public partial class FeatureEditor : BaseForms.ComponentEditor.ComponentEditorBaseForm
    {
        public FeatureEditor()
            :base()
        {
            InitializeComponent();

            PK.Wrapper.LoadFeaturesAsyncCompleteEvent += new EventHandler(PKWrapper_LoadFeaturesAsyncCompleteEvent);
        }

        private FeatureWrapper Feat;

        /// <summary>
        /// Sets Feature for edition
        /// </summary>
        /// <param name="LibCat"></param>
        public void SetFeat(FeatureWrapper Feat)
        {
            UpdateForm(Feat);
        }

        private void UpdateForm(FeatureWrapper Feat)
        {
            FormText = Strings.Feature + " : " + Feat.Name;
            ModifiedFormText = FormText + "*";

            this.Feat = Feat;
            if (Feat.Filter == null) Feat.Filter = "";

            this.Pages.Clear();

            this.Pages.Add(new Editors.Pages.Feature.MainPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.DescriptionPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.DocumentationPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.FilterPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.FlagsPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.ComponentDependenciesPage(Feat));
            this.Pages.Add(new Editors.Pages.Feature.FeatureDependenciesPage(Feat));

            //this.Pages.Add(new Editors.Pages.Library.ProcessorSpecificPage(Lib));
            foreach (EditorPageBase page in this.Pages)
            {
                IEventComponent icomp = page as IEventComponent;
                if (icomp != null)
                {
                    icomp.SelectionChangedEvent += new EventHandler<ObjectEventArgs>(icomp_SelectionChangedEvent);
                }
            }

           this.Initialize();

            SetModified(false);
        }

        void icomp_SelectionChangedEvent(object sender, ObjectEventArgs e)
        {
            OnSelectionChangeEvent(e.Object);
        }

        
        public override EditedComponentDescription EditedItemDesc
        {
            get
            {
                return new EditedComponentDescription() { Type = EditedComponentDescription.ComponentType.Feature, Name = Feat.Name };
            }
        }

        public FeatureWrapper Feature { get { return this.Feat; } }

        public override void Save()
        {
            //try
            //{
            //    ApplyChanges();
            //    PK.Wrapper.SaveFeatureProj(this.Feat);
            //    SetModified(false);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        void PKWrapper_LoadFeaturesAsyncCompleteEvent(object sender, EventArgs e)
        {
            if (this.Feat != null)
                this.SetFeat(PK.Wrapper.FindFeature(this.Feat.Guid));
        }
    }
}
