using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Models.Abstract
{
    public interface IVotesRepository
    {
        int GetJokesVotesCount(int pJokeId, bool pType);
        string GetCurrentUserVote(int pJokeId, long pUserId);
        bool AddVote(int pJokeId, long pUserId,bool pVoteType);
    }
}