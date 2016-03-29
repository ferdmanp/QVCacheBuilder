/*
 * Created by SharpDevelop.
 * User: ferdman.pavel
 * Date: 10.11.2014
 * Time: 17:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq;

namespace QVCacheBuilder.Classes
{
	
	public static class QVCommands
	{
		public const string ActivateSheet				=	@"ActivateSheet";
		public const string FieldsCollection			=	@"Fields";
		public const string Select						=	@"Select";
		public const string Count						=	@"Count";
		public const string PossibleValues				=	@"GetPossibleValues";
		public const string AlternativeValues			=	@"GetAlternativeValues";
		public const string	Item						=	@"Item";
		public const string	Text						=	@"Text";
		public const string	Clear						=	@"Clear";
		public const string Selections					=	@"GetSelectedValues";
		public const string GetSheetCount				=	@"NoOfSheets";
		
	}
	
	/// <summary>
	/// Description of QVComWrapper.
	/// </summary>
	public class QVApp 
	{
				
		private object _appInstance;

		public object AppInstance {
			get {
				return _appInstance;
			}
		}
		
		public object Application { 
			get {
				return this.SendCommandAndGetObject(_appInstance,@"GetApplication",new object[0]);
			}
		}
		
		public QVApp(object QVInstance)
		{
			this._appInstance=QVInstance;
		}
		
		
		
		/// <summary>
		/// Отправка команды в QV
		/// </summary>
		/// <param name="ObjectInstance">инстанс объекта, который получает команду</param>
		/// <param name="CommandText" type="System.String">текст команды</param>
		/// <param name="ArgumentsArray">параметры комады</param>
		private void SendCommand(object ObjectInstance, string CommandText, object[] ArgumentsArray)
		{
			try {
				
				//NewLateBinding.LateCall(ObjectInstance, null, CommandText, ArgumentsArray, null, null, new []{true}, true);
				NewLateBinding.LateCall(ObjectInstance, null, CommandText, ArgumentsArray, null, null, null, true);
				//NewLateBinding.LateCall(objField,null,"Clear",new object[0],null,null,null,true );
				
			} catch (COMException ex) {
				
				throw new Exception(ex.Message);
			}
		}
		
		
		private void SendCommand(object ObjectInstance, string CommandText)
		{
			this.SendCommand(ObjectInstance,CommandText, new object[0]);
		}
		
		private object SendCommandAndGetObject(object ObjectInstance, string CommandText, object[]  ArgumentsArray)
		{
			object obj;
			
			try {
				
				 obj=NewLateBinding.LateGet(ObjectInstance,null, CommandText, ArgumentsArray,null,null,null);
				
				
			} catch (COMException ex) {
				
				throw new Exception(ex.Message);
			}
			
			return obj;
		}
		
//		private object SendCommandAndGetObject(object ObjectInstance, string CommandText, params object[] CommandParams)
//		{
//			return this.SendCommandAndGetObject(ObjectInstance,CommandText,CommandParams);
//		}
		
		private object SendCommandAndGetObject(object ObjectInstance, string CommandText)
		{
			return this.SendCommandAndGetObject(ObjectInstance,CommandText,new object[0]);
		}
		
		#region Sheet
		
		/// <summary>
		/// Активация листа.
		/// </summary>		
		/// <param name="SheetId">Id листа</param>
		/// <returns>Экземпляр листа</returns>
		public object ActivateSheet(string SheetId)
		{				
			return SendCommandAndGetObject(this._appInstance,QVCommands.ActivateSheet,new object[] {SheetId});			

		}
		
		#endregion
		
		#region Fields
		
		
		public object GetField(string FieldName)
		{
			return SendCommandAndGetObject(this._appInstance,QVCommands.FieldsCollection,new object[]{FieldName});
		}
		
		public void ClearField(object FieldObject)
		{
			SendCommand(FieldObject,QVCommands.Clear);
		}
		
		
		public int GetCollectionCount(object CollectionObject)
		{
			return (int)RuntimeHelpers.GetObjectValue(SendCommandAndGetObject(CollectionObject,QVCommands.Count));
		}
		
		public object GetCollectionItem(object CollectionObject, int index)
		{
			return SendCommandAndGetObject(CollectionObject,QVCommands.Item,new object[]{index});
		}
		
		public string GetCollectionItemText(object CollectionItemObject)
		{
			return SendCommandAndGetObject(CollectionItemObject,QVCommands.Text).ToString();
		}
		
		public List<string> GetFieldValueList(string FieldName)
		{
			return GetFieldValueList(FieldName,1000);
		}
		
		public List<string> GetFieldValueList(string FieldName, int? maxLimit)
		{
			var _lstReturn = new List<string>();
			
			var _field=this.GetField(FieldName);		
			
			var _possibleVals=this.SendCommandAndGetObject(_field,QVCommands.PossibleValues,new object[]{maxLimit});
			
			var _cnt=RuntimeHelpers.GetObjectValue(SendCommandAndGetObject(_possibleVals,QVCommands.Count));
			
			for(int i=0;i<(int)_cnt;i++)
			{
				var _item=this.GetCollectionItem(_possibleVals,i);
					//NewLateBinding.LateGet(_possibleVals,null,"Item",new object[]{i},null,null,null);
					_lstReturn.Add( this.GetCollectionItemText(_item).ToString());
			}
			
			var _altVals=this.SendCommandAndGetObject(_field,QVCommands.AlternativeValues,new object[]{maxLimit});
			
			_cnt=RuntimeHelpers.GetObjectValue(SendCommandAndGetObject(_altVals,QVCommands.Count));
			
			for(int i=0;i<(int)_cnt;i++)
			{
				var _item=this.GetCollectionItem(_altVals,i);
					//NewLateBinding.LateGet(_possibleVals,null,"Item",new object[]{i},null,null,null);
					_lstReturn.Add( this.GetCollectionItemText(_item).ToString());
			}
			
			return _lstReturn;
		}
		
		#endregion
		
		#region Selections
		
		public void SetSelection(object FieldObject, string SearchString)
		{
			if (FieldObject==null)
				throw new ArgumentNullException("FieldObject");
			SendCommand(FieldObject,QVCommands.Select,new object[]{SearchString});
		}
		
		public List<string> GetSelectionValueList(object FieldObject)
		{
			var _lstReturn= new List<string>();
			
			var _selections=SendCommandAndGetObject(FieldObject,QVCommands.Selections);
			int _cnt=GetCollectionCount(_selections);
			
			for (int i = 0; i < _cnt; i++) {
				_lstReturn.Add(GetCollectionItemText(GetCollectionItem(_selections,i)));
			}
			
			return _lstReturn;
			
		}
		
		public string GetSelectionSearchString(object FieldObject)
		{
			string _strReturn=String.Empty;			
			
			
			var _valueList=GetSelectionValueList(FieldObject);
			if(_valueList.Count>0)
			{
				StringBuilder bldr= new StringBuilder();
				bldr.Append("(");
				foreach (var str in _valueList) {
					bldr.Append("\"");
					bldr.Append(str);
					bldr.Append("\"|");					
				}
				bldr.Remove(bldr.Length-1,1);
				bldr.Append(")");
				
				_strReturn=bldr.ToString();
				
			}
			
			return _strReturn;
			
			
		}
		
		#endregion
		
		#region Misc
		
		public void WaitForIdle()
		{
			SendCommand(Application,@"WaitForIdle",new object[0]);
		}
		
		public int GetSheetsCount()
		{
			return (int)SendCommandAndGetObject(Application,QVCommands.GetSheetCount);
		}
		#endregion
		
	}
	

}
