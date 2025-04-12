# QQScreenShotLauncher

项目的实现过程参考 [QQ 截图启动器](https://acomma.github.io/2025/03/29/qq-screen-shot-launcher/)。项目使用的开发工具为 [Visual Studio 2022](https://visualstudio.microsoft.com/zh-hans/vs/)，采用基于 .NET 8.0 的 [WinForms](https://learn.microsoft.com/zh-cn/dotnet/desktop/winforms/?view=netdesktop-8.0) 技术开发。

目前只实现了 QQ 截图功能：点击托盘图标截图、快捷键截图，和清空截图缓存功能。

## 使用说明

1. 下载新版 QQ，比如 [QQ_9.9.18_250401_x64_01.exe](https://dldir1.qq.com/qqfile/qq/QQNT/Windows/QQ_9.9.18_250401_x64_01.exe)，并安装。
2. 从 [Releases](https://github.com/acomma/QQScreenShotLauncher/releases) 下载本软件，解压到任意目录，比如 *D:\Program Files*。
3. 双击 *NTLauncher.exe* 启动，在设置对话框中勾选*启用QQ截图*、*启用热键*，配置 *QQScreenshot.exe* 路径，比如 *C:\Program Files\Tencent\QQNT\versions\9.9.18-33800\resources\app\QQScreenShot\BinRelease-x64\QQScreenshot.exe*。
4. 也可以把 *C:\Program Files\Tencent\QQNT\versions\9.9.18-33800\resources\app\QQScreenShot* 整个目录拷贝到 *D:\Program Files*，从而简化配置为 *D:\Program Files\QQScreenShot\BinRelease-x64\QQScreenshot.exe*，然后你可以自由的卸载 QQ 而不影响截图。
5. 设置完成后点击*确定*按钮以保存配置，重启软件使配置生效。
