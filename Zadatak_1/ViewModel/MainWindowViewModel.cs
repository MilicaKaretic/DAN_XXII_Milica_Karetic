using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        #region Properties

        private vwPlayer players;
        public vwPlayer Players
        {
            get
            {
                return players;
            }
            set
            {
                players = value;
                onPropertyChanged("Players");
            }
        }
        private tblPlayer player;
        public tblPlayer Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
                onPropertyChanged("Player");
            }
        }
        private tblCoach coach;
        public tblCoach Coach
        {
            get
            {
                return coach;
            }
            set
            {
                coach = value;
                onPropertyChanged("Coach");
            }
        }
        private tblTeam team;
        public tblTeam Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
                onPropertyChanged("Team");
            }
        }
        private List<vwPlayer> playersList;
        public List<vwPlayer> PlayersList
        {
            get
            {
                return playersList;
            }
            set
            {
                playersList = value;
                onPropertyChanged("PlayersList");
            }
        }

        private List<tblTeam> teamList;
        public List<tblTeam> TeamList
        {
            get
            {
                return teamList;
            }
            set
            {
                teamList = value;
                onPropertyChanged("TeamList");
            }
        }
        private List<tblCoach> coachList;
        public List<tblCoach> CoachList
        {
            get
            {
                return coachList;
            }
            set
            {
                coachList = value;
                onPropertyChanged("CoachList");
            }
        }
        private Visibility viewPlayers = Visibility.Visible;
        public Visibility ViewPlayers
        {
            get
            {
                return viewPlayers;
            }
            set
            {
                viewPlayers = value;
                onPropertyChanged("ViewPlayers");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor with MainWindow parameter
        /// </summary>
        /// <param name="mainOpen">Main window</param>
        public MainWindowViewModel(MainWindow mainOpen)
        {
            Service s = new Service();

            main = mainOpen;
            PlayersList = s.GetAllPlayers().ToList();
            TeamList = s.GetAllTeams().ToList();
            CoachList = s.GetAllCoaches().ToList();

        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="mainOpen">Main window</param>
        /// <param name="resultForEdit">Player view</param>
        public MainWindowViewModel(MainWindow mainOpen, vwPlayer resultForEdit)
        {
            players = resultForEdit;
            main = mainOpen;

            Service s = new Service();

            PlayersList = s.GetAllPlayers().ToList();
            TeamList = s.GetAllTeams().ToList();
            CoachList = s.GetAllCoaches().ToList();
        }
        #endregion

        #region Commands
        private ICommand addPlayer;
        public ICommand AddPlayers
        {
            get
            {
                if (addPlayer == null)
                {
                    addPlayer = new RelayCommand(param => AddPlayersExecute(), param => CanAddPlayersExecute());
                }
                return addPlayer;
            }
        }

        /// <summary>
        /// Add player command
        /// </summary>
        private void AddPlayersExecute()
        {
            try
            {
                AddPlayers addPlayers = new AddPlayers();
                addPlayers.ShowDialog();
                if ((addPlayers.DataContext as AddPlayersViewModel).IsUpdatePlayers == true)
                {
                    Service s = new Service();
                    PlayersList = s.GetAllPlayers().ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can add player command
        /// </summary>
        /// <returns>True or false</returns>
        private bool CanAddPlayersExecute()
        {
            return true;
        }

        private ICommand deletePlayers;
        public ICommand DeletePlayers
        {
            get
            {
                if (deletePlayers == null)
                {
                    deletePlayers = new RelayCommand(param => DeletePlayersExecute(), param => CanDeletePlayersExecute());
                }
                return deletePlayers;
            }
        }

        /// <summary>
        /// Delete player command
        /// </summary>
        private void DeletePlayersExecute()
        {
            try
            {
                if (Players != null)
                {
                    Service s = new Service();

                    int playerID = players.PlayerID;
                    bool isPlayer = s.IsPlayerID(playerID);
                    if (isPlayer == true)
                    {
                        s.DeletePlayers(playerID);
                        PlayersList = s.GetAllPlayers().ToList();
                    }
                    else
                    {
                        MessageBox.Show("Can't delete");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can delete player command
        /// </summary>
        /// <returns>true or false</returns>
        private bool CanDeletePlayersExecute()
        {
            if (Players == null)
                return false;
            else
                return true;
        }

        #endregion
    }
}
