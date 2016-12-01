using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TrustedActivityCreator.View {
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

		private void HideProps(object sender, RoutedEventArgs e) {
			ToggleMenu("storyboardHideProperties", hideProps, showProps, ShowHideProps);
		}

		private void ShowProps(object sender, RoutedEventArgs e) {
			ToggleMenu("storyboardShowProperties", hideProps, showProps, ShowHideProps);
		}

		private void ToggleMenu(string Storyboard, Button hide, Button show, StackPanel panel) {
			Storyboard storyboard = Resources[Storyboard] as Storyboard;
			storyboard.Begin(panel);

			if(hideProps.Visibility == System.Windows.Visibility.Visible) {
				hideProps.Visibility = System.Windows.Visibility.Hidden;
				showProps.Visibility = System.Windows.Visibility.Visible;
			} else if (showProps.Visibility == System.Windows.Visibility.Visible) {
				showProps.Visibility = System.Windows.Visibility.Hidden;
				hideProps.Visibility = System.Windows.Visibility.Visible;
			}

		}
    }
}
