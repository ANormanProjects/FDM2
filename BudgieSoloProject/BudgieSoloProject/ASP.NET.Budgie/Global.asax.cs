﻿using BudgieDatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ASP.NET.Budgie
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string _firstName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                        string _lastName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                        string _dob = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData; 
                        string _balance = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                        string _budget = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
                        string roles = string.Empty;

                        using (BudgieDBCFModel buc = new BudgieDBCFModel())
                        {
                            BudgieUser user = buc.budgieUsers.SingleOrDefault(u => u.emailAddress == username);
                            BudgieUser firstName = buc.budgieUsers.SingleOrDefault(u => u.firstName == _firstName);
                            BudgieUser lastName = buc.budgieUsers.SingleOrDefault(u => u.lastName == _lastName);
                            BudgieUser dob = buc.budgieUsers.SingleOrDefault(u => u.dob == _dob);
                            Account balance = buc.accounts.SingleOrDefault(u => u.balance.ToString() == _balance);
                            Account budget = buc.accounts.SingleOrDefault(u => u.budget.ToString() == _budget);
                            roles = user.roles;
                        }
                        //let us extract the roles from our own custom cookie


                        //Let us set the Principal with our user specific details
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
