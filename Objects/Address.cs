using System;
using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Address
  {
    private string _street;
    private string _city;
    private string _state;
    private int _zipcode;

    public Address(string street, string city, string state, int zipcode)
    {
      _street = street;
      _city = city;
      _state = state;
      _zipcode = zipcode;
    }

    public string GetStreet()
    {
      return _street;
    }

    public string GetCity()
    {
      return _city;
    }

    public string GetState()
    {
      return _state;
    }

    public int GetZipcode()
    {
      return _zipcode;
    }
  }
}
