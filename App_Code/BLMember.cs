using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

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

	public Member PerformLoginAttempt(string username, string password)
	{
		string hashedPassword;

		using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
		{
			hashedPassword = sha.ComputeHash(System.Text.Encoding.Default.GetBytes(password)).ToString();
		}
		
		return (from Member in dc.Members where Member.Name == username where Member.Password == hashedPassword select Member).SingleOrDefault();
	}

	public void UpdatePassword(Member member, string password)
	{
		string hashedPassword;

		using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
		{
			hashedPassword = sha.ComputeHash(System.Text.Encoding.Default.GetBytes(password)).ToString();
		}
	}
}