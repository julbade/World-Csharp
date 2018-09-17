using System.Collections.Generic;
using System.Collections;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
  public class City
  {
    private string _cityName;
    private int _id;


    public City (string cityName, int Id = 0)
    {
      _cityName = cityName;
      _id = Id;

    }
    public string GetCityName()
    {
      return _cityName;
    }
    public void SetCityName(string newCityName)
    {
      _cityName = newCityName;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<City> GetAll()
    {
            List<City> allCitys = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM world;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string cityDescription = rdr.GetString(1);
              City newCity = new City(cityDescription, cityId);
              allCitys.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCitys;
        }

   }
  }
