using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDashDemo
{
	internal class GitUserModelcs
	{
		public string login { get;set; }
		public string avatar_url { get;set; }
		public string repos_url { get; set; }
		public string bio { get; set; }
		public DateTime? created_at { get; set; }

	}
}
