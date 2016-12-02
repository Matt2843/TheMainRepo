﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrustedActivityCreator.View {
	/// <summary>
	/// Interaction logic for TrustedQuickPanelUC.xaml
	/// </summary>
	public partial class TrustedQuickPanelUC : UserControl {
		public TrustedQuickPanelUC() {
			InitializeComponent();
			Reader.MinZoom = 100;
			Reader.MaxZoom = 100;
		}
	}
}
