using System;
using System.Collections.Generic;
using System.Linq;
public class Ticket
{
    public DateTime FlightTime { get; set; }
    public string FlightNumber { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }
    public override string ToString() => $"{From}-{To}, {FlightTime}, Number:{FlightNumber},Price:{Price}";
}
public class TicketInquiry
{
    public List<Ticket> Inquiry(DateTime date, string from, string to)
    {
        var iranAirFlights = new IranAir().SearchFlights(date, from, to);
        var mahanFlights = new Mahan().Search(date, from, to);
        var ataFlights = new ATA().Find(date, from, to);

        List<Ticket> result = new();
        result.AddRange(iranAirFlights);
        result.AddRange(mahanFlights);
        result.AddRange(ataFlights);
        return result.OrderBy(x => x.Price).ToList();
    }
}
public class IranAir
{
    readonly Ticket[] iranairTickets = new[]
    {
            new Ticket() { FlightNumber = "IA1000", FlightTime = new DateTime(2021,01,02,11,20,00), Price = 800000, From="Tehran",To="Urmia" },
            new Ticket() { FlightNumber = "IA2000", FlightTime = new DateTime(2021,01,02,12,45,00), Price = 750000, From="Tehran",To="Rasht" },
            new Ticket() { FlightNumber = "IA3000", FlightTime = new DateTime(2021,01,03,09,10,00), Price = 700000, From="Tehran",To="Urmia" },
            new Ticket() { FlightNumber = "IA4000", FlightTime = new DateTime(2021,01,02,18,45,00), Price = 775000, From="Tehran",To="Tabriz" },
            new Ticket() { FlightNumber = "IA5000", FlightTime = new DateTime(2021,01,02,22,00,00), Price = 780000, From="Tehran",To="Ahvaz" },
        };
    public Ticket[] SearchFlights(DateTime date, string from, string to) => iranairTickets.Where(x => x.FlightTime.Date == date.Date && x.From == from && x.To == to).ToArray();

}
public class Mahan
{
    readonly Ticket[] mahanTickets = new[]
    {
            new Ticket() { FlightNumber = "M999", FlightTime = new DateTime(2021,01,03,13,30,00), Price = 1500000, From="Tehran",To="Zahedan" },
            new Ticket() { FlightNumber = "M888", FlightTime = new DateTime(2021,01,04,15,00,00), Price = 810000, From="Tehran",To="Urmia" },
            new Ticket() { FlightNumber = "M777", FlightTime = new DateTime(2021,01,02,06,10,00), Price = 745000, From="Tehran",To="Rasht" }
        };
    public Ticket[] Search(DateTime date, string from, string to) => mahanTickets.Where(x => x.FlightTime.Date == date.Date && x.From == from && x.To == to).ToArray();
}
public class ATA
{
    readonly Ticket[] ataTickets = new[]
    {
            new Ticket() { FlightNumber = "A123", FlightTime = new DateTime(2021,01,02,07,10,00), Price = 805000, From="Tehran",To="Urmia" },
            new Ticket() { FlightNumber = "A456", FlightTime = new DateTime(2021,01,03,09,20,00), Price = 750000, From="Tehran",To="Sari" },
            new Ticket() { FlightNumber = "A789", FlightTime = new DateTime(2021,01,02,16,50,00), Price = 700000, From="Tehran",To="Tabriz" },
            new Ticket() { FlightNumber = "A159", FlightTime = new DateTime(2021,01,03,23,10,00), Price = 775000, From="Tehran",To="Sanandaj" },
            new Ticket() { FlightNumber = "A357", FlightTime = new DateTime(2021,01,02,05,00,00), Price = 780000, From="Tehran",To="Urmia" },
        };
    public Ticket[] Find(DateTime date, string from, string to) => ataTickets.Where(x => x.FlightTime.Date == date.Date && x.From == from && x.To == to).ToArray();
}