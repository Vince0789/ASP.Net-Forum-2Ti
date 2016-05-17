using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumModerator
/// </summary>
public partial class ForumModerator
{
    public ForumModerator(Forum forum, Member member)
    {
        this.ForumId = forum.Id;
        this.MemberId = member.Id;
        this.Forum = forum;
        this.Member = member;
    }
}