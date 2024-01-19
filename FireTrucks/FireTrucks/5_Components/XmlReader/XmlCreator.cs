using FireTrucks._5_Components.CsvReader;
using System.Xml.Linq;

namespace WhatWhere1.Components.XmlReader;

public class XmlCreator : IXmlCreator
{
    private readonly ICsvReader _csvReader;

    public XmlCreator(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void CreateXmlEmergencyVehicle()
    {
        var carsRecords = _csvReader.ProcessEmergencyVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\EmergencyVehicle.csv");

        var document = new XDocument();
        var cars = new XElement("EmergencyVehicles", carsRecords
            .Select(x =>
                new XElement("EmergencyVehicle",
                    new XAttribute("Manufacturer", x.Manufacturer),
                    new XAttribute("YearOfProduction", x.YearOfProduction),
                    new XAttribute("Weight", x.Weight))));

        document.Add(cars);
        document.Save("EmergencyVehicle.xml");
    }

    public void CreateXmlFirefightingVehicle()
    {
        var carsRecords = _csvReader.ProcessFirefightingVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\FirefightingVehicle.csv");

        var document = new XDocument();
        var cars = new XElement("FirefightingVehicles", carsRecords
            .Select(x =>
                new XElement("FirefightingVehicle",
                    new XAttribute("Manufacturer", x.Manufacturer),
                    new XAttribute("YearOfProduction", x.YearOfProduction),
                    new XAttribute("Weight", x.Weight))));

        document.Add(cars);
        document.Save("FirefightingVehicle.xml");
    }

    public void CreateXmlJoined()
    {
        var vehiclesFirefightingVehicleRecords = _csvReader.ProcessFirefightingVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\FirefightingVehicle.csv");
        var vehiclesEmergencyVehicleRecords = _csvReader.ProcessEmergencyVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\EmergencyVehicle.csv");

        var groupsJoined = vehiclesEmergencyVehicleRecords.GroupJoin(
            vehiclesFirefightingVehicleRecords,
            FirefightingVehicle => FirefightingVehicle.Manufacturer,
            EmergencyVehicle => EmergencyVehicle.Manufacturer,
            (e, f) =>
                new
                {
                    FirefightingVehicles = f,
                    EmergencyVehicles = e
                }
            )
        .OrderBy(x => x.EmergencyVehicles.Manufacturer);

        var document = new XDocument();

        var firefigterTrucks = new XElement("EmergencyVehicles", groupsJoined
            .Select(x =>
                new XElement("EmergencyVehicles",
                    new XAttribute("Name", x.EmergencyVehicles.YearOfProduction),
                    new XAttribute("Country", x.EmergencyVehicles.Equipment),
                    new XElement("FirefightingVehicles",
                    new XAttribute("Country", x.EmergencyVehicles.Weight),
                    new XAttribute("CombinedSum", x.FirefightingVehicles.Sum(c => c.NumbersOfFireHoses)),
                    new XElement("Vehicle", x.FirefightingVehicles
                                             .Select(c =>
                                                    new XElement("FirefightingVehicles",
                                                        new XAttribute("Model", c.VehicleCategory),
                                                        new XAttribute("NumbersOfFireHoses", c.NumbersOfFireHoses))))))));

        document.Add(firefigterTrucks);
        document.Save("EmergencyVehicleAndFirefightingVehicle.xml");
    }

    public void QueryXmlEmergencyVehicle()
    {
        var document = XDocument.Load("EmergencyVehicle.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("EmergencyVehicle")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void QueryXmlFirefightingVehicle()
    {
        var document = XDocument.Load("FirefightingVehicle.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("FirefightingVehicle")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}