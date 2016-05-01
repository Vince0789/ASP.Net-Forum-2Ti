using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Topic
/// </summary>
public partial class Topic
{
    protected Member author;
    protected Post eerstePost;
    protected Post laatstePost;

    public Post EerstePost
    {
        get
        {
            this.Posts.OrderBy(post => post.CreatedDate);
            return this.Posts.First();
        }
    }

    public Post LaatstePost
    {
        get
        {
            this.Posts.OrderBy(post => post.CreatedDate);
            return this.Posts.Last();
        }
    }
}