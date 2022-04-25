using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App2
{
    class Program
    {
        private void ButtonClick(object sender, EventArgs e)
        {
            if (_passportTextbox.Text.Trim() == "")
                MessageBox.Show("Введите серию и номер паспорта");
            else
                ReportResultInput();
        }

        private void ReportResultInput()
        {
            string rawData = _passportTextbox.Text.Trim().Replace(" ", string.Empty);

            if (rawData.Length < 10)
                _textResult.Text = "Неверный формат серии или номера паспорта";
            else
                TryConnect(rawData);
        }

        private void TryConnect(string rawData)
        {
            string command = string.Format("select * from passports where num='{0}' limit 1;", (object)Format.ComputeSha256Hash(rawData));
            string connection = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

            try
            {
                SQLiteConnection sqLiteConnection = new SQLiteConnection(connection);
                sqLiteConnection.Open();
                SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(command, sqLiteConnection));
                DataTable dataTable = new DataTable();
                sqLiteDataAdapter.Fill(dataTable);
                ReportResultConnect(dataTable);
                sqLiteConnection.Close();
            }
            catch (SQLiteException exception)
            {
                if (exception.ErrorCode != 1)
                    return;

                MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
            }
        }

        private void ReportResultConnect(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
                GetVotingMessege(dataTable);
            else
                _textResult.Text = "Паспорт «" + _passportTextbox.Text + "» в списке участников дистанционного голосования НЕ НАЙДЕН";
        }

        private string GetVotingMessege(DataTable dataTable)
        {
            if (Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]))
                return _textResult.Text = "По паспорту «" + _passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
            else
                return _textResult.Text = "По паспорту «" + _passportTextbox.Text + "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
        }
    }
}