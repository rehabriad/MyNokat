using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Models.Concrete
{
    public class VotesRepository : IVotesRepository
    {
        NokatModelContainer container;
        public int GetJokesVotesCount(int pJokeId, bool pType)
        {
            int ret = 0;

            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                ret = container.Votes.Count(i => i.JokeId == pJokeId && i.VoteType == pType);
            }
            catch
            {
            }
            return ret;

        }


        public string GetCurrentUserVote(int pJokeId, long pUserId)
        {
            string ret =null;

            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                var result = container.Votes.Where(i => i.JokeId == pJokeId && i.UserId==pUserId).Select(i=>i.VoteType).First();
                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch
            {
            }
            return ret;
        }

        public bool AddVote(int pJokeId, long pUserId, bool pVoteType)
        {
            bool ret = false;

            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }
                
                var result = container.Votes.Where(i => i.JokeId == pJokeId && i.UserId == pUserId).FirstOrDefault();
                if (result == null)
                {
                    container.AddToVotes(new Votes(){  JokeId=pJokeId,UserId=pUserId,VoteType=pVoteType});
                    container.SaveChanges();
                }
                else if(result.VoteType!=pVoteType)
                {
                    result.VoteType=pVoteType;
                    container.SaveChanges();
                }
                ret=true;
            }
            catch
            {
            }
            return ret;
        }
    }
}