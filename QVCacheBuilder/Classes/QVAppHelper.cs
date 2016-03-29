/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 06.11.2014
 * Time: 12:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq;


namespace QVCacheBuilder.Classes
{
	/// <summary>
	/// Description of QVAppHelper.
	/// </summary>
	public class QVAppHelper
	{
		
		#region --VARS--
					
		private object totalMemory;

        private object committedMemory;

        private object Time_Before;

        private object Time_After;

        private object Mem_Before;

        private object Mem_After;

        private object TestingHost;

        private object ComputerName;

        private object scenario;

        private object @value;

        private object Timestamp;

        private object AppName;

        private object RunName;

        private object NumSheets;

        private object chartCnt;

        private object LoopMinutes;

        private object RunID;

        private int[] TotalValues;

        private int[] ObjectsWithCyclicDimensionsFlag;

        private string[] ObjectsWithCyclicDimensionsName;

        private List<string> CacheFields;

        private string[,] FieldValues;

        private object App;

        private object QV;

        private object fso;

        private object TotalSelections;

        private object Success;

        private DateTime LimitTrialDate;

        private DateTime Today;
        
        #endregion
		
        public  void IndexExpansion(string DocPath, List<string> FieldList)
        {
            string str = string.Concat("qvp://localhost/", DocPath);
            this.QV = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("QlikTech.Qlikview", ""));
            object qV = this.QV;
            var objArray = new object[] { str };
            object[] objArray1 = objArray;
            var flagArray = new bool[] { true };
            object obj = NewLateBinding.LateGet(qV, null, "OpenDoc", objArray1, null, null, flagArray);
            if (flagArray[0])
            {
                str = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(string));
            }
            this.App = RuntimeHelpers.GetObjectValue(obj);
            this.scenario = "BiX";
//            this.CacheFields[0] = this.FieldOne.Text.ToString();
//            this.CacheFields[1] = this.FieldTwo.Text.ToString();
			this.CacheFields=FieldList;
            this.initVars();
            //this.initOutputFile();
            this.NumSheets = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(App, null, "NoOfSheets", new object[0], null, null, null));
            object app = this.App;

			var qvApp=new 	Classes.QVApp(this.App);
			qvApp.WaitForIdle();
			qvApp.ActivateSheet(@"SH77");
			
			foreach (var field  in CacheFields) {				
				
				var objField=qvApp.GetField(field);				

				string CurrentSelections=qvApp.GetSelectionSearchString(objField);
	            
				List<string> locTmp=qvApp.GetFieldValueList(field);            	           
	
	            qvApp.ClearField(objField);
	            
	            foreach (var element in locTmp) {
	            	qvApp.WaitForIdle();
	            	qvApp.SetSelection(objField,element);	            	
	            }	
	            
	            qvApp.SetSelection(objField,CurrentSelections);
			}
			
            
            
            


            this.Success = 1;
        }
        
