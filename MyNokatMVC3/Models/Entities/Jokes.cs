using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNokatMVC3.Models.Entities
{
    public partial class Jokes
    {
        public string UserName { get; set; }
        public int UpVotesCount { get; set; }
        public int DownVotesCount { get; set; }
        public string UserVoteType { get; set; }
    }
}