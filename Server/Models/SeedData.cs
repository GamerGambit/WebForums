using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

using System;
using System.Threading.Tasks;

using WebForums.Server.Data;

namespace WebForums.Server.Models
{
	public static class SeedData
	{
		public static async Task InitializeAsync(IServiceProvider serviceProvider)
		{
			using var context = new WebForumsContext(serviceProvider.GetRequiredService<DbContextOptions<WebForumsContext>>());

			if (
				await context.Category.AnyAsync() ||
				await context.Forum.AnyAsync() ||
				await context.Post.AnyAsync() ||
				await context.Thread.AnyAsync() ||
				await context.User.AnyAsync()
				)
				return;

			// Seed users and categories
			await context.AddRangeAsync(
				#region Users
				new User
				{
					Username = "Alan Turing"
				},

				new User
				{
					Username = "Dennis Ritchie"
				},

				new User
				{
					Username = "John Carmack"
				},

				new User
				{
					Username = "Bill Gates"
				},
				#endregion Users

				#region Categories
				new Category
				{
					Title = "Forums"
				},

				new Category
				{
					Title = "Hardware and Software"
				},

				new Category
				{
					Title = "Games"
				},

				new Category
				{
					Title = "Developers"
				}
				#endregion Categories
				);

			await context.SaveChangesAsync();

			// Seed forums, which require categories
			await context.AddRangeAsync(
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Forums"),
					Title = "General Discussion",
					Description = "Post stuff that first in no other section"
				},

				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Forums"),
					Title = "Sensationalist Headlines",
					Description = "New gets more informative the more outraged you are by it"
				},

				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Hardware and Software"),
					Title = "Hardware and Software - General Discussion",
					Description = "Hardware, Software .. all kinds of wares. Except actual warez. Cuz that gets you banned."
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Hardware and Software"),
					Title = "Technical Support",
					Description = "Have you tried rebooting stopped being funny in 2007"
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Games"),
					Title = "General Games Discussion",
					Description = "I bet you can't guess what you're meant to talk about in here."
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Developers"),
					Title = "Programming",
					Description = "Forum related to programming languages other than GMod Lua"
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Developers"),
					Title = "Web Development",
					Description = "HTML, PHP, ASP, Javascript, etc.."
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Developers"),
					Title = "Mapping",
					Description = "No - we don't know how to make water."
				},
				
				new Forum
				{
					Category = await context.Category.FirstAsync(c => c.Title == "Developers"),
					Title = "Modelling",
					Description = "For your modelling/animation/skinning needs"
				});

			await context.SaveChangesAsync();

			// Seed threads, which require forums and users
			await context.AddRangeAsync(
				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Programming"),
					Title = "WAYWO",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Programming"),
					Title = "WDYNHW",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Web Development"),
					Title = "WAYWO",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Web Development"),
					Title = "WDYNHW",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Mapping"),
					Title = "WAYWO",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Mapping"),
					Title = "WDYNHW",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Modelling"),
					Title = "WAYWO",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				},

				new Thread
				{
					Forum = await context.Forum.FirstAsync(c => c.Title == "Modelling"),
					Title = "WDYNHW",
					Starter = await context.User.OrderBy(u => Guid.NewGuid()).Take(1).FirstAsync()
				});

			await context.SaveChangesAsync();

			// Seed posts, which require threads and users
			// I'm going to take a shortcut here and just generate some posts for WAYWO and WDYNHW.

			// Find the thread starters for the WAYWO/WDYNHW threads so we can make the first post from the same person who started the thread
			var pwaywo = await context.Thread.FirstAsync(t => t.Forum.Title == "Programming" && t.Title == "WAYWO");
			var pwdynhw = await context.Thread.FirstAsync(t => t.Forum.Title == "Programming" && t.Title == "WDYNHW");
			var wdwaywo = await context.Thread.FirstAsync(t => t.Forum.Title == "Web Development" && t.Title == "WAYWO");
			var wdwdynhw = await context.Thread.FirstAsync(t => t.Forum.Title == "Web Development" && t.Title == "WDYNHW");
			var mapwaywo = await context.Thread.FirstAsync(t => t.Forum.Title == "Mapping" && t.Title == "WAYWO");
			var mapwdynhw = await context.Thread.FirstAsync(t => t.Forum.Title == "Mapping" && t.Title == "WDYNHW");
			var modwaywo = await context.Thread.FirstAsync(t => t.Forum.Title == "Modelling" && t.Title == "WAYWO");
			var modwdynhw = await context.Thread.FirstAsync(t => t.Forum.Title == "Modelling" && t.Title == "WDYNHW");

			await context.Post.AddRangeAsync(
				new Post
				{
					Thread = pwaywo,
					Poster = pwaywo.Starter,
					Content = "Welcome to the Programming \"What Are You Working On\" thread! Post your current WIPs here."
				},

				new Post
				{
					Thread = pwdynhw,
					Poster = pwdynhw.Starter,
					Content = "Welcome to the Programming \"What Do You Need Help With\" thread! Post your current failures here."
				},

				new Post
				{
					Thread = wdwaywo,
					Poster = wdwaywo.Starter,
					Content = "Welcome to the Web Development \"What Are You Working On\" thread! Post your current WIPs here."
				},

				new Post
				{
					Thread = wdwdynhw,
					Poster = wdwdynhw.Starter,
					Content = "Welcome to the Web Development \"What Do You Need Help With\" thread! Post your current failures here."
				},

				new Post
				{
					Thread = mapwaywo,
					Poster = mapwaywo.Starter,
					Content = "Welcome to the Mapping \"What Are You Working On\" thread! Post your current WIPs here."
				},

				new Post
				{
					Thread = mapwdynhw,
					Poster = mapwdynhw.Starter,
					Content = "Welcome to the Mapping \"What Do You Need Help With\" thread! Post your current failures here."
				},

				new Post
				{
					Thread = modwaywo,
					Poster = modwaywo.Starter,
					Content = "Welcome to the Modelling \"What Are You Working On\" thread! Post your current WIPs here."
				},

				new Post
				{
					Thread = modwdynhw,
					Poster = modwdynhw.Starter,
					Content = "Welcome to the Modelling \"What Do You Need Help With\" thread! Post your current failures here."
				});

			await context.SaveChangesAsync();
		}
	}
}
