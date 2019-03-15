using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _clientName;
    private int _clientPhone;
    private string _clientNotes;
    private int _id;

    public Client(string clientName, int clientPhone, string clientNotes, int id = 0)
    {
      _clientName = clientName;
      _clientPhone = clientPhone;
      _clientNotes = clientNotes;
      _id = id;
    }

    public string GetName()
    {
      return _clientName;
    }

    public int GetPhone()
    {
      return _clientPhone;
    }

    public string GetNotes()
    {
      return _clientNotes;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string newName)
    {
      _clientName = newName;
    }

    public void SetPhone(int newPhone)
    {
      _clientPhone = newPhone;
    }

    public void SetNotes(string newNotes)
    {
      _clientNotes = newNotes;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool phoneEquality = this.GetPhone() == newClient.GetPhone();
        bool notesEquality = this.GetNotes() == newClient.GetNotes();
        return (idEquality && nameEquality && phoneEquality && notesEquality);
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        int ClientPhone = rdr.GetInt32(2);
        string ClientNotes = rdr.GetString(3);
        Client newClient = new Client(ClientName, ClientPhone, ClientNotes, ClientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phone, notes) VALUES (@name, @phone, @notes);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._clientName;
      cmd.Parameters.Add(name);
      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@phone";
      phone.Value = this._clientPhone;
      cmd.Parameters.Add(phone);
      MySqlParameter notes = new MySqlParameter();
      notes.ParameterName = "@notes";
      notes.Value = this._clientNotes;
      cmd.Parameters.Add(notes);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientName = "";
      int clientPhone = 0;
      string clientNotes = "";
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        clientPhone = rdr.GetInt32(2);
        clientNotes = rdr.GetString(3);
      }
      Client newClient = new Client(clientName, clientPhone, clientNotes, clientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public void DeleteClient(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId; DELETE FROM stylists_clients WHERE client_id = @ClientId;";
      MySqlParameter ClientId = new MySqlParameter();
      ClientId.ParameterName = "@ClientId";
      ClientId.Value = id;
      cmd.Parameters.Add(ClientId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newName, int newPhone, string newNotes)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newName, phone = @newPhone, notes = @newNotes WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@newPhone";
      phone.Value = newPhone;
      cmd.Parameters.Add(phone);
      MySqlParameter notes = new MySqlParameter();
      notes.ParameterName = "@newNotes";
      notes.Value = newNotes;
      cmd.Parameters.Add(notes);
      cmd.ExecuteNonQuery();
      _clientName = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* from clients
        JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
        JOIN stylists ON (stylists_clients.stylist_id = stylists.id)
        WHERE clients.id = @ClientId;";
      MySqlParameter clientIdParameter = new MySqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = _id;
      cmd.Parameters.Add(clientIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistDetails = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistName, stylistDetails, stylistId);
        stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylists;
    }

    public void AddStylist(Stylist stylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_clients (client_id, stylist_id) VALUES (@ClientId, @StylistId);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = stylist.GetId();
      cmd.Parameters.Add(stylist_id);
      MySqlParameter client_id = new MySqlParameter();
      client_id.ParameterName = "@ClientId";
      client_id.Value = _id;
      cmd.Parameters.Add(client_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearJoinTable()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists_clients";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
