using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Service
    {
        //view

        /// <summary>
        /// Method for Get All Players from view
        /// </summary>
        /// <returns>List of players</returns>
        public List<vwPlayer> GetAllPlayers()
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    List<vwPlayer> list = new List<vwPlayer>();
                    list = (from x in context.vwPlayers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method for Add new Player
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public vwPlayer AddPlayers(vwPlayer players)
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    if (players.PlayerID == 0)
                    {
                        tblPlayer newPlayer = new tblPlayer
                        {
                            PlayerName = players.PlayerName,
                            Position = players.Position,
                            Number = players.Number,
                            TeamID = (int)players.TeamID
                        };
                        context.tblPlayers.Add(newPlayer);
                        context.SaveChanges();
                        players.PlayerID = newPlayer.PlayerID;
                        return players;
                    }
                    else
                    {
                        tblPlayer playerToEdit = (from r in context.tblPlayers where r.PlayerID == players.PlayerID select r).First();
                        playerToEdit.PlayerName = players.PlayerName;
                        playerToEdit.Position = players.Position;
                        playerToEdit.Number = players.Number;
                        playerToEdit.TeamID = (int) players.TeamID;
                        playerToEdit.PlayerID = players.PlayerID;
                        context.SaveChanges();
                        return players;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Method for Delete Player
        /// </summary>
        /// <param name="playerID">Player id</param>
        public void DeletePlayers(int playerID)
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    tblPlayer playerToDelete = (from r in context.tblPlayers where r.PlayerID == playerID select r).First();
                    context.tblPlayers.Remove(playerToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        //tblTeam

        /// <summary>
        /// Method for Get All Teams 
        /// </summary>
        /// <returns>List of teams</returns>
        public List<tblTeam> GetAllTeams()
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    List<tblTeam> list = new List<tblTeam>();
                    list = (from x in context.tblTeams select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        //tblCoach

        /// <summary>
        /// Method for Get All Coaches 
        /// </summary>
        /// <returns>List of teams</returns>
        public List<tblCoach> GetAllCoaches()
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    List<tblCoach> list = new List<tblCoach>();
                    list = (from x in context.tblCoaches select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        //is id

        /// <summary>
        /// Method to check if there is player with that id
        /// </summary>
        /// <param name="playerID">Player id</param>
        /// <returns>There is or not</returns>
        public bool IsPlayerID(int playerID)
        {
            try
            {
                using (TeamClubEntities context = new TeamClubEntities())
                {
                    int result = (from x in context.vwPlayers where x.PlayerID == playerID select x.PlayerID).FirstOrDefault();

                    if (result != 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                throw;
            }
        }

    }
}
