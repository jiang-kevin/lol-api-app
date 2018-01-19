using LolApp.Data;

namespace LolApp.Interfaces
{
    /// <summary>
    /// Represents an instance of the Riot Games API
    /// </summary>
    public interface IRiotApi
    {
        /// <summary>
        /// Returns a Summoner object obtained from the Riot API
        /// </summary>
        /// <param name="region">Region code associated with Summoner</param>
        /// <param name="name">Name of the Summoner</param>
        /// <returns>Summoner object</returns>
        Summoner GetSummonerByName(string region, string name);
    }
}
