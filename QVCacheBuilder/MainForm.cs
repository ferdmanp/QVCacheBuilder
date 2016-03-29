/*
 * Created by SharpDevelop.
 * User: ferdman.pavel
 * Date: 06.11.2014
 * Time: 13:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QVCacheBuilder.Classes;
using System.Linq;

namespace QVCacheBuilder
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		BindingList<string> _fieldList= new BindingList<string>();
		QVAppHelper qvapp;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			qvapp= new QVAppHelper();
			RefreshListBoxFields();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string DocPath=textBox1.Text;
			qvapp.IndexExpansion(DocPath,_fieldList.ToList());
			
		}
		void BtnAddFieldClick(object sender, EventArgs e)
		{
			if(!tbFieldName.IsEmpty())
			{
				_fieldList.Add(tbFieldName.GetValue());			
				RefreshListBoxFields();
				tbFieldName.Clear();
			}
		}
		
		void RefreshListBoxFields()
		{
			lbFields.DataSource=_fieldList;
			if(_fieldList.Count>0)
				lbFields.SelectedIndex=_fieldList.Count-1;
		}
		void BtnRemoveFieldClick(object sender, EventArgs e)
		{
			if(_fieldList.Count>0)
			{
				_fieldList.RemoveAt(lbFields.SelectedIndex);
				RefreshListBoxFields();
			}
			
		}
	}
}
