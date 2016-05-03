using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLMember
/// </summary>
public class BLMember
{
	protected AspLinqDataContext dc;

	public BLMember()
	{
		dc = new AspLinqDataContext();
	}

	public int CountAll()
	{
		return dc.Members.Count();
	}

	public Member GetNewestMember()
	{
		return dc.Members.OrderByDescending(member => member.RegistrationDate).FirstOrDefault();
	}
}