using System.Windows;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for AddPlayers.xaml
    /// </summary>
    public partial class AddPlayers : Window
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AddPlayers()
        {
            InitializeComponent();
            this.DataContext = new AddPlayersViewModel(this);
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="playersEdit">Player view</param>
        public AddPlayers(vwPlayer playersEdit)
        {
            InitializeComponent();
            this.DataContext = new AddPlayersViewModel(this, playersEdit);
        }
    }
}
