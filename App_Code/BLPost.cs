using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLPost
/// </summary>
public class BLPost
{
    protected AspLinqDataContext dc;

    public BLPost()
    {
        dc = new AspLinqDataContext();
    }


}