using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pikpo_job
{
    public partial class view : Form
    {
        Model Model = new Model();
        public view()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Model._observbadauth += new System.EventHandler(this.badAuth);
            Model._observmainwindowadmin += new System.EventHandler(this.adminWindow);
            Model._observmainwindowuser += new System.EventHandler(this.mainWindow);
            Model._observopenusers += new System.EventHandler(this.usersTableWindow);
            Model._observopenorders += new System.EventHandler(this.ordersTableWindow);
            Model._observopenwares += new System.EventHandler(this.waresTableWindow);
            Model._observopenclients += new System.EventHandler(this.clientsTableWindow);
            Model._observselectuser += new System.EventHandler(this.selectRowUsers);
            Model._observselectclients += new System.EventHandler(this.selectRowClients);
            Model._observselectwares += new System.EventHandler(this.selectRowWares);
            Model._observselectorders += new System.EventHandler(this.selectRowOrders);
            Model._observselectchangeuser += new System.EventHandler(this.selectedUsers);
            Model._observselectchangeclients += new System.EventHandler(this.selectedClients);
            Model._observselectchangewares += new System.EventHandler(this.selectedWares);
            Model._observselectchangeorders += new System.EventHandler(this.selectedOrders);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            Model.AuthIn(textBoxLogin.Text, textBoxPassword.Text);
        }
        void badAuth(object sender,EventArgs e)
        {
            labelBadAuth.Visible = true;
        }
        void setUsersCB()
        {
            comboBoxLogin.DataSource=(Model.getUsersElems("Логин"));
            comboBoxPassword.DataSource = (Model.getUsersElems("Пароль"));
            comboBoxLoginUsers.DataSource = Model.getUsersElems("Логин");
            comboBoxPassUsers.DataSource = Model.getUsersElems("Пароль");
            checkBoxLoginUsers.Checked = false;
            checkBoxPassUsers.Checked = false;
            checkBoxDostupUsers.Checked = false;
        }
        void setClientsCB()
        {
            comboBoxName.DataSource = Model.getClientsElems("Имя");
            comboBoxPhone.DataSource = Model.getClientsElems("Телефон");
            comboBoxBirthday.DataSource = Model.getClientsElems("ДатаРождения");
            comboBoxEmail.DataSource = Model.getClientsElems("Email");
            comboBoxNameClientsSort.DataSource = Model.getClientsElems("Имя");
            comboBoxPhoneClientsSort.DataSource = Model.getClientsElems("Телефон");
            comboBoxBirthClientsSort.DataSource = Model.getClientsElems("ДатаРождения");
            comboBoxEmailClientsSort.DataSource = Model.getClientsElems("Email");
            checkBoxBirthdayClients.Checked = false;
            checkBoxEmailClients.Checked = false;
            checkBoxNameClients.Checked = false;
            checkBoxPhoneClients.Checked = false;
            checkBoxPrivClients.Checked = false;
        }
        void setOrdersCB()
        {
            comboBoxArticuleOrders.DataSource = Model.getWaresElems("Артикул");
            comboBoxPhoneOrders.DataSource = Model.getClientsElems("Телефон");
            comboBoxArticuleOrdersSort.DataSource = Model.getWaresElems("Артикул");
            comboBoxPhoneOrdersSort.DataSource = Model.getClientsElems("Телефон");
            checkBoxArticuleOrders.Checked = false;
            checkBoxCountOrders.Checked = false;
            checkBoxPhoneOrders.Checked = false;
            checkBoxStatusOrders.Checked = false;
        }
        void setWaresCB()
        {
            comboBoxNameWares.DataSource = Model.getWaresElems("Наименование");
            comboBoxArticuleWares.DataSource = Model.getWaresElems("Артикул");
            comboBoxPrice.DataSource = Model.getWaresElems("Цена");
            comboBoxArticuleWaresSort.DataSource = Model.getWaresElems("Артикул");
            comboBoxNameWaresSort.DataSource = Model.getWaresElems("Наименование");
            comboBoxPriceWaresSort.DataSource = Model.getWaresElems("Цена");
            checkBoxArticuleWares.Checked = false;
            checkBoxCountWares.Checked = false;
            checkBoxPriceWares.Checked = false;
            checkBoxPhoneWares.Checked = false;
        }


        void mainWindow(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            AuthName.Visible = false;
            panelTables.Visible = true;
            dataTable.Visible = false;
            buttonBack.Visible = false;
            label2.Visible = false;
            panelClients.Visible = false;
            panelOrders.Visible = false;
            panelUsers.Visible = false;
            panelWares.Visible = false;
            panelSysMsg.Visible = false;
            panelSortUsers.Visible = false;
            panelSortClients.Visible = false;
            panelSortWares.Visible = false;
            panelOrdersSort.Visible = false;
            panelSysMsg.Visible = false;
            buttonExcel.Visible = false;
            buttonSenMsg.Visible = false;
            setUsersCB();
            setClientsCB();
            setWaresCB();
            setOrdersCB();
        }
        void adminWindow(object sender, EventArgs e)
        {
            mainWindow(sender,e);
            buttonUsers.Visible = true;
        }
        void usersTableWindow(object sender,EventArgs e)
        {
            comboBoxLogin.DataSource = (Model.getUsersElems("Логин"));
            comboBoxPassword.DataSource = (Model.getUsersElems("Пароль"));
            dataTable.DataSource = Model.getUsers();
            dataTable.Visible = true;
            panelTables.Visible = false;
            label2.Visible = true;
            label2.Text = "Таблица: Пользователи";
            buttonBack.Visible = true;
            panelClients.Visible = false;
            panelOrders.Visible = false;
            panelWares.Visible = false;
            panelUsers.Visible = true;
            panelUsers.BringToFront();
            panelUsers.Location = panelPrototype.Location;
            buttonDeleteUsers.Enabled = false;
            buttonUpdateUsers.Enabled = false;
            panelSysMsg.Visible = true;
            panelSortUsers.Visible = true;
            panelSortUsers.Location = panelSortPrototype.Location;
            buttonExcel.Visible = true;
           
        }
        void ordersTableWindow(object sender, EventArgs e)
        {
            comboBoxArticuleOrders.DataSource = Model.getWaresElems("Артикул");
            comboBoxPhoneOrders.DataSource = Model.getClientsElems("Телефон");
            dataTable.DataSource = Model.getOrders();
            dataTable.Visible = true;
            panelTables.Visible = false;
            label2.Visible = true;
            label2.Text = "Таблица: Заказы";
            buttonBack.Visible = true;
            panelClients.Visible = false;
            panelOrders.Visible = true;
            panelWares.Visible = false;
            panelUsers.Visible = false;
            panelOrders.BringToFront();
            panelOrders.Location = panelPrototype.Location;
            buttonDeleteOrders.Enabled = false;
            buttonUpdateOrders.Enabled = false;
            panelSysMsg.Visible = true;
            panelOrdersSort.Visible = true;
            panelOrdersSort.Location = panelSortPrototype.Location;
            buttonExcel.Visible = true;
            buttonSenMsg.Visible = true;
        }
        void waresTableWindow(object sender, EventArgs e)
        {
            comboBoxNameWares.DataSource = Model.getWaresElems("Наименование");
            comboBoxArticuleWares.DataSource = Model.getWaresElems("Артикул");
            comboBoxPrice.DataSource = Model.getWaresElems("Цена");
            dataTable.DataSource = Model.getWares();
            dataTable.Visible = true;
            panelTables.Visible = false;
            label2.Visible = true;
            label2.Text = "Таблица: Товары";
            buttonBack.Visible = true;
            panelClients.Visible = false;
            panelOrders.Visible = false;
            panelWares.Visible = true;
            panelUsers.Visible = false;
            panelWares.BringToFront();
            panelWares.Location = panelPrototype.Location;
            buttonWaresDelete.Enabled = false;
            buttonWaresUpdate.Enabled = false;
            panelSysMsg.Visible = true;
            panelSortWares.Visible = true;
            panelSortWares.Location = panelSortPrototype.Location;
            buttonExcel.Visible = true;
        }
        void clientsTableWindow(object sender, EventArgs e)
        {
            comboBoxName.DataSource = Model.getClientsElems("Имя");
            comboBoxPhone.DataSource = Model.getClientsElems("Телефон");
            comboBoxBirthday.DataSource = Model.getClientsElems("ДатаРождения");
            comboBoxEmail.DataSource = Model.getClientsElems("Email");
            dataTable.DataSource = Model.getClients();
            dataTable.Visible = true;
            panelTables.Visible = false;
            label2.Visible = true;
            label2.Text = "Таблица: Клиенты";
            buttonBack.Visible = true;
            panelClients.Visible = true;
            panelOrders.Visible = false;
            panelWares.Visible = false;
            panelUsers.Visible = false;
            panelClients.BringToFront();
            panelClients.Location = panelPrototype.Location;
            buttonClientsDelete.Enabled = false;
            buttonClientsUpdate.Enabled = false;
            panelSysMsg.Visible = true;
            panelSortClients.Visible = true;
            panelSortClients.Location = panelSortPrototype.Location;
            buttonExcel.Visible = true;
           
        }
        void selectRowUsers(object sender, EventArgs e)
        {
            dataTable.Rows[Model.getNumOfRowInUsers(comboBoxLogin.Text, 
                comboBoxPassword.Text, numericDostup.Value.ToString())].Selected=true;
        }
        void selectRowClients(object sender, EventArgs e)
        {
            dataTable.Rows[Model.getNumOfRowInClients(comboBoxPhone.Text,
                comboBoxName.Text, numericUpPriv.Value.ToString(),
                comboBoxBirthday.Text,comboBoxEmail.Text)].Selected = true;
        }
        void selectRowWares(object sender, EventArgs e)
        {
            dataTable.Rows[Model.getNumOfRowInWares(comboBoxArticuleWares.Text,
                comboBoxNameWares.Text, numericCountWares.Value.ToString(),
                comboBoxPrice.Text)].Selected = true;
        }
        void selectRowOrders(object sender, EventArgs e)
        {
            dataTable.Rows[Model.getNumOfRowInOrders(comboBoxPhoneOrders.Text,
                comboBoxArticuleOrders.Text, numericStatusOrder.Value.ToString(),
                numericCountOrders.Value.ToString())].Selected = true;
        }
        void selectedWares(object sender,EventArgs e)
        {
            try
            {
                comboBoxArticuleWares.Text = dataTable.SelectedRows[0].Cells[1].Value.ToString();
                comboBoxNameWares.Text = dataTable.SelectedRows[0].Cells[2].Value.ToString();
                numericCountWares.Value = Convert.ToInt32(dataTable.SelectedRows[0].Cells[3].Value);
                comboBoxPrice.Text = dataTable.SelectedRows[0].Cells[4].Value.ToString();
                buttonWaresDelete.Enabled = true;
                buttonWaresUpdate.Enabled = true;
            }
            catch (System.Exception ex)
            {
                comboBoxArticuleWares.Text = "";
                comboBoxNameWares.Text = "";
                numericCountWares.Value = 0;
                comboBoxPrice.Text = "";
            }
        }
        void selectedOrders(object sender, EventArgs e)
        {
            try
            {
                comboBoxPhoneOrders.Text= dataTable.SelectedRows[0].Cells[1].Value.ToString();
                comboBoxArticuleOrders.Text = dataTable.SelectedRows[0].Cells[2].Value.ToString();
                numericStatusOrder.Value= Convert.ToInt32(dataTable.SelectedRows[0].Cells[3].Value);
                numericCountOrders.Value = Convert.ToInt32(dataTable.SelectedRows[0].Cells[4].Value);
                buttonDeleteOrders.Enabled = true;
                buttonUpdateOrders.Enabled = true;
            }
            catch (System.Exception ex)
            {
                comboBoxPhoneOrders.Text = "";
                comboBoxArticuleOrders.Text = "";
                numericStatusOrder.Value = 0;
                numericCountOrders.Value = 0;
            }
        }
        void selectedClients(object sender, EventArgs e)
        {
            try
            {
                comboBoxPhone.Text = dataTable.SelectedRows[0].Cells[1].Value.ToString();
                comboBoxName.Text = dataTable.SelectedRows[0].Cells[2].Value.ToString();
                numericUpPriv.Value = Convert.ToInt32(dataTable.SelectedRows[0].Cells[3].Value);
                comboBoxBirthday.Text = dataTable.SelectedRows[0].Cells[4].Value.ToString();
                comboBoxEmail.Text = dataTable.SelectedRows[0].Cells[5].Value.ToString();
                buttonClientsDelete.Enabled = true;
                buttonClientsUpdate.Enabled = true;
            }
            catch (System.Exception ex)
            {
                comboBoxPhone.Text = "";
                comboBoxName.Text = "";
                numericUpPriv.Value = 0;
                comboBoxBirthday.Text = "";
                comboBoxEmail.Text = "";
            }
        }
        void selectedUsers(object sender, EventArgs e)
        {
            try
            {
                comboBoxLogin.Text = dataTable.SelectedRows[0].Cells[1].Value.ToString();
                comboBoxPassword.Text = dataTable.SelectedRows[0].Cells[2].Value.ToString();
                numericDostup.Value = Convert.ToInt32(dataTable.SelectedRows[0].Cells[3].Value);
                buttonDeleteUsers.Enabled = true;
                buttonUpdateUsers.Enabled = true;
            }
            catch (System.Exception ex)
            {
                comboBoxLogin.Text = "";
                comboBoxPassword.Text = "";
                numericDostup.Value = 0;
            }
        }
        private void buttonOrders_Click(object sender, EventArgs e)
        {
            Model.openOrders();
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            Model.openClients();
           
        }

        private void buttonWares_Click(object sender, EventArgs e)
        {
            Model.openWares();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            Model.openUsers();
            
        }

        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataTable.Columns[0].Visible = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            mainWindow(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonClientsUpdate_Click(object sender, EventArgs e)
        {
            Model.updateInClents(dataTable.SelectedRows[0].Cells[0].Value.ToString(),
               comboBoxPhone.Text,
                comboBoxName.Text, numericUpPriv.Value.ToString(),
                comboBoxBirthday.Text, comboBoxEmail.Text);
        }

        private void buttonClientsInsert_Click(object sender, EventArgs e)
        {
            Model.insertInClients(comboBoxPhone.Text,
                comboBoxName.Text, numericUpPriv.Value.ToString(),
                comboBoxBirthday.Text, comboBoxEmail.Text);
        }

        private void buttonClientsDelete_Click(object sender, EventArgs e)
        {
            Model.deleteInClients(dataTable.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void buttonClientsSelect_Click(object sender, EventArgs e)
        {
            Model.selectInClients(comboBoxPhone.Text,
                comboBoxName.Text, numericUpPriv.Value.ToString(),
                comboBoxBirthday.Text, comboBoxEmail.Text);
        }

        private void buttonUpdateUsers_Click(object sender, EventArgs e)
        {
            Model.updateInUsers(dataTable.SelectedRows[0].Cells[0].Value.ToString(),
                comboBoxLogin.Text,comboBoxPassword.Text,numericDostup.Value.ToString());
        }

        private void buttonDeleteUsers_Click(object sender, EventArgs e)
        {
            Model.deleteInUsers(dataTable.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void buttonInsertUsers_Click(object sender, EventArgs e)
        {
            Model.insertInUsers(comboBoxLogin.Text, comboBoxPassword.Text, numericDostup.Value.ToString());
        }

        private void buttonSelectUsers_Click(object sender, EventArgs e)
        {
            Model.selectInUsers(comboBoxLogin.Text, comboBoxPassword.Text, numericDostup.Value.ToString());
        }

       
        private void buttonWaresUpdate_Click(object sender, EventArgs e)
        {
            Model.updateInWares(dataTable.SelectedRows[0].Cells[0].Value.ToString(),
                comboBoxArticuleWares.Text,
                comboBoxNameWares.Text, numericCountWares.Value.ToString(),
                comboBoxPrice.Text);
        }

        private void buttonWaresInsert_Click(object sender, EventArgs e)
        {
            Model.insertInWares(comboBoxArticuleWares.Text,
                comboBoxNameWares.Text, numericCountWares.Value.ToString(),
                comboBoxPrice.Text);
        }

        private void buttonWaresDelete_Click(object sender, EventArgs e)
        {
            Model.deleteInWares(dataTable.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void buttonWaresSelect_Click(object sender, EventArgs e)
        {
            Model.selectInWares(
                comboBoxArticuleWares.Text,comboBoxNameWares.Text, 
                numericCountWares.Value.ToString(),comboBoxPrice.Text);
        }

        private void buttonUpdateOrders_Click(object sender, EventArgs e)
        {
            Model.updateInOrders(dataTable.SelectedRows[0].Cells[0].Value.ToString(),
               comboBoxPhoneOrders.Text,
                comboBoxArticuleOrders.Text, numericStatusOrder.Value.ToString(),
                numericCountOrders.Value.ToString());
        }

        private void buttonInserOrders_Click(object sender, EventArgs e)
        {
            Model.insertInOrders(comboBoxPhoneOrders.Text, comboBoxArticuleOrders.Text,
                numericStatusOrder.Value.ToString(), numericCountOrders.Value.ToString());
        }

        private void buttonDeleteOrders_Click(object sender, EventArgs e)
        {
            Model.deleteInOrders(dataTable.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void buttonSelectOrders_Click(object sender, EventArgs e)
        {
            Model.selectInOrders(
                comboBoxPhoneOrders.Text,comboBoxArticuleOrders.Text, 
                numericStatusOrder.Value.ToString(),numericCountOrders.Value.ToString());
        }

        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataTable_SelectionChanged(object sender, EventArgs e)
        {
            Model.sellectRow();
        }

        private void dataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataTable.ClearSelection();
        }
    }
}
