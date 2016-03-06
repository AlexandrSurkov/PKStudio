using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PKStudio.Forms.Options.Options
{
    [Serializable]
    public class EnvironmentOption : OptionsHelper.Options.OptionsBase
    {

        public TOOL Tool { get ; set ; }
        public string Version { get ; set ; }
        public string Path {get; set; }

        public override void OnInitialized()
        {

        }

        [Serializable]
        public enum TOOL : int
        {
            GCC,
            GCC_OP,
            MDK,
            RVDS,
            SHC,
            VS
        }

        public static string GetToolString(TOOL tool)
        {
            var compilerToolVersion = string.Empty;
            switch (tool)
            {
                case TOOL.GCC:
                    compilerToolVersion = "GCC";
                    break;
                case TOOL.GCC_OP:
                    compilerToolVersion = "GCCOP";
                    break;
                case TOOL.MDK:
                    compilerToolVersion = "MDK";
                    break;
                case TOOL.RVDS:
                    compilerToolVersion = "RVDS";
                    break;
                case TOOL.SHC:
                    compilerToolVersion = "SHC";
                    break;
                case TOOL.VS:
                    compilerToolVersion = "VS";
                    break;
            }
            return compilerToolVersion;
        }

        public override bool OnApplyChanges()
        {
            return true;
        }
    }
}
