using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Battleship.View.UserControls
{
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty SubmitCommandProperty =
            DependencyProperty.Register("SubmitCommand", typeof(ICommand), typeof(OptionsControl), new PropertyMetadata(null));

        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }

        public static readonly DependencyProperty PlayerReadyTextProperty =
            DependencyProperty.Register(
                "PlayerReadyText",
                typeof(string),
                typeof(OptionsControl),
                new PropertyMetadata(default(string)));

        public string PlayerReadyText
        {
            get { return (string)GetValue(PlayerReadyTextProperty); }
            set { SetValue(PlayerReadyTextProperty, value); }
        }

        public static readonly DependencyProperty PlayerReadyForegroundProperty =
            DependencyProperty.Register(
                "PlayerReadyForeground",
                typeof(Brush),
                typeof(OptionsControl),
                new PropertyMetadata(default(Brush)));

        public Brush PlayerReadyForeground
        {
            get { return (Brush)GetValue(PlayerReadyForegroundProperty); }
            set { SetValue(PlayerReadyForegroundProperty, value); }
        }

    }
}