using System.Collections.Generic;
using System;
using pikpo_job.rep;
using System.Data;
public class Model
{
    public System.EventHandler _observmainwindowuser;
    public System.EventHandler _observmainwindowadmin;
    public System.EventHandler _observbadauth;
    public System.EventHandler _observopenusers;
    public System.EventHandler _observopenorders;
    public System.EventHandler _observopenclients;
    public System.EventHandler _observopenwares;
    public System.EventHandler _observtableupdate;
    public System.EventHandler _observselectuser;
    public System.EventHandler _observselectorders;
    public System.EventHandler _observselectwares;
    public System.EventHandler _observselectclients;
    public System.EventHandler _observselectchangeuser;
    public System.EventHandler _observselectchangeorders;
    public System.EventHandler _observselectchangewares;
    public System.EventHandler _observselectchangeclients;
    DataBaseInterface DataBase = new DataBase();
    User CurrentUser=new User();
    private static string _tablename = "";
    public static string _inf = "";
    static DataTable data = new DataTable();
    public void AuthIn(string login,string password)
    {
        DataTable _dt=DataBase.getUsersTable();
        foreach (DataRow str in _dt.Rows)
        {
            if (login == str[1].ToString() && password == str[2].ToString())
            {
                CurrentUser._userpermissions = Convert.ToInt32(str[3]);
                break;
            }
        }
         
        if (CurrentUser._userpermissions == -1)
        {
            _observbadauth.Invoke(this,null);
        }
        else if(CurrentUser._userpermissions == 1)
        {
            _observmainwindowadmin.Invoke(this, null);
        }
        else
        {
            _observmainwindowuser.Invoke(this, null);
        }
    }
    public void openUsers()
    {
        _tablename = "Пользователи";
        _observopenusers.Invoke(this, null);
    }
    public void openWares()
    {
        _tablename = "Товары";
        _observopenwares.Invoke(this, null);
    }
    public void openOrders()
    {
        _tablename = "Заказы";
        _observopenorders.Invoke(this, null);
    }
    public void openClients()
    {
        _tablename = "Клиенты";
        _observopenclients.Invoke(this, null);
    }
    public DataTable getUsers()
    {
        return DataBase.getUsersTable();
    }
    public DataTable getOrders()
    {
        return DataBase.getOrdersTable();
    }
    public DataTable getWares()
    {
        return DataBase.getWaresTable();
    }
    public DataTable getClients()
    {
        return DataBase.getClientsTable();
    }
    public void insertInUsers(string s1,string s2,string s3)
    {
        if (s1 == "" || s2 == "" || s3 == "") ;
        else
        {
            try
            {
                DataBase.insertInUsers(s1, s2, s3);
            }
            catch(System.Exception ex)
            {

            }
        }
        _observopenusers.Invoke(this, null);
    }
    public void insertInOrders(string s1,string s2,string s3,string s4)
    {
        if (s1 == "" || s2 == "" || s3 == "" || s4 == "") ;
        else
        {
            try
            {
                DataBase.insertInOrders(s1, s2, s3, s4);
            }
            catch(System.Exception ex)
            {

            }
        }
        _observopenorders.Invoke(this, null);
    }
    public void insertInClients(string s1, string s2, string s3,string s4,string s5)
    {
        if (s1 == "" || s2 == "" || s3 == "" || s4=="" || s5=="") ;
        else
        {
            try
            {
                DataBase.insertInClients(s1, s2, s3,s4,s5);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenclients.Invoke(this, null);
    }
    public void insertInWares(string s1, string s2, string s3, string s4)
    {
        if (s1 == "" || s2 == "" || s3 == "" || s4 == "") ;
        else
        {
            try
            {
                DataBase.insertInWares(s1, s2, s3, s4);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenwares.Invoke(this, null);
    }
   
    public int getNumOfRowInUsers(string s1,string s2,string s3)
    {
        int ind = -1;
        if (s1 == "" || s2 == "" || s3 == "" || DataBase.selectInUsers(s1, s2, s3) == -1) ;
        else
        {
            DataTable _dt = DataBase.getUsersTable();
            int count = 0;
            foreach (DataRow str in _dt.Rows)
            {
                if (str[0].ToString() == DataBase.selectInUsers(s1, s2, s3).ToString())
                {
                    ind = count;
                    break;
                }
                count++;
            }
        }
        return ind;
    }
    public int getNumOfRowInOrders(string s1, string s2, string s3,string s4)
    {
        int ind = -1;
        if (s1 == "" || s2 == "" || s3 == "" || s4=="" || DataBase.selectInOrders(s1, s2, s3,s4) == -1) ;
        else
        {
            DataTable _dt = DataBase.getOrdersTable();
            int count = 0;
            foreach (DataRow str in _dt.Rows)
            {
                if (str[0].ToString() == DataBase.selectInOrders(s1, s2, s3,s4).ToString())
                {
                    ind = count;
                    break;
                }
                count++;
            }
        }
        return ind;
    }
    public int getNumOfRowInWares(string s1, string s2, string s3,string s4)
    {
        int ind = -1;
        if (s1 == "" || s2 == "" || s3 == "" || s4=="" || DataBase.selectInWares(s1, s2, s3,s4) == -1) ;
        else
        {
            DataTable _dt = DataBase.getWaresTable();
            int count = 0;
            foreach (DataRow str in _dt.Rows)
            {
                if (str[0].ToString() == DataBase.selectInWares(s1, s2, s3,s4).ToString())
                {
                    ind = count;
                    break;
                }
                count++;
            }
        }
        return ind;
    }
    public int getNumOfRowInClients(string s1, string s2, string s3,string s4,string s5)
    {
        int ind = -1;
        if (s1 == "" || s2 == "" || s3 == "" || s4=="" || s5=="" || DataBase.selectInClients(s1, s2, s3,s4,s5) == -1) ;
        else
        {
            DataTable _dt = DataBase.getClientsTable();
            int count = 0;
            foreach (DataRow str in _dt.Rows)
            {
                if (str[0].ToString() == DataBase.selectInClients(s1, s2, s3,s4,s5).ToString())
                {
                    ind = count;
                    break;
                }
                count++;
            }
        }
        return ind;
    }
    public void selectInUsers(string s1,string s2,string s3)
    {
        if (getNumOfRowInUsers(s1, s2, s3) != -1)
            _observselectuser.Invoke(this, null);
        else
            _observopenusers.Invoke(this, null);
    }
    public void selectInOrders(string s1, string s2, string s3,string s4)
    {
        if (getNumOfRowInOrders(s1, s2, s3,s4) != -1)
            _observselectorders.Invoke(this, null);
        else
            _observopenorders.Invoke(this, null);
    }
    public void selectInWares(string s1, string s2, string s3, string s4)
    {
        if (getNumOfRowInWares(s1, s2, s3, s4) != -1)
            _observselectwares.Invoke(this, null);
        else
            _observopenwares.Invoke(this, null);
    }
    public void selectInClients(string s1, string s2, string s3, string s4,string s5)
    {
        if (getNumOfRowInClients(s1, s2, s3, s4,s5) != -1)
            _observselectclients.Invoke(this, null);
        else
            _observopenclients.Invoke(this, null);
    }
    public void deleteInUsers(string id)
    {
        if (id == "") ;
        else
        {
            try
            {
                DataBase.deleteFromUsers(id);
            }
            catch (System.Exception ex)
            {

            }  
        }
        _observopenusers.Invoke(this, null);
    }
    public void deleteInWares(string id)
    {
        if (id == "") ;
        else
        {
            try
            {
                DataBase.deleteFromWares(id);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenwares.Invoke(this, null);
    }
    public void deleteInOrders(string id)
    {
        if (id == "") ;
        else
        {
            try
            {
                DataBase.deleteFromOrders(id);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenorders.Invoke(this, null);
    }
    public void deleteInClients(string id)
    {
        if (id == "") ;
        else
        {
            try
            {
                DataBase.deleteFromClients(id);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenclients.Invoke(this, null);
    }
    public void updateInUsers(string id,string s1,string s2,string s3)
    {
        if (id == "" || s1 == "" || s2 == "" || s3 == "") ;
        else
        {
            try
            {
                DataBase.updateInUsers(id, s1, s2, s3);
            }
            catch(System.Exception ex)
            {

            }
        }
        _observopenusers.Invoke(this, null);
    }
    public void updateInClents(string id, string s1, string s2, string s3,string s4,string s5)
    {
        if (id == "" || s1 == "" || s2 == "" || s3 == "" || s4=="" || s5=="") ;
        else
        {
            try
            {
                DataBase.updateInClients(id, s1, s2, s3,s4,s5);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenclients.Invoke(this, null);
    }
    public void updateInWares(string id, string s1, string s2, string s3,string s4)
    {
        if (id == "" || s1 == "" || s2 == "" || s3 == "" || s4=="") ;
        else
        {
            try
            {
                DataBase.updateInWares(id, s1, s2, s3,s4);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenwares.Invoke(this, null);
    }
    public void updateInOrders(string id, string s1, string s2, string s3,string s4)
    {
        if (id == "" || s1 == "" || s2 == "" || s3 == "" || s4=="") ;
        else
        {
            try
            {
                DataBase.updateInOrders(id, s1, s2, s3,s4);
            }
            catch (System.Exception ex)
            {

            }
        }
        _observopenorders.Invoke(this, null);
    }
    public void sellectRow()
    {
        if (_tablename == "Пользователи")
            _observselectchangeuser.Invoke(this, null);
        else if (_tablename == "Заказы")
            _observselectchangeorders.Invoke(this, null);
        else if (_tablename == "Клиенты")
            _observselectchangeclients.Invoke(this, null);
        else if (_tablename == "Товары")
            _observselectchangewares.Invoke(this, null);
    }
    public IList<string> getOrdersElems(string columname)
    {
        return DataBase.getElemsOrders(columname);
    }
    public IList<string> getWaresElems(string columname)
    {
        return DataBase.getElemsWares(columname);
    }
    public IList<string> getClientsElems(string columname)
    {
        return DataBase.getElemsClients(columname);
    }
    public IList<string> getUsersElems(string columname)
    {
        return DataBase.getElemsUsers(columname);
    }


}