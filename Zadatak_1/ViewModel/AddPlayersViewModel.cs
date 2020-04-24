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
    class AddPlayersViewModel : ViewModelBase
    {
        AddPlayers addPlayers;

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
        private bool isUpdatePlayers;
        public bool IsUpdatePlayers
        {
            get
            {
                return isUpdatePlayers;
            }
            set
            {
                isUpdatePlayers = value;
            }
        }
        //private List<tblCoach> coachList;
        //public List<tblCoach> CoachList
        //{
        //    get
        //    {
        //        return coachList;
        //    }
        //    set
        //    {
        //        coachList = value;
        //        onPropertyChanged("CoachList");
        //    }
        //}
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
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with one parameter AddPlayers
        /// </summary>
        /// <param name="addPlayersOpen">AddPlayers</param>
        public AddPlayersViewModel(AddPlayers addPlayersOpen)
        {
            players = new vwPlayer();
            addPlayers = addPlayersOpen;

            Service s = new Service();

            TeamList = s.GetAllTeams().ToList();

        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="addPlayersOpen">AddPlayers</param>
        /// <param name="playersEdit">Player view</param>
        public AddPlayersViewModel(AddPlayers addPlayersOpen, vwPlayer playersEdit)
        {
            players = playersEdit;
            addPlayers = addPlayersOpen;

            Service s = new Service();

            TeamList = s.GetAllTeams().ToList();

        }
        #endregion

        #region Commands

        private ICommand save;
        /// <summary>
        /// Save command
        /// </summary>
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// Method for saving player
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                Service s = new Service();

                players.TeamID = Team.TeamID;
                s.AddPlayers(Players);
                isUpdatePlayers = true;
                addPlayers.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can save command
        /// </summary>
        /// <returns>True or false</returns>
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(players.PlayerName))
            {
                return false;
            }
            else
                return true;
        }

        private ICommand close;
        /// <summary>
        /// Close command
        /// </summary>
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }

                return close;
            }
        }

        /// <summary>
        /// Execute close command
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addPlayers.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can close command
        /// </summary>
        /// <returns>True or false</returns>
        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion

    }
}