//		public  void IndexExpansion(string DocPath, List<string> FieldList)
//        {
//            string str = string.Concat("qvp://localhost/", DocPath);
//            this.QV = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("QlikTech.Qlikview", ""));
//            object qV = this.QV;
//            var objArray = new object[] { str };
//            object[] objArray1 = objArray;
//            var flagArray = new bool[] { true };
//            object obj = NewLateBinding.LateGet(qV, null, "OpenDoc", objArray1, null, null, flagArray);
//            if (flagArray[0])
//            {
//                str = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(string));
//            }
//            this.App = RuntimeHelpers.GetObjectValue(obj);
//            this.scenario = "BiX";
////            this.CacheFields[0] = this.FieldOne.Text.ToString();
////            this.CacheFields[1] = this.FieldTwo.Text.ToString();
//			this.CacheFields=FieldList.ToArray();
//            this.initVars();
//            //this.initOutputFile();
//            this.NumSheets = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(App, null, "NoOfSheets", new object[0], null, null, null));
//            object app = this.App;
//            objArray1 = new object[] { true };
//            
//            objArray= new object[] {@"SH77"};
//            NewLateBinding.LateCall(app, null, "ActivateSheet", objArray, null, null, flagArray, true);
//            
//            
//            objArray= new object[]{@"ГМ"};
//            
//            var objField=RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(app,null,"Fields",objArray,null,null,null));
//            
//            //NewLateBinding.LateCall(objField,null,"objField",null,null,null,flagArray,true);
//           // NewLateBinding.LateCall(objField, null, "Clear", new object[0], null, null, null, true);
////           int fldValsCount=RuntimeHelpers.GetObjectValue(
////           		NewLateBinding.LateGet(objField,null,""
////           );
//            NewLateBinding.LateCall(objField, null, "Select", new object[] {@"сен-2013"}, null, null, null, true);
//            
//            var locTmp=GetFieldValues(@"ГМ");
//            
//            
//            NewLateBinding.LateCall(objField,null,"Clear",new object[0],null,null,null,true );
//            
//            foreach (var element in locTmp) {
//				System.Threading.Thread.Sleep(1000);            	
//            	NewLateBinding.LateCall(objField, null, "Select", new object[] {element}, null, null, null, true);
//            	System.Threading.Thread.Sleep(1000);
//            }
//            
//            
//            
////            objArray= new object[] {@"ГМ","Янв-2014"};
////            NewLateBinding.LateCall(app, null, "SelectInField", objArray, null, null, flagArray, true);
//            //NewLateBinding.LateCall(app, null, "ClearAll", objArray1, null, null, null, true);
////            this.MinimizeAllCharts();
////            this.GetTotalSelections();
////            this.Progress.Minimum = 0;
////            this.Progress.Maximum = Conversions.ToInteger(this.TotalSelections);
////            decimal value = this.SheetNumber.Value;
////            decimal num = value;
////            decimal num1 = value;            
////            this.RestoreAllObjects();
////            this.Closefile();
////            NewLateBinding.LateCall(NewLateBinding.LateGet(this.App, null, "GetApplication", new object[0], null, null, null), null, "Quit", new object[0], null, null, null, true);
//            this.Success = 1;
//        }
		
		List<string> GetFieldValues(string FieldName)
		{
			var _lstReturn = new List<string>();
			var parArray= new object[0];
			
			
			parArray=new object[]
			{
				FieldName
			};
			
			var _field=NewLateBinding.LateGet(this.App,null,@"Fields",parArray,null,null,null);
			
			parArray= new object[]
			{
				@"10000"
			};
			
			var _possibleVals= NewLateBinding.LateGet(_field,null,@"GetPossibleValues",parArray,null,null,null);			
			
			var _cnt=RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(_possibleVals,null,@"Count",new object[0],null,null,null));
			
			for(int i=0;i<(int)_cnt;i++)
			{
				var _item=NewLateBinding.LateGet(_possibleVals,null,"Item",new object[]{i},null,null,null);
				_lstReturn.Add( RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(_item,null,"Text",new object[0],null,null,null)).ToString());
			}
			
			var _altVals= NewLateBinding.LateGet(_field,null,@"GetAlternativeValues",parArray,null,null,null);			
			
			_cnt=RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(_altVals,null,@"Count",new object[0],null,null,null));
			
			for(int i=0;i<(int)_cnt;i++)
			{
				var _item=NewLateBinding.LateGet(_altVals,null,"Item",new object[]{i},null,null,null);
				_lstReturn.Add( RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(_item,null,"Text",new object[0],null,null,null)).ToString());
			}
			
			return _lstReturn;
		}
		
//		public void initOutputFile()
//        {
//            object objectValue = RuntimeHelpers.GetObjectValue(this.buildFilename(this.SaveToFolder.Text));
//            this.fso = new StreamWriter(Conversions.ToString(objectValue));
//            this.CreateFile();
//        }

//		private void SendCommand(string commandText)
//		{
//		}
		
        public void initVars()
        {
            this.ComputerName = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(this.App, null, "GetApplication", new object[0], null, null, null), null, "GetProperties", new object[0], null, null, null), null, "Computername", new object[0], null, null, null));
            this.AppName = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.App, null, "Name", new object[0], null, null, null));
            this.AppName = Strings.Replace(Conversions.ToString(this.AppName), ".qvw", "", 1, -1, CompareMethod.Binary);
            this.AppName = Strings.Replace(Conversions.ToString(this.AppName), "/", "-", 1, -1, CompareMethod.Binary);
            this.NumSheets = Operators.SubtractObject(NewLateBinding.LateGet(this.App, null, "NoOfSheets", new object[0], null, null, null), 1);
            this.RunID = DateAndTime.Now;
        }

			
	}
}
