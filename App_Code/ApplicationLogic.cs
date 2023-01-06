using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitsBizLogic
{
  public class ApplicationLogic
    {
         public static string SuccessMessage(string Msg)
{

    return "<div class='alert alert-success alert-dismissible fade show' role='alert'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button><h4><i class='icon fa fa-check'></i> Success!</h4>" + Msg + "</div>";

}
         public static string ErrorWarning(string Msg)
         {

             return "<div class='alert alert-warning  alert-dismissible'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button><h4><i class='icon fa fa-warning'></i> Error!</h4>" + Msg + "</div>";

         }
         public static string Error(string Msg)
         {

             return "<div class='alert alert-danger  alert-dismissible'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button><h4><i class='icon fa fa-ban'></i> Error!</h4>" + Msg + "</div>";

         }
    }
  
   
}
