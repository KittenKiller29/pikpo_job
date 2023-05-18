using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System;
interface DataBaseInterface
{
    string _connectionpath { get; set; }
    static SQLiteConnection _connect { get; set; }
    DataTable getUsersTable();
    DataTable getOrdersTable();
    DataTable getClientsTable();
    DataTable getWaresTable();
    IList<string> getElemsUsers(string columname);
    IList<string> getElemsOrders(string columname);
    IList<string> getElemsWares(string columname);
    IList<string> getElemsClients(string columname);

    void deleteFromUsers(string id);
    void deleteFromOrders(string id);
    void deleteFromClients(string id);
    void deleteFromWares(string id);
    void updateInUsers(string id,string s1,string s2,string s3);
    void updateInOrders(string id,string s1,string s2,string s3,string s4);
    void updateInClients(string id,string s1,string s2,string s3,string s4,string s5);
    void updateInWares(string id,string s1,string s2,string s3,string s4);
    void insertInUsers(string s1,string s2,string s3);
    void insertInOrders(string s1,string s2,string s3,string s4);
    void insertInClients(string s1,string s2,string s3,string s4,string s5);
    void insertInWares(string s1,string s2,string s3,string s4);
    int selectInUsers(string s1,string s2,string s3);
    int selectInOrders(string s1,string s2,string s3,string s4);
    int selectInClients(string s1,string s2,string s3,string s4,string s5);
    int selectInWares(string s1,string s2,string s3,string s4);

}
class DataBase : DataBaseInterface
{
    public string _connectionpath { get; set; }
    public static SQLiteConnection _connect { get; set; }
    public DataBase()
    {
        _connectionpath = "Data Source=C:\\Users\\azamat\\Desktop\\pikpo\\pikpo.db;Cache=Shared;Mode=ReadWrite;";
        _connect = new SQLiteConnection(_connectionpath);
    }
    public DataTable getUsersTable()
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        DataTable data = new DataTable("Пользователи");
        SQLiteCommand _cmd = new SQLiteCommand("select * from Пользователи", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        data.Columns.Add("id");
        data.Columns.Add("Логин");
        data.Columns.Add("Пароль");
        data.Columns.Add("Доступ");
        while (dr.Read())
        {
            DataRow drtmp = data.NewRow();
            drtmp["id"] = dr[0].ToString();
            drtmp["Логин"] = dr[1].ToString();
            drtmp["Пароль"] = dr[2].ToString();
            drtmp["Доступ"] = dr[3].ToString();
            data.Rows.Add(drtmp);
        }
        return data;
    }
    public DataTable getOrdersTable()
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        DataTable data = new DataTable("Заказы");
        SQLiteCommand _cmd = new SQLiteCommand("select * from Заказы", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        data.Columns.Add("id");
        data.Columns.Add("Телефон");
        data.Columns.Add("Артикул");
        data.Columns.Add("Статус");
        data.Columns.Add("Количество");
        while (dr.Read())
        {
            DataRow drtmp = data.NewRow();
            drtmp["id"] = dr[0].ToString();
            drtmp["Телефон"] = dr[1].ToString();
            drtmp["Артикул"] = dr[2].ToString();
            drtmp["Статус"] = dr[3].ToString();
            drtmp["Количество"] = dr[4].ToString();
            data.Rows.Add(drtmp);
        }
        return data;
    }
    public DataTable getClientsTable()
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        DataTable data = new DataTable("Клиенты");
        SQLiteCommand _cmd = new SQLiteCommand("select * from Клиенты", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        data.Columns.Add("id");
        data.Columns.Add("Телефон");
        data.Columns.Add("Имя");
        data.Columns.Add("Привилегии");
        data.Columns.Add("Дата рождения");
        data.Columns.Add("Email");
        while (dr.Read())
        {
            DataRow drtmp = data.NewRow();
            drtmp["id"] = dr[0].ToString();
            drtmp["Телефон"] = dr[1].ToString();
            drtmp["Имя"] = dr[2].ToString();
            drtmp["Привилегии"] = dr[3].ToString();
            drtmp["Дата рождения"] = dr[4].ToString();
            drtmp["Email"] = dr[5].ToString();
            data.Rows.Add(drtmp);
        }
        return data;
    }
    public DataTable getWaresTable()
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        DataTable data = new DataTable("Товары");
        SQLiteCommand _cmd = new SQLiteCommand("select * from Товары", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        data.Columns.Add("id");
        data.Columns.Add("Артикул");
        data.Columns.Add("Наименование");
        data.Columns.Add("Количество");
        data.Columns.Add("Цена");
        while (dr.Read())
        {
            DataRow drtmp = data.NewRow();
            drtmp["id"] = dr[0].ToString();
            drtmp["Артикул"] = dr[1].ToString();
            drtmp["Наименование"] = dr[2].ToString();
            drtmp["Количество"] = dr[3].ToString();
            drtmp["Цена"] = dr[4].ToString();
            data.Rows.Add(drtmp);
        }
        return data;
    }
    public IList<string> getElemsOrders(string columname)
    {
        IList<string> data = new List<string>();
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand _cmd = new SQLiteCommand("select * from Заказы", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        while (dr.Read())
        {
            if (columname == "Номер" && data.Contains(dr[1].ToString())==false)
            {
                data.Add(dr[1].ToString());
            }
            if (columname == "Артикул" && data.Contains(dr[2].ToString()) == false)
            {
                data.Add(dr[2].ToString());
            }
        }

        return data;
    }
    public IList<string> getElemsUsers(string columname)
    {
        IList<string> data = new List<string>();
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand _cmd = new SQLiteCommand("select * from Пользователи", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        while (dr.Read())
        {
            if (columname == "Логин" && data.Contains(dr[1].ToString()) == false)
            {
                data.Add(dr[1].ToString());
            }
            if (columname == "Пароль" && data.Contains(dr[2].ToString()) == false)
            {
                data.Add(dr[2].ToString());
            }
        }
        return data;
    }
    public IList<string> getElemsWares(string columname)
    {
        IList<string> data = new List<string>();
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand _cmd = new SQLiteCommand("select * from Товары", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        while (dr.Read())
        {
            if (columname == "Артикул" && data.Contains(dr[1].ToString()) == false)
            {
                data.Add(dr[1].ToString());
            }
            if (columname == "Наименование" && data.Contains(dr[2].ToString()) == false)
            {
                data.Add(dr[2].ToString());
            }
            if (columname == "Цена" && data.Contains(dr[4].ToString()) == false)
            {
                data.Add(dr[4].ToString());
            }
        }
        return data;
    }
    public IList<string> getElemsClients(string columname)
    {
        IList<string> data = new List<string>();
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand _cmd = new SQLiteCommand("select * from Клиенты", _connect);
        SQLiteDataReader dr = _cmd.ExecuteReader();
        while (dr.Read())
        {
            if (columname == "Телефон" && data.Contains(dr[1].ToString()) == false)
            {
                data.Add(dr[1].ToString());
            }
            if (columname == "Имя" && data.Contains(dr[2].ToString()) == false)
            {
                data.Add(dr[2].ToString());
            }
            if (columname == "ДатаРождения" && data.Contains(dr[4].ToString()) == false)
            {
                data.Add(dr[4].ToString());
            }
            if (columname == "Email" && data.Contains(dr[5].ToString()) == false)
            {
                data.Add(dr[5].ToString());
            }
        }
        return data;
    }
    public void deleteFromUsers(string id)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = $"DELETE from Пользователи WHERE id = {Convert.ToInt32(Convert.ToInt32(id))}";
        SQLiteCommand cmd = new SQLiteCommand(comtext, _connect);
        int dr = cmd.ExecuteNonQuery();
    }
    public void deleteFromOrders(string id)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = $"DELETE from Заказы WHERE id = {Convert.ToInt32(Convert.ToInt32(id))}";
        SQLiteCommand cmd = new SQLiteCommand(comtext, _connect);
        int dr = cmd.ExecuteNonQuery();
    }
    public void deleteFromClients(string id)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = $"DELETE from Клиенты WHERE id = {Convert.ToInt32(Convert.ToInt32(id))}";
        SQLiteCommand cmd = new SQLiteCommand(comtext, _connect);
        int dr = cmd.ExecuteNonQuery();
    }
    public void deleteFromWares(string id)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = $"DELETE from Товары WHERE id = {Convert.ToInt32(Convert.ToInt32(id))}";
        SQLiteCommand cmd = new SQLiteCommand(comtext, _connect);
        int dr = cmd.ExecuteNonQuery();
    }
    public void updateInUsers(string id,string s1,string s2,string s3)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = "", comtext1 = "", comtext2 = "";
        comtext = $"UPDATE Пользователи SET Логин = '{s1}' WHERE id={Convert.ToInt32(id)}";
        comtext1 = $"UPDATE Пользователи SET Пароль = '{s2}' WHERE id={Convert.ToInt32(id)}";
        comtext2 = $"UPDATE Пользователи SET Доступ = {Convert.ToInt32(s3)} WHERE id={Convert.ToInt32(id)}";
        using (var command = new SQLiteCommand(comtext, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext1, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext2, _connect))
        {
            command.ExecuteNonQuery();
        }
    }
    public void updateInOrders(string id,string s1,string s2,string s3,string s4)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = "", comtext1 = "", comtext2 = "",comtext3="";
        comtext = $"UPDATE Заказы SET Телефон = '{s1}' WHERE id={Convert.ToInt32(id)}";
        comtext1 = $"UPDATE Заказы SET Артикул = '{s2}' WHERE id={Convert.ToInt32(id)}";
        comtext2 = $"UPDATE Заказы SET Статус = {Convert.ToInt32(s3)} WHERE id={Convert.ToInt32(id)}";
        comtext3 = $"UPDATE Заказы SET Количество = {Convert.ToInt32(s4)} WHERE id={Convert.ToInt32(id)}";
        using (var command = new SQLiteCommand(comtext, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext1, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext2, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext3, _connect))
        {
            command.ExecuteNonQuery();
        }
    }
    public void updateInClients(string id,string s1,string s2,string s3,string s4,string s5)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = "", comtext1 = "", comtext2 = "", comtext3 = "",comtext4="";
        comtext = $"UPDATE Клиенты SET Телефон = '{s1}' WHERE id={Convert.ToInt32(id)}";
        comtext1 = $"UPDATE Клиенты SET Имя = '{s2}' WHERE id={Convert.ToInt32(id)}";
        comtext2 = $"UPDATE Клиенты SET Привилегии = {Convert.ToInt32(s3)} WHERE id={Convert.ToInt32(id)}";
        comtext3 = $"UPDATE Клиенты SET Дата рождения = '{s4}' WHERE id={Convert.ToInt32(id)}";
        comtext4 = $"UPDATE Клиенты SET Email = '{s5}' WHERE id={Convert.ToInt32(id)}";
        using (var command = new SQLiteCommand(comtext, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext1, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext2, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext3, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext4, _connect))
        {
            command.ExecuteNonQuery();
        }
    }
    public void updateInWares(string id,string s1,string s2,string s3,string s4)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        string comtext = "", comtext1 = "", comtext2 = "",comtext3="";
        comtext = $"UPDATE Товары SET Артикул = '{s1}' WHERE id={Convert.ToInt32(id)}";
        comtext1 = $"UPDATE Товары SET Наименование = '{s2}' WHERE id={Convert.ToInt32(id)}";
        comtext2 = $"UPDATE Товары SET Количество = {Convert.ToInt32(s3)} WHERE id={Convert.ToInt32(id)}";
        comtext3 = $"UPDATE Товары SET Цена = '{s4}' WHERE id={Convert.ToInt32(id)}";
        using (var command = new SQLiteCommand(comtext, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext1, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext2, _connect))
        {
            command.ExecuteNonQuery();
        }
        using (var command = new SQLiteCommand(comtext3, _connect))
        {
            command.ExecuteNonQuery();
        }
    }
    public void insertInUsers(string s1,string s2,string s3)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Пользователи (Логин,Пароль,Доступ) VALUES (:s1,:s2,:s3)", _connect);
        cmd.Parameters.AddWithValue("s1", s1);
        cmd.Parameters.AddWithValue("s2", s2);
        cmd.Parameters.AddWithValue("s3", Convert.ToInt32(s3));
        int dr = cmd.ExecuteNonQuery();
    }
    public void insertInOrders(string s1,string s2,string s3,string s4)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Заказы (Телефон,Артикул,Статус,Количество) VALUES (:s1,:s2,:s3,:s4)", _connect);
        cmd.Parameters.AddWithValue("s1", s1);
        cmd.Parameters.AddWithValue("s2", s2);
        cmd.Parameters.AddWithValue("s3", Convert.ToInt32(s3));
        cmd.Parameters.AddWithValue("s4", Convert.ToInt32(s4));
        int dr = cmd.ExecuteNonQuery();
    }
    public void insertInClients(string s1,string s2,string s3,string s4,string s5)
    {

        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Клиенты (Телефон,Имя,Привилегии,ДатаРождения,Email) VALUES (:s1,:s2,:s3,:s4,:s5)", _connect);
        cmd.Parameters.AddWithValue("s1", s1);
        cmd.Parameters.AddWithValue("s2", s2);
        cmd.Parameters.AddWithValue("s3", Convert.ToInt32(s3));
        cmd.Parameters.AddWithValue("s4", s4);
        cmd.Parameters.AddWithValue("s5", s5);
        int dr = cmd.ExecuteNonQuery();
    }
    public void insertInWares(string s1, string s2, string s3, string s4)
    {

        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Товары (Артикул,Наименование,Количество,Цена) VALUES (:s1,:s2,:s3,:s4)", _connect);
        cmd.Parameters.AddWithValue("s1", s1);
        cmd.Parameters.AddWithValue("s2", s2);
        cmd.Parameters.AddWithValue("s3", Convert.ToInt32(s3));
        cmd.Parameters.AddWithValue("s4", s4);
        int dr = cmd.ExecuteNonQuery();
    }
    public int selectInUsers(string s1,string s2,string s3)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("select * from Пользователи", _connect);
        SQLiteDataReader dr = cmd.ExecuteReader();
        int index = -1;
        while (dr.Read())
        {
            if (s1 == dr[1].ToString() && s2 == dr[2].ToString() && s3 == dr[3].ToString() && index == -1)
            {
                index = Convert.ToInt32(dr[0]);
            }
        }
        return index;
    }
    public int selectInOrders(string s1,string s2,string s3,string s4)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("select * from Заказы", _connect);
        SQLiteDataReader dr = cmd.ExecuteReader();
        int index = -1;
        while (dr.Read())
        {
            if (s1 == dr[1].ToString() && s2 == dr[2].ToString() 
                && s3 == dr[3].ToString() && s4 == dr[4].ToString() && index == -1)
            {
                index = Convert.ToInt32(dr[0]);
            }
        }
        return index;
    }
    public int selectInClients(string s1,string s2,string s3,string s4,string s5)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("select * from Клиенты", _connect);
        SQLiteDataReader dr = cmd.ExecuteReader();
        int index = -1;
        while (dr.Read())
        {
            if (s1 == dr[1].ToString() && s2 == dr[2].ToString() && s3 == dr[3].ToString() 
                && s4 == dr[4].ToString() && s5 == dr[5].ToString() && index == -1)
            {
                index = Convert.ToInt32(dr[0]);
            }
        }
        return index;
    }
    public int selectInWares(string s1,string s2,string s3,string s4)
    {
        if (_connect.State == ConnectionState.Closed)
            _connect.Open();
        SQLiteCommand cmd = new SQLiteCommand("select * from Товары", _connect);
        SQLiteDataReader dr = cmd.ExecuteReader();
        int index = -1;
        while (dr.Read())
        {
            if (s1 == dr[1].ToString() && s2 == dr[2].ToString() 
                && s3 == dr[3].ToString() && s4 == dr[4].ToString() && index == -1)
            {
                index = Convert.ToInt32(dr[0]);
            }
        }
        return index;
    }

}