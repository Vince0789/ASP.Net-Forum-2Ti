using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

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

	public bool Exists(Member member)
	{
		return dc.Members.Contains(member);
	}

	public bool IsNameInUse(string name)
	{
		Member member = (from Member in dc.Members where Member.Name == name select Member).SingleOrDefault();
		return member != null;
	}

	public int CountAll()
	{
		return dc.Members.Count();
	}

	public Member Create(string name, string unhashedPassword)
	{
		Member newMember = new Member();
		newMember.Name = name;
		newMember.Password = SHA1HashString(unhashedPassword);
		newMember.RegistrationDate = DateTime.Now;

		dc.Members.InsertOnSubmit(newMember);
		dc.SubmitChanges();

		return newMember;
	}

	public Member GetMemberById(int id)
	{
		return (from Member in dc.Members where Member.Id == id select Member).SingleOrDefault();
	}

	public bool Delete(Member member)
	{
		// moderators en mensen die nog posts hebben mogen niet verwijderd worden
		if (member.IsAdmin() || member.Posts.Count != 0 || dc.ForumModerators.Select(fm => fm.Member).Contains(member))
			return false;

		dc.Members.DeleteOnSubmit(member);
		dc.SubmitChanges();
		return true;
	}

	public void PrepareUpdate(int memberId, out Member member)
	{
		member = this.GetMemberById(memberId);
	}

	public void Update()
	{
		dc.SubmitChanges();
	}

	public Member GetNewestMember()
	{
		return dc.Members.OrderByDescending(member => member.RegistrationDate).FirstOrDefault();
	}

	public Member PerformLoginAttempt(string username, string password)
	{
		string hashedPassword = SHA1HashString(password);
		return (from Member in dc.Members where Member.Name == username where Member.Password == hashedPassword select Member).SingleOrDefault();
	}

	public void UpdatePassword(Member member, string password)
	{
		string hashedPassword = SHA1HashString(password);
	}

	public List<Member> FindMembersByName(string query)
	{
		return (from Member in dc.Members where Member.Name.StartsWith(query) orderby Member.Name select Member).ToList();
	}

	public static string SHA1HashString(string s)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(s);

		var sha1 = SHA1.Create();
		byte[] hashBytes = sha1.ComputeHash(bytes);

		return HexStringFromBytes(hashBytes);
	}

	public static string HexStringFromBytes(byte[] bytes)
	{
		var sb = new StringBuilder();
		foreach (byte b in bytes)
		{
			var hex = b.ToString("x2");
			sb.Append(hex);
		}
		return sb.ToString();
	}
}