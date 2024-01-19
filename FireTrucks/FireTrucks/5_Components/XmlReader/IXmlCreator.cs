namespace WhatWhere1.Components.XmlReader;

public interface IXmlCreator
{
    void CreateXmlEmergencyVehicle();

    void CreateXmlFirefightingVehicle();

    void QueryXmlEmergencyVehicle();

    void QueryXmlFirefightingVehicle();

    void CreateXmlJoined();
}