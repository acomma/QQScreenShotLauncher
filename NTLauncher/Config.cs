using System.Runtime.InteropServices;
using System.Text;

namespace NTLauncher
{
    public class Config
    {
        public string QQScreenShot { get; set; }
        public string UsrLib { get; set; }
        public string WeChatOCR { get; set; }
        public string WeChatUtility { get; set; }
        public string AutoExitClear { get; set; }
        public string AutoNTVOpen { get; set; }
        public string AutoRun { get; set; }
        public string DebugConsole { get; set; }
        public string EnableHotKey { get; set; }
        public string EnableOCR { get; set; }
        public string EnablePlugin { get; set; }
        public string EnableScreenShot { get; set; }
        public string EnableUtility { get; set; }
        public string FisrtRun { get; set; }
        public string HotKey { get; set; }
        public string KillXPlugin { get; set; }
        public string RunTip { get; set; }
        public string ScrollVol { get; set; }
        public string DbgConsole { get; set; }
        public string LaunchShow { get; set; }
        public string CurOCR { get; set; }
        public string CurSearch { get; set; }
        public string CurSoutu { get; set; }
        public string CurTran { get; set; }
        public string PluginDir { get; set; }
        public string PythonDir { get; set; }
    }

    public class ConfigHandler
    {
        private string filePath;

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        public ConfigHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(Config config)
        {
            // ExePath
            WritePrivateProfileString("ExePath", "QQScreenShot", config.QQScreenShot, this.filePath);
            WritePrivateProfileString("ExePath", "UsrLib", config.UsrLib, this.filePath);
            WritePrivateProfileString("ExePath", "WeChatOCR", config.WeChatOCR, this.filePath);
            WritePrivateProfileString("ExePath", "WeChatUtility", config.WeChatUtility, this.filePath);

            // General
            WritePrivateProfileString("General", "AutoExitClear", config.AutoExitClear, this.filePath);
            WritePrivateProfileString("General", "AutoNTVOpen", config.AutoNTVOpen, this.filePath);
            WritePrivateProfileString("General", "AutoRun", config.AutoRun, this.filePath);
            WritePrivateProfileString("General", "DebugConsole", config.DebugConsole, this.filePath);
            WritePrivateProfileString("General", "EnableHotKey", config.EnableHotKey, this.filePath);
            WritePrivateProfileString("General", "EnableOCR", config.EnableOCR, this.filePath);
            WritePrivateProfileString("General", "EnablePlugin", config.EnablePlugin, this.filePath);
            WritePrivateProfileString("General", "EnableScreenShot", config.EnableScreenShot, this.filePath);
            WritePrivateProfileString("General", "EnableUtility", config.EnableUtility, this.filePath);
            WritePrivateProfileString("General", "FisrtRun", config.FisrtRun, this.filePath);
            WritePrivateProfileString("General", "HotKey", config.HotKey, this.filePath);
            WritePrivateProfileString("General", "KillXPlugin", config.KillXPlugin, this.filePath);
            WritePrivateProfileString("General", "RunTip", config.RunTip, this.filePath);
            WritePrivateProfileString("General", "ScrollVol", config.ScrollVol, this.filePath);

            // NTViewer
            WritePrivateProfileString("NTViewer", "DbgConsole", config.DbgConsole, this.filePath);
            WritePrivateProfileString("NTViewer", "LaunchShow", config.LaunchShow, this.filePath);

            // Plugin
            WritePrivateProfileString("Plugin", "CurOCR", config.CurOCR, this.filePath);
            WritePrivateProfileString("Plugin", "CurSearch", config.CurSearch, this.filePath);
            WritePrivateProfileString("Plugin", "CurSoutu", config.CurSoutu, this.filePath);
            WritePrivateProfileString("Plugin", "CurTran", config.CurTran, this.filePath);
            WritePrivateProfileString("Plugin", "PluginDir", config.PluginDir, this.filePath);
            WritePrivateProfileString("Plugin", "PythonDir", config.PythonDir, this.filePath);
        }

        public Config Read()
        {
            Config config = new Config();

            // ExePath

            StringBuilder retVal = new StringBuilder(255);
            GetPrivateProfileString("ExePath", "QQScreenShot", "", retVal, 255, this.filePath);
            config.QQScreenShot = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("ExePath", "UsrLib", "", retVal, 255, this.filePath);
            config.UsrLib = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("ExePath", "WeChatOCR", "", retVal, 255, this.filePath);
            config.WeChatOCR = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("ExePath", "WeChatUtility", "", retVal, 255, this.filePath);
            config.WeChatUtility = retVal.ToString();

            // General

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "AutoExitClear", "false", retVal, 255, this.filePath);
            config.AutoExitClear = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "AutoNTVOpen", "false", retVal, 255, this.filePath);
            config.AutoNTVOpen = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "AutoRun", "false", retVal, 255, this.filePath);
            config.AutoRun = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "DebugConsole", "false", retVal, 255, this.filePath);
            config.DebugConsole = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "EnableHotKey", "false", retVal, 255, this.filePath);
            config.EnableHotKey = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "EnableOCR", "false", retVal, 255, this.filePath);
            config.EnableOCR = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "EnablePlugin", "false", retVal, 255, this.filePath);
            config.EnablePlugin = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "EnableScreenShot", "false", retVal, 255, this.filePath);
            config.EnableScreenShot = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "EnableUtility", "false", retVal, 255, this.filePath);
            config.EnableUtility = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "FisrtRun", "true", retVal, 255, this.filePath);
            config.FisrtRun = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "HotKey", "CTRL+ALT+A", retVal, 255, this.filePath);
            config.HotKey = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "KillXPlugin", "false", retVal, 255, this.filePath);
            config.KillXPlugin = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "RunTip", "true", retVal, 255, this.filePath);
            config.RunTip = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("General", "ScrollVol", "false", retVal, 255, this.filePath);
            config.ScrollVol = retVal.ToString();

            // NTViewer

            retVal = new StringBuilder(255);
            GetPrivateProfileString("NTViewer", "DbgConsole", "false", retVal, 255, this.filePath);
            config.DbgConsole = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("NTViewer", "LaunchShow", "false", retVal, 255, this.filePath);
            config.LaunchShow = retVal.ToString();

            // Plugin

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "CurOCR", "NULL", retVal, 255, this.filePath);
            config.CurOCR = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "CurSearch", ".\\ntplugin\\baidusearch.py", retVal, 255, this.filePath);
            config.CurSearch = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "CurSoutu", ".\\ntplugin\\baidusoutu.py", retVal, 255, this.filePath);
            config.CurSoutu = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "CurTran", ".\\ntplugin\\youdaotran.py", retVal, 255, this.filePath);
            config.CurTran = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "PluginDir", ".\\ntplugin", retVal, 255, this.filePath);
            config.PluginDir = retVal.ToString();

            retVal = new StringBuilder(255);
            GetPrivateProfileString("Plugin", "PythonDir", ".\\pyenv", retVal, 255, this.filePath);
            config.PythonDir = retVal.ToString();

            return config;
        }
    }
}
