using System;
using System.Diagnostics;
using OptionsHelper.Options;
using PKStudio;
using PKStudio.Forms.Options.Options;
using System.IO;

namespace PKStudioLauncher
{
    class Program
    {
        private const string PKStudioLauncherName = "PKStudioLauncher";
        static readonly string OptionsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\options.dat";
        static readonly string PKStudioPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\PKStudio.exe";

        static void Main()
        {
            foreach (var proc in Process.GetProcessesByName(PKStudioLauncherName))
            {
                if (proc.Id != Process.GetCurrentProcess().Id)
                    return;
            }

            var tool = string.Empty;
            var toolPath = string.Empty;
            var toolVersion = string.Empty;
            var pkPath = string.Empty;

            if (File.Exists(OptionsPath))
            {
                var serializer = OptionsSerializer.BackState(OptionsPath);

                foreach (var option in serializer.SOptions)
                {
                    var envOption = option as EnvironmentOption;
                    if (envOption != null)
                    {
                        tool = EnvironmentOption.GetToolString(envOption.Tool);
                        toolPath = envOption.Path;
                        toolVersion = envOption.Version;
                    }

                    var verOption = option as PKVersionOption;
                    if (verOption != null)
                    {
                        pkPath = verOption.PKVersion.Path;
                    }
                }
            }

            var path = "";
            var portingKitRegistryValue = Environment.GetEnvironmentVariable("SPOCLIENT");
            var spoClientPath = "";
            if (string.IsNullOrEmpty(portingKitRegistryValue) || !Directory.Exists(portingKitRegistryValue))
            {
                portingKitRegistryValue = pkPath;
            }
            if (string.IsNullOrEmpty(portingKitRegistryValue) || !Directory.Exists(portingKitRegistryValue))
            {
                portingKitRegistryValue = Helper.GetPortingKitRegistryValue("", "InstallRoot");
            }
            if (!string.IsNullOrEmpty(portingKitRegistryValue) && Directory.Exists(portingKitRegistryValue))
            {
                path = portingKitRegistryValue;
            }

            if (!Directory.Exists(path) || !Directory.Exists(path + @"\DeviceCode\Targets\"))
            {
                using (var of = new SetSPOForm())
                {
                    if (of.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        Console.WriteLine(@".NET Micro Framework Porting Kit directory was not found. Waiting for exit...");
                        Process.GetCurrentProcess().WaitForExit();
                    }
                    else
                    {
                        if (Directory.Exists(path + @"\DeviceCode\Targets\"))
                            spoClientPath = of.Path;
                        else
                        {
                            Console.WriteLine(@".NET Micro Framework Porting Kit directory was not found. Waiting for exit...");
                            Process.GetCurrentProcess().WaitForExit();
                        }
                    }
                }
            }
            else
            {
                Environment.SetEnvironmentVariable("SPOCLIENT", path);
                spoClientPath = path;
            }


            if (spoClientPath.Substring(spoClientPath.Length - 1, 1) != @"\") spoClientPath += @"\";
            path = string.Format("{0}setenv_base.cmd {1} {2} {3}", spoClientPath, tool, toolVersion, toolPath);

            foreach (var proc in Process.GetProcessesByName("PKStudio"))
            {
                Console.WriteLine(@"Another running copy of PKStudio has been detected. Waiting for exit...");
                proc.WaitForExit();
            }
            if (File.Exists(PKStudioPath))
            {
                var process = new Process();
                var info = process.StartInfo;
                info.FileName = Environment.ExpandEnvironmentVariables("%comspec%");
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                if (process.Start())
                {
                    process.StandardInput.WriteLine(path);                    
                    process.StandardInput.WriteLine(PKStudioPath);
                }
            }
            else
            {
                Console.WriteLine(@"PKStudio executable not found.");
            }
        }
    }
}
