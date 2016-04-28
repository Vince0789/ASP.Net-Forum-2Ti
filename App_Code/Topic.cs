using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Topic
/// </summary>
public partial class Topic
{
    protected User author;
    protected Post eerstePost;
    protected Post laatstePost;

    public User Author
    {
        get;
        set;
    }

    public Post EerstePost
    {
        get;
        set;
    }

    public Post LaatstePost
    {
        get;
        set;
    }
}