/*
 * Created by SharpDevelop.
 * User: ferdman.pavel
 * Date: 06.11.2014
 * Time: 14:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QVCacheBuilder.Classes
{
	/// <summary>
	/// Description of Extensions.
	/// </summary>
	public static class Extensions
	{
		public static string GetValue(this System.Windows.Forms.TextBox textBox)
		{
			return (!String.IsNullOrEmpty(textBox.Text))?textBox.Text:String.Empty;
		}

		public static bool IsEmpty(this System.Windows.Forms.TextBox textBox)
		{
			return String.IsNullOrEmpty(textBox.Text);
		}
		
		
	}
}
