using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace wpfexam1
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)         // StartUp 에는 대리자가 필요하므로 좌측 문장은 항상 필요하다.
        {
            // 메인 윈도우를 초기화하고 보여준다.( Initialize and Show the mainWindow )
            var mainWindow = new MainWindow();
            this.MainWindow = mainWindow;
            mainWindow.Show();

            // mainWindow 의 DataContext 에 ViewModel 을 연결한다. (Connect the ViewModel to DataContext of mainWindow )
            var viewModel = new ViewModel();
            mainWindow.DataContext = viewModel;
        }
    }
}
